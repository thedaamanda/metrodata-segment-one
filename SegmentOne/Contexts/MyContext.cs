using System.Data.SqlClient;

namespace SegmentOne.Contexts;

public class MyContext
{
    private static string _serverName = "localhost";
    private static string _databaseName = "db_dts_segment1";
    private static string _userName = "sa";
    private static string _password = "Passw@rd";
    private static SqlConnection connection;
    private string connectionString;

    public MyContext()
    {
        // Memasukkan data koneksi ke dalam string
        connectionString = "Server=" + _serverName + ";Database=" + _databaseName + ";User Id=" + _userName + ";Password=" + _password + "; Trusted_Connection=False; MultipleActiveResultSets=true";

        // Menginisialisasi SqlConnection object
        connection = new SqlConnection(connectionString);
    }

    public bool OpenConnection()
    {
        try
        {
            // Membuka koneksi ke database
            connection.Open();
            return true;
        }
        catch (Exception ex)
        {
            // Melakukan penanganan error jika gagal membuka koneksi
            Console.WriteLine("Error: " + ex.Message);
            return false;
        }
    }

    public void CloseConnection()
    {
        // Menutup koneksi ke database
        connection.Close();
    }

    public SqlConnection GetConnection()
    {
        try
        {
            // Mengembalikan SqlConnection object
            return connection;
        }
        catch (Exception ex)
        {
            // Melakukan penanganan error jika gagal mengembalikan SqlConnection object
            Console.WriteLine("Error: " + ex.Message);
            return null;
        }
    }
}
