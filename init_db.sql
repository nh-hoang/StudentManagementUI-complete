-- Tạo Database StudentDB
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'StudentDB')
BEGIN
    CREATE DATABASE StudentDB;
END
GO

USE StudentDB;
GO

-- Tạo bảng Students
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Students]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Students] (
        [Id]        INT            IDENTITY(1,1) PRIMARY KEY,
        [Code]      NVARCHAR(20)   NOT NULL UNIQUE,
        [FullName]  NVARCHAR(100)  NOT NULL,
        [BirthDate] DATE           NOT NULL,
        [Gender]    NVARCHAR(10)   NOT NULL,
        [ClassName] NVARCHAR(50)   NOT NULL,
        [Major]     NVARCHAR(100)  NOT NULL,
        [Email]     NVARCHAR(100)  NULL,
        [Phone]     NVARCHAR(20)   NULL,
        [GPA]       FLOAT          NOT NULL DEFAULT 0.0
    );
END
GO
