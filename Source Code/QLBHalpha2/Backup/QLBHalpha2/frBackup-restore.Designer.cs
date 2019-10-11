namespace QLBHalpha2
{
    partial class frBackup_restore
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonX_backup = new DevComponents.DotNetBar.ButtonX();
            this.buttonX_restore = new DevComponents.DotNetBar.ButtonX();
            this.textBoxX_path = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX_cancel = new DevComponents.DotNetBar.ButtonX();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonX_path = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // buttonX_backup
            // 
            this.buttonX_backup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_backup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_backup.Location = new System.Drawing.Point(96, 78);
            this.buttonX_backup.Name = "buttonX_backup";
            this.buttonX_backup.Size = new System.Drawing.Size(75, 23);
            this.buttonX_backup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_backup.TabIndex = 0;
            this.buttonX_backup.Text = "Backup";
            this.buttonX_backup.Click += new System.EventHandler(this.buttonX_backup_Click);
            // 
            // buttonX_restore
            // 
            this.buttonX_restore.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_restore.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_restore.Location = new System.Drawing.Point(207, 78);
            this.buttonX_restore.Name = "buttonX_restore";
            this.buttonX_restore.Size = new System.Drawing.Size(75, 23);
            this.buttonX_restore.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_restore.TabIndex = 1;
            this.buttonX_restore.Text = "Restore";
            this.buttonX_restore.Click += new System.EventHandler(this.buttonX_restore_Click);
            // 
            // textBoxX_path
            // 
            // 
            // 
            // 
            this.textBoxX_path.Border.Class = "TextBoxBorder";
            this.textBoxX_path.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX_path.Location = new System.Drawing.Point(47, 28);
            this.textBoxX_path.Name = "textBoxX_path";
            this.textBoxX_path.Size = new System.Drawing.Size(413, 20);
            this.textBoxX_path.TabIndex = 2;
            // 
            // buttonX_cancel
            // 
            this.buttonX_cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_cancel.Location = new System.Drawing.Point(321, 78);
            this.buttonX_cancel.Name = "buttonX_cancel";
            this.buttonX_cancel.Size = new System.Drawing.Size(75, 23);
            this.buttonX_cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_cancel.TabIndex = 1;
            this.buttonX_cancel.Text = "Cancel";
            this.buttonX_cancel.Click += new System.EventHandler(this.buttonX_cancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonX_path
            // 
            this.buttonX_path.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX_path.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX_path.Location = new System.Drawing.Point(478, 28);
            this.buttonX_path.Name = "buttonX_path";
            this.buttonX_path.Size = new System.Drawing.Size(41, 20);
            this.buttonX_path.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX_path.TabIndex = 3;
            this.buttonX_path.Text = ".....";
            this.buttonX_path.Click += new System.EventHandler(this.buttonX_path_Click);
            // 
            // frBackup_restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 127);
            this.Controls.Add(this.buttonX_path);
            this.Controls.Add(this.textBoxX_path);
            this.Controls.Add(this.buttonX_cancel);
            this.Controls.Add(this.buttonX_restore);
            this.Controls.Add(this.buttonX_backup);
            this.Name = "frBackup_restore";
            this.Text = "frBackup_restore";
            this.Load += new System.EventHandler(this.frBackup_restore_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.ButtonX buttonX_backup;
        public DevComponents.DotNetBar.ButtonX buttonX_restore;
        public DevComponents.DotNetBar.Controls.TextBoxX textBoxX_path;
        public DevComponents.DotNetBar.ButtonX buttonX_cancel;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public DevComponents.DotNetBar.ButtonX buttonX_path;
    }
}