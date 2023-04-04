using SegmentOne.Contexts;
using SegmentOne.Models;
using SegmentOne.Repositories.Interfaces;
using System.Data.SqlClient;

namespace SegmentOne.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private MyContext _context;

    public TeacherRepository(MyContext context)
    {
        _context = context;
    }

    public List<Teacher> GetAll()
    {
        List<Teacher> teachers = new List<Teacher>();

        // Membuka koneksi ke database
        _context.OpenConnection();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("SELECT * FROM Teachers", _context.GetConnection());

            // Membuat objek SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Membaca data dari SqlDataReader
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    teachers.Add(new Teacher
                    {
                        Id = reader.GetInt32(0),
                        NIP = reader.GetString(1),
                        FirstName = reader.GetString(2),
                        LastName = reader.GetString(3),
                        Email = reader.GetString(4),
                        Phone = reader.GetString(5),
                        Status = reader.GetBoolean(6)
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

        return teachers;
    }

    public Teacher GetById(int id)
    {
        Teacher teacher = new Teacher();

        // Membuka koneksi ke database
        _context.OpenConnection();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("SELECT * FROM Teachers WHERE Id = @Id", _context.GetConnection());

            // Menambahkan parameter ke SqlCommand
            command.Parameters.AddWithValue("@Id", id);

            // Membuat objek SqlDataReader
            SqlDataReader reader = command.ExecuteReader();

            // Membaca data dari SqlDataReader
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    teacher.Id = reader.GetInt32(0);
                    teacher.NIP = reader.GetString(1);
                    teacher.FirstName = reader.GetString(2);
                    teacher.LastName = reader.GetString(3);
                    teacher.Email = reader.GetString(4);
                    teacher.Phone = reader.GetString(5);
                    teacher.Status = reader.GetBoolean(6);
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

        return teacher;
    }

    public int Insert(Teacher teacher)
    {
        int result = 0;
        // Membuka koneksi ke database
        _context.OpenConnection();

        // Membuat begin transaction
        SqlTransaction transaction = _context.GetConnection().BeginTransaction();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("INSERT INTO Teachers (NIP, First_Name, Last_Name, Email, Phone, Status) VALUES (@NIP, @FirstName, @LastName, @Email, @Phone, @Status)", _context.GetConnection(), transaction);

            // Menambahkan parameter ke SqlCommand
            command.Parameters.AddWithValue("@NIP", teacher.NIP);
            command.Parameters.AddWithValue("@FirstName", teacher.FirstName);
            command.Parameters.AddWithValue("@LastName", teacher.LastName);
            command.Parameters.AddWithValue("@Email", teacher.Email);
            command.Parameters.AddWithValue("@Phone", teacher.Phone);
            command.Parameters.AddWithValue("@Status", teacher.Status);

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

    public int Update(Teacher teacher)
    {
        int result = 0;

        // Membuka koneksi ke database
        _context.OpenConnection();

        // Membuat begin transaction
        SqlTransaction transaction = _context.GetConnection().BeginTransaction();

        try {
            // Membuat objek SqlCommand
            SqlCommand command = new SqlCommand("UPDATE Teachers SET NIP = @NIP, First_Name = @FirstName, Last_Name = @LastName, Email = @Email, Phone = @Phone, Status = @Status WHERE Id = @Id", _context.GetConnection(), transaction);

            // Menambahkan parameter ke SqlCommand
            command.Parameters.AddWithValue("@Id", teacher.Id);
            command.Parameters.AddWithValue("@NIP", teacher.NIP);
            command.Parameters.AddWithValue("@FirstName", teacher.FirstName);
            command.Parameters.AddWithValue("@LastName", teacher.LastName);
            command.Parameters.AddWithValue("@Email", teacher.Email);
            command.Parameters.AddWithValue("@Phone", teacher.Phone);
            command.Parameters.AddWithValue("@Status", teacher.Status);

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
            SqlCommand command = new SqlCommand("DELETE FROM Teachers WHERE Id = @Id", _context.GetConnection(), transaction);

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
