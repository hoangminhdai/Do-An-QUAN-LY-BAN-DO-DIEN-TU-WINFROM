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
        public DataTable LayDSdatHang0()
        {
            queue = "select * from dathang where tinhtrang = 0";
            return thuchienSQL(queue, false);
        }

        public DataTable LayDSCTDathang(String mdh) ///lay ds chi tiet dat hang theo ma dat hang
        {
            queue = "select a.mdh,b.msp,b.tensp,a.giaban,a.sldathang,a.thanhtien from chitiet_PDH a ,sanpham b,dathang c where c.mdh = a.mdh and a.msp = b.msp and c.mdh = " + mdh;
            return thuchienSQL(queue, false);
        }                    
    }
}
