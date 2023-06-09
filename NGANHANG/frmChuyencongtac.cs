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
        private string CMND = "";
        private int temp = 0;
        
        public void set_CMND(string str)
        {
            this.CMND = str;
        }
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
            cmbCN.SelectedIndex = 0;

        }

        private void btnChuyen_Click(object sender, EventArgs e)
        { 
            if(temp == 1)
            {
                if(txtMaNVM.Text.Trim() == "")
                {
                    MessageBox.Show("Mã nhân viên mới không được để trống", "Thông báo", MessageBoxButtons.OK);
                    txtMaNVM.Focus();
                    return;
                }
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
                                       
                    Program.mlogin = Program.remotelogin;
                    Program.password = Program.remotepassword;
                    Program.KetNoi();
                    if(temp == 1)
                    {
                        Program.ExecSqlNonQuery("EXEC SP_CHUYENCONGTAC_SONGSONG \'" + MANVCU + "\', \'" + txtMaNVM.Text.Trim() + "\', \'" + cmbCN.SelectedValue.ToString() + "\'");
                    }else
                    {
                        Program.ExecSqlNonQuery("EXEC SP_CHUYENCONGTAC_SONGSONG \'" + MANVCU + "\', \'TEST\', \'" + cmbCN.SelectedValue.ToString() + "\'");
                    }
                    Close();
                                                         
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
            Program.myReader = Program.ExecSqlDataReader("SELECT * FROM LINK1.NGANHANG.DBO.NHANVIEN WHERE CMND = \'" + CMND + "\'");
            if(Program.myReader.HasRows)
            {
                pnlMNV.Visible = false;
                Program.myReader.Close();
                this.temp = 0;
            }else
            {
                pnlMNV.Visible = true;
                Program.myReader.Close();
                this.temp = 1;
            }
        }
    }
}
