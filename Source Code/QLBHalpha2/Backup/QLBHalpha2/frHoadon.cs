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
    public partial class frHoadon : Office2007Form
    {
        Connection2 c2 = new Connection2();
        DataTable DtableDh0 = new DataTable();
        DataTable DtableCTDH = new DataTable();
        BindingSource binds = new BindingSource(); // lam bv
        BindingSource bindsCTDH = new BindingSource(); // lam nv datagridview CHDH
        HoaDon hd = new HoaDon();
        public frHoadon()
        {
            InitializeComponent();
        }

        private void frHoadon_Load(object sender, EventArgs e)
        {
            hienthiHD();
        }
        private void hienthiHD()
        {
            try
            {
                dataGridViewX1.AutoGenerateColumns = false;
                dataGridViewX1.AllowUserToAddRows = false;
                DtableDh0 = c2.getDShd();
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
        private void hienthi_CTHD(String mhd) // hien thi CT dat hang theo maDH
        {
            try
            {
                dataGridViewX2.AutoGenerateColumns = false;
                dataGridViewX2.AllowUserToAddRows = false;
                DtableCTDH = c2.getDS_CTHD(mhd);
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
            String mhd = dr.Cells["Columnmdh"].Value.ToString();
            hienthi_CTHD(mhd);
        }

        private void dataGridViewX1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = new DataGridViewRow();
            dr = dataGridViewX1.Rows[e.RowIndex];
            String mhd = dr.Cells["Columnmdh"].Value.ToString();
            hienthi_CTHD(mhd);
        }

        private void navigationPane1_Load(object sender, EventArgs e)
        {

        }
    }
}
