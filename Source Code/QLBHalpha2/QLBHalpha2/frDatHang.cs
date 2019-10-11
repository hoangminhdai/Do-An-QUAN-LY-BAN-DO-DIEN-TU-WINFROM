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
    public partial class frDatHang : Form
    {
        DatHang dh = null; 
        frKhachhang frkh = null;
        Connection2 c2 = new Connection2();
        DataTable DtableManv = new DataTable();
        DataTable DtaleMakh = new DataTable();
        DataTable DtableMuahang = new DataTable();
        BindingSource binds = new BindingSource();
        bool KTbinding = true;
        //frMain frmain = null;
        public frDatHang()
        {
            khoitao();
            InitializeComponent();
        }

        private void frDatHang_Load(object sender, EventArgs e)
        {
            trangthai1();
            hienthidathang();
        }
        private void hienthidathang()
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

                ///them
                ///
                textBoxX_makh.Text = "kh1";
                textBoxX_manv.Text = "nv01";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi hien thi mua hang " + ex.ToString());

                throw;
            }
        }
        private void trangthai1()
        {
            panelEx1.Enabled = false;
            panelEx2.Enabled = false;
            dataGridViewX1.Enabled = false;
            navigationPane2.Enabled = false;
            navigationPane1.Enabled = true;
        }
        private void trangthai2()
        {
            panelEx1.Enabled = true;
            panelEx2.Enabled = true;
            dataGridViewX1.Enabled = true;
            navigationPane2.Enabled = true;
            navigationPane1.Enabled = false;
        }

        private void buttonX_lapphieudat_Click(object sender, EventArgs e)
        {
            trangthai2();
            dh = new DatHang(textBoxX_makh.Text, textBoxX_manv.Text, dateTime_date.Value);
            /*foreach (SP sp in dh.GetListSP())
            {
                sp.GetMSP();
                sp.GetTensp();
                sp.GetGiaban();
                sp.GetSoluong();
                sp.GetThanhtien();
            }*/
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            trangthai1();
        }

        private void buttonX_addKH_Click(object sender, EventArgs e)
        {
            
            if (frkh == null || frkh.IsDisposed)
            {
                frkh = new frKhachhang();
                frkh.MdiParent = frMain.ActiveForm;
                frkh.Show();
            }
            else
                frkh.Activate();
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxX_sl_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX_add_Click(object sender, EventArgs e)
        {
            if (dh == null)
                MessageBox.Show("Ban phai dien thong tin phieu dat hang truoc ");
            else
            {
                SP s = new SP(textBoxX_msp.Text, int.Parse(textBoxX_sl.Text));
                if (s.GetStatus() == 0)//san pham la ok
                {
                    SP sp = dh.AddSP(s);
                    ///
                    HienthiCTdathang();
                    DataRow dr = DtableMuahang.NewRow();
                    dr["msp"] = sp.GetMSP();
                    dr["tensp"] = sp.GetMSP();
                    dr["gia"] = sp.GetGiaban();
                    dr["sl"] = sp.GetSoluong();// textBoxX_soluong.Text;//Int32.Parse(textBoxX_sl.Text.ToString());
                    dr["thanhtien"] = sp.GetThanhtien();
                    DtableMuahang.Rows.Add(dr);
                    //MessageBox.Show("xoa");
                    deleteRow(dataGridViewX1, "ColumnMsp");
                }
                
               
            }
        }

        private void buttonX_ghihoadon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dat hang");
            if (dh== null ||dh.GetListSP().Count == 0)
                MessageBox.Show("Ban phai dien thieu thong tin ...");

            else
            {
                Boolean f;
                f = c2.DatHang(dh);
                if (f == true)
                    MessageBox.Show("thanh toan hoa don thanh cong");
            }
        }

        private void navigationPanePanel1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEx_makh_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxX_makh.Text = comboBoxEx_makh.SelectedValue.ToString();
        }

        private void comboBoxEx_manv_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxX_manv.Text = comboBoxEx_manv.SelectedValue.ToString();
        }

        public void khoitao()
        {
            DtableMuahang.Columns.Add("msp", typeof(String));
            DtableMuahang.Columns.Add("tensp", typeof(String));
            DtableMuahang.Columns.Add("gia", typeof(double));
            DtableMuahang.Columns.Add("sl", typeof(int));
            DtableMuahang.Columns.Add("thanhtien", typeof(double));
        }

        public void HienthiCTdathang()
        {
            try
            {
                dataGridViewX1.AutoGenerateColumns = false;
                dataGridViewX1.AllowUserToAddRows = false;
                //DtableMuahang = CreatTable();
                binds.DataSource = DtableMuahang;
                
                if (KTbinding)
                {
                    textBoxX_masp.DataBindings.Add("Text", binds, "msp");
                    textBoxX_tensp.DataBindings.Add("Text", binds, "tensp");
                    textBoxX_gia.DataBindings.Add("Text", binds, "gia");
                    textBoxX_soluong.DataBindings.Add("Text", binds, "sl");
                    textBoxX_thanhtien.DataBindings.Add("Text", binds, "thanhtien");
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
            //for(int i = n-1; i >=0  ; i --)
            //    for (int j =0; j < i  ; j--)
            //    {
            //        String s1 = dgv.Rows[i].Cells[Cot].Value.ToString();
            //        String s2 = dgv.Rows[j].Cells[Cot].Value.ToString();
            //        if (s1.Equals(s2))
            //        {
            //            MessageBox.Show("s1 = "+s1);
            //            MessageBox.Show("s2 = "+s2);
            //            dgv.Rows.Remove(dgv.Rows[j]);
            //        }
            //    }
        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count > 0)
            {
                DataGridViewRow dr = dataGridViewX1.CurrentRow;
                String s1 = dr.Cells["ColumnMsp"].Value.ToString();
                dh.RemoveSP(s1);
                MessageBox.Show(s1);
                MessageBox.Show(s1);
                dataGridViewX1.Rows.Remove(dr);
                MessageBox.Show(dh.GetListSP().Count.ToString());
            }
        }
    }
}
