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
    public partial class frmTaoTKKH : Form
    {
        private int vitri = 0;
        public frmTaoTKKH()
        {
            InitializeComponent();
        }

        private void taiKhoanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsTaiKhoan.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmTaoTKKH_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;// Tải về nhưng không kiểm tra ràng buộc
            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS.TaiKhoan' table. You can move, or remove it, as needed.
            this.taiKhoanTableAdapter.Fill(this.dS.TaiKhoan);
            // TODO: This line of code loads data into the 'dS.GD_CHUYENTIEN' table. You can move, or remove it, as needed.
            this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_CHUYENTIENTableAdapter.Fill(this.dS.GD_CHUYENTIEN);
            // TODO: This line of code loads data into the 'dS.GD_GOIRUT' table. You can move, or remove it, as needed.
            this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_GOIRUTTableAdapter.Fill(this.dS.GD_GOIRUT);
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;
            cmbChiNhanh.Enabled = false;

            if (Program.mGroup == "NGANHANG")
            {
                btnThem.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnGhi.Enabled = false;
            }
            else
            {
                btnThem.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnGhi.Enabled = true;
            }
            gcNhapLieu.Enabled = false;

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsTaiKhoan.Position;//Lấy vị trí hiện tại
            gcNhapLieu.Enabled = true;
            gcTaiKhoan.Enabled = false;
            bdsTaiKhoan.AddNew();
            btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = false;
            btnPhucHoi.Enabled = btnGhi.Enabled = btnDong.Enabled = true;
            if (cmbChiNhanh.SelectedIndex == 0)
            {
                txtMACN.Text = "BENTHANH";
            }
            else if (cmbChiNhanh.SelectedIndex == 0)
            {
                txtMACN.Text = "TANDINH";
            }
            Program.myReader.Close();
            Program.conn.Close();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String soTK = "";
            if (bdsGOIRUT.Count > 0 || bdsCHUYENTIEN.Count > 0 || bdsCHUYENTIEN1.Count > 0)
            {
                MessageBox.Show("Không thể xóa tài khoản này vì tài khoản đã phát sinh giao dịch");
            }
            else
            {
                if (MessageBox.Show("Bạn có thực sự muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    try
                    {
                        soTK = ((DataRowView)bdsTaiKhoan[bdsTaiKhoan.Position])["MACN"].ToString();
                        bdsTaiKhoan.RemoveCurrent();
                        this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.taiKhoanTableAdapter.Update(this.dS.TaiKhoan);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa Tài khoản. Vui lòng thử lại.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                        this.taiKhoanTableAdapter.Fill(this.dS.TaiKhoan);
                        bdsTaiKhoan.Position = bdsTaiKhoan.Find("SOTK", soTK);
                        return;
                    }
                }
            }
            if (bdsTaiKhoan.Count == 0) btnXoa.Enabled = false;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtSOTK.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tài khoản", "Thông báo", MessageBoxButtons.OK);
                txtSOTK.Focus();
                return;
            }
            if (txtCMND.Text.Trim() == "" || txtCMND.Text.Length != 10)
            {
                MessageBox.Show("Vui lòng nhập số chứng minh nhân dân hoặc không đủ 10 số", "Thông báo", MessageBoxButtons.OK);
                txtCMND.Focus();
                return;
            }

            bdsTaiKhoan.EndEdit();
            bdsTaiKhoan.ResetCurrentItem(); //Đưa các thông tin vừa điền lên lưới
            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            this.taiKhoanTableAdapter.Update(this.dS.TaiKhoan);

            gcTaiKhoan.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnDong.Enabled = true;
            btnPhucHoi.Enabled = btnGhi.Enabled = false;
            gcNhapLieu.Enabled = false;
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.taiKhoanTableAdapter.Fill(this.dS.TaiKhoan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message, "Lỗi", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnHuyTienTrinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnKTSOTK_Click(object sender, EventArgs e)
        {
            Program.myReader = Program.ExecSqlDataReader("EXEC find_TK_by_STK '" + txtSOTK.Text.Trim() + "'");
            Program.myReader.Read();
            if (Program.myReader.HasRows)
            {
                MessageBox.Show("Số tài khoản đã tồn tại", "Thông báo", MessageBoxButtons.OK);

                Program.myReader.Close();
                return;
            }
            else
            {
                Program.myReader.Close();

            }
        }

        private void btnKTCMND_Click(object sender, EventArgs e)
        {
            Program.myReader = Program.ExecSqlDataReader("EXEC find_KH_by_CMND '" + txtCMND.Text.Trim() + "'");
            Program.myReader.Read();
            if (Program.myReader.HasRows)
            {
                Program.myReader.Close();
            }
            else
            {
                MessageBox.Show("Số chứng minh nhân dân không tồn tại", "Thông báo", MessageBoxButtons.OK);
                Program.myReader.Close();
                return;
            }
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedIndex.ToString() == "System.Data.DataRowView")

                return;
            Program.servername = cmbChiNhanh.SelectedIndex.ToString();

        }
    }
}
