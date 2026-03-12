using Microsoft.Data.SqlClient;

namespace task_3
{
    public class Connection
    {
        private SqlConnection SqlConnection;

        public Connection(string constring = "Server=.\\MSSQLSERVER01;TrustServerCertificate=True;Integrated Security=True")
        {
            SqlConnection = new SqlConnection(constring);
        }
        public SqlConnection GetConnection()
        {
            return SqlConnection;
        }
    }
}
