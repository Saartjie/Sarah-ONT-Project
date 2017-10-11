using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;




namespace _216310962
{
    class DataAccessLayer
    {
        private string connectionString;
        SqlConnection dbConnection;
        SqlCommand dbCommand;
        SqlDataAdapter dbAdapter;
        SqlDataReader dr;
        DataTable dt = new DataTable();

        public DataAccessLayer()
        {
            connectionString = @"Data Source =(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\216310962.mdf" + ";Intergrated Security=True;Connect Timeout=30";
            dbConnection = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\216310962.mdf" + ";Intergrated Security=True;Connect Timeout=30");
        }
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
    }
}
