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
    public partial class frm_DangKiTaiKhoan : Form
    {
        LopDungChung lopchung = new LopDungChung();
        public frm_DangKiTaiKhoan()
        {
            InitializeComponent();
        }

        private void Frm_DangKiTaiKhoan_Load(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Date_NgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Txt_DiaChiTT_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Thoat_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("BẠN CÓ CHẮC MUỐN THOÁT KHÔNG", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                frm_DangNhap dn = new frm_DangNhap();
                dn.Show();
            }
        }

        bool Login(string chuoi)
        {
            if (chuoi == null)
            {
                return false;
            }
            return true;
        }

        private void Btn_LuuTT_Click(object sender, EventArgs e)
        {
            if (Login(txt_TenDangNhap.Text) == false || Login(txt_MatKhau.Text)== false || Login(txt_NhapLaiMatKhau.Text) == false)
            {
                MessageBox.Show("BẠN VUI LÒNG ĐIỀN ĐẦY ĐỦ THÔNG TIN");
            }
            else
            {
                if (txt_NhapLaiMatKhau.Text != txt_MatKhau.Text)
                {
                    MessageBox.Show("MẬT KHẨU BẠN VỪA NHẬP KHÔNG TRÙNG KHỚP");
                }
                else
                {
                    string sql = "Insert into TaiKhoan values (N'" + txt_TenDangNhap.Text + "','" + txt_MatKhau.Text + "',N'" + txt_TenND.Text + "','" + date_NgaySinh.Text + "','" + txt_DiaChiTT.Text + "','" + txt_QueQuan.Text + "','" + txt_SDT.Text + "','" + txt_Email.Text + "')";
                    int ketqua = lopchung.ThemSuaXoa(sql);
                    if (ketqua >= 1)
                    {
                        MessageBox.Show("Bạn đã thêm tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã thêm tài khoản thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
