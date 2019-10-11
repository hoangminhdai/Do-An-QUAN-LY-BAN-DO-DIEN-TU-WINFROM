using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
//using System.Data;

namespace QLBHalpha2
{
    public partial class frUser : Office2007Form
    {
        //class
        Connection2 c2 = new Connection2();
        //bien
       // DataSet datasetUser = null;
        BindingSource bindingS = new BindingSource();
        DataTable tableU = new DataTable();
        public frUser()
        {
            InitializeComponent();
        }
      

        private void Form_User_Load(object sender, EventArgs e)
        {

            hienthiUser1();

        }

        private void dataGridView_user_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine("Loi data ombo");
        }
        public void hienthiUser1()
        {
           


            Column_maquyen.DataSource = c2.laymaquyen();
            Column_maquyen.ValueMember = "maquyen";
            Column_maquyen.DataPropertyName = "maquyen";
            Column_maquyen.DisplayMember = "maquyen";



            tableU = c2.layngdung();
            bindingS.DataSource = tableU;
            bindingNavigator_user.BindingSource = bindingS;
            dataGridView_user.DataSource = bindingS;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            bindingNavigator_user.BindingSource.MoveNext();
            
            int t  = c2.save();
            if (t > 0)
            {
                MessageBox.Show("cap nhat " + t);
            }
            else
                MessageBox.Show("ko co ji thay doi");
            bindingNavigator_user.BindingSource.MovePrevious();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            hienthiUser1();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DataRow dr = tableU.NewRow();
            dr["id"] = nextUser();
            tableU.Rows.Add(dr);
            bindingNavigator_user.BindingSource.MoveLast();
        }
        private String nextUser()
        {
            String nextU = "u" + dataGridView_user.Rows.Count.ToString();
            return nextU;
        }

        
    }
}
