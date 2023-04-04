using SegmentOne.Contexts;
using SegmentOne.Models;
using SegmentOne.Repositories.Interfaces;
using System.Data.SqlClient;

namespace SegmentOne.Repositories;

public class ClassroomCourseRepository : IClassroomCourseRepository
{
    private MyContext _context;

    public ClassroomCourseRepository(MyContext context)
    {
        _context = context;
    }

    public List<ClassroomCourse> GetAll()
    {
        List<ClassroomCourse> classrooms = new List<ClassroomCourse>();

        // Membuka koneksi ke database
        _context.OpenConnection();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("SELECT A.*, B.code, C.name FROM Classroom_Course A INNER JOIN Classrooms B ON A.Classroom_Id = B.Id INNER JOIN Courses C ON A.Course_Id = C.Id", _context.GetConnection());

            // Membuat objek SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Membaca data dari SqlDataReader
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    classrooms.Add(new ClassroomCourse
                    {
                        Id = reader.GetInt32(0),
                        ClassroomId = reader.GetInt32(1),
                        CourseId = reader.GetInt32(2),
                        Classroom = new Classroom
                        {
                            Id = reader.GetInt32(1),
                            Code = reader.GetString(3)
                        },
                        Course = new Course
                        {
                            Id = reader.GetInt32(2),
                            Name = reader.GetString(4)
                        }
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

        return classrooms;
    }

    public int Insert(ClassroomCourse classroomCourse)
    {
        int result = 0;
        // Membuka koneksi ke database
        _context.OpenConnection();

        // Membuat begin transaction
        SqlTransaction transaction = _context.GetConnection().BeginTransaction();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("INSERT INTO Classroom_Course (Classroom_Id, Course_Id) VALUES (@ClassroomId, @CourseId)", _context.GetConnection(), transaction);

            // Menambahkan parameter
            command.Parameters.AddWithValue("@ClassroomId", classroomCourse.ClassroomId);
            command.Parameters.AddWithValue("@CourseId", classroomCourse.CourseId);

            // Menjalankan perintah SQL
            result = command.ExecuteNonQuery();

            // Commit transaction
            transaction.Commit();
        } catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message);

            // Rollback transaction
            transaction.Rollback();
        } finally {
            // Menutup koneksi ke database
            _context.CloseConnection();
        }

        return result;
    }
}
