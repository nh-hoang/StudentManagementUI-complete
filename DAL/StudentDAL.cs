using System;
using System.Collections.Generic;
using System.Data;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class StudentDAL
    {
        private readonly string _connectionString;

        public StudentDAL() : this("Server=localhost;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True;")
        {
        }

        public StudentDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<StudentDTO> GetAll()
        {
            var students = new List<StudentDTO>();
            const string query = @"
                SELECT Id, Code, FullName, BirthDate, Gender, ClassName, Major, Email, Phone, GPA
                FROM Students
                WHERE 1 = @IsActive
                ORDER BY Id DESC";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Int) { Value = 1 });

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                students.Add(MapReaderToStudent(reader));
            }

            return students;
        }

        public bool Add(StudentDTO student)
        {
            const string query = @"
                INSERT INTO Students (Code, FullName, BirthDate, Gender, ClassName, Major, Email, Phone, GPA)
                VALUES (@Code, @FullName, @BirthDate, @Gender, @ClassName, @Major, @Email, @Phone, @GPA)";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 20) { Value = student.Code });
            cmd.Parameters.Add(new SqlParameter("@FullName", SqlDbType.NVarChar, 100) { Value = student.FullName });
            cmd.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.Date) { Value = student.BirthDate.Date });
            cmd.Parameters.Add(new SqlParameter("@Gender", SqlDbType.NVarChar, 10) { Value = student.Gender });
            cmd.Parameters.Add(new SqlParameter("@ClassName", SqlDbType.NVarChar, 50) { Value = student.ClassName });
            cmd.Parameters.Add(new SqlParameter("@Major", SqlDbType.NVarChar, 100) { Value = student.Major });
            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 100) { Value = string.IsNullOrWhiteSpace(student.Email) ? DBNull.Value : student.Email });
            cmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 20) { Value = string.IsNullOrWhiteSpace(student.Phone) ? DBNull.Value : student.Phone });
            cmd.Parameters.Add(new SqlParameter("@GPA", SqlDbType.Float) { Value = student.GPA });

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(StudentDTO student)
        {
            const string query = @"
                UPDATE Students
                SET Code = @Code,
                    FullName = @FullName,
                    BirthDate = @BirthDate,
                    Gender = @Gender,
                    ClassName = @ClassName,
                    Major = @Major,
                    Email = @Email,
                    Phone = @Phone,
                    GPA = @GPA
                WHERE Id = @Id";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = student.Id });
            cmd.Parameters.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 20) { Value = student.Code });
            cmd.Parameters.Add(new SqlParameter("@FullName", SqlDbType.NVarChar, 100) { Value = student.FullName });
            cmd.Parameters.Add(new SqlParameter("@BirthDate", SqlDbType.Date) { Value = student.BirthDate.Date });
            cmd.Parameters.Add(new SqlParameter("@Gender", SqlDbType.NVarChar, 10) { Value = student.Gender });
            cmd.Parameters.Add(new SqlParameter("@ClassName", SqlDbType.NVarChar, 50) { Value = student.ClassName });
            cmd.Parameters.Add(new SqlParameter("@Major", SqlDbType.NVarChar, 100) { Value = student.Major });
            cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 100) { Value = string.IsNullOrWhiteSpace(student.Email) ? DBNull.Value : student.Email });
            cmd.Parameters.Add(new SqlParameter("@Phone", SqlDbType.NVarChar, 20) { Value = string.IsNullOrWhiteSpace(student.Phone) ? DBNull.Value : student.Phone });
            cmd.Parameters.Add(new SqlParameter("@GPA", SqlDbType.Float) { Value = student.GPA });

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            const string query = "DELETE FROM Students WHERE Id = @Id";

            using var conn = new SqlConnection(_connectionString);
            using var cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        private static StudentDTO MapReaderToStudent(SqlDataReader reader)
        {
            return new StudentDTO
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Code = reader.GetString(reader.GetOrdinal("Code")),
                FullName = reader.GetString(reader.GetOrdinal("FullName")),
                BirthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate")),
                Gender = reader.GetString(reader.GetOrdinal("Gender")),
                ClassName = reader.GetString(reader.GetOrdinal("ClassName")),
                Major = reader.GetString(reader.GetOrdinal("Major")),
                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? string.Empty : reader.GetString(reader.GetOrdinal("Email")),
                Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? string.Empty : reader.GetString(reader.GetOrdinal("Phone")),
                GPA = Convert.ToDouble(reader["GPA"])
            };
        }
    }
}
