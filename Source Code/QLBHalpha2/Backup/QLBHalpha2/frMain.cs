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
    public partial class frMain : Office2007RibbonForm
    {
        //Form
        frLogin loginForm1 = null;
        frNguoidung Form_User1 = null;
        frNhanvien nhanvienForm1 = null;
        frSanpham spForm1 = null;
        frLoaisp Loaisp = null;
        frNsx frnsx = null;
        frDoiMK frdoimk = null;
        frBackup_restore frBr = null;
        frKhachhang frkh = null;
        frMuahang frmuahang = null;
        frDatHang frDh = null;
        frQuanLyDatHang frqldh = null;
        frHoadon frhd = null;
        frNcc frncc = null;
        fr_CtyDatHang frctyDH = null;
        frthongke frTK = null;
        fr_thongkeBanHang frTKBH = null;
        //class
        Connection2 c2 = new Connection2();
        public frMain()
        {
            InitializeComponent();
        }

        private void office2007StartButton1_Click(object sender, EventArgs e)
        {

        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            loginS();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc muốn thoát chương trình ? ", "", MessageBoxButtons.YesNo);
            if (kq == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void RibbonStart_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            
            if (c2.checkConn())
            {
                //con tro
                this.Cursor = MyCursors.Create(System.IO.Path.Combine(Application.StartupPath, "Pointer.cur"));
                login_default();
            }
            else
            {
                MessageBox.Show("Loi ket noi CSDL - kiem tra file Connection.xml trong thu muc debug");
            }
        }

        public void loginS()
        {
        Cout:
            if (loginForm1 == null || loginForm1.IsDisposed)
            {
                loginForm1 = new frLogin();
            }

            //loginForm1.Show();
            if (loginForm1.ShowDialog() == DialogResult.OK)
            {

                if (loginForm1.textBoxX_id.Text == "")
                {
                    loginForm1.labelX_statusloginForm.Text = "Chưa nhập username";
                    goto Cout;
                }
               
                int kq = login(loginForm1.textBoxX_id.Text, loginForm1.textBoxX_pass.Text);
                switch (kq)
                {
                    case 0: { loginForm1.labelX_statusloginForm.Text = "!!!Tài khoản không tồn tại"; goto Cout; }
                    case 1: { loginForm1.labelX_statusloginForm.Text = "sai mật khẩu"; goto Cout; }
                    case 2:
                        {
                            loginForm1.labelX_statusloginForm.Text = "đăng nhập thành công !!!!";
                            String quyen = c2.getQuyen(loginForm1.textBoxX_id.Text).Trim();
                            this.labelX_statusBar.Text = "Login với Username : " + loginForm1.textBoxX_id.Text + "Với quyền " + quyen;
                            //login_admin();
                            chungthucLogin(quyen);
                            break;
                        }

                    default:
                        break;
                }
            }

        }

        private void buttonItem_user_Click(object sender, EventArgs e)
        {
            if (Form_User1 == null || Form_User1.IsDisposed)
            {
                Form_User1 = new frNguoidung();
                Form_User1.MdiParent = this;
                Form_User1.Show();
                tabItem_user.Text = "User";
            }
            else
                Form_User1.Activate();
            
        }

        public void chungthucLogin(String quyen)
        {
            if (quyen.Equals("admin"))
            {
                login_admin();
            }
            if (quyen.Equals("manager"))
            {
                logic_manager();
            }
            if (quyen.Equals("sell"))
                login_cell();
            if (quyen.Equals("nhaphang"))
                logic_nhaphang();
        }


        private void login_default()  //trang thai chua dang nhap
        {

            btBackup.Enabled = false;
            btDoiPass.Enabled = false;
            btRestore.Enabled = false;
            btLogOut.Enabled = false;

            buttonItem_user.Enabled = false;
            buttonItem_nhanvien.Enabled = false;
            buttonItem_khachhang.Enabled = false;

            buttonItemSp.Enabled = false;
            buttonItemLoaisp.Enabled = false;
            buttonItem_nhasx.Enabled = false;

            buttonItem_lapphieumua.Enabled = false;
            buttonItem_hoadon.Enabled = false;
            buttonItem_phieudathang.Enabled = false;
            buttonItem_quanlyDH.Enabled = false;

            buttonItem_Lapphieunhap.Enabled = false;
            buttonItem_hoadonnhap.Enabled = false;
            buttonItem_nhacc.Enabled = false;

            buttonItem_thongkeHD.Enabled = false;
            buttonItem_thongke.Enabled = false;
        }

        private void login_admin() //trang thai login voi quyen admin
        {

          
            btBackup.Enabled = true;
            btDoiPass.Enabled = true;
            btRestore.Enabled = true;
            btLogOut.Enabled = true;

            buttonItem_user.Enabled = true;
            buttonItem_nhanvien.Enabled = true;
            buttonItem_khachhang.Enabled = true;

           buttonItemSp.Enabled = true;
           buttonItemLoaisp.Enabled = true;
           buttonItem_nhasx.Enabled = true;

           buttonItem_lapphieumua.Enabled = true;
           buttonItem_hoadon.Enabled = true;
           buttonItem_phieudathang.Enabled = true;
           buttonItem_quanlyDH.Enabled = true;

           buttonItem_Lapphieunhap.Enabled = true;
           buttonItem_hoadonnhap.Enabled = true;
           buttonItem_nhacc.Enabled = true;

           buttonItem_thongkeHD.Enabled = true;
           buttonItem_thongke.Enabled = true;
        }
        private void logic_manager()
        {
            btBackup.Enabled = false;
            btDoiPass.Enabled = true;
            btRestore.Enabled = false;
            btLogOut.Enabled = true;

            buttonItem_user.Enabled = false;
            buttonItem_nhanvien.Enabled = true;
            buttonItem_khachhang.Enabled = true;

            buttonItemSp.Enabled = true;
            buttonItemLoaisp.Enabled = true;
            buttonItem_nhasx.Enabled = true;

            buttonItem_lapphieumua.Enabled = true;
            buttonItem_hoadon.Enabled = true;
            buttonItem_phieudathang.Enabled = true;
            buttonItem_quanlyDH.Enabled = true;

            buttonItem_Lapphieunhap.Enabled = true;
            buttonItem_hoadonnhap.Enabled = true;
            buttonItem_nhacc.Enabled = true;

            buttonItem_thongkeHD.Enabled = true;
            buttonItem_thongke.Enabled = true;
        }
        private void login_cell()
        {
            btBackup.Enabled = false;
            btDoiPass.Enabled = true;
            btRestore.Enabled = false;
            btLogOut.Enabled = true;

            buttonItem_user.Enabled = false;
            buttonItem_nhanvien.Enabled = false;
            buttonItem_khachhang.Enabled = true;

            buttonItemSp.Enabled = true;
            buttonItemLoaisp.Enabled = true;
            buttonItem_nhasx.Enabled = true;

            buttonItem_lapphieumua.Enabled = true;
            buttonItem_hoadon.Enabled = true;
            buttonItem_phieudathang.Enabled = true;
            buttonItem_quanlyDH.Enabled = true;

            buttonItem_Lapphieunhap.Enabled = false;
            buttonItem_hoadonnhap.Enabled = false;
            buttonItem_nhacc.Enabled = false;

            buttonItem_thongkeHD.Enabled = true;
            buttonItem_thongke.Enabled = true;
        }
        private void logic_nhaphang()
        {
            btBackup.Enabled = false;
            btDoiPass.Enabled = true;
            btRestore.Enabled = false;
            btLogOut.Enabled = true;

            buttonItem_user.Enabled = false;
            buttonItem_nhanvien.Enabled = false;
            buttonItem_khachhang.Enabled = false;

            buttonItemSp.Enabled = true;
            buttonItemLoaisp.Enabled = true;
            buttonItem_nhasx.Enabled = true;

            buttonItem_lapphieumua.Enabled = false;
            buttonItem_hoadon.Enabled = false;
            buttonItem_phieudathang.Enabled = false;
            buttonItem_quanlyDH.Enabled = false;

            buttonItem_Lapphieunhap.Enabled = true;
            buttonItem_hoadonnhap.Enabled = true;
            buttonItem_nhacc.Enabled = true;

            buttonItem_thongkeHD.Enabled = true;
            buttonItem_thongke.Enabled = true;
        }

        private void btLogOut_Click(object sender, EventArgs e)
        {
            login_default();
            loginForm1 = new frLogin();
            loginForm1.textBoxX_pass.Text = "";
            
            labelX_statusBar.Text = "Bạn đã logout...";
            //frNguoidung.ActiveForm.Close();
                //Form_User1.Close();
        }

        private void btDoiPass_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Cứ từ từ !!!");
            doimk();
            
        }

        private void btBackup_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Cứ từ từ !!!");
            if (frBr == null || frBr.IsDisposed)
            {
                frBr = new frBackup_restore();
                frBr.buttonX_restore.Enabled = false;
                frBr.Show();
            }
            else
            {
                frBr.Activate();
                frBr.buttonX_restore.Enabled = false;
            }
        }

        private void btRestore_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("Cứ từ từ !!!");
            if (frBr == null || frBr.IsDisposed)
            {
                frBr = new frBackup_restore();
                frBr.buttonX_backup.Enabled = false;
                frBr.Show();
            }
            else
            {
                frBr.Activate();
                frBr.buttonX_backup.Enabled = false;
            }
        }

        private void btHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cứ từ từ !!!");
        }

        private void buttonItem_nhanvien_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem_nhanvien_Click_1(object sender, EventArgs e)
        {
            if (nhanvienForm1 == null || nhanvienForm1.IsDisposed)
            {
                nhanvienForm1 = new frNhanvien();
                nhanvienForm1.MdiParent = this;
                nhanvienForm1.Show();
               
            }
            else
                nhanvienForm1.Activate();
        }

        private void ribbonBar8_ItemClick(object sender, EventArgs e)
        {

        }

        private void buttonItem2_Click(object sender, EventArgs e) // gọi form san phẩm
        {
            if (spForm1 == null || spForm1.IsDisposed)
            {
                spForm1 = new frSanpham();
                spForm1.MdiParent = this;
                spForm1.Show();
            }
            else
                spForm1.Activate();

        }

        private void Coder_Click(object sender, EventArgs e)
        {
            //frAbout ab1 = new frAbout();
            frTacgia frTG = new frTacgia();
            frTG.Show();
        }

        private void buttonItemLoaisp_Click(object sender, EventArgs e)
        {
            if (Loaisp == null || Loaisp.IsDisposed)
            {
                Loaisp = new frLoaisp();
                Loaisp.MdiParent = this;
                Loaisp.Show();
            }
            else
                Loaisp.Activate();
        }

        private void buttonItem2_Click_1(object sender, EventArgs e)
        {
            if (frnsx == null || frnsx.IsDisposed)
            {
                frnsx = new frNsx();
                frnsx.MdiParent = this;
                frnsx.Show();
            }
            else
                frnsx.Activate();
        }

        ///kiem tra login
        ///
        public int login(String id, String pass)
        {
            DataSet datatb = c2.getUser(id);
            if (datatb.Tables[0].Rows.Count == 0)
            {
                return 0; // ko ton tai user
            }
            String password = datatb.Tables[0].Rows[0]["pass"].ToString();
            if (password != pass)
            {
                return 1;  // sai pass
            }
            else
                return 2; //login thanh cong
        }


        /// xử lý đổi mật khâu
        /// 
        private void doimk()
        {
            try
            {
               Cout:
                if (frdoimk==null||frdoimk.IsDisposed)
                {
                    frdoimk = new frDoiMK();
                    //frdoimk.Show();
                }
                if (frdoimk.ShowDialog()==DialogResult.OK)//thuc hien doi mk
                {
                    bool check = false;
                    if (frdoimk.textBoxX_id.Text=="")
                    {
                        MessageBox.Show( "Chưa nhập tên đăng nhập ");
                        goto Cout;
                    }
                    int kq = login(frdoimk.textBoxX_id.Text, frdoimk.textBoxX_mkcu.Text);
                    switch (kq)
                    {
                        case 0: MessageBox.Show("tài khoản không tồn tại");  break;
                        case 1: MessageBox.Show("Mật khẩu cũ không chính xác"); break;
                        case 2: //kiem tra nhap dung id va pass, tien hanh doi
                            {
                                if (frdoimk.textBoxX_mkmoi1.Text=="" ||frdoimk.textBoxX_mkmoi1.Text.Equals(frdoimk.textBoxX_mkmoi2.Text))//neu 2 mat khau vua nhap giong nhau
                                {
                                    ///thuc hien ham doi mk
                                    ///
                                    c2.updateMKuser(frdoimk.textBoxX_id.Text,frdoimk.textBoxX_mkmoi1.Text);
                                    check = true;
                                    frdoimk.textBoxX_id.Text = "";
                                    frdoimk.textBoxX_mkcu.Text = "";
                                    frdoimk.textBoxX_mkmoi1.Text = "";
                                    frdoimk.textBoxX_mkmoi2.Text = "";
                                    MessageBox.Show("Đổi MK thành công!");
                                }

                                else
                                {
                                    MessageBox.Show("Mật khẩu xác thực chưa giống nhau!");
                                }
                                break;
                            }
                        default:
                            break;
                    }
                    if (check == false)
                        goto Cout;


                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi Doi MK " + ex.ToString());
                throw;
            }
        }

        private void buttonItem_khachhang_Click(object sender, EventArgs e)
        {
            if (frkh == null || frkh.IsDisposed)
            {
                frkh = new frKhachhang();
                frkh.MdiParent = this;
                frkh.Show();
            }
            else
                frkh.Activate();
        }

        private void buttonItem_lapphieumua_Click(object sender, EventArgs e)
        {
            if (frmuahang == null || frmuahang.IsDisposed)
            {
                frmuahang = new frMuahang();
                frmuahang.MdiParent = this;
                frmuahang.Show();
            }
            else
                frmuahang.Activate();
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            if (frTK == null || frTK.IsDisposed)
            {
                frTK = new frthongke();
                frTK.MdiParent = this;
                frTK.Show();
            }
            else
                frTK.Activate();
        }

        private void buttonItem_phieudathang_Click(object sender, EventArgs e)
        {
            if (frDh == null || frDh.IsDisposed)
            {
                frDh = new frDatHang();
                frDh.MdiParent = this;
                frDh.Show();
            }
            else
                frDh.Activate();
        }

        private void buttonItem_quanlyDH_Click(object sender, EventArgs e)
        {
            if (frqldh == null || frqldh.IsDisposed)
            {
                frqldh = new frQuanLyDatHang();
                frqldh.MdiParent = this;
                frqldh.Show();
            }
            else
                frqldh.Activate();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            if (frhd == null || frhd.IsDisposed)
            {
                frhd = new frHoadon();
                frhd.MdiParent = this;
                frhd.Show();
            }
            else
                frhd.Activate();
        }

        private void buttonItem_nhacc_Click(object sender, EventArgs e)
        {
            if (frncc == null || frncc.IsDisposed)
            {
                frncc = new frNcc();
                frncc.MdiParent = this;
                frncc.Show();
            }
            else
                frncc.Activate();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem_Lapphieunhap_Click(object sender, EventArgs e) // xu ly button cty nhap hang tu nha cung cap
        {
            if (frctyDH == null || frctyDH.IsDisposed)
            {
                frctyDH = new fr_CtyDatHang();
                frctyDH.MdiParent = this;
                frctyDH.Show();
            }
            else
                frctyDH.Activate();

        }

        private void buttonItem_thongkeHD_Click(object sender, EventArgs e)
        {
            if (frTKBH == null || frTKBH.IsDisposed)
            {
                frTKBH = new fr_thongkeBanHang();
                frTKBH.MdiParent = this;
                frTKBH.Show();

            }
            else
                frTKBH.Activate();
        }

        
    }
}
