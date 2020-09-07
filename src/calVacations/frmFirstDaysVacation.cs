using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calVacations
{
    public partial class frmFirstDaysVacation : Form
    {
        public frmFirstDaysVacation()
        {
            InitializeComponent();
        }

        private void frmFirstDaysVacation_Load(object sender, EventArgs e)
        {
            dtpDate.MinDate = kadrInfo.dateEmploy;

            if (kadrInfo.dateUnEmploy != null)
                dtpDate.MaxDate = (DateTime)kadrInfo.dateUnEmploy;

            Task.Run(() => get_data());
        }

        private void DoOnUIThread(MethodInvoker d)
        {
            if (this.InvokeRequired) { this.Invoke(d); } else { d(); }
        }

        private decimal countDay;
        private DateTime startDate;

        private async Task get_data()
        {
            DoOnUIThread(delegate ()
            { this.Enabled = false; });

            DataTable dtData = await Config.hCntMain.getFirstVacationData(kadrInfo.id_kadr);
            if (dtData != null && dtData.Rows.Count > 0)
                DoOnUIThread(delegate ()
                {
                    if (dtData.Rows[0]["FirstVacationDays"] != DBNull.Value)
                    {
                        //nudDay.Value = decimal.Parse(dtData.Rows[0]["FirstVacationDays"].ToString());
                        //countDay = nudDay.Value;
                        tbskdg.Text = dtData.Rows[0]["FirstVacationDays"].ToString();
                        countDay = decimal.Parse(tbskdg.Text.ToString());
                    }

                    if (dtData.Rows[0]["StartCalculation"] != DBNull.Value)
                    {
                        try
                        {
                            dtpDate.Value = (DateTime)dtData.Rows[0]["StartCalculation"];
                            startDate = dtpDate.Value;
                        }
                        catch
                        {
                            dtpDate.Value = dtpDate.MaxDate;
                            startDate = dtpDate.Value;
                        }
                    }

                    btDel.Visible = true;
                });

            DoOnUIThread(delegate ()
            { this.Enabled = true; });

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Config.hCntMain.setFirstVacationData(kadrInfo.id_kadr, decimal.Parse(tbskdg.Text.ToString()), dtpDate.Value, false);

            Logging.StartFirstLevel(1508);            
            Logging.Comment("Сотрудник ID:" + kadrInfo.id_kadr + "; ФИО: " + kadrInfo.FIO);
            Logging.Comment("Отдел: " + kadrInfo.nameDep);

            Logging.VariableChange("Дата начала расчёта: ", dtpDate.Value.Date.ToShortDateString(), startDate.Date.ToShortDateString());
            Logging.VariableChange("Кол-во дней отпуска: ", decimal.Parse(tbskdg.Text.ToString()), countDay, typeLog._decimal);

            Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                            + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
            Logging.StopFirstLevel();


            MessageBox.Show("Данные сохранены!", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(Config.centralText("Вы хотите очистить первичный ввод\nданных по отпуску сотрудника?\n\nВнимание! Для предотвращения потери информации\nоперация удаления логируется.\n"), "Очистка ввода отпуска", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                Logging.StartFirstLevel(1490);

                Logging.Comment("Произведено удаление записи о первичном вводе отпуска на форме «Первичный ввод отпуска»");

                Logging.Comment("Сотрудник ID:" + kadrInfo.id_kadr + "; ФИО: "+kadrInfo.FIO);
                Logging.Comment("Количество дней первичного отпуска перед удалением: " + decimal.Parse(tbskdg.Text.ToString()).ToString("0.0"));
                Logging.Comment("Дата начала расчёта: "+ startDate.Date.ToShortDateString());

                Logging.StopFirstLevel();
             
                Config.hCntMain.setFirstVacationData(kadrInfo.id_kadr, decimal.Parse(tbskdg.Text.ToString()), dtpDate.Value, true);
                MessageBox.Show("Данные удалены!", "Удаление данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
        }

        private void tbskdg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            if ((e.KeyChar == ',') && ((sender as TextBox).Text.ToString().Contains(e.KeyChar) || (sender as TextBox).Text.ToString().Length == 0))
            {
                e.Handled = true;
            }
            else
                if ((!Char.IsNumber(e.KeyChar) && (e.KeyChar != ',')))
            {
                if (e.KeyChar != '\b')
                { e.Handled = true; }
            }
        }

        private void tbskdg_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
