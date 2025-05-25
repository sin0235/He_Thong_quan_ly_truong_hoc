using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.DTO
{
    public class TKBDTO
    {
        // Thuộc tính cơ bản từ bảng ThoiKhoaBieu
        public int MaTKB { get; set; }
        public int MaLop { get; set; }
        public int MaMon { get; set; }
        public int MaGV { get; set; }
        public DateTime Ngay { get; set; }
        public int Thu { get; set; }
        public string Tiet { get; set; }

        // Thuộc tính mở rộng cho hiển thị
        public string TenMon { get; set; }
        public string TenGiaoVien { get; set; }
        public string TenLop { get; set; }

        public TKBDTO()
        {
        }

        public TKBDTO(int maTKB, int maLop, int maMon, int maGV, DateTime ngay, int thu, string tiet)
        {
            MaTKB = maTKB;
            MaLop = maLop;
            MaMon = maMon;
            MaGV = maGV;
            Ngay = ngay;
            Thu = thu;
            Tiet = tiet;
        }
    }

    // Lớp bổ sung để lưu thông tin về tuần học
    public class TuanHocDTO
    {
        public int SoTuan { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }

        public TuanHocDTO(int soTuan, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            SoTuan = soTuan;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
        }

        public override string ToString()
        {
            return $"Tuần {SoTuan} ({NgayBatDau:dd/MM/yyyy} - {NgayKetThuc:dd/MM/yyyy})";
        }
    }
    // Thêm vào file DTO/TKBDTO.cs

    /// <summary>
    /// Lớp biểu diễn một khoảng thời gian (thay thế TuanHocDTO)
    /// </summary>
    public class KhoangThoiGianDTO
    {
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string DisplayText { get; set; }

        public KhoangThoiGianDTO(DateTime ngayBatDau, DateTime ngayKetThuc, string displayText)
        {
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            DisplayText = displayText;
        }

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
