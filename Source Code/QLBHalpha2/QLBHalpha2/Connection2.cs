using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml;
using System.Data;

namespace QLBHalpha2
{
    partial class Connection2
    {
        SqlConnection con;
        String queue;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet Dset = new DataSet();
        DataTable tableResult = new DataTable();
        SqlCommandBuilder build = null;


        //--------------
        public String conString;
        public static String sv;
        public static String CSDL;
        public static String user;
        public static String pass;

        public void connect()
        {
            //XmlDocument xmlread = new XmlDocument();
            //xmlread.Load("Connection.xml");
            //XmlElement xmlelement1 = xmlread.DocumentElement;
            //sv = xmlelement1.SelectSingleNode("sv").InnerText;
            //CSDL = xmlelement1.SelectSingleNode("database").InnerText;
            //user = xmlelement1.SelectSingleNode("username").InnerText;
            //pass = xmlelement1.SelectSingleNode("password").InnerText;

            //if (user == "") // dang nhap authentication ; ko dung user - pass
            //    conString = @"Data Source = " + sv + ";Initial Catalog = " + CSDL + ";Integrated Security=SSPI;";
            //else
            //    conString = @"Data Source=" + sv + ";Initial Catalog=" + CSDL + ";User Id=" + user + ";Password=" + pass + ";";
            //con = new SqlConnection(conString);
            con = new SqlConnection("server=.\\SQLEXPRESS;database=QUANLYBANHANG_DIENTU;Integrated Security=SSPI");
        }

        public bool checkConn()
        {
            connect();
            try
            {
                con.Open();
                if (con.State != ConnectionState.Open)
                {
                    MessageBox.Show("Loi ket noi CSDL - kiem tra file Connection.xml trong thu muc debug");
                    Application.Exit();
                    return false;
                }
                else
                    return true;
            }
            catch (Exception)
            {
                MessageBox.Show("2Loi ket noi CSDL - kiem tra file Connection.xml trong thu muc debug");
                return false;
            }
        }

        // dong nay duoc chuyen qua UserSQL để dễ quản lý
       
        /// xu ly boi from nhan vien
        /// 
        public int save()
        {
            connect();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int dem = 0;
            try
            {
                build = new SqlCommandBuilder(da);
                dem = da.Update(tableResult);
                con.Close();
                return dem;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi save " + ex.ToString());
                return 0;
                throw;
            }
        }

       
        public DataTable thuchienSQL(String queue, bool check)
        {
            try
            {
                connect();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                if (check == true)
                {
                    da = new SqlDataAdapter(queue, con);
                    tableResult = new DataTable();
                    da.Fill(tableResult);
                    return tableResult;
                }
                else
                {
                    SqlDataAdapter da1 = new SqlDataAdapter();
                    DataTable tableResult1 = new DataTable();
                    da = new SqlDataAdapter(queue, con);
                    da.Fill(tableResult1);
                    return tableResult1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi thuchienSQL " + ex.ToString());
                throw;
            }
        }
       

       ///ssssssssssssssssssssssssss
       ///buc
       ///backup -restore
       ///

        
        public String backup(String path)
        {
            ///mo file xml de lay ten database
            ///
            try
            {
                connect();
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                XmlDocument xmlread = new XmlDocument();
                xmlread.Load("Connection.xml");
                XmlElement xmlelement1 = xmlread.DocumentElement;
                String tenCSDL = xmlelement1.SelectSingleNode("database").InnerText;
                queue = "BACKUP DATABASE ["+tenCSDL+"] TO  DISK = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL.2\\MSSQL\\Backup\\quanlybanhang.bak' WITH NOFORMAT, NOINIT,  NAME = N'quanlybanhang-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                MessageBox.Show(queue);
                SqlCommand cmd = new SqlCommand(queue, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return queue;

            }
            catch(Exception ex)
            {
                MessageBox.Show("lỗi backup CSDL " + ex.ToString());
                throw;
            }
        }
        public void restore(String path)
        {
             try
            {
                connect();
                if (con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                XmlDocument xmlread = new XmlDocument();
                xmlread.Load("Connection.xml");
                XmlElement xmlelement1 = xmlread.DocumentElement;
                String tenCSDL = xmlelement1.SelectSingleNode("database").InnerText;
                queue = "RESTORE DATABASE ["+tenCSDL+"] FROM  DISK = N'C:\\Program Files\\Microsoft SQL Server\\MSSQL.2\\MSSQL\\Backup\\quanlybanhang.bak' WITH  FILE = 3,  NOUNLOAD,  STATS = 10";
                //MessageBox.Show(queue);
                SqlCommand cmd = new SqlCommand(queue, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("lỗi backup CSDL " + ex.ToString());
                throw;
            }
        }


    }
}

