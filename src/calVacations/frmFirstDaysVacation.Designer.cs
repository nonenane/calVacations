namespace calVacations
{
    partial class frmFirstDaysVacation
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
            this.btDel = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.nudDay = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbskdg = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudDay)).BeginInit();
            this.SuspendLayout();
            // 
            // btDel
            // 
            this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDel.Image = global::calVacations.Properties.Resources.agt_action_fail_2870;
            this.btDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDel.Location = new System.Drawing.Point(12, 92);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(115, 32);
            this.btDel.TabIndex = 21;
            this.btDel.Text = "Удалить ввод";
            this.btDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btDel, "Удалить ввод");
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Visible = false;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::calVacations.Properties.Resources.filesave_2175;
            this.btSave.Location = new System.Drawing.Point(176, 92);
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
            this.btClose.Location = new System.Drawing.Point(214, 92);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 22;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Дата начала расчета";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Кол-во дней отпуска";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(144, 22);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(95, 20);
            this.dtpDate.TabIndex = 24;
            // 
            // nudDay
            // 
            this.nudDay.Location = new System.Drawing.Point(27, 66);
            this.nudDay.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDay.Name = "nudDay";
            this.nudDay.Size = new System.Drawing.Size(95, 20);
            this.nudDay.TabIndex = 25;
            this.nudDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDay.Visible = false;
            // 
            // tbskdg
            // 
            this.tbskdg.Location = new System.Drawing.Point(144, 47);
            this.tbskdg.Name = "tbskdg";
            this.tbskdg.Size = new System.Drawing.Size(55, 20);
            this.tbskdg.TabIndex = 26;
            this.tbskdg.Text = "28,3";
            this.tbskdg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbskdg.TextChanged += new System.EventHandler(this.tbskdg_TextChanged);
            this.tbskdg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbskdg_KeyPress);
            // 
            // frmFirstDaysVacation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 130);
            this.ControlBox = false;
            this.Controls.Add(this.tbskdg);
            this.Controls.Add(this.nudDay);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btDel);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFirstDaysVacation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Первичный ввод отпуска";
            this.Load += new System.EventHandler(this.frmFirstDaysVacation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.NumericUpDown nudDay;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbskdg;
    }
}