using DevExpress.Charts.Native;
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
    public partial class frmLichSuGD : Form
    {
        private double sodu;
        public frmLichSuGD()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if(dteTuNgay.Text == "" || dteDenNgay.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ khoảng thời gian cần xem.", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else
            {
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader("EXEC SP_THONGKE_GD '" +cmbSTK.Text.Trim()  + "', '" + dteTuNgay.Text  + "', '"+ dteDenNgay.Text + "'");
                        while(Program.myReader.Read())
                        {                        
                            this.dgvLSGD.Rows.Add(
                                Program.myReader.GetSqlMoney(0).ToDouble(),
                                Program.myReader.GetDateTime(1),
                                Program.myReader.GetString(2),
                                Program.myReader.GetSqlMoney(3).ToDouble(),
                                Program.myReader.GetSqlMoney(4).ToDouble());
                        }
                        Program.myReader.Close();
                        if(dgvLSGD.RowCount>1)
                        {
                            
                            Console.WriteLine("bd: " );
                            lblSDD.Text = dteTuNgay.Text;
                            lblSDC.Text = dteDenNgay.Text;
                            dteTuNgay.Text = "";
                            dteDenNgay.Text = "";
                            txtSDD.Text = dgvLSGD.Rows[0].Cells[0].Value.ToString();                      
                            txtSDC.Text = dgvLSGD.Rows[dgvLSGD.RowCount - 2].Cells[4].Value.ToString();
                        }                      
                }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Lỗi lấy lịch sử giao dịch của tài khoản.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    
            }
        }

        private void frmThongKeGD_Load(object sender, EventArgs e)
        {
            Program.myReader = Program.ExecSqlDataReader("SELECT SOTK FROM TAIKHOAN WHERE CMND = \'" + Program.username + "\'");
            while (Program.myReader.Read())
            {
                if (!Program.myReader.HasRows)
                {
                    MessageBox.Show("Bạn chưa có bất kì tài khoản ngân hàng nào.", "Thông báo", MessageBoxButtons.OK);
                    Program.myReader.Close();
                    this.Close();
                }

                cmbSTK.Items.Add(Program.myReader.GetString(0).Trim());
            }
            cmbSTK.SelectedIndex = 0;
            Program.myReader.Close();
            
        }
    }
}
