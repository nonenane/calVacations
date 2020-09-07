namespace calVacations
{
    partial class frmGrafWorkKadr
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btDel = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.dgvHoli = new System.Windows.Forms.DataGridView();
            this.chDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chPay = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chCompensation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvAbsenc = new System.Windows.Forms.DataGridView();
            this.cnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnDateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCheack = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cnComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btEditAbsenc = new System.Windows.Forms.Button();
            this.btReportAbcent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btClose = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoli)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsenc)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 74);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(629, 343);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btDel);
            this.tabPage1.Controls.Add(this.btEdit);
            this.tabPage1.Controls.Add(this.btAdd);
            this.tabPage1.Controls.Add(this.btPrint);
            this.tabPage1.Controls.Add(this.dgvHoli);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(621, 317);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Отпуск";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDel.Image = global::calVacations.Properties.Resources.agt_action_fail_2870;
            this.btDel.Location = new System.Drawing.Point(578, 276);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(35, 35);
            this.btDel.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btDel, "Удалить");
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.Image = global::calVacations.Properties.Resources._2;
            this.btEdit.Location = new System.Drawing.Point(537, 276);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(35, 35);
            this.btEdit.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btEdit, "Редактировать");
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.Image = global::calVacations.Properties.Resources.view2;
            this.btAdd.Location = new System.Drawing.Point(496, 276);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(35, 35);
            this.btAdd.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btAdd, "Добавить");
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Image = global::calVacations.Properties.Resources.klpq_2511;
            this.btPrint.Location = new System.Drawing.Point(455, 276);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(35, 35);
            this.btPrint.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btPrint, "Печать");
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // dgvHoli
            // 
            this.dgvHoli.AllowUserToAddRows = false;
            this.dgvHoli.AllowUserToDeleteRows = false;
            this.dgvHoli.AllowUserToResizeRows = false;
            this.dgvHoli.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoli.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHoli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoli.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chDate,
            this.chCount,
            this.chPay,
            this.chCompensation,
            this.chComment});
            this.dgvHoli.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvHoli.Location = new System.Drawing.Point(3, 3);
            this.dgvHoli.Name = "dgvHoli";
            this.dgvHoli.RowHeadersVisible = false;
            this.dgvHoli.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoli.Size = new System.Drawing.Size(615, 255);
            this.dgvHoli.TabIndex = 0;
            // 
            // chDate
            // 
            this.chDate.DataPropertyName = "DataStartVacation";
            this.chDate.HeaderText = "Дата начала отпуска";
            this.chDate.Name = "chDate";
            this.chDate.ReadOnly = true;
            // 
            // chCount
            // 
            this.chCount.DataPropertyName = "CountVacation";
            this.chCount.HeaderText = "Продолжительность дней";
            this.chCount.Name = "chCount";
            this.chCount.ReadOnly = true;
            // 
            // chPay
            // 
            this.chPay.DataPropertyName = "isPaid";
            this.chPay.HeaderText = "Отпуск оплачен";
            this.chPay.Name = "chPay";
            this.chPay.ReadOnly = true;
            // 
            // chCompensation
            // 
            this.chCompensation.DataPropertyName = "isCompensatory";
            this.chCompensation.HeaderText = "Компенсация";
            this.chCompensation.Name = "chCompensation";
            this.chCompensation.ReadOnly = true;
            // 
            // chComment
            // 
            this.chComment.DataPropertyName = "Comment";
            this.chComment.HeaderText = "Комментарий";
            this.chComment.Name = "chComment";
            this.chComment.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvAbsenc);
            this.tabPage2.Controls.Add(this.btEditAbsenc);
            this.tabPage2.Controls.Add(this.btReportAbcent);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(621, 317);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Отсутствие";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvAbsenc
            // 
            this.dgvAbsenc.AllowUserToAddRows = false;
            this.dgvAbsenc.AllowUserToDeleteRows = false;
            this.dgvAbsenc.AllowUserToResizeRows = false;
            this.dgvAbsenc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAbsenc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAbsenc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbsenc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnDate,
            this.cnDateEnd,
            this.cnCheack,
            this.cnComment});
            this.dgvAbsenc.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvAbsenc.Location = new System.Drawing.Point(3, 3);
            this.dgvAbsenc.Name = "dgvAbsenc";
            this.dgvAbsenc.RowHeadersVisible = false;
            this.dgvAbsenc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAbsenc.Size = new System.Drawing.Size(615, 255);
            this.dgvAbsenc.TabIndex = 22;
            // 
            // cnDate
            // 
            this.cnDate.DataPropertyName = "DataStartAbsence";
            this.cnDate.HeaderText = "Дата начала отсутствия";
            this.cnDate.Name = "cnDate";
            this.cnDate.ReadOnly = true;
            // 
            // cnDateEnd
            // 
            this.cnDateEnd.DataPropertyName = "DataStopAbsence";
            this.cnDateEnd.HeaderText = "Дата окончания отсутствия";
            this.cnDateEnd.Name = "cnDateEnd";
            this.cnDateEnd.ReadOnly = true;
            // 
            // cnCheack
            // 
            this.cnCheack.DataPropertyName = "inCalc";
            this.cnCheack.HeaderText = "Включить / не включить в расчет";
            this.cnCheack.Name = "cnCheack";
            this.cnCheack.ReadOnly = true;
            this.cnCheack.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cnCheack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cnComment
            // 
            this.cnComment.DataPropertyName = "Comment";
            this.cnComment.HeaderText = "Комментарий";
            this.cnComment.Name = "cnComment";
            this.cnComment.ReadOnly = true;
            // 
            // btEditAbsenc
            // 
            this.btEditAbsenc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEditAbsenc.Image = global::calVacations.Properties.Resources._2;
            this.btEditAbsenc.Location = new System.Drawing.Point(576, 276);
            this.btEditAbsenc.Name = "btEditAbsenc";
            this.btEditAbsenc.Size = new System.Drawing.Size(35, 35);
            this.btEditAbsenc.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btEditAbsenc, "Редактировать");
            this.btEditAbsenc.UseVisualStyleBackColor = true;
            this.btEditAbsenc.Click += new System.EventHandler(this.btEditAbsenc_Click);
            // 
            // btReportAbcent
            // 
            this.btReportAbcent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btReportAbcent.Image = global::calVacations.Properties.Resources.klpq_2511;
            this.btReportAbcent.Location = new System.Drawing.Point(535, 276);
            this.btReportAbcent.Name = "btReportAbcent";
            this.btReportAbcent.Size = new System.Drawing.Size(35, 35);
            this.btReportAbcent.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btReportAbcent, "Печать");
            this.btReportAbcent.UseVisualStyleBackColor = true;
            this.btReportAbcent.Click += new System.EventHandler(this.btReportAbcent_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "ФИО";
            // 
            // tbFIO
            // 
            this.tbFIO.Location = new System.Drawing.Point(53, 18);
            this.tbFIO.Name = "tbFIO";
            this.tbFIO.ReadOnly = true;
            this.tbFIO.Size = new System.Drawing.Size(563, 20);
            this.tbFIO.TabIndex = 23;
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(79, 48);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(100, 20);
            this.dtpStart.TabIndex = 24;
            this.dtpStart.CloseUp += new System.EventHandler(this.dtpStart_CloseUp);
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            this.dtpStart.Leave += new System.EventHandler(this.dtpStart_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Период с";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "по";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(224, 48);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(100, 20);
            this.dtpEnd.TabIndex = 24;
            this.dtpEnd.CloseUp += new System.EventHandler(this.dtpStart_CloseUp);
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            this.dtpEnd.Leave += new System.EventHandler(this.dtpStart_Leave);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::calVacations.Properties.Resources.exit_8633;
            this.btClose.Location = new System.Drawing.Point(588, 423);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(35, 35);
            this.btClose.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // frmGrafWorkKadr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 461);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbFIO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGrafWorkKadr";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список отпусков и отсутствий сотрудника";
            this.Load += new System.EventHandler(this.frmGrafWorkKadr_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoli)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsenc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFIO;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DataGridView dgvHoli;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btEditAbsenc;
        private System.Windows.Forms.Button btReportAbcent;
        private System.Windows.Forms.DataGridView dgvAbsenc;
        private System.Windows.Forms.DataGridViewTextBoxColumn chDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn chCount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chPay;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chCompensation;
        private System.Windows.Forms.DataGridViewTextBoxColumn chComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDateEnd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cnCheack;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnComment;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}