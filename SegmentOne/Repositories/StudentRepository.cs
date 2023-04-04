using SegmentOne.Contexts;
using SegmentOne.Models;
using SegmentOne.Repositories.Interfaces;
using System.Data.SqlClient;

namespace SegmentOne.Repositories;

public class StudentRepository : IStudentRepository
{
    private MyContext _context;

    public StudentRepository(MyContext context)
    {
        _context = context;
    }

    public List<Student> GetAll()
    {
        List<Student> students = new List<Student>();

        // Membuka koneksi ke database
        _context.OpenConnection();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("SELECT * FROM Students", _context.GetConnection());

            // Membuat objek SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Membaca data dari SqlDataReader
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = reader.GetInt32(0),
                        NISN = reader.GetString(1),
                        FirstName = reader.GetString(2),
                        LastName = reader.GetString(3),
                        Email = reader.GetString(4),
                        Phone = reader.GetString(5),
                        Status = reader.GetBoolean(6),
                        ClassroomId = reader.GetInt32(7)
                    });
                }
            }

            // Menutup objek SqlDataReader
            reader.Close();
        } catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message);
        } finally {
            // Menutup koneksi ke database
            _context.CloseConnection();
        }

        return students;
    }

    public Student GetById(int id)
    {
        Student student = new Student();

        // Membuka koneksi ke database
        _context.OpenConnection();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("SELECT * FROM Students WHERE Id = @Id", _context.GetConnection());

            // Menambahkan parameter ke SqlCommand
            command.Parameters.AddWithValue("@Id", id);

            // Membuat objek SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Membaca data dari SqlDataReader
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    student.Id = reader.GetInt32(0);
                    student.NISN = reader.GetString(1);
                    student.FirstName = reader.GetString(2);
                    student.LastName = reader.GetString(3);
                    student.Email = reader.GetString(4);
                    student.Phone = reader.GetString(5);
                    student.Status = reader.GetBoolean(6);
                    student.ClassroomId = reader.GetInt32(7);
                }
            } else {
                return null;
            }
        } catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message);
        } finally {
            // Menutup koneksi ke database
            _context.CloseConnection();
        }

        return student;
    }

    public int Insert(Student student)
    {
        int result = 0;
        // Membuka koneksi ke database
        _context.OpenConnection();

        // Membuat begin transaction
        SqlTransaction transaction = _context.GetConnection().BeginTransaction();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("INSERT INTO Students (NISN, First_Name, Last_Name, Email, Phone, Status, Classroom_Id) VALUES (@NISN, @FirstName, @LastName, @Email, @Phone, @Status, @ClassroomId)", _context.GetConnection(), transaction);

            // Menambahkan parameter ke SqlCommand
            command.Parameters.AddWithValue("@NISN", student.NISN);
            command.Parameters.AddWithValue("@FirstName", student.FirstName);
            command.Parameters.AddWithValue("@LastName", student.LastName);
            command.Parameters.AddWithValue("@Email", student.Email);
            command.Parameters.AddWithValue("@Phone", student.Phone);
            command.Parameters.AddWithValue("@Status", student.Status);
            command.Parameters.AddWithValue("@ClassroomId", student.ClassroomId);

            // Menjalankan perintah SQL
            result = command.ExecuteNonQuery();

            // Commit transaksi
            transaction.Commit();

        } catch (Exception ex) {
            // Melakukan rollback jika terjadi error
            transaction.Rollback();
            Console.WriteLine("Error: " + ex.Message);
        } finally {
            // Menutup koneksi ke database
            _context.CloseConnection();
        }

        return result;
    }

    public int Update(Student student)
    {
        int result = 0;

        // Membuka koneksi ke database
        _context.OpenConnection();

        // Membuat begin transaction
        SqlTransaction transaction = _context.GetConnection().BeginTransaction();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("UPDATE Students SET NISN = @NISN, First_Name = @FirstName, Last_Name = @LastName, Email = @Email, Phone = @Phone, Status = @Status, Classroom_Id = @ClassroomId WHERE Id = @Id", _context.GetConnection(), transaction);

            // Menambahkan parameter ke SqlCommand
            command.Parameters.AddWithValue("@Id", student.Id);
            command.Parameters.AddWithValue("@NISN", student.NISN);
            command.Parameters.AddWithValue("@FirstName", student.FirstName);
            command.Parameters.AddWithValue("@LastName", student.LastName);
            command.Parameters.AddWithValue("@Email", student.Email);
            command.Parameters.AddWithValue("@Phone", student.Phone);
            command.Parameters.AddWithValue("@Status", student.Status);
            command.Parameters.AddWithValue("@ClassroomId", student.ClassroomId);

            // Menjalankan perintah SQL
            result = command.ExecuteNonQuery();

            // Commit transaksi
            transaction.Commit();
        } catch (Exception ex) {
            // Melakukan rollback jika terjadi error
            transaction.Rollback();
            Console.WriteLine("Error: " + ex.Message);
        } finally {
            // Menutup koneksi ke database
            _context.CloseConnection();
        }

        return result;
    }

    public int Delete(int id)
    {
        int result = 0;
        // Membuka koneksi ke database
        _context.OpenConnection();

        // Membuat begin transaction
        SqlTransaction transaction = _context.GetConnection().BeginTransaction();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("DELETE FROM Students WHERE Id = @Id", _context.GetConnection(), transaction);

            // Menambahkan parameter ke SqlCommand
            command.Parameters.AddWithValue("@Id", id);

            // Menjalankan perintah SQL
            result = command.ExecuteNonQuery();

            // Commit transaksi
            transaction.Commit();
        } catch (Exception ex) {
            // Melakukan rollback jika terjadi error
            transaction.Rollback();
            Console.WriteLine("Error: " + ex.Message);
        } finally {
            // Menutup koneksi ke database
            _context.CloseConnection();
        }

        return result;
    }
}
