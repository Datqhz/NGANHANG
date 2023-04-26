using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGANHANG
{
    public partial class frmDSKhachHang : Form
    {
        private Stack myStack = new Stack();
        private string macn = "";
        private int row;
        private int chucnang;
        private string thongtin = "";
        public frmDSKhachHang()
        {
            InitializeComponent();
        }

        private void khachHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKhachHang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void khachHangBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsKhachHang.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmDSKhachHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.KhachHang' table. You can move, or remove it, as needed.
            
            dS.EnforceConstraints = false;// Tải về nhưng không kiểm tra ràng buộc
            this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
            this.khachHangTableAdapter.Fill(this.dS.KhachHang);
            // TODO: This line of code loads data into the 'dS.KhachHang' table. You can move, or remove it, as needed.
            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS.TaiKhoan' table. You can move, or remove it, as needed.
            this.taiKhoanTableAdapter.Fill(this.dS.TaiKhoan);

            macn = ((DataRowView)bdsKhachHang[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;
            if (Program.mGroup == "NGANHANG")
            {
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = false;
                cmbChiNhanh.Enabled = true;
            }
            else
            {
                btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled;
                cmbChiNhanh.Enabled = false;
            }
            txtMACN.Enabled = btnPhucHoi.Enabled = btnHuy.Enabled = btnGhi.Enabled = false;
            grbTT.Enabled = false;
            cmbPhai.Items.Insert(0, "Nam");
            cmbPhai.Items.Insert(1, "Nữ");
            
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cmbPhai.SelectedIndex = 0;
            chucnang = 1;
            txtCMND.Enabled = true;
            row = bdsKhachHang.Position;
            grbTT.Enabled = true;
            gcKhachHang.Enabled = false;
            bdsKhachHang.AddNew();
            txtMACN.Text = macn;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnPhucHoi.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = true;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chucnang = 0;
            txtCMND.Enabled = false;
            row = bdsKhachHang.Position;
            grbTT.Enabled = true;
            gcKhachHang.Enabled=false;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnPhucHoi.Enabled = false;
            btnGhi.Enabled = btnHuy.Enabled = true;
            thongtin += txtCMND.Text.Trim() + ";" +
                    ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["HO"].ToString()
                    + ";" + ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["TEN"].ToString() + ";"
                    + ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["DIACHI"].ToString() + ";"
                    + ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["PHAI"].ToString() + ";"
                    + ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["NGAYCAP"].ToString() + ";"
                    + ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["SODT"].ToString() + ";"
                    + ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["MACN"].ToString();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string cmnd = "";
            
            if (bdsTaiKhoan.Count > 0)
            {
                MessageBox.Show("Khách hàng đã đăng ký tài khoản, không thể xóa!", "Thông báo", MessageBoxButtons.OK);
                return;
            }else
            {
                if(MessageBox.Show("Bạn có thực sự muốn xóa thông tin khách hàng này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        thongtin += ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["CMND"].ToString() + ";" +
                            ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["HO"].ToString()
                            + ";" + ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["TEN"].ToString() + ";"
                            + ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["DIACHI"].ToString() + ";"
                            + ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["PHAI"].ToString() + ";"
                            + ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["NGAYCAP"].ToString() + ";"
                            + ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["SODT"].ToString() + ";"
                            + ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["MACN"].ToString();
                                cmnd = ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["CMND"].ToString();
                        bdsKhachHang.RemoveCurrent();
                        this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.khachHangTableAdapter.Update(this.dS.KhachHang);
                        myStack.Push("delete;" + thongtin);
                        thongtin = "";
                    }catch(Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa khách hàng. Vui lòng thử lại.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                        this.khachHangTableAdapter.Fill(this.dS.KhachHang);
                        bdsKhachHang.Position = bdsKhachHang.Find("CMND",cmnd);
                        return;
                    }
                }
            }
            if (bdsKhachHang.Count == 0) btnXoa.Enabled = false;
            if (myStack.Count != 0)
            {
                btnPhucHoi.Enabled = true;
            }
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string str = myStack.Pop().ToString();
            Console.WriteLine(str);
            string[]strItem = str.Split(';');
            if (strItem[0] == "delete")
            {
                if(MessageBox.Show("Bạn có muốn khôi phục thông tin khách hàng có CMND \"" + strItem[1] + "\" không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bdsKhachHang.AddNew();
                    txtCMND.Text = strItem[1];
                    txtHo.Text = strItem[2];
                    txtTen.Text = strItem[3];  
                    txtDiaChi.Text = strItem[4];
                    if (strItem[5] == "Nam")
                    {
                        cmbPhai.SelectedIndex = 0;
                    }else
                    {
                        cmbPhai.SelectedIndex=1;
                    }
                    dteNgayCap.Text = strItem[6];
                    txtSDT.Text = strItem[7];
                    txtMACN.Text = strItem[8];
                    bdsKhachHang.EndEdit();
                    bdsKhachHang.ResetCurrentItem();
                    this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.khachHangTableAdapter.Update(this.dS.KhachHang);
                }else
                {
                    myStack.Push(str);
                }
                
            }else if(strItem[0] == "add") 
            {
                if(MessageBox.Show("Bạn có muốn xóa khách hàng có CMND \"" + strItem[1] + "\" khỏi cơ sở dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bdsKhachHang.Position =bdsKhachHang.Find("CMND", strItem[1]);
                    bdsKhachHang.RemoveCurrent();
                    this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.khachHangTableAdapter.Update(this.dS.KhachHang);
                }else
                {
                    myStack.Push(str);
                }
            }else
            {
                if (MessageBox.Show("Bạn có muốn khôi phục thông tin khách hàng có CMND \"" + strItem[1] + "\" như trước không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bdsKhachHang.Position = bdsKhachHang.Find("CMND", strItem[1]);
                    txtCMND.Text = strItem[1];
                    txtHo.Text = strItem[2];
                    txtTen.Text = strItem[3];
                    txtDiaChi.Text = strItem[4];
                    if (strItem[5] == "Nam")
                    {
                        cmbPhai.SelectedIndex = 0;
                    }
                    else
                    {
                        cmbPhai.SelectedIndex = 1;
                    }
                    dteNgayCap.Text = strItem[6];
                    txtSDT.Text = strItem[7];
                    txtMACN.Text = strItem[8];
                    bdsKhachHang.EndEdit();
                    bdsKhachHang.ResetCurrentItem();
                    this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.khachHangTableAdapter.Update(this.dS.KhachHang);
                }
                else
                {
                    myStack.Push(str);
                }
            }
            if(myStack.Count == 0)
            {
                btnPhucHoi.Enabled = false;
            }
            
        }

        private void btnlamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.khachHangTableAdapter.Fill(this.dS.KhachHang);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message, "Lỗi", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (txtCMND.Text.Trim() == "")
            {
                MessageBox.Show("CMND không được để trống!!!", "Thông báo", MessageBoxButtons.OK);
                return;
            }else if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ không được để trống!!!", "Thông báo", MessageBoxButtons.OK);
                return;
            }else if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên không được để trống!!!", "Thông báo", MessageBoxButtons.OK);

                return;
            }else if (dteNgayCap.Text.Trim() == "")
            {
                MessageBox.Show("Ngày cấp CMND không được để trống!!!", "Thông báo", MessageBoxButtons.OK);
                return;
            }else if (txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Số điện thoại không được để trống!!!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            try
            {
                string stackstr = "";
                if(chucnang == 1)
                {
                    Program.myReader = Program.ExecSqlDataReader("EXEC find_KH_by_CMND '" + txtCMND.Text.Trim() + "'");
                    Program.myReader.Read();
                    if (Program.myReader.HasRows)
                    {
                        MessageBox.Show("Số CMND của khách hàng đã tồn tại trên hệ thống!!", "Thông báo", MessageBoxButtons.OK);
                        Program.myReader.Close();
                        return;
                    }else
                    {
                        Program.myReader.Close();

                    }
                    stackstr += "add;" + txtCMND.Text.Trim(); ;
                }else
                {
                    //((DataRowView)bdsKhachHang[bdsKhachHang.Position])["HO"].ToString();
                    stackstr += "edit;" + thongtin;
                }
                bdsKhachHang.EndEdit();
                bdsKhachHang.ResetCurrentItem();
                this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khachHangTableAdapter.Update(this.dS.KhachHang);
                /*stackstr += ";" + txtCMND.Text.Trim() + ";" +
                    txtHo.Text.Trim() + ";" + txtTen.Text.Trim() + ";"
                    + txtDiaChi.Text.Trim() + ";" + cmbPhai.Text.Trim() + ";" + dteNgayCap.Text.Trim() + ";"
                    + txtSDT.Text.Trim() + ";" + txtMACN.Text.Trim();*/
                Console.WriteLine(stackstr);
                myStack.Push(stackstr);
                thongtin = "";
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi ghi nhân viên.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return;
            }
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnPhucHoi.Enabled = true;
            btnGhi.Enabled = btnHuy.Enabled = true;
            grbTT.Enabled = false;
            gcKhachHang.Enabled = true;

        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView")) //Kiểm tra xem cmb đã có các phân mảnh hay chưa
            {
                return;
            }
            Program.servername = cmbChiNhanh.SelectedValue.ToString();
            if (cmbChiNhanh.SelectedIndex != Program.mChiNhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }

            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới.", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khachHangTableAdapter.Fill(this.dS.KhachHang);

                this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                this.taiKhoanTableAdapter.Fill(this.dS.TaiKhoan);

                macn = ((DataRowView)bdsKhachHang[0])["MACN"].ToString();
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKhachHang.CancelEdit();
            if (btnThem.Enabled == false)
            {
                bdsKhachHang.Position = row;
            }
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            grbTT.Enabled = false;
            gcKhachHang.Enabled = true;
        }
    }
}
