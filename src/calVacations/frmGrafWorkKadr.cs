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
    public partial class frmGrafWorkKadr : Form
    {
        private DataTable dtData, dtDataAbcens;
        public frmGrafWorkKadr()
        {
            InitializeComponent();
            dgvHoli.AutoGenerateColumns = false;
            dgvAbsenc.AutoGenerateColumns = false;                
        }

        private void frmGrafWorkKadr_Load(object sender, EventArgs e)
        {
            tbFIO.Text = kadrInfo.FIO;
            dtpStart.Value = DateTime.Now.AddYears(-1);
            dtpEnd.Value = DateTime.Now.AddMonths(4);
            getData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == new frmAddVacation().ShowDialog())
                getData();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (dtpStart.Value.Date > dtpEnd.Value.Date)
                    dtpEnd.Value = dtpStart.Value.Date;
            }
            catch
            { }
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                if (dtpStart.Value.Date > dtpEnd.Value.Date)
                    dtpStart.Value = dtpEnd.Value.Date;
            }
            catch
            { }

        }

        private void getData()
        {
            Task.Run(() => get_data());
        }

        private void DoOnUIThread(MethodInvoker d)
        {
            if (this.InvokeRequired) { this.Invoke(d); } else { d(); }
        }

        private async Task get_data()
        {
            DateTime dStart = DateTime.Now, dEnd = DateTime.Now;

            DoOnUIThread(delegate ()
            {
                try
                {
                    dStart = dtpStart.Value;
                    dEnd = dtpEnd.Value;
                    this.Enabled = false;

                    if (dStart == null || dEnd == null)
                    {
                        this.Enabled = true;
                        return;
                    }
                }
                catch
                {
                    this.Enabled = true;
                    return;
                }
            });

            try
            {

                if (dStart == null || dEnd == null)
                {
                    DoOnUIThread(delegate ()
                    {
                        this.Enabled = true;
                    });
                    return;
                }

                dtData = await Config.hCntMain.getContentVacation(kadrInfo.id_kadr, dStart, dEnd);
                dtDataAbcens = await Config.hCntMain.getDayAbsence(kadrInfo.id_kadr, dStart, dEnd);
            }
            catch
            {
                DoOnUIThread(delegate ()
                {
                    this.Enabled = true;
                });
                return;
            }

            DoOnUIThread(delegate ()
                {
                    if (dtData != null && dtData.Rows.Count > 0)
                    {
                        dgvHoli.DataSource = dtData;
                        dtData.DefaultView.Sort = "DataStartVacation desc";
                        btPrint.Enabled = btEdit.Enabled = btDel.Enabled = true;
                    }
                    else
                    {
                        dgvHoli.DataSource = null;
                        btPrint.Enabled = btEdit.Enabled = btDel.Enabled = false;
                    }

                    if (dtDataAbcens != null && dtDataAbcens.Rows.Count > 0)
                    {
                        dgvAbsenc.DataSource = dtDataAbcens;
                        dtDataAbcens.DefaultView.Sort = "DataStartAbsence desc";
                        btEditAbsenc.Enabled = btReportAbcent.Enabled = true;
                    }
                    else
                    {
                        dgvAbsenc.DataSource = null;
                        btEditAbsenc.Enabled = btReportAbcent.Enabled = false;
                    }
                });

            DoOnUIThread(delegate ()
            { this.Enabled = true; });

        }

        private void btEditAbsenc_Click(object sender, EventArgs e)
        {
            if (dtDataAbcens == null || dtDataAbcens.DefaultView.Count == 0) return;
            int id = (int)dtDataAbcens.DefaultView[dgvAbsenc.CurrentRow.Index]["id"];

            if (DialogResult.OK == new frmUnWorkKadr() { id = id }.ShowDialog())
                getData();
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (dtData == null || dtData.DefaultView.Count == 0) return;

            int id = (int)dtData.DefaultView[dgvHoli.CurrentRow.Index]["id"];



            DataTable dtTmp = Config.hCntMain.getSingleContentVacation(id);

            if (dtTmp == null) return;
            if (dtTmp.Rows.Count == 0)
            {
                MessageBox.Show("Запись удалена другим пользователем","Удалить запись",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                getData();
                return;
            }


                if (DialogResult.Yes == MessageBox.Show(Config.centralText("Удалить выбранную запись?\n\nВнимание! Для предотвращения потери информации\nоперация удаления логируется.\n"), "Удаление записи", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                                
                DateTime _dtpStart = new DateTime();
                if (dtData.DefaultView[dgvHoli.CurrentRow.Index]["DataStartVacation"] != DBNull.Value)
                {
                    _dtpStart = (DateTime)dtData.Rows[0]["DataStartVacation"];                    
                }

                int _nudCount = 1;
                if (dtData.DefaultView[dgvHoli.CurrentRow.Index]["CountVacation"] != DBNull.Value)
                {
                    _nudCount = int.Parse(dtData.Rows[0]["CountVacation"].ToString());                    
                }

                bool _chbPay = false;
                if (dtData.DefaultView[dgvHoli.CurrentRow.Index]["isPaid"] != DBNull.Value)
                {
                    _chbPay = (bool)dtData.Rows[0]["isPaid"];                  
                }

                bool _chbCompinsation = false;
                if(dtData.DefaultView[dgvHoli.CurrentRow.Index]["isCompensatory"] != DBNull.Value)
                {
                    _chbCompinsation = (bool)dtData.Rows[0]["isCompensatory"];                    
                }

                string _comment = "";
                if (dtData.DefaultView[dgvHoli.CurrentRow.Index]["Comment"] != DBNull.Value)
                {
                    _comment = (string)dtData.Rows[0]["Comment"];                    
                }



                Logging.StartFirstLevel(1489);

                Logging.Comment("Произведено удаление записи об отпуске на форме «Список отпусков и отсутствий сотрудника»");

                Logging.Comment("Сотрудник ID:" + kadrInfo.id_kadr + "; ФИО: " + kadrInfo.FIO);
                Logging.Comment("Дата начала отпуска: " + _dtpStart.ToShortDateString());
                Logging.Comment("Продолжительность: " + _nudCount.ToString());
                Logging.Comment("Отпуск оплачен: " + (_chbPay ? "Да" : "Нет"));
                Logging.Comment("Компенсация: " + (_chbCompinsation ? "Да" : "Нет"));
                Logging.Comment("Комментарий: " + _comment.Trim());
               
                Logging.StopFirstLevel();

               

                Config.hCntMain.setSingleContentVacation(id, kadrInfo.id_kadr, _nudCount, _dtpStart, _chbPay, _chbCompinsation, _comment, true);
                getData();
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {

            if (dtData == null || dtData.DefaultView.Count == 0) return;

            Logging.StartFirstLevel(79);
            Logging.Comment("Произведена выгрузка отчёта по отпускам сотрудника:");
            Logging.Comment("Период с " + dtpStart.Value.ToShortDateString() + " по " + dtpEnd.Value.ToShortDateString());
            Logging.Comment("Сотрудник ID:" + kadrInfo.id_kadr + "; ФИО: " + kadrInfo.FIO);
            Logging.Comment("Отдел: " + kadrInfo.nameDep);
            Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                            + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
            Logging.StopFirstLevel();

            Nwuram.Framework.ToExcelNew.ExcelUnLoad report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad();

            int indexRow = 1;

            report.Merge(indexRow, 1, indexRow, 5);
            report.AddSingleValue("Отчёт по отпускам сотрудника", indexRow, 1);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
            report.SetFontBold(indexRow, 1, indexRow, 1);
            report.SetFontSize(indexRow, 1, indexRow, 1, 16);
            indexRow++;
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 3);
            report.AddSingleValue("Период с " + dtpStart.Value.ToShortDateString() + " по " + dtpEnd.Value.ToShortDateString(), indexRow, 1);

            report.Merge(indexRow, 4, indexRow, 5);
            report.AddSingleValue("Выгрузил: " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername, indexRow, 4);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 3);
            report.AddSingleValue("ФИО: " + tbFIO.Text.Trim(), indexRow, 1);

            report.Merge(indexRow, 4, indexRow, 5);
            report.AddSingleValue("Дата выгрузки: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), indexRow, 4);
            indexRow++;
            indexRow++;

            int indexCol = 0;
            foreach (DataGridViewColumn col in dgvHoli.Columns)
            {
                if (col.Visible)
                {
                    indexCol++;
                    report.AddSingleValue(col.HeaderText, indexRow, indexCol);
                }
            }
            report.SetBorders(indexRow, 1, indexRow, indexCol);
            report.SetFontBold(indexRow, 1, indexRow, indexCol);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, indexCol);
            indexRow++;

            foreach (DataRowView row in dtData.DefaultView)
            {

                report.AddSingleValueObject(((DateTime)row["DataStartVacation"]).ToShortDateString(), indexRow, 1);
                report.AddSingleValueObject(row["CountVacation"], indexRow, 2);
                report.AddSingleValueObject((bool)row["isPaid"] ? "V" : "", indexRow, 3);
                report.AddSingleValueObject((bool)row["isCompensatory"] ? "V" : "", indexRow, 4);
                report.AddSingleValueObject(row["Comment"], indexRow, 5);
                


                report.SetBorders(indexRow, 1, indexRow, indexCol);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, indexCol);
                indexRow++;
            }

            report.SetColumnAutoSize(2, 1, indexRow, 7);
            report.SetPageSetup(1, 999, true);
            report.Show();
        }

        private void btReportAbcent_Click(object sender, EventArgs e)
        {
            if (dtDataAbcens == null || dtDataAbcens.DefaultView.Count == 0) return;


            Logging.StartFirstLevel(79);
            Logging.Comment("Произведена выгрузка отчёта по отсутствиям сотрудника:");
            Logging.Comment("Период с " + dtpStart.Value.ToShortDateString() + " по " + dtpEnd.Value.ToShortDateString());
            Logging.Comment("Сотрудник ID:" + kadrInfo.id_kadr + "; ФИО: " + kadrInfo.FIO);
            Logging.Comment("Отдел: " + kadrInfo.nameDep);
            Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                            + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
            Logging.StopFirstLevel();

            Nwuram.Framework.ToExcelNew.ExcelUnLoad report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad();

            int indexRow = 1;

            report.Merge(indexRow, 1, indexRow, 5);
            report.AddSingleValue("Отчёт по отсутствиям сотрудника", indexRow, 1);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
            report.SetFontBold(indexRow, 1, indexRow, 1);
            report.SetFontSize(indexRow, 1, indexRow, 1, 16);
            indexRow++;
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 2);
            report.AddSingleValue("Период с " + dtpStart.Value.ToShortDateString() + " по " + dtpEnd.Value.ToShortDateString(), indexRow, 1);

            report.Merge(indexRow, 3, indexRow, 4);
            report.AddSingleValue("Выгрузил: " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername, indexRow, 3);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 2);
            report.AddSingleValue("ФИО: " + tbFIO.Text.Trim(), indexRow, 1);

            report.Merge(indexRow, 3, indexRow, 4);
            report.AddSingleValue("Дата выгрузки: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), indexRow, 3);
            indexRow++;
            indexRow++;

            int indexCol = 0;
            foreach (DataGridViewColumn col in dgvAbsenc.Columns)
            {
                if (col.Visible)
                {
                    indexCol++;
                    report.AddSingleValue(col.HeaderText, indexRow, indexCol);
                }
            }
            report.SetBorders(indexRow, 1, indexRow, indexCol);
            report.SetFontBold(indexRow, 1, indexRow, indexCol);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, indexCol);
            indexRow++;

            foreach (DataRowView row in dtDataAbcens.DefaultView)
            {
                report.AddSingleValueObject(((DateTime)row["DataStartAbsence"]).ToShortDateString(), indexRow, 1);
                report.AddSingleValueObject(((DateTime)row["DataStopAbsence"]).ToShortDateString(), indexRow, 2);                
                report.AddSingleValueObject((bool)row["inCalc"] ? "V" : "", indexRow, 3);                
                report.AddSingleValueObject(row["Comment"], indexRow, 4);                

                report.SetBorders(indexRow, 1, indexRow, indexCol);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, indexCol);
                indexRow++;
            }

            report.SetColumnAutoSize(2, 1, indexRow, 4);
            report.Show();
        }

        private void dtpStart_CloseUp(object sender, EventArgs e)
        {
            getData();
        }

        private void dtpStart_Leave(object sender, EventArgs e)
        {
            getData();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (dtData == null || dtData.DefaultView.Count == 0) return;
            int id = (int)dtData.DefaultView[dgvHoli.CurrentRow.Index]["id"];

            if (DialogResult.OK == new frmAddVacation() { id = id }.ShowDialog())
                getData();
        }
       
    }
}
