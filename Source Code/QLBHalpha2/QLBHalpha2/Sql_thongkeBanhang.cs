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
        public DataTable SumYear(String year)
        {
            queue = "select sum(tongtrigia) as tong from hoadon where year(ngaylap) = " + year;
            return thuchienSQL(queue, true);
        }

        public DataTable SumMonth(String year, String month)
        {
            queue = "select sum(tongtrigia) as tong from hoadon where year(ngaylap) = " + year + " and month(ngaylap) = "+month;
            Console.WriteLine(queue);
            return thuchienSQL(queue, true);
        }
        public DataTable SumDay(String year, String month, String day)
        {
            queue = "select sum(tongtrigia) as tong from hoadon where year(ngaylap) = " + year + " and month(ngaylap) = " + month + " and day(ngaylap) = "+day;
            Console.WriteLine(queue);
            return thuchienSQL(queue, true);
        }

        /// lenh thuc hien truy van dua ra tat cac cac san pham ban dc trong 1 khan thoi gian cu the
        /// 
        public DataTable ChitietYear(String year)
        {

            queue = "select a.mhd,b.mnv, b.mkh, a.msp,a.giamua,a.soluong, a.thanhtien,b.ngaylap  from CTHD a,hoadon b where a.mhd = b.mhd and";
            queue += " year(ngaylap) = " + year;
            Console.WriteLine(queue);
            return thuchienSQL(queue, true);
        }
        public DataTable ChitietMonth(String year, String month)
        {
            queue = "select a.mhd,b.mnv, b.mkh, a.msp,a.giamua,a.soluong, a.thanhtien,b.ngaylap  from CTHD a,hoadon b where a.mhd = b.mhd and";
            queue += " year(ngaylap) = " + year;
            queue += " and month(ngaylap) = " + month;
            Console.WriteLine(queue);
            return thuchienSQL(queue, true);
        }
        public DataTable ChitietDay(String year, String month, String day)
        {
            queue = "select a.mhd,b.mnv, b.mkh, a.msp,a.giamua,a.soluong, a.thanhtien,b.ngaylap  from CTHD a,hoadon b where a.mhd = b.mhd and";
            queue += " year(ngaylap) = " + year;
            queue += " and month(ngaylap) = " + month;
            queue += " and day(ngaylap) = " + day;
            Console.WriteLine(queue);
            return thuchienSQL(queue, true);
        }

    }
}
