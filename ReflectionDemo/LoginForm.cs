using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReflectionDemo
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();

            con.ConnectionString = @"server=10.10.14.56\MSSQLSERVER,1433; database=DSMS;uid=sa;pwd=1";
            con.Open();

            SqlCommand command = new SqlCommand();

            command.CommandText = $"select Password from Employee where EmployeeId = '{textBoxID.Text}'";
            //command.CommandText = "select * from employee";

            command.CommandType = CommandType.Text;
            command.Connection = con;


            SqlDataReader reader = command.ExecuteReader();
            //테스트
            //            string pwd = reader.GetString(1);
            //            MessageBox.Show(pwd);

            //            if (!reader.Read())
            //            {
            //                MessageBox.Show("사원번호가 등록되어있지 않습니다.");
            //            }

            while (reader.Read())
            {
                string pwd = reader.GetString(0);

                if (!textBoxPwd.Text.Equals(pwd))
                {
                    MessageBox.Show("등록되지 않은 사용자 이거나 비밀번호가 틀렸습니다.");
                    break;
                }
                else
                {
                    LoginInfo.loginId = textBoxID.Text;
                    this.Hide();
                    MainForm mainForm1 = new MainForm();
                    mainForm1.Show();

                }
            }
            reader.Close();
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            EnrollmentForm enrollmentForm = new EnrollmentForm();
            enrollmentForm.Show();
        }
    }
}
