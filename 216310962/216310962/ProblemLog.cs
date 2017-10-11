using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProblemProject
{
    class ProblemLog
    {

        private DataTable DT { get; set; }

        public DataTable GetProblemLog(int ProblemID)
        {
                    DataAccessLayer dat = new DataAccessLayer();
        DT = dat.getProblemLog(ProblemID);
            return DT;
        }

        public void InsertIntoProblemLog(int ProblemID, DateTime LogDateTime, string LogStaffID, string SolutionLogComment)
        {
            DataAccessLayer dat = new DataAccessLayer();

            dat.insertIntoProblemLog(ProblemID, LogDateTime, LogStaffID, SolutionLogComment); 
        }

        public int[] GetAllAssignedProblems(int num, string StaffID)
        {
            DataAccessLayer dat = new DataAccessLayer();

            int[] ProblemID = new int[num];
            ProblemID = dat.getAllAssignedProblems(num, StaffID);
            return ProblemID;
        }

        public DataTable GetAllAssignedProblems(string StaffID)
        {
            DataAccessLayer dat = new DataAccessLayer();

            DT = dat.getAllAssignedProblems(StaffID);
            return DT;
        }

        public void UpdateProblemStatus(int ProblemID, string status)
        {
            DataAccessLayer dat = new DataAccessLayer();

            dat.updateProblemStatus(ProblemID, status);
        }
    }
}
