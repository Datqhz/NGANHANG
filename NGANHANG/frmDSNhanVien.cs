using DevExpress.XtraEditors.ButtonPanel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGANHANG
{
    public partial class frmDSNhanVien : Form
    {
        private String macn = "";
        private int vitri = 0;
        private int chucnang;
        //private String manv = "";
        public frmDSNhanVien()
        {
            InitializeComponent();
        }

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmDSNhanVien_Load(object sender, EventArgs e)
        {

            DS.EnforceConstraints = false;// Tải về nhưng không kiểm tra ràng buộc
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
            // TODO: This line of code loads data into the 'dS.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
            // TODO: This line of code loads data into the 'DS.GD_CHUYENTIEN' table. You can move, or remove it, as needed.
            this.gD_CHUYENTIENTableAdapter.Fill(this.DS.GD_CHUYENTIEN);
            // TODO: This line of code loads data into the 'DS.GD_GOIRUT' table. You can move, or remove it, as needed.
            this.gD_GOIRUTTableAdapter.Fill(this.DS.GD_GOIRUT);

            macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;
            if (Program.mGroup == "NGANHANG")
            {
                btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnGhi.Enabled = false;
                cmbChiNhanh.Enabled = true;
            }
            else
            {
                btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = btnGhi.Enabled = true;
                cmbChiNhanh.Enabled = false;
            }

        }

        private void nhanVienBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaNV.Enabled = true;
            vitri = bdsNV.Position;//Lấy vị trí hiện tại
            grbNhapLieu.Enabled = true;
            bdsNV.AddNew();
            txtMaCN.Text = macn;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled  = btnLamMoi.Enabled = btnDong.Enabled = false;
            btnPhucHoi.Enabled = btnGhi.Enabled = true;
            gcNhanVien.Enabled = false;
            chucnang = 1;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsNV.CancelEdit();
            if(btnThem.Enabled == false)
            {
                bdsNV.Position = vitri;
            }
            gcNhanVien.Enabled = true;
            grbNhapLieu.Enabled = false;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnDong.Enabled = true;
            btnPhucHoi.Enabled = btnGhi.Enabled = false;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chucnang = 2;
            txtMaNV.Enabled = false;
            vitri = bdsNV.Position;//Lấy vị trí hiện tại
            grbNhapLieu.Enabled = true;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnDong.Enabled = false;
            btnPhucHoi.Enabled = btnGhi.Enabled = true;
            gcNhanVien.Enabled = false;
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi reload: " + ex.Message, "Lỗi", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String manv = "";
            if(bdsGR.Count > 0 || bdsCT.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập giao dịch");
            }else
            {
                if(MessageBox.Show("Bạn có thực sự muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    try
                    {
                        manv = ((DataRowView)bdsNV[bdsNV.Position])["MACN"].ToString();
                        bdsNV.RemoveCurrent();
                        this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.nhanVienTableAdapter.Update(this.DS.NhanVien);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa nhân viên. Vui lòng thử lại.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                        this.nhanVienTableAdapter.Fill(this.DS.NhanVien);
                        bdsNV.Position = bdsNV.Find("MANV", manv);
                        return;
                    }
                }
            }
            if (bdsNV.Count == 0) btnXoa.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaNV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!", "Thông báo", MessageBoxButtons.OK);
                txtMaNV.Focus();
                return;
            }else if(txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập họ!", "Thông báo", MessageBoxButtons.OK);
                txtHo.Focus();
                return;
            }
            else if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên!", "Thông báo", MessageBoxButtons.OK);
                txtTen.Focus();
                return;
            }
            else if (txtCMND.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số CMND!", "Thông báo", MessageBoxButtons.OK);
                txtCMND.Focus();
                return;
            }
            else if (txtSDT.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK);
                txtSDT.Focus();
                return;
            }


            try
            {
                if (chucnang == 1)
                {
                    Program.myReader = Program.ExecSqlDataReader("EXEC find_nv_by_manv '" + txtMaNV.Text.Trim() + "'");
                    Program.myReader.Read();
                    if (Program.myReader.HasRows)
                    {
                        MessageBox.Show("Mã nhân viên đã tồn tại", "Thông báo", MessageBoxButtons.OK);
                        Program.myReader.Close();
                        return;
                    }
                    else
                    {
                        Program.myReader.Close();
                    }
                }
                bdsNV.EndEdit();
                bdsNV.ResetCurrentItem(); //Đưa các thông tin vừa điền lên lưới
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Update(this.DS.NhanVien);
            }catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi nhân viên.\n" + ex.Message,"Thông báo", MessageBoxButtons.OK);
                return;
            }
            gcNhanVien.Enabled = true;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnDong.Enabled = true;
            btnPhucHoi.Enabled = btnGhi.Enabled = false;
            grbNhapLieu.Enabled = false;
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbChiNhanh.SelectedItem.ToString() == "System.Data.DataRowView") //Kiểm tra xem cmb đã có các phân mảnh hay chưa
            {
                return;
            }
            Program.servername = cmbChiNhanh.SelectedValue.ToString();
            if(cmbChiNhanh.SelectedIndex!= Program.mChiNhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }

            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới.", "Thông báo", MessageBoxButtons.OK);
            }else
            {
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.connstr;
                this.nhanVienTableAdapter.Fill(this.DS.NhanVien);

                this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gD_GOIRUTTableAdapter.Fill(this.DS.GD_GOIRUT);

                this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.gD_CHUYENTIENTableAdapter.Fill(this.DS.GD_CHUYENTIEN);
                macn = ((DataRowView)bdsNV[0])["MANV"].ToString();
            }
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}
