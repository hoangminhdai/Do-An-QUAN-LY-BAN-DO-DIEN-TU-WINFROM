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
    public partial class test : Form
    {
        DataTable dtable = new DataTable();
        BindingSource binds = new BindingSource();
        DataTable dt = new DataTable();
        Connection2 c2 = new Connection2();
        public test()
        {

            khoitao1();
            InitializeComponent();
        }
        public void khoitao1()
        {
            dtable.Columns.Add("hoten", typeof(String));
        }
        public void khoitao()
        {
            binds.DataSource = dtable;
            dataGridViewX1.DataSource = binds;
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            khoitao();
            DataRow dr = dtable.NewRow();
            dr["hoten"] = textBoxX1.Text;
            dtable.Rows.Add(dr);
        }

        private void test_Load(object sender, EventArgs e)
        {
            hienthi();
            textBoxX2.Text = "kh1";
        }
        public void hienthi()
        {
            dt = c2.layDSmaKH();
            comboBoxEx1.DataSource = dt;
            comboBoxEx1.ValueMember = "mkh";
            comboBoxEx1.DisplayMember = "makh";
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxX2.Text = comboBoxEx1.SelectedValue.ToString();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            textBoxX2.Text = comboBoxEx1.SelectedValue.ToString();
        }

        private void comboBoxEx2_SelectedIndexChanged(object sender, EventArgs e)
        {
           // textBoxX2.Text = comboBoxEx2.SelectedItem.ToString();
        }


    }
}
