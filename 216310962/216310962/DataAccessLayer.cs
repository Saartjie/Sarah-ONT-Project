using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace ProblemProject
{
    internal class DataAccessLayer
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

        public DataTable getAllProblems()
        {
            dbCommand = new SqlCommand("sp_GetAllProblems", dbConnection);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }

        public DataTable getProblemWithStatus(string status)
        {
            dbCommand = new SqlCommand("sp_GetProblemWithStatus", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@Status", status);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }

        public void insertIntoProblem(DateTime ProblemDateTime, int ProblemPriority, string ReportingUser, string StaffID, string MachineID, string CurrentDirectory, string ProblemComment, string ProblemCategory, string LogicalDrives, string ProblemStatus)
        {
            dbCommand = new SqlCommand("sp_InsertIntoProblem", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@ProblemDateTime", ProblemDateTime);
            dbCommand.Parameters.AddWithValue("@ProblemPriority", ProblemPriority);
            dbCommand.Parameters.AddWithValue("@ReportingUser", ReportingUser);
            dbCommand.Parameters.AddWithValue("@MachineID", MachineID);
            dbCommand.Parameters.AddWithValue("@CurrentDirectory", CurrentDirectory);
            dbCommand.Parameters.AddWithValue("@ProblemComment", ProblemComment);
            dbCommand.Parameters.AddWithValue("@ProblemCategory", ProblemCategory);
            dbCommand.Parameters.AddWithValue("@MachineLogicalDrives", LogicalDrives);
            dbCommand.Parameters.AddWithValue("@ProblemStatus", ProblemStatus);
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            int result = dbCommand.ExecuteNonQuery();

            dbConnection.Close();
        }
        public void updateProblemStatus(int ProblemID, string ProblemStatus)
        {
            dbCommand = new SqlCommand("sp_UpdateProblemStatus", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@ProblemID", ProblemID);
            dbCommand.Parameters.AddWithValue("@ProblemStatus", ProblemStatus);
            dbAdapter = new SqlDataAdapter(dbCommand);
            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();
            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
        }
        public DataTable sortHighPriority()
        {
            dbCommand = new SqlCommand("sp_FilterHighPriority", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }

        public DataTable sortByDate(DateTime from, DateTime to)
        {
            dbCommand = new SqlCommand("sp_FilterByDate", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@from", from);
            dbCommand.Parameters.AddWithValue("@to", to);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }

        public DataTable sortByCategory(string category)
        {
            dbCommand = new SqlCommand("sp_FilterByCategory", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@category", category);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }

        public DataTable sortByStaffID(string staffID)
        {
            dbCommand = new SqlCommand("sp_FilterByStaffID", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@StaffID", staffID);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }

        public DataTable sortByMachineID(string machineID)
        {
            dbCommand = new SqlCommand("sp_FilterByMachineID", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@MachineID", machineID);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }
        public string getProblemStatus(int ProblemID)
        {
            dbCommand = new SqlCommand("sp_GetProblemStatus", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@ProblemID", ProblemID);
            dbAdapter = new SqlDataAdapter(dbCommand);
            string status;

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            status = dbCommand.ExecuteScalar().ToString();
            dbConnection.Close();
            return status;
        }

        public DataTable getProblemLog(int ProblemID)
        {
            dbCommand = new SqlCommand("sp_GetProblemLog", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@ProblemID", ProblemID);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }
        public void addProblemLog(int ProblemID, DateTime LogDateTime, string LogStaffID, string SolutionLogComment)
        {
            dbCommand = new SqlCommand("sp_InsertIntoProblemLog", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@ProblemID", ProblemID);
            dbCommand.Parameters.AddWithValue("@LogDateTime", LogDateTime);
            dbCommand.Parameters.AddWithValue("@LogStaffID", LogStaffID);
            dbCommand.Parameters.AddWithValue("@SolutionLogComment", SolutionLogComment);
            dbAdapter = new SqlDataAdapter(dbCommand);
            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();
            int result = dbCommand.ExecuteNonQuery();
            dbConnection.Close();
        }
        public DataTable getCategories()
        {
            dbCommand = new SqlCommand("sp_GetCategory", dbConnection);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }
        public int getNumCategory()
        {
            dbCommand = new SqlCommand("sp_GetNumCategory", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbAdapter = new SqlDataAdapter(dbCommand);
            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();
            int x;
            x = (int)dbCommand.ExecuteScalar();
            dbConnection.Close();
            return x;
        }
        public DataTable getStaff()
        {
            dbCommand = new SqlCommand("sp_GetStaff", dbConnection);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }
        public DataTable getAllAssignedProblems(string StaffID)
        {
            dbCommand = new SqlCommand("sp_GetAssignedProblems", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@StaffID", StaffID);
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            dbCommand.ExecuteNonQuery();
            dbAdapter.Fill(dt);
            dbConnection.Close();
            return dt;
        }

        public string getStaffRole(string Username)
        {
            string staffRole = "";
            dbCommand = new SqlCommand("sp_GetStaffRole", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@Username", Username);
            dbAdapter = new SqlDataAdapter(dbCommand);
            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();
            dbCommand.ExecuteNonQuery();
            dbAdapter.Fill(dt);
            dr = dbCommand.ExecuteReader();
            while (dr.Read())
            {
                staffRole = Convert.ToString(dr[3]);
            }
            dbConnection.Close();
            return staffRole;
        }

        public string getStaffID(string username)
        {
            string StaffID = "";
            dbCommand = new SqlCommand("sp_GetStaffID", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@Username", username);
            dbAdapter = new SqlDataAdapter(dbCommand);
            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();
            dbCommand.ExecuteNonQuery();
            dbAdapter.Fill(dt);
            dr = dbCommand.ExecuteReader();
            while (dr.Read())
            {
                StaffID = Convert.ToString(dr[0]);
            }
            dbConnection.Close();
            return StaffID;
        }

        public void allocateStaff(int ProblemID, string StaffID)
        {
            dbCommand = new SqlCommand("sp_AllocateStaff", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@ProblemID", ProblemID);
            dbCommand.Parameters.AddWithValue("@Staff", StaffID);
            dbCommand.Parameters.AddWithValue("@Status", "Waiting");
            dbAdapter = new SqlDataAdapter(dbCommand);
            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();
            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
        }
        public int getNumStaff()
        {
            dbCommand = new SqlCommand("sp_GetNumStaff", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbAdapter = new SqlDataAdapter(dbCommand);
            int NumStaff;
            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();
            NumStaff = (int)dbCommand.ExecuteScalar();
            dbConnection.Close();
            return NumStaff;
        }

        public string getStaffPass(string username)
        {
            string StaffPassword = "";
            dbCommand = new SqlCommand("sp_GetStaffPass", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@Username", username);
            dbAdapter = new SqlDataAdapter(dbCommand);
            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();
            dbCommand.ExecuteNonQuery();
            dbAdapter.Fill(dt);
            dr = dbCommand.ExecuteReader();
            while (dr.Read())
            {
                StaffPassword = Convert.ToString(dr[0]);
            }
            dbConnection.Close();
            return StaffPassword;
        }
    }
}