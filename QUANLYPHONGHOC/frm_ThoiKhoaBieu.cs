using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYPHONGHOC
{
    public partial class frm_ThoiKhoaBieu : Form
    {
        LopDungChung lopchung = new LopDungChung();
        public frm_ThoiKhoaBieu()
        {
            InitializeComponent();
        }

        private void Frm_ThoiKhoaBieu_Load(object sender, EventArgs e)
        {
                LoadTKB();
                LayDanhMucLH();
                LayDanhMucMH();
                LayDanhMucPH();
                LayDanhMucXH();
        }

        public void LoadTKB()
        {
            string sql = "Select * from ThoiKhoaBieu";
            DataTable dt = lopchung.LayBang(sql);
            dataGridView1.DataSource = dt;
        }



        public void LayDanhMucLH()
        {
            string sql = "Select * from LopHoc";
            DataTable dt = lopchung.LayBang(sql);
            cbb_TenLH.DataSource = dt;
            cbb_TenLH.DisplayMember = "TenLH";
            cbb_TenLH.ValueMember = "MaLH";
        }
        public void LayDanhMucMH()
        {
            string sql = "Select * from MonHoc";
            DataTable dt = lopchung.LayBang(sql);
            cbb_TenMH.DataSource = dt;
            cbb_TenMH.DisplayMember = "TenMH";
            cbb_TenMH.ValueMember = "MaMH";
        }
        public void LayDanhMucPH()
        {
            string sql = "Select * from PhongHoc";
            DataTable dt = lopchung.LayBang(sql);
            cbb_TenPH.DataSource = dt;
            cbb_TenPH.DisplayMember = "TenPH";
            cbb_TenPH.ValueMember = "MaPH";
        }

        public void LayDanhMucXH()
        {
            string sql = "Select * from XuatHoc";
            DataTable dt = lopchung.LayBang(sql);
            cbb_TenXH.DataSource = dt;
            cbb_TenXH.DisplayMember = "TenXH";
            cbb_TenXH.ValueMember = "MaXH";
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaTKB.Text = dataGridView1.CurrentRow.Cells["MaTKB"].Value.ToString();
            txt_TenTKB.Text = dataGridView1.CurrentRow.Cells["TenTKB"].Value.ToString();
            txt_HocKi.Text = dataGridView1.CurrentRow.Cells["HocKi"].Value.ToString();
            date_NgayLap.Text = dataGridView1.CurrentRow.Cells["NgayLap"].Value.ToString();
            date_NgayApDung.Text = dataGridView1.CurrentRow.Cells["NgayApDung"].Value.ToString();
            cbb_TenXH.Text = dataGridView1.CurrentRow.Cells["MaXH"].Value.ToString();
            cbb_TenPH.Text = dataGridView1.CurrentRow.Cells["MaPH"].Value.ToString();
            cbb_TenMH.Text = dataGridView1.CurrentRow.Cells["MaMH"].Value.ToString();
            cbb_TenLH.Text = dataGridView1.CurrentRow.Cells["MaLH"].Value.ToString();
        }

        private void Btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_TaoMoi_Click(object sender, EventArgs e)
        {
            txt_MaTKB.Clear();
            txt_TenTKB.Clear();
            date_NgayLap.Text = "";
            date_NgayApDung.Text = "";
            txt_HocKi.Clear();
            txt_MaTKB.Focus();
        }

        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql = "Delete from ThoiKhoaBieu where MaTKB = '" + txt_MaTKB.Text + "'";
            int ketqua = lopchung.ThemSuaXoa(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Bạn đã xóa thời khóa biểu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn đã xóa thời khóa biểu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadTKB();
            LayDanhMucLH();
            LayDanhMucMH();
            LayDanhMucPH();
            LayDanhMucXH();
        }

        private void Btn_Sua_Click(object sender, EventArgs e)
        {
            string sql = "Update ThoiKhoaBieu set TenTKB = N'" + txt_TenTKB.Text + "',HocKi = '" + txt_HocKi.Text + "',NgayLap = '" + date_NgayLap.Text + "',NgayApDung ='" + date_NgayApDung.Text + "',MaLH =N'" + cbb_TenLH.SelectedValue + "',MaMH =N'" + cbb_TenMH.SelectedValue + "',MaPH =N'" + cbb_TenPH.SelectedValue + "',MaXH =N'" + cbb_TenXH.SelectedValue + "' where MaTKB ='" + txt_MaTKB.Text + "'";
            int ketqua = lopchung.ThemSuaXoa(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Bạn đã sửa thời khóa biểu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn đã sửa thời khóa biểu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadTKB();
            LayDanhMucLH();
            LayDanhMucMH();
            LayDanhMucPH();
            LayDanhMucXH();
        }

        private void Btn_Luu_Click(object sender, EventArgs e)
        {
            string sql = "Insert into ThoiKhoaBieu values ('" + txt_MaTKB.Text + "',N'" + txt_TenTKB.Text + "','" + txt_HocKi.Text + "','" + date_NgayLap.Text + "','" + date_NgayApDung.Text + "','" + cbb_TenLH.SelectedValue + "','" + cbb_TenMH.SelectedValue + "','" + cbb_TenPH.SelectedValue + "','" + cbb_TenXH.SelectedValue + "')";
            int ketqua = lopchung.ThemSuaXoa(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Bạn đã lưu thời khóa biểu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn đã lưu thời khóa biểu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadTKB();
            LayDanhMucLH();
            LayDanhMucMH();
            LayDanhMucPH();
            LayDanhMucXH();
        }
    }
}
