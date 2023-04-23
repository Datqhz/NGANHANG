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
    public partial class frmChuyenGuiRut : Form
    {
        private double sodu = 0;
        public frmChuyenGuiRut()
        {
            InitializeComponent();
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (txtTKGoc.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tài khoản thực hiện giao dịch.", "Thông báo", MessageBoxButtons.OK);
                return;
            }else if(txtSTKNhan.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tài khoản nhận!", "Thông báo", MessageBoxButtons.OK);
                return;
            }else if (Double.Parse(txtSoTienChuyen.Text.Trim()) < 0)
            {
                MessageBox.Show("Số tiền chuyển phải lớn hơn 0!\nVui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            //check stk chuyen
            Program.myReader = Program.ExecSqlDataReader("SELECT SODU FROM TaiKhoan WHERE SOTK = '" + txtTKGoc.Text.Trim() + "'");
            Program.myReader.Read();
            if (!Program.myReader.HasRows)
            {
                MessageBox.Show("Số tài khoản thực hiện không tồn tại", "Thông báo", MessageBoxButtons.OK);
                Program.myReader.Close();
                return;
            }
            else
            {
                sodu = Program.myReader.GetSqlMoney(0).ToDouble();
                Program.myReader.Close();
            }
            
            //Check stk nhan
            Program.myReader = Program.ExecSqlDataReader("SELECT * FROM TaiKhoan WHERE SOTK = '" + txtSTKNhan.Text.Trim() + "'");
            Program.myReader.Read();
            if (!Program.myReader.HasRows)
            {
                MessageBox.Show("Số tài khoản nhận không tồn tại trong hệ thống.\nVui lòng nhập lại!!", "Thông báo", MessageBoxButtons.OK);
                Program.myReader.Close();
                return;
            }else
            {
                Program.myReader.Close();
                if (sodu < Double.Parse(txtSoTienChuyen.Text))
                {
                    MessageBox.Show("Số dư không đủ để thực hiện giao dịch!!\nVui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                try
                {
                    Console.WriteLine("EXEC SP_CHUYENTIEN '" + txtTKGoc + "', '" + txtSTKNhan + "', " + txtSoTienChuyen + ",'" + Program.username + "'");
                    Program.ExecSqlNonQuery("EXEC SP_CHUYENTIEN '" + txtTKGoc.Text.Trim() + "', '" + txtSTKNhan.Text.Trim() + "', " + txtSoTienChuyen.Text.Trim() + ",'" + Program.username+"'");
                    //MessageBox.Show("Thực hiện giao dịch thành công!!", "Thông báo", MessageBoxButtons.OK);
                    txtSoTienChuyen.Text = "";
                    txtSTKNhan.Text = "";
                    btnSoDu.PerformClick();
                }catch(Exception ex)
                {
                    MessageBox.Show("Lỗi trong quá trình thực hiện giao dịch! Vui lòng thử lại.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                
            }
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            //Chưa nhập tk thực hiện giao dịch
            if (txtTKGoc.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tài khoản thực hiện giao dịch.", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            //Kiểm tra sự tồn tại của tài khoản
            Program.myReader = Program.ExecSqlDataReader("SELECT SODU FROM TaiKhoan WHERE SOTK = '" + txtTKGoc.Text.Trim() + "'");
            Program.myReader.Read();
            if (!Program.myReader.HasRows)
            {
                MessageBox.Show("Số tài khoản thực hiện không tồn tại.", "Thông báo", MessageBoxButtons.OK);
                Program.myReader.Close();
                return;
            }
            else
            {
                Program.myReader.Close();
            }
            if (Double.Parse(txtSotienGui_Rut.Text.Trim()) < 100000)
            {
                MessageBox.Show("Số tiền giao dịch tối thiểu là 100.000!\nVui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK);
                
                return;
            }else
            {
                try
                {
                    Program.ExecSqlNonQuery("EXEC SP_GUITIEN '" + txtTKGoc.Text.Trim() + "', " + txtSotienGui_Rut.Text.Trim()+", '"+Program.username+"'");
                    //MessageBox.Show("Thực hiện giao dịch thành công!", "Thông báo", MessageBoxButtons.OK);
                    txtSotienGui_Rut.Text = "";
                    btnSoDu.PerformClick();
                }
                catch( Exception ex )
                {
                    MessageBox.Show("Phát sinh lỗi trong quá trình thực hiện. Vui lòng thử lại.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    return;
                }
            }

        }

        private void btnRut_Click(object sender, EventArgs e)
        {
            //Chưa nhập tk thực hiện giao dịch
            if (txtTKGoc.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tài khoản thực hiện giao dịch.", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            //Kiểm tra sự tồn tại của tài khoản
            Program.myReader = Program.ExecSqlDataReader("SELECT SODU FROM TaiKhoan WHERE SOTK = '" + txtTKGoc.Text.Trim() + "'");
            Program.myReader.Read();
            if (!Program.myReader.HasRows)
            {
                MessageBox.Show("Số tài khoản thực hiện không tồn tại.", "Thông báo", MessageBoxButtons.OK);
                Program.myReader.Close();
                return;
            }
            else
            {
                // Lấy số dư của tài khoản để kiểm tra số dư khi giao dịch
                sodu = Program.myReader.GetSqlMoney(0).ToDouble();
                Program.myReader.Close();
            }
            if (Double.Parse(txtSotienGui_Rut.Text.Trim()) < 100000)
            {
                MessageBox.Show("Số tiền giao dịch tối thiểu là 100.000!\nVui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK);
                return;
            }else if(Double.Parse(txtSotienGui_Rut.Text.Trim()) > sodu)
            {
                MessageBox.Show("Số dư hiện tại không đủ để thực hiện giao dịch.\nVui lòng nhập vào số tiền nhỏ hơn!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            else
            {
                try
                {
                    Program.ExecSqlNonQuery("EXEC SP_RUTTIEN '" + txtTKGoc.Text.Trim() + "', " + txtSotienGui_Rut.Text.Trim() + ", '" + Program.username + "'");
                    //MessageBox.Show("Thực hiện giao dịch thành công!", "Thông báo", MessageBoxButtons.OK);
                    txtSotienGui_Rut.Text = "";
                    btnSoDu.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Phát sinh lỗi trong quá trình thực hiện. Vui lòng thử lại.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    return;
                }
            }

        }

        private void btnSoDu_Click(object sender, EventArgs e)
        {
            if (txtTKGoc.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập số tài khoản trước khi kiểm tra", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            Program.myReader = Program.ExecSqlDataReader("SELECT SODU FROM TaiKhoan WHERE SOTK = '" + txtTKGoc.Text.Trim() + "'");
            Program.myReader.Read();
            if (!Program.myReader.HasRows)
            {
                MessageBox.Show("Số tài khoản bạn nhập không tồn tại", "Thông báo", MessageBoxButtons.OK);
                Program.myReader.Close();
                return;
            }else
            {
                txtSoDu.Text = Program.myReader.GetSqlMoney(0).ToString();
                Program.myReader.Close();
            }
        }
    }
}
;