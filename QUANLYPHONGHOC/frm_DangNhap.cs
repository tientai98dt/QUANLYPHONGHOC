using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QUANLYPHONGHOC
{
    public partial class frm_DangNhap : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Tien Tai\Documents\HocLapTrinhC#\QUANLYPHONGHOC\QUANLYPHONGHOC\DataBase\QuanLy.mdf;Integrated Security=True");
        int solan = 0;
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void Frm_DangNhap_Load(object sender, EventArgs e)
        {
            DialogResult dg =  MessageBox.Show("Chào Bạn ! Bạn Có Phải Là Nhà Quản Lý", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.No)
            {
                panel2.Enabled = false;
            }
            
         }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("BẠN CÓ CHẮC MUỐN THOÁT KHÔNG", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
            
         }
        private void Btn_DangNhap_Click(object sender, EventArgs e)
        {
            string sql = "Select * from TaiKhoan where TenDangNhap = '" + txt_TenDangNhap.Text + "' AND MatKhau = '" + txt_MatKhau.Text + "'";
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.Read() == true)
            {
                frm_TrangChu frm = new frm_TrangChu();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bạn Đã Nhập Sai Tên Đăng Nhập Hoặc Mật Khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txt_TenDangNhap.Focus();
                solan++;
                if (solan >= 3)
                {
                    MessageBox.Show("Bạn Đã Nhập Sai Quá 3 Lần", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
            }
            conn.Close();
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Btn_XemTKB_Click(object sender, EventArgs e)
        {
            DanhSachTKB ds = new DanhSachTKB();
            this.Hide();
            ds.ShowDialog();

        }

        private void Btn_DangKiTK_Click(object sender, EventArgs e)
        {
            frm_DangKiTaiKhoan frm = new frm_DangKiTaiKhoan();
            this.Hide();
            frm.Show();
        }
    }
}
