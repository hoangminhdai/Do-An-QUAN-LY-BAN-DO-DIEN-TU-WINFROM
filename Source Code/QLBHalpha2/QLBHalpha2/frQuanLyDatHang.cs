using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLBHalpha2
{
    public partial class frQuanLyDatHang : Form
    {
        Connection2 c2 = new Connection2();
        DataTable DtableDh0 = new DataTable();
        DataTable DtableCTDH = new DataTable();
        BindingSource binds = new BindingSource(); // lam bv
        BindingSource bindsCTDH = new BindingSource(); // lam nv datagridview CHDH
        HoaDon hd = new HoaDon();
        String mdh = "";
        public frQuanLyDatHang()
        {
            InitializeComponent();
        }

        private void frQuanLyDatHang_Load(object sender, EventArgs e)
        {
            hienthi_donDh0();
        }

        /// hien thi DS cac don dat hang tinh trang 0
        /// 
        private void hienthi_donDh0()
        {
            try
            {
                dataGridViewX1.AutoGenerateColumns = false;
                dataGridViewX1.AllowUserToAddRows = false;
                DtableDh0 = c2.LayDSdatHang0();
                binds.DataSource = DtableDh0;
                bindingNavigator1.BindingSource = binds;
                dataGridViewX1.DataSource = binds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi hien thi QLDH" + ex.ToString());
                throw;
            }
        }

        private void hienthiCTdathang(String mdh) // hien thi CT dat hang theo maDH
        {
            try
            {
                dataGridViewX2.AutoGenerateColumns = false;
                dataGridViewX2.AllowUserToAddRows = false;
                DtableCTDH = c2.LayDSCTDathang(mdh);
                bindsCTDH.DataSource = DtableCTDH;
                bindingNavigator2.BindingSource = bindsCTDH;
                dataGridViewX2.DataSource = bindsCTDH;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi hien thi chi tiet dat hang theo mdh" + ex.ToString());
                throw;
            }
        }

        private void dataGridViewX1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            DataGridViewRow dr = new DataGridViewRow();
            dr = dataGridViewX1.Rows[e.RowIndex];
             mdh = dr.Cells[0].Value.ToString();
            hienthiCTdathang(mdh);
            String s2 = dr.Cells[1].Value.ToString();
            String s3 = dr.Cells[2].Value.ToString();
            hd.SetMKH(s2);
            hd.SetMNV(s3);
            DuyetGridView2();
           
        }

        private void dataGridViewX1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow dr = new DataGridViewRow();
            //dr = dataGridViewX1.Rows[e.RowIndex];
            //String mdh = dr.Cells[0].Value.ToString();
            ////hienthiCTdathang(mdh);
            //String s1 = dr.Cells[0].Value.ToString();
            //String s2 = dr.Cells[1].Value.ToString();
            //String s3 = dr.Cells[2].Value.ToString();
            //String s4 = dr.Cells[3].Value.ToString();
            //String s5 = dr.Cells[4].Value.ToString();
            //String s6 = dr.Cells[5].Value.ToString();
            ////MessageBox.Show(s2 + s3);
            //hd.SetMKH(s2);
            //hd.SetMNV(s3);
        }

        private void DuyetGridView()
        {
            int demlanduyet = 0;
            foreach (DataGridViewRow dr in dataGridViewX2.Rows)
            {
                foreach (DataGridViewCell dc in dr.Cells)
                {
                    demlanduyet++;
                    string s = dc.Value.ToString();
                    
                }
            }
        }
        private void DuyetGridView2()
        {
           
            
            foreach (DataGridViewRow dr in dataGridViewX2.Rows)
            {
                String s2 = dr.Cells["Cl_msp"].Value.ToString();
                int  s4 =int.Parse(dr.Cells["Cl_soluong"].Value.ToString());
                SP sp = new SP(s2, s4);
                    hd.AddSP(sp);

            }
        }
        //private void DuyetGridView2()
        //{
        //    int demlanduyet = 0;
        //    foreach (DataGridViewRow dr in dataGridViewX2.Rows)
        //    {
        //        demlanduyet++;
        //        String s1 = dr.Cells[0].Value.ToString();
        //        String s2 = dr.Cells[1].Value.ToString();
        //        String s3 = dr.Cells[2].Value.ToString();
        //        String s4 = dr.Cells[3].Value.ToString();
        //        String s5 = dr.Cells[4].Value.ToString();
        //        String s6 = dr.Cells[5].Value.ToString();
        //        MessageBox.Show( s3, demlanduyet.ToString());

        //    }
        //}

        
        private void buttonX1_Click(object sender, EventArgs e)
        {
            DuyetGridView2();
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridViewRow dr = new DataGridViewRow();
            dr = dataGridViewX1.Rows[e.RowIndex];
            String mdh = dr.Cells["Columnmadh"].Value.ToString();
            hienthiCTdathang(mdh);
            DuyetGridView2();
           
            
        }

        private void buttonX_Hd_Click(object sender, EventArgs e)
        {
            
            if (!hd.GetMKH().Equals("") || hd.GetListSP().Count != 0)
            {
                Boolean f;
                if (!mdh.Equals(""))
                    c2.SetDH(mdh);
                f = c2.MuaHang(hd);
                if (f == true)
                    MessageBox.Show("ghi hoa don thanh cong");
                else
                    MessageBox.Show("Bi loi ! thu lai");
            }
            else
                MessageBox.Show(" Ban phai chon don dat hang truoc");
        }
    }
}
