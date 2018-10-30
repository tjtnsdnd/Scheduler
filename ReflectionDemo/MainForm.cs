using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReflectionDemo.Data;
using ReflectionDemo.Data.Data;

namespace ReflectionDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            DSMSEntities entities = new DSMSEntities();

            gridRowBindingSource.DataSource = DataRepository.Schedule.ConvertToGridRows(DateTime.Now);
            foreach (var item in DataRepository.Schedule.GetColorChangeInfos())
            {
                dgvSchedule.Rows[item.row].Cells[item.column + 1].Style.BackColor = Color.MediumSeaGreen;
            }
        }

        private void buttonAddSchedule_Click(object sender, EventArgs e)
        {
            AddScheduleForm addScheduleForm = new AddScheduleForm();
            addScheduleForm.Show();
        }

        private void buttonDeleteSchedule_Click(object sender, EventArgs e)
        {
            //-----------삭제버튼-----------
            DeleteScheduleForm deleteScheduleForm = new DeleteScheduleForm();
            deleteScheduleForm.Show();
        }

        private void buttonEMail_Click(object sender, EventArgs e)
        {
            SendEMailForm sendEMailForm = new SendEMailForm();
            sendEMailForm.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
