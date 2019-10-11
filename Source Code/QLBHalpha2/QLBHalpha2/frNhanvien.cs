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
    public partial class frNhanvien : Office2007Form
    {
        Connection2 c2 = new Connection2();
        BindingSource bindingS = new BindingSource();
        DataTable tableNV = new DataTable();
        DataTable tableGT = null;
        public frNhanvien()
        {
            InitializeComponent();
        }

        private void nhanvienForm_Load(object sender, EventArgs e)
        {
            hienthinv();
        }

        /// viet ham hien thi
        /// 
        public void hienthinv()
        {
            try
            {
                dataGridViewX1.AutoGenerateColumns = false;
                dataGridViewX1.AllowUserToAddRows = false;
                ///000000000000000000000
                ///
                tableGT = c2.layGT();
                comboBoxEx_sex.DataSource = tableGT;
                comboBoxEx_sex.ValueMember = "gioitinh";
                comboBoxEx_sex.DisplayMember = "gioitinh";

                //
                tableNV = c2.laydsNV();
                bindingS.DataSource = tableNV;
                //
                if (textBoxX_manv.Text == "") // đúng ra chỗ này kiểm tra textboxmanv đã được binding chưa? mà ko biet dùng hàm ji để kt nên .....
                {
                    textBoxX_manv.DataBindings.Add("Text", bindingS, "mnv");
                    textBoxX_tennv.DataBindings.Add("Text", bindingS, "tennv");
                    comboBoxEx_sex.DataBindings.Add("SelectedValue", bindingS, "gioitinh");
                    textBoxX_diachi.DataBindings.Add("Text", bindingS, "diachinv");
                    textBoxX_phone.DataBindings.Add("Text", bindingS, "sodt");
                    dateTimeInput_ngaysinh.DataBindings.Add("Value", bindingS, "ngaysinh");
                }

                Column_gioitinh.DataSource = tableGT;
                Column_gioitinh.DisplayMember = "gioitinh"; //hien thi cac thuoc tinh trong cot gioi tinh
                Column_gioitinh.ValueMember = "gioitinh";  // lay gia tri o cot nao
                Column_gioitinh.DataPropertyName = "gioitinh";
               
                dataGridViewX1.DataSource = bindingS;
                bindingNavigator1.BindingSource = bindingS;
            }
            catch (Exception)
            {
                MessageBox.Show("Loi hienthinv");
                throw;
            }
          
        }

        public String nv_next()
        {
            String nvtiep = "nv" + (dataGridViewX1.Rows.Count+1).ToString();
            return nvtiep;
        }

        private void saveNV()
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

        private void toolStripButton1_Click(object sender, EventArgs e) //save
        {
            
            saveNV();
            
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            //this.Refresh();
            
            hienthinv();
        }

        private void toolStripButton2_Click(object sender, EventArgs e) // addNV tu dong danh ma nv
        {
            DataRow dr = tableNV.NewRow();
            dr["mnv"] = nv_next();
            dr["ngaysinh"] = "06/28/1989";
            tableNV.Rows.Add(dr);
            bindingNavigator1.BindingSource.MoveLast();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
         
        }

        private void buttonX_SaveNV_Click(object sender, EventArgs e)
        {
            saveNV();
        }

        private void dataGridViewX1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
