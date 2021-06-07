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
    public partial class frm_NguoiDung : Form
    {

        LopDungChung lopchung = new LopDungChung();
        public frm_NguoiDung()
        {
            InitializeComponent();
        }

        private void Tb_SinhVien_Click(object sender, EventArgs e)
        {

        }

        public void LoadSV()
        {
            string sql = "Select * from SinhVien";
            DataTable dt = lopchung.LayBang(sql);
            dataGridView1.DataSource = dt;    
        }

        public void LoadGV()
        {
            string sql = "Select * from GiaoVien";
            DataTable dt = lopchung.LayBang(sql);
            dataGridView2.DataSource = dt;
        }

        public void LoadNQL()
        {
            string sql = "Select * from NhaQuanLy";
            DataTable dt = lopchung.LayBang(sql);
            dataGridView3.DataSource = dt;
        }

        

        public void LayDanhMucSV()
        {
            string sql = "Select * from ThoiKhoaBieu";
            DataTable dt = lopchung.LayBang(sql);
            cbb_TKBSV.DataSource = dt;
            cbb_TKBSV.DisplayMember = "TenTKB";
            cbb_TKBSV.ValueMember = "MaTKB";
        }
        public void LayDanhMucGV()
        {
            string sql = "Select * from ThoiKhoaBieu";
            DataTable dt = lopchung.LayBang(sql);
            cbb_TKBGV.DataSource = dt;
            cbb_TKBGV.DisplayMember = "TenTKB";
            cbb_TKBGV.ValueMember = "MaTKB";
        }
        public void LayDanhMucNQL()
        {
            string sql = "Select * from ThoiKhoaBieu";
            DataTable dt = lopchung.LayBang(sql);
            cbb_NQL.DataSource = dt;
            cbb_NQL.DisplayMember = "TenTKB";
            cbb_NQL.ValueMember = "MaTKB";
        }

        private void Frm_NguoiDung_Load(object sender, EventArgs e)
        {
            LoadGV();
            LoadNQL();
            LoadSV();
            LayDanhMucSV();
            LayDanhMucGV();
            LayDanhMucNQL();
        }

        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaSV.Text = dataGridView1.CurrentRow.Cells["MaSV"].Value.ToString();
            txt_TenSV.Text = dataGridView1.CurrentRow.Cells["TenSV"].Value.ToString();
            date_NgaySinhSV.Text = dataGridView1.CurrentRow.Cells["NgaySinh"].Value.ToString();
            txt_DiaChiSV.Text = dataGridView1.CurrentRow.Cells["DiaChiTT"].Value.ToString();
            txt_QueQuanSV.Text = dataGridView1.CurrentRow.Cells["QueQuan"].Value.ToString();
            txt_SDTSV.Text = dataGridView1.CurrentRow.Cells["SDT"].Value.ToString();
            txt_EmailSV.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
            txt_ChuyenNganh.Text = dataGridView1.CurrentRow.Cells["ChuyenNganh"].Value.ToString();
            txt_HeDaoTao.Text = dataGridView1.CurrentRow.Cells["HeDaoTao"].Value.ToString();
            cbb_TKBSV.Text = dataGridView1.CurrentRow.Cells["MaTKB"].Value.ToString();
        }

        private void Btn_TaoMoi_Click(object sender, EventArgs e)
        {
            txt_ChuyenNganh.Clear();
            txt_HeDaoTao.Clear();
            txt_MaSV.Clear();
            txt_TenSV.Clear();
            date_NgaySinhSV.Text = "";
            txt_DiaChiSV.Clear();
            txt_QueQuanSV.Clear();
            txt_SDTSV.Clear();
            txt_EmailSV.Clear();
            txt_MaSV.Focus();

        }

        private void Btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql = "Delete from SinhVien where MaSV='"+txt_MaSV.Text+"'";
            int ketqua = lopchung.ThemSuaXoa(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Bạn đã xóa sinh viên thành công", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn đã xóa sinh viên thất bại", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadSV();
            LayDanhMucSV();
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_TaoMoiGV_Click(object sender, EventArgs e)
        {
            txt_MaGV.Clear();
            txt_TenGV.Clear();
            txt_KhoaGV.Clear();
            date_NgaySinhGV.Text ="";
            txt_DiaChiGV.Clear() ;
            txt_QueQuanGV.Clear();
            txt_SDTGV.Clear();
            txt_EmailGV.Clear();
            txt_KinhNghiem.Clear();
            txt_QTCT.Clear();
            txt_QTDT.Clear();
            txt_HocVi.Clear();
            txt_MaGV.Focus();
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Btn_Sua_Click(object sender, EventArgs e)
        {
            string sql = "Update SinhVien set TenSV = N'" + txt_TenSV.Text + "',NgaySinh = N'" + date_NgaySinhSV.Text + "',DiaChiTT =  N'" + txt_DiaChiSV.Text + "',QueQuan = N'" + txt_QueQuanSV.Text + "',SDT = N'" + txt_SDTSV.Text + "',Email = N'" + txt_EmailSV.Text + "',MaTKB = N'" + cbb_TKBSV.SelectedValue + "',ChuyenNganh = N'" + txt_ChuyenNganh.Text + "',HeDaoTao = N'" + txt_HeDaoTao.Text + "' where MaSV = '" + txt_MaSV.Text + "'";
            int ketqua = lopchung.ThemSuaXoa(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Bạn đã sửa sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn đã sửa sinh viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadSV();
            LayDanhMucSV();
        }

        private void Btn_Luu_Click(object sender, EventArgs e)
        {
            string sql = "Insert into SinhVien values ( '" + txt_MaSV.Text + "',N'" + txt_TenSV.Text + "', N'" + date_NgaySinhSV.Text + "', N'" + txt_DiaChiSV.Text + "', N'" + txt_QueQuanSV.Text + "','" + txt_SDTSV.Text + "', N'" + txt_EmailSV.Text + "','" + cbb_TKBSV.SelectedValue + "', N'" + txt_ChuyenNganh.Text + "', N'" + txt_HeDaoTao.Text + "')";
            int ketqua = lopchung.ThemSuaXoa(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Bạn đã lưu sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn đã lưu sinh viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadSV();
            LayDanhMucSV();
        }

        private void Btn_XoaGV_Click(object sender, EventArgs e)
        {
            string sql = "Delete from GiaoVien where MaGV ='" + txt_MaGV.Text + "'";
            int ketqua = lopchung.ThemSuaXoa(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Bạn đã xóa giáo viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn đã xóa giáo viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadSV();
            LayDanhMucSV();
        }

        private void Btn_SuaGV_Click(object sender, EventArgs e)
        {
            string sql = "Update GiaoVien set TenGV = N'" + txt_TenGV.Text + "',Khoa = N'" + txt_KhoaGV.Text + "',NgaySinh = '" + date_NgaySinhGV.Text + "',DiaChiTT =  N'" + txt_DiaChiGV.Text + "',QueQuan = N'" + txt_QueQuanGV.Text + "',SDT = '" + txt_SDTGV.Text + "',Email = N'" + txt_EmailGV.Text + "',KinhNghiem = N'" + txt_KinhNghiem.Text + "',QuaTrinhCT = N'" + txt_QTCT.Text + "',QuaTrinhDT = N'" + txt_QTDT.Text + "',HocVi = N'" + txt_HocVi.Text + "',MaTKB = N'" + cbb_TKBGV.SelectedValue + "' where MaGV = '" + txt_MaGV.Text + "'";
            int ketqua = lopchung.ThemSuaXoa(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Bạn đã sửa giáo viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn đã sửa giáo viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadGV();
            LayDanhMucGV();
        }

        private void Txt_KhoaSV_TextChanged(object sender, EventArgs e)
        {
        }

        private void Btn_LuuGV_Click(object sender, EventArgs e)
        {
            string sql = "Insert into GiaoVien values ('" + txt_MaGV.Text + "',N'" + txt_TenGV.Text + "', N'" + txt_KhoaGV.Text + "','" + date_NgaySinhGV.Text + "', N'" + txt_DiaChiGV.Text + "','" + txt_QueQuanGV.Text + "','" + txt_SDTGV.Text + "',N'" + txt_EmailGV.Text + "',N'" + txt_KinhNghiem.Text + "',N'" + txt_QTCT.Text + "',N'" + txt_QTDT.Text + "',N'" + txt_HocVi.Text + "', N'" + cbb_TKBGV.SelectedValue + "')";
            int ketqua = lopchung.ThemSuaXoa(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Bạn đã thêm giáo viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn đã thêm giáo viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadGV();
            LayDanhMucGV();
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaNQL.Text = dataGridView3.CurrentRow.Cells["MaNQL"].Value.ToString();
            txt_TenNQL.Text = dataGridView3.CurrentRow.Cells["TenNQL"].Value.ToString();
            date_NgaySinhNQL.Text = dataGridView3.CurrentRow.Cells["NgaySinh"].Value.ToString();
            txt_DiaChiNQL.Text = dataGridView3.CurrentRow.Cells["DiaChiTT"].Value.ToString();
            txt_QueQuanNQL.Text = dataGridView3.CurrentRow.Cells["QueQuan"].Value.ToString();
            txt_SDTNQL.Text = dataGridView3.CurrentRow.Cells["SDT"].Value.ToString();
            txt_EmailNQL.Text = dataGridView3.CurrentRow.Cells["Email"].Value.ToString();
            txt_LoaiChucVu.Text = dataGridView3.CurrentRow.Cells["LoaiChucVu"].Value.ToString();
            txt_NoiLamViec.Text = dataGridView3.CurrentRow.Cells["NoiLamViec"].Value.ToString();
            cbb_NQL.Text = dataGridView3.CurrentRow.Cells["MaTKB"].Value.ToString();
        }

        private void Btn_ThoatNQL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_TaoMoiNQL_Click(object sender, EventArgs e)
        {
            txt_MaNQL.Clear();
            txt_TenNQL.Clear();
            date_NgaySinhNQL.Text ="";
            txt_DiaChiNQL.Clear();
            txt_QueQuanNQL.Clear();
            txt_SDTNQL.Clear();
            txt_EmailNQL.Clear();
            txt_LoaiChucVu.Clear();
            txt_NoiLamViec.Clear();
            txt_MaNQL.Focus();
        }

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaGV.Text = dataGridView2.CurrentRow.Cells["MaGV"].Value.ToString();
            txt_TenGV.Text = dataGridView2.CurrentRow.Cells["TenGV"].Value.ToString();
            txt_KhoaGV.Text = dataGridView2.CurrentRow.Cells["Khoa"].Value.ToString();
            date_NgaySinhGV.Text = dataGridView2.CurrentRow.Cells["NgaySinh"].Value.ToString();
            txt_DiaChiGV.Text = dataGridView2.CurrentRow.Cells["DiaChiTT"].Value.ToString();
            txt_QueQuanGV.Text = dataGridView2.CurrentRow.Cells["QueQuan"].Value.ToString();
            txt_SDTGV.Text = dataGridView2.CurrentRow.Cells["SDT"].Value.ToString();
            txt_EmailGV.Text = dataGridView2.CurrentRow.Cells["Email"].Value.ToString();
            txt_KinhNghiem.Text = dataGridView2.CurrentRow.Cells["KinhNghiem"].Value.ToString();
            txt_QTCT.Text = dataGridView2.CurrentRow.Cells["QuaTrinhCT"].Value.ToString();
            txt_QTDT.Text = dataGridView2.CurrentRow.Cells["QuaTrinhDT"].Value.ToString();
            txt_HocVi.Text = dataGridView2.CurrentRow.Cells["HocVi"].Value.ToString();
            cbb_TKBGV.Text = dataGridView2.CurrentRow.Cells["MaTKB"].Value.ToString();
        }

        private void Tb_GiaoVien_Click(object sender, EventArgs e)
        {

        }

        private void Btn_XoaNQL_Click(object sender, EventArgs e)
        {
            string sql = "Delete from NhaQuanLy where MaNQL ='" + txt_MaNQL.Text + "'";
            int ketqua = lopchung.ThemSuaXoa(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Bạn đã xóa nhà quản lý thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn đã xóa nhà quản lý thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadNQL();
            LayDanhMucNQL();
        }

        private void Btn_SuaNQL_Click(object sender, EventArgs e)
        {
            string sql = "Update NhaQuanLy set TenNQL = N'" + txt_TenNQL.Text + "',NgaySinh = '" + date_NgaySinhNQL.Text + "',DiaChiTT =  N'" + txt_DiaChiNQL.Text + "',QueQuan = N'" + txt_QueQuanNQL.Text + "',SDT = '" + txt_SDTNQL.Text + "',Email = N'" + txt_EmailNQL.Text + "',MaTKB = N'" + cbb_NQL.SelectedValue + "',LoaiChucVu = N'" + txt_LoaiChucVu.Text + "',NoiLamViec = N'" + txt_NoiLamViec.Text + "' where MaNQL = '" + txt_MaNQL.Text + "'";
            int ketqua = lopchung.ThemSuaXoa(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Bạn đã sửa nhà quản lý thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn đã sửa nhà quản lý thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadNQL();
            LayDanhMucNQL();
        }

        private void Btn_LuuNQL_Click(object sender, EventArgs e)
        {
            string sql = "Insert into NhaQuanLy values ('" + txt_MaNQL.Text + "', N'" + txt_TenNQL.Text + "','" + date_NgaySinhNQL.Text + "',N'" + txt_DiaChiNQL.Text + "',N'" + txt_QueQuanNQL.Text + "','" + txt_SDTNQL.Text + "',N'" + txt_EmailNQL.Text + "',N'" + cbb_NQL.SelectedValue + "',N'" + txt_LoaiChucVu.Text + "', N'" + txt_NoiLamViec.Text + "')";
            int ketqua = lopchung.ThemSuaXoa(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Bạn đã thêm nhà quản lý thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bạn đã thêm nhà quản lý thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadNQL();
            LayDanhMucNQL();
        }
    }
}
