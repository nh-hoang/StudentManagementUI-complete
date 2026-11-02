using System;
using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace BLL
{
    public class StudentBLL
    {
        private readonly StudentDAL _studentDAL;
        private readonly ILogger<StudentBLL> _logger;

        public StudentBLL() : this(new StudentDAL(), NullLogger<StudentBLL>.Instance)
        {
        }

        public StudentBLL(ILogger<StudentBLL> logger) : this(new StudentDAL(), logger)
        {
        }

        public StudentBLL(StudentDAL studentDAL, ILogger<StudentBLL>? logger = null)
        {
            _studentDAL = studentDAL ?? throw new ArgumentNullException(nameof(studentDAL));
            _logger = logger ?? NullLogger<StudentBLL>.Instance;
        }

        public bool ValidateStudent(StudentDTO student, out string errorMessage)
        {
            if (student == null)
            {
                errorMessage = "Thông tin sinh viên không được để trống.";
                _logger.LogWarning("Kiểm tra hợp lệ thất bại: Đối tượng StudentDTO là null.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(student.Code) || !student.Code.Trim().StartsWith("SV", StringComparison.OrdinalIgnoreCase))
            {
                errorMessage = "Mã sinh viên (Code) phải bắt đầu bằng 'SV'.";
                _logger.LogWarning("Kiểm tra hợp lệ thất bại cho mã '{Code}': {Error}", student.Code, errorMessage);
                return false;
            }

            if (string.IsNullOrWhiteSpace(student.FullName))
            {
                errorMessage = "Họ tên sinh viên (FullName) không được để trống.";
                _logger.LogWarning("Kiểm tra hợp lệ thất bại cho mã '{Code}': {Error}", student.Code, errorMessage);
                return false;
            }

            if (student.GPA < 0.0 || student.GPA > 4.0)
            {
                errorMessage = "Điểm trung bình (GPA) phải nằm trong khoảng từ 0 đến 4.";
                _logger.LogWarning("Kiểm tra hợp lệ thất bại cho mã '{Code}' với GPA={GPA}: {Error}", student.Code, student.GPA, errorMessage);
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public List<StudentDTO> GetAll()
        {
            try
            {
                _logger.LogInformation("Đang lấy danh sách toàn bộ sinh viên.");
                var students = _studentDAL.GetAll();
                _logger.LogInformation("Lấy thành công {Count} sinh viên.", students.Count);
                return students;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách sinh viên.");
                throw;
            }
        }

        public bool Add(StudentDTO student)
        {
            if (!ValidateStudent(student, out string errorMessage))
            {
                throw new ArgumentException(errorMessage);
            }

            try
            {
                _logger.LogInformation("Đang thêm sinh viên mới với mã: {Code}", student.Code);
                bool result = _studentDAL.Add(student);
                if (result)
                {
                    _logger.LogInformation("Thêm sinh viên {Code} thành công.", student.Code);
                }
                else
                {
                    _logger.LogWarning("Không thể thêm sinh viên {Code}.", student.Code);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi thêm sinh viên mã {Code}.", student.Code);
                throw;
            }
        }

        public bool Update(StudentDTO student)
        {
            if (!ValidateStudent(student, out string errorMessage))
            {
                throw new ArgumentException(errorMessage);
            }

            try
            {
                _logger.LogInformation("Đang cập nhật sinh viên Id={Id}, Code={Code}", student.Id, student.Code);
                bool result = _studentDAL.Update(student);
                if (result)
                {
                    _logger.LogInformation("Cập nhật sinh viên Id={Id} thành công.", student.Id);
                }
                else
                {
                    _logger.LogWarning("Không tìm thấy hoặc không thể cập nhật sinh viên Id={Id}.", student.Id);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi cập nhật sinh viên Id={Id}.", student.Id);
                throw;
            }
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Yêu cầu xóa sinh viên với Id không hợp lệ: {Id}", id);
                throw new ArgumentException("Id sinh viên không hợp lệ.");
            }

            try
            {
                _logger.LogInformation("Đang xóa sinh viên có Id={Id}", id);
                bool result = _studentDAL.Delete(id);
                if (result)
                {
                    _logger.LogInformation("Xóa sinh viên Id={Id} thành công.", id);
                }
                else
                {
                    _logger.LogWarning("Không tìm thấy hoặc không thể xóa sinh viên Id={Id}.", id);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xóa sinh viên Id={Id}.", id);
                throw;
            }
        }
    }
}
