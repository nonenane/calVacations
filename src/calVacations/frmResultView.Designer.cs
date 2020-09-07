namespace calVacations
{
    partial class frmResultView
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAbsenc = new System.Windows.Forms.DataGridView();
            this.cnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnDateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cVacation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cBreak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCountMonth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCountDays = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btPrint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDayWithPay = new System.Windows.Forms.TextBox();
            this.lDayWithOutPay = new System.Windows.Forms.Label();
            this.tbDayWithOutPay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCountVacantionUsed = new System.Windows.Forms.TextBox();
            this.tbBreak = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsenc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAbsenc
            // 
            this.dgvAbsenc.AllowUserToAddRows = false;
            this.dgvAbsenc.AllowUserToDeleteRows = false;
            this.dgvAbsenc.AllowUserToResizeRows = false;
            this.dgvAbsenc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAbsenc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAbsenc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbsenc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnDate,
            this.cnDateEnd,
            this.cVacation,
            this.cBreak});
            this.dgvAbsenc.Location = new System.Drawing.Point(12, 96);
            this.dgvAbsenc.Name = "dgvAbsenc";
            this.dgvAbsenc.RowHeadersVisible = false;
            this.dgvAbsenc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAbsenc.Size = new System.Drawing.Size(607, 372);
            this.dgvAbsenc.TabIndex = 27;
            this.dgvAbsenc.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvAbsenc_RowPrePaint);
            // 
            // cnDate
            // 
            this.cnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnDate.DataPropertyName = "date";
            this.cnDate.FillWeight = 121.8274F;
            this.cnDate.HeaderText = "Дата";
            this.cnDate.MinimumWidth = 80;
            this.cnDate.Name = "cnDate";
            this.cnDate.ReadOnly = true;
            this.cnDate.Width = 120;
            // 
            // cnDateEnd
            // 
            this.cnDateEnd.DataPropertyName = "percent";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cnDateEnd.DefaultCellStyle = dataGridViewCellStyle2;
            this.cnDateEnd.FillWeight = 78.17259F;
            this.cnDateEnd.HeaderText = "Процент отработки месяца";
            this.cnDateEnd.Name = "cnDateEnd";
            this.cnDateEnd.ReadOnly = true;
            // 
            // cVacation
            // 
            this.cVacation.DataPropertyName = "cntDay";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cVacation.DefaultCellStyle = dataGridViewCellStyle3;
            this.cVacation.HeaderText = "Отпуск";
            this.cVacation.Name = "cVacation";
            this.cVacation.ReadOnly = true;
            // 
            // cBreak
            // 
            this.cBreak.DataPropertyName = "cntBreak";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cBreak.DefaultCellStyle = dataGridViewCellStyle4;
            this.cBreak.HeaderText = "Отсутствия";
            this.cBreak.Name = "cBreak";
            this.cBreak.ReadOnly = true;
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::calVacations.Properties.Resources.exit_8633;
            this.btClose.Location = new System.Drawing.Point(575, 527);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 487);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Кол-во месяцев:";
            // 
            // tbCountMonth
            // 
            this.tbCountMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbCountMonth.Location = new System.Drawing.Point(126, 483);
            this.tbCountMonth.Name = "tbCountMonth";
            this.tbCountMonth.ReadOnly = true;
            this.tbCountMonth.Size = new System.Drawing.Size(85, 20);
            this.tbCountMonth.TabIndex = 29;
            this.tbCountMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 513);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Начисленно отпуска:";
            // 
            // tbCountDays
            // 
            this.tbCountDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbCountDays.Location = new System.Drawing.Point(346, 509);
            this.tbCountDays.Name = "tbCountDays";
            this.tbCountDays.ReadOnly = true;
            this.tbCountDays.Size = new System.Drawing.Size(86, 20);
            this.tbCountDays.TabIndex = 29;
            this.tbCountDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Image = global::calVacations.Properties.Resources.klpq_2511;
            this.btPrint.Location = new System.Drawing.Point(537, 527);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(32, 32);
            this.btPrint.TabIndex = 32;
            this.toolTip1.SetToolTip(this.btPrint, "Печать");
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Сотрудник";
            // 
            // tbFio
            // 
            this.tbFio.Location = new System.Drawing.Point(78, 6);
            this.tbFio.Name = "tbFio";
            this.tbFio.ReadOnly = true;
            this.tbFio.Size = new System.Drawing.Size(259, 20);
            this.tbFio.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Доступное количество дней отпуска";
            // 
            // tbDayWithPay
            // 
            this.tbDayWithPay.Location = new System.Drawing.Point(219, 32);
            this.tbDayWithPay.Name = "tbDayWithPay";
            this.tbDayWithPay.ReadOnly = true;
            this.tbDayWithPay.Size = new System.Drawing.Size(118, 20);
            this.tbDayWithPay.TabIndex = 31;
            this.tbDayWithPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lDayWithOutPay
            // 
            this.lDayWithOutPay.AutoSize = true;
            this.lDayWithOutPay.Location = new System.Drawing.Point(33, 61);
            this.lDayWithOutPay.Name = "lDayWithOutPay";
            this.lDayWithOutPay.Size = new System.Drawing.Size(174, 13);
            this.lDayWithOutPay.TabIndex = 30;
            this.lDayWithOutPay.Text = "С учётом неоплаченного отпуска";
            // 
            // tbDayWithOutPay
            // 
            this.tbDayWithOutPay.Location = new System.Drawing.Point(219, 58);
            this.tbDayWithOutPay.Name = "tbDayWithOutPay";
            this.tbDayWithOutPay.ReadOnly = true;
            this.tbDayWithOutPay.Size = new System.Drawing.Size(118, 20);
            this.tbDayWithOutPay.TabIndex = 31;
            this.tbDayWithOutPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 506);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 26);
            this.label5.TabIndex = 28;
            this.label5.Text = "Кол-во дней\r\nотгуленного отпуска:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbCountVacantionUsed
            // 
            this.tbCountVacantionUsed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbCountVacantionUsed.Location = new System.Drawing.Point(126, 509);
            this.tbCountVacantionUsed.Name = "tbCountVacantionUsed";
            this.tbCountVacantionUsed.ReadOnly = true;
            this.tbCountVacantionUsed.Size = new System.Drawing.Size(85, 20);
            this.tbCountVacantionUsed.TabIndex = 29;
            this.tbCountVacantionUsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbBreak
            // 
            this.tbBreak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbBreak.Location = new System.Drawing.Point(346, 483);
            this.tbBreak.Name = "tbBreak";
            this.tbBreak.ReadOnly = true;
            this.tbBreak.Size = new System.Drawing.Size(86, 20);
            this.tbBreak.TabIndex = 34;
            this.tbBreak.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 487);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Отсутствия:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(8, 540);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(19, 19);
            this.panel1.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(168)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(229, 540);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(19, 19);
            this.panel2.TabIndex = 35;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(255)))), ((int)(((byte)(179)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(385, 540);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(19, 19);
            this.panel3.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 543);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "-Отсутствия участвующие в расчете";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(254, 543);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "- Неоплаченный отпуск";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(410, 543);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "-Компенсация";
            // 
            // frmResultView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 566);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbBreak);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.tbDayWithOutPay);
            this.Controls.Add(this.lDayWithOutPay);
            this.Controls.Add(this.tbDayWithPay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbFio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCountDays);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCountVacantionUsed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbCountMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAbsenc);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmResultView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Результат по месяцам";
            this.Load += new System.EventHandler(this.frmResultView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsenc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.DataGridView dgvAbsenc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCountMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCountDays;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDayWithPay;
        private System.Windows.Forms.Label lDayWithOutPay;
        private System.Windows.Forms.TextBox tbDayWithOutPay;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCountVacantionUsed;
        private System.Windows.Forms.TextBox tbBreak;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDateEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cVacation;
        private System.Windows.Forms.DataGridViewTextBoxColumn cBreak;
    }
}