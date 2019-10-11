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
    public partial class frDoiMK : Office2007Form
    {
        public frDoiMK()
        {
            InitializeComponent();
        }

        private void buttonX_Xacnhan_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void buttonX_huybo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frDoiMK_Load(object sender, EventArgs e)
        {
            
        }

    }
}
