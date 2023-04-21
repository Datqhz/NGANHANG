using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraBars.Docking2010.Views.BaseRegistrator;
using System.Xml.Linq;

namespace NGANHANG
{
    public partial class frmTaoLogin : Form
    {
        public frmTaoLogin()
        {
            InitializeComponent();
        }

        private void frmTaoLogin_Load(object sender, EventArgs e)
        {
            this.NV_Chua_Co_LoginTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS.DSNV_CHUA_CO_TK_LOGIN' table. You can move, or remove it, as needed.
            this.NV_Chua_Co_LoginTableAdapter.Fill(this.dS.DSNV_CHUA_CO_TK_LOGIN);
            // TODO: This line of code loads data into the 'dS.DSNV_CHUA_CO_TK_LOGIN' table. You can move, or remove it, as needed.
            this.NV_Chua_Co_LoginTableAdapter.Fill(this.dS.DSNV_CHUA_CO_TK_LOGIN);
            // TODO: This line of code loads data into the 'dS.DSNV_CHUA_CO_TK_LOGIN' table. You can move, or remove it, as needed.
            this.NV_Chua_Co_LoginTableAdapter.Fill(this.dS.DSNV_CHUA_CO_TK_LOGIN);
            grbTTDN.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grbTTDN.Enabled = true;
            gcNV.Enabled = false;
            btnTao.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtTenDN.Text = "";
            txtMatKhau.Text = "";
            grbTTDN.Enabled = false;
            gcNV.Enabled = true;
            btnTao.Enabled = true;
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            if (txtTenDN.Text.Trim() == "")
            {
                MessageBox.Show("Tên tài khoản không được để trống", "Thông báo", MessageBoxButtons.OK);
                return;
            }else if(txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            try
            {
                string manv = ((DataRowView)bdsNVChua_co_login[bdsNVChua_co_login.Position])["MANV"].ToString();
                //Console.WriteLine("exec [dbo].[SP_TAOLOGIN] '" + txtTenDN.Text.Trim() + "', '" + txtMatKhau.Text.Trim() + "', '" + manv.Trim() + "', '" + Program.mGroup + "'");
                Program.ExecSqlDataReader("exec [dbo].[SP_TAOLOGIN] '" + txtTenDN.Text.Trim() + "', '" + txtMatKhau.Text.Trim() + "', '" + manv.Trim() + "', '" + Program.mGroup + "'");
                MessageBox.Show("Tạo login cho nhân viên có mã \"" + manv + "\" thành công!!", "Thông báo", MessageBoxButtons.OK);
                txtTenDN.Text = "";
                txtMatKhau.Text = "";
                grbTTDN.Enabled = false;
                gcNV.Enabled = true;
                btnTao.Enabled = true;
                this.NV_Chua_Co_LoginTableAdapter.Fill(this.dS.DSNV_CHUA_CO_TK_LOGIN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tạo tài khoản.\n" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            
            
        }
    }
}
