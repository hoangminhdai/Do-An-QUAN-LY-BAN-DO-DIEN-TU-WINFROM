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
    public partial class frLogin : Office2007Form
    {
        public frLogin()
        {
            InitializeComponent();
        }

        private void OKbuttonX1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void CancelbuttonX2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void PasstextBoxX2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frLogin_Load(object sender, EventArgs e)
        {

        }
        
    }
}
