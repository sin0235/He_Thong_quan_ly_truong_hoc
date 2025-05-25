using System;
using System.Collections.Generic;

namespace QuanLyTruongHoc.DTO
{
    public class DiemSoDTO
    {
        // Basic properties mapping to database fields
        public int MaDiem { get; set; }
        public int MaHS { get; set; }
        public int MaMon { get; set; }
        public int MaGV { get; set; }
        public int HocKy { get; set; }
        public string LoaiDiem { get; set; }
        public float Diem { get; set; }

        // Additional properties for display
        public string TenMon { get; set; }
        public string TenGV { get; set; }

        public DiemSoDTO()
        {
            // Default constructor
        }

        public DiemSoDTO(int maDiem, int maHS, int maMon, int maGV, int hocKy, string loaiDiem, float diem)
        {
            MaDiem = maDiem;
            MaHS = maHS;
            MaMon = maMon;
            MaGV = maGV;
            HocKy = hocKy;
            LoaiDiem = loaiDiem;
            Diem = diem;
        }
    }

    // Class to aggregate scores for a subject
    public class MonHocScoreDTO
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; }

        // Lists to store multiple scores of each type
        public List<float> DiemMiengList { get; set; } = new List<float>();
        public List<float> Diem15PhutList { get; set; } = new List<float>();
        public List<float> DiemGiuaKyList { get; set; } = new List<float>();
        public List<float> DiemCuoiKyList { get; set; } = new List<float>();

        // Average scores for each type
        public float DiemMieng { get; set; }
        public float Diem15Phut { get; set; }
        public float DiemGiuaKy { get; set; }
        public float DiemCuoiKy { get; set; }

        // Calculated scores
        public float DiemThuongXuyen { get; set; }
        public float DiemTrungBinh { get; set; }
        public string NhanXet { get; set; }

        public MonHocScoreDTO()
        {
            DiemMieng = 0;
            Diem15Phut = 0;
            DiemGiuaKy = 0;
            DiemCuoiKy = 0;
            DiemTrungBinh = 0;
            NhanXet = "";
        }

        // Calculate the average for each type of score
        public void CalculateTypeAverages()
        {
            DiemMieng = CalculateAverage(DiemMiengList);
            Diem15Phut = CalculateAverage(Diem15PhutList);
            DiemGiuaKy = CalculateAverage(DiemGiuaKyList);
            DiemCuoiKy = CalculateAverage(DiemCuoiKyList);

            // Calculate regular score as average of DiemMieng and Diem15Phut
            DiemThuongXuyen = (DiemMieng + Diem15Phut) / 2;
        }

        // Helper method to calculate average of a list of scores
        private float CalculateAverage(List<float> scores)
        {
            if (scores == null || scores.Count == 0)
                return 0;

            float sum = 0;
            foreach (float score in scores)
            {
                sum += score;
            }
            return (float)Math.Round(sum / scores.Count, 1);
        }

        // Calculate average score with new weights
        public void CalculateAverage()
        {
            // Calculate type averages first
            CalculateTypeAverages();

            // Weight: 30% DiemThuongXuyen, 30% DiemGiuaKy, 40% DiemCuoiKy
            DiemTrungBinh = (DiemThuongXuyen * 0.3f) + (DiemGiuaKy * 0.3f) + (DiemCuoiKy * 0.4f);
            DiemTrungBinh = (float)Math.Round(DiemTrungBinh, 1);
        }
    }

    // Class to store semester summary information
    public class HocKySummaryDTO
    {
        public int MaHS { get; set; }
        public int HocKy { get; set; }
        public string NamHoc { get; set; }
        public float DiemTrungBinh { get; set; }
        public string XepLoai { get; set; }
        public string HanhKiem { get; set; }
        public int XepHang { get; set; }
        public int SoBuoiNghi { get; set; }
        public string NhanXet { get; set; }

        public HocKySummaryDTO()
        {
            HocKy = 1;
            NamHoc = "2024-2025";
            DiemTrungBinh = 0;
            XepLoai = "Chưa xếp loại";
            HanhKiem = "Tốt";
            XepHang = 0;
            SoBuoiNghi = 0;
            NhanXet = "";
        }

        // Calculate performance tier based on GPA
        public void CalculateXepLoai()
        {
            if (DiemTrungBinh >= 8.0)
                XepLoai = "Giỏi";
            else if (DiemTrungBinh >= 7.0)
                XepLoai = "Khá";
            else if (DiemTrungBinh >= 5.0)
                XepLoai = "Trung bình";
            else
                XepLoai = "Yếu";
        }
    }
}
