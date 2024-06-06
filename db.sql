-- Active: 1717615683018@@bstwmojs1mvajpissme7-mysql.services.clever-cloud.com@3306@bstwmojs1mvajpissme7

CREATE TABLE Students (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Names VARCHAR(125),
    BirthDate DATE,
    Address VARCHAR(125),
    Email VARCHAR(125)
);

INSERT INTO Students (Names, BirthDate, Address, Email)
VALUES('Juan David Ortega', '2005-12-07', 'Aldea de Guayabal', 'juanda@gmail.com'),
('Juan Ortega', '2005-12-07', 'Aldea de Guayabal', 'juano@gmail.com'),
('Juan David', '2005-12-07', 'Aldea de Guayabal', 'juandavid@gmail.com'),
('David Ortega', '2005-12-07', 'Aldea de Guayabal', 'david@gmail.com'),
('Juan', '2005-12-07', 'Aldea de Guayabal', 'juan@gmail.com');

CREATE TABLE Teachers (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Names VARCHAR(125),
    Specialty VARCHAR(125),
    Phone VARCHAR(25),
    Email VARCHAR(125),
    YearsExperience INT
);

INSERT INTO Teachers (Names, Specialty, Phone, Email, YearsExperience)
VALUES
('John', 'Matematicas', '3123447890', 'john@matematicas.com', 3),
('Andres', 'Ciencias', '3123441234', 'andres@ciencias.com', 2),
('Jairo', 'Quimica', '3123445678', 'jairo@quimica.com', 1),
('Manuel', 'Fisica', '3123449012', 'manuel@fisica.com', 4),
('Alberto', 'Tecnología', '3123443456', 'alberto@tecnologia.com', 2);

CREATE TABLE Courses (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(125),
    Description TEXT,
    TeacherId INT,
    FOREIGN KEY (TeacherId) REFERENCES Teachers(Id),
    Schedule VARCHAR(125),
    Duration VARCHAR(125),
    Capacity INT
);

INSERT INTO `Courses` (`Name`, `Description`, `TeacherId`, `Schedule`, `Duration`, `Capacity`)
VALUES
('Programming', 'Courses free of programming', 1, 'Moodles Front and Back', '10 meses', 100),
('Science', 'Courses free of science', 1, 'Modulos de Quimica y Biología', '12 meses', 150),
('Logica', 'Courses free of logic', 1, 'Modulos de Pensamiento y Teoria', '6 meses', 120),
('Ingles', 'Courses free of english', 1, 'Modulos de A1 hasta C1', '3 años', 140),
('Viajes', 'Courses free of travels', 1, 'Modulos de practica y teoria', '15 meses', 110);

CREATE TABLE Enrollments (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Date DATE,
    StudentId INT(10),
    FOREIGN KEY (StudentId) REFERENCES Students(Id),
    CourseId INT(10),
    FOREIGN KEY (CourseId) REFERENCES Courses(Id),
    Status ENUM('Active', 'Inactive')
);

INSERT INTO `Enrollments` (`Date`, `StudentId`, `CourseId`, `Status`)
VALUES
('2024-06-06', 1, 1, 'Active'),
('2024-08-08', 2, 2, 'Active'),
('2024-10-10', 3, 3, 'Active'),
('2024-12-12', 4, 4, 'Active'),
('2025-02-02', 5, 5, 'Active');