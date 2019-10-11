using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QLBHalpha2
{
    public partial class frMuahang : Form
    {
     
        HoaDon hd =null;
        Connection2 c2 = new Connection2();
        DataTable DtableManv = new DataTable();
        DataTable DtaleMakh = new DataTable();
        DataTable DtableMuahang = new DataTable();
        BindingSource binds = new BindingSource();
        bool KTbinding = true;
        
        public frMuahang()
        {
            khoitao();
           
            InitializeComponent();
            panelEx1.Enabled = false;
            navigationPane2.Enabled = false;
        }

        private void comboBoxEx3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frMuahang_Load(object sender, EventArgs e)
        {
            
            hienthiMh();
        }
        private void hienthiMh()
        {
            try
            {
                DtaleMakh = c2.layDSmaKH();
                DtableManv = c2.layDSmaNV();
                comboBoxEx_makh.DataSource = DtaleMakh;
                comboBoxEx_makh.ValueMember = "mkh";
                comboBoxEx_makh.DisplayMember = "mkh";

                comboBoxEx_manv.DataSource = DtableManv;
                comboBoxEx_manv.ValueMember = "mnv";
                comboBoxEx_manv.DisplayMember = "mnv";
                textBoxX_makh3.Text = "kh1";
                textBoxX_manv3.Text = "nv1";
                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi hien thi mua hang " + ex.ToString());
                
                throw;
            }
        }

        private void buttonX_lapphieumua_Click(object sender, EventArgs e)
        {
            panelEx1.Enabled = true;
            navigationPane2.Enabled = true;
            hd = new HoaDon(textBoxX_makh3.Text,textBoxX_manv3.Text);

            
        }

        private void buttonX_add_Click(object sender, EventArgs e)
        {
            if (hd == null)
                MessageBox.Show("Ban phai lap phieu mua truoc");
            else
            {

                hd.SetMKH(textBoxX_makh3.Text);// yes or no
                SP s = new SP(textBoxX_msp.Text, int.Parse(textBoxX_soluong.Text));

                if (s.GetStatus() == 0)//san pham la ok
                {
                    SP sp = hd.AddSP(s);//them moi san pham !! kiem tra san pham bi trungs
                    HienthiCTmuahang();
                    DataRow dr = DtableMuahang.NewRow();
                    dr["msp"] = sp.GetMSP();
                    dr["tensp"] = sp.GetMSP();
                    dr["gia"] = sp.GetGiaban();
                    dr["sl"] = sp.GetSoluong();// textBoxX_soluong.Text;//Int32.Parse(textBoxX_sl.Text.ToString());
                    dr["thanhtien"] = sp.GetThanhtien();
                    DtableMuahang.Rows.Add(dr);
                    deleteRow(dataGridViewX1, "ColumnMsp");
                }

            }
        }
        

        private void buttonX_hd_Click(object sender, EventArgs e)
        {
            if (hd == null || hd.GetListSP().Count == 0)
                MessageBox.Show("Ban phai dien thong tin san pham");
            else
            {
                Boolean f;
                f = c2.MuaHang(hd);
                if (f == true)
                    MessageBox.Show("thanh toan hoa don thanh cong");
            }
        }




        private void buttonX_them_Click(object sender, EventArgs e)
        {
            //try
           // {

                /*HienthiCTmuahang();
                DataRow dr = DtableMuahang.NewRow();
                dr["msp"] = sp.GetMSP();
                dr["tensp"] = sp.GetMSP();
                dr["gia"] = sp.GetGiaban();
                dr["sl"] = sp.GetSoluong();// textBoxX_soluong.Text;//Int32.Parse(textBoxX_sl.Text.ToString());
                dr["thanhtien"] = sp.GetThanhtien();
                DtableMuahang.Rows.Add(dr);

            }
            catch (Exception ex)
            {
                MessageBox.Show("LOi button click" + ex.ToString());
                throw;
            }*/
            
        }

        public DataTable CreatTable()
        {
            DataTable dtable = new DataTable();
            dtable.Columns.Add("msp", typeof(String));
            dtable.Columns.Add("tensp", typeof(String));
            dtable.Columns.Add("gia", typeof(double));
            dtable.Columns.Add("sl", typeof(int));
            dtable.Columns.Add("thanhtien", typeof(double));


            return dtable;


        }
        public void khoitao()
        {
            DtableMuahang.Columns.Add("msp", typeof(String));
            DtableMuahang.Columns.Add("tensp", typeof(String));
            DtableMuahang.Columns.Add("gia", typeof(double));
            DtableMuahang.Columns.Add("sl", typeof(int));
            DtableMuahang.Columns.Add("thanhtien", typeof(double));

            ///
           
        }

        public DataRow CreateRow(String msp, String tensp, double gia, int sl, double thanhtien)
        {
            DataTable dtable = CreatTable();
            /*dtable.Columns.Add("msp", typeof(String));
            dtable.Columns.Add("tensp", typeof(String));
            dtable.Columns.Add("gia", typeof(double));
            dtable.Columns.Add("sl", typeof(int));
            dtable.Columns.Add("thanhtien", typeof(double));*/

            DataRow dr = dtable.NewRow();
            dr["msp"] = msp;
            dr["tensp"] = tensp;
            dr["gia"] = gia;
            dr["sl"] = sl;
            dr["thanhtien"] = thanhtien;

            return dr;
        }

     

        public void HienthiCTmuahang()
        {
            try
            {
                dataGridViewX1.AutoGenerateColumns = false;
                dataGridViewX1.AllowUserToAddRows = false;
                //DtableMuahang = CreatTable();
                //if (DtableMuahang==null||DtableMuahang.Rows.Count==0)
                //{
                //    DtableMuahang = new DataTable();
                //}
                
                binds.DataSource = DtableMuahang;

                if (KTbinding) 
                {
                    textBoxX_masp.DataBindings.Add("Text", binds, "msp");
                    textBoxX_tensp.DataBindings.Add("Text", binds, "tensp");
                    textBoxX_gia.DataBindings.Add("Text", binds, "gia");
                    textBoxX_sl.DataBindings.Add("Text", binds, "sl");
                    textBoxX_thanhtien.DataBindings.Add("Text", binds, "thanhtien");
                   // MessageBox.Show(binds.Count.ToString());
                    KTbinding = false;
                }
                bindingNavigator1.BindingSource = binds;
                bindingNavigator2.BindingSource = binds;
                dataGridViewX1.DataSource = binds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi them " + ex.ToString());
                throw;
            }
        }

        public DataTable ThemRowVaoTable(String msp, String tensp, double gia, int sl, double thanhtien)
        {
            try
            {
                DataTable dtable = CreatTable();
                /*dtable.Columns.Add("msp", typeof(String));
                dtable.Columns.Add("tensp", typeof(String));
                dtable.Columns.Add("gia", typeof(double));
                dtable.Columns.Add("sl", typeof(int));
                dtable.Columns.Add("thanhtien", typeof(double));*/

                DataRow dr = dtable.NewRow();
                dr["msp"] = msp;
                dr["tensp"] = tensp;
                dr["gia"] = gia;
                dr["sl"] = sl;
                dr["thanhtien"] = thanhtien;

                dtable.Rows.Add(dr);
                return dtable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi them row vao table" + ex.ToString());
                throw;
            }
        }

        private void comboBoxEx_makh_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            textBoxX_makh3.Text = comboBoxEx_makh.SelectedValue.ToString();
        }

        private void comboBoxEx_manv_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            textBoxX_manv3.Text = comboBoxEx_manv.SelectedValue.ToString();
        }

        private void buttonX_addKH_Click(object sender, EventArgs e)
        {
            frKhachhang frkh = null;
            if (frkh == null || frkh.IsDisposed)
            {
                frkh = new frKhachhang();
                frkh.MdiParent = frMain.ActiveForm;
                frkh.Show();
            }
            else
                frkh.Activate();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            // LAY SP BI REMOVE
            //bindingNavigator1.item
            DataGridViewRow dr = dataGridViewX1.CurrentRow;
            String s1 = dr.Cells["ColumnMsp"].Value.ToString();



        }

        private void toolStripButtonXoa_Click(object sender, EventArgs e)
        {
            

            if (dataGridViewX1.Rows.Count > 0)
            {

                DataGridViewRow dr = dataGridViewX1.CurrentRow;
                String s1 = dr.Cells["ColumnMsp"].Value.ToString();
                hd.RemoveSP(s1);
                dataGridViewX1.Rows.Remove(dr);
               
            }
        }
        private void deleteRow(DataGridView dgv, String Cot)
        {
            int n = dgv.Rows.Count;
            String msp = dgv.Rows[n - 1].Cells[Cot].Value.ToString();
            for (int i = 0; i < n - 1; i++)
            {
                String s1 = dgv.Rows[i].Cells[Cot].Value.ToString();
                if (msp.Equals(s1))
                {
                    dgv.Rows.Remove(dgv.Rows[i]);
                    break;
                }
            }
        
        }
        

     
    }
}
