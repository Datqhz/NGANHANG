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
            if(choice == DialogResult.Yes)
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

        }
    }
}