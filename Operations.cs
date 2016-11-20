using DBX.Cache;
using DBX.Command;
using Doware_LicenceServer.LicenceObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Doware_LicenceServer
{
    public class Operations
    {
        public static bool Verify(int userId)
        { 
            CmdProccess cmd = GetCmd();
            Console.Write("");
            cmd.Execute("select * from usuarios where ativo = 1", ConnectedUsers.Find("LS"));

            if (cmd.RESULT_TABLE == null)
                return false;
            if (cmd.RESULT_TABLE.Rows.Count == 0)
                return false;

            foreach (DataRow row in cmd.RESULT_TABLE.Rows)
            {
                if (int.Parse(row["id"].ToString()) == userId)
                    return true;
            }

            return false;
        }

        public static void RemoveUser(int userId)
        {
            string sql = "delete from usuarios where id = " + userId;
            CmdProccess cmd = GetCmd();
            cmd.Execute(sql, ConnectedUsers.Find("LS"));
        }

        public static int GetCountUsers()
        {
            string sql = "select * from usuarios where ativo = 1";
            CmdProccess cmd = GetCmd();
            cmd.Execute(sql, ConnectedUsers.Find("LS"));
            if (cmd.RESULT_TABLE == null)
                return 0;
            return cmd.RESULT_TABLE.Rows.Count;
        }

        public static string RegisterUser(LicenceUser user)
        {
            Licence licence = Program.LoadLicenceFromFile();
            int usersCount = GetCountUsers();
            if (usersCount >= int.Parse(licence.USUARIOS))
                return "O número de usuários permitidos na licenca foi excedido.";

            string sql = @"insert into usuarios(id, nome, ativo) values (" + user.ID + ", " + user.NAME + ", " + (user.ACTIVE ? "1" : "0") + ")";
            CmdProccess cmd = GetCmd();
            cmd.Execute(sql, ConnectedUsers.Find("LS"));
            return "1";
        }

        public static bool IsValidDate(int usuario)
        {
            DateTime? date = GetLastDate();

            if(date == null)
            {
                AddDate(usuario);
                return true;
            }

            if (date.Value.Date > DateTime.Now.Date)
                return false;

            return true;
        }

        private static void AddDate(int usuario)
        {
            string sql = "insert into logs(usuario, data) values (" + usuario + ", " + DateTime.Now + ")";

            CmdProccess cmd = GetCmd();
            cmd.Execute(sql, ConnectedUsers.Find("LS"));
        }

        public static DateTime? GetLastDate()
        {
            CmdProccess cmd = GetCmd();
            cmd.Execute("select * from logs", ConnectedUsers.Find("LS"));

            if (cmd.RESULT_TABLE == null)
                return null;
            if (cmd.RESULT_TABLE.Rows.Count == 0)
                return null;

            DataRow row = cmd.RESULT_TABLE.Rows[cmd.RESULT_TABLE.Rows.Count - 1];
            return Convert.ToDateTime(row["data"]);
        }

        public static CmdProccess GetCmd()
        {
            CmdProccess cmd = new CmdProccess();
         //   cmd.Execute("connect licencedb as LS", ConnectedUsers.Find("SA"));
            return cmd;
        }
    }
}
