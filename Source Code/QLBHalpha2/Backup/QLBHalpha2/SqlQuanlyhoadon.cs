using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml;
using System.Data;

namespace QLBHalpha2
{
    partial class Connection2
    {
        public DataTable getDShd()
        {
            queue = "select * from hoadon where tongtrigia > 0 order by mhd";
            return thuchienSQL(queue,true);
        }

        public DataTable getDS_CTHD(String mhd)
        {
            queue = "select * from cthd where mhd = " + mhd +" order by mhd";
            return thuchienSQL(queue,true);
        }
    }
}
