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
    public partial class frKhachhang : Office2007Form
    {
        Connection2 c2 = new Connection2();
        DataTable DtableKH = new DataTable();
        BindingSource binds = new BindingSource();
        public frKhachhang()
        {
            InitializeComponent();
        }

        private void ftKhachhang_Load(object sender, EventArgs e)
        {
            hienthiKH();
        }
        private void hienthiKH()
        {
            try
            {
                dataGridViewX1.AutoGenerateColumns = false;
                dataGridViewX1.AllowUserToAddRows = false;
                DtableKH = c2.layDSkh();
                binds.DataSource = DtableKH;
                if (textBoxX_makh.Text=="")
                {
                    textBoxX_makh.DataBindings.Add("Text", binds, "mkh");
                    textBoxX_hotenkh.DataBindings.Add("Text", binds, "hoten");
                    textBoxX_diachi.DataBindings.Add("Text", binds, "diachikh");
                    textBoxX_sodt.DataBindings.Add("Text", binds, "diachikh");
                    textBoxX_doanhso.DataBindings.Add("Text", binds, "tien");
                }

                bindingNavigator1.BindingSource = binds;
                bindingNavigator2.BindingSource = binds;
                dataGridViewX1.DataSource = binds;

            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi hien thi KH" + ex.ToString());
                throw;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            hienthiKH();
        }
        public String kh_next()
        {
            String khtiep = "kh" + (dataGridViewX1.Rows.Count + 1).ToString();
            return khtiep;
        }

        private void saveKH()
        {
            bindingNavigator1.BindingSource.MovePrevious();
            int t = c2.save();
            bindingNavigator1.BindingSource.MoveNext();
            if (t > 0)
            {
                MessageBox.Show("cap nhat " + t);
            }
            else
                MessageBox.Show("ko co ji thay doi");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            saveKH();
        }

        private void buttonX_Xacnhan_Click(object sender, EventArgs e)
        {
            saveKH();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DataRow dr = DtableKH.NewRow();
            dr["mkh"] = kh_next();
            //dr["ngaysinh"] = "06/28/1989";
            DtableKH.Rows.Add(dr);
            bindingNavigator1.BindingSource.MoveLast();
        }

       
    }
}
