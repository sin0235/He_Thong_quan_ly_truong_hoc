using QuanLyTruongHoc.GUI.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.DAL
{
    public class ThongBaoDAO
    {
        private DatabaseHelper dbHelper;

        public ThongBaoDAO()
        {
            dbHelper = new DatabaseHelper();
        }

        /// <summary>
        /// Lấy tất cả thông báo mà người dùng có thể xem (cá nhân, vai trò, lớp học)
        /// </summary>
        public List<ThongBaoDTO> GetThongBaoForUser(int maNguoiDung, int maVaiTro, int? maLop)
        {
            try
            {
                // Câu truy vấn SQL để lấy thông báo cho người dùng
                string query = @"
                SELECT 
                    TB.MaTB, TB.TieuDe, TB.NoiDung, TB.NgayGui, TB.MaNguoiNhan, 
                    CASE 
                        WHEN GV.HoTen IS NOT NULL THEN GV.HoTen 
                        WHEN HS.HoTen IS NOT NULL THEN HS.HoTen
                        WHEN ND.MaVaiTro = 1 THEN 
                            (SELECT HoTen FROM GiaoVien WHERE MaNguoiDung = TB.MaNguoiGui)
                        ELSE N'Không xác định' 
                    END AS NguoiGui,
                    CASE
                        WHEN TB.MaNguoiNhan IS NOT NULL THEN N'Cá nhân'
                        WHEN TB.MaVaiTroNhan IS NOT NULL THEN (SELECT TenVaiTro FROM VaiTro WHERE MaVaiTro = TB.MaVaiTroNhan)
                        WHEN TB.MaLop IS NOT NULL THEN (SELECT TenLop FROM LopHoc WHERE MaLop = TB.MaLop)
                        ELSE N'Tất cả'
                    END AS NguoiNhan,
                    CASE 
                        WHEN TB.isActive = 0 THEN 1
                        ELSE 0 
                    END AS DaDoc
                FROM ThongBao TB
                LEFT JOIN NguoiDung ND ON TB.MaNguoiGui = ND.MaNguoiDung
                LEFT JOIN GiaoVien GV ON ND.MaNguoiDung = GV.MaNguoiDung
                LEFT JOIN HocSinh HS ON ND.MaNguoiDung = HS.MaNguoiDung
                WHERE 
                    (TB.MaNguoiNhan = @MaNguoiDung OR
                    TB.MaVaiTroNhan = @MaVaiTro OR
                    (TB.MaLop = @MaLop AND @MaLopHasValue = 1) OR
                    (TB.MaNguoiNhan IS NULL AND TB.MaVaiTroNhan IS NULL AND TB.MaLop IS NULL))
                ORDER BY TB.NgayGui DESC";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaNguoiDung", maNguoiDung },
                    { "@MaVaiTro", maVaiTro },
                    { "@MaLopHasValue", maLop.HasValue ? 1 : 0 }
                };

                // Thêm tham số MaLop
                if (maLop.HasValue)
                {
                    parameters.Add("@MaLop", maLop.Value);
                }
                else
                {
                    parameters.Add("@MaLop", DBNull.Value);
                }

                DataTable dt = dbHelper.ExecuteQuery(query, parameters);
                return ConvertDataTableToList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông báo cho người dùng: " + ex.Message);
                // Ghi log chi tiết lỗi
                throw new Exception("Không thể tải dữ liệu thông báo: " + ex.Message);
            }
        }

        /// <summary>
        /// Lấy thông báo cá nhân cho người dùng
        /// </summary>
        public List<ThongBaoDTO> GetPersonalNotifications(int ID)
        {
            try
            {
                string query = @"
                SELECT 
                    TB.MaTB, TB.TieuDe, TB.NoiDung, TB.NgayGui, 
                    CASE 
                        WHEN GV.HoTen IS NOT NULL THEN GV.HoTen 
                        WHEN HS.HoTen IS NOT NULL THEN HS.HoTen
                        WHEN ND.MaVaiTro = 1 THEN 
                            (SELECT HoTen FROM GiaoVien WHERE MaNguoiDung = TB.MaNguoiGui)
                        ELSE N'Không xác định' 
                    END AS NguoiGui,
                    N'Cá nhân' AS NguoiNhan,
                    CASE 
                        WHEN TB.isActive = 0 THEN 1
                        ELSE 0 
                    END AS DaDoc
                FROM ThongBao TB
                LEFT JOIN NguoiDung ND ON TB.MaNguoiGui = ND.MaNguoiDung
                LEFT JOIN GiaoVien GV ON ND.MaNguoiDung = GV.MaNguoiDung
                LEFT JOIN HocSinh HS ON ND.MaNguoiDung = HS.MaNguoiDung
                WHERE TB.MaNguoiNhan = @MaNguoiDung
                ORDER BY TB.NgayGui DESC";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaNguoiDung", ID }
                };

                DataTable dt = dbHelper.ExecuteQuery(query, parameters);
                return ConvertDataTableToList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông báo cá nhân: " + ex.Message);
                throw new Exception("Không thể tải thông báo cá nhân: " + ex.Message);
            }
        }

        /// <summary>
        /// Lấy thông báo của vai trò cho người dùng
        /// </summary>
        public List<ThongBaoDTO> GetRoleNotifications(int maVaiTro, int maNguoiDung)
        {
            try
            {
                string query = @"
                    SELECT 
                        TB.MaTB, TB.TieuDe, TB.NoiDung, TB.NgayGui,  
                        CASE 
                            WHEN GV.HoTen IS NOT NULL THEN GV.HoTen 
                            WHEN HS.HoTen IS NOT NULL THEN HS.HoTen
                            WHEN ND.MaVaiTro = 1 THEN 
                                (SELECT HoTen FROM GiaoVien WHERE MaNguoiDung = TB.MaNguoiGui)
                            ELSE N'Không xác định' 
                        END AS NguoiGui,
                        N'Vai trò' AS NguoiNhan,
                        CASE 
                            WHEN EXISTS (SELECT 1 FROM ThongBaoNguoiDoc WHERE MaTB = TB.MaTB AND MaNguoiDung = @MaNguoiDung) THEN 1
                            ELSE 0 
                        END AS DaDoc
                    FROM ThongBao TB
                    LEFT JOIN NguoiDung ND ON TB.MaNguoiGui = ND.MaNguoiDung
                    LEFT JOIN GiaoVien GV ON ND.MaNguoiDung = GV.MaNguoiDung
                    LEFT JOIN HocSinh HS ON ND.MaNguoiDung = HS.MaNguoiDung
                    WHERE TB.MaVaiTroNhan = @MaVaiTro
                    ORDER BY TB.NgayGui DESC";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaVaiTro", maVaiTro },
                    { "@MaNguoiDung", maNguoiDung }
                };

                DatabaseHelper dbHelper = new DatabaseHelper();
                DataTable dt = dbHelper.ExecuteQuery(query, parameters);

                return ConvertDataTableToList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy thông báo vai trò: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Lấy thông tin chi tiết của một thông báo theo mã thông báo
        /// </summary>
        public ThongBaoDTO GetThongBaoById(int maTB)
        {
            try
            {
                string query = $@"
                SELECT 
                    TB.MaTB, TB.TieuDe, TB.NoiDung, TB.NgayGui, TB.MaNguoiNhan,
                    CASE 
                        WHEN GV.HoTen IS NOT NULL THEN GV.HoTen 
                        WHEN HS.HoTen IS NOT NULL THEN HS.HoTen
                        WHEN ND.MaVaiTro = 1 THEN 
                            (SELECT HoTen FROM GiaoVien WHERE MaNguoiDung = TB.MaNguoiGui)
                        ELSE N'Không xác định' 
                    END AS NguoiGui,
                    CASE
                        WHEN TB.MaNguoiNhan IS NOT NULL THEN N'Cá nhân'
                        WHEN TB.MaVaiTroNhan IS NOT NULL THEN (SELECT TenVaiTro FROM VaiTro WHERE MaVaiTro = TB.MaVaiTroNhan)
                        WHEN TB.MaLop IS NOT NULL THEN (SELECT TenLop FROM LopHoc WHERE MaLop = TB.MaLop)
                        ELSE N'Tất cả'
                    END AS NguoiNhan,
                    CASE 
                        WHEN TB.isActive = 0 THEN 1
                        ELSE 0 
                    END AS DaDoc
                FROM ThongBao TB
                LEFT JOIN NguoiDung ND ON TB.MaNguoiGui = ND.MaNguoiDung
                LEFT JOIN GiaoVien GV ON ND.MaNguoiDung = GV.MaNguoiDung
                LEFT JOIN HocSinh HS ON ND.MaNguoiDung = HS.MaNguoiDung
                WHERE TB.MaTB = {maTB}";
                DataTable dt = dbHelper.ExecuteQuery(query);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return new ThongBaoDTO
                    {
                        MaTB = Convert.ToInt32(dt.Rows[0]["MaTB"]),
                        TieuDe = dt.Rows[0]["TieuDe"].ToString(),
                        NoiDung = dt.Rows[0]["NoiDung"].ToString(),
                        Ngay = Convert.ToDateTime(dt.Rows[0]["NgayGui"]),
                        NguoiGui = dt.Rows[0]["NguoiGui"].ToString(),
                        NguoiNhan = dt.Rows[0]["NguoiNhan"].ToString(),
                        DaDoc = Convert.ToBoolean(dt.Rows[0]["DaDoc"]),
                        maNguoiNhan = dt.Rows[0]["MaNguoiNhan"] == DBNull.Value ? -1 : Convert.ToInt32(dt.Rows[0]["MaNguoiNhan"])

                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy thông báo theo ID: " + ex.Message);
                throw new Exception("Không thể tải chi tiết thông báo: " + ex.Message);
            }
        }

        /// <summary>
        /// Cập nhật trạng thái đã đọc của thông báo
        /// </summary>
        public bool UpdateReadStatus(int maTB, int maNguoiDung)
        {
            try
            {
                string checkPersonalQuery = @"
                    SELECT COUNT(*) 
                    FROM ThongBao 
                    WHERE MaTB = @MaTB AND MaNguoiNhan = @MaNguoiDung";

                Dictionary<string, object> checkParams = new Dictionary<string, object>
                {
                    { "@MaTB", maTB },
                    { "@MaNguoiDung", maNguoiDung }
                };

                DatabaseHelper dbHelper = new DatabaseHelper();
                int isPersonal = Convert.ToInt32(dbHelper.ExecuteScalar(checkPersonalQuery, checkParams));
                if (isPersonal > 0)
                {
                    string updateQuery = @"
                        UPDATE ThongBao 
                        SET isActive = 0 
                        WHERE MaTB = @MaTB AND MaNguoiNhan = @MaNguoiDung";

                    Dictionary<string, object> updateParams = new Dictionary<string, object>
                    {
                        { "@MaTB", maTB },
                        { "@MaNguoiDung", maNguoiDung }
                    };

                    dbHelper.ExecuteNonQuery(updateQuery, updateParams);
                }
                string checkReadQuery = @"
                    SELECT COUNT(*) 
                    FROM ThongBaoNguoiDoc 
                    WHERE MaTB = @MaTB AND MaNguoiDung = @MaNguoiDung";

                int existingCount = Convert.ToInt32(dbHelper.ExecuteScalar(checkReadQuery, checkParams));
                if (existingCount == 0)
                {
                    string insertQuery = @"
                        INSERT INTO ThongBaoNguoiDoc (MaTB, MaNguoiDung, ThoiGianDoc)
                        VALUES (@MaTB, @MaNguoiDung, GETDATE())";

                    return dbHelper.ExecuteNonQuery(insertQuery, checkParams);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật trạng thái đọc: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách file đính kèm cho một thông báo
        /// </summary>
        public List<ucTBChiTiet.AttachmentInfo> GetAttachments(int maTB)
        {
            // Trả về danh sách rỗng nếu chưa có chức năng đính kèm
            return new List<ucTBChiTiet.AttachmentInfo>();
        }

        // Helper method để chuyển DataTable sang List<ThongBaoDTO>
        private List<ThongBaoDTO> ConvertDataTableToList(DataTable dt)
        {
            List<ThongBaoDTO> thongBaoList = new List<ThongBaoDTO>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        thongBaoList.Add(new ThongBaoDTO
                        {
                            MaTB = Convert.ToInt32(row["MaTB"]),
                            TieuDe = row["TieuDe"].ToString(),
                            NoiDung = row["NoiDung"].ToString(),
                            Ngay = Convert.ToDateTime(row["NgayGui"]),
                            NguoiGui = row["NguoiGui"].ToString(),
                            NguoiNhan = row["NguoiNhan"].ToString(),
                            DaDoc = Convert.ToBoolean(row["DaDoc"])
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi xử lý thông báo: {ex.Message}");
                    }
                }
            }

            return thongBaoList;
        }
    }
}
