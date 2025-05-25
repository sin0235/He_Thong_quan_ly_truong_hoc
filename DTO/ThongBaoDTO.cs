using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.DAL
{
    public class ThongBaoDTO
    {
        public int MaTB { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public DateTime Ngay { get; set; }
        public string NguoiGui { get; set; }
        public string NguoiNhan { get; set; }
        public bool DaDoc { get; set; }

        public int maNguoiNhan { get; set; }

        public ThongBaoDTO()
        {
            // Constructor mặc định
        }

        public ThongBaoDTO(int maTB, string tieuDe, string noiDung, DateTime ngay, string nguoiGui, string nguoiNhan, bool daDoc)
        {
            MaTB = maTB;
            TieuDe = tieuDe;
            NoiDung = noiDung;
            Ngay = ngay;
            NguoiGui = nguoiGui;
            NguoiNhan = nguoiNhan;
            DaDoc = daDoc;
        }
    }
}
