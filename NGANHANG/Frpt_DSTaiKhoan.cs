using DevExpress.XtraReports.UI;
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
    public partial class Frpt_DSTaiKhoan : Form
    {
        private string title = "";
        public Frpt_DSTaiKhoan()
        {
            InitializeComponent();

            Program.mlogin = Program.remotelogin;
            Program.password = Program.remotepassword;
            
        }

        private void robAll_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                if (radio.Text.Trim() == "Tất cả chi nhánh")
                {
                    title = "TẤT CẢ CHI NHÁNH";
                    pnlCN.Visible = false;
                    Program.servername = ((DataRowView)Program.bds_pmtc.Current).Row[1].ToString();
                    if(Program.KetNoi() == 1)
                    {
                        return;
                    }
                    Console.WriteLine("all ");
                }
                else
                {
                    Console.WriteLine("one");
                    pnlCN.Visible = true;
                    cmbChiNhanh.SelectedIndex = 1;
                    cmbChiNhanh.SelectedIndex = 0;

                }
            }
            Console.WriteLine(Program.servername);
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                title = ((DataRowView)Program.bds_dspm[cmbChiNhanh.SelectedIndex]).Row[0].ToString();
                
                Program.servername = cmbChiNhanh.SelectedValue.ToString();
                Console.WriteLine("Tên server dstk: " + Program.servername);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnWatch_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Program.servername);
            if (dteFromDate.Text.Trim() == "" || dteToDate.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn khoảng thời gian cần xem!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else if (dteFromDate.DateTime > DateTime.Today || dteToDate.DateTime > DateTime.Today)
            {
                MessageBox.Show("Ngày bắt đầu và ngày kết thúc không được quá ngày hiện tại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else
            {
                try
                {
                    if(Program.KetNoi() == 0)
                    {
                        return;
                    }
                }catch(Exception ex)
                {

                }
                XtraReport_DSTaiKhoan rpt = new XtraReport_DSTaiKhoan(dteFromDate.Text, dteToDate.Text);
                rpt.lblTitle.Text = "DANH SÁCH TÀI KHOẢN ĐÃ MỞ TỪ NGÀY " + dteFromDate.Text + " ĐẾN NGÀY " + dteToDate.Text + "\n TẠI " + title;
                ReportPrintTool print = new ReportPrintTool(rpt);
                print.ShowPreviewDialog();
            }                                  
        }

        private void Frpt_DSTaiKhoan_Load(object sender, EventArgs e)
        {
            Program.mlogin = Program.remotelogin;
            Program.password = Program.remotepassword;
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
/*            cmbChiNhanh.SelectedIndex = 1;
            cmbChiNhanh.SelectedIndex = 0;*/
            pnlCN.Visible = false;
        }
    }
}
