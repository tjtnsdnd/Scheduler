using ReflectionDemo.Data.Models;

namespace ReflectionDemo
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.buttonEMail = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonDeleteSchedule = new System.Windows.Forms.Button();
            this.buttonAddSchedule = new System.Windows.Forms.Button();
            this.gridRowBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rankDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d01DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d02DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d03DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d04DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d05DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d06DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d07DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d08DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d09DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d10DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d11DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d12DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d13DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d14DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d15DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d16DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d17DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d18DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d19DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d20DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d21DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d22DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d23DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d24DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d25DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d26DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d27DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d28DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d29DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d30DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d31DataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRowBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.dgvSchedule);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.buttonEMail);
            this.splitContainerControl1.Panel2.Controls.Add(this.buttonExit);
            this.splitContainerControl1.Panel2.Controls.Add(this.buttonDeleteSchedule);
            this.splitContainerControl1.Panel2.Controls.Add(this.buttonAddSchedule);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1054, 522);
            this.splitContainerControl1.SplitterPosition = 851;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AutoGenerateColumns = false;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.rankDataGridViewTextBoxColumn,
            this.d01DataGridViewCheckBoxColumn,
            this.d02DataGridViewCheckBoxColumn,
            this.d03DataGridViewCheckBoxColumn,
            this.d04DataGridViewCheckBoxColumn,
            this.d05DataGridViewCheckBoxColumn,
            this.d06DataGridViewCheckBoxColumn,
            this.d07DataGridViewCheckBoxColumn,
            this.d08DataGridViewCheckBoxColumn,
            this.d09DataGridViewCheckBoxColumn,
            this.d10DataGridViewCheckBoxColumn,
            this.d11DataGridViewCheckBoxColumn,
            this.d12DataGridViewCheckBoxColumn,
            this.d13DataGridViewCheckBoxColumn,
            this.d14DataGridViewCheckBoxColumn,
            this.d15DataGridViewCheckBoxColumn,
            this.d16DataGridViewCheckBoxColumn,
            this.d17DataGridViewCheckBoxColumn,
            this.d18DataGridViewCheckBoxColumn,
            this.d19DataGridViewCheckBoxColumn,
            this.d20DataGridViewCheckBoxColumn,
            this.d21DataGridViewCheckBoxColumn,
            this.d22DataGridViewCheckBoxColumn,
            this.d23DataGridViewCheckBoxColumn,
            this.d24DataGridViewCheckBoxColumn,
            this.d25DataGridViewCheckBoxColumn,
            this.d26DataGridViewCheckBoxColumn,
            this.d27DataGridViewCheckBoxColumn,
            this.d28DataGridViewCheckBoxColumn,
            this.d29DataGridViewCheckBoxColumn,
            this.d30DataGridViewCheckBoxColumn,
            this.d31DataGridViewCheckBoxColumn});
            this.dgvSchedule.DataSource = this.gridRowBindingSource;
            this.dgvSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSchedule.Location = new System.Drawing.Point(0, 0);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.RowTemplate.Height = 27;
            this.dgvSchedule.Size = new System.Drawing.Size(851, 522);
            this.dgvSchedule.TabIndex = 0;
            // 
            // buttonEMail
            // 
            this.buttonEMail.Location = new System.Drawing.Point(30, 215);
            this.buttonEMail.Name = "buttonEMail";
            this.buttonEMail.Size = new System.Drawing.Size(136, 55);
            this.buttonEMail.TabIndex = 30;
            this.buttonEMail.Text = "메일 쓰기";
            this.buttonEMail.UseVisualStyleBackColor = true;
            this.buttonEMail.Click += new System.EventHandler(this.buttonEMail_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(30, 437);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(136, 51);
            this.buttonExit.TabIndex = 29;
            this.buttonExit.Text = "닫기";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonDeleteSchedule
            // 
            this.buttonDeleteSchedule.Location = new System.Drawing.Point(30, 125);
            this.buttonDeleteSchedule.Name = "buttonDeleteSchedule";
            this.buttonDeleteSchedule.Size = new System.Drawing.Size(136, 53);
            this.buttonDeleteSchedule.TabIndex = 28;
            this.buttonDeleteSchedule.Text = "일정 삭제";
            this.buttonDeleteSchedule.UseVisualStyleBackColor = true;
            this.buttonDeleteSchedule.Click += new System.EventHandler(this.buttonDeleteSchedule_Click);
            // 
            // buttonAddSchedule
            // 
            this.buttonAddSchedule.Location = new System.Drawing.Point(30, 35);
            this.buttonAddSchedule.Name = "buttonAddSchedule";
            this.buttonAddSchedule.Size = new System.Drawing.Size(136, 56);
            this.buttonAddSchedule.TabIndex = 27;
            this.buttonAddSchedule.Text = "일정 추가";
            this.buttonAddSchedule.UseVisualStyleBackColor = true;
            this.buttonAddSchedule.Click += new System.EventHandler(this.buttonAddSchedule_Click);
            // 
            // gridRowBindingSource
            // 
            this.gridRowBindingSource.DataSource = typeof(ReflectionDemo.Data.Models.GridRow);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "이름";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 70;
            // 
            // rankDataGridViewTextBoxColumn
            // 
            this.rankDataGridViewTextBoxColumn.DataPropertyName = "Rank";
            this.rankDataGridViewTextBoxColumn.HeaderText = "직급";
            this.rankDataGridViewTextBoxColumn.Name = "rankDataGridViewTextBoxColumn";
            this.rankDataGridViewTextBoxColumn.Width = 70;
            // 
            // d01DataGridViewCheckBoxColumn
            // 
            this.d01DataGridViewCheckBoxColumn.DataPropertyName = "D01";
            this.d01DataGridViewCheckBoxColumn.HeaderText = "1일";
            this.d01DataGridViewCheckBoxColumn.Name = "d01DataGridViewCheckBoxColumn";
            this.d01DataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.d01DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d02DataGridViewCheckBoxColumn
            // 
            this.d02DataGridViewCheckBoxColumn.DataPropertyName = "D02";
            this.d02DataGridViewCheckBoxColumn.HeaderText = "2일";
            this.d02DataGridViewCheckBoxColumn.Name = "d02DataGridViewCheckBoxColumn";
            this.d02DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d03DataGridViewCheckBoxColumn
            // 
            this.d03DataGridViewCheckBoxColumn.DataPropertyName = "D03";
            this.d03DataGridViewCheckBoxColumn.HeaderText = "3일";
            this.d03DataGridViewCheckBoxColumn.Name = "d03DataGridViewCheckBoxColumn";
            this.d03DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d04DataGridViewCheckBoxColumn
            // 
            this.d04DataGridViewCheckBoxColumn.DataPropertyName = "D04";
            this.d04DataGridViewCheckBoxColumn.HeaderText = "4일";
            this.d04DataGridViewCheckBoxColumn.Name = "d04DataGridViewCheckBoxColumn";
            this.d04DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d05DataGridViewCheckBoxColumn
            // 
            this.d05DataGridViewCheckBoxColumn.DataPropertyName = "D05";
            this.d05DataGridViewCheckBoxColumn.HeaderText = "5일";
            this.d05DataGridViewCheckBoxColumn.Name = "d05DataGridViewCheckBoxColumn";
            this.d05DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d06DataGridViewCheckBoxColumn
            // 
            this.d06DataGridViewCheckBoxColumn.DataPropertyName = "D06";
            this.d06DataGridViewCheckBoxColumn.HeaderText = "6일";
            this.d06DataGridViewCheckBoxColumn.Name = "d06DataGridViewCheckBoxColumn";
            this.d06DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d07DataGridViewCheckBoxColumn
            // 
            this.d07DataGridViewCheckBoxColumn.DataPropertyName = "D07";
            this.d07DataGridViewCheckBoxColumn.HeaderText = "7일";
            this.d07DataGridViewCheckBoxColumn.Name = "d07DataGridViewCheckBoxColumn";
            this.d07DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d08DataGridViewCheckBoxColumn
            // 
            this.d08DataGridViewCheckBoxColumn.DataPropertyName = "D08";
            this.d08DataGridViewCheckBoxColumn.HeaderText = "8일";
            this.d08DataGridViewCheckBoxColumn.Name = "d08DataGridViewCheckBoxColumn";
            this.d08DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d09DataGridViewCheckBoxColumn
            // 
            this.d09DataGridViewCheckBoxColumn.DataPropertyName = "D09";
            this.d09DataGridViewCheckBoxColumn.HeaderText = "9일";
            this.d09DataGridViewCheckBoxColumn.Name = "d09DataGridViewCheckBoxColumn";
            this.d09DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d10DataGridViewCheckBoxColumn
            // 
            this.d10DataGridViewCheckBoxColumn.DataPropertyName = "D10";
            this.d10DataGridViewCheckBoxColumn.HeaderText = "10일";
            this.d10DataGridViewCheckBoxColumn.Name = "d10DataGridViewCheckBoxColumn";
            this.d10DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d11DataGridViewCheckBoxColumn
            // 
            this.d11DataGridViewCheckBoxColumn.DataPropertyName = "D11";
            this.d11DataGridViewCheckBoxColumn.HeaderText = "11일";
            this.d11DataGridViewCheckBoxColumn.Name = "d11DataGridViewCheckBoxColumn";
            this.d11DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d12DataGridViewCheckBoxColumn
            // 
            this.d12DataGridViewCheckBoxColumn.DataPropertyName = "D12";
            this.d12DataGridViewCheckBoxColumn.HeaderText = "12일";
            this.d12DataGridViewCheckBoxColumn.Name = "d12DataGridViewCheckBoxColumn";
            this.d12DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d13DataGridViewCheckBoxColumn
            // 
            this.d13DataGridViewCheckBoxColumn.DataPropertyName = "D13";
            this.d13DataGridViewCheckBoxColumn.HeaderText = "13일";
            this.d13DataGridViewCheckBoxColumn.Name = "d13DataGridViewCheckBoxColumn";
            this.d13DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d14DataGridViewCheckBoxColumn
            // 
            this.d14DataGridViewCheckBoxColumn.DataPropertyName = "D14";
            this.d14DataGridViewCheckBoxColumn.HeaderText = "14일";
            this.d14DataGridViewCheckBoxColumn.Name = "d14DataGridViewCheckBoxColumn";
            this.d14DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d15DataGridViewCheckBoxColumn
            // 
            this.d15DataGridViewCheckBoxColumn.DataPropertyName = "D15";
            this.d15DataGridViewCheckBoxColumn.HeaderText = "15일";
            this.d15DataGridViewCheckBoxColumn.Name = "d15DataGridViewCheckBoxColumn";
            this.d15DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d16DataGridViewCheckBoxColumn
            // 
            this.d16DataGridViewCheckBoxColumn.DataPropertyName = "D16";
            this.d16DataGridViewCheckBoxColumn.HeaderText = "16일";
            this.d16DataGridViewCheckBoxColumn.Name = "d16DataGridViewCheckBoxColumn";
            this.d16DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d17DataGridViewCheckBoxColumn
            // 
            this.d17DataGridViewCheckBoxColumn.DataPropertyName = "D17";
            this.d17DataGridViewCheckBoxColumn.HeaderText = "17일";
            this.d17DataGridViewCheckBoxColumn.Name = "d17DataGridViewCheckBoxColumn";
            this.d17DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d18DataGridViewCheckBoxColumn
            // 
            this.d18DataGridViewCheckBoxColumn.DataPropertyName = "D18";
            this.d18DataGridViewCheckBoxColumn.HeaderText = "18일";
            this.d18DataGridViewCheckBoxColumn.Name = "d18DataGridViewCheckBoxColumn";
            this.d18DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d19DataGridViewCheckBoxColumn
            // 
            this.d19DataGridViewCheckBoxColumn.DataPropertyName = "D19";
            this.d19DataGridViewCheckBoxColumn.HeaderText = "19일";
            this.d19DataGridViewCheckBoxColumn.Name = "d19DataGridViewCheckBoxColumn";
            this.d19DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d20DataGridViewCheckBoxColumn
            // 
            this.d20DataGridViewCheckBoxColumn.DataPropertyName = "D20";
            this.d20DataGridViewCheckBoxColumn.HeaderText = "20일";
            this.d20DataGridViewCheckBoxColumn.Name = "d20DataGridViewCheckBoxColumn";
            this.d20DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d21DataGridViewCheckBoxColumn
            // 
            this.d21DataGridViewCheckBoxColumn.DataPropertyName = "D21";
            this.d21DataGridViewCheckBoxColumn.HeaderText = "21일";
            this.d21DataGridViewCheckBoxColumn.Name = "d21DataGridViewCheckBoxColumn";
            this.d21DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d22DataGridViewCheckBoxColumn
            // 
            this.d22DataGridViewCheckBoxColumn.DataPropertyName = "D22";
            this.d22DataGridViewCheckBoxColumn.HeaderText = "22일";
            this.d22DataGridViewCheckBoxColumn.Name = "d22DataGridViewCheckBoxColumn";
            this.d22DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d23DataGridViewCheckBoxColumn
            // 
            this.d23DataGridViewCheckBoxColumn.DataPropertyName = "D23";
            this.d23DataGridViewCheckBoxColumn.HeaderText = "23일";
            this.d23DataGridViewCheckBoxColumn.Name = "d23DataGridViewCheckBoxColumn";
            this.d23DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d24DataGridViewCheckBoxColumn
            // 
            this.d24DataGridViewCheckBoxColumn.DataPropertyName = "D24";
            this.d24DataGridViewCheckBoxColumn.HeaderText = "24일";
            this.d24DataGridViewCheckBoxColumn.Name = "d24DataGridViewCheckBoxColumn";
            this.d24DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d25DataGridViewCheckBoxColumn
            // 
            this.d25DataGridViewCheckBoxColumn.DataPropertyName = "D25";
            this.d25DataGridViewCheckBoxColumn.HeaderText = "25일";
            this.d25DataGridViewCheckBoxColumn.Name = "d25DataGridViewCheckBoxColumn";
            this.d25DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d26DataGridViewCheckBoxColumn
            // 
            this.d26DataGridViewCheckBoxColumn.DataPropertyName = "D26";
            this.d26DataGridViewCheckBoxColumn.HeaderText = "26일";
            this.d26DataGridViewCheckBoxColumn.Name = "d26DataGridViewCheckBoxColumn";
            this.d26DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d27DataGridViewCheckBoxColumn
            // 
            this.d27DataGridViewCheckBoxColumn.DataPropertyName = "D27";
            this.d27DataGridViewCheckBoxColumn.HeaderText = "27일";
            this.d27DataGridViewCheckBoxColumn.Name = "d27DataGridViewCheckBoxColumn";
            this.d27DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d28DataGridViewCheckBoxColumn
            // 
            this.d28DataGridViewCheckBoxColumn.DataPropertyName = "D28";
            this.d28DataGridViewCheckBoxColumn.HeaderText = "28일";
            this.d28DataGridViewCheckBoxColumn.Name = "d28DataGridViewCheckBoxColumn";
            this.d28DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d29DataGridViewCheckBoxColumn
            // 
            this.d29DataGridViewCheckBoxColumn.DataPropertyName = "D29";
            this.d29DataGridViewCheckBoxColumn.HeaderText = "29일";
            this.d29DataGridViewCheckBoxColumn.Name = "d29DataGridViewCheckBoxColumn";
            this.d29DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d30DataGridViewCheckBoxColumn
            // 
            this.d30DataGridViewCheckBoxColumn.DataPropertyName = "D30";
            this.d30DataGridViewCheckBoxColumn.HeaderText = "30일";
            this.d30DataGridViewCheckBoxColumn.Name = "d30DataGridViewCheckBoxColumn";
            this.d30DataGridViewCheckBoxColumn.Width = 50;
            // 
            // d31DataGridViewCheckBoxColumn
            // 
            this.d31DataGridViewCheckBoxColumn.DataPropertyName = "D31";
            this.d31DataGridViewCheckBoxColumn.HeaderText = "31일";
            this.d31DataGridViewCheckBoxColumn.Name = "d31DataGridViewCheckBoxColumn";
            this.d31DataGridViewCheckBoxColumn.Width = 50;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 522);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.MainForm_Load);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRowBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource gridRowBindingSource;
        private System.Windows.Forms.Button buttonEMail;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonDeleteSchedule;
        private System.Windows.Forms.Button buttonAddSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rankDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d01DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d02DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d03DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d04DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d05DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d06DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d07DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d08DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d09DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d10DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d11DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d12DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d13DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d14DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d15DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d16DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d17DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d18DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d19DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d20DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d21DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d22DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d23DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d24DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d25DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d26DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d27DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d28DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d29DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d30DataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d31DataGridViewCheckBoxColumn;
    }
}

