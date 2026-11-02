using System;
using System.Globalization;
using System.Windows.Forms;
using BLL;
using DTO;
using Microsoft.Data.SqlClient;

namespace UI;

public partial class Form1 : Form
{
    private readonly StudentBLL _studentBLL;

    public Form1()
    {
        InitializeComponent();
        dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _studentBLL = new StudentBLL();
        cboGender.SelectedIndex = 0;
    }

    private void Form1_Load(object? sender, EventArgs e)
    {
        LoadStudents();
    }

    private void LoadStudents()
    {
        try
        {
            dgvStudents.DataSource = _studentBLL.GetAll();
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            if (dgvStudents.Columns.Count > 0)
            {
                dgvStudents.Columns[dgvStudents.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Không thể tải danh sách sinh viên: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private StudentDTO GetStudentFromInputs()
    {
        int.TryParse(txtId.Text.Trim(), out int id);
        if (!double.TryParse(txtGPA.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double gpa))
        {
            if (!double.TryParse(txtGPA.Text.Trim(), out gpa))
            {
                throw new ArgumentException("Điểm GPA không đúng định dạng số.");
            }
        }

        return new StudentDTO
        {
            Id = id,
            Code = txtCode.Text.Trim(),
            FullName = txtFullName.Text.Trim(),
            BirthDate = dtpBirthDate.Value.Date,
            Gender = cboGender.SelectedItem?.ToString() ?? "Nam",
            ClassName = txtClassName.Text.Trim(),
            Major = txtMajor.Text.Trim(),
            Email = txtEmail.Text.Trim(),
            Phone = txtPhone.Text.Trim(),
            GPA = gpa
        };
    }

    private void ClearInputs()
    {
        txtId.Clear();
        txtCode.Clear();
        txtFullName.Clear();
        dtpBirthDate.Value = DateTime.Now;
        cboGender.SelectedIndex = 0;
        txtClassName.Clear();
        txtMajor.Clear();
        txtEmail.Clear();
        txtPhone.Clear();
        txtGPA.Clear();
        txtCode.Focus();
    }

    private void btnAdd_Click(object? sender, EventArgs e)
    {
        try
        {
            var student = GetStudentFromInputs();
            if (_studentBLL.Add(student))
            {
                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudents();
                ClearInputs();
            }
        }
        catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
        {
            MessageBox.Show("Mã sinh viên, Email hoặc Số điện thoại đã tồn tại trong hệ thống. Vui lòng kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnUpdate_Click(object? sender, EventArgs e)
    {
        try
        {
            var student = GetStudentFromInputs();
            if (student.Id <= 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa từ danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_studentBLL.Update(student))
            {
                MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudents();
                ClearInputs();
            }
        }
        catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
        {
            MessageBox.Show("Mã sinh viên, Email hoặc Số điện thoại đã tồn tại trong hệ thống. Vui lòng kiểm tra lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnDelete_Click(object? sender, EventArgs e)
    {
        try
        {
            if (!int.TryParse(txtId.Text.Trim(), out int id) || id <= 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa từ danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes && _studentBLL.Delete(id))
            {
                MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStudents();
                ClearInputs();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnRefresh_Click(object? sender, EventArgs e)
    {
        ClearInputs();
        LoadStudents();
    }

    private void dgvStudents_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= dgvStudents.Rows.Count)
            return;

        if (dgvStudents.Rows[e.RowIndex].DataBoundItem is StudentDTO student)
        {
            txtId.Text = student.Id.ToString();
            txtCode.Text = student.Code;
            txtFullName.Text = student.FullName;
            dtpBirthDate.Value = student.BirthDate;
            cboGender.SelectedItem = student.Gender;
            txtClassName.Text = student.ClassName;
            txtMajor.Text = student.Major;
            txtEmail.Text = student.Email;
            txtPhone.Text = student.Phone;
            txtGPA.Text = student.GPA.ToString(CultureInfo.InvariantCulture);
        }
    }
}
