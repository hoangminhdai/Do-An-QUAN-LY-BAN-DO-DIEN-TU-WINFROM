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
    public partial class frLoaisp : Office2007Form
    {
        Connection2 c2 = new Connection2();
        DataTable DtableLoaiSP = new DataTable();
        public frLoaisp()
        {
            InitializeComponent();
        }

        private void LoaihangForm_Load(object sender, EventArgs e)
        {
            hienthiLoaiSP();
        }
        private void hienthiLoaiSP()
        {
            try
            {
                dataGridViewX1.AutoGenerateColumns = false;
                dataGridViewX1.AllowUserToAddRows = false;
                DtableLoaiSP = c2.layDSLoaiSP();
                bindS.DataSource = DtableLoaiSP;
                bindingNavigator1.BindingSource = bindS;
                dataGridViewX1.DataSource = bindS;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi hien thi LoaiSP " + ex.ToString());
                throw;
            }
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            hienthiLoaiSP();
        }
              
    }
}
