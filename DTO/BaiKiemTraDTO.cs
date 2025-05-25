using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.DTO
{
    /// <summary>
    /// DTO for a test/quiz
    /// </summary>
    public class BaiKiemTraDTO
    {
        public int MaBaiKT { get; set; }
        public string TenBaiKT { get; set; }
        public int MaGV { get; set; }
        public int MaMH { get; set; }
        public string TenMonHoc { get; set; }
        public int MaLop { get; set; }
        public string TenLop { get; set; }
        public string LoaiBaiKT { get; set; }
        public int ThoiGianLamBai { get; set; } // in minutes
        public int SoLanLamToiDa { get; set; }
        public string MoTa { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public double DiemDatYeuCau { get; set; }
        public bool HienThiKetQuaNgay { get; set; }
        public bool XaoTronCauHoi { get; set; }
        public string GhiChuChamDiem { get; set; }
        public bool CoMatKhau { get; set; }
        public string MatKhau { get; set; }
        public string TrangThai { get; set; } // "Chưa công bố" hoặc "Đã công bố"
        public DateTime NgayTao { get; set; }
        public List<CauHoiDTO> DanhSachCauHoi { get; set; } = new List<CauHoiDTO>();
        // Các thuộc tính cần thêm vào BaiKiemTraDTO
        public int HocKy { get; set; }
        public string NamHoc { get; set; }

        public BaiKiemTraDTO()
        {
            NgayTao = DateTime.Now;
            TrangThai = "Chưa công bố";
            HienThiKetQuaNgay = true;
            XaoTronCauHoi = false;
            SoLanLamToiDa = 1;
            ThoiGianLamBai = 45; // default 45 minutes
            DiemDatYeuCau = 5.0; // default passing score 5.0
            HocKy = 1; // Default to semester 1
            NamHoc = "2024-2025"; // Default to current academic year
        }

    }

    /// <summary>
    /// Base DTO for questions (both multiple choice and essay)
    /// </summary>
    public class CauHoiDTO
    {
        public int MaCauHoi { get; set; }
        public int MaBaiKT { get; set; }
        public string LoaiCauHoi { get; set; } // "TN" or "TL"
        public string NoiDung { get; set; }
        public double DiemSo { get; set; }
        public int ThuTu { get; set; }
        public int MaMH { get; set; } // Mã môn học
        public int MaGV { get; set; } // Mã giáo viên
    }
    
    /// <summary>
    /// DTO for multiple-choice questions
    /// </summary>
    public class CauHoiTracNghiemDTO : CauHoiDTO
    {
        public List<LuaChonDTO> DanhSachLuaChon { get; set; } = new List<LuaChonDTO>();
        public string DapAnDung { get; set; } // A, B, C, or D
        
        public CauHoiTracNghiemDTO()
        {
            LoaiCauHoi = "TN";
            MaMH = 0; // Sẽ được thiết lập từ bài kiểm tra
            MaGV = 0; // Sẽ được thiết lập từ bài kiểm tra
        }
    }
    
    /// <summary>
    /// DTO for essay questions
    /// </summary>
    public class CauHoiTuLuanDTO : CauHoiDTO
    {
        public string HuongDanTraLoi { get; set; }
        public bool CoGioiHanTu { get; set; }
        public int GioiHanTu { get; set; }
        
        public CauHoiTuLuanDTO()
        {
            LoaiCauHoi = "TL";
            GioiHanTu = 500; // default word limit
            MaMH = 0; // Sẽ được thiết lập từ bài kiểm tra
            MaGV = 0; // Sẽ được thiết lập từ bài kiểm tra
        }
    }
    
    /// <summary>
    /// DTO for multiple choice options
    /// </summary>
    public class LuaChonDTO
    {
        public int MaLuaChon { get; set; }
        public int MaCauHoi { get; set; }
        public string NoiDung { get; set; }
        public string NhanDang { get; set; } // A, B, C, or D
        public bool LaDapAnDung { get; set; }
    }
}
