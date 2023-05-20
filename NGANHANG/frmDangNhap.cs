using DevExpress.ChartRangeControlClient.Core;
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
    public partial class frmDangNhap : Form
    {
        private SqlConnection conn_publisher = new SqlConnection();
        private int option = 0;
        public frmDangNhap()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void layDSPM(String query1, String query2)
        {
            DataTable data = new DataTable();
            if(conn_publisher.State == ConnectionState.Closed) conn_publisher.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query1, conn_publisher); // tạo ra một adapter kết nối tới csdl với query thông qua conn_publisher
            dataAdapter.Fill(data);// đổ data lấy được vào datatable tương ứng với các row và các column có tên tương ứng trong csdl
            conn_publisher.Close();
            Program.bds_dspm.DataSource = data;
            DataTable data1 = new DataTable();
            if (conn_publisher.State == ConnectionState.Closed) conn_publisher.Open();
            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(query2, conn_publisher); // tạo ra một adapter kết nối tới csdl với query thông qua conn_publisher
            dataAdapter1.Fill(data1);// đổ data lấy được vào datatable tương ứng với các row và các column có tên tương ứng trong csdl
            conn_publisher.Close();
            Program.bds_pmtc.DataSource = data1;
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN"; cmbChiNhanh.ValueMember= "TENSERVER";

        }
        
        private int KetNoi_CSDLGoc()
        {
            if(conn_publisher != null && conn_publisher.State == ConnectionState.Open)
                conn_publisher.Close();
            try
            {
                conn_publisher.ConnectionString = Program.connstr_publisher;
                conn_publisher.Open();
                Console.WriteLine(Program.connstr_publisher);
                return 1;
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu gốc.\nVui lòng xem lại tên server Publisher và tên cơ sở dữ liệu trong server!");
                return 0;
            }
        }

        

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = cmbChiNhanh.SelectedValue.ToString();
            }
            catch(Exception ex)
            {

            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Program.frmChinh.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(txtTenDN.Text.Trim()=="" || txtMatKhau.Text.Trim() == "")
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!","", MessageBoxButtons.OK);
                return ;
            }

            //Kết nối về sever tương ứng
            Program.mlogin = txtTenDN.Text;
            Program.password = txtMatKhau.Text;
            if(Program.KetNoi()==0) return ; //Thử kết nối, nếu k log dc thì return

            //Kết nối thành công thì gán cho DN
            Program.mChiNhanh = cmbChiNhanh.SelectedIndex;
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;
            String strLenh = "";
            if(option == 0)
            {
                strLenh = "EXEC SP_Lay_Thong_Tin_NV_Tu_Login '" + Program.mlogin + "'";
            }else
            {
                strLenh = "EXEC SP_Lay_Thong_Tin_KH_Tu_Login '" + Program.mlogin + "'";
            }
            

            Program.myReader = Program.ExecSqlDataReader(strLenh); ;
            if (Program.myReader == null) return;

            Program.myReader.Read();

            Program.username = Program.myReader.GetString(0);
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Tài khoản bạn nhập không có quyền truy cập dữ liệu.\nVui lòng xem lại username và password.", "", MessageBoxButtons.OK);
                return ;
            }
            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();

            Program.frmChinh.MANV.Text = "MÃ NV: " + Program.username;
            Program.frmChinh.HOTEN.Text = "HỌ TÊN: " + Program.mHoten;
            Program.frmChinh.NHOM.Text = "NHÓM: " + Program.mGroup;
            DataTable data2 = new DataTable();
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT MACN, TENCN FROM LINK2.NGANHANG.DBO.ChiNhanh WHERE MACN NOT IN(SELECT MACN FROM ChiNhanh)", Program.conn); // tạo ra một adapter kết nối tới csdl với query thông qua conn_publisher
            dataAdapter.Fill(data2);// đổ data lấy được vào datatable tương ứng với các row và các column có tên tương ứng trong csdl
            conn_publisher.Close();

            Program.bds_dspm_cct.DataSource = data2;
            Console.WriteLine(((DataRowView)Program.bds_dspm_cct.Current).Row[1].ToString());
            Close();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            if (KetNoi_CSDLGoc() == 0) return;
            layDSPM("SELECT * FROM Get_Subscribes", "SELECT * FROM Get_Subscribes_TC");
            cmbChiNhanh.SelectedIndex = 1; cmbChiNhanh.SelectedIndex = 0;
            robNV.Checked = true;
        }

        private void robKH_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio.Checked)
            {
                if (radio.Text.Trim() == "Khách hàng")
                {
                    option = 1;
                    pnlChiNhanh.Visible = false;
                    Program.servername = ((DataRowView)Program.bds_pmtc.Current).Row[1].ToString();
                    Console.WriteLine("Server: " + ((DataRowView)Program.bds_pmtc.Current).Row[1].ToString());
                }
                else
                {
                    option = 0;
                    pnlChiNhanh.Visible = true;
                    cmbChiNhanh.SelectedIndex = 1;
                    cmbChiNhanh.SelectedIndex = 0;

                }
            }
            Console.WriteLine(Program.servername);
        }
    }
}
