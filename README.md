# 🏫 Hệ Thống Quản Lý Trường Học

[![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![.NET Framework](https://img.shields.io/badge/.NET_Framework-512BD4?style=flat-square&logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat-square&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/sql-server)

## 📖 Giới Thiệu

Hệ thống quản lý trường học là một ứng dụng desktop được phát triển bằng C# WindowsForms, sử dụng Guna Framework để tạo giao diện đẹp mắt và hiện đại. Hệ thống giúp quản lý toàn bộ hoạt động của trường học một cách hiệu quả và chuyên nghiệp.

## ✨ Tính Năng Chính

### 👥 Quản Lý Người Dùng
- **Quản lý học sinh**: Thêm, sửa, xóa thông tin học sinh
- **Quản lý giáo viên**: Quản lý hồ sơ và thông tin giảng dạy
- **Quản lý phụ huynh**: Liên kết thông tin phụ huynh với học sinh

### 📚 Quản Lý Học Tập
- **Quản lý lớp học**: Tạo lớp, phân công giáo viên
- **Quản lý môn học**: Thiết lập chương trình học
- **Quản lý điểm số**: Nhập và theo dõi kết quả học tập
- **Lịch học**: Sắp xếp thời khóa biểu

### 📊 Báo Cáo & Thống Kê
- Báo cáo học tập của học sinh
- Thống kê điểm số theo lớp/môn học
- Báo cáo tài chính (học phí)
- Xuất báo cáo PDF/Excel

## 🛠️ Công Nghệ Sử Dụng

- **Ngôn ngữ**: C#
- **Framework**: .NET Framework
- **Giao diện**: WindowsForms với Guna UI Framework
- **Cơ sở dữ liệu**: Microsoft SQL Server
- **IDE**: Visual Studio

## 📋 Yêu Cầu Hệ Thống

### Phần Mềm Cần Thiết
- Windows 10/11 hoặc Windows Server 2016+
- .NET Framework 4.7.2 trở lên
- Microsoft SQL Server 2017+ hoặc SQL Server Express
- Visual Studio 2019+ (để phát triển)

### Phần Cứng Tối Thiểu
- RAM: 4GB (khuyến nghị 8GB+)
- Ổ cứng: 2GB dung lượng trống
- Màn hình: độ phân giải 1366x768 trở lên

## 🚀 Hướng Dẫn Cài Đặt

### 1. Clone Repository
```bash
git clone https://github.com/sin0235/He_Thong_quan_ly_truong_hoc.git
cd He_Thong_quan_ly_truong_hoc
```

### 2. Thiết Lập Cơ Sở Dữ Liệu
1. Mở SQL Server Management Studio
2. Tạo database mới tên `SchoolManagement`
3. Chạy script SQL từ thư mục `Database/` để tạo bảng và dữ liệu mẫu

### 3. Cấu Hình Kết Nối
1. Mở file `app.config`
2. Cập nhật connection string phù hợp với SQL Server của bạn:
```xml
<connectionStrings>
    <add name="SchoolDB" 
         connectionString="Server=YOUR_SERVER;Database=SchoolManagement;Integrated Security=true;" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 4. Build & Chạy Ứng Dụng
1. Mở solution trong Visual Studio
2. Restore NuGet packages
3. Build solution (Ctrl+Shift+B)
4. Chạy ứng dụng (F5)

## 📱 Giao Diện Ứng Dụng

### Dashboard Chính
- Tổng quan thống kê
- Thông báo quan trọng
- Lịch sự kiện

### Modules Chính
- **👤 Học Sinh**: Quản lý thông tin cá nhân, học tập
- **👨‍🏫 Giáo Viên**: Hồ sơ, lịch dạy, quản lý điểm
- **📊 Báo Cáo**: Xuất báo cáo, thống kê
- **⚙️ Cài Đặt**: Cấu hình hệ thống

## 👥 Đóng Góp

Chúng tôi hoan nghênh mọi đóng góp để cải thiện hệ thống!

### Cách Đóng Góp
1. Fork repository này
2. Tạo feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Tạo Pull Request

### Báo Lỗi
Nếu bạn phát hiện lỗi, vui lòng tạo issue với thông tin chi tiết:
- Mô tả lỗi
- Các bước tái hiện
- Screenshot (nếu có)
- Thông tin môi trường

## 📄 Giấy Phép

Dự án này được phân phối dưới giấy phép MIT. Xem file `LICENSE` để biết thêm chi tiết.

## 📞 Liên Hệ

- **Developer**: [sin0235](https://github.com/sin0235)
- **Email**: phuctoan235@gmail.com
- **Project Link**: [https://github.com/sin0235/He_Thong_quan_ly_truong_hoc](https://github.com/sin0235/He_Thong_quan_ly_truong_hoc)

## 🙏 Cảm Ơn

- [Guna UI Framework](https://gunaui.com/) - Giao diện đẹp mắt
- [Microsoft](https://microsoft.com/) - .NET Framework và SQL Server
- Cộng đồng developer C# Việt Nam

---

⭐ **Nếu dự án này hữu ích, hãy cho chúng tôi một Star nhé!** ⭐
