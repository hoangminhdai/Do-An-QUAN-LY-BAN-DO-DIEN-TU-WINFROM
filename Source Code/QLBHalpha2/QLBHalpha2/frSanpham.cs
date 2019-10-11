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
    public partial class frSanpham : Office2007Form
    {
        bool check_bin = true;
        Connection2 c2 = new Connection2();
        private BindingSource bin = new BindingSource();
        DataTable DtableSP = new DataTable();
        DataTable Dtableml = new DataTable();
        DataTable DtableMansx = new DataTable();
        //
        DataTable DtimML = new DataTable();
        DataTable DtimMnsx = new DataTable();
        DataTable DtimMSP = new DataTable();
        DataTable DkqTim = new DataTable();
        public frSanpham()
        {
            InitializeComponent();
        }

        private void spForm_Load(object sender, EventArgs e)
        {
            hienthiSP();
        }

        private void hienthiSP()
        {
            try
            {
                dgv.AutoGenerateColumns = false;
                dgv.AllowUserToAddRows = false;
                Dtableml = c2.layDSmaloai2();
                DtableMansx = c2.layDSnsx();

                DtableSP = c2.layDSsp();
                
                
                // 
                comboBoxEx_maloai.DataSource = Dtableml;
                comboBoxEx_maloai.ValueMember = "ml";
                comboBoxEx_maloai.DisplayMember = "ml";

                comboBoxEx_nsx.DataSource = DtableMansx;
                comboBoxEx_nsx.ValueMember = "mnsx";
                comboBoxEx_nsx.DisplayMember = "mnsx";

                //gan vao binhdings
                bin.DataSource = DtableSP;
                if (check_bin)
                {
                    textBoxX_maps.DataBindings.Add("Text", bin, "msp");
                    textBoxX_dvt.DataBindings.Add("Text", bin, "dvt");
                    textBoxX_giaban.DataBindings.Add("Text", bin, "giaban");
                    textBoxX_giamua.DataBindings.Add("Text", bin, "giamua");
                    textBoxX_tensp.DataBindings.Add("Text", bin, "tensp");
                    textBoxX_soluong.DataBindings.Add("Text", bin, "soluong");
                    comboBoxEx_maloai.DataBindings.Add("SelectedValue", bin, "ml");
                    comboBoxEx_nsx.DataBindings.Add("SelectedValue", bin, "mnsx");
                    check_bin = false;
                }
                //
                ColumnMaloai.DataSource = Dtableml;
                ColumnMaloai.DisplayMember = "ml";
                ColumnMaloai.ValueMember = "ml";
                ColumnMaloai.DataPropertyName = "ml";

                ColumnMansx.DataSource = DtableMansx;
                ColumnMansx.DisplayMember = "mnsx";
                ColumnMansx.DisplayMember = "mnsx";
                ColumnMansx.DataPropertyName = "mnsx";

                dgv.DataSource = bin;
                bNavigator.BindingSource = bin;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi hienthiSP " + ex.ToString());
                throw;
            }
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        private void save()
        {
            try
            {
                bNavigator.BindingSource.MovePrevious();
                int t = c2.save();
                if (t > 0)
                {
                    MessageBox.Show("Cập nhật " + t + " hàng");
                }
                else
                    MessageBox.Show("Không có gì thay đổi");
                bNavigator.BindingSource.MoveNext();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi save " + ex.ToString());
                throw;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            save();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            hienthiSP();
        }

        private void buttonX_save_Click(object sender, EventArgs e)
        {
            save();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DataRow dr = DtableSP.NewRow();
            dr["msp"] = sp_next();
            dr["mnsx"] = "sx01";
            dr["ml"] = "LT";
            DtableSP.Rows.Add(dr);
            bNavigator.BindingSource.MoveLast();
        }
        public String sp_next()
        {
            String sptiep = "sp" + (dgv.Rows.Count+1).ToString();
            return sptiep;
        }

        private void buttonItem_timkiem_Click(object sender, EventArgs e)
        {
            hienthiTimSp();
            
        }

        private void hienthiTimSp()
        {
            try
            {
                textBoxX_timtensp.Enabled = true;
                comboBoxEx_timnsx.Enabled = true;
                comboBoxEx_timloaimh.Enabled = true;
                comboBoxEx_giamax.Enabled = true;
                comboBoxEx_timgiamin.Enabled = true;

               DtimML = c2.layDSmaloai2();
                DtimMnsx = c2.layDSnsx();
                DtimMSP = c2.layDSMSP();

                comboBoxEx_timmasp.DataSource = DtimMSP;
                comboBoxEx_timmasp.ValueMember = "msp";
                comboBoxEx_timmasp.DisplayMember = "msp";

                comboBoxEx_timloaimh.DataSource = DtimML;
                comboBoxEx_timloaimh.ValueMember = "ml";
                comboBoxEx_timloaimh.DisplayMember = "ml";

                comboBoxEx_timnsx.DataSource = DtimMnsx;
                comboBoxEx_timnsx.ValueMember = "mnsx";
                comboBoxEx_timnsx.DisplayMember = "mnsx";

                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi hien thi tim kiem" + ex.ToString());
                throw;
            }
        }

        private void buttonX_timkiem_Click(object sender, EventArgs e)
        {
            
            Search();
            //comboBoxEx_timmasp.Text = null;
            //textBoxX_timtensp.Text = null;
        }

        public void Search()
        {
            int choice = 0;
            String queue = "select * from sanpham where ";
            if (comboBoxEx_timmasp.Text != "")
            {
                choice++;
                queue += "msp = '" + comboBoxEx_timmasp.Text.Trim()+"'";
                
            }
            else
            {


               // MessageBox.Show(comboBoxEx_timmasp.SelectedIndex.ToString());
                
                
                //DtableNh.Clear();
                if (textBoxX_timtensp.Text.Trim() != "")
                {
                    choice++;
                    queue += "tensp = " + "'" + textBoxX_timtensp.Text.Trim() + "'";
                }
                if (comboBoxEx_timloaimh.Text.Trim() != "")
                {
                    choice++;
                    if (choice == 1)
                        queue += "ml = " + "'" + comboBoxEx_timloaimh.Text.Trim() + "'";
                    if (choice != 1)
                        queue += " and ml = " + "'" + comboBoxEx_timloaimh.Text.Trim() + "'";
                    //MessageBox.Show(queue);
                }
                if (comboBoxEx_timnsx.Text.Trim() != "")
                {

                    choice++;
                    if (choice == 1)
                        queue += "mnsx =" + "'" + comboBoxEx_timnsx.Text.Trim() + "'";
                    else
                        queue += " and mnsx =" + "'" + comboBoxEx_timnsx.Text.Trim() + "'";
                   // MessageBox.Show(queue);
                   // Console.WriteLine(queue);
                }
                if (comboBoxEx_timgiamin.SelectedIndex != -1)
                {
                    if (comboBoxEx_giamax.SelectedIndex == -1)
                    {
                        MessageBox.Show("Loi~ : Nhập giá min thì phải nhập giá max chứ !");
                    }
                    else
                    {
                        // MessageBox.Show(comboBoxEx_timgiamin.SelectedIndex.ToString());
                        choice++;
                        if (choice == 1)
                            queue += "giaban between " + "'" + comboBoxEx_timgiamin.Text.Trim() + "'" + " and " + "'" + comboBoxEx_giamax.Text.Trim() + "'";
                        else
                            queue += " and giaban between " + "'" + comboBoxEx_timgiamin.Text.Trim() + "'" + " and " + "'" + comboBoxEx_giamax.Text.Trim() + "'";
                        MessageBox.Show(queue);
                    }
                }
                
            }
            if (choice == 0)
                MessageBox.Show("Chọn cái ji đi");
            else
            {
                DkqTim = c2.thuchienSQL(queue, true);
                bin.DataSource = DkqTim;

                ColumnMaloai.DataSource = Dtableml;
                ColumnMaloai.DisplayMember = "ml";
                ColumnMaloai.ValueMember = "ml";
                ColumnMaloai.DataPropertyName = "ml";

                ColumnMansx.DataSource = DtableMansx;
                ColumnMansx.DisplayMember = "mnsx";
                ColumnMansx.DisplayMember = "mnsx";
                ColumnMansx.DataPropertyName = "mnsx";

                dgv.DataSource = bin;
                bNavigator.BindingSource = bin;

            }
            
        }

        private void buttonItem_edit_Click(object sender, EventArgs e)
        {
            hienthiSP();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //hienthiTimSp();
            comboBoxEx_timmasp.Text = "";
            comboBoxEx_timmasp.Enabled = false;

            textBoxX_timtensp.Enabled = true;
            comboBoxEx_timnsx.Enabled = true;
            comboBoxEx_timloaimh.Enabled = true;
            comboBoxEx_giamax.Enabled = true;
            comboBoxEx_timgiamin.Enabled = true;
        }

     

        private void buttonX_timtheomsp_Click(object sender, EventArgs e)
        {
            comboBoxEx_timmasp.Enabled = true;


            textBoxX_timtensp.Text = "";
            comboBoxEx_timnsx.Text = "";
            comboBoxEx_timloaimh.Text = "";
            comboBoxEx_giamax.SelectedIndex = -1;
            comboBoxEx_timgiamin.SelectedIndex = -1;

            textBoxX_timtensp.Enabled = false;
            comboBoxEx_timnsx.Enabled = false;
            comboBoxEx_timloaimh.Enabled = false;
            comboBoxEx_giamax.Enabled = false;
            comboBoxEx_timgiamin.Enabled = false;
        }

     
    }
}
