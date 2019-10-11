using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QLBHalpha2
{
    partial class frAbout : Office2007RibbonForm
    {
        public frAbout()
        {
            InitializeComponent();
            this.Text = "Đồ Án Cuối Kỳ PTTK HHHT";
            this.labelProductName.Text = "UIT - MMT02";
            this.labelVersion.Text = "Alpha2";
            this.labelCopyright.Text = "0|0";
            this.labelCompanyName.Text = "CRYWOLF";
            //this.labelCompanyName
            this.textBoxDescription.Text = "Đồ án cuối kỳ môn PTTK HTTT" + "\r\n" +
                                               " GV : ThS. Đỗ Thị Minh Phụng" + "\n" + "\r\n" +
                                                "----Coder------------" + "\r\n" +
                                                "Nguyễn Thanh Sơn 07520306" + "\r\n" +
                                                "Hồ Ngyễn Duy   07520055" + "\r\n" +
                                                "Nguyễn Thị Thúy 07520349" + "\r\n" +
                                               " Thái Thị Thu Thảo 07520323" + "\r\n" + 
                                               "vipboy286@gmail.com";
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelProductName_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
