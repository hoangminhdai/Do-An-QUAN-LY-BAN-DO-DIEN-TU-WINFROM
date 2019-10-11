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
    public partial class frNguoidung : Office2007Form
    {
        Connection2 c2 = new Connection2();
        DataTable DtableNguoidung = new DataTable();
        DataTable DtableMaquyen = new DataTable();
        BindingSource binds = new BindingSource();
        public frNguoidung()
        {
            InitializeComponent();
        }

        private void frNguoidung_Load(object sender, EventArgs e)
        {
            hienthiNguoidung();
        }
        private void hienthiNguoidung()
        {
            try
            {
                dataGridViewX1.AutoGenerateColumns = false;
                dataGridViewX1.AllowUserToAddRows = false;
                DtableMaquyen = c2.laymaquyen2();
                comboBoxEx_maquyen.DataSource= DtableMaquyen;
                comboBoxEx_maquyen.ValueMember = "maquyen";
                comboBoxEx_maquyen.DisplayMember = "maquyen";

                DtableNguoidung = c2.layngdung();
                binds.DataSource = DtableNguoidung;
                if (textBoxX_id.Text=="")
                {
                    textBoxX_id.DataBindings.Add("Text", binds, "id");
                    textBoxX_manv.DataBindings.Add("Text", binds, "mnv");
                    textBoxX_pass.DataBindings.Add("Text", binds, "pass");
                    comboBoxEx_maquyen.DataBindings.Add("SelectedValue", binds, "maquyen");
                }

                ColumnMaquyen.DataSource = DtableMaquyen;
                ColumnMaquyen.DataPropertyName = "maquyen";
                ColumnMaquyen.ValueMember = "maquyen";
                ColumnMaquyen.DisplayMember = "maquyen";

                bindingNavigator1.BindingSource = binds;
                bindingNavigator2.BindingSource = binds;
                dataGridViewX1.DataSource = binds;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi thien thi User" + ex.ToString());
                throw;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DataRow dr = DtableNguoidung.NewRow();
            dr["id"] = Ngdung_next();
            dr["maquyen"] = "sell";
            DtableNguoidung.Rows.Add(dr);
            bindingNavigator1.BindingSource.MoveLast();

        }

        private String Ngdung_next()
        {
            String s = "u" + (dataGridViewX1.Rows.Count + 1).ToString();
            return s;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DataRow dr = DtableNguoidung.NewRow();
            dr["id"] = Ngdung_next();
            dr["maquyen"] = "sell";
            DtableNguoidung.Rows.Add(dr);
            bindingNavigator1.BindingSource.MoveLast();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveNgdung();
        }
        private void SaveNgdung()
        {
            bindingNavigator1.BindingSource.MovePrevious();
            int t = c2.save();
            bindingNavigator1.BindingSource.MoveNext();
            if (t > 0)
            {
                MessageBox.Show("CẬP NHẬT " + t + " HÀNG");
            }
            else
                MessageBox.Show("KHÔNG CÓ GÌ THAY ĐỔI");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            hienthiNguoidung();
        }

        private void buttonX_submit_Click(object sender, EventArgs e)
        {
            SaveNgdung();
        }
                
    }
}
