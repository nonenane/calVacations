namespace calVacations
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDeps = new System.Windows.Forms.ComboBox();
            this.chbUnemploy = new System.Windows.Forms.CheckBox();
            this.pUnemploy = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDateCome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCountDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDateStartCalculate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.cmsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.рассчитатьДоступноеКоличествоДнейОтпускаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btReportNotPayVacation = new System.Windows.Forms.Button();
            this.btSettings = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.btGraFWorkKadr = new System.Windows.Forms.Button();
            this.btAddFirstDayVacation = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.chbShowTransfer = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.cmsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1079, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(25, 17);
            this.toolStripStatusLabel1.Text = "___";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Отдел:";
            // 
            // cmbDeps
            // 
            this.cmbDeps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeps.FormattingEnabled = true;
            this.cmbDeps.Location = new System.Drawing.Point(70, 13);
            this.cmbDeps.Name = "cmbDeps";
            this.cmbDeps.Size = new System.Drawing.Size(190, 21);
            this.cmbDeps.TabIndex = 17;
            this.cmbDeps.DropDown += new System.EventHandler(this.cmbDeps_DropDown);
            this.cmbDeps.SelectionChangeCommitted += new System.EventHandler(this.cmbDeps_SelectionChangeCommitted);
            // 
            // chbUnemploy
            // 
            this.chbUnemploy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbUnemploy.AutoSize = true;
            this.chbUnemploy.Location = new System.Drawing.Point(38, 396);
            this.chbUnemploy.Name = "chbUnemploy";
            this.chbUnemploy.Size = new System.Drawing.Size(148, 17);
            this.chbUnemploy.TabIndex = 20;
            this.chbUnemploy.Text = "- уволенные сотрудники";
            this.chbUnemploy.UseVisualStyleBackColor = true;
            this.chbUnemploy.CheckedChanged += new System.EventHandler(this.chbUnemploy_CheckedChanged);
            // 
            // pUnemploy
            // 
            this.pUnemploy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pUnemploy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(153)))));
            this.pUnemploy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pUnemploy.Location = new System.Drawing.Point(13, 394);
            this.pUnemploy.Name = "pUnemploy";
            this.pUnemploy.Size = new System.Drawing.Size(19, 19);
            this.pUnemploy.TabIndex = 21;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDep,
            this.cPost,
            this.cFIO,
            this.cDateCome,
            this.cDateEnd,
            this.cCountDay,
            this.cDateStartCalculate});
            this.dgvData.Location = new System.Drawing.Point(13, 67);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1054, 314);
            this.dgvData.TabIndex = 22;
            this.dgvData.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseClick);
            this.dgvData.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvData_RowPostPaint);
            this.dgvData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvData_RowPrePaint);
            this.dgvData.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvData_Paint);
            // 
            // cDep
            // 
            this.cDep.DataPropertyName = "nameDep";
            this.cDep.HeaderText = "Отдел";
            this.cDep.Name = "cDep";
            this.cDep.ReadOnly = true;
            // 
            // cPost
            // 
            this.cPost.DataPropertyName = "namePost";
            this.cPost.HeaderText = "Должность";
            this.cPost.Name = "cPost";
            this.cPost.ReadOnly = true;
            // 
            // cFIO
            // 
            this.cFIO.DataPropertyName = "FIO";
            this.cFIO.HeaderText = "ФИО";
            this.cFIO.Name = "cFIO";
            this.cFIO.ReadOnly = true;
            // 
            // cDateCome
            // 
            this.cDateCome.DataPropertyName = "dateEmploy";
            this.cDateCome.HeaderText = "Дата приема на работу";
            this.cDateCome.Name = "cDateCome";
            this.cDateCome.ReadOnly = true;
            // 
            // cDateEnd
            // 
            this.cDateEnd.DataPropertyName = "dateUnemploy";
            this.cDateEnd.HeaderText = "Дата увольнения";
            this.cDateEnd.Name = "cDateEnd";
            this.cDateEnd.ReadOnly = true;
            this.cDateEnd.Visible = false;
            // 
            // cCountDay
            // 
            this.cCountDay.DataPropertyName = "FirstVacationDays";
            this.cCountDay.HeaderText = "Кол-во дней отпуска";
            this.cCountDay.Name = "cCountDay";
            this.cCountDay.ReadOnly = true;
            // 
            // cDateStartCalculate
            // 
            this.cDateStartCalculate.DataPropertyName = "StartCalculation";
            this.cDateStartCalculate.HeaderText = "Дата начала расчета";
            this.cDateStartCalculate.Name = "cDateStartCalculate";
            this.cDateStartCalculate.ReadOnly = true;
            // 
            // tbFIO
            // 
            this.tbFIO.Location = new System.Drawing.Point(314, 41);
            this.tbFIO.Name = "tbFIO";
            this.tbFIO.Size = new System.Drawing.Size(154, 20);
            this.tbFIO.TabIndex = 23;
            this.tbFIO.TextChanged += new System.EventHandler(this.tbFIO_TextChanged);
            // 
            // cmsMenu
            // 
            this.cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.рассчитатьДоступноеКоличествоДнейОтпускаToolStripMenuItem});
            this.cmsMenu.Name = "cmsMenu";
            this.cmsMenu.Size = new System.Drawing.Size(324, 26);
            // 
            // рассчитатьДоступноеКоличествоДнейОтпускаToolStripMenuItem
            // 
            this.рассчитатьДоступноеКоличествоДнейОтпускаToolStripMenuItem.Name = "рассчитатьДоступноеКоличествоДнейОтпускаToolStripMenuItem";
            this.рассчитатьДоступноеКоличествоДнейОтпускаToolStripMenuItem.Size = new System.Drawing.Size(323, 22);
            this.рассчитатьДоступноеКоличествоДнейОтпускаToolStripMenuItem.Text = "Рассчитать доступное количество дней отпуска";
            this.рассчитатьДоступноеКоличествоДнейОтпускаToolStripMenuItem.Click += new System.EventHandler(this.рассчитатьДоступноеКоличествоДнейОтпускаToolStripMenuItem_Click);
            // 
            // btReportNotPayVacation
            // 
            this.btReportNotPayVacation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btReportNotPayVacation.Image = global::calVacations.Properties.Resources.lying_on_beach;
            this.btReportNotPayVacation.Location = new System.Drawing.Point(883, 387);
            this.btReportNotPayVacation.Name = "btReportNotPayVacation";
            this.btReportNotPayVacation.Size = new System.Drawing.Size(32, 32);
            this.btReportNotPayVacation.TabIndex = 24;
            this.toolTip1.SetToolTip(this.btReportNotPayVacation, "Отчет по неоплаченным отпускам");
            this.btReportNotPayVacation.UseVisualStyleBackColor = true;
            this.btReportNotPayVacation.Click += new System.EventHandler(this.btReportNotPayVacation_Click);
            // 
            // btSettings
            // 
            this.btSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btSettings.Image = global::calVacations.Properties.Resources.p3;
            this.btSettings.Location = new System.Drawing.Point(456, 387);
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(32, 32);
            this.btSettings.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btSettings, "Настройки");
            this.btSettings.UseVisualStyleBackColor = true;
            this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Image = global::calVacations.Properties.Resources.klpq_2511;
            this.btPrint.Location = new System.Drawing.Point(921, 387);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(32, 32);
            this.btPrint.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btPrint, "Печать");
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btGraFWorkKadr
            // 
            this.btGraFWorkKadr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btGraFWorkKadr.Image = global::calVacations.Properties.Resources.p1;
            this.btGraFWorkKadr.Location = new System.Drawing.Point(959, 387);
            this.btGraFWorkKadr.Name = "btGraFWorkKadr";
            this.btGraFWorkKadr.Size = new System.Drawing.Size(32, 32);
            this.btGraFWorkKadr.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btGraFWorkKadr, "Список отпусков и отсутствий сотрудника");
            this.btGraFWorkKadr.UseVisualStyleBackColor = true;
            this.btGraFWorkKadr.Click += new System.EventHandler(this.btGraFWorkKadr_Click);
            // 
            // btAddFirstDayVacation
            // 
            this.btAddFirstDayVacation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btAddFirstDayVacation.Image = global::calVacations.Properties.Resources.p2;
            this.btAddFirstDayVacation.Location = new System.Drawing.Point(997, 387);
            this.btAddFirstDayVacation.Name = "btAddFirstDayVacation";
            this.btAddFirstDayVacation.Size = new System.Drawing.Size(32, 32);
            this.btAddFirstDayVacation.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btAddFirstDayVacation, "Первичный ввод отпуска");
            this.btAddFirstDayVacation.UseVisualStyleBackColor = true;
            this.btAddFirstDayVacation.Click += new System.EventHandler(this.btAddFirstDayVacation_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::calVacations.Properties.Resources.exit_8633;
            this.btClose.Location = new System.Drawing.Point(1035, 387);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btUpdate
            // 
            this.btUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btUpdate.Image = global::calVacations.Properties.Resources.reload_8055;
            this.btUpdate.Location = new System.Drawing.Point(1035, 6);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(32, 32);
            this.btUpdate.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btUpdate, "Обновить");
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // chbShowTransfer
            // 
            this.chbShowTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbShowTransfer.AutoSize = true;
            this.chbShowTransfer.Location = new System.Drawing.Point(221, 396);
            this.chbShowTransfer.Name = "chbShowTransfer";
            this.chbShowTransfer.Size = new System.Drawing.Size(155, 17);
            this.chbShowTransfer.TabIndex = 25;
            this.chbShowTransfer.Text = "- показать переведенных";
            this.chbShowTransfer.UseVisualStyleBackColor = true;
            this.chbShowTransfer.CheckedChanged += new System.EventHandler(this.chbUnemploy_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 450);
            this.Controls.Add(this.chbShowTransfer);
            this.Controls.Add(this.btReportNotPayVacation);
            this.Controls.Add(this.tbFIO);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.pUnemploy);
            this.Controls.Add(this.chbUnemploy);
            this.Controls.Add(this.btSettings);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btGraFWorkKadr);
            this.Controls.Add(this.btAddFirstDayVacation);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDeps);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(808, 477);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.cmsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDeps;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btAddFirstDayVacation;
        private System.Windows.Forms.Button btGraFWorkKadr;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btSettings;
        private System.Windows.Forms.CheckBox chbUnemploy;
        private System.Windows.Forms.Panel pUnemploy;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.TextBox tbFIO;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem рассчитатьДоступноеКоличествоДнейОтпускаToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPost;
        private System.Windows.Forms.DataGridViewTextBoxColumn cFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDateCome;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDateEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCountDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDateStartCalculate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btReportNotPayVacation;
        private System.Windows.Forms.CheckBox chbShowTransfer;
    }
}

