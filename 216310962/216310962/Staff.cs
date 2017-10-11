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
        public DataTable GetAllProblems()
        {
            DataAccessLayer dat = new DataAccessLayer();
            DT = dat.getAllStaff();
            return DT;
        }
        public string[] GetStaffUserNames(int staffNum)
        {
            string[] staff = new string[4];
            DataAccessLayer dat = new DataAccessLayer();
            staff = dat.getAllStaffUserNames(staffNum);
            return staff;
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

        public void AddStaffMember(string Surname, string Name, string StaffRole, string Username, string Password)
        {
            DataAccessLayer dat = new DataAccessLayer();
            dat.addStaffMember(Surname, Name, StaffRole, Username, Password);
        }

        public int Exists(string username)
        {
            DataAccessLayer dat = new DataAccessLayer();
            int exists;
            exists = dat.staffExists(username);
            return exists;
        }

        public void RemoveStaffMember(string StaffID)
        {
            DataAccessLayer dat = new DataAccessLayer();
            dat.removeStaffMember(StaffID);
        }

        public DataTable ViewStaff()
        {
            DataAccessLayer dat = new DataAccessLayer();
            DT = dat.viewStaff();
            return DT;
        }

        public void UpdateStaffRole(string StaffID, string StaffRole)
        {
            DataAccessLayer dat = new DataAccessLayer();
            dat.updateStaffRole(StaffID, StaffRole);
        }

        public void UpdateStaffUsername(string StaffID, string Username)
        {
            DataAccessLayer dat = new DataAccessLayer();
            dat.updateStaffUsername(StaffID, Username);
        }
        public void UpdateStaffPass(string StaffID, string Username)
        {
            DataAccessLayer dat = new DataAccessLayer();
            dat.updateStaffPass(StaffID, Username);
        }
        public string GetStaffSurname(string StaffID)
        {
            string Surname;
            DataAccessLayer dat = new DataAccessLayer();
            Surname = dat.getStaffSurname(StaffID);
            return Surname;
        }

        public string GetStaffFirstName(string StaffID)
        {
            string FirstName;
            DataAccessLayer dat = new DataAccessLayer();
            FirstName = dat.getStaffFirstName(StaffID);
            return FirstName;
        }
    }
}
