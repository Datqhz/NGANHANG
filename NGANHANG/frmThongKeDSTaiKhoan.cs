using DevExpress.XtraEditors.ViewInfo;
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
    public partial class frmThongKeDSTaiKhoan : Form
    {
        public frmThongKeDSTaiKhoan()
        {
            InitializeComponent();
        }

        private void robAll_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if(radio.Checked )
            {
                if(radio.Text.Trim() == "Tất cả")
                {
                    pnlChiNhanh.Visible = false;
                }else
                {
                    pnlChiNhanh.Visible = true;
                }
            }
        }

        private void frmThongKeDSTaiKhoan_Load(object sender, EventArgs e)
        {
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChiNhanh;
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
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string str = "số tài khoản;số dư;mã;chi nhánh";
            string[] strList = str.Split(';');
            dgvDS.Rows.Add(strList);
            
        }
    }
}
