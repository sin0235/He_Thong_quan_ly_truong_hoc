// File: DAL/BaiLamDAO.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using QuanLyTruongHoc.DTO;

namespace QuanLyTruongHoc.DAL
{
    public class BaiLamDAO
    {
        private DatabaseHelper db;

        public BaiLamDAO()
        {
            db = new DatabaseHelper();
        }

        /// <summary>
        /// Checks if the student is allowed to take a test based on attempt limits
        /// </summary>
        /// <param name="maBaiKT">Test ID</param>
        /// <param name="maHS">Student ID</param>
        /// <returns>Tuple with (isAllowed, errorMessage, remainingAttempts)</returns>
        public Tuple<bool, string, int> KiemTraLuotLamBai(int maBaiKT, int maHS)
        {
            try
            {
                string query = @"
                    DECLARE @KetQua BIT;
                    DECLARE @ThongBao NVARCHAR(500);
                    DECLARE @SoLuotConLai INT;
                    
                    EXEC sp_KiemTraLuotLamBaiHopLe @MaBaiKT, @MaHS, @KetQua OUTPUT, @ThongBao OUTPUT;
                    SET @SoLuotConLai = dbo.fn_SoLuotLamBaiConLai(@MaBaiKT, @MaHS);
                    
                    SELECT @KetQua AS KetQua, @ThongBao AS ThongBao, @SoLuotConLai AS SoLuotConLai;";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT },
                    { "@MaHS", maHS }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    bool isAllowed = Convert.ToBoolean(row["KetQua"]);
                    string errorMessage = row["ThongBao"].ToString();
                    int remainingAttempts = Convert.ToInt32(row["SoLuotConLai"]);
                    
                    return new Tuple<bool, string, int>(isAllowed, errorMessage, remainingAttempts);
                }
                
                return new Tuple<bool, string, int>(false, "Lỗi kiểm tra lượt làm bài", 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking test attempt: {ex.Message}");
                return new Tuple<bool, string, int>(false, $"Lỗi: {ex.Message}", 0);
            }
        }
        
