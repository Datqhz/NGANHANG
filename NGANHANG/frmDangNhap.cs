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
        public frmDangNhap()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void layDSPM(String query)
        {
            DataTable data = new DataTable();
            if(conn_publisher.State == ConnectionState.Closed) conn_publisher.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn_publisher); // tạo ra một adapter kết nối tới csdl với query thông qua conn_publisher
            dataAdapter.Fill(data);// đổ data lấy được vào datatable tương ứng với các row và các column có tên tương ứng trong csdl
            conn_publisher.Close();
            Program.bds_dspm.DataSource = data;
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
            String strLenh = "EXEC SP_Lay_Thong_Tin_NV_Tu_Login '" + Program.mlogin + "'";

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
            Close();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            if (KetNoi_CSDLGoc() == 0) return;
            layDSPM("SELECT * FROM Get_Subscribes");
            cmbChiNhanh.SelectedIndex = 1; cmbChiNhanh.SelectedIndex = 0;
        }
    }
}
