﻿
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
    public partial class frthongke : Form
    {
        Connection2 c2 = new Connection2();
        DataTable DtSP = new DataTable();
        BindingSource binds = new BindingSource();
        
        public frthongke()
        {
            InitializeComponent();
        }

        private void Button_thongke_Click(object sender, EventArgs e)
        {
            thongkeSP();
        }
        private void thongkeSP()
        {
            dataGridViewX1.AutoGenerateColumns = false;
            dataGridViewX1.AllowUserToAddRows = false;
            DtSP = c2.thongkesp();
            binds.DataSource = DtSP;
            bindingNavigator1.BindingSource = binds;
            dataGridViewX1.DataSource = binds;
        }
    }
}
