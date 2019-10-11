using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QLBHalpha2
{
    partial class Connection2
    {
        public String getQuyen(String id)
        {
            queue = ("select maquyen from nguoidung where id = '" +id+ " '");
            DataTable d = thuchienSQL(queue,false);
            String s = "";
            foreach(DataRow dr in d.Rows )
            {
                s = dr["maquyen"].ToString();

            }
            return s;
        }
        public DataSet getUser(String id)
        {
            if (checkConn())
            {
                connect();
                con.Open();

                queue = "select * from nguoidung where id = @id";
                da.SelectCommand = new SqlCommand(queue, con);
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Char).Value = id;
                Dset.Clear();
                da.Fill(Dset);
                return Dset;
            }
            else
                return Dset;

        }

        public DataSet getUser()
        {
            connect();
            con.Open();
            queue = "select id,pass, maquyen,tennv from nguoidung u1,nhanvien n1 where u1.mnv=n1.mnv";
            da.SelectCommand = new SqlCommand(queue, con);
            Dset.Clear();
            da.Fill(Dset);
            return Dset;
        }

        public DataTable layngdung()
        {

            queue = "select * from nguoidung";
           // queue = queue = "select id,pass, maquyen,tennv from nguoidung u1,nhanvien n1 where u1.manv=n1.manv";
            return thuchienSQL(queue, true);
        }

        public DataTable laymaquyen()
        {
            queue = "select distinct maquyen from quyen";
            return thuchienSQL(queue, false);
        }
        public DataTable laymaquyen2()
        {
            queue = "select maquyen from quyen";
            return thuchienSQL(queue, false);
        }

        public void updateMKuser(String id, String newpass)
        {
            //connect();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //con.Open();
            queue = "update nguoidung set pass=@pass where id = @id";
            da.UpdateCommand = new SqlCommand(queue, con);
            da.UpdateCommand.Parameters.Add("@id", SqlDbType.Char).Value = id;
            da.UpdateCommand.Parameters.Add("@pass", SqlDbType.VarChar).Value = newpass;
            da.UpdateCommand.ExecuteNonQuery();
            con.Close();
        }
        public DataTable GetSP(String msp)
        {
            connect();
            if (con.State ==ConnectionState.Closed)
            {
                con.Open();
            }
                queue = "select * from SANPHAM where MSP=@MSP";
                da.SelectCommand = new SqlCommand(queue, con);
                da.SelectCommand.Parameters.Add("@MSP", SqlDbType.Char).Value = msp;
                tableResult.Clear();
                da.Fill(tableResult);
                //MessageBox.Show("ket noi co so du lieu");
                //MessageBox.Show(tableResult.Rows.Count.ToString());
                return tableResult;
        }
        public Boolean InsertSP(SP s)
        {
            connect();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
           
            try
            {

                SqlCommand insert_sp = new SqlCommand("INSERT_SANPHAM", con);
                insert_sp.Parameters.Add("@MSP", SqlDbType.Char, 10).Value = s.GetMSP();
                insert_sp.Parameters.Add("@ML", SqlDbType.Char, 10).Value = s.GetML();
                insert_sp.Parameters.Add("@MNSX", SqlDbType.Char, 10).Value = s.GetMNSX();
                insert_sp.Parameters.Add("@TENSP", SqlDbType.VarChar).Value = s.GetTensp();
               // insert_sp.Parameters.Add("@HSD", SqlDbType.DateTime).Value = s.GetHSD();
                insert_sp.Parameters.Add("@DVT", SqlDbType.Char, 10).Value = s.GetDVT();
                insert_sp.Parameters.Add("@GIAMUA", SqlDbType.Money).Value = s.GetGiaMua();
                insert_sp.Parameters.Add("@GIABAN", SqlDbType.Money).Value = s.GetGiaban();
                insert_sp.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                con.Dispose();
            }
            

        }
        public Boolean SetDH(String mdh)
        {
            connect();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            try
            {
                SqlCommand set_status = new SqlCommand("SET_STATUS_DH", con);
                set_status.CommandType = CommandType.StoredProcedure;
                set_status.Parameters.Add("@MDH", SqlDbType.Char, 10).Value = mdh;
                set_status.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                con.Dispose();
            }
        }

        public Boolean MuaHang(HoaDon hd) //mua hang truc tiep va lap hoa don tu phieu dat hang
        {
            connect();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
           
            SqlTransaction muahang = con.BeginTransaction();
            try
            {
                SqlCommand insert_hoadon = new SqlCommand("INSERT_HOADON", con, muahang);
                insert_hoadon.CommandType = CommandType.StoredProcedure;
                insert_hoadon.Parameters.Add("@MKH", SqlDbType.Char).Value = hd.GetMKH();
                insert_hoadon.Parameters.Add("@MNV", SqlDbType.Char).Value = hd.GetMNV();
                hd.SetMHD((int)insert_hoadon.ExecuteScalar());
                foreach (SP sp in hd.GetListSP())
                {//ghi chi tiet hoa don
                    
                    SqlCommand insert_cthd = new SqlCommand("INSERT_CTHD", con, muahang);
                    insert_cthd.CommandType = CommandType.StoredProcedure;
                    insert_cthd.Parameters.Add("@MHD", SqlDbType.Int).Value = hd.GetMHD();
                    insert_cthd.Parameters.Add("@MSP", SqlDbType.Char).Value = sp.GetMSP();
                    insert_cthd.Parameters.Add("@GIABAN", SqlDbType.Money).Value = sp.GetGiaban();
                    insert_cthd.Parameters.Add("@SOLUONG", SqlDbType.Int).Value = sp.GetSoluong();
                    insert_cthd.Parameters.Add("@THANHTIEN", SqlDbType.Money).Value = sp.GetThanhtien();
                    insert_cthd.ExecuteNonQuery();

                }
                muahang.Commit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi " + ex.ToString());
                muahang.Rollback();
                return false;
            }
            finally
            {
                con.Dispose();
            }
            

        }
        public Boolean DatHang(DatHang dh)
        {
            connect();
            con.Open();
            
            SqlTransaction dathang = con.BeginTransaction();
            try
            {
               
                SqlCommand insert_dh = new SqlCommand("INSERT_DATHANG", con, dathang);
                insert_dh.CommandType = CommandType.StoredProcedure;
                insert_dh.Parameters.Add("@MKH", SqlDbType.Char).Value = dh.GetMKH();
                insert_dh.Parameters.Add("@MNV", SqlDbType.Char).Value = dh.GetMNV();
                insert_dh.Parameters.Add("@DATE", SqlDbType.DateTime).Value = dh.GetDate();
                //insert_dh.Parameters.Add("@TINHTRANG", SqlDbType.Int).Value = dh.GetStatus();
                dh.SetMDH((int)insert_dh.ExecuteScalar());

               
                
                foreach (SP sp in dh.GetListSP())
                {
                    
                    SqlCommand insert_ctdh = new SqlCommand("INSERT_CTDH", con, dathang);
                    insert_ctdh.CommandType = CommandType.StoredProcedure;
                    insert_ctdh.Parameters.Add("@MDH", SqlDbType.Char).Value = dh.GetMDH();
                    insert_ctdh.Parameters.Add("@MSP", SqlDbType.Char).Value = sp.GetMSP();
                    insert_ctdh.Parameters.Add("@GIABAN", SqlDbType.Money).Value = sp.GetGiaban();
                    insert_ctdh.Parameters.Add("@SLDATHANG", SqlDbType.Int).Value = sp.GetSoluong();
                    insert_ctdh.Parameters.Add("@THANHTIEN", SqlDbType.Money).Value = sp.GetThanhtien();
                    insert_ctdh.ExecuteNonQuery();
                }
                dathang.Commit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi " + ex.ToString());
                dathang.Rollback();
                return false;
            }
            finally
            {
                con.Dispose();
            }


        }
        public Boolean NhapHang(NhapHang nh)
        {
            connect();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
           

            SqlTransaction nhaphang = con.BeginTransaction();
            try
            {
               
                SqlCommand insert_nh = new SqlCommand("INSERT_PNH", con, nhaphang);
                insert_nh.CommandType = CommandType.StoredProcedure;
                insert_nh.Parameters.Add("@MNCC", SqlDbType.Char).Value = nh.GetMNCC();
                insert_nh.Parameters.Add("@MNV", SqlDbType.Char).Value = nh.GetMNV();
                nh.SetMPN((int)insert_nh.ExecuteScalar());
                foreach (SP sp in nh.GetListSP())
                {//ghi chi tiet hoa don
                    SqlCommand insert_ctnh = new SqlCommand("INSERT_CTPNH", con, nhaphang);
                    insert_ctnh.CommandType = CommandType.StoredProcedure;
                    insert_ctnh.Parameters.Add("@MPN", SqlDbType.Int).Value = nh.GetMPN();
                    insert_ctnh.Parameters.Add("@MSP", SqlDbType.Char).Value = sp.GetMSP();
                    insert_ctnh.Parameters.Add("@GIAMUA", SqlDbType.Money).Value = sp.GetGiaMua();
                    insert_ctnh.Parameters.Add("@SLNHAP", SqlDbType.Int).Value = sp.GetSoluong();
                    insert_ctnh.Parameters.Add("@THANHTIEN", SqlDbType.Money).Value = sp.GetThanhtien();
                    insert_ctnh.ExecuteNonQuery();

                }
               nhaphang.Commit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi " + ex.ToString());
                nhaphang.Rollback();
                return false;
            }
            finally
            {
                con.Dispose();
            }
            

        }
       
 

    }
}

