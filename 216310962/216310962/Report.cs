using ProblemProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _216310962
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Problem problem = new Problem();
            DateTime ProblemDateTime = DateTime.Now;
            int ProblemPriority = int.Parse(comboBox1.Text);
            string ReportingUser = Environment.UserName.ToString();
            string StaffID = "";
            string MachineID = Environment.MachineName.ToString();
            String CurrentDirectory = Environment.CurrentDirectory.ToString();
            string ProblemComment = textBox1.Text;
            string ProblemCategory = (string)comboBox2.SelectedValue;
            string[] Drives = new string[Environment.GetLogicalDrives().Length];
            string LogicalDrives = "";
            Drives = Environment.GetLogicalDrives();
            for(int x = 0; x < Drives.Length; x++)
            {
                LogicalDrives += Drives[x] = "";
            }
            string ProblemStatus = "Open";
            problem.InsertIntoProblem(ProblemDateTime,ProblemPriority,ReportingUser,StaffID,MachineID,CurrentDirectory,ProblemComment,ProblemCategory,LogicalDrives,ProblemStatus);
        }
    }
}
