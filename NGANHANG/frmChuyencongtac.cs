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
    public partial class frmChuyencongtac : Form
    {
        private string MANVCU = "";
        public void set_MANVCU(string str)
        {
            this.MANVCU = str;
        }
        public frmChuyencongtac()
        {
            InitializeComponent();
        }

        private void chiNhanhBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.chiNhanhBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void frmChuyencongtac_Load(object sender, EventArgs e)
        {
           
            cmbCN.DataSource = Program.bds_dspm_cct;
            cmbCN.DisplayMember = "TENCN";
            cmbCN.ValueMember = "MACN";
            //cmbCN.SelectedIndex = Program.mChiNhanh;


        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
           if(txtMaNVM.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên mới không được để trống", "Thông báo", MessageBoxButtons.OK);
                txtMaNVM.Focus();
                return;
            }else if(txtMK.Text.Trim() == "")
            {
                MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK);
                txtMK.Focus();
                return;
            }

           Program.myReader = Program.ExecSqlDataReader("Select * from LINK2.NGANHANG.DBO.NHANVIEN WHERE MANV = \'" + txtMaNVM.Text.Trim()+"\'");
            Program.myReader.Read();
            if (Program.myReader.HasRows)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại\nVui lòng nhập mã nhân viên khác.", "Thông báo", MessageBoxButtons.OK);
                Program.myReader.Close();
                return;
            }
            else
            {
                Program.myReader.Close();

            }
            if (MessageBox.Show("Bạn muốn chuyển nhân viên " + MANVCU.Trim() + " sang chi nhánh " + cmbCN.Text.Trim() + "??", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                try
                {
                    Program.myReader = Program.ExecSqlDataReader("SELECT SUSER_SNAME(sid),uid FROM sys.sysusers WHERE name = \'"+ MANVCU+"\'");
                    Program.myReader.Read();
                    String lgin = Program.myReader.GetString(0);
                    Console.WriteLine("1, login : " + Program.myReader.GetString(0));
                    Console.WriteLine("test, uid : " + Convert.ToInt32(Program.myReader["uid"]));
                    int uid = Convert.ToInt32(Program.myReader["uid"]);
                    Console.WriteLine("2");
                    Program.myReader.Close();
                    Program.myReader = Program.ExecSqlDataReader("SELECT NAME FROM sys.sysusers WHERE uid =(SELECT groupuid from sys.sysmembers WHERE memberuid = "+uid+")");
                    Program.myReader.Read();
                    String role = Program.myReader.GetString(0);
                    Console.WriteLine("3");
                    Program.myReader.Close();
                    Console.WriteLine(cmbCN.SelectedValue.ToString());
                    Program.mlogin = Program.remotelogin;
                    Program.password = Program.remotepassword;
                    Program.KetNoi();
                    Program.ExecSqlNonQuery("EXEC SP_CHUYENCONGTAC_SONGSONG \'" + MANVCU + "\', \'" + txtMaNVM.Text.Trim() + "\', \'" + cmbCN.SelectedValue.ToString() + "\'");
                    
                    Console.WriteLine("4");
                    Program.ExecSqlNonQuery("EXEC LINK1.NGANHANG.DBO.SP_TAOLOGIN \'"+lgin+"\',\'"+ txtMK.Text.Trim()+"\',\'"+ txtMaNVM.Text.Trim() + "\',\'"+role+"\' ");
                    Console.WriteLine("5");
                    //MessageBox.Show("Chuyển nhân viên thành công!", "Thông báo", MessageBoxButtons.OK);
                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Phát sinh lỗi trong quá trình thực hiện. Vui lòng thử lại.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK);
                    Program.myReader.Close();
                    return;
                    
                }
            }
            
        }
        private void cmbCN_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }
    }
}
