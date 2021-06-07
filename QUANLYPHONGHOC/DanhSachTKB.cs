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
    public partial class DanhSachTKB : Form
    {
        LopDungChung dungchung = new LopDungChung();
        public DanhSachTKB()
        {
            InitializeComponent();
        }

        public void LoadDanhSach()
        {
            string sql = "Select * from ThoiKhoaBieu";
            DataTable dt = dungchung.LayBang(sql);
            dataGridView1.DataSource = dt;
        }

        public void LayDanhMucLH()
        {
            string sql = "Select * from LopHoc";
            DataTable dt = dungchung.LayBang(sql);
            cbb_TenLH.DataSource = dt;
            cbb_TenLH.DisplayMember = "TenLH";
            cbb_TenLH.ValueMember = "MaLH";
        }
        public void LayDanhMucMH()
        {
            string sql = "Select * from MonHoc";
            DataTable dt = dungchung.LayBang(sql);
            cbb_TenMH.DataSource = dt;
            cbb_TenMH.DisplayMember = "TenMH";
            cbb_TenMH.ValueMember = "MaMH";
        }
        public void LayDanhMucPH()
        {
            string sql = "Select * from PhongHoc";
            DataTable dt = dungchung.LayBang(sql);
            cbb_TenPH.DataSource = dt;
            cbb_TenPH.DisplayMember = "TenPH";
            cbb_TenPH.ValueMember = "MaPH";
        }

        public void LayDanhMucXH()
        {
            string sql = "Select * from XuatHoc";
            DataTable dt = dungchung.LayBang(sql);
            cbb_TenXH.DataSource = dt;
            cbb_TenXH.DisplayMember = "TenXH";
            cbb_TenXH.ValueMember = "MaXH";
        }

        private void DanhSachTKB_Load(object sender, EventArgs e)
        {
            LoadDanhSach();
            LayDanhMucLH();
            LayDanhMucMH();
            LayDanhMucPH();
            LayDanhMucXH();
        }

        private void Cbb_TenMH_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("BẠN CÓ CHẮC MUỐN THOÁT KHÔNG", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                frm_DangNhap dn = new frm_DangNhap();
                dn.Show();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cbb_TenLH.Text = dataGridView1.CurrentRow.Cells["MaLH"].Value.ToString();
            cbb_TenMH.Text = dataGridView1.CurrentRow.Cells["MaMH"].Value.ToString();
            cbb_TenPH.Text = dataGridView1.CurrentRow.Cells["MaPH"].Value.ToString();
            cbb_TenXH.Text = dataGridView1.CurrentRow.Cells["MaXH"].Value.ToString();
        }
    }
}
