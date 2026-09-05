using System;
using System.Data;
using System.Data.SqlClient;

namespace GoMartApplication
{
    class DBConnect
    {
        private readonly SqlConnection con =
            new SqlConnection(
                @"Data Source=LAPTOP-GKLO9QEE\SQLEXPRESS;" +
                @"Initial Catalog=GoMartDB;" +
                @"Integrated Security=True;" +
                @"TrustServerCertificate=True;");

        public SqlConnection GetCon()
        {
            return con;
        }

        public void OpenCon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void CloseCon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}