CREATE DATABASE db_dts_segment1;

USE db_dts_segment1;

-- SQL Server syntax
CREATE TABLE grades (
    id INT IDENTITY PRIMARY KEY,
    name VARCHAR(50),
    description VARCHAR(255),
);

CREATE TABLE classrooms (
    id INT IDENTITY PRIMARY KEY,
    code VARCHAR(10),
    year CHAR(4) NOT NULL,
    grade_id INT NOT NULL

    FOREIGN KEY (grade_id) REFERENCES grades(id)
);

CREATE TABLE students (
    id INT IDENTITY PRIMARY KEY,
    nisn CHAR(10) UNIQUE,
    first_name VARCHAR(50),
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(50) UNIQUE,
    phone VARCHAR(15) NOT NULL,
    status BIT,
    classroom_id INT NOT NULL

    FOREIGN KEY (classroom_id) REFERENCES classrooms(id)
);

CREATE TABLE teachers (
    id INT IDENTITY PRIMARY KEY,
    nip CHAR(18) UNIQUE,
    first_name VARCHAR(50),
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(50) UNIQUE,
    phone VARCHAR(15) NOT NULL,
    status BIT
);


CREATE TABLE courses (
    id INT IDENTITY PRIMARY KEY,
    name VARCHAR(50),
    description VARCHAR(255),
    grade_id INT NOT NULL,
    teacher_id INT NOT NULL

    FOREIGN KEY (grade_id) REFERENCES grades(id),
    FOREIGN KEY (teacher_id) REFERENCES teachers(id)
);

CREATE TABLE classroom_course (
    id INT IDENTITY PRIMARY KEY,
    course_id INT NOT NULL,
    classroom_id INT NOT NULL

    FOREIGN KEY (course_id) REFERENCES courses(id),
    FOREIGN KEY (classroom_id) REFERENCES classrooms(id)
);

INSERT INTO grades (name, description) VALUES
    ('X', 'Kelas 10'),
    ('XI', 'Kelas 11'),
    ('XII', 'Kelas 12');

INSERT INTO classrooms (code, year, grade_id) VALUES
    ('X.A', '2023', 1),
    ('X.B', '2023', 1),
    ('XI.A', '2023', 2),
    ('XI.B', '2023', 2),
    ('XII.A', '2023', 3),
    ('XII.B', '2023', 3);

INSERT INTO students (nisn, first_name, last_name, email, phone, status, classroom_id) VALUES
    ('1234567890', 'John', 'Doe', 'johndoe@gmail.com', '081234567890', 1, 1),
    ('1234567891', 'Jane', 'Doe', 'janedoe@gmail.com', '081234567891', 1, 1),
    ('1234567892', 'John', 'Smith', 'johnsmith@gmail.com', '081234567892', 1, 2),
    ('1234567893', 'Jane', 'Smith', 'janesmith@gmail.com', '081234567893', 1, 2),
    ('1234567894', 'Sally', 'Doe', 'sallydoe@gmail.com', '081234567894', 1, 2);

INSERT INTO teachers (nip, first_name, last_name, email, phone, status) VALUES
    ('123456789012345670', 'Bryan', 'Keith', 'bryankeith@gmail.com', '081234567890', 1),
    ('123456789012345671', 'Jimmy', 'Son', 'jimmyson@gmail.com', '081234567891', 0),
    ('123456789012345672', 'Sandy', 'Jeff', 'sandyjeff@gmail.com', '081234567892', 1);

INSERT INTO courses (name, description, grade_id, teacher_id) VALUES
    ('Matematika', 'Mata pelajaran matematika', 1, 1),
    ('Matematika', 'Mata pelajaran matematika', 2, 1),
    ('Matematika', 'Mata pelajaran matematika', 3, 1),
    ('Bahasa Indonesia', 'Mata pelajaran bahasa indonesia', 1, 2),
    ('Bahasa Indonesia', 'Mata pelajaran bahasa indonesia', 2, 2),
    ('Bahasa Indonesia', 'Mata pelajaran bahasa indonesia', 3, 2),
    ('Bahasa Inggris', 'Mata pelajaran bahasa inggris', 1, 3),
    ('Bahasa Inggris', 'Mata pelajaran bahasa inggris', 2, 3),
    ('Bahasa Inggris', 'Mata pelajaran bahasa inggris', 3, 3);

