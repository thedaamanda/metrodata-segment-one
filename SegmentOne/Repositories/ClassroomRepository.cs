using SegmentOne.Contexts;
using SegmentOne.Models;
using SegmentOne.Repositories.Interfaces;
using System.Data.SqlClient;

namespace SegmentOne.Repositories;

public class ClassroomRepository : IClassroomRepository
{
    private MyContext _context;

    public ClassroomRepository(MyContext context)
    {
        _context = context;
    }

    public List<Classroom> GetAll()
    {
        List<Classroom> classrooms = new List<Classroom>();

        // Membuka koneksi ke database
        _context.OpenConnection();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("SELECT * FROM Classrooms", _context.GetConnection());

            // Membuat objek SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Membaca data dari SqlDataReader
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    classrooms.Add(new Classroom
                    {
                        Id = reader.GetInt32(0),
                        Code = reader.GetString(1),
                        Year = reader.GetString(2),
                        GradeId = reader.GetInt32(3)
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

    public Classroom GetById(int id)
    {
        Classroom classroom = new Classroom();

        // Membuka koneksi ke database
        _context.OpenConnection();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("SELECT * FROM Classrooms WHERE Id = @Id", _context.GetConnection());

            // Menambahkan parameter ke SqlCommand
            command.Parameters.AddWithValue("@Id", id);

            // Membuat objek SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Membaca data dari SqlDataReader
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    classroom.Id = reader.GetInt32(0);
                    classroom.Code = reader.GetString(1);
                    classroom.Year = reader.GetString(2);
                    classroom.GradeId = reader.GetInt32(3);
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

        return classroom;
    }

    public int Insert(Classroom classroom)
    {
        int result = 0;
        // Membuka koneksi ke database
        _context.OpenConnection();

        // Membuat begin transaction
        SqlTransaction transaction = _context.GetConnection().BeginTransaction();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("INSERT INTO Classrooms (Code, Year, Grade_Id) VALUES (@Code, @Year, @GradeId)", _context.GetConnection(), transaction);

            // Menambahkan parameter ke SqlCommand
            command.Parameters.AddWithValue("@Code", classroom.Code);
            command.Parameters.AddWithValue("@Year", classroom.Year);
            command.Parameters.AddWithValue("@GradeId", classroom.GradeId);

            // Menjalankan perintah SQL
            result = command.ExecuteNonQuery();

            // Commit transaction
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

    public int Update(Classroom classroom)
    {
        int result = 0;

        // Membuka koneksi ke database
        _context.OpenConnection();

        // Membuat begin transaction
        SqlTransaction transaction = _context.GetConnection().BeginTransaction();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("UPDATE Classrooms SET Code = @Code, Year = @Year, Grade_Id = @GradeId WHERE Id = @Id", _context.GetConnection(), transaction);

            // Menambahkan parameter ke SqlCommand
            command.Parameters.AddWithValue("@Id", classroom.Id);
            command.Parameters.AddWithValue("@Code", classroom.Code);
            command.Parameters.AddWithValue("@Year", classroom.Year);
            command.Parameters.AddWithValue("@GradeId", classroom.GradeId);

            // Menjalankan perintah SQL
            result = command.ExecuteNonQuery();

            // Commit transaction
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
            SqlCommand command = new SqlCommand("DELETE FROM Classrooms WHERE Id = @Id", _context.GetConnection(), transaction);

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
