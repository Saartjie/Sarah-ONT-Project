using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProblemProject
{
    class Staff
    {
        public DataTable DT;
        public DataTable GetStaffProblems()
        {
            DataAccessLayer dat = new DataAccessLayer();
            DT = dat.getStaff();
            return DT;
        }
        public string GetStaffRole(string Username)
        {
            DataAccessLayer dat = new DataAccessLayer();
            string StaffRole = dat.getStaffRole(Username);
            return StaffRole;
        }

        public string GetStaffID(string username)
        {
            string StaffID;
            DataAccessLayer dat = new DataAccessLayer();
            StaffID = dat.getStaffID(username);
            return StaffID;
        }

        public int GetNumStaff()
        {
            int num;
            DataAccessLayer dat = new DataAccessLayer();
            num = dat.getNumStaff();
            return num;
        }

        public string GetStaffPass(string username)
        {
            string StaffPass;
            DataAccessLayer dat = new DataAccessLayer();
            StaffPass = dat.getStaffPass(username);
            return StaffPass;
        }
    }
}
