// Cấu trúc dữ liệu học sinh
using System;
using System.Drawing;

public class ThongTinHSDTO
{
    // Thông tin cá nhân cơ bản
    public string StudentId { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string IdentityCode { get; set; }
    public string PlaceOfBirth { get; set; }
    public string Ethnicity { get; set; }
    public string Religion { get; set; }

    // Thông tin liên hệ và địa chỉ
    public string Country { get; set; }
    public string Province { get; set; }
    public string District { get; set; }
    public string Ward { get; set; }
    public string PermanentAddress { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }

    // Thông tin học tập
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public Image Avatar { get; set; }

    // Thông tin phụ huynh
    public string FatherName { get; set; }
    public string FatherPhone { get; set; }
    public string MotherName { get; set; }
    public string MotherPhone { get; set; }

    // Constructor mặc định
    public ThongTinHSDTO()
    {
        StudentId = string.Empty;
        FullName = string.Empty;
        Gender = string.Empty;
        IdentityCode = string.Empty;
        PlaceOfBirth = string.Empty;
        Ethnicity = string.Empty;
        Religion = string.Empty;
        Country = "Việt Nam";
        Province = string.Empty;
        District = string.Empty;
        Ward = string.Empty;
        PermanentAddress = string.Empty;
        Mobile = string.Empty;
        Email = string.Empty;
        ClassName = string.Empty;
        FatherName = string.Empty;
        FatherPhone = string.Empty;
        MotherName = string.Empty;
        MotherPhone = string.Empty;

    }
}
