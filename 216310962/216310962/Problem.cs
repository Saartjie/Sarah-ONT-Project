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
            DataAccessLayer dat = new DataAccessLayer();
            DT = dat.getAllProblems();
            return DT;
        }

        public DataTable GetProblemWithStatus(string status)
        {
            DataAccessLayer dat = new DataAccessLayer();
            DT = dat.getProblemWithStatus(status);
            return DT;
        }


        public void InsertIntoProblem(DateTime ProblemDateTime, int ProblemPriority, string ReportingUser, string StaffID, string MachineID, string CurrentDirectory, string ProblemComment, string ProblemCategory, string LogicalDrives, string ProblemStatus)
        {
            DataAccessLayer dat = new DataAccessLayer();
            dat.insertIntoProblem(ProblemDateTime, ProblemPriority, ReportingUser, StaffID, MachineID, CurrentDirectory, ProblemComment, ProblemCategory, LogicalDrives, ProblemStatus);
        }

        public void AllocateStaff(int ProblemID, string StaffID)
        {
            DataAccessLayer dat = new DataAccessLayer();
            dat.allocateStaff(ProblemID, StaffID);
        }

        public int[] GetAllProblemIDs(int num)
        {
            DataAccessLayer dat = new DataAccessLayer();
            int[] ProblemID = new int[num];
            ProblemID = dat.getAllProblemIDs(num);
            return ProblemID;
        }

        public DataTable FilterHighPriority()
        {
            DataAccessLayer dat = new DataAccessLayer();
            DT = dat.filterHighPriority();
            return DT;
        }

        public DataTable FilterByDate(DateTime from, DateTime to)
        {
            DataAccessLayer dat = new DataAccessLayer();
            DT = dat.filterByDate(from, to);
            return DT;
        }

        public DataTable FilterByCategory(string category)
        {
            DataAccessLayer dat = new DataAccessLayer();
            DT = dat.filterByCategory(category);
            return DT;
        }

        public DataTable FilterByStaffID(string staffID)
        {
            DataAccessLayer dat = new DataAccessLayer();
            DT = dat.filterByStaffID(staffID);
            return DT;
        }

        public DataTable FilterByMachineID(string machineID)
        {
            DataAccessLayer dat = new DataAccessLayer();
            DT = dat.filterByMachineID(machineID);
            return DT;
        }

        public string GetProblemStatus(int ProblemID)
        {
            DataAccessLayer dat = new DataAccessLayer();
            string status;
            status = dat.getProblemStatus(ProblemID);
            return status;
        }

        public void UpdateProblem(int ProblemID, DateTime UpdateTime, int ProblemPriority, string CategoryID)
        {
            DataAccessLayer dat = new DataAccessLayer();
            dat.updateProblem(ProblemID, UpdateTime, ProblemPriority, CategoryID);
        }
    }
}