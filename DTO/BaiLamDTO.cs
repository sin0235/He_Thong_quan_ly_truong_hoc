// File: DTO/BaiLamDTO.cs
using System;
using System.Collections.Generic;

namespace QuanLyTruongHoc.DTO
{
    /// <summary>
    /// DTO for a student test submission
    /// </summary>
    public class BaiLamDTO
    {
        public int MaBaiLam { get; set; }
        public int MaBaiKT { get; set; }
        public string TenBaiKT { get; set; }
        public int MaHS { get; set; }
        public string TenHocSinh { get; set; }
        public string TenLop { get; set; }
        public DateTime NgayLam { get; set; }
        public int ThoiGianLamBai { get; set; } // in minutes
        public double? DiemSo { get; set; } // null until graded
        public bool DaNop { get; set; }

        // Child collections for answers
        public List<BaiLamTracNghiemDTO> CauTraLoiTracNghiem { get; set; } = new List<BaiLamTracNghiemDTO>();
        public List<BaiLamTuLuanDTO> CauTraLoiTuLuan { get; set; } = new List<BaiLamTuLuanDTO>();
    }

    /// <summary>
    /// DTO for a student's multiple-choice answer
    /// </summary>
    public class BaiLamTracNghiemDTO
    {
        public int MaBaiLam { get; set; }
        public int MaCauHoiTN { get; set; }
        public string NoiDungCauHoi { get; set; }
        public string CauTraLoi { get; set; } // A, B, C, or D; null if not answered
        public double? Diem { get; set; } // null until graded
        public double DiemToiDa { get; set; } // max points for this question
        public string DapAnDung { get; set; } // correct answer
        public List<LuaChonDTO> DanhSachLuaChon { get; set; } = new List<LuaChonDTO>();
        public int ThuTu { get; set; } // order of question in test
    }

    /// <summary>
    /// DTO for a student's essay answer
    /// </summary>
    public class BaiLamTuLuanDTO
    {
        public int MaBaiLam { get; set; }
        public int MaCauHoiTL { get; set; }
        public string NoiDungCauHoi { get; set; }
        public string CauTraLoi { get; set; }
        public double? Diem { get; set; } // null until graded
        public double DiemToiDa { get; set; } // max points for this question
        public string NhanXet { get; set; } // teacher comments
        public string HuongDanTraLoi { get; set; } // answer guide
        public int ThuTu { get; set; } // order of question in test
    }
}
