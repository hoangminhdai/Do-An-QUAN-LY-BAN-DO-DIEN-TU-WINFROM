namespace QLBHalpha2
{
    partial class frLogin
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.OKbuttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.CancelbuttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.textBoxX_id = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX_pass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.bar_Formlogin = new DevComponents.DotNetBar.Bar();
            this.labelX_statusloginForm = new DevComponents.DotNetBar.LabelX();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar_Formlogin)).BeginInit();
            this.bar_Formlogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(60, 41);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "User";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(60, 81);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Password";
            // 
            // OKbuttonX1
            // 
            this.OKbuttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.OKbuttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.OKbuttonX1.Location = new System.Drawing.Point(60, 126);
            this.OKbuttonX1.Name = "OKbuttonX1";
            this.OKbuttonX1.Size = new System.Drawing.Size(75, 23);
            this.OKbuttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.OKbuttonX1.TabIndex = 2;
            this.OKbuttonX1.Text = "OK";
            this.OKbuttonX1.Click += new System.EventHandler(this.OKbuttonX1_Click);
            // 
            // CancelbuttonX2
            // 
            this.CancelbuttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.CancelbuttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.CancelbuttonX2.Location = new System.Drawing.Point(175, 125);
            this.CancelbuttonX2.Name = "CancelbuttonX2";
            this.CancelbuttonX2.Size = new System.Drawing.Size(75, 23);
            this.CancelbuttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.CancelbuttonX2.TabIndex = 3;
            this.CancelbuttonX2.Text = "Cancel";
            this.CancelbuttonX2.Click += new System.EventHandler(this.CancelbuttonX2_Click);
            // 
            // textBoxX_id
            // 
            // 
            // 
            // 
            this.textBoxX_id.Border.Class = "TextBoxBorder";
            this.textBoxX_id.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX_id.Location = new System.Drawing.Point(131, 41);
            this.textBoxX_id.Name = "textBoxX_id";
            this.textBoxX_id.Size = new System.Drawing.Size(100, 20);
            this.textBoxX_id.TabIndex = 4;
            this.textBoxX_id.Text = "u1";
            this.textBoxX_id.WatermarkText = "ID";
            // 
            // textBoxX_pass
            // 
            // 
            // 
            // 
            this.textBoxX_pass.Border.Class = "TextBoxBorder";
            this.textBoxX_pass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX_pass.Location = new System.Drawing.Point(131, 81);
            this.textBoxX_pass.Name = "textBoxX_pass";
            this.textBoxX_pass.PasswordChar = '*';
            this.textBoxX_pass.Size = new System.Drawing.Size(100, 20);
            this.textBoxX_pass.TabIndex = 5;
            this.textBoxX_pass.WatermarkText = "Password";
            this.textBoxX_pass.TextChanged += new System.EventHandler(this.PasstextBoxX2_TextChanged);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(104, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(164, 23);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "ĐĂNG NHẬP";
            // 
            // bar_Formlogin
            // 
            this.bar_Formlogin.AntiAlias = true;
            this.bar_Formlogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bar_Formlogin.Controls.Add(this.labelX_statusloginForm);
            this.bar_Formlogin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bar_Formlogin.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.controlContainerItem1});
            this.bar_Formlogin.Location = new System.Drawing.Point(0, 175);
            this.bar_Formlogin.Name = "bar_Formlogin";
            this.bar_Formlogin.Size = new System.Drawing.Size(314, 33);
            this.bar_Formlogin.Stretch = true;
            this.bar_Formlogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar_Formlogin.TabIndex = 7;
            this.bar_Formlogin.TabStop = false;
            this.bar_Formlogin.Text = "bar1";
            // 
            // labelX_statusloginForm
            // 
            // 
            // 
            // 
            this.labelX_statusloginForm.BackgroundStyle.Class = "";
            this.labelX_statusloginForm.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX_statusloginForm.Location = new System.Drawing.Point(3, 2);
            this.labelX_statusloginForm.Name = "labelX_statusloginForm";
            this.labelX_statusloginForm.Size = new System.Drawing.Size(314, 28);
            this.labelX_statusloginForm.TabIndex = 0;
            this.labelX_statusloginForm.Text = "login.....";
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.Control = this.labelX_statusloginForm;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // frLogin
            // 
            this.AcceptButton = this.OKbuttonX1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 208);
            this.Controls.Add(this.bar_Formlogin);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.textBoxX_pass);
            this.Controls.Add(this.textBoxX_id);
            this.Controls.Add(this.CancelbuttonX2);
            this.Controls.Add(this.OKbuttonX1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Name = "frLogin";
            this.Text = "loginForm";
            this.Load += new System.EventHandler(this.frLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar_Formlogin)).EndInit();
            this.bar_Formlogin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.LabelX labelX1;
        public DevComponents.DotNetBar.LabelX labelX2;
        public DevComponents.DotNetBar.ButtonX OKbuttonX1;
        public DevComponents.DotNetBar.ButtonX CancelbuttonX2;
        public DevComponents.DotNetBar.Controls.TextBoxX textBoxX_id;
        public DevComponents.DotNetBar.Controls.TextBoxX textBoxX_pass;
        public DevComponents.DotNetBar.LabelX labelX3;
        public DevComponents.DotNetBar.Bar bar_Formlogin;
        public DevComponents.DotNetBar.LabelX labelX_statusloginForm;
        public DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
    }
}