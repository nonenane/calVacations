namespace calVacations
{
    partial class frmSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.nudkdog = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudkdps = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudsous = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudskdg = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbskdg = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudkdog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudkdps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudsous)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudskdg)).BeginInit();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Image = global::calVacations.Properties.Resources.filesave_2175;
            this.btSave.Location = new System.Drawing.Point(396, 193);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(32, 32);
            this.btSave.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btSave, "Сохранить");
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Image = global::calVacations.Properties.Resources.exit_8633;
            this.btClose.Location = new System.Drawing.Point(434, 193);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(32, 32);
            this.btClose.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btClose, "Выход");
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "Кол-во дней отпуска положенных за один отработанный год";
            // 
            // nudkdog
            // 
            this.nudkdog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudkdog.Location = new System.Drawing.Point(411, 20);
            this.nudkdog.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudkdog.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudkdog.Name = "nudkdog";
            this.nudkdog.Size = new System.Drawing.Size(55, 20);
            this.nudkdog.TabIndex = 22;
            this.nudkdog.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(23, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(340, 73);
            this.label2.TabIndex = 21;
            this.label2.Text = "Кол-во дней, которые допустимо пропустить подряд сотрудником на работе по ПО «Уче" +
    "т рабочего времени», при нахождении которых не будет выводится дополнительный за" +
    "прос при формировании отпускных дней";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudkdps
            // 
            this.nudkdps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudkdps.Location = new System.Drawing.Point(411, 74);
            this.nudkdps.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudkdps.Name = "nudkdps";
            this.nudkdps.Size = new System.Drawing.Size(55, 20);
            this.nudkdps.TabIndex = 22;
            this.nudkdps.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(340, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Кол-во дней отображения уволенных сотрудников";
            // 
            // nudsous
            // 
            this.nudsous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudsous.Location = new System.Drawing.Point(411, 117);
            this.nudsous.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudsous.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudsous.Name = "nudsous";
            this.nudsous.Size = new System.Drawing.Size(55, 20);
            this.nudsous.TabIndex = 22;
            this.nudsous.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(23, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(340, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Среднее кол-во календарных дней в месяце для расчета отпуска";
            // 
            // nudskdg
            // 
            this.nudskdg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudskdg.Location = new System.Drawing.Point(205, 193);
            this.nudskdg.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudskdg.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudskdg.Name = "nudskdg";
            this.nudskdg.Size = new System.Drawing.Size(55, 20);
            this.nudskdg.TabIndex = 22;
            this.nudskdg.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudskdg.Visible = false;
            // 
            // tbskdg
            // 
            this.tbskdg.Location = new System.Drawing.Point(411, 146);
            this.tbskdg.Name = "tbskdg";
            this.tbskdg.Size = new System.Drawing.Size(55, 20);
            this.tbskdg.TabIndex = 23;
            this.tbskdg.Text = "28,3";
            this.tbskdg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbskdg.TextChanged += new System.EventHandler(this.tbskdg_TextChanged);
            this.tbskdg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbskdg_KeyPress);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 237);
            this.ControlBox = false;
            this.Controls.Add(this.tbskdg);
            this.Controls.Add(this.nudskdg);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudsous);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudkdps);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudkdog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettings_FormClosing);
            this.Load += new System.EventHandler(this.frmSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudkdog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudkdps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudsous)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudskdg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudkdog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudkdps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudsous;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudskdg;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbskdg;
    }
}