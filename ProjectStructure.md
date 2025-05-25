# Sơ đồ cấu trúc thư mục và tổ chức mã nguồn

```
QuanLyTruongHoc/
│
├── Program.cs                     # Điểm khởi chạy ứng dụng
├── App.config                     # Cấu hình ứng dụng
├── packages.config                # Cấu hình các package
├── QuanLyTruongHoc.csproj         # File project C#
├── QuanLyTruongHoc.sln            # Solution file
│
├── GUI/                           # Tầng giao diện người dùng
│   ├── Forms/                     # Chứa các form giao diện
│   │   ├── frmLogin.cs            # Form đăng nhập
│   │   ├── frmHS.cs               # Form dành cho học sinh
│   │   ├── frmGV.cs               # Form dành cho giáo viên
│   │   ├── frmBGH.cs              # Form dành cho ban giám hiệu
│   │   ├── frmPhongNoiVu.cs       # Form dành cho phòng nội vụ
│   │   ├── frmQuanLyEx.cs         # Form quản lý mở rộng
│   │   ├── frmChangePW.cs         # Form đổi mật khẩu
│   │   ├── frmKiemTra.cs          # Form kiểm tra
│   │   ├── frmNhapDiem.cs         # Form nhập điểm
│   │   ├── frmChinhSuaDiem.cs     # Form chỉnh sửa điểm
│   │   ├── frmQuanLyHocSinh.cs    # Form quản lý học sinh
│   │   ├── frmQuanLyLop.cs        # Form quản lý lớp
│   │   ├── frmQuanLyThoiKhoaBieu.cs # Form quản lý thời khóa biểu
│   │   ├── frmThongBaoChiTiet.cs  # Form chi tiết thông báo
│   │   └── frmChiTietDonXinNghi.cs # Form chi tiết đơn xin nghỉ
│   │
│   └── Controls/                  # Chứa các control tùy chỉnh
│
├── DTO/                           # Data Transfer Objects
│   ├── NguoiDung.cs               # Đối tượng người dùng
│   ├── ThongTinHSDTO.cs           # Đối tượng thông tin học sinh
│   ├── DiemSoDTO.cs               # Đối tượng điểm số
│   ├── BaiKiemTraDTO.cs           # Đối tượng bài kiểm tra
│   ├── BaiLamDTO.cs               # Đối tượng bài làm
│   ├── TKBDTO.cs                  # Đối tượng thời khóa biểu
│   ├── ThongBaoDTO.cs             # Đối tượng thông báo
│   ├── DonXinNghiDTO.cs           # Đối tượng đơn xin nghỉ
│   └── Notification.cs            # Đối tượng thông báo hệ thống
│
├── DAL/                           # Data Access Layer
│   ├── DatabaseHelper.cs          # Lớp hỗ trợ kết nối cơ sở dữ liệu
│   ├── HocSinhDAO.cs              # Truy xuất dữ liệu học sinh
│   ├── DiemSoDAO.cs               # Truy xuất dữ liệu điểm số
│   ├── BaiKiemTraDAO.cs           # Truy xuất dữ liệu bài kiểm tra
│   ├── BaiLamDAO.cs               # Truy xuất dữ liệu bài làm
│   ├── TKBDAO.cs                  # Truy xuất dữ liệu thời khóa biểu
│   ├── ThongBaoDAO.cs             # Truy xuất dữ liệu thông báo
│   └── DonXinNghiDAO.cs           # Truy xuất dữ liệu đơn xin nghỉ
│
├── db/                            # Thư mục liên quan đến cơ sở dữ liệu
│
├── Resources/                     # Tài nguyên ứng dụng (hình ảnh, biểu tượng, v.v.)
│
├── assets/                        # Tài sản bổ sung khác
│
├── bin/                           # Thư mục chứa file thực thi sau khi build
│   ├── Debug/                     # Phiên bản Debug
│   └── Release/                   # Phiên bản Release
│
├── obj/                           # Thư mục chứa các file tạm thời khi biên dịch
│
├── Properties/                    # Thuộc tính của dự án
│
├── packages/                      # Thư mục chứa các package NuGet
│
├── .vs/                           # Thiết lập Visual Studio
│
├── .vscode/                       # Thiết lập VSCode
│
└── SQL Scripts/                   # Các script SQL
    ├── CSDL.sql                   # Script tạo cơ sở dữ liệu
    ├── DuLieuMau.sql              # Script dữ liệu mẫu
    ├── DuLieuMau_HocSinh.sql      # Script dữ liệu mẫu cho học sinh
    ├── DuLieuMau_DiemSo_BoSung.sql # Script dữ liệu bổ sung điểm số
    ├── DuLieuMau_ThongBao.sql     # Script dữ liệu mẫu thông báo
    ├── DuLieuMau_ThoiKhoaBieu_CapNhat.sql # Script cập nhật thời khóa biểu
    └── ...                        # Các script SQL khác
```

