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
    public partial class frm_TrangChu : Form
    {
        public frm_TrangChu()
        {
            InitializeComponent();
        }

        private void ThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ThốngKêPhòngHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private bool KiemTra(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name.Equals(name))
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        private void ĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!KiemTra("frm_DangNhap"))
            {
                frm_DangNhap frmdn = new frm_DangNhap();
                frmdn.MdiParent = this;
                frmdn.Show();
            }
        }

        private void HìnhẢnhToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ĐăngKíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!KiemTra("frm_DangKiTaiKhoan"))
            {
                frm_DangKiTaiKhoan frmdn = new frm_DangKiTaiKhoan();
                frmdn.MdiParent = this;
                frmdn.Show();
            }
        }

        private void QuảnLýVàThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Frm_TrangChu_Load(object sender, EventArgs e)
        {

        }

        private void VideoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void QuảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void NgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (!KiemTra("frm_NguoiDung"))
            {
                frm_NguoiDung frm = new frm_NguoiDung();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void ThờiKhóaBiểuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!KiemTra("frm_ThoiKhoaBieu"))
            {
                frm_ThoiKhoaBieu frm = new frm_ThoiKhoaBieu();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void HọcTậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!KiemTra("frm-PhongHoc"))
            {
                frm_PhongHoc frm = new frm_PhongHoc();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void ThoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("BẠN CÓ CHẮC MUỐN THOÁT KHÔNG", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
