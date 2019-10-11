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
    public partial class fr_CtyDatHang : Form
    {
        Connection2 c2 = new Connection2();
        DataTable dMNCC = new DataTable();
        DataTable dMNV = new DataTable();
        DataTable DtableMuahang = new DataTable();
        BindingSource binds = new BindingSource();
        NhapHang nh =null;
        public fr_CtyDatHang()
        {
            khoitao();
            InitializeComponent();
        }

        private void comboBoxEx2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxX_mnv.Text = comboBoxEx_mnv.SelectedValue.ToString().Trim();
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (dateTimeInput_ngaylap.IsEmpty)
            {
                MessageBox.Show("Nhập vào ngày tháng");
                trangthai1();
            }
            else
            {
                labelX_mncc.Text = "Mã NCC : " + textBoxX_mncc.Text;
                labelX_mnv.Text = "Mã NV : " + textBoxX_mnv.Text;
                trangthai2();
                nh = new NhapHang(textBoxX_mncc.Text, textBoxX_mnv.Text);

            }
        }

        private void fr_CtyDatHang_Load(object sender, EventArgs e)
        {
            hienthi1();
            trangthai1();
        }
        private void trangthai1()
        {
            panelEx1.Enabled = false;
            panelEx2.Enabled = false;
            navigationPane1.Enabled = true;
        }
        private void trangthai2()
        {
            panelEx1.Enabled = true;
            panelEx2.Enabled = true;
            navigationPane1.Enabled = false;
        }
        private void hienthi1()
        {
            dMNCC = c2.getDSNcc();
            dMNV = c2.layDSmaNV();
            comboBoxEx_mncc.DataSource = dMNCC;
            comboBoxEx_mncc.ValueMember = "mncc";
            comboBoxEx_mncc.DisplayMember = "mncc";

            comboBoxEx_mnv.DataSource = dMNV;
            comboBoxEx_mnv.ValueMember = "mnv";
            comboBoxEx_mnv.DisplayMember = "mnv";

            textBoxX_mncc.Text = comboBoxEx_mncc.Text.Trim();
            textBoxX_mnv.Text = comboBoxEx_mnv.Text.Trim();
        }

        private void comboBoxEx_mncc_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxX_mncc.Text = comboBoxEx_mncc.SelectedValue.ToString().Trim();
        }

        private void buttonX_lammoi_Click(object sender, EventArgs e)
        {
            trangthai1();
            //lam sach datagridview
            while (dataGridViewX1.Rows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridViewX1.Rows)
                {
                    dataGridViewX1.Rows.Remove(dr);
                }
            }
            labelX_mncc.Text = "Mã NCC : ";
            labelX_mnv.Text = "Mã NV : ";
        }

        private void buttonX_Add_Click(object sender, EventArgs e)
        {
            HienthiCTdathang();
            if (c2.sosanhMSP(textBoxX_msp.Text.Trim())) //neu msp da ton tai thuc hien add
            {
                if (nh != null)
                {
                    SP s= new SP();
                    s = s.SetSP(textBoxX_msp.Text, int.Parse(textBoxX_soluong.Text));
                    SP sp = nh.AddSP(s);
                    DataRow dr = DtableMuahang.NewRow();
                    dr["msp"] = sp.GetMSP();
                    dr["tensp"] = sp.GetTensp();
                    dr["giamua"] = sp.GetGiaMua();
                    dr["slnhap"] = sp.GetSoluong();
                    dr["thanhtien"] = sp.GetThanhtien();
                    DtableMuahang.Rows.Add(dr);
                    deleteRow(dataGridViewX1, "Column_msp");
                }
            }
            else
            {
                MessageBox.Show("Hãy thêm Sp mới vào");
                frSanpham frsp = new frSanpham();
                frsp.Show();
            }
            
        }
        public void HienthiCTdathang()
        {
            try
            {
                dataGridViewX1.AutoGenerateColumns = false;
                dataGridViewX1.AllowUserToAddRows = false;
                binds.DataSource = DtableMuahang;
                bindingNavigator1.BindingSource = binds;
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
          
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Rows.Count > 0)
            {
                DataGridViewRow dr = dataGridViewX1.CurrentRow;
                String s1 = dr.Cells["Column_msp"].Value.ToString();
                dataGridViewX1.Rows.Remove(dr);
            }
        }

        public void khoitao()
        {
            DtableMuahang.Columns.Add("msp", typeof(String));
            DtableMuahang.Columns.Add("tensp", typeof(String));
            DtableMuahang.Columns.Add("giamua", typeof(double));
            DtableMuahang.Columns.Add("slnhap", typeof(int));
            DtableMuahang.Columns.Add("thanhtien", typeof(double));
        }

        private void buttonX_ghiphieunhap_Click(object sender, EventArgs e)
        {
            
            if (nh == null || nh.GetListSP().Count == 0)
                MessageBox.Show("Ban phai dien thieu thong tin ...");

            else
            {
                Boolean f;
                f = c2.NhapHang(nh);
                if (f == true)
                    MessageBox.Show("thanh toan hoa don thanh cong");
            }
        }
    }
}
