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
    public partial class AddScheduleForm : Form
    {
        public AddScheduleForm()
        {
            InitializeComponent();
        }

        List<string[]> empLists = new List<string[]>();
        private void AddScheduleForm_Load_1(object sender, EventArgs e)
        {
            //폼이 로드될 때
            string empName, empRank, empId;
            bool isAdmin;

            int row = 0;

            listBoxShowEmpID.SelectionMode = SelectionMode.MultiExtended;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"server=10.10.14.56\MSSQLSERVER,1433; database=DSMS;uid=sa;pwd=1";
            con.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = $"select isAdmin from employee where employeeid = '{LoginInfo.loginId}'";
            command.CommandType = CommandType.Text;
            command.Connection = con;

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            bool check = reader.GetBoolean(0);
            reader.Close();
            //isAdmin 체크해서 false면 본인만 보이기
            if (!check)
            {
                command = new SqlCommand();
                command.CommandText = $"select Name, Rank, employeeid from Employee where employeeid = '{LoginInfo.loginId}'";
                command.CommandType = CommandType.Text;
                command.Connection = con;
                SqlDataReader multiReader = command.ExecuteReader();
                multiReader.Read();

                empName = multiReader.GetString(0);
                empRank = multiReader.GetString(1);
                empId = multiReader.GetInt32(2).ToString();
                //bool 넣어야함

                empLists.Add(new string[] { empName, empRank, empId });
                listBoxShowEmpID.Items.Add($"{empLists[0][0]} {empLists[0][1]} / {empLists[0][2]}");
                con.Close();
                multiReader.Close();
            }
            else
            {
                //isAdmin 체크해서 true면 모든 사원 보이기
                reader.Close();
                command = new SqlCommand();
                command.CommandText = "select Name, Rank, employeeid from Employee";
                command.CommandType = CommandType.Text;
                command.Connection = con;

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    empName = reader.GetString(0);
                    empRank = reader.GetString(1);
                    empId = reader.GetInt32(2).ToString();

                    empLists.Add(new string[] { empName, empRank, empId });
                    listBoxShowEmpID.Items.Add($"{empLists[row][0]} {empLists[row][1]} / {empLists[row][2]}");
                    row++;
                }
                reader.Close();
                con.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //추가하기 버튼 클릭 시 동작
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"server=10.10.14.56\MSSQLSERVER,1433; database=DSMS;uid=sa;pwd=1";
            con.Open();

            //선택한 수만큼 DB에 저장시킴
            for (int i = 0; i < listBoxShowEmpID.SelectedIndices.Count; i++)
            {
                SqlCommand command =
                    CreateCommand(
                        "INSERT INTO Schedule VALUES (@EmployeeId, @StartDate, @EndDate, @Summary, @Description)",
                        con);

                SqlParameter parameter = new SqlParameter("@EmployeeId", SqlDbType.NVarChar);
                int index = listBoxShowEmpID.SelectedIndices[i];
                parameter.Value = empLists[index][2];
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@StartDate", SqlDbType.Date);
                parameter.Value = dtpStart.Value.Date.ToShortDateString();
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@EndDate", SqlDbType.Date);
                parameter.Value = dtpEnd.Value.Date.ToShortDateString();
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@Summary", SqlDbType.NVarChar);
                parameter.Value = textBoxSumm.Text;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@Description", SqlDbType.NVarChar);
                parameter.Value = textBoxDesc.Text;
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }

            MessageBox.Show("일정이 추가되었습니다.");
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
        

    }
}
