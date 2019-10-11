using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBHalpha2
{
    class NhapHang
    {
        List<SP> sp = new List<SP>();
        int mpn;
        String mncc;
        String mnv;
        public NhapHang()
        {
            mncc = "";
            mnv = "";
        }
        public NhapHang(String mncc, String mnv)
        {
            this.mncc = mncc;
            this.mnv = mnv;
        }
        public String GetMNCC()
        {
            return mncc;
        }
        public void SetMNCC(String mncc)
        {
            this.mncc = mncc;
        }
        public String GetMNV()
        {
            return mnv;
        }
        public void SetMNV(String mnv)
        {
            this.mnv = mnv;
        }
        public void SetMPN(int mpn)
        {
            this.mpn = mpn;
        }
        public int GetMPN()
        {
            return mpn;
        }
        public List<SP> GetListSP()
        {
            return sp;
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
    }
}
