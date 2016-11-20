using DBX.Cache;
using DBX.Command;
using DBX.Entities;
using DBX.OPERATIONS;
using Doware_LicenceServer.LicenceObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Doware_LicenceServer
{
    class Program
    {
        private static readonly Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static readonly List<Socket> clientSockets = new List<Socket>();
        private const int BUFFER_SIZE = 4096;
        private const int PORT = 14449;
        private static readonly byte[] buffer = new byte[BUFFER_SIZE];

        static void Main(string[] args)
        {
            Console.Title = "Doware Licence Server - " + Version;

            string licenceFile = Directory.GetCurrentDirectory() + @"\licence.dwkey";
            if (!File.Exists(licenceFile))
                new Configure().ShowDialog();

            StartupServer();
            
            CmdProccess cmd = new CmdProccess();
            cmd.Execute("connect licencedb as LS", ConnectedUsers.Find("SA"));
            Console.ReadKey();
        }

        private static void StartupServer()
        {
            DBUtil.Initialize();

            LicenceObjects.Licence licence = LoadLicenceFromFile();
            if (string.IsNullOrEmpty(licence.ID_CLIENTE))
            {
                new Configure().ShowDialog();
                StartupServer();
            }

            if (!licence.ID_CPU.Equals(GetCPUID()))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("**********************************************************************");
                Console.WriteLine("***  A inicialização do servidor de licenças foi interrompida      ***");
                Console.WriteLine("***  porque o arquivo de licenças não pertence a este hardware.    ***");
                Console.WriteLine("***  A utilização do serviço foi temporariamente bloqueada         ***");
                Console.WriteLine("***  juntamente com os produtos Doware dependentes do mesmo.       ***");
                Console.WriteLine("**********************************************************************");
                return;
            }
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, PORT));
            serverSocket.Listen(0);
            serverSocket.BeginAccept(AcceptCallback, null);
            Console.WriteLine("Server start complete");
        }

        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;

            try
            {
                socket = serverSocket.EndAccept(AR);

                clientSockets.Add(socket);
                socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, socket);
                serverSocket.BeginAccept(AcceptCallback, null);
            }
            catch (ObjectDisposedException) // I cannot seem to avoid this (on exit when properly closing sockets)
            {
            }
        }

        private static void ReceiveCallback(IAsyncResult AR)
        {
            try
            {
                Socket current = (Socket)AR.AsyncState;
                int received;

                try
                {
                    received = current.EndReceive(AR);
                }
                catch (SocketException)
                {
                    Console.WriteLine("Client forcefully disconnected");
                    // Don't shutdown because the socket may be disposed and its disconnected anyway.
                    current.Close();
                    clientSockets.Remove(current);
                    return;
                }


                byte[] recBuf = new byte[received];
                Array.Copy(buffer, recBuf, received);
                string commandText = Encoding.Default.GetString(recBuf);
                string resultText = string.Empty;

                Licence licence = LoadLicenceFromFile();
                if (DateTime.Now.Date > licence.VENCIMENTO.Date)
                    resultText = @"O Licence Server não conseguiu completar a operação devido
                        ao arquivo de licenças estar com a data de validade vencida. O serviço foi temporariamente bloqueado juntamente com 
os produtos Doware dependentes do mesmo. Entre em contato com o setor financeiro da Doware 
para legalizar a situação.";

                if (!Operations.IsValidDate(0))
                    resultText = @"O Licence Server não conseguiu completar a operação devido a 
data do sistema operacional não estar de acordo com os registros. O serviço foi temporariamente bloqueado juntamente com 
os produtos Doware dependentes do mesmo.";

                if (string.IsNullOrEmpty(resultText))
                {
                    if (commandText.StartsWith("VR "))
                    {
                        commandText = commandText.Replace("VR ", "");
                        if (Operations.Verify(int.Parse(commandText)))
                            resultText = "1";
                        else
                            resultText = "Não autorizado pelo servidor de licenças";
                    }

                    if (commandText.StartsWith("RU"))
                    {
                        commandText = commandText.Replace("RU ", "");
                        LicenceUser user = JsonConvert.DeserializeObject<LicenceUser>(commandText);
                        resultText = Operations.RegisterUser(user);
                    }

                    if (commandText.StartsWith("DU"))
                    {
                        commandText = commandText.Replace("DU ", "");
                        Operations.RemoveUser(int.Parse(commandText));
                        resultText = "1";
                    }
                }

                byte[] resultData = null;

                resultData = Encoding.UTF8.GetBytes(resultText);
                current.Send(resultData);
                current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, current);
            }
            catch (Exception ex)
            {

            }
        }

        public static string Version
        {
            get
            {
                return "1.2.1311";
            }
        }

        public static LicenceObjects.Licence LoadLicenceFromFile()
        {
            FileStream stream = null;
            try
            {
                string licenceFile = Directory.GetCurrentDirectory() + @"\licence.dwkey";
                stream = File.OpenRead(licenceFile);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                LicenceObjects.Licence licence = (LicenceObjects.Licence)binaryFormatter.Deserialize(stream);
                stream.Close();
                return FillLicence(licence);
            }
            catch (Exception ex)
            {
                if (stream != null)
                    stream.Close();
            }
            return new LicenceObjects.Licence();
        }

        private static LicenceObjects.Licence FillLicence(LicenceObjects.Licence licence)
        {
            licence.ID_CLIENTE = licence.ID_CLIENTE.FromCompact();
            licence.ID_CONTRATO = licence.ID_CONTRATO.FromCompact();
            licence.ID_INSTALACAO = licence.ID_INSTALACAO.FromCompact();
            licence.USUARIOS = licence.USUARIOS.FromCompact();

            return licence;
        }

        public static void SaveLicence(LicenceObjects.Licence licence)
        {
            FileStream stream = null;
            try
            {
                string licenceFile = Directory.GetCurrentDirectory() + @"\licence.dwkey";
                if (File.Exists(licenceFile)) File.Delete(licenceFile);
                stream = File.OpenWrite(licenceFile);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, licence);
                stream.Close();
            }
            catch (Exception ex)
            {
                if (stream != null)
                    stream.Close();
            }
        }

        public static string GetCPUID()
        {
            String cpuid = "";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_Processor");

                foreach (ManagementObject share in searcher.Get())
                    cpuid = share["ProcessorId"].ToString();
            }
            catch (Exception) { }
            return cpuid;
        }
    }

    public static class Compactor
    {
        public static string ToCompact(this string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            MemoryStream ms = new MemoryStream();
            using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
            {
                zip.Write(buffer, 0, buffer.Length);
            }

            ms.Position = 0;
            MemoryStream outStream = new MemoryStream();

            byte[] compressed = new byte[ms.Length];
            ms.Read(compressed, 0, compressed.Length);

            byte[] gzBuffer = new byte[compressed.Length + 4];
            System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);
            System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
            return Convert.ToBase64String(gzBuffer);
        }

        public static string FromCompact(this string compressedText)
        {
            byte[] gzBuffer = Convert.FromBase64String(compressedText);
            using (MemoryStream ms = new MemoryStream())
            {
                int msgLength = BitConverter.ToInt32(gzBuffer, 0);
                ms.Write(gzBuffer, 4, gzBuffer.Length - 4);

                byte[] buffer = new byte[msgLength];

                ms.Position = 0;
                using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress))
                {
                    zip.Read(buffer, 0, buffer.Length);
                }
                return Encoding.UTF8.GetString(buffer);
            }
        }
    }
}
