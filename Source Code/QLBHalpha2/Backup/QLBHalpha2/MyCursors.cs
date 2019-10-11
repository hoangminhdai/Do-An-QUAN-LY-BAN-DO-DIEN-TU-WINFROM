using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace QLBHalpha2
{
    public class MyCursors : UserControl
    {
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern IntPtr LoadCursorFromFile(String str);

        #region Tạo con trỏ chuột
        public static Cursor Create(string filename)
        {
            IntPtr hCursor = LoadCursorFromFile(filename);

            if (!IntPtr.Zero.Equals(hCursor))
            {
                return new Cursor(hCursor);
            }
            else
            {
                MessageBoxEx.Show("Không thể tạo con trỏ chuột từ file Pointer.cur!\nCó thể file này bị lỗi hoặc không tồn tại trong hệ thống.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return Cursors.Default;
            }
        }
        #endregion
    }
}
