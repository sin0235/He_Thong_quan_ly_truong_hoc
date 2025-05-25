using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTruongHoc.GUI.Controls.ucBanGiamHieu
{
    public partial class ucXemTBChiTiet : UserControl
    {
        // Thiết lập chi tiết thông báo để hiển thị
        public void SetThongBaoChiTiet(string thoiGian, string nguoiNhan, string noiDung, string tieuDe)
        {
            lblThoiGianGuiThu.Text = thoiGian;
            lblNguoINhanThu.Text = nguoiNhan;
            rtbNoiDung.Text = noiDung;
            lblTieuDeThu.Text = tieuDe;
        }
        public ucXemTBChiTiet()
        {
            InitializeComponent();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            var parentForm = this.FindForm() as frmBGH;
            parentForm.btnXemThu_Click(sender, e);
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlMain_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void ucXemTBChiTiet_Load(object sender, EventArgs e)
        {

        }
    }
}
