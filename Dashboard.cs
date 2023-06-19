using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STUDENT_DATABASE
{
   
    public partial class Dashboard : Form
    {
        Functions con;
        public Dashboard()
        {
            InitializeComponent();
            con = new Functions();
            CountStudents();
            CountDepartments();
            CountMale();
            CountFemale();
        }
        private void CountStudents()
        {
            string Query = "select Count(*) as Stud from StudentTbl";
            foreach(DataRow dr in con.GetData(Query).Rows)
            {
                studentNumLbl.Text = dr["Stud"].ToString();
            }
        }
        private void CountDepartments()
        {
            string Query = "select Count(*) as Dep from DepartmentTbl";
            foreach (DataRow dr in con.GetData(Query).Rows)
            {
                DepNumLbl.Text = dr["Dep"].ToString();
            }
        }
        private void CountMale()
        {
            string Gen = "Male";
            string Query = "select Count(*) as Male from StudentTbl where StGen ='{0}'";
            Query = String.Format(Query, Gen);
            foreach (DataRow dr in con.GetData(Query).Rows)
            {
                MaleStdNumLbl.Text = dr["Male"].ToString();
            }
            

        }
        private void CountFemale()
        {
            string Gen = "Female";
            string Query = "select Count(*) as Female from StudentTbl where StGen ='{0}'";
            Query = String.Format(Query, Gen);
            foreach (DataRow dr in con.GetData(Query).Rows)
            {
                FemaleStdNumLbl.Text = dr["Female"].ToString();
            }


        }

        private void DepartmentLbl_Click(object sender, EventArgs e)
        {
            Departments Obj = new Departments();
            Obj.Show();
            this.Close();
        }

      

        private void StudentLbl_Click(object sender, EventArgs e)
        {
            Student Obj = new Student();
            Obj.Show();
            this.Close();
        }

      

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Close();
        }

        

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MaleBtn_Click(object sender, EventArgs e)
        {
            Student Obj = new Student();
            Obj.Show();
            this.Close();
        }

        private void FemaleBtn_Click(object sender, EventArgs e)
        {
            Student Obj = new Student();
            Obj.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Departments Obj = new Departments();
            Obj.Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Student Obj = new Student();
            Obj.Show();
            this.Close();
        }
    }
}
