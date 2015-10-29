using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using System.Data.SqlClient;
using System.Data;

namespace Connection
{
    class Connection
    {
        private static Configuration cfg = null;

        public static Configuration getConfiguration()
        {
            if (cfg == null)
            {
                cfg = new Configuration().Configure();

                //string ip = "115.24.161.31";// IniReadAndWrite.IniReadValue("connect", "ip");
                //string id = "sa";//IniReadAndWrite.IniReadValue("connect", "id");
                //string pwd = "iti@240";// IniReadAndWrite.IniReadValue("connect", "pwd");
                //string db = "XBNews";//IniReadAndWrite.IniReadValue("connect", "db");
                //cfg.SetProperty("connection.connection_string", "UID=" + id + ";PWD=" + pwd + ";Database=" + db + ";server=" +ip);
                //cfg.AddAssembly("ClassLibrary");
            }
            return cfg;
        }

        private static SqlConnection connection = null;

        public static SqlConnection getSqlConnection()
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection("UID=" + "sa" + ";PWD=" + "iti@240" + ";Database=" + "XBNews" + ";server=" + "115.24.161.31");
            }
            if (connection.State != ConnectionState.Open)
            {
                try
                {
                    connection.Open();
                }
                catch
                {
                    throw;
                }
            }
            return connection;
        }

    }
}
