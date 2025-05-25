using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.DAL
{
    /// <summary>
    /// Lớp xử lý thao tác dữ liệu học sinh với cơ sở dữ liệu
    /// </summary>
    public class HocSinhDAO
    {
        private DatabaseHelper db;

        public HocSinhDAO()
        {
            db = new DatabaseHelper();
        }

        /// <summary>
        /// Lấy thông tin học sinh theo mã học sinh
        /// </summary>
        /// <param name="maHS">Mã học sinh</param>
        /// <returns>Đối tượng StudentInfo chứa thông tin học sinh</returns>
        public ThongTinHSDTO GetStudentById(int maHS)
        {
            try
            {
                string query = @"
                SELECT 
                    HS.MaHS AS StudentId,
                    HS.HoTen AS FullName,
                    HS.NgaySinh AS DateOfBirth,
                    HS.GioiTinh AS Gender,
                    L.TenLop AS ClassName,
                    HS.MaDinhDanh AS IdentityCode,
                    HS.NoiSinh AS PlaceOfBirth,
                    HS.DanToc AS Ethnicity,
                    HS.TonGiao AS Religion,
                    HS.QuocGia AS Country,
                    HS.TinhThanh AS Province,
                    HS.QuanHuyen AS District,
                    HS.XaPhuong AS Ward,
                    HS.DiaChiThuongTru AS PermanentAddress,
                    HS.SDT AS Mobile,
                    HS.Email AS Email,
                    PH.HoTenCha AS FatherName,
                    PH.SoDienThoaiCha AS FatherPhone,
                    PH.HoTenMe AS MotherName,
                    PH.SoDienThoaiMe AS MotherPhone
                FROM 
                    HocSinh HS
                LEFT JOIN 
                    LopHoc L ON HS.MaLop = L.MaLop
                LEFT JOIN
                    NguoiDung ND ON HS.MaNguoiDung = ND.MaNguoiDung
                LEFT JOIN
                    PhuHuynh PH ON HS.MaHS = PH.MaHS
                WHERE 
                    HS.MaHS = @MaHS";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaHS", maHS }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    ThongTinHSDTO student = new ThongTinHSDTO();
                    DataRow row = dt.Rows[0];

                    // Map thông tin cơ bản
                    student.StudentId = row["StudentId"].ToString();
                    student.FullName = GetValueOrDefault(row, "FullName", "-----");
                    student.Gender = GetValueOrDefault(row, "Gender", "-----");
                    student.ClassName = GetValueOrDefault(row, "ClassName", "-----");
                    student.PermanentAddress = GetValueOrDefault(row, "Address", "-----");

                    // Map các trường thông tin cá nhân mở rộng
                    student.IdentityCode = GetValueOrDefault(row, "IdentityCode", "-----");
                    student.PlaceOfBirth = GetValueOrDefault(row, "PlaceOfBirth", "-----");
                    student.Ethnicity = GetValueOrDefault(row, "Ethnicity", "-----");
                    student.Religion = GetValueOrDefault(row, "Religion", "-----");
                    student.Country = GetValueOrDefault(row, "Country", "-----");
                    student.Province = GetValueOrDefault(row, "Province", "-----");
                    student.District = GetValueOrDefault(row, "District", "-----");
                    student.Ward = GetValueOrDefault(row, "Ward", "-----");
                    student.PermanentAddress = GetValueOrDefault(row, "PermanentAddress", "-----");
                    student.Mobile = GetValueOrDefault(row, "Mobile", "-----");
                    student.Email = GetValueOrDefault(row, "Email", "-----");

                    // Map thông tin phụ huynh
                    student.FatherName = GetValueOrDefault(row, "FatherName", "-----");
                    student.FatherPhone = GetValueOrDefault(row, "FatherPhone", "-----");
                    student.MotherName = GetValueOrDefault(row, "MotherName", "-----");
                    student.MotherPhone = GetValueOrDefault(row, "MotherPhone", "-----");

                    // Xử lý ngày sinh
                    if (row["DateOfBirth"] != DBNull.Value)
                    {
                        student.DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
                    }
                    else
                    {
                        student.DateOfBirth = DateTime.Now;
                    }

                    return student;
                }
                else
                {
                    Console.WriteLine($"Không tìm thấy học sinh với mã: {maHS}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi trong GetStudentById: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }

            return null;
        }

        ///// <summary>
        ///// Lấy thông tin phụ huynh nếu có trong cơ sở dữ liệu
        ///// </summary>
        //private void GetParentInfo(int maHS, ThongTinHSDTO student)
        //{
        //    try
        //    {
        //        // Kiểm tra xem có bảng phụ huynh không
        //        string checkTableQuery = @"
        //                        IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PhuHuynh')
        //                        SELECT 1 AS TableExists
        //                        ELSE
        //                        SELECT 0 AS TableExists";

        //        DataTable checkTable = db.ExecuteQuery(checkTableQuery);
        //        bool tableExists = checkTable != null && checkTable.Rows.Count > 0 &&
        //                          Convert.ToBoolean(checkTable.Rows[0]["TableExists"]);

        //        if (tableExists)
        //        {
        //            string query = @"
        //                            SELECT 
        //                                HoTenCha, SoDienThoaiCha, HoTenMe, SoDienThoaiMe
        //                            FROM 
        //                                PhuHuynh
        //                            WHERE 
        //                                MaHS = @MaHS";

        //            Dictionary<string, object> parameters = new Dictionary<string, object>
        //                            {
        //                                { "@MaHS", maHS }
        //                            };

        //            DataTable dt = db.ExecuteQuery(query, parameters);
        //            if (dt != null && dt.Rows.Count > 0)
        //            {
        //                DataRow row = dt.Rows[0];
        //                student.FatherName = GetValueOrDefault(row, "HoTenCha", "-----");
        //                student.FatherPhone = GetValueOrDefault(row, "SoDienThoaiCha", "-----");
        //                student.MotherName = GetValueOrDefault(row, "HoTenMe", "-----");
        //                student.MotherPhone = GetValueOrDefault(row, "SoDienThoaiMe", "-----");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Lỗi khi lấy thông tin phụ huynh: {ex.Message}");
        //    }
        //}

        /// <summary>
        /// Cập nhật thông tin cơ bản của học sinh
        /// </summary>
        /// <param name="student">Thông tin học sinh</param>
        /// <returns>True nếu cập nhật thành công, ngược lại là False</returns>
        public bool UpdateStudentBasicInfo(ThongTinHSDTO student)
        {
            try
            {
                // Cập nhật thông tin trong bảng HocSinh
                string query = @"
                                UPDATE HocSinh SET
                                    HoTen = @HoTen,
                                    NgaySinh = @NgaySinh,
                                    GioiTinh = @GioiTinh,
                                    MaDinhDanh = @MaDinhDanh,
                                    NoiSinh = @NoiSinh,
                                    DanToc = @DanToc,
                                    TonGiao = @TonGiao,
                                    QuocGia = @QuocGia,
                                    TinhThanh = @TinhThanh,
                                    QuanHuyen = @QuanHuyen,
                                    XaPhuong = @XaPhuong,
                                    DiaChiThuongTru = @DiaChi,
                                    SDT = @SDT,
                                    Email = @Email
                                WHERE MaHS = @StudentId";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                                {
                                    { "@HoTen", string.IsNullOrEmpty(student.FullName) || student.FullName == "-----" ? DBNull.Value : (object)student.FullName },
                                    { "@NgaySinh", student.DateOfBirth },
                                    { "@GioiTinh", string.IsNullOrEmpty(student.Gender) || student.Gender == "-----" ? DBNull.Value : (object)student.Gender },
                                    { "@MaDinhDanh", string.IsNullOrEmpty(student.IdentityCode) || student.IdentityCode == "-----" ? DBNull.Value : (object)student.IdentityCode },
                                    { "@NoiSinh", string.IsNullOrEmpty(student.PlaceOfBirth) || student.PlaceOfBirth == "-----" ? DBNull.Value : (object)student.PlaceOfBirth },
                                    { "@DanToc", string.IsNullOrEmpty(student.Ethnicity) || student.Ethnicity == "-----" ? DBNull.Value : (object)student.Ethnicity },
                                    { "@TonGiao", string.IsNullOrEmpty(student.Religion) || student.Religion == "-----" ? DBNull.Value : (object)student.Religion },
                                    { "@QuocGia", string.IsNullOrEmpty(student.Country) || student.Country == "-----" ? DBNull.Value : (object)student.Country },
                                    { "@TinhThanh", string.IsNullOrEmpty(student.Province) || student.Province == "-----" ? DBNull.Value : (object)student.Province },
                                    { "@QuanHuyen", string.IsNullOrEmpty(student.District) || student.District == "-----" ? DBNull.Value : (object)student.District },
                                    { "@XaPhuong", string.IsNullOrEmpty(student.Ward) || student.Ward == "-----" ? DBNull.Value : (object)student.Ward },
                                    { "@DiaChi", string.IsNullOrEmpty(student.PermanentAddress) || student.PermanentAddress == "-----" ? DBNull.Value : (object)student.PermanentAddress },
                                    { "@SDT", string.IsNullOrEmpty(student.Mobile) || student.Mobile == "-----" ? DBNull.Value : (object)student.Mobile },
                                    { "@Email", string.IsNullOrEmpty(student.Email) || student.Email == "-----" ? DBNull.Value : (object)student.Email },
                                    { "@StudentId", Convert.ToInt32(student.StudentId) }
                                };

                bool result = db.ExecuteNonQuery(query, parameters);

                // Cập nhật thông tin phụ huynh
                if (result)
                {
                    UpdateParentInfo(
                        Convert.ToInt32(student.StudentId),
                        student.FatherName,
                        student.FatherPhone,
                        student.MotherName,
                        student.MotherPhone
                    );
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật thông tin học sinh: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lưu ảnh đại diện của học sinh
        /// </summary>
        /// <param name="maHS">Mã học sinh</param>
        /// <param name="avatar">Ảnh đại diện</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        public bool SaveStudentAvatar(int maHS, Image avatar)
        {
            try
            {
                if (avatar == null)
                    return false;

                // Chuyển đổi ảnh thành byte[]
                byte[] imageData;
                using (MemoryStream ms = new MemoryStream())
                {
                    avatar.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    imageData = ms.ToArray();
                }

                // Tạo bảng HinhAnhHocSinh nếu chưa tồn tại
                string createTableQuery = @"
                                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'HinhAnhHocSinh')
                                BEGIN
                                    CREATE TABLE HinhAnhHocSinh (
                                        MaHS INT PRIMARY KEY,
                                        HinhAnh VARBINARY(MAX),
                                        NgayCapNhat DATETIME DEFAULT GETDATE(),
                                        FOREIGN KEY (MaHS) REFERENCES HocSinh(MaHS)
                                    )
                                END";

                db.ExecuteNonQuery(createTableQuery);

                // Kiểm tra xem đã có avatar trong CSDL chưa
                string checkQuery = "SELECT COUNT(*) FROM HinhAnhHocSinh WHERE MaHS = @MaHS";
                Dictionary<string, object> checkParams = new Dictionary<string, object>
                                {
                                    { "@MaHS", maHS }
                                };

                int count = Convert.ToInt32(db.ExecuteScalar(checkQuery, checkParams));

                string query;
                if (count > 0)
                {
                    // Cập nhật avatar hiện có
                    query = "UPDATE HinhAnhHocSinh SET HinhAnh = @HinhAnh, NgayCapNhat = GETDATE() WHERE MaHS = @MaHS";
                }
                else
                {
                    // Thêm avatar mới
                    query = "INSERT INTO HinhAnhHocSinh (MaHS, HinhAnh, NgayCapNhat) VALUES (@MaHS, @HinhAnh, GETDATE())";
                }

                Dictionary<string, object> parameters = new Dictionary<string, object>
                                {
                                    { "@MaHS", maHS },
                                    { "@HinhAnh", imageData }
                                };

                return db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lưu ảnh đại diện: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách tất cả học sinh
        /// </summary>
        /// <returns>Danh sách các đối tượng StudentInfo</returns>
        public List<ThongTinHSDTO> GetAllStudents()
        {
            List<ThongTinHSDTO> students = new List<ThongTinHSDTO>();

            try
            {
                string query = @"
                SELECT 
                    HS.MaHS AS StudentId,
                    HS.HoTen AS FullName,
                    HS.NgaySinh AS DateOfBirth,
                    HS.GioiTinh AS Gender,
                    HS.MaDinhDanh AS IdentityCode,
                    HS.NoiSinh AS PlaceOfBirth,
                    HS.DanToc AS Ethnicity,
                    HS.TonGiao AS Religion,
                    HS.QuocGia AS Country, 
                    HS.TinhThanh AS Province,
                    HS.QuanHuyen AS District,
                    HS.XaPhuong AS Ward,
                    HS.DiaChiThuongTru AS PermanentAddress,
                    HS.SDT AS Mobile,
                    HS.Email AS Email,
                    L.MaLop AS ClassId,
                    L.TenLop AS ClassName,
                    PH.HoTenCha AS FatherName,
                    PH.SoDienThoaiCha AS FatherPhone,
                    PH.HoTenMe AS MotherName,
                    PH.SoDienThoaiMe AS MotherPhone
                FROM 
                    HocSinh HS
                LEFT JOIN 
                    LopHoc L ON HS.MaLop = L.MaLop
                LEFT JOIN
                    PhuHuynh PH ON HS.MaHS = PH.MaHS
                ORDER BY 
                    L.TenLop, HS.HoTen";

                DataTable dt = db.ExecuteQuery(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ThongTinHSDTO student = new ThongTinHSDTO
                        {
                            StudentId = GetValueOrDefault(row, "StudentId", ""),
                            FullName = GetValueOrDefault(row, "FullName", ""),
                            Gender = GetValueOrDefault(row, "Gender", ""),
                            IdentityCode = GetValueOrDefault(row, "IdentityCode", ""),
                            PlaceOfBirth = GetValueOrDefault(row, "PlaceOfBirth", ""),
                            Ethnicity = GetValueOrDefault(row, "Ethnicity", ""),
                            Religion = GetValueOrDefault(row, "Religion", ""),
                            Country = GetValueOrDefault(row, "Country", "Việt Nam"),
                            Province = GetValueOrDefault(row, "Province", ""),
                            District = GetValueOrDefault(row, "District", ""),
                            Ward = GetValueOrDefault(row, "Ward", ""),
                            PermanentAddress = GetValueOrDefault(row, "PermanentAddress", ""),
                            Mobile = GetValueOrDefault(row, "Mobile", ""),
                            Email = GetValueOrDefault(row, "Email", ""),
                            ClassName = GetValueOrDefault(row, "ClassName", ""),
                            FatherName = GetValueOrDefault(row, "FatherName", ""),
                            FatherPhone = GetValueOrDefault(row, "FatherPhone", ""),
                            MotherName = GetValueOrDefault(row, "MotherName", ""),
                            MotherPhone = GetValueOrDefault(row, "MotherPhone", ""),
                            DateOfBirth = row["DateOfBirth"] != DBNull.Value ?
                                Convert.ToDateTime(row["DateOfBirth"]) : DateTime.Now
                        };

                        if (row["ClassId"] != DBNull.Value)
                        {
                            student.ClassId = Convert.ToInt32(row["ClassId"]);
                        }

                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách học sinh: {ex.Message}");
            }

            return students;
        }

        /// <summary>
        /// Lấy danh sách học sinh theo lớp
        /// </summary>
        /// <param name="maLop">Mã lớp học</param>
        /// <returns>Danh sách các đối tượng StudentInfo</returns>
        public List<ThongTinHSDTO> GetStudentsByClass(int maLop)
        {
            List<ThongTinHSDTO> students = new List<ThongTinHSDTO>();

            try
            {
                string query = @"
                SELECT 
                    HS.MaHS AS StudentId,
                    HS.HoTen AS FullName,
                    HS.NgaySinh AS DateOfBirth,
                    HS.GioiTinh AS Gender,
                    HS.MaDinhDanh AS IdentityCode,
                    HS.NoiSinh AS PlaceOfBirth,
                    HS.DanToc AS Ethnicity,
                    HS.TonGiao AS Religion,
                    HS.QuocGia AS Country, 
                    HS.TinhThanh AS Province,
                    HS.QuanHuyen AS District,
                    HS.XaPhuong AS Ward,
                    HS.DiaChiThuongTru AS PermanentAddress,
                    HS.SDT AS Mobile,
                    HS.Email AS Email,
                    L.MaLop AS ClassId,
                    L.TenLop AS ClassName,
                    PH.HoTenCha AS FatherName,
                    PH.SoDienThoaiCha AS FatherPhone,
                    PH.HoTenMe AS MotherName,
                    PH.SoDienThoaiMe AS MotherPhone
                FROM 
                    HocSinh HS
                LEFT JOIN 
                    LopHoc L ON HS.MaLop = L.MaLop
                LEFT JOIN
                    PhuHuynh PH ON HS.MaHS = PH.MaHS
                WHERE 
                    HS.MaLop = @MaLop
                ORDER BY 
                    HS.HoTen";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaLop", maLop }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ThongTinHSDTO student = new ThongTinHSDTO
                        {
                            StudentId = GetValueOrDefault(row, "StudentId", ""),
                            FullName = GetValueOrDefault(row, "FullName", ""),
                            Gender = GetValueOrDefault(row, "Gender", ""),
                            IdentityCode = GetValueOrDefault(row, "IdentityCode", ""),
                            PlaceOfBirth = GetValueOrDefault(row, "PlaceOfBirth", ""),
                            Ethnicity = GetValueOrDefault(row, "Ethnicity", ""),
                            Religion = GetValueOrDefault(row, "Religion", ""),
                            Country = GetValueOrDefault(row, "Country", "Việt Nam"),
                            Province = GetValueOrDefault(row, "Province", ""),
                            District = GetValueOrDefault(row, "District", ""),
                            Ward = GetValueOrDefault(row, "Ward", ""),
                            PermanentAddress = GetValueOrDefault(row, "PermanentAddress", ""),
                            Mobile = GetValueOrDefault(row, "Mobile", ""),
                            Email = GetValueOrDefault(row, "Email", ""),
                            ClassName = GetValueOrDefault(row, "ClassName", ""),
                            FatherName = GetValueOrDefault(row, "FatherName", ""),
                            FatherPhone = GetValueOrDefault(row, "FatherPhone", ""),
                            MotherName = GetValueOrDefault(row, "MotherName", ""),
                            MotherPhone = GetValueOrDefault(row, "MotherPhone", ""),
                            DateOfBirth = row["DateOfBirth"] != DBNull.Value ?
                                Convert.ToDateTime(row["DateOfBirth"]) : DateTime.Now
                        };

                        if (row["ClassId"] != DBNull.Value)
                        {
                            student.ClassId = Convert.ToInt32(row["ClassId"]);
                        }

                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách học sinh theo lớp: {ex.Message}");
            }

            return students;
        }

        /// <summary>
        /// Tìm kiếm học sinh theo từ khóa (tên, mã hoặc lớp)
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm</param>
        /// <returns>Danh sách học sinh thỏa điều kiện tìm kiếm</returns>
        public List<ThongTinHSDTO> SearchStudents(string keyword)
        {
            List<ThongTinHSDTO> students = new List<ThongTinHSDTO>();

            try
            {
                string query = @"
                SELECT 
                    HS.MaHS AS StudentId,
                    HS.HoTen AS FullName,
                    HS.NgaySinh AS DateOfBirth,
                    HS.GioiTinh AS Gender,
                    HS.MaDinhDanh AS IdentityCode,
                    HS.NoiSinh AS PlaceOfBirth,
                    HS.DanToc AS Ethnicity,
                    HS.TonGiao AS Religion,
                    HS.QuocGia AS Country, 
                    HS.TinhThanh AS Province,
                    HS.QuanHuyen AS District,
                    HS.XaPhuong AS Ward,
                    HS.DiaChiThuongTru AS PermanentAddress,
                    HS.SDT AS Mobile,
                    HS.Email AS Email,
                    L.MaLop AS ClassId,
                    L.TenLop AS ClassName,
                    PH.HoTenCha AS FatherName,
                    PH.SoDienThoaiCha AS FatherPhone,
                    PH.HoTenMe AS MotherName,
                    PH.SoDienThoaiMe AS MotherPhone
                FROM 
                    HocSinh HS
                LEFT JOIN 
                    LopHoc L ON HS.MaLop = L.MaLop
                LEFT JOIN
                    PhuHuynh PH ON HS.MaHS = PH.MaHS
                WHERE 
                    HS.HoTen LIKE @Keyword 
                    OR CAST(HS.MaHS AS VARCHAR) LIKE @Keyword
                    OR L.TenLop LIKE @Keyword
                    OR HS.MaDinhDanh LIKE @Keyword
                ORDER BY 
                    L.TenLop, HS.HoTen";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@Keyword", $"%{keyword}%" }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ThongTinHSDTO student = new ThongTinHSDTO
                        {
                            StudentId = GetValueOrDefault(row, "StudentId", ""),
                            FullName = GetValueOrDefault(row, "FullName", ""),
                            Gender = GetValueOrDefault(row, "Gender", ""),
                            IdentityCode = GetValueOrDefault(row, "IdentityCode", ""),
                            PlaceOfBirth = GetValueOrDefault(row, "PlaceOfBirth", ""),
                            Ethnicity = GetValueOrDefault(row, "Ethnicity", ""),
                            Religion = GetValueOrDefault(row, "Religion", ""),
                            Country = GetValueOrDefault(row, "Country", "Việt Nam"),
                            Province = GetValueOrDefault(row, "Province", ""),
                            District = GetValueOrDefault(row, "District", ""),
                            Ward = GetValueOrDefault(row, "Ward", ""),
                            PermanentAddress = GetValueOrDefault(row, "PermanentAddress", ""),
                            Mobile = GetValueOrDefault(row, "Mobile", ""),
                            Email = GetValueOrDefault(row, "Email", ""),
                            ClassName = GetValueOrDefault(row, "ClassName", ""),
                            FatherName = GetValueOrDefault(row, "FatherName", ""),
                            FatherPhone = GetValueOrDefault(row, "FatherPhone", ""),
                            MotherName = GetValueOrDefault(row, "MotherName", ""),
                            MotherPhone = GetValueOrDefault(row, "MotherPhone", ""),
                            DateOfBirth = row["DateOfBirth"] != DBNull.Value ?
                                Convert.ToDateTime(row["DateOfBirth"]) : DateTime.Now
                        };

                        if (row["ClassId"] != DBNull.Value)
                        {
                            student.ClassId = Convert.ToInt32(row["ClassId"]);
                        }

                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tìm kiếm học sinh: {ex.Message}");
            }

            return students;
        }

        /// <summary>
        /// Lấy giá trị từ DataRow, trả về giá trị mặc định nếu không có hoặc là DBNull
        /// </summary>
        private string GetValueOrDefault(DataRow row, string columnName, string defaultValue)
        {
            if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
                return row[columnName].ToString();
            return defaultValue;
        }
        /// <summary>
        /// Cập nhật thông tin phụ huynh
        /// </summary>
        /// <param name="maHS">Mã học sinh</param>
        /// <param name="fatherName">Tên cha</param>
        /// <param name="fatherPhone">Số điện thoại cha</param>
        /// <param name="motherName">Tên mẹ</param>
        /// <param name="motherPhone">Số điện thoại mẹ</param>
        /// <returns>True nếu cập nhật thành công, ngược lại là False</returns>
        public bool UpdateParentInfo(int maHS, string fatherName, string fatherPhone, string motherName, string motherPhone)
        {
            try
            {
                // Kiểm tra xem đã có thông tin phụ huynh cho học sinh này chưa
                string checkQuery = "SELECT COUNT(*) FROM PhuHuynh WHERE MaHS = @MaHS";
                Dictionary<string, object> checkParams = new Dictionary<string, object>
                {
                    { "@MaHS", maHS }
                };

                int count = Convert.ToInt32(db.ExecuteScalar(checkQuery, checkParams));

                string query;
                if (count > 0)
                {
                    // Cập nhật thông tin phụ huynh hiện có
                    query = @"
                    UPDATE PhuHuynh SET
                        HoTenCha = @HoTenCha,
                        SoDienThoaiCha = @SoDienThoaiCha,
                        HoTenMe = @HoTenMe,
                        SoDienThoaiMe = @SoDienThoaiMe
                    WHERE MaHS = @MaHS";
                }
                else
                {
                    // Thêm mới thông tin phụ huynh
                    query = @"
                    INSERT INTO PhuHuynh (MaHS, HoTenCha, SoDienThoaiCha, HoTenMe, SoDienThoaiMe)
                    VALUES (@MaHS, @HoTenCha, @SoDienThoaiCha, @HoTenMe, @SoDienThoaiMe)";
                }

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaHS", maHS },
                    { "@HoTenCha", string.IsNullOrEmpty(fatherName) || fatherName == "-----" ? DBNull.Value : (object)fatherName },
                    { "@SoDienThoaiCha", string.IsNullOrEmpty(fatherPhone) || fatherPhone == "-----" ? DBNull.Value : (object)fatherPhone },
                    { "@HoTenMe", string.IsNullOrEmpty(motherName) || motherName == "-----" ? DBNull.Value : (object)motherName },
                    { "@SoDienThoaiMe", string.IsNullOrEmpty(motherPhone) || motherPhone == "-----" ? DBNull.Value : (object)motherPhone }
                };

                return db.ExecuteNonQuery(query, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật thông tin phụ huynh: {ex.Message}");
                return false;
            }
        }
        /// <summary>
        /// Thêm học sinh mới vào hệ thống kèm thông tin tài khoản
        /// </summary>
        /// <param name="student">Thông tin học sinh</param>
        /// <param name="maLop">Mã lớp học</param>
        /// <param name="tenDangNhap">Tên đăng nhập được tạo</param>
        /// <param name="matKhau">Mật khẩu được tạo</param>
        /// <returns>Mã học sinh nếu thành công, -1 nếu thất bại</returns>
        public int AddStudent(ThongTinHSDTO student, int maLop, out string tenDangNhap, out string matKhau)
        {
            tenDangNhap = string.Empty;
            matKhau = string.Empty;

            try
            {
                db.OpenConnection();

                // Tạo tài khoản người dùng
                string queryMaxMaNguoiDung = "SELECT ISNULL(MAX(MaNguoiDung), 0) + 1 AS NextMaNguoiDung FROM NguoiDung";
                DataTable dtMaxMaNguoiDung = db.ExecuteQuery(queryMaxMaNguoiDung);
                int maNguoiDung = Convert.ToInt32(dtMaxMaNguoiDung.Rows[0]["NextMaNguoiDung"]);

                // Tạo tên đăng nhập và mật khẩu
                matKhau = GenerateRandomPassword(8);
                tenDangNhap = $"hs{maNguoiDung}";

                // Thêm người dùng mới
                string queryInsertNguoiDung = @"
                INSERT INTO NguoiDung (MaNguoiDung, TenDangNhap, MatKhau, MaVaiTro, NgayTao)
                VALUES (@MaNguoiDung, @TenDangNhap, @MatKhau, 4, GETDATE())";

                Dictionary<string, object> userParams = new Dictionary<string, object>
                {
                    { "@MaNguoiDung", maNguoiDung },
                    { "@TenDangNhap", tenDangNhap },
                    { "@MatKhau", matKhau }
                };

                bool userInsertResult = db.ExecuteNonQuery(queryInsertNguoiDung, userParams);
                if (!userInsertResult)
                {
                    Console.WriteLine("Thêm tài khoản người dùng thất bại");
                    return -1;
                }

                // Tạo mã học sinh tự động
                int currentYear = DateTime.Now.Year;
                string studentIdStr = GenerateStudentId(currentYear, student.IdentityCode);
                int studentId = Convert.ToInt32(studentIdStr);

                // Thêm học sinh mới
                string queryInsertHocSinh = @"
                INSERT INTO HocSinh (
                    MaHS, MaNguoiDung, HoTen, NgaySinh, GioiTinh, 
                    MaDinhDanh, NoiSinh, DanToc, TonGiao, 
                    QuocGia, TinhThanh, QuanHuyen, XaPhuong, 
                    DiaChiThuongTru, SDT, Email, MaLop
                )
                VALUES (
                    @MaHS, @MaNguoiDung, @HoTen, @NgaySinh, @GioiTinh,
                    @MaDinhDanh, @NoiSinh, @DanToc, @TonGiao,
                    @QuocGia, @TinhThanh, @QuanHuyen, @XaPhuong,
                    @DiaChiThuongTru, @SDT, @Email, @MaLop
                )";

                Dictionary<string, object> studentParams = new Dictionary<string, object>
                {
                    { "@MaHS", studentId },
                    { "@MaNguoiDung", maNguoiDung },
                    { "@HoTen", string.IsNullOrEmpty(student.FullName) ? DBNull.Value : (object)student.FullName },
                    { "@NgaySinh", student.DateOfBirth },
                    { "@GioiTinh", string.IsNullOrEmpty(student.Gender) ? DBNull.Value : (object)student.Gender },
                    { "@MaDinhDanh", string.IsNullOrEmpty(student.IdentityCode) ? DBNull.Value : (object)student.IdentityCode },
                    { "@NoiSinh", string.IsNullOrEmpty(student.PlaceOfBirth) ? DBNull.Value : (object)student.PlaceOfBirth },
                    { "@DanToc", string.IsNullOrEmpty(student.Ethnicity) ? DBNull.Value : (object)student.Ethnicity },
                    { "@TonGiao", string.IsNullOrEmpty(student.Religion) ? DBNull.Value : (object)student.Religion },
                    { "@QuocGia", string.IsNullOrEmpty(student.Country) ? "Việt Nam" : (object)student.Country },
                    { "@TinhThanh", string.IsNullOrEmpty(student.Province) ? DBNull.Value : (object)student.Province },
                    { "@QuanHuyen", string.IsNullOrEmpty(student.District) ? DBNull.Value : (object)student.District },
                    { "@XaPhuong", string.IsNullOrEmpty(student.Ward) ? DBNull.Value : (object)student.Ward },
                    { "@DiaChiThuongTru", string.IsNullOrEmpty(student.PermanentAddress) ? DBNull.Value : (object)student.PermanentAddress },
                    { "@SDT", string.IsNullOrEmpty(student.Mobile) ? DBNull.Value : (object)student.Mobile },
                    { "@Email", string.IsNullOrEmpty(student.Email) ? DBNull.Value : (object)student.Email },
                    { "@MaLop", maLop }
                };

                // Thực hiện truy vấn và kiểm tra kết quả
                bool result = db.ExecuteNonQuery(queryInsertHocSinh, studentParams);

                if (!result)
                {
                    Console.WriteLine("Thêm học sinh thất bại");
                    return -1;
                }

                // Thêm thông tin phụ huynh nếu có
                if (!string.IsNullOrEmpty(student.FatherName) || !string.IsNullOrEmpty(student.MotherName) ||
                    !string.IsNullOrEmpty(student.FatherPhone) || !string.IsNullOrEmpty(student.MotherPhone))
                {
                    UpdateParentInfo(
                        studentId,
                        student.FatherName,
                        student.FatherPhone,
                        student.MotherName,
                        student.MotherPhone
                    );
                }

                return studentId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm học sinh: {ex.Message}");
                return -1;
            }
            finally
            {
                db.CloseConnection();
            }
        }

        /// <summary>
        /// Cập nhật thông tin học sinh (bao gồm thông tin cơ bản và thông tin phụ huynh)
        /// </summary>
        /// <param name="student">Thông tin học sinh đã cập nhật</param>
        /// <param name="maLop">Mã lớp học mới</param>
        /// <returns>True nếu cập nhật thành công, False nếu thất bại</returns>
        public bool UpdateStudent(ThongTinHSDTO student, int maLop)
        {
            try
            {
                // Cập nhật thông tin cơ bản
                string query = @"
                UPDATE HocSinh SET
                    HoTen = @HoTen,
                    NgaySinh = @NgaySinh,
                    GioiTinh = @GioiTinh,
                    MaDinhDanh = @MaDinhDanh,
                    NoiSinh = @NoiSinh,
                    DanToc = @DanToc,
                    TonGiao = @TonGiao,
                    QuocGia = @QuocGia,
                    TinhThanh = @TinhThanh,
                    QuanHuyen = @QuanHuyen,
                    XaPhuong = @XaPhuong,
                    DiaChiThuongTru = @DiaChiThuongTru,
                    SDT = @SDT,
                    Email = @Email,
                    MaLop = @MaLop
                WHERE MaHS = @MaHS";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaHS", Convert.ToInt32(student.StudentId) },
                    { "@HoTen", string.IsNullOrEmpty(student.FullName) ? DBNull.Value : (object)student.FullName },
                    { "@NgaySinh", student.DateOfBirth },
                    { "@GioiTinh", string.IsNullOrEmpty(student.Gender) ? DBNull.Value : (object)student.Gender },
                    { "@MaDinhDanh", string.IsNullOrEmpty(student.IdentityCode) ? DBNull.Value : (object)student.IdentityCode },
                    { "@NoiSinh", string.IsNullOrEmpty(student.PlaceOfBirth) ? DBNull.Value : (object)student.PlaceOfBirth },
                    { "@DanToc", string.IsNullOrEmpty(student.Ethnicity) ? DBNull.Value : (object)student.Ethnicity },
                    { "@TonGiao", string.IsNullOrEmpty(student.Religion) ? DBNull.Value : (object)student.Religion },
                    { "@QuocGia", string.IsNullOrEmpty(student.Country) ? "Việt Nam" : (object)student.Country },
                    { "@TinhThanh", string.IsNullOrEmpty(student.Province) ? DBNull.Value : (object)student.Province },
                    { "@QuanHuyen", string.IsNullOrEmpty(student.District) ? DBNull.Value : (object)student.District },
                    { "@XaPhuong", string.IsNullOrEmpty(student.Ward) ? DBNull.Value : (object)student.Ward },
                    { "@DiaChiThuongTru", string.IsNullOrEmpty(student.PermanentAddress) ? DBNull.Value : (object)student.PermanentAddress },
                    { "@SDT", string.IsNullOrEmpty(student.Mobile) ? DBNull.Value : (object)student.Mobile },
                    { "@Email", string.IsNullOrEmpty(student.Email) ? DBNull.Value : (object)student.Email },
                    { "@MaLop", maLop }
                };

                bool result = db.ExecuteNonQuery(query, parameters);

                // Cập nhật thông tin phụ huynh
                if (result)
                {
                    UpdateParentInfo(
                        Convert.ToInt32(student.StudentId),
                        student.FatherName,
                        student.FatherPhone,
                        student.MotherName,
                        student.MotherPhone
                    );
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật thông tin học sinh: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa học sinh và tài khoản liên kết
        /// </summary>
        /// <param name="maHS">Mã học sinh cần xóa</param>
        /// <returns>True nếu xóa thành công, False nếu thất bại</returns>
        public bool DeleteStudent(int maHS)
        {
            try
            {
                // Lấy mã người dùng liên kết với học sinh
                string queryGetMaNguoiDung = "SELECT MaNguoiDung FROM HocSinh WHERE MaHS = @MaHS";
                Dictionary<string, object> getParams = new Dictionary<string, object>
                {
                    { "@MaHS", maHS }
                };

                object result = db.ExecuteScalar(queryGetMaNguoiDung, getParams);

                if (result == null || result == DBNull.Value)
                    return false;

                int maNguoiDung = Convert.ToInt32(result);

                // Thực hiện xóa các bảng liên quan trước
                List<string> deleteQueries = new List<string>();

                // Kiểm tra và xóa thông tin trong bảng PhuHuynh
                string checkParentQuery = "SELECT COUNT(*) FROM PhuHuynh WHERE MaHS = " + maHS;
                int parentExists = Convert.ToInt32(db.ExecuteScalar(checkParentQuery));
                if (parentExists > 0)
                {
                    deleteQueries.Add("DELETE FROM PhuHuynh WHERE MaHS = " + maHS);
                }

                // Kiểm tra và xóa thông tin trong bảng HinhAnhHocSinh
                string checkAvatarQuery = "SELECT COUNT(*) FROM HinhAnhHocSinh WHERE MaHS = " + maHS;
                int avatarExists = Convert.ToInt32(db.ExecuteScalar(checkAvatarQuery));
                if (avatarExists > 0)
                {
                    deleteQueries.Add("DELETE FROM HinhAnhHocSinh WHERE MaHS = " + maHS);
                }

                // Xóa các bảng liên quan khác nếu cần
                // Chẳng hạn như DiemSo, DiemDanh, DonXinNghi...
                string checkDiemSoQuery = "SELECT COUNT(*) FROM DiemSo WHERE MaHS = " + maHS;
                int diemSoExists = Convert.ToInt32(db.ExecuteScalar(checkDiemSoQuery));
                if (diemSoExists > 0)
                {
                    deleteQueries.Add("DELETE FROM DiemSo WHERE MaHS = " + maHS);
                }

                string checkDiemDanhQuery = "SELECT COUNT(*) FROM DiemDanh WHERE MaHS = " + maHS;
                int diemDanhExists = Convert.ToInt32(db.ExecuteScalar(checkDiemDanhQuery));
                if (diemDanhExists > 0)
                {
                    deleteQueries.Add("DELETE FROM DiemDanh WHERE MaHS = " + maHS);
                }

                string checkDonXinNghiQuery = "SELECT COUNT(*) FROM DonXinNghi WHERE MaHS = " + maHS;
                int donXinNghiExists = Convert.ToInt32(db.ExecuteScalar(checkDonXinNghiQuery));
                if (donXinNghiExists > 0)
                {
                    deleteQueries.Add("DELETE FROM DonXinNghi WHERE MaHS = " + maHS);
                }

                // Kiểm tra và xóa các bài làm liên quan đến BaiLam_TracNghiệm và BaiLam_TuLuan trước
                string getBaiLamQuery = "SELECT MaBaiLam FROM BaiLam WHERE MaHS = " + maHS;
                DataTable dtBaiLam = db.ExecuteQuery(getBaiLamQuery);
                if (dtBaiLam != null && dtBaiLam.Rows.Count > 0)
                {
                    foreach (DataRow row in dtBaiLam.Rows)
                    {
                        int maBaiLam = Convert.ToInt32(row["MaBaiLam"]);
                        
                        // Xóa các câu trả lời trắc nghiệm
                        string checkTNQuery = $"SELECT COUNT(*) FROM BaiLam_TracNghiem WHERE MaBaiLam = {maBaiLam}";
                        int tnExists = Convert.ToInt32(db.ExecuteScalar(checkTNQuery));
                        if (tnExists > 0)
                        {
                            deleteQueries.Add($"DELETE FROM BaiLam_TracNghiem WHERE MaBaiLam = {maBaiLam}");
                        }
                        
                        // Xóa các câu trả lời tự luận
                        string checkTLQuery = $"SELECT COUNT(*) FROM BaiLam_TuLuan WHERE MaBaiLam = {maBaiLam}";
                        int tlExists = Convert.ToInt32(db.ExecuteScalar(checkTLQuery));
                        if (tlExists > 0)
                        {
                            deleteQueries.Add($"DELETE FROM BaiLam_TuLuan WHERE MaBaiLam = {maBaiLam}");
                        }
                    }
                    
                    // Sau khi xóa các câu trả lời, xóa bài làm
                    deleteQueries.Add("DELETE FROM BaiLam WHERE MaHS = " + maHS);
                }

                // Xóa học sinh
                deleteQueries.Add("DELETE FROM HocSinh WHERE MaHS = " + maHS);

                // Xóa người dùng liên kết
                deleteQueries.Add("DELETE FROM NguoiDung WHERE MaNguoiDung = " + maNguoiDung);

                // Thực hiện xóa trong transaction
                bool success = db.ExecuteTransaction(deleteQueries);

                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa học sinh: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách lớp học
        /// </summary>
        /// <returns>DataTable chứa danh sách lớp</returns>
        public DataTable GetClasses()
        {
            try
            {
                string query = "SELECT MaLop, TenLop FROM LopHoc ORDER BY TenLop";
                return db.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách lớp: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Lấy ảnh đại diện của học sinh
        /// </summary>
        /// <param name="maHS">Mã học sinh</param>
        /// <returns>Ảnh đại diện dạng Image hoặc null nếu không có</returns>
        public Image GetStudentAvatar(int maHS)
        {
            try
            {
                string query = "SELECT HinhAnh FROM HinhAnhHocSinh WHERE MaHS = @MaHS";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaHS", maHS }
                };

                DataTable dt = db.ExecuteQuery(query, parameters);

                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["HinhAnh"] != DBNull.Value)
                {
                    byte[] imageData = (byte[])dt.Rows[0]["HinhAnh"];
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        return Image.FromStream(ms);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy ảnh đại diện học sinh: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Tạo mật khẩu ngẫu nhiên
        /// </summary>
        private string GenerateRandomPassword(int length)
        {
            Random random = new Random();
            const string chars = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// Tạo mã học sinh duy nhất dựa trên năm hiện tại và số căn cước công dân
        /// </summary>
        /// <param name="currentYear">Năm hiện tại</param>
        /// <param name="citizenId">Số căn cước công dân</param>
        /// <returns>Mã học sinh được tạo tự động</returns>
        private string GenerateStudentId(int currentYear, string citizenId)
        {
            // Kiểm tra nếu căn cước công dân là null hoặc trống
            if (string.IsNullOrEmpty(citizenId))
            {
                // Tạo một ID mặc định theo năm và số ngẫu nhiên
                Random random = new Random();
                return $"{currentYear}{random.Next(100000, 999999)}";
            }

            // Lấy 6 ký tự cuối của CCCD
            string lastSixDigits = citizenId.Length >= 6 ?
                citizenId.Substring(citizenId.Length - 6) :
                citizenId.PadLeft(6, '0');

            // Tạo mã học sinh với định dạng: năm + 6 số cuối CCCD
            string proposedId = $"{currentYear}{lastSixDigits}";

            // Kiểm tra xem mã học sinh đã tồn tại chưa
            string checkQuery = $"SELECT COUNT(*) FROM HocSinh WHERE MaHS = {proposedId}";

            // Nếu đã tồn tại, thêm số ngẫu nhiên ở cuối
            int count = Convert.ToInt32(db.ExecuteScalar(checkQuery));
            if (count > 0)
            {
                Random random = new Random();
                proposedId = $"{proposedId}{random.Next(10, 99)}";
            }

            return proposedId;
        }
        /// <summary>
        /// Get class ID for a specific student
        /// </summary>
        /// <param name="maHS">Student ID</param>
        /// <returns>Class ID or 0 if not found</returns>
        public int GetMaLopByMaHS(int maHS)
        {
            try
            {
                string query = "SELECT MaLop FROM HocSinh WHERE MaHS = @MaHS";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@MaHS", maHS }
                };

                object result = db.ExecuteScalar(query, parameters);

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving class for student: {ex.Message}");
            }

            return 0;
        }
    }
}
