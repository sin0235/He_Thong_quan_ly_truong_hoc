using QuanLyTruongHoc.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.DAL
{
    /// <summary>
    /// Lớp xử lý thao tác dữ liệu đơn xin nghỉ với cơ sở dữ liệu
    /// </summary>
    public class DonXinNghiDAO
    {
        private readonly DatabaseHelper db;

        /// <summary>
        /// Khởi tạo đối tượng xử lý đơn xin nghỉ
        /// </summary>
        public DonXinNghiDAO()
        {
            db = new DatabaseHelper();
        }

        /// <summary>
        /// Lấy danh sách đơn xin nghỉ của học sinh
        /// </summary>
        /// <param name="maHS">Mã học sinh</param>
        /// <returns>Danh sách đơn xin nghỉ</returns>
        public List<DonXinNghiDTO> GetDonXinNghiByHocSinh(int maHS)
        {
            try
            {
                string query = @"
                    SELECT 
                        DN.MaDon, 
                        DN.MaHS,
                        HS.HoTen AS HoTenHocSinh,
                        HS.MaLop,
                        LH.TenLop,
                        DN.NgayNghi, 
                        DN.LyDo, 
                        DN.TrangThai,
                        DN.NgayTao,
                        DN.GhiChu
                    FROM 
                        DonXinNghi DN
                    INNER JOIN 
                        HocSinh HS ON DN.MaHS = HS.MaHS
                    INNER JOIN 
                        LopHoc LH ON HS.MaLop = LH.MaLop
                    WHERE 
                        DN.MaHS = @MaHS
                    ORDER BY 
                        DN.NgayTao DESC";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@MaHS", maHS }
                    };

                DataTable dt = db.ExecuteQuery(query, parameters);
                return MapDataTableToDonXinNghiList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách đơn nghỉ: {ex.Message}");
                return new List<DonXinNghiDTO>();
            }
        }

        /// <summary>
        /// Lấy danh sách đơn xin nghỉ theo trạng thái
        /// </summary>
        /// <param name="maGVChuNhiem">Mã giáo viên chủ nhiệm</param>
        /// <param name="trangThai">Trạng thái đơn cần lấy (null để lấy tất cả)</param>
        /// <returns>Danh sách đơn xin nghỉ</returns>
        public List<DonXinNghiDTO> GetDonXinNghiByTrangThaiVaGVCN(int maGVChuNhiem, string trangThai = null)
        {
            try
            {
                string whereClause = trangThai != null ? "AND DN.TrangThai = @TrangThai" : "";

                string query = $@"
                    SELECT 
                        DN.MaDon, 
                        DN.MaHS,
                        HS.HoTen AS HoTenHocSinh,
                        HS.MaLop,
                        LH.TenLop,
                        DN.NgayNghi, 
                        DN.LyDo, 
                        DN.TrangThai,
                        DN.NgayTao,
                        DN.GhiChu
                    FROM 
                        DonXinNghi DN
                    INNER JOIN 
                        HocSinh HS ON DN.MaHS = HS.MaHS
                    INNER JOIN 
                        LopHoc LH ON HS.MaLop = LH.MaLop
                    WHERE 
                        LH.MaGVChuNhiem = @MaGVChuNhiem
                        {whereClause}
                    ORDER BY 
                        DN.NgayTao DESC";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@MaGVChuNhiem", maGVChuNhiem }
                    };

                if (trangThai != null)
                {
                    parameters.Add("@TrangThai", trangThai);
                }

                DataTable dt = db.ExecuteQuery(query, parameters);
                return MapDataTableToDonXinNghiList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách đơn nghỉ: {ex.Message}");
                return new List<DonXinNghiDTO>();
            }
        }

        /// <summary>
        /// Lấy thông tin chi tiết đơn xin nghỉ theo ID
        /// </summary>
        /// <param name="maDon">ID của đơn xin nghỉ</param>
        /// <returns>Thông tin đơn xin nghỉ</returns>
        public DonXinNghiDTO GetDonXinNghiById(int maDon)
        {
            try
            {
                string query = @"
                    SELECT 
                        DN.MaDon, 
                        DN.MaHS,
                        HS.HoTen AS HoTenHocSinh,
                        HS.MaLop,
                        LH.TenLop,
                        DN.NgayNghi, 
                        DN.LyDo, 
                        DN.TrangThai,
                        DN.NgayTao,
                        DN.GhiChu
                    FROM 
                        DonXinNghi DN
                    INNER JOIN 
                        HocSinh HS ON DN.MaHS = HS.MaHS
                    INNER JOIN 
                        LopHoc LH ON HS.MaLop = LH.MaLop
                    WHERE 
                        DN.MaDon = @MaDon";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@MaDon", maDon }
                    };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt.Rows.Count == 0)
                    return null;

                DonXinNghiDTO donXinNghi = MapDataRowToDonXinNghi(dt.Rows[0]);

                // Lấy danh sách tệp đính kèm
                donXinNghi.DanhSachDinhKem = GetDinhKemByDonId(maDon);

                return donXinNghi;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy thông tin đơn nghỉ: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Thêm đơn xin nghỉ mới
        /// </summary>
        /// <param name="donXinNghi">Thông tin đơn xin nghỉ</param>
        /// <returns>ID của đơn vừa tạo, hoặc -1 nếu có lỗi</returns>
        public int ThemDonXinNghi(DonXinNghiDTO donXinNghi)
        {
            try
            {
                string query = @"
                    INSERT INTO DonXinNghi (MaHS, NgayNghi, LyDo, TrangThai, NgayTao, GhiChu)
                    VALUES (@MaHS, @NgayNghi, @LyDo, @TrangThai, @NgayTao, @GhiChu);
                    SELECT SCOPE_IDENTITY();";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@MaHS", donXinNghi.MaHS },
                        { "@NgayNghi", donXinNghi.NgayNghi },
                        { "@LyDo", donXinNghi.LyDo },
                        { "@TrangThai", donXinNghi.TrangThai ?? "Chờ duyệt" },
                        { "@NgayTao", DateTime.Now },
                        { "@GhiChu", donXinNghi.GhiChu ?? (object)DBNull.Value }
                    };

                object result = db.ExecuteScalar(query, parameters);

                if (result != null && result != DBNull.Value)
                {
                    int maDon = Convert.ToInt32(result);

                    // Thêm các tệp đính kèm nếu có
                    if (donXinNghi.DanhSachDinhKem != null && donXinNghi.DanhSachDinhKem.Count > 0)
                    {
                        foreach (var dinhKem in donXinNghi.DanhSachDinhKem)
                        {
                            ThemDinhKem(maDon, dinhKem);
                        }
                    }

                    return maDon;
                }

                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm đơn nghỉ: {ex.Message}");
                return -1;
            }
        }

        /// <summary>
        /// Cập nhật trạng thái đơn xin nghỉ
        /// </summary>
        /// <param name="maDon">ID của đơn xin nghỉ</param>
        /// <param name="trangThai">Trạng thái mới (Đã duyệt/Từ chối)</param>
        /// <returns>True nếu cập nhật thành công</returns>
        public bool CapNhatTrangThaiDon(int maDon, string trangThai)
        {
            try
            {
                string query = @"
                    UPDATE DonXinNghi
                    SET TrangThai = @TrangThai
                    WHERE MaDon = @MaDon";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@MaDon", maDon },
                        { "@TrangThai", trangThai }
                    };

                int rowsAffected = db.ExecuteNonQuery(query, parameters) ? 1 : 0;

                // Nếu đơn được duyệt, cập nhật điểm danh
                if (rowsAffected > 0 && trangThai == "Đã duyệt")
                {
                    CapNhatDiemDanhVangCoPhep(maDon);
                }

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật trạng thái đơn nghỉ: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Cập nhật điểm danh học sinh khi đơn được duyệt
        /// </summary>
        /// <param name="maDon">ID đơn xin nghỉ</param>
        private void CapNhatDiemDanhVangCoPhep(int maDon)
        {
            try
            {
                // Lấy thông tin học sinh và ngày nghỉ
                string fetchQuery = @"
                    SELECT MaHS, NgayNghi, (SELECT MaLop FROM HocSinh WHERE HocSinh.MaHS = DonXinNghi.MaHS) AS MaLop
                    FROM DonXinNghi
                    WHERE MaDon = @MaDon";

                Dictionary<string, object> fetchParams = new Dictionary<string, object>
                    {
                        { "@MaDon", maDon }
                    };

                DataTable dt = db.ExecuteQuery(fetchQuery, fetchParams);
                if (dt.Rows.Count > 0)
                {
                    int maHS = Convert.ToInt32(dt.Rows[0]["MaHS"]);
                    int maLop = Convert.ToInt32(dt.Rows[0]["MaLop"]);
                    DateTime ngayNghi = Convert.ToDateTime(dt.Rows[0]["NgayNghi"]);

                    // Cập nhật trạng thái "Vắng có phép" trong bảng DiemDanh
                    string updateQuery = @"
                        IF EXISTS (
                            SELECT 1 FROM DiemDanh 
                            WHERE MaHS = @MaHS AND Ngay = @NgayNghi
                        )
                        BEGIN
                            UPDATE DiemDanh
                            SET TrangThai = N'Vắng có phép',
                                GhiChu = N'Đơn nghỉ đã duyệt'
                            WHERE MaHS = @MaHS AND Ngay = @NgayNghi
                        END
                        ELSE
                        BEGIN
                            INSERT INTO DiemDanh (MaHS, MaLop, Ngay, TrangThai, GhiChu)
                            VALUES (@MaHS, @MaLop, @NgayNghi, N'Vắng có phép', N'Đơn nghỉ đã duyệt')
                        END";

                    Dictionary<string, object> updateParams = new Dictionary<string, object>
                        {
                            { "@MaHS", maHS },
                            { "@MaLop", maLop },
                            { "@NgayNghi", ngayNghi.Date }
                        };

                    db.ExecuteNonQuery(updateQuery, updateParams);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật điểm danh: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách tệp đính kèm của một đơn
        /// </summary>
        /// <param name="maDon">ID đơn xin nghỉ</param>
        /// <returns>Danh sách tệp đính kèm</returns>
        private List<TepDinhKemDTO> GetDinhKemByDonId(int maDon)
        {
            try
            {
                string query = @"
                    SELECT 
                        MaDinhKem,
                        MaDon, 
                        TenFile, 
                        KichThuoc
                    FROM 
                        DinhKem
                    WHERE 
                        MaDon = @MaDon";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@MaDon", maDon }
                    };

                DataTable dt = db.ExecuteQuery(query, parameters);
                List<TepDinhKemDTO> dinhKemList = new List<TepDinhKemDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    TepDinhKemDTO dinhKem = new TepDinhKemDTO
                    {
                        MaDinhKem = Convert.ToInt32(row["MaDinhKem"]),
                        MaDon = maDon,
                        TenFile = row["TenFile"].ToString(),
                        KichThuoc = Convert.ToInt64(row["KichThuoc"])
                    };

                    dinhKemList.Add(dinhKem);
                }

                return dinhKemList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách đính kèm: {ex.Message}");
                return new List<TepDinhKemDTO>();
            }
        }

        /// <summary>
        /// Thêm tệp đính kèm mới cho đơn xin nghỉ
        /// </summary>
        /// <param name="maDon">ID đơn xin nghỉ</param>
        /// <param name="dinhKem">Thông tin tệp đính kèm</param>
        /// <returns>True nếu thêm thành công</returns>
        public bool ThemDinhKem(int maDon, TepDinhKemDTO dinhKem)
        {
            try
            {
                string query = @"
                    INSERT INTO DinhKem (MaDon, TenFile, NoiDung, KichThuoc)
                    VALUES (@MaDon, @TenFile, @NoiDung, @KichThuoc)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@MaDon", maDon },
                        { "@TenFile", dinhKem.TenFile },
                        { "@NoiDung", dinhKem.NoiDung },
                        { "@KichThuoc", dinhKem.KichThuoc }
                    };

                int rowsAffected = db.ExecuteNonQuery(query, parameters) ? 1 : 0;
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm đính kèm: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy nội dung của tệp đính kèm theo ID
        /// </summary>
        /// <param name="maDinhKem">ID của tệp đính kèm</param>
        /// <returns>Nội dung tệp đính kèm dạng mảng byte</returns>
        public byte[] GetNoiDungDinhKem(int maDinhKem)
        {
            try
            {
                string query = @"
                    SELECT NoiDung
                    FROM DinhKem
                    WHERE MaDinhKem = @MaDinhKem";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                    {
                        { "@MaDinhKem", maDinhKem }
                    };

                DataTable dt = db.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    return (byte[])dt.Rows[0]["NoiDung"];
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy nội dung đính kèm: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Xóa đơn xin nghỉ
        /// </summary>
        /// <param name="maDon">ID đơn xin nghỉ</param>
        /// <returns>True nếu xóa thành công</returns>
        public bool XoaDonXinNghi(int maDon)
        {
            try
            {
                // Xóa các đính kèm trước để tránh vi phạm ràng buộc khóa ngoại
                string deleteAttachmentsQuery = @"DELETE FROM DinhKem WHERE MaDon = @MaDon";
                db.ExecuteNonQuery(deleteAttachmentsQuery, new Dictionary<string, object> { { "@MaDon", maDon } });

                // Sau đó xóa đơn
                string deleteQuery = @"DELETE FROM DonXinNghi WHERE MaDon = @MaDon";
                bool result = db.ExecuteNonQuery(deleteQuery, new Dictionary<string, object> { { "@MaDon", maDon } });

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa đơn nghỉ: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Chuyển DataTable thành danh sách đơn xin nghỉ
        /// </summary>
        private List<DonXinNghiDTO> MapDataTableToDonXinNghiList(DataTable dt)
        {
            List<DonXinNghiDTO> donXinNghiList = new List<DonXinNghiDTO>();

            foreach (DataRow row in dt.Rows)
            {
                DonXinNghiDTO donXinNghi = MapDataRowToDonXinNghi(row);
                donXinNghiList.Add(donXinNghi);
            }

            return donXinNghiList;
        }

        /// <summary>
        /// Chuyển DataRow thành đối tượng DonXinNghiDTO
        /// </summary>
        private DonXinNghiDTO MapDataRowToDonXinNghi(DataRow row)
        {
            DonXinNghiDTO donXinNghi = new DonXinNghiDTO
            {
                MaDon = Convert.ToInt32(row["MaDon"]),
                MaHS = Convert.ToInt32(row["MaHS"]),
                HoTenHocSinh = row["HoTenHocSinh"].ToString(),
                MaLop = Convert.ToInt32(row["MaLop"]),
                TenLop = row["TenLop"].ToString(),
                NgayNghi = Convert.ToDateTime(row["NgayNghi"]),
                LyDo = row["LyDo"].ToString(),
                TrangThai = row["TrangThai"].ToString(),
                NgayTao = row.Table.Columns.Contains("NgayTao") && row["NgayTao"] != DBNull.Value
                    ? Convert.ToDateTime(row["NgayTao"])
                    : DateTime.MinValue,
                GhiChu = row.Table.Columns.Contains("GhiChu") && row["GhiChu"] != DBNull.Value
                    ? row["GhiChu"].ToString()
                    : null
            };

            return donXinNghi;
        }
        /// <summary>
        /// Lấy lịch sử đơn xin nghỉ của học sinh theo các khoảng thời gian
        /// </summary>
        /// <param name="maHS">Mã học sinh</param>
        /// <param name="tuNgay">Từ ngày (để lọc)</param>
        /// <param name="denNgay">Đến ngày (để lọc)</param>
        /// <returns>Danh sách đơn xin nghỉ</returns>
        public List<DonXinNghiDTO> GetLichSuDonXinNghi(int maHS, DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            try
            {
                string whereClause = "";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaHS", maHS }
                };

                if (tuNgay.HasValue)
                {
                    whereClause += " AND DN.NgayNghi >= @TuNgay";
                    parameters.Add("@TuNgay", tuNgay.Value);
                }

                if (denNgay.HasValue)
                {
                    whereClause += " AND DN.NgayNghi <= @DenNgay";
                    parameters.Add("@DenNgay", denNgay.Value);
                }

                string query = $@"
                    SELECT 
                        DN.MaDon, 
                        DN.MaHS,
                        HS.HoTen AS HoTenHocSinh,
                        HS.MaLop,
                        LH.TenLop,
                        DN.NgayNghi, 
                        DN.LyDo, 
                        DN.TrangThai,
                        DN.NgayTao,
                        DN.GhiChu
                    FROM 
                        DonXinNghi DN
                    INNER JOIN 
                        HocSinh HS ON DN.MaHS = HS.MaHS
                    INNER JOIN 
                        LopHoc LH ON HS.MaLop = LH.MaLop
                    WHERE 
                        DN.MaHS = @MaHS
                        {whereClause}
                    ORDER BY 
                        DN.NgayNghi DESC, DN.NgayTao DESC";

                DataTable dt = db.ExecuteQuery(query, parameters);
                return MapDataTableToDonXinNghiList(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy lịch sử đơn nghỉ: {ex.Message}");
                return new List<DonXinNghiDTO>();
            }
        }

        /// <summary>
        /// Kiểm tra xem học sinh đã có đơn xin nghỉ cho ngày cụ thể chưa
        /// </summary>
        /// <param name="maHS">Mã học sinh</param>
        /// <param name="ngayNghi">Ngày nghỉ cần kiểm tra</param>
        /// <returns>True nếu đã tồn tại đơn, False nếu chưa</returns>
        public bool DaTonTaiDonXinNghi(int maHS, DateTime ngayNghi)
        {
            try
            {
                string query = @"
                    SELECT COUNT(1) AS Count
                    FROM DonXinNghi
                    WHERE MaHS = @MaHS 
                      AND CONVERT(date, NgayNghi) = CONVERT(date, @NgayNghi)
                      AND TrangThai <> N'Từ chối'";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaHS", maHS },
                    { "@NgayNghi", ngayNghi.Date }
                };

                object result = db.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi kiểm tra đơn trùng: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy thông tin về số lượng đơn xin nghỉ của học sinh theo loại trạng thái
        /// </summary>
        /// <param name="maHS">Mã học sinh</param>
        /// <returns>Dictionary chứa thống kê đơn theo trạng thái</returns>
        public Dictionary<string, int> GetThongKeDonXinNghi(int maHS)
        {
            try
            {
                string query = @"
                    SELECT 
                        TrangThai,
                        COUNT(*) AS SoLuong
                    FROM 
                        DonXinNghi
                    WHERE 
                        MaHS = @MaHS
                    GROUP BY 
                        TrangThai";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaHS", maHS }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                Dictionary<string, int> result = new Dictionary<string, int>
                {
                    { "Chờ duyệt", 0 },
                    { "Đã duyệt", 0 },
                    { "Từ chối", 0 },
                    { "Tổng", 0 }
                };

                foreach (DataRow row in dt.Rows)
                {
                    string trangThai = row["TrangThai"].ToString();
                    int soLuong = Convert.ToInt32(row["SoLuong"]);

                    if (result.ContainsKey(trangThai))
                    {
                        result[trangThai] = soLuong;
                    }

                    result["Tổng"] += soLuong;
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy thống kê đơn nghỉ: {ex.Message}");
                return new Dictionary<string, int>
                {
                    { "Chờ duyệt", 0 },
                    { "Đã duyệt", 0 },
                    { "Từ chối", 0 },
                    { "Tổng", 0 }
                };
            }
        }

        /// <summary>
        /// Hủy đơn xin nghỉ đang chờ duyệt
        /// </summary>
        /// <param name="maDon">Mã đơn cần hủy</param>
        /// <param name="maHS">Mã học sinh (để xác thực quyền)</param>
        /// <returns>True nếu hủy thành công</returns>
        public bool HuyDonXinNghi(int maDon, int maHS)
        {
            try
            {
                // Kiểm tra đơn có thuộc về học sinh không và đang ở trạng thái chờ duyệt không
                string checkQuery = @"
                    SELECT COUNT(1) AS Count
                    FROM DonXinNghi
                    WHERE MaDon = @MaDon
                      AND MaHS = @MaHS
                      AND TrangThai = N'Chờ duyệt'";

                Dictionary<string, object> checkParams = new Dictionary<string, object>
                {
                    { "@MaDon", maDon },
                    { "@MaHS", maHS }
                };

                object checkResult = db.ExecuteScalar(checkQuery, checkParams);
                if (Convert.ToInt32(checkResult) == 0)
                {
                    return false; // Đơn không tồn tại hoặc không thuộc quyền học sinh này
                }

                // Thực hiện hủy đơn
                string deleteQuery = @"DELETE FROM DonXinNghi WHERE MaDon = @MaDon";
                bool result = db.ExecuteNonQuery(deleteQuery, new Dictionary<string, object> { { "@MaDon", maDon } });

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi hủy đơn: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Cập nhật thông tin đơn xin nghỉ (chỉ cho đơn chờ duyệt)
        /// </summary>
        /// <param name="donXinNghi">Thông tin đơn cần cập nhật</param>
        /// <returns>True nếu cập nhật thành công</returns>
        public bool CapNhatDonXinNghi(DonXinNghiDTO donXinNghi)
        {
            try
            {
                // Kiểm tra đơn có thuộc về học sinh không và đang ở trạng thái chờ duyệt không
                string checkQuery = @"
                    SELECT COUNT(1) AS Count
                    FROM DonXinNghi
                    WHERE MaDon = @MaDon
                      AND MaHS = @MaHS
                      AND TrangThai = N'Chờ duyệt'";

                Dictionary<string, object> checkParams = new Dictionary<string, object>
                {
                    { "@MaDon", donXinNghi.MaDon },
                    { "@MaHS", donXinNghi.MaHS }
                };

                object checkResult = db.ExecuteScalar(checkQuery, checkParams);
                if (Convert.ToInt32(checkResult) == 0)
                {
                    return false; // Đơn không tồn tại hoặc không ở trạng thái chờ duyệt
                }

                // Cập nhật đơn
                string updateQuery = @"
                    UPDATE DonXinNghi
                    SET NgayNghi = @NgayNghi,
                        LyDo = @LyDo,
                        GhiChu = @GhiChu
                    WHERE MaDon = @MaDon";

                Dictionary<string, object> updateParams = new Dictionary<string, object>
                {
                    { "@MaDon", donXinNghi.MaDon },
                    { "@NgayNghi", donXinNghi.NgayNghi },
                    { "@LyDo", donXinNghi.LyDo },
                    { "@GhiChu", donXinNghi.GhiChu ?? (object)DBNull.Value }
                };

                bool result = db.ExecuteNonQuery(updateQuery, updateParams);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật đơn: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy số ngày nghỉ của học sinh trong một khoảng thời gian
        /// </summary>
        /// <param name="maHS">Mã học sinh</param>
        /// <param name="tuNgay">Từ ngày</param>
        /// <param name="denNgay">Đến ngày</param>
        /// <returns>Số ngày nghỉ đã được duyệt</returns>
        public int GetSoNgayNghi(int maHS, DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) AS SoNgayNghi
                    FROM DonXinNghi
                    WHERE MaHS = @MaHS
                      AND NgayNghi BETWEEN @TuNgay AND @DenNgay
                      AND TrangThai = N'Đã duyệt'";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaHS", maHS },
                    { "@TuNgay", tuNgay },
                    { "@DenNgay", denNgay }
                };

                object result = db.ExecuteScalar(query, parameters);
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đếm số ngày nghỉ: {ex.Message}");
                return 0;
            }
        }

    }
}
