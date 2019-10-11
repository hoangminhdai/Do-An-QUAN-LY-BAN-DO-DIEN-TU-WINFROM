using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLBHalpha2
{
    public partial class frTacgia : Form
    {
        public frTacgia()
        {
            InitializeComponent();
        }

        private void frTacgia_Load(object sender, EventArgs e)
        {
            labelX1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelX1.Text = "ĐỒ ÁN CUỐI KỲ MÔN PTTK HTTT" ;
            labelX2.Text = "MMT02 - UIT - THÁNG 6/2010";
            String s = "NGUYỄN THANH SƠN 07520306";
            labelX4.Text = s + "\r\n" + "NGUYỄN THỊ THÚY  07520349" + "\r\n" + "HỒ NGUYỄN DUY   07520055" + "\r\n" +

                                               "THÁI THỊ THU THẢO 07520323" + "\r\n"
                                                +
                                               " GVHD : ThS. Đỗ Thị Minh Phụng";
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
