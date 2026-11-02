namespace DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string Gender { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public double GPA { get; set; }

        public StudentDTO()
        {
        }

        public StudentDTO(int id, string code, string fullName, DateTime birthDate, string gender, string className, string major, string email, string phone, double gpa)
        {
            Id = id;
            Code = code;
            FullName = fullName;
            BirthDate = birthDate;
            Gender = gender;
            ClassName = className;
            Major = major;
            Email = email;
            Phone = phone;
            GPA = gpa;
        }
    }
}
