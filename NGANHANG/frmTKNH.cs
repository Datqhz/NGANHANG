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
    public partial class frmTKNH : Form
    {
        private int vitri = 0;
        private string macn = "";

        Stack myStack = new Stack();
        private string task = "";
        public frmTKNH()
        {
            InitializeComponent();
        }

        private void taiKhoanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsTK.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmTKNH_Load(object sender, EventArgs e)
        {
            dS.EnforceConstraints = false;// Tải về nhưng không kiểm tra ràng buộc
            
            // TODO: This line of code loads data into the 'dS.TaiKhoan' table. You can move, or remove it, as needed.
            this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            this.taiKhoanTableAdapter.Fill(this.dS.TaiKhoan);
            this.taiKhoanTableAdapter.Fill(this.dS.TaiKhoan);
            // TODO: This line of code loads data into the 'dS.GD_CHUYENTIEN' table. You can move, or remove it, as needed.
            this.gD_CHUYENTIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_CHUYENTIENTableAdapter.Fill(this.dS.GD_CHUYENTIEN);
            
            // TODO: This line of code loads data into the 'dS.GD_GOIRUT' table. You can move, or remove it, as needed.
            this.gD_GOIRUTTableAdapter.Connection.ConnectionString = Program.connstr;
            this.gD_GOIRUTTableAdapter.Fill(this.dS.GD_GOIRUT);


            if (Program.mGroup == "NGANHANG")
            {
                btnThem.Enabled = btnXoa.Enabled =  false;
            }
            else
            {
                btnThem.Enabled = btnXoa.Enabled = true;
            }
            pnlNhapLieu.Enabled =btnHuyTT.Enabled =btnGhi.Enabled = btnPhucHoi.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            task = "add;";
            vitri = bdsTK.Position;//Lấy vị trí hiện tại
            pnlNhapLieu.Enabled = true;
            gcTaiKhoan.Enabled = false;
            bdsTK.AddNew();
            btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnDong.Enabled = btnPhucHoi.Enabled = btnLamMoi.Enabled = false;
            btnHuyTT.Enabled = btnGhi.Enabled =  true;

            Program.myReader = Program.ExecSqlDataReader("select TOP(1) SOTK from TaiKhoan ORDER BY SOTK DESC");
            Program.myReader.Read();
            if (Program.myReader.HasRows)
            {
                txtSTK.Text =  Convert.ToString(int.Parse(Program.myReader.GetSqlString(0).ToString())+1);

            }
            Program.myReader.Close();
            Program.myReader = Program.ExecSqlDataReader("select * from ChiNhanh");
            Program.myReader.Read();
            if (Program.myReader.HasRows)
            {
                macn = Program.myReader.GetSqlString(0).ToString();

            }
            Program.myReader.Close();
            txtMaCN.Text = macn;
            dteNgayTao.DateTime = DateTime.Now;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            task = "delete;";
            String soTK = "";
            if (bdsGR.Count > 0 || bdsCTG.Count > 0 || bdsCTN.Count > 0)
            {
                MessageBox.Show("Không thể xóa tài khoản này vì tài khoản đã phát sinh giao dịch");
            }
            else
            {
                if (MessageBox.Show("Bạn có thực sự muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    try
                    {
                        task += txtSTK.Text.Trim() + ";" + txtCMND.Text.Trim() + ";" + txtSoDu.Text.Trim()
                            + ";" + txtMaCN.Text.Trim() + ";" + dteNgayTao.DateTime.ToString();
                        soTK = ((DataRowView)bdsTK[bdsTK.Position])["SOTK"].ToString();
                        bdsTK.RemoveCurrent();
                        this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.taiKhoanTableAdapter.Update(this.dS.TaiKhoan);
                        myStack.Push(task);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa Tài khoản. Vui lòng thử lại.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                        this.taiKhoanTableAdapter.Fill(this.dS.TaiKhoan);
                        bdsTK.Position = bdsTK.Find("SOTK", soTK);
                        return;
                    }
                }
            }
            if (bdsTK.Count == 0) btnXoa.Enabled = false;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string str = myStack.Pop().ToString();
            Console.WriteLine(str);
            string[] strItem = str.Split(';');
            if (strItem[0] == "delete")
            {
                if (MessageBox.Show("Bạn có muốn khôi phục thông tin tài khoản \"" + strItem[1] + "\" không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bdsTK.AddNew();
                    txtSTK.Text = strItem[1];
                    txtCMND.Text = strItem[2];
                    txtSoDu.Text = strItem[3];
                    txtMaCN.Text = strItem[4];
                    dteNgayTao.Text = strItem[5];
                    bdsTK.EndEdit();
                    bdsTK.ResetCurrentItem();
                    try
                    {
                        this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.taiKhoanTableAdapter.Update(this.dS.TaiKhoan);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi thêm tài khoản vào cơ sở dữ liệu.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    myStack.Push(str);
                }

            }
            else if (strItem[0] == "add")
            {
                if (MessageBox.Show("Bạn có muốn xóa tài khoản \"" + strItem[1] + "\" khỏi cơ sở dữ liệu không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bdsTK.Position = bdsTK.Find("SOTK", strItem[1]);
                    bdsTK.RemoveCurrent();
                    try
                    {
                        this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.taiKhoanTableAdapter.Update(this.dS.TaiKhoan);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xóa tài khoản.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    myStack.Push(str);
                }
            }
            if (myStack.Count == 0)
            {
                btnPhucHoi.Enabled = false;
            }
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

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtSTK.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tài khoản", "Thông báo", MessageBoxButtons.OK);
                txtSTK.Focus();
                return;
            }
            if (txtCMND.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số chứng minh nhân dân.", "Thông báo", MessageBoxButtons.OK);
                txtCMND.Focus();
                return;
            }
            if(txtSoDu.Text.Trim() == "")
            {
                txtSoDu.Text = "0";
            }

            try
            {
                Program.myReader = Program.ExecSqlDataReader("select * from LINK2.NGANHANG.DBO.KhachHang WHERE CMND = " + txtCMND.Text.Trim());
                Program.myReader.Read();
                if (!Program.myReader.HasRows)
                {
                    MessageBox.Show("Số CMND của khách hàng không tồn tại trong hệ thống.\nVui lòng tạo thông tin khách hàng trước khi tạo tài khoản", "Thông báo", MessageBoxButtons.OK);
                    Program.myReader.Close();
                    txtCMND.Focus();
                    return;
                }else
                {
                    Program.myReader.Close();
                    /*Program.myReader = Program.ExecSqlDataReader("SELECT * FROM TaiKhoan WHERE SOTK = " + txtSTK.Text.Trim());
                    Program.myReader.Read();
                    if (Program.myReader.HasRows)
                    {
                        MessageBox.Show("Số tài khoản đã tồn tại trong hệ thống.", "Thông báo", MessageBoxButtons.OK);
                        Program.myReader.Close();
                        txtSTK.Focus();
                        return;
                    }*/
/*                    else
                    {*/
                        task += txtSTK.Text.Trim();
                        Program.myReader.Close();
                        bdsTK.EndEdit();
                        bdsTK.ResetCurrentItem(); //Đưa các thông tin vừa điền lên lưới
                        this.taiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
                        this.taiKhoanTableAdapter.Update(this.dS.TaiKhoan);

                        pnlNhapLieu.Enabled = false;
                        gcTaiKhoan.Enabled = true;
                        btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnDong.Enabled = btnPhucHoi.Enabled = btnLamMoi.Enabled = true;
                        btnHuyTT.Enabled = btnGhi.Enabled = false;
                        myStack.Push(task);
/*                    }*/
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Tạo tài khoản ngân hàng không thành công." + ex.Message, "Thông báo", MessageBoxButtons.OK);
                return;
            }
            
        }
        
        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnHuyTT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsTK.CancelEdit();
            if (btnThem.Enabled == false)
            {
                bdsTK.Position = vitri;
            }
            gcTaiKhoan.Enabled = true;
            pnlNhapLieu.Enabled = false;
            btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnLamMoi.Enabled = btnDong.Enabled = btnPhucHoi.Enabled = true;
            btnHuyTT.Enabled = btnGhi.Enabled = false;
            task = "";
        }


        private void btnCheck_Click_1(object sender, EventArgs e)
        {
            if(txtCMND.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số CMND trước khi kiểm tra.", "Thông báo", MessageBoxButtons.OK);
                txtCMND.Focus();
                return;
            }else
            {
                Program.myReader = Program.ExecSqlDataReader("SELECT * FROM LINK0.NGANHANG.DBO.KhachHang WHERE CMND = " + txtCMND.Text.Trim());
                Program.myReader.Read();
                if (!Program.myReader.HasRows)
                {
                    MessageBox.Show("Số CMND không tồn tại trong hệ thống.", "Thông báo", MessageBoxButtons.OK);
                    txtCMND.Focus();
                    Program.myReader.Close();
                    return;
                }else
                {
                    MessageBox.Show("Số CMND hợp lệ!!", "Thông báo", MessageBoxButtons.OK);
                    Console.WriteLine("CMND hợp lệ");
                    Program.myReader.Close();
                }
            }
        }
    }
}
