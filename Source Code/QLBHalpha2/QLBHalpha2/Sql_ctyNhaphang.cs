using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLBHalpha2
{
    partial class Connection2
    {
        public bool sosanhMSP(String msp)
        {
            DataTable db = layDSMSP();
            foreach (DataRow dr in db.Rows)
            {
                String s = dr["msp"].ToString().Trim();
               // MessageBox.Show(s);
                if (msp.Equals(s))
                {
                    return true;
                }
            }
            return false;
        }
    }
}