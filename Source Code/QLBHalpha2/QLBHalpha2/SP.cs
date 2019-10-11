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
    class SP
    {
        Connection2 c2 = new Connection2();
        String msp ;
        String tenSP;
        String ml;
        String mnsx;
        //  DateTime hsd;
        String dvt;
        Double giamua;
        Double giaban;
        int soluong;
        double thanhtien;
        int status = 0;
        public SP()//display
        {
            // Connection2.getSP(MSP);
        }
        public SP(String msp, String tenSP, String ml, String mnsx, String dvt, Double giamua, Double giaban, int sl)
        {//dat hang
            //dung de ghi chi tiet phieu dat hang
            this.msp = msp;
            this.giaban = giaban;
            this.soluong = sl;
            this.thanhtien = sl * giaban;
            DataTable daSP = c2.GetSP(msp);
            if (daSP.Rows.Count == 0) //chua co sp--> san pham moi
            {// insert vao bang san pham
                this.tenSP = tenSP;
                this.ml = ml;
                this.mnsx = mnsx;
                // this.hsd = hsd;
                this.dvt = dvt;
                this.giamua = giamua;
                if (c2.InsertSP(this) == false)
                    MessageBox.Show(" loi insert san pham");
            }


        }

        public SP(String ma, int sl)//mua va dat hang
        {

            DataTable daSP = c2.GetSP(ma);
            if (daSP.Rows.Count != 0)// co san pham nay
            {
               

                    msp = daSP.Rows[0]["MSP"].ToString();
                    //MessageBox.Show(msp);
                    tenSP = daSP.Rows[0]["TENSP"].ToString();
                    giaban = double.Parse(daSP.Rows[0]["GIABAN"].ToString());
                    int s = int.Parse(daSP.Rows[0]["SOLUONG"].ToString());
                    if (s == 0)
                    {
                        MessageBox.Show("Da het san pham nay");
                        status = 3;//so luong la 0
                    }
                    else
                    {
                        if (s >= sl)
                            soluong = sl;
                        else
                        {
                            status = 1;//so luong dang ki lon hon
                            MessageBox.Show("So luong dang ki lon hon " + s);
                        }
                    }

                    thanhtien = giaban * soluong;
                
            }
            else
            {
                status = 2;//san pham nay khong ton tai
                MessageBox.Show("San pham nay khong ton tai");
            }



        }
        public SP SetSP(String ma, int sl)
        {
            MessageBox.Show("cai dat ");
            DataTable daSP = c2.GetSP(ma);
            if (daSP.Rows.Count != 0)// co san pham nay
            {
                MessageBox.Show("co san pham nay");
                    msp = daSP.Rows[0]["MSP"].ToString();
                    tenSP = daSP.Rows[0]["TENSP"].ToString();
                    giamua = double.Parse(daSP.Rows[0]["GIAMUA"].ToString());
                    soluong = sl;
                    thanhtien = giamua * soluong;
                
            }
            else
            {
                status = 2;//san pham nay khong ton tai
                MessageBox.Show("San pham nay khong ton tai");
            }
            return this;

        }

        public int GetStatus()
        {
            return status;
        }
        public void SetSoluong(int sl)
        {
            soluong = sl;
        }
        public void SetThanhtien(int sl, double gia)
        {
            thanhtien = sl * gia;
        }
        public String GetMSP()
        {
            return msp;
        }
        public String GetTensp()
        {
            return tenSP;
        }
        public double GetGiaban()
        {
            return giaban;
        }
        public int GetSoluong()
        {
            return soluong;
        }
        public double GetThanhtien()
        {
            return thanhtien;
        }
        public String GetML()
        {
            return ml;
        }
        public String GetMNSX()
        {
            return mnsx;
        }

        public Double GetGiaMua()
        {
            return giamua;
        }

        public String GetDVT()
        {
            return dvt;
        }

    }
}
