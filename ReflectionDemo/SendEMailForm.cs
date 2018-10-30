using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using S22.Imap;

namespace ReflectionDemo
{
    public partial class SendEMailForm : Form
    {
        List<string[]> empEmailLists = new List<string[]>();
        List<string> emailList = new List<string>();
        private static SendEMailForm sendEMailForm;
        public SendEMailForm()
        {
            InitializeComponent();
            sendEMailForm = this;
        }

        private void SendEMailForm_Load_1(object sender, EventArgs e)
        {
            listBoxEmailList.SelectionMode = SelectionMode.MultiExtended;

            string empName, empRank, empEmail;
            int row = 0;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"server=10.10.14.56\MSSQLSERVER,1433; database=DSMS;uid=sa;pwd=1";
            con.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = $"select name, rank, email from employee";
            command.CommandType = CommandType.Text;
            command.Connection = con;

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                empName = reader.GetString(0);
                empRank = reader.GetString(1);
                empEmail = reader.GetString(2);
                empEmailLists.Add(new string[] { empName, empRank, empEmail });
                listBoxEmailList.Items.Add($"{empEmailLists[row][0]} {empEmailLists[row][1]} / {empEmailLists[row][2]}");
                row++;
            }
            reader.Close();
            con.Close();
        }

        private void buttonSend_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxEmailList.SelectedIndices.Count; i++)
            {
                int index = listBoxEmailList.SelectedIndices[i];
                emailList.Add(empEmailLists[index][2]);

                var message = new MailMessage(textBoxAddr.Text, emailList[i]);
                message.Subject = textBoxTitle.Text;
                message.Body = textBoxContent.Text;

                using (SmtpClient mailer = new SmtpClient("smtp.gmail.com", 587))
                {
                    mailer.Credentials = new NetworkCredential(textBoxAddr.Text, textBoxPw.Text);
                    mailer.EnableSsl = true;
                    mailer.Send(message);
                }
            }
            textBoxTitle.Text = null;
            textBoxContent.Text = null;
            connectedEmail = null;
            MessageBox.Show("메일을 발송했습니다.");


            /* 한번에 여러명에게 메일보내기 실패................

            for (int i = 0; i < listBoxEmailList.SelectedIndices.Count; i++)
            {
                int index = listBoxEmailList.SelectedIndices[i];
                emailList.Add(empEmailLists[index][2]);
            }

            
            for (int i = 0; i < emailList.Count; i++)
            {
                connectedEmail = connectedEmail + $"{emailList[i]} ";
            }
            var message = new MailMessage(textBoxAddr.Text, connectedEmail);
            message.Subject = textBoxTitle.Text;
            message.Body = textBoxContent.Text;

            using (SmtpClient mailer = new SmtpClient("smtp.gmail.com", 587))
            {
                mailer.Credentials = new NetworkCredential(textBoxAddr.Text, textBoxPw.Text);
                mailer.EnableSsl = true;
                mailer.Send(message);
            }


            textBoxTitle.Text = null;
            textBoxContent.Text = null;
            connectedEmail = null;
            MessageBox.Show("메일을 발송했습니다.");
            */

            //
            //            string connectedEmail = null;
            //            for (int i = 0; i < emailList.Count; i++)
            //            {
            //                connectedEmail = connectedEmail + $"{emailList[i]} ";
            //            }

            //            MessageBox.Show(connectedEmail);

        }

       
        string connectedEmail = null;
        
        /*
        private void StartReceiving()
        {
            Task.Run(() =>
            {
                using (ImapClient client = new ImapClient("imap.gmail.com", 993, textBoxAddr.Text, textBoxPw.Text,
                    AuthMethod.Login, true))
                {
                    if (client.Supports("IDLE") == false)
                    {
                        MessageBox.Show("실패");
                        return;
                    }

                    client.NewMessage += new EventHandler<IdleMessageEventArgs>(OnNewMessage);
                }
            });
        }

        private void OnNewMessage(object sender, IdleMessageEventArgs e)
        {
            MessageBox.Show("새로운 메세지를 받았습니다.");
            MailMessage m = e.Client.GetMessage(e.MessageUID, FetchOptions.Normal);
            sendEMailForm.Invoke((MethodInvoker) delegate
            {
                sendEMailForm.textBoxRe.AppendText("보낸이 : " + m.From + "\n" +
                                                   "제  목 : " + m.Subject + "\n" +
                                                   "내  용 : " + m.Body + "\n");
            });
        }
        */

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
