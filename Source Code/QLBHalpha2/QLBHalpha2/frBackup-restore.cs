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
    public partial class frBackup_restore : Office2007Form
    {
        Connection2 c2 = new Connection2();
        public frBackup_restore()
        {
            InitializeComponent();
        }

        private void frBackup_restore_Load(object sender, EventArgs e)
        {
            textBoxX_path.Text = @"C:\Program Files\Microsoft SQL Server\MSSQL.2\MSSQL\Backup";
            textBoxX_path.Enabled = false;
            buttonX_path.Enabled = false;
        }

        private void buttonX_backup_Click(object sender, EventArgs e)
        {
            buttonX_restore.Enabled = false;
            c2.backup(textBoxX_path.Text);
            MessageBox.Show("backup thành công tại  " + textBoxX_path.Text);
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = textBoxX_path.Text;
            prc.Start();
        }

        private void buttonX_path_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "backupQLBH.bak";
            saveFileDialog1.Filter = "Backup file(*.bak) |*.bak";
            saveFileDialog1.Title = "Sao lưu CSDL";
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)

            {
                textBoxX_path.Text = saveFileDialog1.FileName.ToString();
            }
        }

        private void buttonX_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX_restore_Click(object sender, EventArgs e)
        {
            buttonX_backup.Enabled = false;
            //c2.restore(textBoxX_path.Text);
            MessageBox.Show("Restore thanh cong");
        }
    }
}
