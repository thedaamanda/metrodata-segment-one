using System.Data.SqlClient;

namespace SegmentOne.Contexts
{
	public class MyContext
	{
        private static SqlConnection connection;
        private string connectionString;

		public MyContext(string serverName, string databaseName, string userName, string password)
		{
            // Memasukkan data koneksi ke dalam string
            connectionString = "Server=" + serverName + ";Database=" + databaseName + ";User Id=" + userName + ";Password=" + password + "; Trusted_Connection=False; MultipleActiveResultSets=true";

            // Menginisialisasi SqlConnection object
            connection = new SqlConnection(connectionString);
		}

        public bool OpenConnection()
        {
            try
            {
                // Membuka koneksi ke database
                connection.Open();
                Console.WriteLine("Connection Open ! ");
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
}
