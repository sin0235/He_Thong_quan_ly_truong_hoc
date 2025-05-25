using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTruongHoc.DTO;

namespace QuanLyTruongHoc.DAL
{
    public class BaiKiemTraDAO
    {
        private DatabaseHelper db;
        
        public BaiKiemTraDAO()
        {
            db = new DatabaseHelper();
            // Đảm bảo các bảng cần thiết tồn tại
            EnsureTablesExist();
        }
        
        /// <summary>
        /// Create a new test/quiz in the database
        /// </summary>
        /// <param name="baiKiemTra">The test/quiz data to save</param>
        /// <returns>ID of the created test or -1 if failed</returns>
        public int CreateBaiKiemTra(BaiKiemTraDTO baiKiemTra)
        {
            try
            {
                // Standardize the status to Vietnamese
                string standardizedStatus = baiKiemTra.TrangThai;
                if (baiKiemTra.TrangThai == "Published")
                    standardizedStatus = "Đã công bố";
                else if (baiKiemTra.TrangThai == "Draft")
                    standardizedStatus = "Chưa công bố";

                // 1. Tạo bài kiểm tra với các thuộc tính mới
                string insertTestQuery = @"
                INSERT INTO BaiKiemTra (
                    MaGV, TenBaiKT, MoTa, ThoiGianLamBai, 
                    MaMon, TrangThai, NgayTao, HocKy, NamHoc,
                    ThoiGianBatDau, ThoiGianKetThuc, DiemDatYeuCau, 
                    SoLanLamToiDa, LoaiBaiKiemTra, HienThiKetQuaNgay, 
                    XaoTronCauHoi, GhiChuChamDiem, CoMatKhau, MatKhau
                )
                VALUES (
                    @MaGV, @TenBaiKT, @MoTa, @ThoiGianLamBai, 
                    @MaMH, @TrangThai, GETDATE(), @HocKy, @NamHoc,
                    @ThoiGianBatDau, @ThoiGianKetThuc, @DiemDatYeuCau, 
                    @SoLanLamToiDa, @LoaiBaiKiemTra, @HienThiKetQuaNgay, 
                    @XaoTronCauHoi, @GhiChuChamDiem, @CoMatKhau, @MatKhau
                );
                SELECT SCOPE_IDENTITY();";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaGV", baiKiemTra.MaGV },
                    { "@TenBaiKT", baiKiemTra.TenBaiKT },
                    { "@MoTa", string.IsNullOrEmpty(baiKiemTra.MoTa) ? DBNull.Value : (object)baiKiemTra.MoTa },
                    { "@ThoiGianLamBai", baiKiemTra.ThoiGianLamBai },
                    { "@MaMH", baiKiemTra.MaMH },
                    { "@TrangThai", standardizedStatus },
                    { "@HocKy", baiKiemTra.HocKy },
                    { "@NamHoc", baiKiemTra.NamHoc },
                    { "@ThoiGianBatDau", baiKiemTra.ThoiGianBatDau },
                    { "@ThoiGianKetThuc", baiKiemTra.ThoiGianKetThuc },
                    { "@DiemDatYeuCau", baiKiemTra.DiemDatYeuCau },
                    { "@SoLanLamToiDa", baiKiemTra.SoLanLamToiDa },
                    { "@LoaiBaiKiemTra", string.IsNullOrEmpty(baiKiemTra.LoaiBaiKT) ? DBNull.Value : (object)baiKiemTra.LoaiBaiKT },
                    { "@HienThiKetQuaNgay", baiKiemTra.HienThiKetQuaNgay },
                    { "@XaoTronCauHoi", baiKiemTra.XaoTronCauHoi },
                    { "@GhiChuChamDiem", string.IsNullOrEmpty(baiKiemTra.GhiChuChamDiem) ? DBNull.Value : (object)baiKiemTra.GhiChuChamDiem },
                    { "@CoMatKhau", baiKiemTra.CoMatKhau },
                    { "@MatKhau", string.IsNullOrEmpty(baiKiemTra.MatKhau) ? DBNull.Value : (object)baiKiemTra.MatKhau }
                };

                int maBaiKT = db.ExecuteInsertAndGetId(insertTestQuery, parameters);

                // 2. Liên kết bài kiểm tra với lớp học
                if (maBaiKT > 0)
                {
                    DateTime ngayKiemTra = baiKiemTra.ThoiGianBatDau != DateTime.MinValue ?
                        baiKiemTra.ThoiGianBatDau : DateTime.Now;

                    string insertClassTestQuery = @"
                    INSERT INTO BaiKiemTra_LopHoc (
                        MaBaiKT, MaLop, NgayKiemTra, TrangThai
                    )
                    VALUES (
                        @MaBaiKT, @MaLop, @NgayKiemTra, @TrangThaiLop
                    )";

                    Dictionary<string, object> classParams = new Dictionary<string, object>
                    {
                        { "@MaBaiKT", maBaiKT },
                        { "@MaLop", baiKiemTra.MaLop },
                        { "@NgayKiemTra", ngayKiemTra },
                        { "@TrangThaiLop", "Đã công bố" }
                    };

                    bool success = db.ExecuteNonQuery(insertClassTestQuery, classParams);

                    if (!success)
                    {
                        // Xóa bài kiểm tra nếu không thể liên kết với lớp học
                        string deleteQuery = $"DELETE FROM BaiKiemTra WHERE MaBaiKT = {maBaiKT}";
                        db.ExecuteNonQuery(deleteQuery);
                        return -1;
                    }

                    // Thêm các câu hỏi
                    if (baiKiemTra.DanhSachCauHoi.Count > 0)
                    {
                        int thuTu = 1;
                        foreach (var cauHoi in baiKiemTra.DanhSachCauHoi)
                        {
                            cauHoi.MaBaiKT = maBaiKT;
                            cauHoi.ThuTu = thuTu++;

                            if (cauHoi is CauHoiTracNghiemDTO)
                            {
                                AddMultipleChoiceQuestion(cauHoi as CauHoiTracNghiemDTO);
                            }
                            else if (cauHoi is CauHoiTuLuanDTO)
                            {
                                AddEssayQuestion(cauHoi as CauHoiTuLuanDTO);
                            }
                        }
                    }
                }

