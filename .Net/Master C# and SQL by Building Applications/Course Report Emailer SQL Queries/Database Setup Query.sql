CREATE DATABASE CourseReport;
GO

USE CourseReport
GO

CREATE TABLE [dbo].[Course] (
    CourseId INT IDENTITY(1,1) NOT NULL,
    CourseCode VARCHAR(5) NOT NULL,
    [Description] VARCHAR(50) NOT NULL,
    PRIMARY KEY (CourseId)
);
GO

CREATE TABLE [dbo].[Student] (
    StudentId INT IDENTITY(1,1) NOT NULL,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    PRIMARY KEY (StudentId)
);
GO

CREATE TABLE [dbo].[Enrollments] (
    EnrollmentId INT IDENTITY(1,1) NOT NULL,
    StudentId INT NOT NULL,
    CourseId INT NOT NULL,
    PRIMARY KEY (EnrollmentId),
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId),
    FOREIGN KEY (CourseId) REFERENCES Course(CourseId)
);
GO

-- Course
INSERT INTO [dbo].[Course] (CourseCode, [Description]) VALUES ('AF', 'Accounting & Finance');
INSERT INTO [dbo].[Course] (CourseCode, [Description]) VALUES ('ME', 'Aeronautical & Manufacturing Engineering');
INSERT INTO [dbo].[Course] (CourseCode, [Description]) VALUES ('AF', 'Agriculture & Forestry');
INSERT INTO [dbo].[Course] (CourseCode, [Description]) VALUES ('AS', 'American Studies');
INSERT INTO [dbo].[Course] (CourseCode, [Description]) VALUES ('APSY', 'Anatomy & Physiology');
INSERT INTO [dbo].[Course] (CourseCode, [Description]) VALUES ('ANT', 'Anthropology');
INSERT INTO [dbo].[Course] (CourseCode, [Description]) VALUES ('ARC', 'Archaeology');
INSERT INTO [dbo].[Course] (CourseCode, [Description]) VALUES ('ARCH', 'Architecture');
GO

-- Student
INSERT INTO [dbo].[Student] (FirstName, LastName) VALUES ('Millard', 'Lamb');
INSERT INTO [dbo].[Student] (FirstName, LastName) VALUES ('Gayle', 'Reid');
INSERT INTO [dbo].[Student] (FirstName, LastName) VALUES ('Quinton', 'Beltran');
INSERT INTO [dbo].[Student] (FirstName, LastName) VALUES ('Eusebio', 'Moyer');
INSERT INTO [dbo].[Student] (FirstName, LastName) VALUES ('Imelda', 'Shea');
INSERT INTO [dbo].[Student] (FirstName, LastName) VALUES ('Ellsworth', 'Fletcher');
GO

-- Enrollments
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (1, 1);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (2, 1);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (3, 1);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (1, 2);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (2, 2);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (3, 2);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (4, 2);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (5, 3);
INSERT INTO [dbo].[Enrollments] (StudentId, CourseId) VALUES (6, 4);
GO

CREATE VIEW [dbo].[EnrollmentReport] AS
    SELECT
        t1.EnrollmentId,
        t2.FirstName,
        t2.LastName,
        t3.CourseCode,
        t3.[Description]
    FROM
        [dbo].[Enrollments] t1
    INNER JOIN
        [dbo].[Student] t2 on t1.StudentId = t2.StudentId
    INNER JOIN
        [dbo].[Course] t3 on t1.CourseId = t3.CourseId
GO

CREATE PROCEDURE [dbo].[EnrollmentReport_GetList] AS
    SELECT
        EnrollmentId,
        FirstName,
        LastName,
        CourseCode,
        [Description]
    FROM
        [dbo].[EnrollmentReport]
GO

