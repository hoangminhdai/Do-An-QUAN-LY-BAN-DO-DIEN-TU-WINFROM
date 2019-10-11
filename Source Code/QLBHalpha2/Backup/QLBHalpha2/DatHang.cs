using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBHalpha2
{
    class DatHang
    {
        List<SP> sp = new List<SP>(); //dung de ghi chi tiet phieu dat hang
        int  mdh;//tu dong tang
        String mkh="";
        String mnv="";
        DateTime date;
        int status = 0;//san pham chua giao 
        public DatHang()
        {
        }
        public DatHang(String mkh, String mnv,DateTime date)
        {
            this.mkh = mkh;
            this.mnv = mnv;
            this.date= date;
            //if(status!=0)
               // this.status =status;
        }
        public SP AddSP(SP s) //san pham da ton tai
        {
           
            foreach (SP ss in sp)
            {
                
                if (s.GetMSP().Equals(ss.GetMSP()))
                {
                    //  MessageBox.Show(s.GetMSP());
                    ss.SetSoluong(s.GetSoluong() + ss.GetSoluong());
                    ss.SetThanhtien(ss.GetSoluong(), ss.GetGiaban());
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
        public List<SP> GetListSP()
        {
            return sp;
        }
        public String GetMKH()
        {
            return mkh;
        }
        public void SetMKH(String mkh)
        {
            this.mkh = mkh;
        }
        public void SetMNV(String mnv)
        {
            this.mnv = mnv;
        }
        public void SetDate(DateTime date)
        {
            this.date = date;
        }
        public void SetStatus(int status)
        {
            this.status = status;
        }
        public String GetMNV()
        {
            return mnv;
        }
        public DateTime GetDate()
        {
            return date;
        }
        public int GetStatus()
        {
            return status;
        }
        public int GetMDH()
        {
            return mdh;
        }
        public void SetMDH(int mdh)
        {
            this.mdh = mdh;
        }
    }
}
