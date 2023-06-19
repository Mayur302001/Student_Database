using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STUDENT_DATABASE
{
   
    public partial class Departments : Form
    {
        Functions con;
        public Departments()
        {
            InitializeComponent();
            con = new Functions();
            ShowDepartments();
           
        }
        private void ShowDepartments()
        {
            string Query = "select * from DepartmentTbl";
            DepartmentsList.DataSource = con.GetData(Query);

        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (DepNameTb.Text == "" || DetailsTb.Text == "")
            {
                MessageBox.Show("Missing Data !!!");
            }
            else
            {
                try
                {
                    string DName = DepNameTb.Text;
                    string Details = DetailsTb.Text;
                    string Query = "insert into DepartmentTbl values('{0}','{1}')";
                    Query = string.Format(Query, DName, Details);
                    con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Added !!!");
                    Clear();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
            
        }
        int Key = 0;
        private void DepartmentsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DepNameTb.Text = DepartmentsList.SelectedRows[0].Cells[1].Value.ToString();
            DetailsTb.Text = DepartmentsList.SelectedRows[0].Cells[2].Value.ToString();
            
            if(DepNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(DepartmentsList.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (DepNameTb.Text == "" || DetailsTb.Text == "")
            {
                MessageBox.Show("Missing Data !!!");
            }
            else
            {
                try
                {
                    string DName = DepNameTb.Text;
                    string Details = DetailsTb.Text;
                    string Query = "Update DepartmentTbl set DepName = '{0}',DepDetails = '{1}' where DepId ={2}";
                    Query = string.Format(Query, DName, Details,Key);
                    con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Updated !!!");
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Clear()
        {
            DepNameTb.Text = "";
            DetailsTb.Text = "";
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select a Department");
            }
            else
            {
                try
                {
                    string DName = DepNameTb.Text;
                    string Details = DetailsTb.Text;
                    string Query = "Delete from DepartmentTbl where DepId ={0}";
                    Query = string.Format(Query, Key);
                    con.SetData(Query);
                    ShowDepartments();
                    MessageBox.Show("Department Deleted !!!");
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void LogoutLbl_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Close();
        }

        private void StudentLbl_Click(object sender, EventArgs e)
        {
            Student Obj = new Student();
            Obj.Show();
            this.Close();
        }

        private void DashboardLbl_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Close();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
