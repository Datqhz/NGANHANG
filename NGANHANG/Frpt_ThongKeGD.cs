using DevExpress.XtraReports.UI;
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
    public partial class Frpt_ThongKeGD : Form
    {
        public Frpt_ThongKeGD()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if(txtSTK.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tài khoản cần xem!", "Thông báo", MessageBoxButtons.OK);
                return;
            }else
            {
                Program.myReader = Program.ExecSqlDataReader("EXEC [dbo].[find_TK_by_STK] '" + txtSTK.Text.Trim() + "'");
                Program.myReader.Read();
                if (!Program.myReader.HasRows)
                {
                    MessageBox.Show("Số tài khoản \"" + txtSTK.Text.Trim() + "\" không tồn tại trong hệ thống.\nVui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK);
                    Program.myReader.Close();
                    return;
                }else
                {
                    MessageBox.Show("Số tài khoản \"" + txtSTK.Text.Trim() + "\" hợp lệ.", "Thông báo", MessageBoxButtons.OK);
                    Program.myReader.Close();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSTK.Text = "";
            dteFromDate.Text = "";
            dteToDate.Text = "";
        }

        private void btnWatch_Click(object sender, EventArgs e)
        {
            if (txtSTK.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tài khoản cần xem!", "Thông báo", MessageBoxButtons.OK);
                return;
            }else if(dteFromDate.Text == "" || dteToDate.Text == "")
            {
                MessageBox.Show("Vui lòng chọn khoảng thời gian cần xem!", "Thông báo", MessageBoxButtons.OK);
                return;
            }else if(dteFromDate.DateTime > DateTime.Today || dteToDate.DateTime > DateTime.Today)
            {
                MessageBox.Show("Ngày bắt đầu và ngày kết thúc không được quá ngày hiện tại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else
            {
                Program.myReader = Program.ExecSqlDataReader("EXEC [dbo].[find_TK_by_STK] '" + txtSTK.Text.Trim() + "'");
                Program.myReader.Read();
                if (!Program.myReader.HasRows)
                {
                    MessageBox.Show("Số tài khoản \"" + txtSTK.Text.Trim() + "\" không tồn tại trong hệ thống.\nVui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK);
                    Program.myReader.Close();
                    return;
                }
                else
                {
                    Program.myReader.Close();
                    Console.WriteLine(Program.connstr);
                    XtraReport_ThongKeGD rpt = new XtraReport_ThongKeGD(txtSTK.Text.Trim(), dteFromDate.Text, dteToDate.Text);
                    rpt.lblTitle.Text = "LỊCH SỬ GIAO DỊCH CỦA TÀI KHOẢN " + txtSTK.Text.Trim() + "\nTỪ NGÀY " + dteFromDate.Text + " ĐẾN NGÀY " + dteToDate.Text;
                    ReportPrintTool print = new ReportPrintTool(rpt);
                    print.ShowPreviewDialog();


                }
            }
        }
    }
}
