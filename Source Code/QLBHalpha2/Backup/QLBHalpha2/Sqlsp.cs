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
    partial class Connection2 // viet tiep class Connection2
    {
        public DataTable layDSsp()
        {
            try
            {
                queue = "select * from sanpham";
                return thuchienSQL(queue, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi sp 1" + ex.ToString());
                throw;
            }
        }

     

        public DataTable layDSmaloai2()
        {
            try
            {
                queue = "select ml from loaisp";
                return thuchienSQL(queue, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi sp 3" + ex.ToString());
                throw;
            }
        }
        public DataTable layDSnsx()
        {
            try
            {
                queue = "select mnsx from nhasx";
                return thuchienSQL(queue, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi sp 4" + ex.ToString());
                throw;
            }
        }
        public DataTable layDSMSP()
        {
            queue = "select msp from sanpham";
            return thuchienSQL(queue, false);
        }


        

    }
}
