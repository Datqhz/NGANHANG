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

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult choice = MessageBox.Show("Bạn có thực sự muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(choice == DialogResult.Yes)
            {
                this.Hide();
                Program.frmDN.cmbChiNhanh.SelectedIndex = 0;
                Program.frmDN.txtTenDN.Text = "";
                Program.frmDN.txtMatKhau.Text = "";
                Program.frmDN.Show();
                
            }
        }
    }
}