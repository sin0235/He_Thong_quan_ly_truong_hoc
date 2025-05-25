using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTruongHoc.DTO
{
    /// <summary>
    /// Lớp DTO để ánh xạ dữ liệu đơn xin nghỉ học
    /// </summary>
    public class DonXinNghiDTO
    {
        /// <summary>
        /// Mã đơn xin nghỉ
        /// </summary>
        public int MaDon { get; set; }

        /// <summary>
        /// Mã học sinh
        /// </summary>
        public int MaHS { get; set; }

        /// <summary>
        /// Họ tên học sinh
        /// </summary>
        public string HoTenHocSinh { get; set; }

        /// <summary>
        /// Mã lớp học sinh
        /// </summary>
        public int MaLop { get; set; }

        /// <summary>
        /// Tên lớp học sinh
        /// </summary>
        public string TenLop { get; set; }

        /// <summary>
        /// Ngày xin nghỉ
        /// </summary>
        public DateTime NgayNghi { get; set; }

        /// <summary>
        /// Lý do nghỉ học
        /// </summary>
        public string LyDo { get; set; }

        /// <summary>
        /// Trạng thái đơn nghỉ (Chờ duyệt, Đã duyệt, Từ chối)
        /// </summary>
        public string TrangThai { get; set; }

        /// <summary>
        /// Danh sách tệp đính kèm
        /// </summary>
        public List<TepDinhKemDTO> DanhSachDinhKem { get; set; }

        /// <summary>
        /// Thời gian tạo đơn
        /// </summary>
        public DateTime NgayTao { get; set; }

        /// <summary>
        /// Ghi chú (nếu có)
        /// </summary>
        public string GhiChu { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public DonXinNghiDTO()
        {
            DanhSachDinhKem = new List<TepDinhKemDTO>();
            TrangThai = "Chờ duyệt"; // Giá trị mặc định
        }
    }

    /// <summary>
    /// Lớp DTO cho tệp đính kèm
    /// </summary>
    public class TepDinhKemDTO
    {
        /// <summary>
        /// Mã tệp đính kèm
        /// </summary>
        public int MaDinhKem { get; set; }

        /// <summary>
        /// Mã đơn liên kết
        /// </summary>
        public int MaDon { get; set; }

        /// <summary>
        /// Tên tệp đính kèm
        /// </summary>
        public string TenFile { get; set; }

        /// <summary>
        /// Nội dung tệp đính kèm
        /// </summary>
        public byte[] NoiDung { get; set; }

        /// <summary>
        /// Kích thước tệp (bytes)
        /// </summary>
        public long KichThuoc { get; set; }
    }
}
