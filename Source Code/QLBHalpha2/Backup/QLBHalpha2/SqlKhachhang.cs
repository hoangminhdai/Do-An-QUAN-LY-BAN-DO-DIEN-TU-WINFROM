using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace QLBHalpha2
{
    partial class Connection2
    {
        public DataTable layDSkh()
        {
            queue = "select * from khachhang";
            return thuchienSQL(queue, true);
        }

        public DataTable layDSmaKH()
        {
            queue = "select mkh from khachhang";
            return thuchienSQL(queue, false);
        }
    }
}
