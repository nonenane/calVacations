namespace calVacations
{
    partial class frmAddVacation
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
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.tbFIO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.chbPay = new System.Windows.Forms.CheckBox();
            this.chbCompinsation = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::calVacations.Properties.Resources.filesave_2175;
            this.btSave.Location = new System.Drawing.Point(233, 301);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btSave, "Сохранить");
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::calVacations.Properties.Resources.exit_8633;
            this.btClose.Location = new System.Drawing.Point(271, 301);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 22;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // tbFIO
            // 
            this.tbFIO.Location = new System.Drawing.Point(79, 12);
            this.tbFIO.Name = "tbFIO";
            this.tbFIO.ReadOnly = true;
            this.tbFIO.Size = new System.Drawing.Size(220, 20);
            this.tbFIO.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Сотрудник";
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(132, 42);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(100, 20);
            this.dtpStart.TabIndex = 27;
            this.dtpStart.ValueChanged += new System.EventHandler(this.nudCount_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Дата начала отпуска";
            // 
            // nudCount
            // 
            this.nudCount.Location = new System.Drawing.Point(177, 73);
            this.nudCount.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(55, 20);
            this.nudCount.TabIndex = 29;
            this.nudCount.ValueChanged += new System.EventHandler(this.nudCount_ValueChanged);
            this.nudCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nudCount_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Продолжительность отпуска";
            // 
            // chbPay
            // 
            this.chbPay.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbPay.Location = new System.Drawing.Point(12, 96);
            this.chbPay.Name = "chbPay";
            this.chbPay.Size = new System.Drawing.Size(220, 24);
            this.chbPay.TabIndex = 30;
            this.chbPay.Text = "Отпуск оплачен";
            this.chbPay.UseVisualStyleBackColor = true;
            this.chbPay.CheckedChanged += new System.EventHandler(this.chbPay_CheckedChanged);
            // 
            // chbCompinsation
            // 
            this.chbCompinsation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbCompinsation.Location = new System.Drawing.Point(12, 117);
            this.chbCompinsation.Name = "chbCompinsation";
            this.chbCompinsation.Size = new System.Drawing.Size(220, 24);
            this.chbCompinsation.TabIndex = 30;
            this.chbCompinsation.Text = "Компенсация";
            this.chbCompinsation.UseVisualStyleBackColor = true;
            this.chbCompinsation.CheckedChanged += new System.EventHandler(this.chbPay_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Комментарий";
            // 
            // tbComment
            // 
            this.tbComment.Location = new System.Drawing.Point(15, 157);
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(284, 122);
            this.tbComment.TabIndex = 31;
            this.tbComment.TextChanged += new System.EventHandler(this.tbComment_TextChanged);
            // 
            // frmAddVacation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 341);
            this.ControlBox = false;
            this.Controls.Add(this.tbComment);
            this.Controls.Add(this.chbCompinsation);
            this.Controls.Add(this.chbPay);
            this.Controls.Add(this.nudCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFIO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddVacation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddVacation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddVacation_FormClosing);
            this.Load += new System.EventHandler(this.frmAddVacation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TextBox tbFIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbPay;
        private System.Windows.Forms.CheckBox chbCompinsation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}