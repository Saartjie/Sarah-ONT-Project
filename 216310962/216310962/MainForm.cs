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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string tempPass = "";
            Staff staff = new Staff();
            //try
            //{
                tempPass = staff.GetStaffPass(username);
            //}
            //catch
            //{
            //    MessageBox.Show("Username does not exist.");
            //}
            if (tempPass == password)
            {
                if ((staff.GetStaffRole(username) == "Staff"))
                {
                    ProblemStaff frmStaff = new ProblemStaff();
                    frmStaff.ShowDialog();
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                    this.ActiveControl = txtUsername;
                }
                else if ((staff.GetStaffRole(username) == "Lab Manager"))
                {
                    ProblemLabManager frmLabMang = new ProblemLabManager();
                    frmLabMang.ShowDialog();
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                    this.ActiveControl = txtUsername;
                }
                else
                {
                    MessageBox.Show("Invalid Login");
                }
            }
            else
            {
                MessageBox.Show("Incorrect Username Or Password!");
            }

        }

        private void btnReportProblem_Click(object sender, EventArgs e)
        {
            Report frmReport = new Report();
            frmReport.ShowDialog();
        }
    }
}
