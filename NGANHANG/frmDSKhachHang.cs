using System;
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

        private string macn = "";
        private int row;
        private int chucnang;
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
                btnThem.Enabled = btnXoa.Enabled = btnSua.Enabled = btnPhucHoi.Enabled = btnGhi.Enabled = false;
                cmbChiNhanh.Enabled = true;
            }
            else
            {
                btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnGhi.Enabled = true;
                cmbChiNhanh.Enabled = false;
            }
            txtMACN.Enabled = false;
            grbTT.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chucnang = 1;
            txtCMND.Enabled = true;
            row = bdsKhachHang.Position;
            grbTT.Enabled = true;
            gcKhachHang.Enabled = false;
            bdsKhachHang.AddNew();
            txtMACN.Text = macn;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chucnang = 0;
            txtCMND.Enabled = false;
            row = bdsKhachHang.Position;
            grbTT.Enabled = true;
            gcKhachHang.Enabled=false;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string cmnd = "";
            if(bdsTaiKhoan.Count > 0)
            {
                MessageBox.Show("Khách hàng đã đăng ký tài khoản, không thể xóa!", "Thông báo", MessageBoxButtons.OK);
                return;
            }else
            {
                if(MessageBox.Show("Bạn có thực sự muốn xóa thông tin khách hàng này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        cmnd = ((DataRowView)bdsKhachHang[bdsKhachHang.Position])["CMND"].ToString();
                        bdsKhachHang.RemoveCurrent();
                        this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.khachHangTableAdapter.Update(this.dS.KhachHang);

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
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsKhachHang.CancelEdit();
            if(btnThem.Enabled == false)
            {
                bdsKhachHang.Position = row;
            }
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            grbTT.Enabled=false;
            gcKhachHang.Enabled = true;
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
                }
                bdsKhachHang.EndEdit();
                bdsKhachHang.ResetCurrentItem();
                this.khachHangTableAdapter.Connection.ConnectionString = Program.connstr;
                this.khachHangTableAdapter.Update(this.dS.KhachHang);


            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi ghi nhân viên.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return;
            }
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            grbTT.Enabled = false;
            gcKhachHang.Enabled = true;

        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}
