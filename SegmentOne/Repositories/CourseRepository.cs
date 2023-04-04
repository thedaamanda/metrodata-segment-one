using SegmentOne.Contexts;
using SegmentOne.Models;
using SegmentOne.Repositories.Interfaces;
using System.Data.SqlClient;

namespace SegmentOne.Repositories;

public class CourseRepository : ICourseRepository
{
    private MyContext _context;

    public CourseRepository(MyContext context)
    {
        _context = context;
    }

    public List<Course> GetAll()
    {
        List<Course> courses = new List<Course>();

        // Membuka koneksi ke database
        _context.OpenConnection();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("SELECT * FROM Courses", _context.GetConnection());

            // Membuat objek SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Membaca data dari SqlDataReader
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    courses.Add(new Course
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        GradeId = reader.GetInt32(3),
                        TeacherId = reader.GetInt32(4)
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

        return courses;
    }

    public Course GetById(int id)
    {
        Course course = new Course();

        // Membuka koneksi ke database
        _context.OpenConnection();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("SELECT * FROM Courses WHERE Id = @Id", _context.GetConnection());

            // Menambahkan parameter ke SqlCommand
            command.Parameters.AddWithValue("@Id", id);

            // Membuat objek SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Membaca data dari SqlDataReader
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    course.Id = reader.GetInt32(0);
                    course.Name = reader.GetString(1);
                    course.Description = reader.GetString(2);
                    course.GradeId = reader.GetInt32(3);
                    course.TeacherId = reader.GetInt32(4);
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

        return course;
    }

    public int Insert(Course course)
    {
        int result = 0;
        // Membuka koneksi ke database
        _context.OpenConnection();

        // Membuat begin transaction
        SqlTransaction transaction = _context.GetConnection().BeginTransaction();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("INSERT INTO Courses (Name, Description, Grade_Id, Teacher_Id) VALUES (@Name, @Description, @GradeId, @TeacherId)", _context.GetConnection(), transaction);

            // Menambahkan parameter ke SqlCommand
            command.Parameters.AddWithValue("@Name", course.Name);
            command.Parameters.AddWithValue("@Description", course.Description);
            command.Parameters.AddWithValue("@GradeId", course.GradeId);
            command.Parameters.AddWithValue("@TeacherId", course.TeacherId);

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

    public int Update(Course course)
    {
        int result = 0;

        // Membuka koneksi ke database
        _context.OpenConnection();

        // Membuat begin transaction
        SqlTransaction transaction = _context.GetConnection().BeginTransaction();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("UPDATE Courses SET Name = @Name, Description = @Description, Grade_Id = @GradeId, Teacher_Id = @TeacherId WHERE Id = @Id", _context.GetConnection(), transaction);

            // Menambahkan parameter ke SqlCommand
            command.Parameters.AddWithValue("@Id", course.Id);
            command.Parameters.AddWithValue("@Name", course.Name);
            command.Parameters.AddWithValue("@Description", course.Description);
            command.Parameters.AddWithValue("@GradeId", course.GradeId);
            command.Parameters.AddWithValue("@TeacherId", course.TeacherId);

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
            SqlCommand command = new SqlCommand("DELETE FROM Courses WHERE Id = @Id", _context.GetConnection(), transaction);

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
