using System;
using BLL;
using DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public sealed class Test1
{
    private StudentBLL _studentBLL = null!;

    [TestInitialize]
    public void Setup()
    {
        _studentBLL = new StudentBLL();
    }

    private static StudentDTO CreateValidStudent()
    {
        return new StudentDTO
        {
            Id = 1,
            Code = "SV001",
            FullName = "Nguyễn Văn A",
            BirthDate = new DateTime(2004, 5, 15),
            Gender = "Nam",
            ClassName = "CNTT01",
            Major = "Công nghệ thông tin",
            Email = "nguyenvana@example.com",
            Phone = "0901234567",
            GPA = 3.2
        };
    }

    // Test Case 1: GPA tại biên dưới không hợp lệ (-0.01)
    [TestMethod]
    public void ValidateStudent_GPA_BelowLowerBoundary_Minus0Point01_ReturnsFalse()
    {
        var student = CreateValidStudent();
        student.GPA = -0.01;

        bool isValid = _studentBLL.ValidateStudent(student, out string errorMessage);

        Assert.IsFalse(isValid);
        Assert.AreEqual("Điểm trung bình (GPA) phải nằm trong khoảng từ 0 đến 4.", errorMessage);
    }

    // Test Case 2: GPA tại biên dưới hợp lệ (0)
    [TestMethod]
    public void ValidateStudent_GPA_AtLowerBoundary_0_ReturnsTrue()
    {
        var student = CreateValidStudent();
        student.GPA = 0.0;

        bool isValid = _studentBLL.ValidateStudent(student, out string errorMessage);

        Assert.IsTrue(isValid);
        Assert.AreEqual(string.Empty, errorMessage);
    }

    // Test Case 3: GPA tại biên trên hợp lệ (4)
    [TestMethod]
    public void ValidateStudent_GPA_AtUpperBoundary_4_ReturnsTrue()
    {
        var student = CreateValidStudent();
        student.GPA = 4.0;

        bool isValid = _studentBLL.ValidateStudent(student, out string errorMessage);

        Assert.IsTrue(isValid);
        Assert.AreEqual(string.Empty, errorMessage);
    }

    // Test Case 4: GPA tại biên trên không hợp lệ (4.01)
    [TestMethod]
    public void ValidateStudent_GPA_AboveUpperBoundary_4Point01_ReturnsFalse()
    {
        var student = CreateValidStudent();
        student.GPA = 4.01;

        bool isValid = _studentBLL.ValidateStudent(student, out string errorMessage);

        Assert.IsFalse(isValid);
        Assert.AreEqual("Điểm trung bình (GPA) phải nằm trong khoảng từ 0 đến 4.", errorMessage);
    }

    // Test Case 5: Sinh viên hợp lệ với GPA trung bình (2.5)
    [TestMethod]
    public void ValidateStudent_ValidStudent_NormalGPA_ReturnsTrue()
    {
        var student = CreateValidStudent();
        student.GPA = 2.5;

        bool isValid = _studentBLL.ValidateStudent(student, out string errorMessage);

        Assert.IsTrue(isValid);
        Assert.AreEqual(string.Empty, errorMessage);
    }

    // Test Case 6: Mã sinh viên (Code) rỗng hoặc khoảng trắng
    [TestMethod]
    public void ValidateStudent_EmptyCode_ReturnsFalse()
    {
        var student = CreateValidStudent();
        student.Code = "   ";

        bool isValid = _studentBLL.ValidateStudent(student, out string errorMessage);

        Assert.IsFalse(isValid);
        Assert.AreEqual("Mã sinh viên (Code) phải bắt đầu bằng 'SV'.", errorMessage);
    }

    // Test Case 7: Mã sinh viên (Code) không bắt đầu bằng "SV"
    [TestMethod]
    public void ValidateStudent_CodeNotStartingWithSV_ReturnsFalse()
    {
        var student = CreateValidStudent();
        student.Code = "IT001";

        bool isValid = _studentBLL.ValidateStudent(student, out string errorMessage);

        Assert.IsFalse(isValid);
        Assert.AreEqual("Mã sinh viên (Code) phải bắt đầu bằng 'SV'.", errorMessage);
    }

    // Test Case 8: Họ tên sinh viên (FullName) rỗng
    [TestMethod]
    public void ValidateStudent_EmptyFullName_ReturnsFalse()
    {
        var student = CreateValidStudent();
        student.FullName = "";

        bool isValid = _studentBLL.ValidateStudent(student, out string errorMessage);

        Assert.IsFalse(isValid);
        Assert.AreEqual("Họ tên sinh viên (FullName) không được để trống.", errorMessage);
    }

    // Test Case 9: Đối tượng StudentDTO là null
    [TestMethod]
    public void ValidateStudent_NullStudent_ReturnsFalse()
    {
        bool isValid = _studentBLL.ValidateStudent(null!, out string errorMessage);

        Assert.IsFalse(isValid);
        Assert.AreEqual("Thông tin sinh viên không được để trống.", errorMessage);
    }

    // Test Case 10: Hàm Add ném ArgumentException khi GPA vượt biên (4.01)
    [TestMethod]
    public void AddStudent_InvalidGPA_4Point01_ThrowsArgumentException()
    {
        var student = CreateValidStudent();
        student.GPA = 4.01;

        Assert.ThrowsException<ArgumentException>(() => _studentBLL.Add(student));
    }
}
