namespace UI;

partial class Form1
{
    private System.ComponentModel.IContainer components = null!;

    private Label lblTitle = null!;
    private GroupBox grpStudentInfo = null!;
    private Label lblId = null!;
    private TextBox txtId = null!;
    private Label lblCode = null!;
    private TextBox txtCode = null!;
    private Label lblFullName = null!;
    private TextBox txtFullName = null!;
    private Label lblBirthDate = null!;
    private DateTimePicker dtpBirthDate = null!;
    private Label lblGender = null!;
    private ComboBox cboGender = null!;
    private Label lblClassName = null!;
    private TextBox txtClassName = null!;
    private Label lblMajor = null!;
    private TextBox txtMajor = null!;
    private Label lblEmail = null!;
    private TextBox txtEmail = null!;
    private Label lblPhone = null!;
    private TextBox txtPhone = null!;
    private Label lblGPA = null!;
    private TextBox txtGPA = null!;

    private Button btnAdd = null!;
    private Button btnUpdate = null!;
    private Button btnDelete = null!;
    private Button btnRefresh = null!;

    private DataGridView dgvStudents = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.lblTitle = new System.Windows.Forms.Label();
        this.grpStudentInfo = new System.Windows.Forms.GroupBox();
        this.lblId = new System.Windows.Forms.Label();
        this.txtId = new System.Windows.Forms.TextBox();
        this.lblCode = new System.Windows.Forms.Label();
        this.txtCode = new System.Windows.Forms.TextBox();
        this.lblFullName = new System.Windows.Forms.Label();
        this.txtFullName = new System.Windows.Forms.TextBox();
        this.lblBirthDate = new System.Windows.Forms.Label();
        this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
        this.lblGender = new System.Windows.Forms.Label();
        this.cboGender = new System.Windows.Forms.ComboBox();
        this.lblClassName = new System.Windows.Forms.Label();
        this.txtClassName = new System.Windows.Forms.TextBox();
        this.lblMajor = new System.Windows.Forms.Label();
        this.txtMajor = new System.Windows.Forms.TextBox();
        this.lblEmail = new System.Windows.Forms.Label();
        this.txtEmail = new System.Windows.Forms.TextBox();
        this.lblPhone = new System.Windows.Forms.Label();
        this.txtPhone = new System.Windows.Forms.TextBox();
        this.lblGPA = new System.Windows.Forms.Label();
        this.txtGPA = new System.Windows.Forms.TextBox();
        this.btnAdd = new System.Windows.Forms.Button();
        this.btnUpdate = new System.Windows.Forms.Button();
        this.btnDelete = new System.Windows.Forms.Button();
        this.btnRefresh = new System.Windows.Forms.Button();
        this.dgvStudents = new System.Windows.Forms.DataGridView();
        this.grpStudentInfo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
        this.SuspendLayout();

