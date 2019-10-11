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
        public DataTable layDSnsxAll()
        {
            queue = "select * from nhasx";
            return thuchienSQL(queue, true);
        }
    }
}
