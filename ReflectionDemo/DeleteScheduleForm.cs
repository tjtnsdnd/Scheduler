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
    public partial class DeleteScheduleForm : Form
    {
        public DeleteScheduleForm()
        {
            InitializeComponent();
        }

        List<string[]> schedules = new List<string[]>();
        private void DeleteScheduleForm_Load_1(object sender, EventArgs e)
        {
            //폼이 로드될 때

            listBoxShowSchedule.SelectionMode = SelectionMode.MultiExtended;
            ShowScheduleList();
        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            //삭제하기 버튼 클릭 시 schdule 테이블에서 삭제
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"server=10.10.14.56\MSSQLSERVER,1433; database=DSMS;uid=sa;pwd=1";
            con.Open();

            //선택한 수만큼 DB에서 삭제시킴
            for (int i = 0; i < listBoxShowSchedule.SelectedIndices.Count; i++)
            {
                SqlCommand command =
                    CreateCommand(
                        @"delete from schedule where ScheduleId = @ScheduleId",
                        con);
                SqlParameter parameter = new SqlParameter("@ScheduleId", SqlDbType.Int);
                int index = listBoxShowSchedule.SelectedIndices[i];
                parameter.Value = int.Parse(schedules[index][2]);
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
            MessageBox.Show("일정이 삭제되었습니다.");

            con.Close();
            //listBoxShowSchedule.Items.RemoveAt(listBoxShowSchedule.SelectedIndex);
            ListBox.SelectedIndexCollection indexCollection = listBoxShowSchedule.SelectedIndices;
            List<int> indexList = new List<int>();
            foreach (var index in indexCollection)
            {
                indexList.Add(int.Parse(index.ToString()));
            }
            indexList.Sort((a, b) => a > b ? -1 : 1);

            foreach (int i in indexList)
            {
                listBoxShowSchedule.Items.RemoveAt(i);
            }
        }
        
        SqlCommand CreateCommand(string commandText, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = commandText;
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            return command;
        }

        private void DeleteAllItems()
        {

        }
        private void ShowScheduleList()
        {
            string scdSummary, scdStartDate, scdId;
            int row = 0;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"server=10.10.14.56\MSSQLSERVER,1433; database=DSMS;uid=sa;pwd=1";
            con.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = $"select summary, startdate, scheduleid from schedule where employeeid = '{LoginInfo.loginId}'";
            command.CommandType = CommandType.Text;
            command.Connection = con;

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                scdSummary = reader.GetString(0);
                scdStartDate = reader.GetDateTime(1).ToShortDateString();
                scdId = reader.GetInt32(2).ToString();
                schedules.Add(new string[] { scdSummary, scdStartDate, scdId });
                listBoxShowSchedule.Items.Add($"{schedules[row][0]} / {schedules[row][1]}");
                row++;
            }
            reader.Close();
            con.Close();
        }

    }
}