        /// <summary>
        /// Get the number of attempts already used by a student for a test
        /// </summary>
        /// <param name="maBaiKT">Test ID</param>
        /// <param name="maHS">Student ID</param>
        /// <returns>Number of attempts used</returns>
        public int GetAttemptsUsed(int maBaiKT, int maHS)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) 
                    FROM BaiLam
                    WHERE MaBaiKT = @MaBaiKT AND MaHS = @MaHS";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT },
                    { "@MaHS", maHS }
                };
                
                object result = db.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting attempts used: {ex.Message}");
                return 0;
            }
        }
        
        /// <summary>
        /// Get maximum allowed attempts for a test
        /// </summary>
        /// <param name="maBaiKT">Test ID</param>
        /// <returns>Maximum allowed attempts</returns>
        public int GetMaxAttempts(int maBaiKT)
        {
            try
            {
                string query = @"
                    SELECT SoLanLamToiDa
                    FROM BaiKiemTra
                    WHERE MaBaiKT = @MaBaiKT";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT }
                };
                
                object result = db.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting max attempts: {ex.Message}");
                return 1; // Default to 1 attempt if error
            }
        }

        /// <summary>
        /// Get all submissions for a specific test
        /// </summary>
        /// <param name="maBaiKT">Test ID</param>
        /// <returns>List of student submissions</returns>
        public List<BaiLamDTO> GetSubmissionsByTestId(int maBaiKT)
        {
            List<BaiLamDTO> submissions = new List<BaiLamDTO>();
            
            try
            {
                // Query to get all submissions with student information
                string query = @"
                    SELECT bl.*, hs.HoTen AS TenHocSinh, lh.TenLop
                    FROM BaiLam bl
                    INNER JOIN HocSinh hs ON bl.MaHS = hs.MaHS
                    INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                    WHERE bl.MaBaiKT = @MaBaiKT
                    ORDER BY bl.NgayLam DESC";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT }
                };
                
                DataTable dt = db.ExecuteQuery(query, parameters);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        BaiLamDTO submission = new BaiLamDTO
                        {
                            MaBaiLam = Convert.ToInt32(row["MaBaiLam"]),
                            MaBaiKT = maBaiKT,
                            MaHS = Convert.ToInt32(row["MaHS"]),
                            TenHocSinh = row["TenHocSinh"].ToString(),
                            TenLop = row["TenLop"].ToString(),
                            NgayLam = Convert.ToDateTime(row["NgayLam"]),
                            ThoiGianLamBai = Convert.ToInt32(row["ThoiGianLamBai"]),
                            DiemSo = row["DiemSo"] != DBNull.Value ? Convert.ToDouble(row["DiemSo"]) : (double?)null,
                            DaNop = Convert.ToBoolean(row["DaNop"])
                        };
                        
                        submissions.Add(submission);
                    }
                }
                
                return submissions;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting submissions: {ex.Message}");
                return submissions;
            }
        }
        
        /// <summary>
        /// Get a specific student submission by ID
        /// </summary>
        /// <param name="maBaiLam">Submission ID</param>
        /// <returns>The submission data</returns>
        public BaiLamDTO GetSubmissionById(int maBaiLam)
        {
            try
            {
                string query = @"
                    SELECT bl.*, hs.HoTen AS TenHocSinh, lh.TenLop, bkt.TenBaiKT
                    FROM BaiLam bl
                    INNER JOIN HocSinh hs ON bl.MaHS = hs.MaHS
                    INNER JOIN LopHoc lh ON hs.MaLop = lh.MaLop
                    INNER JOIN BaiKiemTra bkt ON bl.MaBaiKT = bkt.MaBaiKT
                    WHERE bl.MaBaiLam = @MaBaiLam";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiLam", maBaiLam }
                };
                
                DataTable dt = db.ExecuteQuery(query, parameters);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    
                    BaiLamDTO submission = new BaiLamDTO
                    {
                        MaBaiLam = maBaiLam,
                        MaBaiKT = Convert.ToInt32(row["MaBaiKT"]),
                        TenBaiKT = row["TenBaiKT"].ToString(),
                        MaHS = Convert.ToInt32(row["MaHS"]),
                        TenHocSinh = row["TenHocSinh"].ToString(),
                        TenLop = row["TenLop"].ToString(),
                        NgayLam = Convert.ToDateTime(row["NgayLam"]),
                        ThoiGianLamBai = Convert.ToInt32(row["ThoiGianLamBai"]),
                        DiemSo = row["DiemSo"] != DBNull.Value ? Convert.ToDouble(row["DiemSo"]) : (double?)null,
                        DaNop = Convert.ToBoolean(row["DaNop"])
                    };
                    
                    // Load multiple choice answers
                    submission.CauTraLoiTracNghiem = GetMultipleChoiceAnswers(maBaiLam);
                    
                    // Load essay answers
                    submission.CauTraLoiTuLuan = GetEssayAnswers(maBaiLam);
                    
                    return submission;
                }
                
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting submission details: {ex.Message}");
                return null;
            }
        }
        
        public List<BaiLamTracNghiemDTO> GetMultipleChoiceAnswers(int maBaiLam)
        {
            List<BaiLamTracNghiemDTO> answers = new List<BaiLamTracNghiemDTO>();

            try
            {
                string query = @"
                    SELECT tn.*, ch.NoiDung, ch.Diem, tn.ThuTu
                    FROM BaiLam_TracNghiem tn
                    INNER JOIN CauHoiTracNghiem ch ON tn.MaCauHoiTN = ch.MaCauHoiTN
                    WHERE tn.MaBaiLam = @MaBaiLam
                    ORDER BY tn.ThuTu";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiLam", maBaiLam }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        BaiLamTracNghiemDTO answer = new BaiLamTracNghiemDTO
                        {
                            MaBaiLam = maBaiLam,
                            MaCauHoiTN = Convert.ToInt32(row["MaCauHoiTN"]),
                            NoiDungCauHoi = row["NoiDung"].ToString(),
                            CauTraLoi = row["CauTraLoi"] != DBNull.Value ? row["CauTraLoi"].ToString() : null,
                            Diem = row["Diem"] != DBNull.Value ? Convert.ToDouble(row["Diem"]) : (double?)null,
                            DiemToiDa = Convert.ToDouble(row["Diem"]),
                            ThuTu = row["ThuTu"] != DBNull.Value ? Convert.ToInt32(row["ThuTu"]) : 0
                        };

                        // Get the correct answer for this question
                        answer.DapAnDung = GetCorrectAnswer(answer.MaCauHoiTN);

                        // Get the question options
                        answer.DanhSachLuaChon = new List<LuaChonDTO>();

                        // Add options A, B, C, D
                        if (row["DapAnA"] != DBNull.Value)
                        {
                            answer.DanhSachLuaChon.Add(new LuaChonDTO
                            {
                                MaCauHoi = answer.MaCauHoiTN,
                                NoiDung = row["DapAnA"].ToString(),
                                NhanDang = "A",
                                LaDapAnDung = answer.DapAnDung == "A"
                            });
                        }

                        if (row["DapAnB"] != DBNull.Value)
                        {
                            answer.DanhSachLuaChon.Add(new LuaChonDTO
                            {
                                MaCauHoi = answer.MaCauHoiTN,
                                NoiDung = row["DapAnB"].ToString(),
                                NhanDang = "B",
                                LaDapAnDung = answer.DapAnDung == "B"
                            });
                        }

                        if (row["DapAnC"] != DBNull.Value)
                        {
                            answer.DanhSachLuaChon.Add(new LuaChonDTO
                            {
                                MaCauHoi = answer.MaCauHoiTN,
                                NoiDung = row["DapAnC"].ToString(),
                                NhanDang = "C",
                                LaDapAnDung = answer.DapAnDung == "C"
                            });
                        }

                        if (row["DapAnD"] != DBNull.Value)
                        {
                            answer.DanhSachLuaChon.Add(new LuaChonDTO
                            {
                                MaCauHoi = answer.MaCauHoiTN,
                                NoiDung = row["DapAnD"].ToString(),
                                NhanDang = "D",
                                LaDapAnDung = answer.DapAnDung == "D"
                            });
                        }

                        answers.Add(answer);
                    }
                }

                return answers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting multiple choice answers: {ex.Message}");
                return answers;
            }
        }
        
        private string GetCorrectAnswer(int maCauHoi)
        {
            try
            {
                string query = @"
                    SELECT DapAnDung
                    FROM CauHoiTracNghiem
                    WHERE MaCauHoiTN = @MaCauHoi";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaCauHoi", maCauHoi }
                };

                object result = db.ExecuteScalar(query, parameters);

                if (result != null && result != DBNull.Value)
                {
                    return result.ToString();
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting correct answer: {ex.Message}");
                return null;
            }
        }
        
        /// <summary>
        /// Get all options for a multiple choice question
        /// </summary>
        private List<LuaChonDTO> GetQuestionOptions(int maCauHoi)
        {
            List<LuaChonDTO> options = new List<LuaChonDTO>();
            
            try
            {
                string query = @"
                    SELECT * FROM LuaChon
                    WHERE MaCauHoi = @MaCauHoi
                    ORDER BY NhanDang";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaCauHoi", maCauHoi }
                };
                
                DataTable dt = db.ExecuteQuery(query, parameters);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        LuaChonDTO option = new LuaChonDTO
                        {
                            MaLuaChon = Convert.ToInt32(row["MaLuaChon"]),
                            MaCauHoi = maCauHoi,
                            NoiDung = row["NoiDung"].ToString(),
                            NhanDang = row["NhanDang"].ToString(),
                            LaDapAnDung = Convert.ToBoolean(row["LaDapAnDung"])
                        };
                        
                        options.Add(option);
                    }
                }
                
                return options;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting question options: {ex.Message}");
                return options;
            }
        }
                public List<BaiLamTuLuanDTO> GetEssayAnswers(int maBaiLam)
        {
            List<BaiLamTuLuanDTO> answers = new List<BaiLamTuLuanDTO>();

            try
            {
                string query = @"
                    SELECT tl.*, ch.NoiDung, ch.Diem as DiemSo, ctl.DapAn as HuongDanTraLoi
                    FROM BaiLam_TuLuan tl
                    INNER JOIN CauHoiTuLuan ch ON tl.MaCauHoiTL = ch.MaCauHoiTL
                    INNER JOIN CauHoiTuLuan ctl ON tl.MaCauHoiTL = ctl.MaCauHoiTL
                    WHERE tl.MaBaiLam = @MaBaiLam
                    ORDER BY tl.ThuTu";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiLam", maBaiLam }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        BaiLamTuLuanDTO answer = new BaiLamTuLuanDTO
                        {
                            MaBaiLam = maBaiLam,
                            MaCauHoiTL = Convert.ToInt32(row["MaCauHoiTL"]),
                            NoiDungCauHoi = row["NoiDung"].ToString(),
                            CauTraLoi = row["CauTraLoi"] != DBNull.Value ? row["CauTraLoi"].ToString() : null,
                            Diem = row["Diem"] != DBNull.Value ? Convert.ToDouble(row["Diem"]) : (double?)null,
                            DiemToiDa = Convert.ToDouble(row["DiemSo"]),
                            NhanXet = row["NhanXet"] != DBNull.Value ? row["NhanXet"].ToString() : null,
                            HuongDanTraLoi = row["HuongDanTraLoi"] != DBNull.Value ? row["HuongDanTraLoi"].ToString() : null,
                            ThuTu = row["ThuTu"] != DBNull.Value ? Convert.ToInt32(row["ThuTu"]) : 0
                        };

                        answers.Add(answer);
                    }
                }

                return answers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting essay answers: {ex.Message}");
                return answers;
            }
        }

        /// <summary>
        /// Update grades for multiple choice questions and calculate total score
        /// </summary>
        /// <param name="maBaiLam">Submission ID</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool AutoGradeMultipleChoice(int maBaiLam)
        {
            try
            {
                // Step 1: Get all multiple choice answers for this submission
                string getAnswersQuery = @"
            SELECT 
                bl_tn.MaCauHoiTN, bl_tn.CauTraLoi, 
                tn.DapAnDung, tn.Diem
            FROM 
                BaiLam_TracNghiem bl_tn
            INNER JOIN 
                CauHoiTracNghiem tn ON bl_tn.MaCauHoiTN = tn.MaCauHoiTN
            WHERE 
                bl_tn.MaBaiLam = @MaBaiLam";

                Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            { "@MaBaiLam", maBaiLam }
        };

                DataTable dt = db.ExecuteQuery(getAnswersQuery, parameters);

                // If no answers found, return success (nothing to grade)
                if (dt == null || dt.Rows.Count == 0)
                {
                    return true;
                }

                // Step 2: Grade each answer and update the score
                foreach (DataRow row in dt.Rows)
                {
                    int maCauHoiTN = Convert.ToInt32(row["MaCauHoiTN"]);
                    string cauTraLoi = row["CauTraLoi"] != DBNull.Value ? row["CauTraLoi"].ToString() : null;
                    string dapAnDung = row["DapAnDung"].ToString();
                    double diemToiDa = Convert.ToDouble(row["Diem"]);

                    // Calculate score: correct answer = full points, incorrect = 0
                    double diem = (cauTraLoi == dapAnDung) ? diemToiDa : 0;

                    // Update the score in the database
                    string updateScoreQuery = @"
                UPDATE BaiLam_TracNghiem
                SET Diem = @Diem
                WHERE MaBaiLam = @MaBaiLam AND MaCauHoiTN = @MaCauHoiTN";

                    Dictionary<string, object> updateParams = new Dictionary<string, object>
            {
                { "@MaBaiLam", maBaiLam },
                { "@MaCauHoiTN", maCauHoiTN },
                { "@Diem", diem }
            };

                    db.ExecuteNonQuery(updateScoreQuery, updateParams);
                }

                // Step 3: Update total score in BaiLam table
                CalculateTotalScore(maBaiLam);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error grading multiple choice questions: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Update grades for an essay question
        /// </summary>
        /// <param name="maBaiLam">Submission ID</param>
        /// <param name="maCauHoiTL">Question ID</param>
        /// <param name="diem">Score</param>
        /// <param name="nhanXet">Comment</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool UpdateEssayGrade(int maBaiLam, int maCauHoiTL, double diem, string nhanXet)
        {
            try
            {
                string updateQuery = @"
                    UPDATE BaiLam_TuLuan
                    SET Diem = @Diem, NhanXet = @NhanXet
                    WHERE MaBaiLam = @MaBaiLam AND MaCauHoiTL = @MaCauHoiTL";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiLam", maBaiLam },
                    { "@MaCauHoiTL", maCauHoiTL },
                    { "@Diem", diem },
                    { "@NhanXet", string.IsNullOrEmpty(nhanXet) ? DBNull.Value : (object)nhanXet }
                };
                
                return db.ExecuteNonQuery(updateQuery, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating essay grade: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Calculate total score and update the submission
        /// </summary>
        /// <param name="maBaiLam">Submission ID</param>
        /// <returns>The calculated total score</returns>
        public double CalculateTotalScore(int maBaiLam)
        {
            try
            {
                // Step 1: Calculate sum of multiple choice scores
                string mcScoreQuery = @"
            SELECT COALESCE(SUM(Diem), 0) AS TotalMCScore
            FROM BaiLam_TracNghiem
            WHERE MaBaiLam = @MaBaiLam";

                Dictionary<string, object> mcParams = new Dictionary<string, object>
        {
            { "@MaBaiLam", maBaiLam }
        };

                object mcResult = db.ExecuteScalar(mcScoreQuery, mcParams);
                double mcScore = (mcResult != null && mcResult != DBNull.Value) ? Convert.ToDouble(mcResult) : 0;

                // Step 2: Calculate sum of essay scores
                string essayScoreQuery = @"
            SELECT COALESCE(SUM(Diem), 0) AS TotalEssayScore
            FROM BaiLam_TuLuan
            WHERE MaBaiLam = @MaBaiLam";

                Dictionary<string, object> essayParams = new Dictionary<string, object>
        {
            { "@MaBaiLam", maBaiLam }
        };

                object essayResult = db.ExecuteScalar(essayScoreQuery, essayParams);
                double essayScore = (essayResult != null && essayResult != DBNull.Value) ? Convert.ToDouble(essayResult) : 0;

                // Step 3: Update total score
                double totalScore = mcScore + essayScore;

                string updateTotalQuery = @"
            UPDATE BaiLam
            SET DiemSo = @DiemSo
            WHERE MaBaiLam = @MaBaiLam";

                Dictionary<string, object> updateParams = new Dictionary<string, object>
        {
            { "@MaBaiLam", maBaiLam },
            { "@DiemSo", totalScore }
        };

                db.ExecuteNonQuery(updateTotalQuery, updateParams);

                return totalScore;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating total score: {ex.Message}");
                return 0;
            }
        }
        /// <summary>
        /// Check if all essay questions have been graded
        /// </summary>
        /// <param name="maBaiLam">Submission ID</param>
        /// <returns>True if all are graded, false otherwise</returns>
        public bool AreAllEssayQuestionsGraded(int maBaiLam)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) 
                    FROM BaiLam_TuLuan
                    WHERE MaBaiLam = @MaBaiLam AND Diem IS NULL";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiLam", maBaiLam }
                };
                
                object result = db.ExecuteScalar(query, parameters);
                int ungraded = Convert.ToInt32(result);
                
                return ungraded == 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking graded status: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Get statistics for a test (average score, max score, passing rate, etc.)
        /// </summary>
        /// <param name="maBaiKT">Test ID</param>
        /// <returns>Dictionary with statistics</returns>
        public Dictionary<string, object> GetTestStatistics(int maBaiKT)
        {
            Dictionary<string, object> stats = new Dictionary<string, object>();
            
            try
            {
                // Get the test information
                string testQuery = @"
                    SELECT TenBaiKT, DiemDatYeuCau
                    FROM BaiKiemTra
                    WHERE MaBaiKT = @MaBaiKT";
                
                Dictionary<string, object> testParams = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT }
                };
                
                DataTable testDt = db.ExecuteQuery(testQuery, testParams);
                
                if (testDt != null && testDt.Rows.Count > 0)
                {
                    stats["TenBaiKT"] = testDt.Rows[0]["TenBaiKT"].ToString();
                    stats["DiemDatYeuCau"] = Convert.ToDouble(testDt.Rows[0]["DiemDatYeuCau"]);
                }
                
                // Get submission statistics
                string statsQuery = @"
                    SELECT 
                        COUNT(*) AS TongBaiLam,
                        COUNT(CASE WHEN DiemSo IS NOT NULL THEN 1 END) AS SoBaiDaCham,
                        AVG(DiemSo) AS DiemTrungBinh,
                        MAX(DiemSo) AS DiemCaoNhat,
                        MIN(DiemSo) AS DiemThapNhat
                    FROM BaiLam
                    WHERE MaBaiKT = @MaBaiKT AND DaNop = 1";
                
                Dictionary<string, object> statsParams = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT }
                };
                
                DataTable statsDt = db.ExecuteQuery(statsQuery, statsParams);
                
                if (statsDt != null && statsDt.Rows.Count > 0)
                {
                    DataRow row = statsDt.Rows[0];
                    stats["TongBaiLam"] = Convert.ToInt32(row["TongBaiLam"]);
                    stats["SoBaiDaCham"] = Convert.ToInt32(row["SoBaiDaCham"]);
                    stats["DiemTrungBinh"] = row["DiemTrungBinh"] != DBNull.Value ? Convert.ToDouble(row["DiemTrungBinh"]) : 0;
                    stats["DiemCaoNhat"] = row["DiemCaoNhat"] != DBNull.Value ? Convert.ToDouble(row["DiemCaoNhat"]) : 0;
                    stats["DiemThapNhat"] = row["DiemThapNhat"] != DBNull.Value ? Convert.ToDouble(row["DiemThapNhat"]) : 0;
                    
                    // Calculate passing rate if passing score is known
                    if (stats.ContainsKey("DiemDatYeuCau"))
                    {
                        double passingScore = (double)stats["DiemDatYeuCau"];
                        
                        string passingQuery = @"
                            SELECT COUNT(*) 
                            FROM BaiLam
                            WHERE MaBaiKT = @MaBaiKT 
                              AND DaNop = 1
                              AND DiemSo >= @DiemDatYeuCau";
                        
                        Dictionary<string, object> passingParams = new Dictionary<string, object>
                        {
                            { "@MaBaiKT", maBaiKT },
                            { "@DiemDatYeuCau", passingScore }
                        };
                        
                        object passingResult = db.ExecuteScalar(passingQuery, passingParams);
                        int passingCount = Convert.ToInt32(passingResult);
                        
                        int totalCount = Convert.ToInt32(stats["TongBaiLam"]);
                        double passingRate = totalCount > 0 ? (double)passingCount / totalCount : 0;
                        
                        stats["SoLuongDat"] = passingCount;
                        stats["TyLeDat"] = passingRate;
                    }
                }
                
                return stats;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting test statistics: {ex.Message}");
                return stats;
            }
        }
        /// <summary>
        /// Get all submissions for a specific student
        /// </summary>
        /// <param name="maHS">Student ID</param>
        /// <returns>List of submissions</returns>
        public List<BaiLamDTO> GetSubmissionsByStudent(int maHS)
        {
            List<BaiLamDTO> submissions = new List<BaiLamDTO>();

            try
            {
                string query = @"
                    SELECT bl.*, bk.TenBaiKT
                    FROM BaiLam bl
                    INNER JOIN BaiKiemTra bk ON bl.MaBaiKT = bk.MaBaiKT
                    WHERE bl.MaHS = @MaHS
                    ORDER BY bl.NgayLam DESC";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaHS", maHS }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        BaiLamDTO submission = new BaiLamDTO
                        {
                            MaBaiLam = Convert.ToInt32(row["MaBaiLam"]),
                            MaBaiKT = Convert.ToInt32(row["MaBaiKT"]),
                            TenBaiKT = row["TenBaiKT"].ToString(),
                            MaHS = maHS,
                            NgayLam = Convert.ToDateTime(row["NgayLam"]),
                            ThoiGianLamBai = Convert.ToInt32(row["ThoiGianLamBai"]),
                            DiemSo = row["DiemSo"] != DBNull.Value ? Convert.ToDouble(row["DiemSo"]) : (double?)null,
                            DaNop = Convert.ToBoolean(row["DaNop"])
                        };

                        submissions.Add(submission);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving submissions for student: {ex.Message}");
            }

            return submissions;
        }
        /// <summary>
        /// Updates the DiemSo table with the score from a completed test
        /// </summary>
        /// <param name="maBaiLam">Submission ID</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool SaveTestScoreToDiemSo(int maBaiLam)
        {
            try
            {
                // First, get the necessary information about the submission and test
                string query = @"
                    SELECT 
                        bl.MaBaiLam, 
                        bl.MaHS, 
                        bl.DiemSo, 
                        bk.MaMon, 
                        bk.MaGV, 
                        DATEPART(MONTH, bl.NgayLam) as ThangLam
                    FROM 
                        BaiLam bl
                    INNER JOIN 
                        BaiKiemTra bk ON bl.MaBaiKT = bk.MaBaiKT
                    WHERE 
                        bl.MaBaiLam = @MaBaiLam 
                        AND bl.DiemSo IS NOT NULL";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiLam", maBaiLam }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt == null || dt.Rows.Count == 0)
                {
                    return false; // No submission found or score is null
                }

                DataRow row = dt.Rows[0];

                // Determine the semester based on the month
                int month = Convert.ToInt32(row["ThangLam"]);
                int hocKy = (month >= 9 && month <= 12) || (month == 1) ? 1 : 2;

                // Create a DiemSo entry
                DiemSoDAO diemSoDao = new DiemSoDAO();
                DiemSoDTO diemSo = new DiemSoDTO
                {
                    MaHS = Convert.ToInt32(row["MaHS"]),
                    MaMon = Convert.ToInt32(row["MaMon"]),  // Ensure this column name matches the database
                    MaGV = Convert.ToInt32(row["MaGV"]),
                    HocKy = hocKy,
                    LoaiDiem = "Cuối kỳ", // Or another appropriate type
                    Diem = (float)Convert.ToDouble(row["DiemSo"])
                };

                // Save to DiemSo table
                return diemSoDao.AddScore(diemSo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving test score to DiemSo: {ex.Message}");
                return false;
            }
        }
    }
}
