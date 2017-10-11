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
            dbConnection = new SqlConnection(@"Data Source =(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Application.StartupPath + @"\216310962.mdf" + ";Connect Timeout=30");
        }
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }
        //Problem Methods
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
        public void updateProblemStatus(int ProblemID, string status)
        {
            dbCommand = new SqlCommand("sp_UpdateProblemStatus", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@ProblemID", ProblemID);
            dbCommand.Parameters.AddWithValue("@Status", status);
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
        }
        public DataTable filterHighPriority()
        {
            dbCommand = new SqlCommand("sp_FilterHighPriority", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }

        public DataTable filterByDate(DateTime from, DateTime to)
        {
            dbCommand = new SqlCommand("sp_FilterByDate", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@from", from);
            dbCommand.Parameters.AddWithValue("@to", to);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }

        public DataTable filterByCategory(string category)
        {
            dbCommand = new SqlCommand("sp_FilterByCategory", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@category", category);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }

        public DataTable filterByStaffID(string staffID)
        {
            dbCommand = new SqlCommand("sp_FilterByStaffID", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@StaffID", staffID);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }

        public DataTable filterByMachineID(string machineID)
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

        public void updateProblem(int ProblemID, DateTime UpdateTime, int ProblemPriority, string CategoryID)
        {
            dbCommand = new SqlCommand("sp_UpdateProblem", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@ProblemID", ProblemID);
            dbCommand.Parameters.AddWithValue("@ProblemDateTime", UpdateTime);
            dbCommand.Parameters.AddWithValue("@ProblemPriority", ProblemPriority);
            dbCommand.Parameters.AddWithValue("@CategoryID", CategoryID);
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            dbCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        //ProblemLog Methods
        public DataTable getProblemLog(int ProblemID)
        {
            dbCommand = new SqlCommand("sp_GetProblemLog", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@ProblemID", ProblemID);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }
        public void insertIntoProblemLog(int ProblemID, DateTime LogDateTime, string LogStaffID, string SolutionLogComment)
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

        //Category Methods
        public DataTable getCategories()
        {
            dbCommand = new SqlCommand("sp_GetCategory", dbConnection);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }
        public void insertCategory(string catCode, string catDesc)
        {
            dbCommand = new SqlCommand("sp_InsertCategory", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@CatCode", catCode);
            dbCommand.Parameters.AddWithValue("@CatName", catDesc);
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            int result = dbCommand.ExecuteNonQuery();

            dbConnection.Close();
        }
        public int categoryExists(string catCode)
        {
            dbCommand = new SqlCommand("sp_CategoryExists", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@CategoryCode", catCode);
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            int i;
            i = (int)dbCommand.ExecuteScalar();

            dbConnection.Close();
            return i;
        }
        public int getNumCategory()
        {
            dbCommand = new SqlCommand("sp_GetNumCategory", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            int i;
            i = (int)dbCommand.ExecuteScalar();
            dbConnection.Close();
            return i;
        }
        public void removeCategory(string CategoryID)
        {
            dbCommand = new SqlCommand("sp_RemoveCategory", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@CategoryID", CategoryID);
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
        }

        //Staff Methods
        public DataTable getAllStaff()
        {
            dbCommand = new SqlCommand("sp_GetAllStaff", dbConnection);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }

        public string[] getAllStaffUserNames(int staffNum)
        {
            dbCommand = new SqlCommand("sp_GetAllStaff", dbConnection);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            string[] username = new string[staffNum];
            dbConnection.Open();
            dr = dbCommand.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                username[i] = dr[4].ToString();
                i++;
            }
            dbConnection.Close();
            return username;
        }

        public int[] getAllAssignedProblems(int numberOfRecords, string StaffID)
        {
            dbCommand = new SqlCommand("sp_GetAssignedProblems", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@StaffID", StaffID);
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            dbCommand.ExecuteNonQuery();
            dbAdapter.Fill(dt);
            int[] ProblemID = new int[numberOfRecords];
            dr = dbCommand.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                ProblemID[i] = Convert.ToInt32(dr[0]);
                i++;
            }
            dbConnection.Close();
            return ProblemID;
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
                staffRole = Convert.ToString(dr[0]);
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

        public int[] getAllProblemIDs(int num)
        {
            dbCommand = new SqlCommand("sp_GetAllProblems", dbConnection);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            int[] ProblemID = new int[num];

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            dr = dbCommand.ExecuteReader();
            int i = 0;
            string temp;
            while (dr.Read())
            {
                temp = dr[0].ToString();
                ProblemID[i] = int.Parse(temp);
                i++;
            }
            dbConnection.Close();
            return ProblemID;
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
            string StaffUsername = "";
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
                StaffUsername = Convert.ToString(dr[0]);
            }
            dbConnection.Close();
            return StaffUsername;
        }

        public void addStaffMember(string Surname, string Name, string StaffRole, string Username, string Password)
        {
            dbCommand = new SqlCommand("sp_AddStaffMember", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@Surname", Surname);
            dbCommand.Parameters.AddWithValue("@Name", Name);
            dbCommand.Parameters.AddWithValue("@StaffRole", StaffRole);
            dbCommand.Parameters.AddWithValue("@Username", Username);
            dbCommand.Parameters.AddWithValue("@Password", Password);
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            int result = dbCommand.ExecuteNonQuery();

            dbConnection.Close();
        }

        public int staffExists(string username)
        {
            dbCommand = new SqlCommand("sp_StaffExists", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@Username", username);
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            int i;
            i = (int)dbCommand.ExecuteScalar();
            dbConnection.Close();
            return i;
        }

        public void removeStaffMember(string StaffID)
        {
            dbCommand = new SqlCommand("sp_RemoveStaffMember", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@StaffID", StaffID);
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
        }

        public DataTable viewStaff()
        {
            dbCommand = new SqlCommand("sp_ViewStaff", dbConnection);
            dbAdapter = new SqlDataAdapter(dbCommand);
            dbAdapter.Fill(dt);
            return dt;
        }

        public void updateStaffRole(string StaffID, string StaffRole)
        {
            dbCommand = new SqlCommand("sp_UpdateStaffRole", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@StaffID", StaffID);
            dbCommand.Parameters.AddWithValue("@StaffRole", StaffRole);
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
        }

        public void updateStaffUsername(string StaffID, string Username)
        {
            dbCommand = new SqlCommand("sp_UpdateStaffUsername", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@StaffID", StaffID);
            dbCommand.Parameters.AddWithValue("@Username", Username);
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
        }

        public void updateStaffPass(string StaffID, string pass)
        {
            dbCommand = new SqlCommand("sp_UpdateStaffPass", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@StaffID", StaffID);
            dbCommand.Parameters.AddWithValue("@Pass", pass);
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            dbCommand.ExecuteNonQuery();
            dbConnection.Close();
        }

        public string getStaffSurname(string StaffID)
        {
            string Surname = "";
            dbCommand = new SqlCommand("sp_GetStaffSurname", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@StaffID", StaffID);
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            dbCommand.ExecuteNonQuery();
            dbAdapter.Fill(dt);
            dr = dbCommand.ExecuteReader();
            while (dr.Read())
            {
                Surname = Convert.ToString(dr[0]);
            }
            dbConnection.Close();
            return Surname;
        }

        public string getStaffFirstName(string StaffID)
        {
            string Name = "";
            dbCommand = new SqlCommand("sp_GetStaffFirstName", dbConnection);
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.Parameters.AddWithValue("@StaffID", StaffID);
            dbAdapter = new SqlDataAdapter(dbCommand);

            if (dbConnection.State == ConnectionState.Closed)
                dbConnection.Open();

            dbCommand.ExecuteNonQuery();
            dbAdapter.Fill(dt);
            dr = dbCommand.ExecuteReader();
            while (dr.Read())
            {
                Name = Convert.ToString(dr[0]);
            }
            dbConnection.Close();
            return Name;
        }
    }
}