                return maBaiKT;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating test: {ex.Message}");
                return -1;
            }
        }
        
        /// <summary>
        /// Add a multiple-choice question to the database
        /// </summary>
        /// <param name="question">The multiple-choice question data</param>
        /// <returns>ID of the created question or -1 if failed</returns>
        public int AddMultipleChoiceQuestion(CauHoiTracNghiemDTO question)
        {
            try
            {
                Console.WriteLine($"Thêm câu hỏi trắc nghiệm: {question.NoiDung}");
                
                // Kiểm tra loại câu hỏi
                string normalizedType = ValidateQuestionType(question.LoaiCauHoi);
                if (normalizedType == null || normalizedType != "TN")
                {
                    Console.WriteLine($"Loại câu hỏi không hợp lệ: {question.LoaiCauHoi}");
                    question.LoaiCauHoi = "TN"; // Chuẩn hóa loại câu hỏi
                }

                // Lấy thông tin môn học và giáo viên từ bài kiểm tra nếu chưa được cung cấp
                if (question.MaMH <= 0 || question.MaGV <= 0)
                {
                    BaiKiemTraDTO baiKiemTra = GetBaiKiemTraById(question.MaBaiKT);
                    if (baiKiemTra != null)
                    {
                        if (question.MaMH <= 0)
                            question.MaMH = baiKiemTra.MaMH;
                        if (question.MaGV <= 0)
                            question.MaGV = baiKiemTra.MaGV;
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy thông tin bài kiểm tra");
                        return -1;
                    }
                }

                // Kiểm tra danh sách lựa chọn
                if (question.DanhSachLuaChon.Count < 2)
                {
                    Console.WriteLine("Câu hỏi trắc nghiệm phải có ít nhất 2 lựa chọn");
                    return -1;
                }

                // Tìm đáp án A, B, C, D
                string dapAnA = "", dapAnB = "", dapAnC = "", dapAnD = "";
                foreach (var luaChon in question.DanhSachLuaChon)
                {
                    switch (luaChon.NhanDang.ToUpper())
                    {
                        case "A":
                            dapAnA = luaChon.NoiDung;
                            break;
                        case "B":
                            dapAnB = luaChon.NoiDung;
                            break;
                        case "C":
                            dapAnC = luaChon.NoiDung;
                            break;
                        case "D":
                            dapAnD = luaChon.NoiDung;
                            break;
                    }
                }

                // Kiểm tra đáp án A, B phải có dữ liệu
                if (string.IsNullOrEmpty(dapAnA) || string.IsNullOrEmpty(dapAnB))
                {
                    Console.WriteLine("Đáp án A và B là bắt buộc");
                    return -1;
                }

                // Truy vấn thêm câu hỏi trắc nghiệm
                string insertQuestionQuery = @"
                    INSERT INTO CauHoiTracNghiem (
                        NoiDung, DapAnA, DapAnB, DapAnC, DapAnD, 
                        DapAnDung, Diem, DoKho, NgayTao, MaMon, MaGV
                    )
                    VALUES (
                        @NoiDung, @DapAnA, @DapAnB, @DapAnC, @DapAnD, 
                        @DapAnDung, @Diem, @DoKho, GETDATE(), @MaMon, @MaGV
                    );
                    SELECT SCOPE_IDENTITY();";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@NoiDung", question.NoiDung },
                    { "@DapAnA", dapAnA },
                    { "@DapAnB", dapAnB },
                    { "@DapAnC", string.IsNullOrEmpty(dapAnC) ? DBNull.Value : (object)dapAnC },
                    { "@DapAnD", string.IsNullOrEmpty(dapAnD) ? DBNull.Value : (object)dapAnD },
                    { "@DapAnDung", question.DapAnDung.ToUpper() },
                    { "@Diem", question.DiemSo },
                    { "@DoKho", 3 }, // Mức độ khó mặc định là 3 (trung bình)
                    { "@MaMon", question.MaMH },
                    { "@MaGV", question.MaGV }
                };

                int maCauHoiTN = db.ExecuteInsertAndGetId(insertQuestionQuery, parameters);

                if (maCauHoiTN <= 0)
                {
                    Console.WriteLine("Thêm câu hỏi trắc nghiệm thất bại");
                    return -1; // Thêm câu hỏi thất bại
                }

                // Liên kết câu hỏi với bài kiểm tra
                string insertLinkQuery = @"
                    INSERT INTO BaiKiemTra_CauHoi (
                        MaBaiKT, MaCauHoiTN, MaCauHoiTL, ThuTu
                    )
                    VALUES (
                        @MaBaiKT, @MaCauHoiTN, NULL, @ThuTu
                    );";

                Dictionary<string, object> linkParameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", question.MaBaiKT },
                    { "@MaCauHoiTN", maCauHoiTN },
                    { "@ThuTu", question.ThuTu }
                };

                bool linkSuccess = db.ExecuteNonQuery(insertLinkQuery, linkParameters);

                if (!linkSuccess)
                {
                    // Nếu liên kết thất bại, xóa câu hỏi đã thêm
                    string deleteQuery = $"DELETE FROM CauHoiTracNghiem WHERE MaCauHoiTN = {maCauHoiTN}";
                    db.ExecuteNonQuery(deleteQuery);
                    Console.WriteLine("Liên kết câu hỏi với bài kiểm tra thất bại");
                    return -1;
                }

                question.MaCauHoi = maCauHoiTN; // Cập nhật ID câu hỏi
                Console.WriteLine($"Đã thêm câu hỏi trắc nghiệm ID: {maCauHoiTN}");
                return maCauHoiTN;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm câu hỏi trắc nghiệm: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return -1;
            }
        }
        
        /// <summary>
        /// Add an essay question to the database
        /// </summary>
        /// <param name="question">The essay question data</param>
        /// <returns>ID of the created question or -1 if failed</returns>
        public int AddEssayQuestion(CauHoiTuLuanDTO question)
        {
            try
            {
                Console.WriteLine($"Thêm câu hỏi tự luận: {question.NoiDung}");
                
                // Kiểm tra loại câu hỏi
                string normalizedType = ValidateQuestionType(question.LoaiCauHoi);
                if (normalizedType == null || normalizedType != "TL")
                {
                    Console.WriteLine($"Loại câu hỏi không hợp lệ: {question.LoaiCauHoi}");
                    question.LoaiCauHoi = "TL"; // Chuẩn hóa loại câu hỏi
                }
                
                // Lấy thông tin môn học và giáo viên từ bài kiểm tra nếu chưa được cung cấp
                if (question.MaMH <= 0 || question.MaGV <= 0)
                {
                    BaiKiemTraDTO baiKiemTra = GetBaiKiemTraById(question.MaBaiKT);
                    if (baiKiemTra != null)
                    {
                        if (question.MaMH <= 0)
                            question.MaMH = baiKiemTra.MaMH;
                        if (question.MaGV <= 0)
                            question.MaGV = baiKiemTra.MaGV;
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy thông tin bài kiểm tra");
                        return -1;
                    }
                }
                
                // Đảm bảo các bảng tồn tại trước khi thêm câu hỏi
                EnsureTablesExist();
                
                // Truy vấn thêm câu hỏi tự luận
                string insertQuestionQuery = @"
                    INSERT INTO CauHoiTuLuan (
                        NoiDung, DapAn, Diem, DoKho, NgayTao, MaMon, MaGV
                    )
                    VALUES (
                        @NoiDung, @DapAn, @Diem, @DoKho, GETDATE(), @MaMon, @MaGV
                    );
                    SELECT SCOPE_IDENTITY();";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@NoiDung", question.NoiDung },
                    { "@DapAn", string.IsNullOrEmpty(question.HuongDanTraLoi) ? DBNull.Value : (object)question.HuongDanTraLoi },
                    { "@Diem", question.DiemSo },
                    { "@DoKho", 3 }, // Mức độ khó mặc định là 3 (trung bình)
                    { "@MaMon", question.MaMH },
                    { "@MaGV", question.MaGV }
                };
                
                int maCauHoiTL = db.ExecuteInsertAndGetId(insertQuestionQuery, parameters);
                
                if (maCauHoiTL <= 0)
                {
                    Console.WriteLine("Thêm câu hỏi tự luận thất bại");
                    return -1; // Thêm câu hỏi thất bại
                }
                
                // Liên kết câu hỏi với bài kiểm tra
                string insertLinkQuery = @"
                    INSERT INTO BaiKiemTra_CauHoi (
                        MaBaiKT, MaCauHoiTN, MaCauHoiTL, ThuTu
                    )
                    VALUES (
                        @MaBaiKT, NULL, @MaCauHoiTL, @ThuTu
                    );";
                
                Dictionary<string, object> linkParameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", question.MaBaiKT },
                    { "@MaCauHoiTL", maCauHoiTL },
                    { "@ThuTu", question.ThuTu }
                };
                
                bool linkSuccess = db.ExecuteNonQuery(insertLinkQuery, linkParameters);
                
                if (!linkSuccess)
                {
                    // Nếu liên kết thất bại, xóa câu hỏi đã thêm
                    string deleteQuery = $"DELETE FROM CauHoiTuLuan WHERE MaCauHoiTL = {maCauHoiTL}";
                    db.ExecuteNonQuery(deleteQuery);
                    Console.WriteLine("Liên kết câu hỏi với bài kiểm tra thất bại");
                    return -1;
                }
                
                question.MaCauHoi = maCauHoiTL; // Cập nhật ID câu hỏi
                Console.WriteLine($"Đã thêm câu hỏi tự luận ID: {maCauHoiTL}");
                return maCauHoiTL;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm câu hỏi tự luận: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return -1;
            }
        }
        
        /// <summary>
        /// Get a test/quiz by ID
        /// </summary>
        /// <param name="maBaiKT">ID of the test to retrieve</param>
        /// <returns>The test data or null if not found</returns>
        public BaiKiemTraDTO GetBaiKiemTraById(int maBaiKT)
        {
            try
            {
                string query = @"
                    SELECT 
                        bk.*, 
                        mh.TenMon AS TenMonHoc, 
                        lh.TenLop AS TenLop,
                        bkl.MaLop,
                        bkl.NgayKiemTra AS ThoiGianBatDau,
                        bk.ThoiGianKetThuc
                    FROM 
                        BaiKiemTra bk
                    LEFT JOIN 
                        MonHoc mh ON bk.MaMon = mh.MaMon
                    LEFT JOIN 
                        BaiKiemTra_LopHoc bkl ON bk.MaBaiKT = bkl.MaBaiKT
                    LEFT JOIN 
                        LopHoc lh ON bkl.MaLop = lh.MaLop
                    WHERE 
                        bk.MaBaiKT = @MaBaiKT";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT }
                };
                
                DataTable dt = db.ExecuteQuery(query, parameters);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    
                    BaiKiemTraDTO baiKiemTra = new BaiKiemTraDTO
                    {
                        MaBaiKT = maBaiKT,
                        TenBaiKT = row["TenBaiKT"].ToString(),
                        MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null,
                        MaGV = Convert.ToInt32(row["MaGV"]),
                        MaMH = Convert.ToInt32(row["MaMon"]),
                        TenMonHoc = row["TenMonHoc"] != DBNull.Value ? row["TenMonHoc"].ToString() : "",
                        LoaiBaiKT = row["LoaiBaiKiemTra"].ToString(),
                        ThoiGianLamBai = Convert.ToInt32(row["ThoiGianLamBai"]),
                        SoLanLamToiDa = Convert.ToInt32(row["SoLanLamToiDa"]),
                        DiemDatYeuCau = Convert.ToDouble(row["DiemDatYeuCau"]),
                        HienThiKetQuaNgay = Convert.ToBoolean(row["HienThiKetQuaNgay"]),
                        XaoTronCauHoi = Convert.ToBoolean(row["XaoTronCauHoi"]),
                        GhiChuChamDiem = row["GhiChuChamDiem"] != DBNull.Value ? row["GhiChuChamDiem"].ToString() : null,
                        CoMatKhau = Convert.ToBoolean(row["CoMatKhau"]),
                        MatKhau = row["MatKhau"] != DBNull.Value ? row["MatKhau"].ToString() : null,
                        TrangThai = row["TrangThai"].ToString(),
                        NgayTao = Convert.ToDateTime(row["NgayTao"]),
                        HocKy = Convert.ToInt32(row["HocKy"]),
                        NamHoc = row["NamHoc"].ToString(),
                        ThoiGianKetThuc = row["ThoiGianKetThuc"] != DBNull.Value ? Convert.ToDateTime(row["ThoiGianKetThuc"]) : DateTime.MinValue
                    };
                    
                    // Handle class information if available in the join
                    if (row["MaLop"] != DBNull.Value)
                    {
                        baiKiemTra.MaLop = Convert.ToInt32(row["MaLop"]);
                        baiKiemTra.TenLop = row["TenLop"].ToString();
                        
                        // Get test schedule from BaiKiemTra_LopHoc
                        if (row["ThoiGianBatDau"] != DBNull.Value)
                        {
                            baiKiemTra.ThoiGianBatDau = Convert.ToDateTime(row["ThoiGianBatDau"]);
                            // ThoiGianKetThuc được lấy trực tiếp từ cơ sở dữ liệu trong constructor
                        }
                    }
                    
                    // Load questions
                    baiKiemTra.DanhSachCauHoi = GetQuestionsByTestId(maBaiKT);
                    
                    return baiKiemTra;
                }
                
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving test: {ex.Message}");
                return null;
            }
        }
        
        /// <summary>
        /// Get all questions for a specific test
        /// </summary>
        /// <param name="maBaiKT">ID of the test</param>
        /// <returns>List of questions</returns>
        public List<CauHoiDTO> GetQuestionsByTestId(int maBaiKT)
        {
            List<CauHoiDTO> questions = new List<CauHoiDTO>();
            
            try
            {
                Console.WriteLine($"Bắt đầu lấy danh sách câu hỏi cho bài kiểm tra ID: {maBaiKT}");
                
                // Lấy danh sách liên kết câu hỏi với bài kiểm tra
                string query = @"
                    SELECT * FROM BaiKiemTra_CauHoi
                    WHERE MaBaiKT = @MaBaiKT
                    ORDER BY ThuTu";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT }
                };
                
                DataTable dt = db.ExecuteQuery(query, parameters);
                
                Console.WriteLine($"Kết quả truy vấn liên kết: {(dt == null ? "NULL" : dt.Rows.Count + " dòng")}");
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int thuTu = Convert.ToInt32(row["ThuTu"]);
                        
                        // Kiểm tra loại câu hỏi (trắc nghiệm hoặc tự luận)
                        if (row["MaCauHoiTN"] != DBNull.Value)
                        {
                            // Xử lý câu hỏi trắc nghiệm
                            int maCauHoiTN = Convert.ToInt32(row["MaCauHoiTN"]);
                            CauHoiTracNghiemDTO question = GetMultipleChoiceQuestion(maCauHoiTN);
                            
                            if (question != null)
                            {
                                question.MaBaiKT = maBaiKT;
                                question.ThuTu = thuTu;
                                questions.Add(question);
                            }
                        }
                        else if (row["MaCauHoiTL"] != DBNull.Value)
                        {
                            // Xử lý câu hỏi tự luận
                            int maCauHoiTL = Convert.ToInt32(row["MaCauHoiTL"]);
                            CauHoiTuLuanDTO question = GetEssayQuestion(maCauHoiTL);
                            
                            if (question != null)
                            {
                                question.MaBaiKT = maBaiKT;
                                question.ThuTu = thuTu;
                                questions.Add(question);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Không có thông tin câu hỏi cho thứ tự {thuTu}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Không có câu hỏi nào cho bài kiểm tra ID: {maBaiKT}");
                }
                
                Console.WriteLine($"Kết thúc lấy danh sách câu hỏi. Tổng số: {questions.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách câu hỏi: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
            
            return questions;
        }
        
        /// <summary>
        /// Lấy thông tin câu hỏi trắc nghiệm từ cơ sở dữ liệu
        /// </summary>
        /// <param name="maCauHoiTN">ID câu hỏi trắc nghiệm</param>
        /// <returns>Đối tượng câu hỏi trắc nghiệm hoặc null nếu không tìm thấy</returns>
        private CauHoiTracNghiemDTO GetMultipleChoiceQuestion(int maCauHoiTN)
        {
            try
            {
                string query = @"
                    SELECT * FROM CauHoiTracNghiem
                    WHERE MaCauHoiTN = @MaCauHoiTN";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaCauHoiTN", maCauHoiTN }
                };
                
                DataTable dt = db.ExecuteQuery(query, parameters);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    
                    CauHoiTracNghiemDTO question = new CauHoiTracNghiemDTO
                    {
                        MaCauHoi = maCauHoiTN,
                        LoaiCauHoi = "TN",
                        NoiDung = row["NoiDung"].ToString(),
                        DiemSo = Convert.ToDouble(row["Diem"]),
                        DapAnDung = row["DapAnDung"].ToString()
                    };
                    
                    // Tạo danh sách lựa chọn từ dữ liệu trong bảng
                    List<LuaChonDTO> options = new List<LuaChonDTO>();
                    
                    if (row["DapAnA"] != DBNull.Value)
                    {
                        options.Add(new LuaChonDTO 
                        { 
                            MaCauHoi = maCauHoiTN,
                            NhanDang = "A",
                            NoiDung = row["DapAnA"].ToString(),
                            LaDapAnDung = row["DapAnDung"].ToString() == "A"
                        });
                    }
                    
                    if (row["DapAnB"] != DBNull.Value)
                    {
                        options.Add(new LuaChonDTO 
                        { 
                            MaCauHoi = maCauHoiTN,
                            NhanDang = "B",
                            NoiDung = row["DapAnB"].ToString(),
                            LaDapAnDung = row["DapAnDung"].ToString() == "B"
                        });
                    }
                    
                    if (row["DapAnC"] != DBNull.Value)
                    {
                        options.Add(new LuaChonDTO 
                        { 
                            MaCauHoi = maCauHoiTN,
                            NhanDang = "C",
                            NoiDung = row["DapAnC"].ToString(),
                            LaDapAnDung = row["DapAnDung"].ToString() == "C"
                        });
                    }
                    
                    if (row["DapAnD"] != DBNull.Value)
                    {
                        options.Add(new LuaChonDTO 
                        { 
                            MaCauHoi = maCauHoiTN,
                            NhanDang = "D",
                            NoiDung = row["DapAnD"].ToString(),
                            LaDapAnDung = row["DapAnDung"].ToString() == "D"
                        });
                    }
                    
                    question.DanhSachLuaChon = options;
                    
                    return question;
                }
                
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy câu hỏi trắc nghiệm: {ex.Message}");
                return null;
            }
        }
        
        /// <summary>
        /// Lấy thông tin câu hỏi tự luận từ cơ sở dữ liệu
        /// </summary>
        /// <param name="maCauHoiTL">ID câu hỏi tự luận</param>
        /// <returns>Đối tượng câu hỏi tự luận hoặc null nếu không tìm thấy</returns>
        private CauHoiTuLuanDTO GetEssayQuestion(int maCauHoiTL)
        {
            try
            {
                string query = @"
                    SELECT * FROM CauHoiTuLuan
                    WHERE MaCauHoiTL = @MaCauHoiTL";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaCauHoiTL", maCauHoiTL }
                };
                
                DataTable dt = db.ExecuteQuery(query, parameters);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    
                    CauHoiTuLuanDTO question = new CauHoiTuLuanDTO
                    {
                        MaCauHoi = maCauHoiTL,
                        LoaiCauHoi = "TL",
                        NoiDung = row["NoiDung"].ToString(),
                        DiemSo = Convert.ToDouble(row["Diem"]),
                        HuongDanTraLoi = row["DapAn"] != DBNull.Value ? row["DapAn"].ToString() : null,
                        // Sử dụng cấu trúc cũ để giữ tương thích với code hiện tại
                        CoGioiHanTu = false,
                        GioiHanTu = 500
                    };
                    
                    return question;
                }
                
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy câu hỏi tự luận: {ex.Message}");
                return null;
            }
        }
        
        /// <summary>
        /// Get all tests for a teacher
        /// </summary>
        /// <param name="maGV">ID of the teacher</param>
        /// <returns>List of tests</returns>
        public List<BaiKiemTraDTO> GetTestsByTeacher(int maGV)
        {
            List<BaiKiemTraDTO> tests = new List<BaiKiemTraDTO>();

            try
            {
                // Sửa câu truy vấn để không sử dụng bảng BaiKiemTra_CauHoi không tồn tại
                string query = @"
                    SELECT 
                        bk.*, 
                        mh.TenMon AS TenMonHoc,
                        (SELECT COUNT(*) FROM CauHoi WHERE MaBaiKT = bk.MaBaiKT) AS SoCauHoi
                    FROM 
                        BaiKiemTra bk
                    LEFT JOIN 
                        MonHoc mh ON bk.MaMon = mh.MaMon
                    WHERE 
                        bk.MaGV = @MaGV
                    ORDER BY 
                        bk.NgayTao DESC";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaGV", maGV }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        BaiKiemTraDTO test = new BaiKiemTraDTO
                        {
                            MaBaiKT = Convert.ToInt32(row["MaBaiKT"]),
                            TenBaiKT = row["TenBaiKT"].ToString(),
                            MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null,
                            MaGV = maGV,
                            MaMH = Convert.ToInt32(row["MaMon"]),
                            TenMonHoc = row["TenMonHoc"] != DBNull.Value ? row["TenMonHoc"].ToString() : "",
                            LoaiBaiKT = row["LoaiBaiKiemTra"] != DBNull.Value ? row["LoaiBaiKiemTra"].ToString() : "",
                            ThoiGianLamBai = Convert.ToInt32(row["ThoiGianLamBai"]),
                            NgayTao = Convert.ToDateTime(row["NgayTao"]),
                            TrangThai = row["TrangThai"].ToString(),
                            HocKy = row["HocKy"] != DBNull.Value ? Convert.ToInt32(row["HocKy"]) : 0,
                            NamHoc = row["NamHoc"] != DBNull.Value ? row["NamHoc"].ToString() : ""
                        };

                        // Thêm các trường tùy chọn nếu tồn tại trong schema
                        if (dt.Columns.Contains("SoLanLamToiDa"))
                            test.SoLanLamToiDa = Convert.ToInt32(row["SoLanLamToiDa"]);
                        if (dt.Columns.Contains("DiemDatYeuCau"))
                            test.DiemDatYeuCau = Convert.ToDouble(row["DiemDatYeuCau"]);
                        if (dt.Columns.Contains("ThoiGianBatDau"))
                            test.ThoiGianBatDau = Convert.ToDateTime(row["ThoiGianBatDau"]);
                        if (dt.Columns.Contains("ThoiGianKetThuc"))
                            test.ThoiGianKetThuc = Convert.ToDateTime(row["ThoiGianKetThuc"]);
                        if (dt.Columns.Contains("HienThiKetQuaNgay"))
                            test.HienThiKetQuaNgay = Convert.ToBoolean(row["HienThiKetQuaNgay"]);
                        if (dt.Columns.Contains("XaoTronCauHoi"))
                            test.XaoTronCauHoi = Convert.ToBoolean(row["XaoTronCauHoi"]);
                        if (dt.Columns.Contains("GhiChuChamDiem"))
                            test.GhiChuChamDiem = row["GhiChuChamDiem"] != DBNull.Value ? row["GhiChuChamDiem"].ToString() : null;
                        if (dt.Columns.Contains("CoMatKhau"))
                            test.CoMatKhau = Convert.ToBoolean(row["CoMatKhau"]);
                        if (dt.Columns.Contains("MatKhau"))
                            test.MatKhau = row["MatKhau"] != DBNull.Value ? row["MatKhau"].ToString() : null;

                        tests.Add(test);
                    }
                }

                return tests;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving tests for teacher: {ex.Message}");
                return tests;
            }
        }
        
        /// <summary>
        /// Update the status of a test
        /// </summary>
        /// <param name="maBaiKT">ID of the test</param>
        /// <param name="trangThai">New status</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool UpdateTestStatus(int maBaiKT, string trangThai)
        {
            try
            {
                // Standardize to Vietnamese status
                string standardizedStatus = trangThai;
                if (trangThai == "Published")
                    standardizedStatus = "Đã công bố";
                else if (trangThai == "Draft")
                    standardizedStatus = "Chưa công bố";

                string query = @"
                    UPDATE BaiKiemTra
                    SET TrangThai = @TrangThai
                    WHERE MaBaiKT = @MaBaiKT";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT },
                    { "@TrangThai", standardizedStatus }
                };
                
                return db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating test status: {ex.Message}");
                return false;
            }
        }
        
        /// <summary>
        /// Delete a test and all its questions
        /// </summary>
        /// <param name="maBaiKT">ID of the test to delete</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool DeleteTest(int maBaiKT)
        {
            try
            {
                Console.WriteLine($"Bắt đầu xóa bài kiểm tra ID: {maBaiKT}");
                
                // Lấy thông tin về các câu hỏi được liên kết với bài kiểm tra
                string getQuestionsQuery = @"
                    SELECT MaCauHoiTN, MaCauHoiTL FROM BaiKiemTra_CauHoi
                    WHERE MaBaiKT = @MaBaiKT";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT }
                };
                
                DataTable dt = db.ExecuteQuery(getQuestionsQuery, parameters);
                
                // Chuẩn bị câu lệnh xóa
                List<string> deleteCommands = new List<string>();
                
                // Xóa liên kết giữa bài kiểm tra và câu hỏi
                deleteCommands.Add($"DELETE FROM BaiKiemTra_CauHoi WHERE MaBaiKT = {maBaiKT}");
                
                // Xóa tất cả câu hỏi
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["MaCauHoiTN"] != DBNull.Value)
                        {
                            int maCauHoiTN = Convert.ToInt32(row["MaCauHoiTN"]);
                            deleteCommands.Add($"DELETE FROM CauHoiTracNghiem WHERE MaCauHoiTN = {maCauHoiTN}");
                        }
                        else if (row["MaCauHoiTL"] != DBNull.Value)
                        {
                            int maCauHoiTL = Convert.ToInt32(row["MaCauHoiTL"]);
                            deleteCommands.Add($"DELETE FROM CauHoiTuLuan WHERE MaCauHoiTL = {maCauHoiTL}");
                        }
                    }
                }
                
                // Xóa liên kết giữa bài kiểm tra và lớp học
                deleteCommands.Add($"DELETE FROM BaiKiemTra_LopHoc WHERE MaBaiKT = {maBaiKT}");
                
                // Xóa bài làm của học sinh nếu có
                deleteCommands.Add($"DELETE FROM BaiLam WHERE MaBaiKT = {maBaiKT}");
                
                // Cuối cùng xóa bài kiểm tra
                deleteCommands.Add($"DELETE FROM BaiKiemTra WHERE MaBaiKT = {maBaiKT}");
                
                bool success = db.ExecuteTransaction(deleteCommands);
                
                if (success)
                {
                    Console.WriteLine($"Đã xóa thành công bài kiểm tra ID: {maBaiKT}");
                }
                else
                {
                    Console.WriteLine($"Xóa bài kiểm tra ID: {maBaiKT} thất bại");
                }
                
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa bài kiểm tra: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return false;
            }
        }
        
        /// <summary>
        /// Make sure all required tables exist in the database
        /// </summary>
        private void EnsureTablesExist()
        {
            try
            {
                Console.WriteLine("Kiểm tra cấu trúc cơ sở dữ liệu...");
                
                // Kiểm tra bảng BaiKiemTra_CauHoi
                string checkBaiKiemTraCauHoiTable = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'BaiKiemTra_CauHoi')
                    BEGIN
                        CREATE TABLE BaiKiemTra_CauHoi (
                            MaBaiKT INT NOT NULL,
                            MaCauHoiTL INT NULL,
                            MaCauHoiTN INT NULL,
                            ThuTu INT NOT NULL,
                            CONSTRAINT PK_BaiKiemTra_CauHoi PRIMARY KEY (MaBaiKT, ThuTu),
                            CONSTRAINT FK_BaiKiemTra_CauHoi_BaiKT FOREIGN KEY (MaBaiKT) REFERENCES BaiKiemTra(MaBaiKT),
                            CONSTRAINT FK_BaiKiemTra_CauHoi_TL FOREIGN KEY (MaCauHoiTL) REFERENCES CauHoiTuLuan(MaCauHoiTL),
                            CONSTRAINT FK_BaiKiemTra_CauHoi_TN FOREIGN KEY (MaCauHoiTN) REFERENCES CauHoiTracNghiem(MaCauHoiTN),
                            CONSTRAINT CK_Either_TL_or_TN CHECK (
                                (MaCauHoiTL IS NULL AND MaCauHoiTN IS NOT NULL) OR
                                (MaCauHoiTL IS NOT NULL AND MaCauHoiTN IS NULL)
                            )
                        )
                    END";
                
                db.ExecuteNonQuery(checkBaiKiemTraCauHoiTable);
                
                // Kiểm tra bảng CauHoiTuLuan
                string checkCauHoiTuLuanTable = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CauHoiTuLuan')
                    BEGIN
                        CREATE TABLE CauHoiTuLuan (
                            MaCauHoiTL INT IDENTITY(1,1) PRIMARY KEY,
                            NoiDung NVARCHAR(MAX) NOT NULL,
                            DapAn NVARCHAR(MAX) NULL,
                            Diem FLOAT NOT NULL,
                            DoKho INT NOT NULL,
                            NgayTao DATETIME DEFAULT GETDATE(),
                            MaMon INT NOT NULL,
                            MaGV INT NOT NULL,
                            CONSTRAINT FK_CauHoiTL_MonHoc FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon),
                            CONSTRAINT FK_CauHoiTL_GiaoVien FOREIGN KEY (MaGV) REFERENCES GiaoVien(MaGV)
                        )
                    END";
                
                db.ExecuteNonQuery(checkCauHoiTuLuanTable);
                
                // Kiểm tra bảng CauHoiTracNghiem
                string checkCauHoiTracNghiemTable = @"
                    IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CauHoiTracNghiem')
                    BEGIN
                        CREATE TABLE CauHoiTracNghiem (
                            MaCauHoiTN INT IDENTITY(1,1) PRIMARY KEY,
                            NoiDung NVARCHAR(MAX) NOT NULL,
                            DapAnA NVARCHAR(500) NOT NULL,
                            DapAnB NVARCHAR(500) NOT NULL,
                            DapAnC NVARCHAR(500) NULL,
                            DapAnD NVARCHAR(500) NULL,
                            DapAnDung CHAR(1) NOT NULL,
                            Diem FLOAT NOT NULL,
                            DoKho INT NOT NULL,
                            NgayTao DATETIME DEFAULT GETDATE(),
                            MaMon INT NOT NULL,
                            MaGV INT NOT NULL,
                            CONSTRAINT FK_CauHoiTN_MonHoc FOREIGN KEY (MaMon) REFERENCES MonHoc(MaMon),
                            CONSTRAINT FK_CauHoiTN_GiaoVien FOREIGN KEY (MaGV) REFERENCES GiaoVien(MaGV),
                            CONSTRAINT CK_DapAnDung CHECK (DapAnDung IN ('A', 'B', 'C', 'D'))
                        )
                    END";
                
                db.ExecuteNonQuery(checkCauHoiTracNghiemTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi kiểm tra cấu trúc cơ sở dữ liệu: {ex.Message}");
            }
        }
        /// <summary>
        /// Lấy danh sách các lớp học được gán cho một bài kiểm tra
        /// </summary>
        /// <param name="maBaiKT">Mã bài kiểm tra</param>
        /// <returns>Danh sách các lớp học</returns>
        public List<dynamic> GetClassesForTest(int maBaiKT)
        {
            List<dynamic> classes = new List<dynamic>();

            try
            {
                string query = @"
                    SELECT bkl.*, lh.TenLop
                    FROM BaiKiemTra_LopHoc bkl
                    JOIN LopHoc lh ON bkl.MaLop = lh.MaLop
                    WHERE bkl.MaBaiKT = @MaBaiKT";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var classInfo = new
                        {
                            MaLop = Convert.ToInt32(row["MaLop"]),
                            TenLop = row["TenLop"].ToString(),
                            NgayKiemTra = Convert.ToDateTime(row["NgayKiemTra"]),
                            TrangThai = row["TrangThai"].ToString()
                        };

                        classes.Add(classInfo);
                    }
                }

                return classes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting classes for test: {ex.Message}");
                return classes;
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
        /// Get all tests assigned to a specific class
        /// </summary>
        /// <param name="maLop">Class ID</param>
        /// <param name="namHoc">School year (optional)</param>
        /// <param name="hocKy">Semester (optional)</param>
        /// <returns>List of tests</returns>
        public List<BaiKiemTraDTO> GetTestsForClass(int maLop, string namHoc = null, int? hocKy = null)
        {
            List<BaiKiemTraDTO> tests = new List<BaiKiemTraDTO>();

            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                // Base query - Explicitly name all columns to avoid field name confusion
                string query = @"
                    SELECT 
                        bk.MaBaiKT, bk.TenBaiKT, bk.MoTa, bk.MaGV, bk.MaMon AS MaMH,
                        bk.ThoiGianLamBai, bk.TrangThai, bk.NgayTao, bk.HocKy, bk.NamHoc,
                        bk.SoLanLamToiDa, bk.DiemDatYeuCau, bk.HienThiKetQuaNgay,
                        bk.XaoTronCauHoi, bk.GhiChuChamDiem, bk.CoMatKhau, bk.MatKhau,
                        bk.LoaiBaiKiemTra AS LoaiBaiKT, 
                        mh.TenMon AS TenMonHoc,
                        lh.TenLop,
                        bkl.NgayKiemTra AS ThoiGianBatDau,
                        bk.ThoiGianKetThuc
                    FROM 
                        BaiKiemTra bk
                    INNER JOIN 
                        BaiKiemTra_LopHoc bkl ON bk.MaBaiKT = bkl.MaBaiKT
                    INNER JOIN
                        MonHoc mh ON bk.MaMon = mh.MaMon
                    INNER JOIN
                        LopHoc lh ON bkl.MaLop = lh.MaLop
                    WHERE 
                        bkl.MaLop = @MaLop";

                parameters.Add("@MaLop", maLop);

                // Add optional filters
                if (!string.IsNullOrEmpty(namHoc))
                {
                    query += " AND bk.NamHoc = @NamHoc";
                    parameters.Add("@NamHoc", namHoc);
                }

                if (hocKy.HasValue)
                {
                    query += " AND bk.HocKy = @HocKy";
                    parameters.Add("@HocKy", hocKy.Value);
                }

                // Only get published tests (support both English and Vietnamese status)
                query += " AND (bk.TrangThai = N'Published' OR bk.TrangThai = N'Đã công bố')";

                // Order by test date
                query += " ORDER BY bkl.NgayKiemTra DESC";

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        BaiKiemTraDTO test = new BaiKiemTraDTO
                        {
                            MaBaiKT = Convert.ToInt32(row["MaBaiKT"]),
                            TenBaiKT = row["TenBaiKT"].ToString(),
                            MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null,
                            MaGV = Convert.ToInt32(row["MaGV"]),
                            MaMH = Convert.ToInt32(row["MaMH"]),
                            TenMonHoc = row["TenMonHoc"].ToString(),
                            MaLop = maLop,
                            TenLop = row["TenLop"].ToString(),
                            LoaiBaiKT = row["LoaiBaiKT"] != DBNull.Value ? row["LoaiBaiKT"].ToString() : "Bài kiểm tra",
                            ThoiGianLamBai = Convert.ToInt32(row["ThoiGianLamBai"]),
                            ThoiGianBatDau = Convert.ToDateTime(row["ThoiGianBatDau"]),
                            ThoiGianKetThuc = Convert.ToDateTime(row["ThoiGianKetThuc"]),
                            NgayTao = Convert.ToDateTime(row["NgayTao"]),
                            TrangThai = row["TrangThai"].ToString(),
                            HocKy = Convert.ToInt32(row["HocKy"]),
                            NamHoc = row["NamHoc"].ToString()
                        };

                        // Set other properties with null checks
                        test.SoLanLamToiDa = row["SoLanLamToiDa"] != DBNull.Value ? Convert.ToInt32(row["SoLanLamToiDa"]) : 1;
                        test.DiemDatYeuCau = row["DiemDatYeuCau"] != DBNull.Value ? Convert.ToDouble(row["DiemDatYeuCau"]) : 5.0;
                        test.HienThiKetQuaNgay = row["HienThiKetQuaNgay"] != DBNull.Value ? Convert.ToBoolean(row["HienThiKetQuaNgay"]) : false;
                        test.XaoTronCauHoi = row["XaoTronCauHoi"] != DBNull.Value ? Convert.ToBoolean(row["XaoTronCauHoi"]) : false;
                        test.CoMatKhau = row["CoMatKhau"] != DBNull.Value ? Convert.ToBoolean(row["CoMatKhau"]) : false;

                        tests.Add(test);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải danh sách bài kiểm tra cho lớp: {ex.Message}");
            }

            return tests;
        }

        /// <summary>
        /// Get all distinct school years from the database
        /// </summary>
        /// <returns>List of school years</returns>
        public List<string> GetDistinctSchoolYears()
        {
            List<string> years = new List<string>();

            try
            {
                string query = "SELECT DISTINCT NamHoc FROM BaiKiemTra ORDER BY NamHoc DESC";

                DataTable dt = db.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        years.Add(row["NamHoc"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving school years: {ex.Message}");
            }

            return years;
        }

        /// <summary>
        /// Get a test with class filter for a specific student
        /// </summary>
        /// <param name="maBaiKT">Test ID</param>
        /// <param name="maHS">Student ID</param>
        /// <returns>The test data or null if not found or not accessible to the student</returns>
        public BaiKiemTraDTO GetBaiKiemTraForStudent(int maBaiKT, int maHS)
        {
            try
            {
                // First, get the student's class
                string getClassQuery = @"
                    SELECT MaLop 
                    FROM HocSinh 
                    WHERE MaHS = @MaHS";
                
                Dictionary<string, object> studentParams = new Dictionary<string, object>
                {
                    { "@MaHS", maHS }
                };
                
                DataTable studentDt = db.ExecuteQuery(getClassQuery, studentParams);
                
                if (studentDt == null || studentDt.Rows.Count == 0)
                {
                    return null; // Student not found
                }
                
                int maLop = Convert.ToInt32(studentDt.Rows[0]["MaLop"]);
                
                // Then get the test but only if it's assigned to the student's class
                string query = @"
                    SELECT 
                        bk.*, 
                        mh.TenMon AS TenMonHoc, 
                        lh.TenLop AS TenLop,
                        bkl.NgayKiemTra AS ThoiGianBatDau,
                        bk.ThoiGianKetThuc AS ThoiGianKetThuc
                    FROM 
                        BaiKiemTra bk
                    INNER JOIN 
                        BaiKiemTra_LopHoc bkl ON bk.MaBaiKT = bkl.MaBaiKT
                    INNER JOIN 
                        LopHoc lh ON bkl.MaLop = lh.MaLop
                    INNER JOIN 
                        MonHoc mh ON bk.MaMon = mh.MaMon
                    WHERE 
                        bk.MaBaiKT = @MaBaiKT AND
                        bkl.MaLop = @MaLop AND
                        (bk.TrangThai = N'Published' OR bk.TrangThai = N'Đã công bố')";
                
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaBaiKT", maBaiKT },
                    { "@MaLop", maLop }
                };
                
                DataTable dt = db.ExecuteQuery(query, parameters);
                
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    
                    BaiKiemTraDTO baiKiemTra = new BaiKiemTraDTO
                    {
                        MaBaiKT = maBaiKT,
                        TenBaiKT = row["TenBaiKT"].ToString(),
                        MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null,
                        MaGV = Convert.ToInt32(row["MaGV"]),
                        MaMH = Convert.ToInt32(row["MaMon"]),
                        TenMonHoc = row["TenMonHoc"].ToString(),
                        MaLop = maLop,
                        TenLop = row["TenLop"].ToString(),
                        LoaiBaiKT = row["LoaiBaiKiemTra"].ToString(),
                        ThoiGianLamBai = Convert.ToInt32(row["ThoiGianLamBai"]),
                        SoLanLamToiDa = Convert.ToInt32(row["SoLanLamToiDa"]),
                        DiemDatYeuCau = Convert.ToDouble(row["DiemDatYeuCau"]),
                        ThoiGianBatDau = Convert.ToDateTime(row["ThoiGianBatDau"]),
                        ThoiGianKetThuc = Convert.ToDateTime(row["ThoiGianKetThuc"]),
                        HienThiKetQuaNgay = Convert.ToBoolean(row["HienThiKetQuaNgay"]),
                        XaoTronCauHoi = Convert.ToBoolean(row["XaoTronCauHoi"]),
                        GhiChuChamDiem = row["GhiChuChamDiem"] != DBNull.Value ? row["GhiChuChamDiem"].ToString() : null,
                        CoMatKhau = Convert.ToBoolean(row["CoMatKhau"]),
                        MatKhau = row["MatKhau"] != DBNull.Value ? row["MatKhau"].ToString() : null,
                        TrangThai = row["TrangThai"].ToString(),
                        NgayTao = Convert.ToDateTime(row["NgayTao"]),
                        HocKy = Convert.ToInt32(row["HocKy"]),
                        NamHoc = row["NamHoc"].ToString()
                    };
                    
                    // Load questions
                    baiKiemTra.DanhSachCauHoi = GetQuestionsByTestId(maBaiKT);
                    
                    return baiKiemTra;
                }
                
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving test for student: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Get a list of available tests for a specific student based on their class
        /// </summary>
        /// <param name="maHS">Student ID</param>
        /// <param name="namHoc">School year (optional)</param>
        /// <param name="hocKy">Semester (optional)</param>
        /// <returns>List of available tests</returns>
        public List<BaiKiemTraDTO> GetAvailableTestsForStudent(int maHS, string namHoc = null, int? hocKy = null)
        {
            List<BaiKiemTraDTO> tests = new List<BaiKiemTraDTO>();

            try
            {
                // First, get the student's class
                string getClassQuery = @"
                    SELECT MaLop 
                    FROM HocSinh 
                    WHERE MaHS = @MaHS";
                
                Dictionary<string, object> studentParams = new Dictionary<string, object>
                {
                    { "@MaHS", maHS }
                };
                
                DataTable studentDt = db.ExecuteQuery(getClassQuery, studentParams);
                
                if (studentDt == null || studentDt.Rows.Count == 0)
                {
                    return tests; // Empty list if student not found
                }
                
                int maLop = Convert.ToInt32(studentDt.Rows[0]["MaLop"]);

                // Base query to get available tests for the student's class
                string query = @"
                    SELECT 
                        bk.MaBaiKT, bk.TenBaiKT, bk.MoTa, bk.MaGV, bk.MaMon AS MaMH,
                        bk.ThoiGianLamBai, bk.TrangThai, bk.NgayTao, bk.HocKy, bk.NamHoc,
                        bk.SoLanLamToiDa, bk.DiemDatYeuCau, bk.HienThiKetQuaNgay,
                        bk.XaoTronCauHoi, bk.GhiChuChamDiem, bk.CoMatKhau, bk.MatKhau,
                        bk.LoaiBaiKiemTra AS LoaiBaiKT, 
                        mh.TenMon AS TenMonHoc,
                        lh.TenLop,
                        bkl.NgayKiemTra AS ThoiGianBatDau,
                        bk.ThoiGianKetThuc,
                        (SELECT COUNT(*) FROM BaiLam bl WHERE bl.MaBaiKT = bk.MaBaiKT AND bl.MaHS = @MaHS AND bl.DaNop = 1) AS SoLanLamBai
                    FROM 
                        BaiKiemTra bk
                    INNER JOIN 
                        BaiKiemTra_LopHoc bkl ON bk.MaBaiKT = bkl.MaBaiKT
                    INNER JOIN
                        MonHoc mh ON bk.MaMon = mh.MaMon
                    INNER JOIN
                        LopHoc lh ON bkl.MaLop = lh.MaLop
                    WHERE 
                        bkl.MaLop = @MaLop
                        AND (bk.TrangThai = N'Published' OR bk.TrangThai = N'Đã công bố')
                        AND GETDATE() BETWEEN bkl.NgayKiemTra AND bk.ThoiGianKetThuc";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaLop", maLop },
                    { "@MaHS", maHS }
                };

                // Add optional filters
                if (!string.IsNullOrEmpty(namHoc))
                {
                    query += " AND bk.NamHoc = @NamHoc";
                    parameters.Add("@NamHoc", namHoc);
                }

                if (hocKy.HasValue)
                {
                    query += " AND bk.HocKy = @HocKy";
                    parameters.Add("@HocKy", hocKy.Value);
                }

                // Order by test date
                query += " ORDER BY bkl.NgayKiemTra ASC";

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int soLanLamBai = Convert.ToInt32(row["SoLanLamBai"]);
                        int soLanLamToiDa = row["SoLanLamToiDa"] != DBNull.Value ? Convert.ToInt32(row["SoLanLamToiDa"]) : 1;

                        // Skip tests that student has already taken the maximum number of times
                        if (soLanLamBai >= soLanLamToiDa)
                        {
                            continue;
                        }

                        BaiKiemTraDTO test = new BaiKiemTraDTO
                        {
                            MaBaiKT = Convert.ToInt32(row["MaBaiKT"]),
                            TenBaiKT = row["TenBaiKT"].ToString(),
                            MoTa = row["MoTa"] != DBNull.Value ? row["MoTa"].ToString() : null,
                            MaGV = Convert.ToInt32(row["MaGV"]),
                            MaMH = Convert.ToInt32(row["MaMH"]),
                            TenMonHoc = row["TenMonHoc"].ToString(),
                            MaLop = maLop,
                            TenLop = row["TenLop"].ToString(),
                            LoaiBaiKT = row["LoaiBaiKT"] != DBNull.Value ? row["LoaiBaiKT"].ToString() : "Bài kiểm tra",
                            ThoiGianLamBai = Convert.ToInt32(row["ThoiGianLamBai"]),
                            ThoiGianBatDau = Convert.ToDateTime(row["ThoiGianBatDau"]),
                            ThoiGianKetThuc = Convert.ToDateTime(row["ThoiGianKetThuc"]),
                            NgayTao = Convert.ToDateTime(row["NgayTao"]),
                            TrangThai = row["TrangThai"].ToString(),
                            HocKy = Convert.ToInt32(row["HocKy"]),
                            NamHoc = row["NamHoc"].ToString(),
                            SoLanLamToiDa = soLanLamToiDa,
                            DiemDatYeuCau = row["DiemDatYeuCau"] != DBNull.Value ? Convert.ToDouble(row["DiemDatYeuCau"]) : 5.0,
                            HienThiKetQuaNgay = row["HienThiKetQuaNgay"] != DBNull.Value ? Convert.ToBoolean(row["HienThiKetQuaNgay"]) : false,
                            XaoTronCauHoi = row["XaoTronCauHoi"] != DBNull.Value ? Convert.ToBoolean(row["XaoTronCauHoi"]) : false,
                            CoMatKhau = row["CoMatKhau"] != DBNull.Value ? Convert.ToBoolean(row["CoMatKhau"]) : false,
                            MatKhau = row["MatKhau"] != DBNull.Value ? row["MatKhau"].ToString() : null
                        };

                        tests.Add(test);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải danh sách bài kiểm tra cho học sinh: {ex.Message}");
            }

            return tests;
        }
        
        /// <summary>
        /// Get a list of all tests (both available and completed) for a student
        /// </summary>
        /// <param name="maHS">Student ID</param>
        /// <param name="namHoc">School year (optional)</param>
        /// <param name="hocKy">Semester (optional)</param>
        /// <returns>List of all relevant tests</returns>
        public List<BaiKiemTraDTO> GetAllTestsForStudent(int maHS, string namHoc = null, int? hocKy = null)
        {
            try 
            {
                // First, get the student's class
                string getClassQuery = @"
                    SELECT MaLop 
                    FROM HocSinh 
                    WHERE MaHS = @MaHS";
                
                Dictionary<string, object> studentParams = new Dictionary<string, object>
                {
                    { "@MaHS", maHS }
                };
                
                DataTable studentDt = db.ExecuteQuery(getClassQuery, studentParams);
                
                if (studentDt == null || studentDt.Rows.Count == 0)
                {
                    return new List<BaiKiemTraDTO>(); 
                }
                
                int maLop = Convert.ToInt32(studentDt.Rows[0]["MaLop"]);
                
                // Get all tests for this class
                return GetTestsForClass(maLop, namHoc, hocKy);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải tất cả bài kiểm tra cho học sinh: {ex.Message}");
                return new List<BaiKiemTraDTO>();
            }
        }

        /// <summary>
        /// Validates and normalizes the question type for consistency
        /// </summary>
        /// <param name="loaiCauHoi">The question type string</param>
        /// <returns>Normalized question type "TN" or "TL" or null if invalid</returns>
        private string ValidateQuestionType(string loaiCauHoi)
        {
            if (string.IsNullOrWhiteSpace(loaiCauHoi))
                return null;
                
            // Trim and normalize type string
            string normalizedType = loaiCauHoi.Trim();
            
            // Check for valid question types, using case-insensitive comparison
            if (string.Equals(normalizedType, "MultipleChoice", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(normalizedType, "TracNghiem", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(normalizedType, "TN", StringComparison.OrdinalIgnoreCase))
            {
                return "TN"; // Chuẩn hóa thành tag "TN" cho trắc nghiệm
            }
            else if (string.Equals(normalizedType, "Essay", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(normalizedType, "TuLuan", StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(normalizedType, "TL", StringComparison.OrdinalIgnoreCase))
            {
                return "TL"; // Chuẩn hóa thành tag "TL" cho tự luận
            }
            
            return null; // Invalid type
        }
    }
}
