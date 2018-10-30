namespace ReflectionDemo
{
    partial class DeleteScheduleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDelete = new System.Windows.Forms.Button();
            this.listBoxShowSchedule = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(122, 203);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(119, 46);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "삭제하기";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click_1);
            // 
            // listBoxShowSchedule
            // 
            this.listBoxShowSchedule.FormattingEnabled = true;
            this.listBoxShowSchedule.ItemHeight = 15;
            this.listBoxShowSchedule.Location = new System.Drawing.Point(48, 26);
            this.listBoxShowSchedule.Name = "listBoxShowSchedule";
            this.listBoxShowSchedule.Size = new System.Drawing.Size(280, 154);
            this.listBoxShowSchedule.TabIndex = 2;
            // 
            // DeleteScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 275);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.listBoxShowSchedule);
            this.Name = "DeleteScheduleForm";
            this.Text = "DeleteScheduleForm";
            this.Load += new System.EventHandler(this.DeleteScheduleForm_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ListBox listBoxShowSchedule;
    }
}