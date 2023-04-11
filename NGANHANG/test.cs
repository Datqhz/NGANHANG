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
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            hideAllSub();
            //this.tabbed.PageAdded(new Panel());
        }

        public void hideAllSub()
        {
            panelNghiepVuSubmenu.Visible = panelDanhMucSubmenu.Visible = panelBaoCaoSubmenu.Visible = false;
        }
        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            if(panelDanhMucSubmenu.Visible == true)
            {
                panelDanhMucSubmenu.Visible = false;
            }
            else
            {
                hideAllSub();
                panelDanhMucSubmenu.Visible = true;
            }
            
        }

        private void btnNghiepVu_Click(object sender, EventArgs e)
        {
            if (panelNghiepVuSubmenu.Visible == true)
            {
                panelNghiepVuSubmenu.Visible = false;
            }
            else
            {
                hideAllSub();
                panelNghiepVuSubmenu.Visible = true;
            }
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (panelBaoCaoSubmenu.Visible == true)
            {
                panelBaoCaoSubmenu.Visible = false;
            }
            else
            {
                hideAllSub();
                panelBaoCaoSubmenu.Visible = true;
            }
        }
    }
}
