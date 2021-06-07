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
    public partial class frm_PhongHoc : Form
    {
        LopDungChung lopchung = new LopDungChung();
        public frm_PhongHoc()
        {
            InitializeComponent();
        }

        public void LoadBang()
        {
            string sql = "Select * from PhongHoc";
            DataTable dt = lopchung.LayBang(sql);
            dataGridView1.DataSource = dt;
        }

        private void Btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_TaoMoi_Click(object sender, EventArgs e)
        {
            txt_MaPH.Clear();
            txt_TenPH.Clear();
            txt_DiaChiPH.Clear();
            txt_MaPH.Focus();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string tinhtrang;
            txt_MaPH.Text = dataGridView1.CurrentRow.Cells["MaPH"].Value.ToString();
            txt_TenPH.Text = dataGridView1.CurrentRow.Cells["TenPH"].Value.ToString();
            txt_DiaChiPH.Text = dataGridView1.CurrentRow.Cells["DiaChiPH"].Value.ToString();
            tinhtrang = dataGridView1.CurrentRow.Cells["TinhTrangPH"].Value.ToString();
            if (tinhtrang == "Đang Sử Dụng")
            {
                chb_SuDung.Checked = true;
                chb_KhongSuDung.Checked = false;
            }
            else
            {
                chb_KhongSuDung.Checked = true;
                chb_SuDung.Checked = false;
            }
        }

        private void Chb_KhongSuDung_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Frm_PhongHoc_Load(object sender, EventArgs e)
        {
            LoadBang();
        }

        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql = "Delete from PhongHoc where MaPH = '" + txt_MaPH.Text + "'";
            int ketqua = lopchung.ThemSuaXoa(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Bạn đã xóa thành công", "Thông Báo");
            }
            else
            {
                MessageBox.Show("Bạn đã xóa thất bại", "Thông Báo");
            }
            LoadBang();
        }

        private void Chb_SuDung_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Sua_Click(object sender, EventArgs e)
        {
            string sql;
            if (chb_SuDung.Checked == true)
            {
                sql = "Update PhongHoc set TenPH = N'" + txt_TenPH.Text + "',DiaChiPH = N'" + txt_DiaChiPH.Text + "',TinhTrangPH = N'Đang Sử Dụng' where MaPH = '" + txt_MaPH.Text + "'";

            }
            else
            {
                sql = "Update PhongHoc set TenPH = N'" + txt_TenPH.Text + "',DiaChiPH = N'" + txt_DiaChiPH.Text + "',TinhTrangPH = N'Không Sử Dụng' where MaPH = '" + txt_MaPH.Text + "'";
            }
            int ketqua = lopchung.ThemSuaXoa(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Bạn đã sửa thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Bạn đã sửa thất bại", "Thông Báo");
            }
            LoadBang();
        }

        private void Btn_Luu_Click(object sender, EventArgs e)
        {
            string sql;
            if (chb_SuDung.Checked == true)
            {
                sql = "Insert into PhongHoc values ('" + txt_MaPH.Text + "', N'" + txt_TenPH.Text + "',N'" + txt_DiaChiPH.Text + "',N'Đang Sử Dụng')";

            }
            else
            {
                sql = "Insert into PhongHoc values ('" + txt_MaPH.Text + "', N'" + txt_TenPH.Text + "',N'" + txt_DiaChiPH.Text + "',N'Không Sử Dụng') ";
            }
            int ketqua = lopchung.ThemSuaXoa(sql);
            if (ketqua >= 1)
            {
                MessageBox.Show("Bạn đã thêm thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Bạn đã thêm thất bại", "Thông Báo");
            }
            LoadBang();
        }
    }
}
