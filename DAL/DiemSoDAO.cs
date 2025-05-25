using QuanLyTruongHoc.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.DAL
{
    public class DiemSoDAO
    {
        private DatabaseHelper db;

        public DiemSoDAO()
        {
            db = new DatabaseHelper();
        }

        /// <summary>
        /// Lấy tất cả điểm số của một học sinh theo học kỳ
        /// </summary>
        /// <param name="maHS">Mã học sinh</param>
        /// <param name="hocKy">Học kỳ (1 hoặc 2), 0 cho cả năm</param>
        /// <param name="namHoc">Năm học (ví dụ: "2024-2025")</param>
        /// <returns>Danh sách điểm số</returns>
        public List<DiemSoDTO> GetStudentScores(int maHS, int hocKy, string namHoc = null)
        {
            List<DiemSoDTO> scores = new List<DiemSoDTO>();
            try
            {
                string query = @"
                            SELECT ds.MaDiem, ds.MaHS, ds.MaMon, ds.MaGV, ds.HocKy, ds.LoaiDiem, ds.Diem,
                                   mh.TenMon, gv.HoTen as TenGV
                            FROM DiemSo ds
                            INNER JOIN MonHoc mh ON ds.MaMon = mh.MaMon
                            INNER JOIN GiaoVien gv ON ds.MaGV = gv.MaGV
                            WHERE ds.MaHS = @MaHS";

                // Add semester filter if specified
                if (hocKy > 0)
                {
                    query += " AND ds.HocKy = @HocKy";
                }

                Dictionary<string, object> parameters = new Dictionary<string, object>
                        {
                            { "@MaHS", maHS }
                        };

                if (hocKy > 0)
                {
                    parameters.Add("@HocKy", hocKy);
                }

                DataTable dt = db.ExecuteQuery(query, parameters);

                foreach (DataRow row in dt.Rows)
                {
                    DiemSoDTO score = new DiemSoDTO
                    {
                        MaDiem = Convert.ToInt32(row["MaDiem"]),
                        MaHS = Convert.ToInt32(row["MaHS"]),
                        MaMon = Convert.ToInt32(row["MaMon"]),
                        MaGV = Convert.ToInt32(row["MaGV"]),
                        HocKy = Convert.ToInt32(row["HocKy"]),
                        LoaiDiem = row["LoaiDiem"].ToString(),
                        Diem = Convert.ToSingle(row["Diem"]),
                        TenMon = row["TenMon"].ToString(),
                        TenGV = row["TenGV"].ToString()
                    };
                    scores.Add(score);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetStudentScores: {ex.Message}");
            }

            return scores;
        }

        // Inside GetStudentSubjectsScore method in DiemSoDAO.cs
        public List<MonHocScoreDTO> GetStudentSubjectsScore(int maHS, int hocKy, string namHoc = null)
        {
            List<DiemSoDTO> allScores = GetStudentScores(maHS, hocKy, namHoc);
            Dictionary<int, MonHocScoreDTO> subjectScores = new Dictionary<int, MonHocScoreDTO>();

            foreach (DiemSoDTO score in allScores)
            {
                // Create or get the subject score object
                if (!subjectScores.ContainsKey(score.MaMon))
                {
                    subjectScores[score.MaMon] = new MonHocScoreDTO
                    {
                        MaMon = score.MaMon,
                        TenMon = score.TenMon
                    };
                }

                // Add score to the appropriate list based on type
                switch (score.LoaiDiem)
                {
                    case "Miệng":
                        subjectScores[score.MaMon].DiemMiengList.Add(score.Diem);
                        break;
                    case "15 phút":
                        subjectScores[score.MaMon].Diem15PhutList.Add(score.Diem);
                        break;
                    case "Giữa kỳ":
                        subjectScores[score.MaMon].DiemGiuaKyList.Add(score.Diem);
                        break;
                    case "Cuối kỳ":
                        subjectScores[score.MaMon].DiemCuoiKyList.Add(score.Diem);
                        break;
                }
            }

            // Calculate average scores
            foreach (var subject in subjectScores.Values)
            {
                subject.CalculateAverage();
            }

            return subjectScores.Values.ToList();
        }

        /// <summary>
        /// Tính điểm tổng kết học kỳ
        /// </summary>
        /// <param name="maHS">Mã học sinh</param>
        /// <param name="hocKy">Học kỳ (1 hoặc 2), 0 cho cả năm</param>
        /// <param name="namHoc">Năm học (ví dụ: "2024-2025")</param>
        /// <returns>Đối tượng tổng kết học kỳ</returns>
        public HocKySummaryDTO GetSemesterSummary(int maHS, int hocKy, string namHoc = null)
        {
            HocKySummaryDTO summary = new HocKySummaryDTO
            {
                MaHS = maHS,
                HocKy = hocKy,
                NamHoc = namHoc ?? "2024-2025",
                HanhKiem = "Tốt", // Default value or should be retrieved from database
                SoBuoiNghi = GetStudentAbsences(maHS, hocKy, namHoc)
            };

            // Get all subject scores
            List<MonHocScoreDTO> subjectScores = GetStudentSubjectsScore(maHS, hocKy, namHoc);

            if (subjectScores.Count > 0)
            {
                // Calculate GPA
                float totalAverage = 0;
                foreach (var subject in subjectScores)
                {
                    totalAverage += subject.DiemTrungBinh;
                }
                summary.DiemTrungBinh = totalAverage / subjectScores.Count;
                summary.DiemTrungBinh = (float)Math.Round(summary.DiemTrungBinh, 1);

                // Calculate academic performance based on GPA
                summary.CalculateXepLoai();

                // Get class rank (this would require additional DB queries)
                summary.XepHang = GetStudentRank(maHS, hocKy, namHoc);
            }

            return summary;
        }

        /// <summary>
        /// Lấy số buổi nghỉ của học sinh
        /// </summary>
        private int GetStudentAbsences(int maHS, int hocKy, string namHoc)
        {
            try
            {
                // Lấy số buổi nghỉ từ bảng DiemDanh thay vì tạo ngẫu nhiên
                string query = @"
                        SELECT COUNT(*) AS SoNgayNghi 
                        FROM DiemDanh 
                        WHERE MaHS = @MaHS AND TrangThai = N'Vắng'";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@MaHS", maHS }
                    };

                // Nếu có năm học, thêm điều kiện lọc theo năm học
                if (!string.IsNullOrEmpty(namHoc))
                {
                    query += " AND YEAR(Ngay) = @Year";
                    int year = int.Parse(namHoc.Split('-')[0]);
                    parameters.Add("@Year", year);
                }

                object result = db.ExecuteScalar(query, parameters);
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetStudentAbsences: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// Lấy xếp hạng của học sinh trong lớp dựa trên điểm trung bình
        /// </summary>
        /// <param name="maHS">Mã học sinh</param>
        /// <param name="hocKy">Học kỳ (1 hoặc 2), 0 cho cả năm</param>
        /// <param name="namHoc">Năm học (ví dụ: "2024-2025")</param>
        /// <returns>Thứ hạng của học sinh trong lớp</returns>
        private int GetStudentRank(int maHS, int hocKy, string namHoc)
        {
            try
            {
                string queryGetClass = @"
                        SELECT hs.MaLop, lh.NamHoc
                        FROM HocSinh hs
                        JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                        WHERE hs.MaHS = @MaHS";

                Dictionary<string, object> paramsGetClass = new Dictionary<string, object>
                    {
                        { "@MaHS", maHS }
                    };

                DataTable dtClass = db.ExecuteQuery(queryGetClass, paramsGetClass);
                if (dtClass == null || dtClass.Rows.Count == 0)
                {
                    return 0; // Không tìm thấy thông tin lớp học
                }

                int maLop = Convert.ToInt32(dtClass.Rows[0]["MaLop"]);
                string namHocLop = dtClass.Rows[0]["NamHoc"].ToString();

                // Sử dụng năm học từ tham số nếu được cung cấp, ngược lại dùng năm học của lớp
                string schoolYear = !string.IsNullOrEmpty(namHoc) ? namHoc : namHocLop;

              
                // Truy vấn này sẽ tính điểm trung bình cho tất cả học sinh trong lớp và gán thứ hạng
                string rankQuery = @"
                        WITH StudentGPA AS (
                            SELECT 
                                hs.MaHS,
                                hs.HoTen,
                                ROUND(AVG(CAST(ds.Diem as FLOAT)), 1) as DiemTB
                            FROM 
                                HocSinh hs
                            LEFT JOIN 
                                DiemSo ds ON hs.MaHS = ds.MaHS
                            WHERE 
                                hs.MaLop = @MaLop";

                if (hocKy > 0)
                {
                    rankQuery += " AND ds.HocKy = @HocKy";
                }

                rankQuery += @"
                            GROUP BY 
                                hs.MaHS, hs.HoTen
                        ),
                        RankedStudents AS (
                            SELECT 
                                MaHS,
                                HoTen,
                                DiemTB,
                                DENSE_RANK() OVER (ORDER BY DiemTB DESC) as Rank
                            FROM 
                                StudentGPA
                        )
                        SELECT 
                            Rank
                        FROM 
                            RankedStudents
                        WHERE 
                            MaHS = @MaHS";

                Dictionary<string, object> rankParams = new Dictionary<string, object>
                    {
                        { "@MaLop", maLop },
                        { "@MaHS", maHS }
                    };

                if (hocKy > 0)
                {
                    rankParams.Add("@HocKy", hocKy);
                }

                DataTable dtRank = db.ExecuteQuery(rankQuery, rankParams);

                if (dtRank != null && dtRank.Rows.Count > 0 && dtRank.Rows[0]["Rank"] != DBNull.Value)
                {
                    return Convert.ToInt32(dtRank.Rows[0]["Rank"]);
                }

                return 0; // Không có dữ liệu xếp hạng
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetStudentRank: {ex.Message}");
                return 0;
            }
        }

        /// <summary>
        /// Thêm điểm số mới
        /// </summary>
        public bool AddScore(DiemSoDTO score)
        {
            try
            {
                // Generate a new MaDiem if it's not provided
                if (score.MaDiem <= 0)
                {
                    // Get the next available ID
                    string getMaxIdQuery = "SELECT ISNULL(MAX(MaDiem), 0) + 1 FROM DiemSo";
                    object result = db.ExecuteScalar(getMaxIdQuery);
                    score.MaDiem = Convert.ToInt32(result);
                }

                string query = @"
                            INSERT INTO DiemSo (MaDiem, MaHS, MaMon, MaGV, HocKy, LoaiDiem, Diem)
                            VALUES (@MaDiem, @MaHS, @MaMon, @MaGV, @HocKy, @LoaiDiem, @Diem)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                        {
                            { "@MaDiem", score.MaDiem },
                            { "@MaHS", score.MaHS },
                            { "@MaMon", score.MaMon },
                            { "@MaGV", score.MaGV },
                            { "@HocKy", score.HocKy },
                            { "@LoaiDiem", score.LoaiDiem },
                            { "@Diem", score.Diem }
                        };

                return db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddScore: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Cập nhật điểm số
        /// </summary>
        public bool UpdateScore(DiemSoDTO score)
        {
            try
            {
                string query = @"
                            UPDATE DiemSo
                            SET MaHS = @MaHS, MaMon = @MaMon, MaGV = @MaGV, 
                                HocKy = @HocKy, LoaiDiem = @LoaiDiem, Diem = @Diem
                            WHERE MaDiem = @MaDiem";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                        {
                            { "@MaDiem", score.MaDiem },
                            { "@MaHS", score.MaHS },
                            { "@MaMon", score.MaMon },
                            { "@MaGV", score.MaGV },
                            { "@HocKy", score.HocKy },
                            { "@LoaiDiem", score.LoaiDiem },
                            { "@Diem", score.Diem }
                        };

                return db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateScore: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa điểm số
        /// </summary>
        public bool DeleteScore(int maDiem)
        {
            try
            {
                string query = "DELETE FROM DiemSo WHERE MaDiem = @MaDiem";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                        {
                            { "@MaDiem", maDiem }
                        };

                return db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteScore: {ex.Message}");
                return false;
            }
        }
    }
}
