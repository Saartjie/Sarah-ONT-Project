using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProblemProject
{
    class Problem
    {
        private DataTable DT { get; set; }

        public DataTable GetAllProblems()
        {
            DataAccessLayer dal = new DataAccessLayer();
            DT = dal.getAllProblems();
            return DT;
        }

        public DataTable GetProblemWithStatus(string status)
        {
            DataAccessLayer dal = new DataAccessLayer();
            DT = dal.getProblemWithStatus(status);
            return DT;
        }


        public void AddProblem(DateTime ProblemDateTime, int ProblemPriority, string ReportingUser, string StaffID, string MachineID, string CurrentDirectory, string ProblemComment, string ProblemCategory, string LogicalDrives, string ProblemStatus)
        {
            DataAccessLayer dal = new DataAccessLayer();
            dal.insertIntoProblem(ProblemDateTime, ProblemPriority, ReportingUser, StaffID, MachineID, CurrentDirectory, ProblemComment, ProblemCategory, LogicalDrives, ProblemStatus);
        }

        public void AllocateStaff(int ProblemID, string StaffID)
        {
            DataAccessLayer dal = new DataAccessLayer();
            dal.allocateStaff(ProblemID, StaffID);
        }

        public DataTable SortHighPriority()
        {
            DataAccessLayer dal = new DataAccessLayer();
            DT = dal.sortHighPriority();
            return DT;
        }

        public DataTable SortByDate(DateTime from, DateTime to)
        {
            DataAccessLayer dal = new DataAccessLayer();
            DT = dal.sortByDate(from, to);
            return DT;
        }

        public DataTable SortByCategory(string category)
        {
            DataAccessLayer dal = new DataAccessLayer();
            DT = dal.sortByCategory(category);
            return DT;
        }

        public DataTable SortByStaffID(string staffID)
        {
            DataAccessLayer dal = new DataAccessLayer();
            DT = dal.sortByStaffID(staffID);
            return DT;
        }

        public DataTable SortByMachineID(string machineID)
        {
            DataAccessLayer dal = new DataAccessLayer();
            DT = dal.sortByMachineID(machineID);
            return DT;
        }

        public string GetProblemStatus(int ProblemID)
        {
            DataAccessLayer dal = new DataAccessLayer();
            string status = dal.getProblemStatus(ProblemID);
            return status;
        }
    }
}