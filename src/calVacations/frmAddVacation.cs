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
    public partial class frmAddVacation : Form
    {
        public int id { set; private get; }

        public frmAddVacation()
        {
            InitializeComponent();
            nudCount.TextChanged += new EventHandler(numericUpDown_TextChanged);                    
        }

        private void frmAddVacation_Load(object sender, EventArgs e)
        {
            this.Text = id == 0 ? "Добавить отпуск сотрудника" : "Редактировать отпуск сотрудника";
            
            dtpStart.MinDate = kadrInfo.dateEmploy;
            if (kadrInfo.StartCalculation != DBNull.Value)
            {
                ///<!--Попросила Люда 09.06.2020-->
                //dtpStart.MinDate = (DateTime)kadrInfo.StartCalculation;
            }

            tbFIO.Text = kadrInfo.FIO;

            if (id != 0)
            {
                Task.Run(() => get_data());
            }
            else
            {
                _dtpStart = dtpStart.Value;
                _nudCount = nudCount.Value;
                _chbPay = chbPay.Checked;
                _chbCompinsation = chbCompinsation.Checked;
                _comment = tbComment.Text;
                enButtonSave();
            }            
        }

        private void DoOnUIThread(MethodInvoker d)
        {
            if (this.InvokeRequired) { this.Invoke(d); } else { d(); }
        }

        private async Task get_data()
        {
            DoOnUIThread(delegate ()
            { this.Enabled = false; });

            DataTable dtData = await Config.hCntMain.getSingleContentVacationAsync(id);
            if (dtData != null && dtData.Rows.Count > 0)
                DoOnUIThread(delegate ()
                {                 
                    if (dtData.Rows[0]["DataStartVacation"] != DBNull.Value)
                    {
                        dtpStart.Value = (DateTime)dtData.Rows[0]["DataStartVacation"];
                        _dtpStart = dtpStart.Value;                    
                    }

                    if (dtData.Rows[0]["CountVacation"] != DBNull.Value)
                    {
                        nudCount.Value = decimal.Parse(dtData.Rows[0]["CountVacation"].ToString());
                        _nudCount = nudCount.Value;                        
                    }

                    if (dtData.Rows[0]["isPaid"] != DBNull.Value)
                    {
                        chbPay.Checked = (bool)dtData.Rows[0]["isPaid"];
                        _chbPay = chbPay.Checked;
                        //        startDate = dtpDate.Value;
                    }

                    if (dtData.Rows[0]["isCompensatory"] != DBNull.Value)
                    {
                        chbCompinsation.Checked = (bool)dtData.Rows[0]["isCompensatory"];
                        _chbCompinsation = chbCompinsation.Checked;
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
            { 
                this.Enabled = true;
                enButtonSave();
            });

        }

        private void numericUpDown_TextChanged(object sender, EventArgs e)
        {
            NumericUpDown _nud = (NumericUpDown)sender;
            if (String.IsNullOrEmpty(_nud.Text))
            {
                _nud.Value = 0;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (int.Parse(nudCount.Value.ToString("0")) == 0)
            {
                MessageBox.Show("Необходимо указать продолжительность отпуска","Сохранение",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            if (id != 0)
                if (DialogResult.No == MessageBox.Show("Вы уверены, что хотите откорректировать отпуск?", "Сохранение отпуска", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)) return;
            


            Task<DataTable> dtData = Config.hCntMain.getHolidaysForDate(dtpStart.MinDate, dtpStart.Value.Date);
            dtData.Wait();
            dtHoliday = dtData.Result;

            DataTable dtVacation;
            dtData = Config.hCntMain.getContentVacation(kadrInfo.id_kadr, null, null);
            dtVacation = dtData.Result;


            DateTime dStart = dtpStart.Value.Date;
            DateTime dEnd = getEndDateVacation(dtpStart.Value.Date, int.Parse(nudCount.Value.ToString()));

            if (dtVacation != null && dtVacation.Rows.Count > 0)
            {
                DataTable dtTmpDateVacation = new DataTable();
                dtTmpDateVacation.Columns.Add("startDate", typeof(DateTime));
                dtTmpDateVacation.Columns.Add("endDate", typeof(DateTime));
                dtTmpDateVacation.AcceptChanges();
                EnumerableRowCollection<DataRow> rowCollection = dtVacation.AsEnumerable().Where(r => r.Field<int>("id") != id);
                foreach (DataRow r in rowCollection)
                {
                    DateTime tmpDate = (DateTime)r["DataStartVacation"];
                    int tmpDays = (int)r["CountVacation"];
                    dtTmpDateVacation.Rows.Add(tmpDate, getEndDateVacation(tmpDate, tmpDays));
                }

                rowCollection = dtTmpDateVacation.AsEnumerable()
                    .Where(r =>
                    (r.Field<DateTime>("startDate").Date <= dStart.Date && dStart.Date <= r.Field<DateTime>("endDate").Date)
                    || (r.Field<DateTime>("startDate").Date <= dEnd.Date && dEnd.Date <= r.Field<DateTime>("endDate").Date)
                    || (dStart.Date <= r.Field<DateTime>("startDate").Date && r.Field<DateTime>("startDate").Date <= dEnd.Date)
                    || (dStart.Date <= r.Field<DateTime>("endDate").Date && r.Field<DateTime>("endDate").Date <= dEnd.Date)
                    );

                if (rowCollection.Count() > 0)
                {
                    MessageBox.Show("Данный период уже присутсвует в списке отпусков", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            Config.hCntMain.setSingleContentVacation(id, kadrInfo.id_kadr, int.Parse(nudCount.Value.ToString("0")), dtpStart.Value, chbPay.Checked, chbCompinsation.Checked,tbComment.Text.Trim(), false);

            if (id == 0)
            {
                Logging.StartFirstLevel(1509);
                Logging.Comment("Сотрудник ID:" + kadrInfo.id_kadr + "; ФИО: " + kadrInfo.FIO);
                Logging.Comment("Отдел: " + kadrInfo.nameDep);
                Logging.Comment("Дата начала отпуска: " + dtpStart.Value.Date.ToShortDateString());
                Logging.Comment("Продолжительность отпуска: " + decimal.Parse(nudCount.Value.ToString()));
                Logging.Comment("Отпуск оплачен: " + (chbPay.Checked ? "Да" : "Нет"));
                Logging.Comment("Компенсация: " + (chbCompinsation.Checked ? "Да" : "Нет"));
                Logging.Comment("Комментарий: " + tbComment.Text);
                Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                                + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                Logging.StopFirstLevel();
            }
            else
            {
                Logging.StartFirstLevel(1510);
                Logging.Comment("Сотрудник ID:" + kadrInfo.id_kadr + "; ФИО: " + kadrInfo.FIO);
                Logging.Comment("Отдел: " + kadrInfo.nameDep);
                Logging.VariableChange("Дата начала отпуска: ", dtpStart.Value.Date.ToShortDateString(), _dtpStart.Date.ToShortDateString());
                Logging.VariableChange("Продолжительность отпуска: " , decimal.Parse(nudCount.Value.ToString()), _nudCount, typeLog._decimal);
                Logging.VariableChange("Отпуск оплачен: " , (chbPay.Checked ? "Да" : "Нет"), (_chbPay ? "Да" : "Нет"));
                Logging.VariableChange("Компенсация: " , (chbCompinsation.Checked ? "Да" : "Нет"), (_chbCompinsation ? "Да" : "Нет"));
                Logging.VariableChange("Комментарий: ", tbComment.Text, _comment, typeLog._string);
                Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                                + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                Logging.StopFirstLevel();
            }

            _dtpStart = dtpStart.Value;
            _nudCount = nudCount.Value;
            _chbPay = chbPay.Checked;
            _chbCompinsation = chbCompinsation.Checked;
            _comment = tbComment.Text;

            MessageBox.Show("Данные сохранены!", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private decimal _nudCount;
        private DateTime _dtpStart;
        private bool _chbPay, _chbCompinsation;
        private string _comment;

        private void chbPay_CheckedChanged(object sender, EventArgs e)
        {
            enButtonSave();
        }

        private void frmAddVacation_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (_nudCount != nudCount.Value || _dtpStart != dtpStart.Value || _chbPay != chbPay.Checked || _chbCompinsation != chbCompinsation.Checked || _comment != tbComment.Text) 
                && DialogResult.No == MessageBox.Show(Config.centralText("На форме есть несохраненные данные.\nЗакрыть форму без сохранения данных?\n"), "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private void nudCount_ValueChanged(object sender, EventArgs e)
        {
            enButtonSave();
        }

        private void tbComment_TextChanged(object sender, EventArgs e)
        {
            enButtonSave();
        }

        private void enButtonSave()
        {
            btSave.Enabled = (_nudCount != nudCount.Value || _dtpStart != dtpStart.Value || _chbPay != chbPay.Checked || _chbCompinsation != chbCompinsation.Checked || _comment != tbComment.Text) && (int.Parse(nudCount.Value.ToString("0")) != 0);
        }

        private DataTable dtHoliday;

        private void nudCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b';
        }

        private DateTime getEndDateVacation(DateTime _date_start, int _days)
        {
            DateTime _date_end = _date_start.AddDays(_days - 1);

            EnumerableRowCollection<DataRow> rowsHoliday = dtHoliday.AsEnumerable().Where(r => r.Field<int>("Status_Holiday") == 1
            && r.Field<DateTime>("Date_Holiday") >= _date_start && r.Field<DateTime>("Date_Holiday") <= _date_end);

            if (rowsHoliday.Count() > 0)
            {
                _date_end = getEndDateVacation(_date_end.AddDays(1), rowsHoliday.Count());
            }

            return _date_end;
        }
    }
}
