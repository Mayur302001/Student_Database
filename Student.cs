using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace STUDENT_DATABASE
{
    public partial class Student : Form
    {
        Functions con;
        public Student()
        {
            InitializeComponent();
            con = new Functions();
            ShowStudents();
            GetDepartment();
        }
        private void ShowStudents()
        {
            string Query = "select * from StudentTbl";
            StudentList.DataSource = con.GetData(Query);
        }
        private void GetDepartment()
        {
            string Query = "select * from DepartmentTbl";
            DepCb.DisplayMember = con.GetData(Query).Columns["DepName"].ToString();
            DepCb.ValueMember = con.GetData(Query).Columns["DepId"].ToString();
            DepCb.DataSource = con.GetData(Query);
        }
        private void Clear()
        {
            StNameTb.Text = "";
            StPhoneTb.Text = "";
            StParentTb.Text = "";
            StAddTb.Text = "";
            GenCb.SelectedIndex = -1;

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (StNameTb.Text == "" || StPhoneTb.Text == "" ||StParentTb.Text == "" ||StAddTb.Text =="" ||DepCb.SelectedIndex == -1 || GenCb.SelectedIndex == -1 )
            {
                MessageBox.Show("Missing Data !!!");
            }
            else
            {
                try
                {
                    string TName = StNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone= StPhoneTb.Text;
                    string Parent = StParentTb.Text;
                    string Address = StAddTb.Text;

                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());

                    string Query = "insert into StudentTbl values('{0}','{1}','{2}','{3}','{4}',{5})";
                    string Query1 = string.Format(Query, TName, Gender, Phone, Parent, Address, Dep);
                    con.SetData(Query1);
                    ShowStudents();
                    MessageBox.Show("Student Added !!!");
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void StudentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            StNameTb.Text = StudentList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.SelectedItem = StudentList.SelectedRows[0].Cells[2].Value.ToString();
            StPhoneTb.Text = StudentList.SelectedRows[0].Cells[3].Value.ToString();
            StParentTb.Text = StudentList.SelectedRows[0].Cells[4].Value.ToString();
            StAddTb.Text = StudentList.SelectedRows[0].Cells[5].Value.ToString();
            DepCb.SelectedValue = StudentList.SelectedRows[0].Cells[6].Value.ToString();
         

            if (StNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(StudentList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (StNameTb.Text == "" || StPhoneTb.Text == "" || StParentTb.Text == "" || StAddTb.Text == "" || DepCb.SelectedIndex == -1 || GenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data !!!");
            }
            else
            {
                try
                {
                    string TName = StNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string phone = StPhoneTb.Text;
                    string Parent = StParentTb.Text;
                    string Address = StAddTb.Text;

                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());

                    string Query = "Update StudentTbl set StName = '{0}',StGen = '{1}',StPhone = '{2}',StParent = '{3}',StAdd = '{4}',StDepartment = {5} where StCode = {6}";
                    string Query1 = string.Format(Query, TName, Gender, phone, Parent, Address,Dep,Key);
                    con.SetData(Query1);
                    ShowStudents();
                    MessageBox.Show("Student Updated !!!");
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Missing Data !!!");
            }
            else
            {
                try
                {
                    string TName = StNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string phone = StPhoneTb.Text;
                    string Parent = StParentTb.Text;
                    string Address = StAddTb.Text;

                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());

                    string Query = "Delete from StudentTbl where StCode = '{0}'";
                    string Query1 = string.Format(Query, Key);
                    con.SetData(Query1);
                    ShowStudents();
                    MessageBox.Show("Student Data Deleted !!!");
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DepLbl_Click(object sender, EventArgs e)
        {
            Departments Obj = new Departments();
            Obj.Show();
            this.Close();
        }

        private void DashboardLbl_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
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

    }
}
