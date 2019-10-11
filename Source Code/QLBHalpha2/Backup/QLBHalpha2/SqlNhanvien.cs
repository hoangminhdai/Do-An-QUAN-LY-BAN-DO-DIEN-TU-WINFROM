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
        public DataTable laydsNV()
        {
            try
            {
                queue = "select * from nhanvien";
                return thuchienSQL(queue, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi nv1 " + ex.ToString());
                return tableResult;
                throw;
            }
        }

        public DataTable layGT()
        {
            queue = "select distinct gioitinh from nhanvien";
            return thuchienSQL(queue, false);
        }

        public DataTable layDSmaNV()
        {
            queue = "select mnv from nhanvien";
            return thuchienSQL(queue, false);
        }
        

    }
}
