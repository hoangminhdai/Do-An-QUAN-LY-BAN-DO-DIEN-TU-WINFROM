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
  class HoaDon
    {
        List<SP> sp = new List<SP>(); //dung de ghi chi tiet hoa don
        int mhd;//tu dong
        String mkh="";
        String mnv="";
       public HoaDon(String mkh, String mnv)
        {
            this.mkh = mkh;
            this.mnv = mnv;
        }
        public HoaDon()
        {
            mkh = "";
            mnv = "";
        }
        public HoaDon(DatHang dh)//giao hang : dat hang --> ghi hoa don
        {
            mkh = dh.GetMKH();
            mnv = dh.GetMNV();
            sp = dh.GetListSP();
        }
        public SP AddSP(SP s) //san pham da ton tai
        {
            
            foreach ( SP ss in sp)
            {
                MessageBox.Show("them san pham");
                //MessageBox.Show(ss.GetMSP());
                if(s.GetMSP().Equals(ss.GetMSP()))
                {//
                  //  MessageBox.Show(s.GetMSP());
                    ss.SetSoluong(s.GetSoluong() + ss.GetSoluong());
                    ss.SetThanhtien(ss.GetSoluong(),ss.GetGiaban());
                    return ss;
                }
            }
            sp.Add(s);
            return s;
        }
        public void RemoveSP(String msp)
        {
            foreach (SP s in sp)
            {
                if (msp == s.GetMSP())
                {
                    sp.Remove(s);
                    break;
                }
            }
        }

        public HoaDon(String mdh)
        {
        }
        public void SetMHD(int mhd)
        {
            this.mhd = mhd;
        }
        public String GetMKH()
        {
            return mkh;
        }
        public void SetMKH(String mkh)
        {
            this.mkh = mkh;
        }
        public String GetMNV()
        {
            return mnv;
        }
        public void SetMNV(String mnv)
        {
            this.mnv = mnv;
        }
        public List<SP> GetListSP()
        {
            return sp;
        }
        public int GetMHD()
        {
            return mhd;
        }
      
    }
}
