namespace calVacations
{
    partial class frmCorrectionKadDate
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
            this.btClose = new System.Windows.Forms.Button();
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAbsenc = new System.Windows.Forms.DataGridView();
            this.cnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnDateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCheack = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cnComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btSave = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsenc)).BeginInit();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::calVacations.Properties.Resources.exit_8633;
            this.btClose.Location = new System.Drawing.Point(600, 317);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // tbFIO
            // 
            this.tbFIO.Location = new System.Drawing.Point(76, 30);
            this.tbFIO.Name = "tbFIO";
            this.tbFIO.ReadOnly = true;
            this.tbFIO.Size = new System.Drawing.Size(327, 20);
            this.tbFIO.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Сотрудник";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(393, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "При расчёте сотрудника были обнаружены периоды отсутствия сотрудника";
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
            this.cnCheack,
            this.cnComment});
            this.dgvAbsenc.Location = new System.Drawing.Point(12, 56);
            this.dgvAbsenc.Name = "dgvAbsenc";
            this.dgvAbsenc.RowHeadersVisible = false;
            this.dgvAbsenc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAbsenc.Size = new System.Drawing.Size(615, 255);
            this.dgvAbsenc.TabIndex = 26;
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
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Location = new System.Drawing.Point(434, 317);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(160, 32);
            this.btSave.TabIndex = 20;
            this.btSave.Text = "Сохранить и рассчитать";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // frmCorrectionKadDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 361);
            this.ControlBox = false;
            this.Controls.Add(this.dgvAbsenc);
            this.Controls.Add(this.tbFIO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCorrectionKadDate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Расчет отпуска сотрудника";
            this.Load += new System.EventHandler(this.frmCorrectionKadDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbsenc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TextBox tbFIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAbsenc;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDateEnd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cnCheack;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnComment;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}