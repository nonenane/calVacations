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
    public partial class frmInserDateStartCalculation : Form
    {
        public frmInserDateStartCalculation()
        {
            InitializeComponent();
        }

        private void frmInserDateStartCalculation_Load(object sender, EventArgs e)
        {
            dtpDate.MinDate = kadrInfo.dateEmploy;
            if (kadrInfo.StartCalculation != DBNull.Value)
            {
                dtpDate.MinDate =(DateTime)kadrInfo.StartCalculation;
            }

            if (kadrInfo.id_WorkStatus == 5 && kadrInfo.dateUnEmploy != null)
                dtpDate.MaxDate = kadrInfo.dateUnEmploy.Value;

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private DataTable dtHoliday, dtWorkTime, dtContenctVacation,dtDateAbsence, dtDateAbsence_new, dtDateAbsenceMonthSort,dtResultTable;
        private DataTable dtContenctVacation_IsPaid, dtContenctVacation_IsNotPaid, dtContenctVacation_IsCompinsation, dtDateAbsenceMonthSortIsCalNo;

        private decimal settingsDay = (decimal)28.3;
        private int yearDays = 28;
        private void btStart_Click(object sender, EventArgs e)
        {
            DataTable dtNowDate;
            DateTime sDate = dtpDate.MinDate.AddDays(1 - dtpDate.MinDate.Day);
            DateTime eDate = dtpDate.Value.Date.AddDays(1 - dtpDate.Value.Day);
            DateTime tmpDate = sDate;
            DateTime nowDate = new DateTime();

            #region "Проверка что отработал год"
            if (dtpDate.Value.Date < kadrInfo.dateEmploy.Date.AddDays(365))
            {
                int countMonth = 0;
                tmpDate = kadrInfo.dateEmploy.Date.AddDays(1 - dtpDate.Value.Day);
                while (eDate > tmpDate)
                {
                    countMonth++;
                    tmpDate = tmpDate.AddMonths(1);
                };

                if (countMonth == 0)
                {
                    MessageBox.Show(Config.centralText("У сотрудника нет доступных\nдней для отпуска\n"), "Расчёт доступных дней отпуска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (DialogResult.No == MessageBox.Show(Config.centralText("Сотрудник отработал менее года\n - " + getLitterMonth(countMonth) + "."
                    + "\nПродолжить расчёт допустимых\nотпускных дней\n"), "Проверка стажа сотрудника", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    MessageBox.Show("Расчёт отпуска прерван пользоватем.", "Расчёт отпуска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }          
            }

            //Task<DataTable> task = Config.hCntMain.getContentVacation(kadrInfo.id_kadr, null, null);
            //task.Wait();
            //DataTable dtTmp = task.Result;
            //if (dtTmp != null && dtTmp.Rows.Count > 0)
            //{
            //    EnumerableRowCollection<DataRow> rowCollections = dtTmp.AsEnumerable().Where(r => !r.Field<bool>("isPaid"));
            //    if (rowCollections.Count() > 0) 
            //    {
            //        MessageBox.Show(Config.centralText("У сотрудника присутствуют неоплаченные отпуска.\nТребуется принятие решения по неоплаченному отпуску.\nРасчёт отпускных дней невозможен.\n"), "Расчёт доступных дней отпуска", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            #endregion

            #region  "Получение данных по праздничным дням"
            Task<DataTable> dtData = Config.hCntMain.getHolidaysForDate(dtpDate.MinDate, dtpDate.Value.Date);
            dtData.Wait();
            dtHoliday = dtData.Result;
            #endregion

            #region  "Получение текущей даты"
            dtData = Config.hCntMain.getDate();
            dtData.Wait();
            dtNowDate = dtData.Result;
            if (dtNowDate != null && dtNowDate.Rows.Count > 0)
                nowDate = ((DateTime)dtNowDate.Rows[0][0]).Date;
            #endregion

            #region "Получение данных по рабочим дням сотрудника"
            dtData = Config.hCntMain.getWorkTimeDataForKadrForDate(kadrInfo.id_kadr, dtpDate.MinDate, dtpDate.Value.Date);
            dtData.Wait();
            dtWorkTime = dtData.Result;
            #endregion

            #region "Расчёт промежутка отпуска с выходными днями"
            int countDayPay = 0;
            int countDayNotPay = 0;
            //dtData = Config.hCntMain.getContentVacation(kadrInfo.id_kadr, dtpDate.MinDate, dtpDate.Value.Date);
            dtData = Config.hCntMain.getContentVacation(kadrInfo.id_kadr, dtpDate.MinDate, null);
            dtData.Wait();
            dtContenctVacation = dtData.Result;

            
            dtContenctVacation_IsPaid = new DataTable();
            dtContenctVacation_IsNotPaid = new DataTable();
            dtContenctVacation_IsCompinsation = new DataTable();

            if (dtContenctVacation != null && dtContenctVacation.Rows.Count > 0)
            {
                object objSum = dtContenctVacation.Compute("SUM(CountVacation)", "isPaid = 1");
                if (objSum != null && objSum != DBNull.Value)
                    countDayPay = int.Parse(objSum.ToString());

                objSum = dtContenctVacation.Compute("SUM(CountVacation)", "");
                if (objSum != null && objSum != DBNull.Value)
                    countDayNotPay = int.Parse(objSum.ToString());

                dtContenctVacation_IsPaid = dtContenctVacation.Copy();
                dtContenctVacation_IsNotPaid = dtContenctVacation.Copy();
                dtContenctVacation_IsCompinsation = dtContenctVacation.Copy();

                dtContenctVacation.DefaultView.RowFilter = "isCompensatory = 0";
                dtContenctVacation = dtContenctVacation.DefaultView.ToTable().Copy();

                if (dtContenctVacation.Columns.Contains("isCompensatory"))
                    dtContenctVacation.Columns.Remove("isCompensatory");

                if (dtContenctVacation.Columns.Contains("Comment"))
                    dtContenctVacation.Columns.Remove("Comment");

                if (dtContenctVacation.Columns.Contains("isPaid"))
                    dtContenctVacation.Columns.Remove("isPaid");

                if (!dtContenctVacation.Columns.Contains("dateEnd"))
                    dtContenctVacation.Columns.Add("dateEnd", typeof(DateTime));

                //if (dtHoliday != null && dtHoliday.Rows.Count > 0 && dtContenctVacation != null && dtContenctVacation.Rows.Count > 0)
                if (dtContenctVacation != null && dtContenctVacation.Rows.Count > 0)
                {
                    foreach (DataRow row in dtContenctVacation.Rows)
                    {
                        DateTime _date_start = (DateTime)row["DataStartVacation"];
                        int _days = (int)row["CountVacation"];
                        DateTime _date_end = getEndDateVacation(_date_start, _days);
                        row["dateEnd"] = _date_end;
                    }
                }


                //New
                dtContenctVacation_IsPaid.DefaultView.RowFilter = "isPaid = 1";
                dtContenctVacation_IsPaid = dtContenctVacation_IsPaid.DefaultView.ToTable().Copy();
                modifTableEndDateVacation(dtContenctVacation_IsPaid);

                dtContenctVacation_IsNotPaid.DefaultView.RowFilter = "isPaid = 0";
                dtContenctVacation_IsNotPaid = dtContenctVacation_IsNotPaid.DefaultView.ToTable().Copy();
                modifTableEndDateVacation(dtContenctVacation_IsNotPaid);

                dtContenctVacation_IsCompinsation.DefaultView.RowFilter = "isCompensatory = 1";
                dtContenctVacation_IsCompinsation = dtContenctVacation_IsCompinsation.DefaultView.ToTable().Copy();
                modifTableEndDateVacation(dtContenctVacation_IsCompinsation);
                //
            }
            #endregion

            #region  "Получение данных по отсутствиям у сотрудника за период"
            dtData = Config.hCntMain.getDayAbsence(kadrInfo.id_kadr, dtpDate.MinDate, dtpDate.Value.Date);
            dtData.Wait();
            dtDateAbsence = dtData.Result;
            dtDateAbsence_new = dtDateAbsence.Clone();

            dtDateAbsenceMonthSort = dtDateAbsence_new.Clone();

            if (dtDateAbsenceMonthSort.Columns.Contains("id"))
                dtDateAbsenceMonthSort.Columns.Remove("id");

            if (dtDateAbsenceMonthSort.Columns.Contains("inCalc"))
                dtDateAbsenceMonthSort.Columns.Remove("inCalc");

            if (dtDateAbsenceMonthSort.Columns.Contains("Comment"))
                dtDateAbsenceMonthSort.Columns.Remove("Comment");

            dtDateAbsenceMonthSortIsCalNo = dtDateAbsenceMonthSort.Clone();

            #endregion

            #region  "Получение данных по настройкам кол-ва дней"
            dtData = Config.hCntMain.getSettings("kdps");
            dtData.Wait();
            DataTable dtSettings = dtData.Result;
            if (dtSettings != null && dtSettings.Rows.Count > 0)
            {
                settingsDay = decimal.Parse(dtSettings.Rows[0]["value"].ToString());
            }

            dtData = Config.hCntMain.getSettings("kdog");
            dtData.Wait();
            dtSettings = dtData.Result;
            if (dtSettings != null && dtSettings.Rows.Count > 0)
            {
                yearDays = int.Parse(dtSettings.Rows[0]["value"].ToString());
            }

            #endregion

            #region "Формирование списка пропущенных дней без учёта отпуска"

            sDate = dtpDate.MinDate;
            //sDate = dtpDate.MinDate.AddDays(1 - dtpDate.MinDate.Day);
            eDate = nowDate.Date > dtpDate.Value.Date ? dtpDate.Value.Date : nowDate.Date;
            //eDate = nowDate.Date;
            tmpDate = sDate;
            // Console.WriteLine("Начальная дата: " + sDate.ToShortDateString() + " Конечная дата: " + eDate.ToShortDateString());

            DateTime? dateStartAbsence = null, dateStopAbsence = null;
            bool flagDayAbsence = false;
            do
            {
                EnumerableRowCollection<DataRow> rowHoliday = dtHoliday.AsEnumerable().Where(r => r.Field<DateTime>("Date_Holiday").Date == tmpDate.Date);

                if (rowHoliday.Count() == 0 || (rowHoliday.Count() > 0 && (int)rowHoliday.First()["Status_Holiday"] == 0))
                {
                    // Console.WriteLine("Рабочий день: " + tmpDate.Date.ToShortDateString() + " - " + tmpDate.Date.DayOfWeek);

                    //EnumerableRowCollection<DataRow> rowWork = dtWorkTime.AsEnumerable().Where(r => (r.Field<object>("TimeIn")!=null && r.Field<DateTime>("TimeIn").Date == tmpDate.Date) || (r.Field<object>("TimeOut") != null && r.Field<DateTime>("TimeOut").Date == tmpDate.Date));

                    if (isComeToWork(tmpDate.Date))//Присутствовал
                    {
                        if (isNotWorkPreDate(tmpDate.Date))
                        {
                            if (flagDayAbsence)
                            {
                                insertDayAbsence(dateStartAbsence, tmpDate.Date);

                                flagDayAbsence = false;
                                dateStartAbsence = null;
                                dateStopAbsence = null;
                            }
                        }
                    }
                    else//Отсутствовал
                    {
                        //rowWork = dtContenctVacation.AsEnumerable().Where(r => r.Field<DateTime>("DataStartVacation").Date <= tmpDate.Date && tmpDate.Date <= r.Field<DateTime>("dateEnd").Date);
                        if (isVacationDay(tmpDate.Date))//Отпуск
                        {
                            if (isNotWorkPreDate(tmpDate.Date))
                            {
                                if (flagDayAbsence)
                                {
                                    insertDayAbsence(dateStartAbsence, tmpDate.Date);

                                    flagDayAbsence = false;
                                    dateStartAbsence = null;
                                    dateStopAbsence = null;
                                }
                            }
                        }
                        else //прогул дня не отпуск
                        {
                            if (flagDayAbsence)
                            {
                                dateStopAbsence = tmpDate.Date;
                                flagDayAbsence = true;
                            }
                            else
                            {
                                dateStartAbsence = tmpDate.Date;
                                dateStopAbsence = null;
                                flagDayAbsence = true;
                            }
                        }
                    }
                }
                //else
                //if (rowHoliday.Count() > 0 && (int)rowHoliday.First()["Status_Holiday"] == 1)
                //    Console.WriteLine("Праздничный день: " + tmpDate.Date.ToShortDateString() + " - " + tmpDate.Date.DayOfWeek);
                //else
                //if (DayOfWeek.Saturday.Equals(tmpDate.Date.DayOfWeek) || DayOfWeek.Sunday.Equals(tmpDate.Date.DayOfWeek))
                //    Console.WriteLine("Выходной день: " + tmpDate.Date.ToShortDateString() + " - " + tmpDate.Date.DayOfWeek);

                if (tmpDate.Date == eDate.AddDays(-1).Date)
                {
                    if (flagDayAbsence)
                    {
                        insertDayAbsence(dateStartAbsence, tmpDate.Date.AddDays(1));

                        dateStartAbsence = null;
                        dateStopAbsence = null;
                        flagDayAbsence = false;
                    }
                }

                tmpDate = tmpDate.AddDays(1);
            } while (eDate.Date > tmpDate.Date);
            //            } while (eDate > tmpDate);

            if (dtDateAbsence_new.Rows.Count > 0 || true)
            {
                EnumerableRowCollection<DataRow> rowFindCollection;
                foreach (DataRow r in dtDateAbsence.Rows)
                {
                    DateTime _start_find = (DateTime)r["DataStartAbsence"];
                    DateTime _end_find = (DateTime)r["DataStopAbsence"];

                    rowFindCollection = dtDateAbsence_new.AsEnumerable().Where(rf => rf.Field<DateTime>("DataStartAbsence").Date == _start_find.Date &&
                    rf.Field<DateTime>("DataStopAbsence").Date == _end_find.Date);

                    if (rowFindCollection.Count() > 0)
                    {
                        rowFindCollection.First().Delete();
                        dtDateAbsence_new.AcceptChanges();
                    }
                }

                if (kadrInfo.StartCalculation != DBNull.Value)
                {
                    DateTime StartCalculation = (DateTime)kadrInfo.StartCalculation;
                    rowFindCollection = dtDateAbsence_new.AsEnumerable().Where(rf => rf.Field<DateTime>("DataStartAbsence").Date == StartCalculation.AddDays(1 - StartCalculation.Day) &&
                        rf.Field<DateTime>("DataStopAbsence").Date == StartCalculation.AddDays(-1));
                }
                else
                {
                    rowFindCollection = dtDateAbsence_new.AsEnumerable().Where(rf => rf.Field<DateTime>("DataStartAbsence").Date == kadrInfo.dateEmploy.AddDays(1 - kadrInfo.dateEmploy.Day) &&
                   rf.Field<DateTime>("DataStopAbsence").Date == kadrInfo.dateEmploy.AddDays(-1));
                }

                if (rowFindCollection.Count() > 0)
                {
                    rowFindCollection.First().Delete();
                    dtDateAbsence_new.AcceptChanges();
                }

                //Уборка выходных с учётом разницы 1 дня
                if (dtDateAbsence_new.Rows.Count > 0)
                {
                    while (true)
                    {
                        rowFindCollection = dtDateAbsence_new.AsEnumerable()
                            .Where(r => DayOfWeek.Saturday.Equals(r.Field<DateTime>("DataStartAbsence").DayOfWeek) && DayOfWeek.Sunday.Equals(r.Field<DateTime>("DataStopAbsence").DayOfWeek) && (r.Field<DateTime>("DataStopAbsence").Date - r.Field<DateTime>("DataStartAbsence").Date).Days == 1);
                        if (rowFindCollection.Count() == 0) break;

                        rowFindCollection.First().Delete();

                    }
                }




                if (dtDateAbsence_new.Rows.Count > 0)
                {
                    if (DialogResult.Cancel == new frmCorrectionKadDate() { dtDateAbsence_new = dtDateAbsence_new }.ShowDialog())
                        return;
                }

                #region  "Получение данных по отсутствиям у сотрудника за период"
                dtData = Config.hCntMain.getDayAbsence(kadrInfo.id_kadr, dtpDate.MinDate, dtpDate.Value.Date);
                dtData.Wait();
                dtDateAbsence = dtData.Result;


                if (kadrInfo.StartCalculation != DBNull.Value)
                {
                    DateTime StartCalculation = (DateTime)kadrInfo.StartCalculation;
                    if (StartCalculation.Date.Day > 1)
                        dtDateAbsence.Rows.Add(0, StartCalculation.AddDays(1 - StartCalculation.Day), StartCalculation.AddDays(-1), false, "");
                }
                else
                {
                    if (kadrInfo.dateEmploy.Date.Day > 1)
                        dtDateAbsence.Rows.Add(0, kadrInfo.dateEmploy.AddDays(1 - kadrInfo.dateEmploy.Day), kadrInfo.dateEmploy.AddDays(-1), false, "");
                }
                #endregion

                dtDateAbsence.DefaultView.RowFilter = "inCalc  = 0";
                if (dtDateAbsence.DefaultView.Count > 0)
                {
                    foreach (DataRowView row in dtDateAbsence.DefaultView)
                    {
                        DateTime _start = (DateTime)row["DataStartAbsence"];
                        DateTime _end = (DateTime)row["DataStopAbsence"];

                        insertGroupMonthDayAbsebce(_start, _end);
                    }

                    //Test

                    //dtDateAbsenceMonthSort.Rows.Add(new DateTime(2016, 2, 16), new DateTime(2016, 2, 24));
                    //dtDateAbsenceMonthSort.Rows.Add(new DateTime(2019, 12, 16), new DateTime(2019, 12, 24));
                }


                dtDateAbsence.DefaultView.RowFilter = "inCalc  = 1";
                if (dtDateAbsence.DefaultView.Count > 0)
                {
                    foreach (DataRowView row in dtDateAbsence.DefaultView)
                    {
                        DateTime _start = (DateTime)row["DataStartAbsence"];
                        DateTime _end = (DateTime)row["DataStopAbsence"];

                        insertGroupMonthDayAbsebceIsCalNo(_start, _end);
                    }

                    //Test

                    //dtDateAbsenceMonthSort.Rows.Add(new DateTime(2016, 2, 16), new DateTime(2016, 2, 24));
                    //dtDateAbsenceMonthSort.Rows.Add(new DateTime(2019, 12, 16), new DateTime(2019, 12, 24));
                }

                

            }
            #endregion

            #region  "Расчёт дней отпуска без учёта отгуленных отпусков и начальных данных по отпуску"
            sDate = dtpDate.MinDate;
            eDate = dtpDate.Value.Date;
            tmpDate = sDate;
            createResultTable();


            //Console.WriteLine("Начальная дата: " + sDate.ToShortDateString() + " Конечная дата: " + eDate.ToShortDateString());
            if (sDate.Year == eDate.Year && sDate.Month == eDate.Month)
            {
                //тут проверка на время отсутствия
                validateDateForNotWork(sDate, eDate);
            }
            else
            {
                DateTime _startDate = new DateTime(tmpDate.Year, tmpDate.Month, sDate.Day);
                DateTime _EndDate = _startDate.AddMonths(1).AddDays(-_startDate.Day);

                do
                {
                    //Console.WriteLine("Дата: " + _startDate.Date.ToShortDateString() + " - " + _EndDate.Date.ToShortDateString());
                    //тут проверка на время отсутствия
                    validateDateForNotWork(_startDate, _EndDate);

                    tmpDate = tmpDate.AddMonths(1);

                    if (tmpDate.Year == eDate.Year && tmpDate.Month == eDate.Month)
                    {
                        _startDate = new DateTime(tmpDate.Year, tmpDate.Month, 1);
                        _EndDate = new DateTime(tmpDate.Year, tmpDate.Month, eDate.Day);
                        // Console.WriteLine("Дата: " + _startDate.Date.ToShortDateString() + " - " + _EndDate.Date.ToShortDateString());
                        validateDateForNotWork(_startDate, _EndDate);

                        break;
                    }

                    _startDate = new DateTime(tmpDate.Year, tmpDate.Month, 1);
                    _EndDate = _startDate.AddMonths(1).AddDays(-1);

                } while (true);
            }
          
            #endregion

            object objSumGlobal = dtResultTable.Compute("SUM(percent)", "");
            decimal countDay = 0;
            if (objSumGlobal != null && objSumGlobal != DBNull.Value)
            {
                countDay = Math.Round((((decimal)yearDays / (decimal)12) * decimal.Parse(objSumGlobal.ToString())), 2);
            }

            if (countDay == 0)
            {
                MessageBox.Show(Config.centralText("У сотрудника нет доступных\nдней для отпуска\n"), "Расчёт доступных дней отпуска", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Logging.StartFirstLevel(1512);
                Logging.Comment("Сотрудник ID:" + kadrInfo.id_kadr + "; ФИО: " + kadrInfo.FIO);
                Logging.Comment("Отдел: " + kadrInfo.nameDep);
                Logging.Comment("Дата, на которую рассчитывается отпуск сотрудника:" + dtpDate.Value.ToShortDateString());                
                Logging.Comment("Количество доступных дней отпуска для сотрудника: У сотрудника нет доступных\nдней для отпуска");

                if(kadrInfo.personalPersonnelType == 1)
                    Logging.Comment("Сотрудник переведен из универсама в офис");

                //Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                //                + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                Logging.StopFirstLevel();
            }
            else
            {
                decimal _dayWithPay = countDay - countDayPay + kadrInfo.countDay;
                decimal _dayWithOutPay = countDay - countDayNotPay + kadrInfo.countDay;


                Logging.StartFirstLevel(1512);                
                Logging.Comment("Сотрудник ID:" + kadrInfo.id_kadr + "; ФИО: " + kadrInfo.FIO);
                Logging.Comment("Отдел: " + kadrInfo.nameDep);
                Logging.Comment("Дата, на которую рассчитывается отпуск сотрудника:" + dtpDate.Value.ToShortDateString());
                if (_dayWithPay == _dayWithOutPay)
                    Logging.Comment("Количество доступных дней отпуска для сотрудника:" + _dayWithPay);
                else
                {
                    Logging.Comment("Количество доступных дней отпуска для сотрудника без учёта неоплаченных отпусков:" + _dayWithPay);
                    Logging.Comment("Количество доступных дней отпуска для сотрудника с учётом неоплаченных отпусков:" + _dayWithOutPay);
                }

                if (kadrInfo.personalPersonnelType == 1)
                    Logging.Comment("Сотрудник переведен из универсама в офис");

                //Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                                //+ " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
                Logging.StopFirstLevel();


                if (dtResultTable != null && dtResultTable.Rows.Count > 0)
                    new frmResultView() { dtData = dtResultTable.Copy(), _dayWithPay = _dayWithPay, 
                        _dayWithOutPay = _dayWithOutPay,
                        dtContenctVacation_IsPaid = dtContenctVacation_IsPaid.Copy(),
                        dtContenctVacation_IsNotPaid = dtContenctVacation_IsNotPaid.Copy(),
                        dtContenctVacation_IsCompinsation = dtContenctVacation_IsCompinsation.Copy(), 
                        dtDateAbsenceMonthSort = dtDateAbsenceMonthSort.Copy(),
                        dtDateAbsenceMonthSortIsCalNo = dtDateAbsenceMonthSortIsCalNo.Copy()
                    }.ShowDialog();


                //if (_dayWithPay == _dayWithOutPay)
                //    MessageBox.Show("У сотрудника доступных дней отпуска " + _dayWithPay, "Расчёт доступных дней отпуска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //else
                //    MessageBox.Show(Config.centralText("У сотрудника доступных дней отпуска:\n- Без учёта неоплаченных отпусков - " + _dayWithPay
                //        + "\n- с учётом неоплаченных отпусков - " + _dayWithOutPay + "\n"), "Расчёт доступных дней отпуска", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void modifTableEndDateVacation(DataTable dtData)
        {
            if (dtData.Columns.Contains("isCompensatory"))
                dtData.Columns.Remove("isCompensatory");

            if (dtData.Columns.Contains("Comment"))
                dtData.Columns.Remove("Comment");

            if (dtData.Columns.Contains("isPaid"))
                dtData.Columns.Remove("isPaid");

            if (!dtData.Columns.Contains("dateEnd"))
                dtData.Columns.Add("dateEnd", typeof(DateTime));

            //if (dtHoliday != null && dtHoliday.Rows.Count > 0 && dtData != null && dtData.Rows.Count > 0)
            if (dtData != null && dtData.Rows.Count > 0)
            {
                foreach (DataRow row in dtData.Rows)
                {
                    DateTime _date_start = (DateTime)row["DataStartVacation"];
                    int _days = (int)row["CountVacation"];
                    DateTime _date_end = getEndDateVacation(_date_start, _days);
                    row["dateEnd"] = _date_end;
                }
            }
        }

        private string getLitterMonth(int number)
        {
            switch (number)
            {
                case 0: return "ноль месяцев"; break;
                case 1: return "один месяц"; break;
                case 2: return "два месяца"; break;
                case 3: return "три месяца"; break;
                case 4: return "четыре месяца"; break;
                case 5: return "пять месяцев"; break;
                case 6: return "шесть месяцев"; break;
                case 7: return "семь месяцев"; break;
                case 8: return "восемь месяцев"; break;
                case 9: return "девять месяце"; break;
                case 10: return "десять месяцев"; break;
                case 11: return "одинадцать месяцев"; break;
                case 12: return "двенадцать месяцев"; break;
                default: return ""; break;
            }
        }

        private DateTime getEndDateVacation(DateTime _date_start, int _days)
        {
            DateTime _date_end = _date_start.AddDays(_days - 1);

            if (dtHoliday == null || dtHoliday.Rows.Count == 0)
            {
                return _date_end;
            }

            EnumerableRowCollection<DataRow> rowsHoliday = dtHoliday.AsEnumerable().Where(r => r.Field<int>("Status_Holiday") == 1
            && r.Field<DateTime>("Date_Holiday") >= _date_start && r.Field<DateTime>("Date_Holiday") <= _date_end);

            if (rowsHoliday.Count() > 0)
            {
                _date_end = getEndDateVacation(_date_end.AddDays(1), rowsHoliday.Count());
            }

            return _date_end;
        }

        private bool isNotWorkPreDate(DateTime tmpDate)
        {
            EnumerableRowCollection<DataRow> rowWork = dtWorkTime.AsEnumerable().Where(r => (r.Field<object>("TimeIn") != null && r.Field<DateTime>("TimeIn").Date == tmpDate.Date.AddDays(-1)) || (r.Field<object>("TimeOut") != null && r.Field<DateTime>("TimeOut").Date == tmpDate.Date.AddDays(-1)));

            return rowWork.Count() == 0;
        }

        private bool isComeToWork(DateTime tmpDate)
        {
            EnumerableRowCollection<DataRow> rowWork = dtWorkTime.AsEnumerable().Where(r => (r.Field<object>("TimeIn") != null && r.Field<DateTime>("TimeIn").Date == tmpDate.Date) || (r.Field<object>("TimeOut") != null && r.Field<DateTime>("TimeOut").Date == tmpDate.Date));

            return rowWork.Count() != 0;
        }

        private bool isVacationDay(DateTime tmpDate)
        {
            EnumerableRowCollection<DataRow> rowWork = dtContenctVacation.AsEnumerable().Where(r => r.Field<DateTime>("DataStartVacation").Date <= tmpDate.Date && tmpDate.Date <= r.Field<DateTime>("dateEnd").Date);

            return rowWork.Count() != 0;
        }

        private void insertDayAbsence(DateTime? dateStartAbsence, DateTime? dateStopAbsence)
        {
            dateStopAbsence = dateStopAbsence.Value.AddDays(-1);
            int _count_day_for_validate = (dateStopAbsence - dateStartAbsence).Value.Days + 1;
            if (settingsDay <= _count_day_for_validate)
                dtDateAbsence_new.Rows.Add(0, dateStartAbsence, dateStopAbsence, false, "");
        }

        private void insertGroupMonthDayAbsebce(DateTime _start, DateTime _end)
        {
            DateTime sDate = _start;
            DateTime eDate = _end;
            DateTime tmpDate = sDate;

            DateTime _startDate = new DateTime(tmpDate.Year, tmpDate.Month, sDate.Day);
            DateTime _EndDate = _startDate.AddMonths(1).AddDays(-sDate.Day);

            //Console.WriteLine("Начальная дата: " + sDate.ToShortDateString() + " Конечная дата: " + eDate.ToShortDateString());

            if (_start.Year == _end.Year && _start.Month == _end.Month)
            {
                dtDateAbsenceMonthSort.Rows.Add(_start, _end);
            }
            else
            {
                do
                {
                    //Console.WriteLine("Дата: " + _startDate.Date.ToShortDateString() + " - " + _EndDate.Date.ToShortDateString());
                    dtDateAbsenceMonthSort.Rows.Add(_startDate, _EndDate);

                    tmpDate = tmpDate.AddMonths(1);

                    if (tmpDate.Year == eDate.Year && tmpDate.Month == eDate.Month)
                    {
                        _startDate = new DateTime(tmpDate.Year, tmpDate.Month, 1);
                        _EndDate = new DateTime(tmpDate.Year, tmpDate.Month, eDate.Day);
                        dtDateAbsenceMonthSort.Rows.Add(_startDate, _EndDate);
                                                                
                        //Console.WriteLine("Дата: " + _startDate.Date.ToShortDateString() + " - " + _EndDate.Date.ToShortDateString());
                        break;
                    }

                    _startDate = new DateTime(tmpDate.Year, tmpDate.Month, 1);
                    _EndDate = _startDate.AddMonths(1).AddDays(-1);

                } while (true);
            }
        }

        private void validateDateForNotWork(DateTime _start, DateTime _end)
        {
            if (dtDateAbsenceMonthSort == null) return;

            EnumerableRowCollection<DataRow> rowCollection = dtDateAbsenceMonthSort.AsEnumerable().Where(r => r.Field<DateTime>("DataStartAbsence").Month == _start.Month
                && r.Field<DateTime>("DataStartAbsence").Year == _start.Year);
            int countDay = 0;

            if (rowCollection.Count() > 0)
            {              
                foreach (DataRow row in rowCollection)
                {
                    DateTime _startDatAbsence = (DateTime)row["DataStartAbsence"];
                    DateTime _endDatAbsence = (DateTime)row["DataStopAbsence"];

                    if (_startDatAbsence.Equals(_start) && _endDatAbsence.Equals(_end))
                    {
                        countDay = (_endDatAbsence - _startDatAbsence).Days + 1;
                        break;
                    }
                    else
                    {
                        countDay += (_endDatAbsence - _startDatAbsence).Days + 1;
                    }
                }               
            }

            if (countDay != 0)
            {
                //int countDayMonth = (new DateTime(_start.Year, _start.Month, 1).AddMonths(1).AddDays(-1) - new DateTime(_start.Year, _start.Month, 1)).Days + 1;
                //int countDayMonth = (new DateTime(_end.Year, _end.Month, _end.Day) - new DateTime(_start.Year, _start.Month, _start.Day)).Days + 1;

                //int countDayMonth = (new DateTime(_start.Year, _start.Month, 1).AddMonths(1).AddDays(-1) - new DateTime(_start.Year, _start.Month, _start.Day)).Days + 1;
                //int countWorkDayToEndDate = (new DateTime(_end.Year, _end.Month, _end.Day) - new DateTime(_start.Year, _start.Month, _start.Day)).Days + 1;


                int countDayMonth = (new DateTime(_start.Year, _start.Month, 1).AddMonths(1).AddDays(-1) - new DateTime(_start.Year, _start.Month, 1)).Days + 1;
                int countWorkDayToEndDate = (new DateTime(_end.Year, _end.Month, _end.Day) - new DateTime(_start.Year, _start.Month, 1)).Days + 1;                
                int resultWorkDay = countDayMonth - countDay;

                if (countDayMonth != countWorkDayToEndDate)
                    resultWorkDay = countWorkDayToEndDate - countDay;

                if (resultWorkDay < 0)
                    resultWorkDay = 0;

                decimal _workDays = Math.Round(decimal.Parse(resultWorkDay.ToString()) / decimal.Parse(countDayMonth.ToString()), 2);
                
                dtResultTable.Rows.Add(new DateTime(_start.Year, _start.Month, 1), _workDays);                
            }
            else
            {
                int countDayMonth = (new DateTime(_start.Year, _start.Month, 1).AddMonths(1).AddDays(-1) - new DateTime(_start.Year, _start.Month, _start.Day)).Days + 1;
                int countWorkDayToEndDate = (new DateTime(_end.Year, _end.Month, _end.Day) - new DateTime(_start.Year, _start.Month, _start.Day)).Days + 1;

                int resultWorkDay = countDayMonth - countDay;

                if (countDayMonth != countWorkDayToEndDate)
                    resultWorkDay = countWorkDayToEndDate;
                
                if (resultWorkDay < 0)
                    resultWorkDay = 0;


                decimal _workDays = Math.Round(decimal.Parse(resultWorkDay.ToString()) / decimal.Parse(countDayMonth.ToString()), 2);




                dtResultTable.Rows.Add(new DateTime(_start.Year, _start.Month, 1), _workDays);
            }


        }

        private void createResultTable()
        {
            dtResultTable = new DataTable();
            dtResultTable.Columns.Add("date", typeof(DateTime));
            dtResultTable.Columns.Add("percent", typeof(decimal));
            dtResultTable.AcceptChanges();
        }

        private void insertGroupMonthDayAbsebceIsCalNo(DateTime _start, DateTime _end)
        {
            DateTime sDate = _start;
            DateTime eDate = _end;
            DateTime tmpDate = sDate;

            DateTime _startDate = new DateTime(tmpDate.Year, tmpDate.Month, sDate.Day);
            DateTime _EndDate = _startDate.AddMonths(1).AddDays(-sDate.Day);

            //Console.WriteLine("Начальная дата: " + sDate.ToShortDateString() + " Конечная дата: " + eDate.ToShortDateString());

            if (_start.Year == _end.Year && _start.Month == _end.Month)
            {
                dtDateAbsenceMonthSortIsCalNo.Rows.Add(_start, _end);
            }
            else
            {
                do
                {
                    //Console.WriteLine("Дата: " + _startDate.Date.ToShortDateString() + " - " + _EndDate.Date.ToShortDateString());
                    dtDateAbsenceMonthSortIsCalNo.Rows.Add(_startDate, _EndDate);

                    tmpDate = tmpDate.AddMonths(1);

                    if (tmpDate.Year == eDate.Year && tmpDate.Month == eDate.Month)
                    {
                        _startDate = new DateTime(tmpDate.Year, tmpDate.Month, 1);
                        _EndDate = new DateTime(tmpDate.Year, tmpDate.Month, eDate.Day);
                        dtDateAbsenceMonthSortIsCalNo.Rows.Add(_startDate, _EndDate);

                        //Console.WriteLine("Дата: " + _startDate.Date.ToShortDateString() + " - " + _EndDate.Date.ToShortDateString());
                        break;
                    }

                    _startDate = new DateTime(tmpDate.Year, tmpDate.Month, 1);
                    _EndDate = _startDate.AddMonths(1).AddDays(-1);

                } while (true);
            }
        }

    }
}
