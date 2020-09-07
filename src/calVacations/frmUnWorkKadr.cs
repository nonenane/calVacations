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
    public partial class frmUnWorkKadr : Form
    {
        public int id { set; private get; }

        public frmUnWorkKadr()
        {
            InitializeComponent();
        }

        private void frmUnWorkKadr_Load(object sender, EventArgs e)
        {
            tbFIO.Text = kadrInfo.FIO;
            Task.Run(() => get_data());
        }

        private void DoOnUIThread(MethodInvoker d)
        {
            if (this.InvokeRequired) { this.Invoke(d); } else { d(); }
        }
        
        private bool _inCalc;
        private string _comment;

        private async Task get_data()
        {
            DoOnUIThread(delegate ()
            { this.Enabled = false; });

            DataTable dtData = await Config.hCntMain.getSingleContentDayAbsence(id);
            if (dtData != null && dtData.Rows.Count > 0)
                DoOnUIThread(delegate ()
                {
                    if (dtData.Rows[0]["DataStartAbsence"] != DBNull.Value)
                    {
                        dtpStart.Value = (DateTime)dtData.Rows[0]["DataStartAbsence"];                        
                    }

                    if (dtData.Rows[0]["DataStopAbsence"] != DBNull.Value)
                    {
                        dtpEnd.Value = (DateTime)dtData.Rows[0]["DataStopAbsence"];
                    }
                                       

                    if (dtData.Rows[0]["inCalc"] != DBNull.Value)
                    {
                        chbinCalc.Checked = (bool)dtData.Rows[0]["inCalc"];
                        _inCalc = chbinCalc.Checked;
                        //        startDate = dtpDate.Value;
                    }

                    if (dtData.Rows[0]["Comment"] != DBNull.Value)
                    {
                        tbComment.Text = (string)dtData.Rows[0]["Comment"];
                        _comment = tbComment.Text;
                        //        startDate = dtpDate.Value;
                    }


                    //    btDel.Visible = true;
                });

            DoOnUIThread(delegate ()
            { this.Enabled = true; });

        }

        private void frmUnWorkKadr_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (_inCalc != chbinCalc.Checked || _comment != tbComment.Text)
              && DialogResult.No == MessageBox.Show(Config.centralText("На форме есть несохраненные данные.\nЗакрыть форму без сохранения данных?\n"), "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            Config.hCntMain.setSingleContentDayAbsence(id, kadrInfo.id_kadr,dtpStart.Value,dtpEnd.Value, chbinCalc.Checked, tbComment.Text.Trim(), false);


            Logging.StartFirstLevel(1511);
            Logging.Comment("Сотрудник ID:" + kadrInfo.id_kadr + "; ФИО: " + kadrInfo.FIO);
            Logging.Comment("Отдел: " + kadrInfo.nameDep);
            Logging.Comment("Дата начала отсутствия: "+ dtpStart.Value.Date.ToShortDateString());
            Logging.Comment("Дата окончания отсутствия: "+ dtpEnd.Value.Date.ToShortDateString());
            Logging.VariableChange("Учесть в расчёте отпусков: ", (chbinCalc.Checked ? "Да" : "Нет"), (_inCalc ? "Да" : "Нет"));            
            Logging.VariableChange("Комментарий: ", tbComment.Text, _comment, typeLog._string);
            Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                            + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
            Logging.StopFirstLevel();


            _inCalc = chbinCalc.Checked;            
            _comment = tbComment.Text;

            MessageBox.Show("Данные сохранены!", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }
    }
}