        // lblTitle
        this.lblTitle.AutoSize = false;
        this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 70, 140);
        this.lblTitle.Height = 45;
        this.lblTitle.Text = "QUẢN LÝ SINH VIÊN";
        this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        // grpStudentInfo
        this.grpStudentInfo.Location = new System.Drawing.Point(16, 55);
        this.grpStudentInfo.Size = new System.Drawing.Size(960, 175);
        this.grpStudentInfo.Text = "Thông tin sinh viên";
        this.grpStudentInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

        // Row 1: Id, Code, FullName, BirthDate
        this.lblId.AutoSize = true;
        this.lblId.Location = new System.Drawing.Point(18, 30);
        this.lblId.Text = "ID:";
        this.txtId.Location = new System.Drawing.Point(95, 26);
        this.txtId.ReadOnly = true;
        this.txtId.Size = new System.Drawing.Size(70, 23);

        this.lblCode.AutoSize = true;
        this.lblCode.Location = new System.Drawing.Point(185, 30);
        this.lblCode.Text = "Mã SV (*):";
        this.txtCode.Location = new System.Drawing.Point(260, 26);
        this.txtCode.Size = new System.Drawing.Size(120, 23);

        this.lblFullName.AutoSize = true;
        this.lblFullName.Location = new System.Drawing.Point(400, 30);
        this.lblFullName.Text = "Họ tên (*):";
        this.txtFullName.Location = new System.Drawing.Point(480, 26);
        this.txtFullName.Size = new System.Drawing.Size(210, 23);

        this.lblBirthDate.AutoSize = true;
        this.lblBirthDate.Location = new System.Drawing.Point(710, 30);
        this.lblBirthDate.Text = "Ngày sinh:";
        this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpBirthDate.Location = new System.Drawing.Point(785, 26);
        this.dtpBirthDate.Size = new System.Drawing.Size(150, 23);

        // Row 2: Gender, ClassName, Major, GPA
        this.lblGender.AutoSize = true;
        this.lblGender.Location = new System.Drawing.Point(18, 70);
        this.lblGender.Text = "Giới tính:";
        this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
        this.cboGender.Location = new System.Drawing.Point(95, 66);
        this.cboGender.Size = new System.Drawing.Size(80, 23);

        this.lblClassName.AutoSize = true;
        this.lblClassName.Location = new System.Drawing.Point(185, 70);
        this.lblClassName.Text = "Lớp:";
        this.txtClassName.Location = new System.Drawing.Point(260, 66);
        this.txtClassName.Size = new System.Drawing.Size(120, 23);

        this.lblMajor.AutoSize = true;
        this.lblMajor.Location = new System.Drawing.Point(400, 70);
        this.lblMajor.Text = "Ngành học:";
        this.txtMajor.Location = new System.Drawing.Point(480, 66);
        this.txtMajor.Size = new System.Drawing.Size(210, 23);

        this.lblGPA.AutoSize = true;
        this.lblGPA.Location = new System.Drawing.Point(710, 70);
        this.lblGPA.Text = "GPA (0-4):";
        this.txtGPA.Location = new System.Drawing.Point(785, 66);
        this.txtGPA.Size = new System.Drawing.Size(150, 23);

        // Row 3: Email, Phone, Action Buttons
        this.lblEmail.AutoSize = true;
        this.lblEmail.Location = new System.Drawing.Point(18, 115);
        this.lblEmail.Text = "Email:";
        this.txtEmail.Location = new System.Drawing.Point(95, 111);
        this.txtEmail.Size = new System.Drawing.Size(285, 23);

        this.lblPhone.AutoSize = true;
        this.lblPhone.Location = new System.Drawing.Point(400, 115);
        this.lblPhone.Text = "Điện thoại:";
        this.txtPhone.Location = new System.Drawing.Point(480, 111);
        this.txtPhone.Size = new System.Drawing.Size(150, 23);

        // Buttons
        this.btnAdd.Location = new System.Drawing.Point(650, 108);
        this.btnAdd.Size = new System.Drawing.Size(70, 32);
        this.btnAdd.Text = "Thêm";
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

        this.btnUpdate.Location = new System.Drawing.Point(725, 108);
        this.btnUpdate.Size = new System.Drawing.Size(70, 32);
        this.btnUpdate.Text = "Sửa";
        this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

        this.btnDelete.Location = new System.Drawing.Point(800, 108);
        this.btnDelete.Size = new System.Drawing.Size(70, 32);
        this.btnDelete.Text = "Xóa";
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

        this.btnRefresh.Location = new System.Drawing.Point(875, 108);
        this.btnRefresh.Size = new System.Drawing.Size(70, 32);
        this.btnRefresh.Text = "Làm mới";
        this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

        this.grpStudentInfo.Controls.Add(this.lblId);
        this.grpStudentInfo.Controls.Add(this.txtId);
        this.grpStudentInfo.Controls.Add(this.lblCode);
        this.grpStudentInfo.Controls.Add(this.txtCode);
        this.grpStudentInfo.Controls.Add(this.lblFullName);
        this.grpStudentInfo.Controls.Add(this.txtFullName);
        this.grpStudentInfo.Controls.Add(this.lblBirthDate);
        this.grpStudentInfo.Controls.Add(this.dtpBirthDate);
        this.grpStudentInfo.Controls.Add(this.lblGender);
        this.grpStudentInfo.Controls.Add(this.cboGender);
        this.grpStudentInfo.Controls.Add(this.lblClassName);
        this.grpStudentInfo.Controls.Add(this.txtClassName);
        this.grpStudentInfo.Controls.Add(this.lblMajor);
        this.grpStudentInfo.Controls.Add(this.txtMajor);
        this.grpStudentInfo.Controls.Add(this.lblGPA);
        this.grpStudentInfo.Controls.Add(this.txtGPA);
        this.grpStudentInfo.Controls.Add(this.lblEmail);
        this.grpStudentInfo.Controls.Add(this.txtEmail);
        this.grpStudentInfo.Controls.Add(this.lblPhone);
        this.grpStudentInfo.Controls.Add(this.txtPhone);
        this.grpStudentInfo.Controls.Add(this.btnAdd);
        this.grpStudentInfo.Controls.Add(this.btnUpdate);
        this.grpStudentInfo.Controls.Add(this.btnDelete);
        this.grpStudentInfo.Controls.Add(this.btnRefresh);

        // dgvStudents
        this.dgvStudents.AllowUserToAddRows = false;
        this.dgvStudents.AllowUserToDeleteRows = false;
        this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvStudents.Location = new System.Drawing.Point(16, 240);
        this.dgvStudents.MultiSelect = false;
        this.dgvStudents.ReadOnly = true;
        this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvStudents.Size = new System.Drawing.Size(960, 320);
        this.dgvStudents.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.dgvStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudents_CellClick);

        // Form1
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(992, 575);
        this.Controls.Add(this.dgvStudents);
        this.Controls.Add(this.grpStudentInfo);
        this.Controls.Add(this.lblTitle);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Quản Lý Sinh Viên";
        this.Load += new System.EventHandler(this.Form1_Load);
        this.grpStudentInfo.ResumeLayout(false);
        this.grpStudentInfo.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
        this.ResumeLayout(false);
    }

    #endregion
}
