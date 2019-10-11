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
    public partial class fr_thongkeBanHang : Form
    {
        Connection2 c2 = new Connection2();
        DataTable DtSP = new DataTable();
        DataTable DtChitiet = new DataTable();
        BindingSource binds = new BindingSource();
        public fr_thongkeBanHang()
        {
            InitializeComponent();
        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEx1.SelectedIndex == 0)
            {
                textBoxX_ngay.Enabled = true;
                textBoxX_thang.Enabled = true;
                textBoxX_nam.Enabled = true;
            }
            if (comboBoxEx1.SelectedIndex == 1)
            {
                textBoxX_ngay.Enabled = false;
                textBoxX_thang.Enabled = true;
                textBoxX_nam.Enabled = true;

                textBoxX_ngay.Text = "";
            }
            if (comboBoxEx1.SelectedIndex == 2)
            {
                textBoxX_ngay.Enabled = false;
                textBoxX_thang.Enabled = false;
                textBoxX_nam.Enabled = true;
                textBoxX_ngay.Text = "";
                textBoxX_thang.Text = "";
            }
            
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX_thuchien_Click(object sender, EventArgs e)
        {
            hienthiSUM();
            hienthiChitiet();
        }
        private void hienthiSUM()
        {
            
            String day = textBoxX_ngay.Text;
            String month = textBoxX_thang.Text;
            String year = textBoxX_nam.Text;
            if (comboBoxEx1.SelectedIndex == 0)
            {
                DtSP = c2.SumDay(year,month,day);
                labelX_timeKK .Text= "Ngày : "+ day + "/" + month + "/" + year;
            }
            if (comboBoxEx1.SelectedIndex == 1)
            {
                DtSP = c2.SumMonth(year,month);
                labelX_timeKK.Text = "Tháng :"+ month + "/" + year;
            }
            if (comboBoxEx1.SelectedIndex==2)
            {
                DtSP = c2.SumYear(year);
                labelX_timeKK.Text = "năm :" + year;
            }
            if (labelX_tongKK.Text == "")
                labelX_tongKK.Text = "Không bán được hàng trong thời gian này";
            String tong = DtSP.Rows[0]["tong"].ToString();
            labelX_tongKK.Text = tong;
            
            
        }

        private void buttonX_chitiet_Click(object sender, EventArgs e)
        {
            hienthiChitiet();
        }

        private void hienthiChitiet()
        {
            dataGridViewX1.AutoGenerateColumns = false;
            dataGridViewX1.AllowUserToAddRows = false;
             String day = textBoxX_ngay.Text;
            String month = textBoxX_thang.Text;
            String year = textBoxX_nam.Text;
            if (comboBoxEx1.SelectedIndex == 0)
            {
                DtChitiet = c2.ChitietDay(year, month, day);
            }
            if (comboBoxEx1.SelectedIndex == 1)
            {
                DtChitiet = c2.ChitietMonth(year, month);
            }
            if (comboBoxEx1.SelectedIndex == 2)
            {
                DtChitiet = c2.ChitietYear(year);
            }
            binds.DataSource = DtChitiet;
            bindingNavigator1.BindingSource = binds;
            dataGridViewX1.DataSource = binds;
        }

        private void fr_thongkeBanHang_Load(object sender, EventArgs e)
        {
            textBoxX_ngay.Enabled = false;
            textBoxX_thang.Enabled = false;
            textBoxX_nam.Enabled = false;
        }
    }
}
