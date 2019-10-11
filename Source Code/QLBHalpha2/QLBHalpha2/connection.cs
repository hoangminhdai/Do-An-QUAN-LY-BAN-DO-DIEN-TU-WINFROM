using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Xml;

namespace QLBHalpha2
{
    partial class connection
    {
        private static SqlConnection con;
        public static String conString;
        public static String sv;
        public static String CSDL;
        public static String user;
        public static String pass;

        public connection()
        {
            Console.WriteLine("khoi tao connect");
        }

        public static void connectionString()
        {
            XmlDocument xmlread = new XmlDocument();
            xmlread.Load("Connection.xml");
            XmlElement xmlelement1 = xmlread.DocumentElement;
            sv = xmlelement1.SelectSingleNode("sv").InnerText;
            CSDL = xmlelement1.SelectSingleNode("database").InnerText;
            user = xmlelement1.SelectSingleNode("username").InnerText;
            pass = xmlelement1.SelectSingleNode("password").InnerText;

            if (user == "") // dang nhap authentication ; ko dung user - pass
                conString = @"Data Source = " + sv + ";Initial Catalog = " + CSDL + ";Integrated Security=SSPI;";
            else
                conString = @"Data Source=" + sv + ";Initial Catalog=" + CSDL + ";User Id=" + user + ";Password=" + pass + ";";

            Console.WriteLine(conString);
        }

        public static bool OpenConnect()
        {
            if (conString == "")
                connectionString();
            try
            {

                if (con == null)
                {
                    con = new SqlConnection(conString);
                }
                if (con.State.ToString().Equals("Close"))
                {
                    con.Open();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                con.Close();
                return false;
            }
        }
    }
}
