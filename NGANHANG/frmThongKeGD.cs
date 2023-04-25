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
    public partial class frmThongKeGD : Form
    {
        private double sodu;
        public frmThongKeGD()
        {
            InitializeComponent();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if(txtSoTK.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tài khoản cần xem.", "Thông báo", MessageBoxButtons.OK);
                return;
            }else if(dteTuNgay.Text == "" || dteDenNgay.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ khoảng thời gian cần xem.", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else
            {
                Program.myReader = Program.ExecSqlDataReader("EXEC find_TK_by_STK '" + txtSoTK.Text.Trim() + "'");
                Program.myReader.Read();
                if (!Program.myReader.HasRows)
                {
                    MessageBox.Show("Số tài khoản bạn nhập không có trong hệ thống.\nVui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK);
                    Program.myReader.Close();
                    return;
                }else
                {
                    Program.myReader.Close();
                    try
                    {
                        Program.myReader = Program.ExecSqlDataReader("EXEC TINHSD '" + dteTuNgay.Text + "', '" + txtSoTK.Text.Trim() + "'");
                        Program.myReader.Read();
                        if (Program.myReader.HasRows)
                        {
                            sodu = Program.myReader.GetSqlMoney(0).ToDouble();
                            txtSDD.Text = sodu.ToString();
                            lblSDD.Text = dteTuNgay.Text;
                            Program.myReader.Close();
                        }else
                        {
                            MessageBox.Show("Lỗi không thể lấy số dư ban đầu.\n", "Thông báo", MessageBoxButtons.OK);
                            Program.myReader.Close();
                            return;
                        }

                        Program.myReader = Program.ExecSqlDataReader("EXEC SP_THONGKE_GD '" +txtSoTK.Text.Trim()  + "', '" + dteTuNgay.Text  + "', '"+ dteDenNgay.Text + "'");
                        while(Program.myReader.Read())
                        {
                            double temp = sodu;
                            if(Program.myReader.GetString(1) == "GT"|| Program.myReader.GetString(1) == "NT")
                            {
                                sodu = sodu + Program.myReader.GetSqlMoney(2).ToDouble();
                            }else
                            {
                                sodu = sodu - Program.myReader.GetSqlMoney(2).ToDouble();
                            }

                            this.dgvLSGD.Rows.Add(
                                temp,
                                Program.myReader.GetDateTime(0),
                                Program.myReader.GetString(1),
                                Program.myReader.GetSqlMoney(2).ToDouble(),
                               sodu);
                        }
                        txtSDC.Text = sodu.ToString();
                        lblSDC.Text = dteDenNgay.Text;
                        Program.myReader.Close();
                        dteTuNgay.Text = "";
                        dteDenNgay.Text = "";
                        txtSoTK.Text = "";
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Lỗi lấy lịch sử giao dịch của tài khoản.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    
                }
            }
        }
    }
}
