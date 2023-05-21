using DevExpress.XtraBars;
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
    public partial class form : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        
        public form()
        {
            InitializeComponent();
            ribNghiepVu.Visible = ribDanhMuc.Visible = ribBaoCao.Visible = false;
            btnDangXuat.Enabled = btnTaoLogin.Enabled = btnThoat.Enabled = false;
            

        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult choice = MessageBox.Show("Bạn có thực sự muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (choice == DialogResult.Yes)
            {
                Program.mChiNhanh = 0;
                Program.mloginDN = "";
                Program.passwordDN = "";
                this.MANV.Text = "";
                this.HOTEN.Text = "";
                this.NHOM.Text = "";
                foreach (Form f in this.MdiChildren)
                {
                    f.Close();
                }

            }
        }


        private void btnDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {

            Form frm = this.CheckExists(typeof(frmDangNhap));
            if (frm != null) frm.Activate();
            else
            {
                frmDangNhap f = new frmDangNhap();
                f.MdiParent = this;
                f.Show();
            }


        }

        public void HienThiMenu()
        {
            MANV.Text = "MÃ NV: " + Program.username;
            HOTEN.Text = "Họ tên: " + Program.mHoten.Trim('\r', '\n');
            NHOM.Text = "Nhóm: " + Program.mGroup;
            //phân quyền
           

            if(Program.mGroup == "NGANHANG")
            {
                ribDanhMuc.Visible= true;
                ribBaoCao.Visible = true;
                btnTKNH.Enabled = false;
                btnTKKhachHang.Enabled = false;
                btnDangXuat.Enabled = btnTaoLogin.Enabled = btnThoat.Enabled = true;
            }
            else if(Program.mGroup == "KHACHHANG")
            {
                btnTaoLogin.Enabled = false;
                ribBaoCao.Visible = true;
                // Danh sách khách hàng
                barButtonItem2.Enabled = false;
                btnTKNH.Enabled = false;
                btnDSTaiKhoan.Enabled = false;
                btnDangXuat.Enabled = btnThoat.Enabled = true;
            }
            else if(Program.mGroup == "CHINHANH")
            {
                btnTaoLogin.Enabled = true;
                ribNghiepVu.Visible = true;
                ribDanhMuc.Visible = true;
                ribBaoCao.Visible = true;
                barButtonItem2.Enabled = true;
                btnTKNH.Enabled = true;
                btnDSTaiKhoan.Enabled = true;
                btnTKKhachHang.Enabled = true;
                btnDangXuat.Enabled = btnTaoLogin.Enabled = btnThoat.Enabled = true;
            }
        } 

        private void btnDSNV_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDSNhanVien));
            if (frm != null) frm.Activate();
            else
            {
                frmDSNhanVien f = new frmDSNhanVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTaoLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmTaoLogin));
            if (frm != null) frm.Activate();
            else
            {
                frmTaoLogin f = new frmTaoLogin();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDSKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDSKhachHang));
            if (frm != null) frm.Activate();
            else
            {
                frmDSKhachHang f = new frmDSKhachHang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTKKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmTTHTKhachHang));
            if (frm != null) frm.Activate();
            else
            {
                frmTTHTKhachHang f = new frmTTHTKhachHang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnCGR_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmChuyenGuiRut));
            if (frm != null) frm.Activate();
            else
            {
                frmChuyenGuiRut f = new frmChuyenGuiRut();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnThongKeGD_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(Frpt_ThongKeGD));
            if (frm != null) frm.Activate();
            else
            {
                Frpt_ThongKeGD f = new Frpt_ThongKeGD();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDSTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(Frpt_DSTaiKhoan));
            if (frm != null) frm.Activate();
            else
            {
                Frpt_DSTaiKhoan f = new Frpt_DSTaiKhoan();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTKNH_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmTKNH));
            if (frm != null) frm.Activate();
            else
            {
                frmTKNH f = new frmTKNH();
                f.MdiParent = this;
                f.Show();

            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(FrptDSKH));
            if (frm != null) frm.Activate();
            else
            {
                FrptDSKH f = new FrptDSKH();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}