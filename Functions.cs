using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUDENT_DATABASE
{
    class Functions
    {
        private SqlConnection con;
        private SqlCommand Cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConStr;
        public Functions()
        {
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MAYUR\Documents\StudentDBC#.mdf;Integrated Security=True;Connect Timeout=30";
            con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = con;
        }
        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, ConStr);
            sda.Fill(dt);
            return dt;
        }
        public int SetData(string Query)
        {
            int Cnt = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            Cmd.CommandText = Query;
            Cnt = Cmd.ExecuteNonQuery();

            return Cnt;
        }





    }
}
