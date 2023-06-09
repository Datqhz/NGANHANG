using DevExpress.Utils.Serializing;
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
    public partial class frmTTHTKhachHang : Form
    {
        public frmTTHTKhachHang()
        {
            InitializeComponent();
        }

        private void frmTTHTKhachHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.DSKH_CHUA_CO_TK_LOGIN' table. You can move, or remove it, as needed.
            this.TaiKhoanTableAdapter.Connection.ConnectionString = Program.connstr;
            this.TaiKhoanTableAdapter.Fill(this.dS.DSKH_CHUA_CO_TK_LOGIN);
            pncNhapLieu.Enabled = false;
            if(dbsChuaTK.Count == 0)
            {
                btnTao.Enabled = false;
            }
            pncNhapLieu.Enabled=false;
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            
            
            if(txtTenDN.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK);
                return;
            }else if(txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK);
                return;
            }else
            {
                Program.myReader = Program.ExecSqlDataReader("SELECT NAME FROM LINK2.NGANHANG.SYS.SYSLOGINS WHERE NAME = N'"+txtTenDN.Text.Trim()+"'");
                Program.myReader.Read();
                if (Program.myReader.HasRows)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại! Vui lòng ghi lại tên đăng nhập mới", "Thông báo", MessageBoxButtons.OK);
                    txtTenDN.Focus();
                    Program.myReader.Close();
                    return;
                }else
                {
                    Program.myReader.Close();
                    try
                    {
                        Program.ExecSqlNonQuery("EXEC LINK2.NGANHANG.DBO.SP_TAOLOGIN \'" + txtTenDN.Text.Trim() + "\', \'" + txtMatKhau.Text.Trim() + "\', \'" + ((DataRowView)dbsChuaTK[dbsChuaTK.Position])["CMND"].ToString() + "\', 'KHACHHANG'");
                        MessageBox.Show("Tạo tài khoản thành công!!", "Thông báo", MessageBoxButtons.OK);
                        this.TaiKhoanTableAdapter.Fill(this.dS.DSKH_CHUA_CO_TK_LOGIN);
                        pncNhapLieu.Enabled = false;
                        gcDSKH.Enabled = true;
                    }catch(Exception ex)
                    {
                        MessageBox.Show("Tạo tài khoản thất bại!!\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                }
                
            }
            if(dbsChuaTK.Count == 0)
            {
                btnTao.Enabled = false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            pncNhapLieu.Enabled = false;
            txtMatKhau.Text = "";
            txtTenDN.Text = "";
            btnTao.Enabled = true;
            gcDSKH.Enabled = true;
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            pncNhapLieu.Enabled = true;
            btnTao.Enabled = false;
            gcDSKH.Enabled = false;
        }
    }
}
