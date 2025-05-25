using QuanLyTruongHoc.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.DAL
{
    public class TKBDAO
    {
        private DatabaseHelper dbHelper;

        public TKBDAO()
        {
            dbHelper = new DatabaseHelper();
        }

        /// <summary>
        /// Lấy danh sách các năm học
        /// </summary>
        public List<string> GetSchoolYears()
        {
            List<string> years = new List<string>();
            try
            {
                string query = @"SELECT DISTINCT NamHoc FROM LopHoc ORDER BY NamHoc";
                DataTable dt = dbHelper.ExecuteQuery(query);

                foreach (DataRow row in dt.Rows)
                {
                    years.Add(row["NamHoc"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách năm học: {ex.Message}");
            }
            return years;
        }

        /// <summary>
        /// Lấy thông tin lớp học của học sinh
        /// </summary>
        public DataRow GetClassInfo(int maHS)
        {
            try
            {
                string query = @"
                                    SELECT L.MaLop, L.TenLop, L.NamHoc 
                                    FROM HocSinh HS
                                    JOIN LopHoc L ON HS.MaLop = L.MaLop
                                    WHERE HS.MaHS = @MaHS";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                                {
                                    { "@MaHS", maHS }
                                };

                DataTable dt = dbHelper.ExecuteQuery(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy thông tin lớp học: {ex.Message}");
            }
            return null;
        }

        /// <summary>
        /// Tạo danh sách các khoảng thời gian trong năm học
        /// </summary>
        public List<KhoangThoiGianDTO> GetTimePeriods(string namHoc)
        {
            List<KhoangThoiGianDTO> timePeriods = new List<KhoangThoiGianDTO>();

            try
            {
                // Phân tích năm học (ví dụ: "2024–2025")
                string[] years = namHoc.Split(new char[] { '–', '-' }, StringSplitOptions.RemoveEmptyEntries);
                if (years.Length != 2)
                {

                    return timePeriods;
                }

                int startYear, endYear;
                if (!int.TryParse(years[0].Trim(), out startYear) || !int.TryParse(years[1].Trim(), out endYear))
                {
                    Console.WriteLine($"Không thể chuyển đổi năm học thành số: {namHoc}");
                    return timePeriods;
                }

                // Ngày bắt đầu: Tháng 9 của năm đầu tiên
                DateTime startDate = new DateTime(startYear, 9, 1);

                // Ngày kết thúc: Cuối tháng 5 của năm thứ hai
                DateTime endDate = new DateTime(endYear, 5, 31);

                // Điều chỉnh ngày bắt đầu để là thứ Hai
                while (startDate.DayOfWeek != DayOfWeek.Monday)
                {
                    startDate = startDate.AddDays(1);
                }

                // Tạo danh sách các khoảng thời gian (mỗi tuần từ thứ Hai đến Chủ nhật)
                DateTime periodStart = startDate;
                int weekCount = 1;

                while (periodStart <= endDate)
                {
                    DateTime periodEnd = periodStart.AddDays(6); // Chủ Nhật
                    string displayText = $"Tuần {weekCount}: {periodStart:dd/MM/yyyy} - {periodEnd:dd/MM/yyyy}";

                    timePeriods.Add(new KhoangThoiGianDTO(
                        periodStart,
                        periodEnd,
                        displayText));

                    periodStart = periodStart.AddDays(7);
                    weekCount++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tính toán các khoảng thời gian: {ex.Message}");
            }

            return timePeriods;
        }


        /// <summary>
        /// Lấy thời khóa biểu của một lớp trong một khoảng thời gian
        /// </summary>
        public List<TKBDTO> GetTimetable(int maLop, DateTime startDate, DateTime endDate)
        {
            List<TKBDTO> result = new List<TKBDTO>();

            try
            {
                string query = @"
                                    SELECT 
                                        tkb.MaTKB, 
                                        tkb.MaLop, 
                                        tkb.MaMon, 
                                        tkb.MaGV, 
                                        tkb.Ngay, 
                                        tkb.Thu, 
                                        tkb.Tiet,
                                        mh.TenMon, 
                                        gv.HoTen AS TenGiaoVien, 
                                        lh.TenLop
                                    FROM 
                                        ThoiKhoaBieu tkb
                                    INNER JOIN 
                                        MonHoc mh ON tkb.MaMon = mh.MaMon
                                    INNER JOIN 
                                        GiaoVien gv ON tkb.MaGV = gv.MaGV
                                    INNER JOIN 
                                        LopHoc lh ON tkb.MaLop = lh.MaLop
                                    WHERE 
                                        tkb.MaLop = @MaLop 
                                        AND tkb.Ngay >= @StartDate 
                                        AND tkb.Ngay <= @EndDate
                                    ORDER BY 
                                        tkb.Thu, 
                                        CASE 
                                            WHEN CHARINDEX('-', tkb.Tiet) > 0 
                                            THEN CONVERT(INT, LEFT(tkb.Tiet, CHARINDEX('-', tkb.Tiet) - 1)) 
                                            ELSE CONVERT(INT, tkb.Tiet) 
                                        END";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                            {
                                { "@MaLop", maLop },
                                { "@StartDate", startDate.Date },
                                { "@EndDate", endDate.Date }
                            };

                DataTable dt = dbHelper.ExecuteQuery(query, parameters);

                foreach (DataRow row in dt.Rows)
                {
                    TKBDTO tkb = new TKBDTO
                    {
                        MaTKB = Convert.ToInt32(row["MaTKB"]),
                        MaLop = Convert.ToInt32(row["MaLop"]),
                        MaMon = Convert.ToInt32(row["MaMon"]),
                        MaGV = Convert.ToInt32(row["MaGV"]),
                        Ngay = Convert.ToDateTime(row["Ngay"]),
                        Thu = Convert.ToInt32(row["Thu"]),
                        Tiet = row["Tiet"].ToString(),
                        TenMon = row["TenMon"].ToString() == "Giáo Dục Công Dân" ? "GDCD" : row["TenMon"].ToString(),
                        TenGiaoVien = row["TenGiaoVien"].ToString(),
                        TenLop = row["TenLop"].ToString()
                    };
                    result.Add(tkb);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy thời khóa biểu: {ex.Message}");
            }

            return result;
        }

        /// <summary>
        /// Xác định khoảng thời gian hiện tại trong danh sách
        /// </summary>
        public int GetCurrentPeriodIndex(List<KhoangThoiGianDTO> periods)
        {
            if (periods == null || periods.Count == 0)
                return 0;

            DateTime today = DateTime.Now.Date;

            for (int i = 0; i < periods.Count; i++)
            {
                if (today >= periods[i].NgayBatDau.Date && today <= periods[i].NgayKetThuc.Date)
                {
                    return i;
                }
            }

            // Nếu ngày hiện tại trước khoảng thời gian đầu tiên, trả về khoảng đầu tiên
            if (today < periods[0].NgayBatDau.Date)
                return 0;

            // Nếu ngày hiện tại sau khoảng thời gian cuối cùng, trả về khoảng cuối cùng
            if (today > periods[periods.Count - 1].NgayKetThuc.Date)
                return periods.Count - 1;

            return 0;
        }

        /// <summary>
        /// Xác định năm học hiện tại
        /// </summary>
        public string GetCurrentSchoolYear()
        {
            try
            {
                DateTime today = DateTime.Now;
                int currentYear = today.Year;
                int nextYear = currentYear + 1;
                int prevYear = currentYear - 1;

                // Nếu tháng từ 9-12, năm học là năm hiện tại - năm tiếp theo
                if (today.Month >= 9)
                {
                    return $"{currentYear}–{nextYear}";
                }
                // Nếu tháng từ 1-8, năm học là năm trước - năm hiện tại
                else
                {
                    return $"{prevYear}–{currentYear}";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xác định năm học hiện tại: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Tự động thiết lập năm học hiện tại
        /// </summary>
        /// <param name="namHoc">Tham chiếu đến chuỗi năm học</param>
        /// <returns>True nếu thiết lập thành công</returns>
        public bool SetupCurrentSchoolYear(out string namHoc)
        {
            try
            {
                // Xác định năm học hiện tại
                namHoc = GetCurrentSchoolYear();

                // Kiểm tra năm học có trong danh sách các năm học không
                List<string> availableYears = GetSchoolYears();
                if (!availableYears.Contains(namHoc))
                {
                    // Nếu không có năm học hiện tại trong danh sách, lấy năm học mới nhất
                    if (availableYears.Count > 0)
                    {
                        namHoc = availableYears.Last(); // Giả sử danh sách đã được sắp xếp
                    }
                    else
                    {
                        namHoc = string.Empty;
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thiết lập năm học hiện tại: {ex.Message}");
                namHoc = string.Empty;
                return false;
            }
        }
        /// <summary>
        /// Xác định tuần hiện tại trong danh sách các tuần học
        /// </summary>
        /// <param name="weeks">Danh sách các tuần học</param>
        /// <returns>Chỉ số của tuần hiện tại</returns>
        public int GetCurrentWeekIndex(List<TuanHocDTO> weeks)
        {
            if (weeks == null || weeks.Count == 0)
                return 0;

            DateTime today = DateTime.Now.Date;

            for (int i = 0; i < weeks.Count; i++)
            {
                if (today >= weeks[i].NgayBatDau.Date && today <= weeks[i].NgayKetThuc.Date)
                {
                    return i;
                }
            }

            // Nếu ngày hiện tại trước tuần đầu tiên, trả về tuần đầu tiên
            if (today < weeks[0].NgayBatDau.Date)
                return 0;

            // Nếu ngày hiện tại sau tuần cuối cùng, trả về tuần cuối cùng
            if (today > weeks[weeks.Count - 1].NgayKetThuc.Date)
                return weeks.Count - 1;

            return 0;
        }
    }
}
