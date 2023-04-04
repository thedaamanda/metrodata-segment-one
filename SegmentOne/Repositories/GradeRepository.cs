using SegmentOne.Contexts;
using SegmentOne.Models;
using SegmentOne.Repositories.Interfaces;
using System.Data.SqlClient;

namespace SegmentOne.Repositories;

public class GradeRepository : IGradeRepository
{
    private MyContext _context;

    public GradeRepository(MyContext context)
    {
        _context = context;
    }

    public List<Grade> GetAll()
    {
        List<Grade> grades = new List<Grade>();

        // Membuka koneksi ke database
        _context.OpenConnection();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("SELECT * FROM Grades", _context.GetConnection());

            // Membuat objek SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Membaca data dari SqlDataReader
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    grades.Add(new Grade
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2)
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

        return grades;
    }

    public Grade GetById(int id)
    {
        Grade grade = new Grade();

        // Membuka koneksi ke database
        _context.OpenConnection();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("SELECT * FROM Grades WHERE Id = @Id", _context.GetConnection());

            // Menambahkan parameter ke SqlCommand
            command.Parameters.AddWithValue("@Id", id);

            // Membuat objek SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Membaca data dari SqlDataReader
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    grade.Id = reader.GetInt32(0);
                    grade.Name = reader.GetString(1);
                    grade.Description = reader.GetString(2);
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

        return grade;
    }

    public int Insert(Grade grade)
    {
        int result = 0;
        // Membuka koneksi ke database
        _context.OpenConnection();

        // Membuat begin transaction
        SqlTransaction transaction = _context.GetConnection().BeginTransaction();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("INSERT INTO Grades (Name, Description) VALUES (@Name, @Description)", _context.GetConnection(), transaction);

            // Menambahkan parameter ke SqlCommand
            command.Parameters.AddWithValue("@Name", grade.Name);
            command.Parameters.AddWithValue("@Description", grade.Description);

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

    public int Update(Grade grade)
    {
        int result = 0;

        // Membuka koneksi ke database
        _context.OpenConnection();

        // Membuat begin transaction
        SqlTransaction transaction = _context.GetConnection().BeginTransaction();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("UPDATE Grades SET Name = @Name, Description = @Description WHERE Id = @Id", _context.GetConnection(), transaction);

            // Menambahkan parameter ke SqlCommand
            command.Parameters.AddWithValue("@Id", grade.Id);
            command.Parameters.AddWithValue("@Name", grade.Name);
            command.Parameters.AddWithValue("@Description", grade.Description);

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
            SqlCommand command = new SqlCommand("DELETE FROM Grades WHERE Id = @Id", _context.GetConnection(), transaction);

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
