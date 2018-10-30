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
    public partial class EnrollmentForm : Form
    {
        public EnrollmentForm()
        {
            InitializeComponent();
        }

        List<int> empIdList = new List<int>();
        private void EnrollmentForm_Load_1(object sender, EventArgs e)
        {
            int empId;


            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"server=10.10.14.56\MSSQLSERVER,1433; database=DSMS;uid=sa;pwd=1";
            con.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = $"select employeeid from employee";
            command.CommandType = CommandType.Text;
            command.Connection = con;

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                empId = reader.GetInt32(0);
                empIdList.Add(empId);
            }
            reader.Close();
            con.Close();
        }
        
        private void buttonCheckOverlap_Click_1(object sender, EventArgs e)
        {
            OverlapChecker();
        }

        //등록하기 버튼 누르면 동작
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!LoginInfo.checkId)
            {
                MessageBox.Show("사원번호 중복 확인을 해주세요.");
            }
            else
            {
                if (textBoxPw.Text != textBoxPwCheck.Text)
                {
                    MessageBox.Show("비밀번호가 서로 일치하지 않습니다.");
                }
                else
                {
                    if (textBoxName.Text != null && textBoxRank.Text != null && textBoxEmail.Text != null)
                    {
                        ConnectAndInsert();
                        MessageBox.Show($"{textBoxName.Text}님의 계정이 등록되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("미입력된 항목이 있습니다.");
                    }
                }
            }
        }


        private void ConnectAndInsert()
        {
            SqlConnection con = new SqlConnection();
            //Data Source=10.10.14.56;Initial Catalog=DSMS;Integrated Security=True
            //                ConnectionStringCreator creator = new MysqlConnectionStringCreator();
            //                creator.IP = "10.10.14.56";
            //                creator.Database = "DSMS";
            //                creator.Uid = "sa";
            //                creator.Pwd = "1";

            //이거로 됨
            //con.ConnectionString = "Data Source=10.10.14.56;Initial Catalog=DSMS;Integrated Security=True";
            con.ConnectionString = @"server=10.10.14.56\MSSQLSERVER,1433; database=DSMS;uid=sa;pwd=1";
            con.Open();

            SqlCommand command = CreateCommand("INSERT INTO Employee VALUES (@EmployeeId, @Password, @Name, @Rank, @IsAdmin, @Email)", con);

            SqlParameter parameter = new SqlParameter("@EmployeeId", SqlDbType.NVarChar);
            parameter.Value = textBoxID.Text;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@Password", SqlDbType.NVarChar);
            parameter.Value = textBoxPw.Text;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@Name", SqlDbType.NVarChar);
            parameter.Value = textBoxName.Text;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@Rank", SqlDbType.NVarChar);
            parameter.Value = textBoxRank.Text;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@IsAdmin", SqlDbType.Bit);
            parameter.Value = checkBoxIsAdmin.CheckState;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter("@Email", SqlDbType.NVarChar);
            parameter.Value = textBoxEmail.Text;
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();

            con.Close();
        }
        SqlCommand CreateCommand(string commandText, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = commandText;
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            return command;
        }
        private bool OverlapChecker()
        {
            if (textBoxID.Text == null)
            {
                MessageBox.Show("사원번호를 입력해주세요.");
                return LoginInfo.checkId = false;
            }
            else if (empIdList.Contains(int.Parse(textBoxID.Text)))
            {
                MessageBox.Show("이미 등록된 사원번호입니다.");
                return LoginInfo.checkId = false;
            }
            else
            {
                MessageBox.Show("등록을 진행하세요.");
                return LoginInfo.checkId = true;
            }

        }



    }
}
