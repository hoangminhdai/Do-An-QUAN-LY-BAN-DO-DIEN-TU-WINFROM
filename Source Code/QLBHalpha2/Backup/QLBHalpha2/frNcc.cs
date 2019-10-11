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
    public partial class frNcc : Office2007Form
    {
        Connection2 c2 = new Connection2();
        DataTable db = new DataTable();
        public frNcc()
        {
            InitializeComponent();
        }

        private void hienthiNcc()
        {
            dataGridViewX1.AutoGenerateColumns = false;
            dataGridViewX1.AllowUserToAddRows = false;
            db = c2.getDSNcc();
            bindingSource1.DataSource = db;
            bindingNavigator1.BindingSource = bindingSource1;
            dataGridViewX2.DataSource = bindingSource1;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            hienthiNcc();
        }
        private void Save()
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
            Save();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Save();
        }

        private void frNcc_Load(object sender, EventArgs e)
        {
            hienthiNcc();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            hienthiNcc();
        }
    }
}
