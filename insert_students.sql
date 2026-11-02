USE StudentDB;
GO

TRUNCATE TABLE Students;
GO

INSERT INTO Students (Code, FullName, BirthDate, Gender, ClassName, Major, Email, Phone, GPA) VALUES
('24031431', N'Hoàng Gia Bảo', '2004-09-13', N'Nam', 'DH24CT', N'Công nghệ thông tin', 'bao@gmail.com', '0987654301', 0),
('24030163', N'Lê Xuân Bình', '2006-01-16', N'Nam', 'DH24CT', N'Công nghệ thông tin', 'binh@gmail.com', '0901234502', 0),
('24031341', N'Võ Thành Danh', '2006-03-12', N'Nam', 'DH24CT', N'Công nghệ thông tin', 'danh@gmail.com', '0912345603', 0),
('24030257', N'Nguyễn Hải Duy', '2006-08-10', N'Nam', 'DH24CT', N'Công nghệ thông tin', 'duy.nguyen@gmail.com', '0934567804', 0),
('24030261', N'Phan Bá Duy', '2006-07-26', N'Nam', 'DH24CT', N'Công nghệ thông tin', 'duy.phan@gmail.com', '0945678905', 0),
('24030330', N'Hoàng Kim Minh Hiếu', '2006-01-02', N'Nam', 'DH24CT', N'Công nghệ thông tin', 'hieu.hoang@gmail.com', '0967890106', 0),
('24030339', N'Trần Nhật Hiếu', '2006-10-31', N'Nam', 'DH24CT', N'Công nghệ thông tin', 'hieu.tran@gmail.com', '0978901207', 0),
('24031295', N'Nguyễn Phạm Đăng Huân', '2006-08-19', N'Nam', 'DH24CT', N'Công nghệ thông tin', 'huan@gmail.com', '0989012308', 0),
('24031484', N'Nguyễn Thế Khang', '2002-07-14', N'Nam', 'DH24CT', N'Công nghệ thông tin', 'khang@gmail.com', '0990123409', 0),
('24030176', N'Nguyễn Trọng Nghĩa', '2006-02-22', N'Nam', 'DH24CT', N'Công nghệ thông tin', 'nghia@gmail.com', '0321234510', 0),
('24031241', N'Hoàng Thảo Nguyên', '2006-07-27', N'Nữ', 'DH24CT', N'Công nghệ thông tin', 'nguyen@gmail.com', '0332345611', 0),
('24030017', N'Nguyễn Thanh Phúc', '2004-09-06', N'Nam', 'DH24CT', N'Công nghệ thông tin', 'phuc.nguyen@gmail.com', '0343456712', 0),
('24031038', N'Nguyễn Trần Đức Tài', '2005-06-28', N'Nam', 'DH24CT', N'Công nghệ thông tin', 'tai@gmail.com', '0354567813', 0),
('24030452', N'Trần Hoàng Tân', '2006-03-15', N'Nam', 'DH24CT', N'Công nghệ thông tin', 'tan@gmail.com', '0365678914', 0),
('24031563', N'Nguyễn Minh Thành', '2003-11-20', N'Nam', 'DH24CT', N'Công nghệ thông tin', 'thanh@gmail.com', '0376789015', 0),
('24031365', N'Đỗ Quốc Việt', '2005-07-01', N'Nam', 'DH24CT', N'Công nghệ thông tin', 'viet@gmail.com', '0387890116', 0),
('24030909', N'Lý Trung Phúc', '2006-12-05', N'Nam', 'DH24CT3', N'Công nghệ thông tin', 'phuc.ly@gmail.com', '0398901217', 0),
('24030852', N'Huỳnh Nhật Khánh', '2005-07-22', N'Nam', 'DH24CT4', N'Công nghệ thông tin', 'khanh@gmail.com', '0869012318', 0);