## Mô tả cấu trúc mã nguồn

### 1. Tổ chức theo mô hình 3 lớp
Dự án được tổ chức theo mô hình kiến trúc 3 lớp rõ ràng:

- **GUI (Presentation Layer)**: Chứa các form giao diện người dùng, chịu trách nhiệm hiển thị và tương tác với người dùng.
- **DTO (Data Transfer Objects)**: Chứa các lớp đối tượng truyền dữ liệu giữa các tầng.
- **DAL (Data Access Layer)**: Chứa các lớp truy cập và thao tác với cơ sở dữ liệu.

### 2. Phân chia theo chức năng
Mỗi thành phần chức năng của hệ thống đều có các lớp tương ứng ở các tầng:

- **Quản lý học sinh**: HocSinhDAO.cs, ThongTinHSDTO.cs, frmQuanLyHocSinh.cs
- **Quản lý điểm số**: DiemSoDAO.cs, DiemSoDTO.cs, frmNhapDiem.cs, frmChinhSuaDiem.cs
- **Quản lý bài kiểm tra**: BaiKiemTraDAO.cs, BaiKiemTraDTO.cs, frmKiemTra.cs
- **Quản lý thời khóa biểu**: TKBDAO.cs, TKBDTO.cs, frmQuanLyThoiKhoaBieu.cs
- **Quản lý thông báo**: ThongBaoDAO.cs, ThongBaoDTO.cs, frmThongBaoChiTiet.cs
- **Quản lý đơn xin nghỉ**: DonXinNghiDAO.cs, DonXinNghiDTO.cs, frmChiTietDonXinNghi.cs

### 3. Quản lý kết nối cơ sở dữ liệu
Lớp DatabaseHelper.cs trong tầng DAL cung cấp các phương thức phổ biến để kết nối và tương tác với cơ sở dữ liệu:
- Mở/đóng kết nối
- Thực thi các truy vấn SQL
- Thực thi các thủ tục lưu trữ
- Quản lý giao dịch
- Kiểm tra sự tồn tại của bản ghi

### 4. Phân quyền người dùng
Hệ thống có các form giao diện riêng biệt cho từng loại người dùng:
- Học sinh (frmHS.cs)
- Giáo viên (frmGV.cs, frmGiaoVien.cs)
- Ban giám hiệu (frmBGH.cs)
- Phòng nội vụ (frmPhongNoiVu.cs)
- Quản trị viên (frmQuanLyEx.cs)

### 5. Dữ liệu và cơ sở dữ liệu
- Các script SQL được tổ chức riêng biệt cho từng chức năng và tình huống
- Có các script tạo cấu trúc cơ sở dữ liệu và script dữ liệu mẫu
- Dữ liệu liên quan đến học sinh, điểm số, thời khóa biểu, thông báo được lưu trong các bảng riêng biệt

### 6. Thư mục build và các tài nguyên
- Thư mục bin và obj được tạo tự động khi biên dịch
- Thư mục Resources và assets chứa tài nguyên như hình ảnh, biểu tượng
- Các cấu hình của ứng dụng được lưu trong App.config 