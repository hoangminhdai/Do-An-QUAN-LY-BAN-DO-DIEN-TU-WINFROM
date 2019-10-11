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
        public DataTable thongkesp()//lay ds sl = 0
        {
            queue = "select * from sanpham where soluong=0";
            return thuchienSQL(queue, true);
        }
    }
}
