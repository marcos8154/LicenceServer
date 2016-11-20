using DBX.Cache;
using DBX.Command;
using DBX.Entities;
using DBX.OPERATIONS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Doware_LicenceServer
{
    public class DBUtil
    {
        public static void Initialize()
        {
            bool saUserHasAdded = false;
            User sa = new User();

            User ls = new User();
            ls.NAME = "LS";

            CmdProccess proccess = new CmdProccess();

            if (!Directory.Exists((@"C:\DBXServer")))
            {
                Console.WriteLine("Creating default structure for SYSTEM...");
                Directory.CreateDirectory(@"C:\DBXServer");
                Directory.CreateDirectory(@"C:\DBXServer\SYSTEM_DATABASES");
                Directory.CreateDirectory(@"C:\DBXServer\TEMP");
                Directory.CreateDirectory(@"C:\DBXServer\SYSTEM_DATABASES\AUTO_BACKUP");
                Directory.CreateDirectory(@"C:\DBXServer\SYSTEM_DATABASES\STARTUP");

                sa.NAME = "SA";
                sa.PASSWD = "6d5sa565654365566656/´[~[vaãv[~çb[aç~h43-0vk w9-I390JB90WJJBFIOJVIO348586454984J84TM8T48GRS";
                ConnectedUsers.Add(sa);
                saUserHasAdded = true;

                INITDATABASE init = new INITDATABASE();
                init.Init();
                sa.DATABASE = new SELECT().LoadSYSTEM();

                proccess.Execute(@"create database licencedb in c:\dbxserver\licencedb.dbx", ConnectedUsers.Find("SA"));
                proccess.Execute("connect licencedb as LS", ConnectedUsers.Find("SA"));
                proccess.Execute("create table usuarios(id int(10), nome varchar(100), ativo int(1))", ConnectedUsers.Find("LS"));
                proccess.Execute("create table logs(usuario int(10), data varchar(30))", ConnectedUsers.Find("LS"));
            }

            if (!saUserHasAdded)
            {
                sa.NAME = "SA";
                sa.PASSWD = "6d5sa565654365566656/´[~[vaãv[~çb[aç~h43-0vk w9-I390JB90WJJBFIOJVIO348586454984J84TM8T48GRS";
                sa.DATABASE = new SELECT().LoadSYSTEM();
                ConnectedUsers.Add(sa);
            }

            Console.WriteLine("Cleaning up locks...");

            proccess.Execute("empty table locks", sa);
            Console.WriteLine("Cleaning up temporary files...");
            DirectoryInfo drInfo = new DirectoryInfo(@"C:\DBXServer\TEMP\");

            foreach (FileInfo fi in drInfo.GetFiles())
            {
                fi.Delete();
            }
        }
    }
}
