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
    public partial class frmResultView : Form
    {
        public DataTable dtData { set; get; }
        //public DataTable dtContenctVacation { set; private get; }
        public DataTable dtContenctVacation_IsPaid { set; private get; }
        public DataTable dtContenctVacation_IsNotPaid { set; private get; }
        public DataTable dtContenctVacation_IsCompinsation { set; private get; }

        public DataTable dtDateAbsenceMonthSort { set; private get; }
        public DataTable dtDateAbsenceMonthSortIsCalNo { set; private get; }
        public decimal _dayWithPay { set; private get; }
        public decimal _dayWithOutPay { set; private get; }

        public frmResultView()
        {
            InitializeComponent();
            dgvAbsenc.AutoGenerateColumns = false;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmResultView_Load(object sender, EventArgs e)
        {
            int yearDays = 28;
            Task<DataTable> task = Config.hCntMain.getSettings("kdog");
            task.Wait();
            DataTable dtSettings = task.Result;
            if (dtSettings != null && dtSettings.Rows.Count > 0)
            {
                yearDays = int.Parse(dtSettings.Rows[0]["value"].ToString());
            }


            tbFio.Text = kadrInfo.FIO;
            tbDayWithPay.Text = _dayWithPay.ToString("0.00");
            tbDayWithOutPay.Text = _dayWithOutPay.ToString("0.00");
            lDayWithOutPay.Visible = tbDayWithOutPay.Visible = _dayWithPay != _dayWithOutPay;
            dayOnMonthVacation();

            dgvAbsenc.DataSource = dtData;

            object objSum = dtData.Compute("SUM(percent)", "");
            if (objSum != null && objSum != DBNull.Value)
            {
                tbCountMonth.Text = decimal.Parse(objSum.ToString()).ToString("0.00");
                tbCountDays.Text = (((decimal)yearDays / (decimal)12) * decimal.Parse(objSum.ToString())).ToString("0.00");
            }
        }

        private void dayOnMonthVacation()
        {
            //DataTable dtTmp = new DataTable();
            //dtTmp.Columns.Add("date", typeof(DateTime));
            //dtTmp.Columns.Add("cntDay", typeof(int));
            //dtTmp.AcceptChanges();

            DataColumn col = new DataColumn();
            col.ColumnName = "cntDay";
            col.DataType = typeof(int);
            col.DefaultValue = 0;
            dtData.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "cntBreak";
            col.DataType = typeof(int);
            col.DefaultValue = 0;
            dtData.Columns.Add(col);


            col = new DataColumn();
            col.ColumnName = "inCalcColor";
            col.DataType = typeof(bool);
            col.DefaultValue = false;
            dtData.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "isPaidColor";
            col.DataType = typeof(bool);
            col.DefaultValue = false;
            dtData.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "isCompensatoryColor";
            col.DataType = typeof(bool);
            col.DefaultValue = false;
            dtData.Columns.Add(col);

            dtData.AcceptChanges();


            foreach (DataRow row in dtContenctVacation_IsPaid.Rows)
            {
                DateTime _date_start = (DateTime)row["DataStartVacation"];
                int _days = (int)row["CountVacation"];
                DateTime _date_end = (DateTime)row["dateEnd"];

                DateTime tmpDate = _date_start.Date;
                DateTime tmpValidDate = _date_start.Date;
                int cntDay = 0;

                while (true)
                {
                    if (tmpDate.Date > _date_end.Date)
                        break;

                    //Console.WriteLine(tmpDate.ToLongDateString());
                    if (tmpValidDate.Year != tmpDate.Year || tmpValidDate.Month != tmpDate.Month)
                    {

                        EnumerableRowCollection<DataRow> rowCollection = dtData.AsEnumerable().Where(r => r.Field<DateTime>("date").Date == tmpValidDate.AddDays(1 - tmpValidDate.Day).Date);

                        if (rowCollection.Count() > 0)
                            rowCollection.First()["cntDay"] = cntDay;


                        //dtTmp.Rows.Add(tmpValidDate.AddDays(1 - tmpValidDate.Day), cntDay);

                        tmpValidDate = tmpDate.Date;
                        cntDay = 0;
                    }

                    tmpDate = tmpDate.AddDays(1); cntDay++;
                }

                if (cntDay != 0)
                {
                    EnumerableRowCollection<DataRow> rowCollection = dtData.AsEnumerable().Where(r => r.Field<DateTime>("date").Date == tmpValidDate.AddDays(1 - tmpValidDate.Day).Date);

                    if (rowCollection.Count() > 0)
                        rowCollection.First()["cntDay"] = cntDay;
                    //dtTmp.Rows.Add(tmpValidDate.AddDays(1 - tmpValidDate.Day), cntDay);                    
                }
            }

            if (dtDateAbsenceMonthSort != null && dtDateAbsenceMonthSort.Rows.Count > 0)
                foreach (DataRow row in dtDateAbsenceMonthSort.Rows)
                {

                    DateTime _startDatAbsence = (DateTime)row["DataStartAbsence"];
                    DateTime _endDatAbsence = (DateTime)row["DataStopAbsence"];

                    TimeSpan time = _endDatAbsence - _startDatAbsence;

                    EnumerableRowCollection<DataRow> rowCollection = dtData.AsEnumerable().Where(r => r.Field<DateTime>("date").Date == _startDatAbsence.AddDays(1 - _startDatAbsence.Day).Date);

                    if (rowCollection.Count() > 0)
                        rowCollection.First()["cntBreak"] = time.Days + 1;
                }

            #region ""
            foreach (DataRow row in dtContenctVacation_IsNotPaid.Rows)
            {
                DateTime _date_start = (DateTime)row["DataStartVacation"];
                DateTime _date_end = (DateTime)row["dateEnd"];

                DateTime tmpDate = _date_start.Date;
                DateTime tmpValidDate = _date_start.Date;
                int cntDay = 0;

                while (true)
                {
                    if (tmpDate.Date > _date_end.Date)
                        break;

                    //Console.WriteLine(tmpDate.ToLongDateString());
                    if (tmpValidDate.Year != tmpDate.Year || tmpValidDate.Month != tmpDate.Month)
                    {

                        EnumerableRowCollection<DataRow> rowCollection = dtData.AsEnumerable().Where(r => r.Field<DateTime>("date").Date == tmpValidDate.AddDays(1 - tmpValidDate.Day).Date);

                        if (rowCollection.Count() > 0)
                            rowCollection.First()["isPaidColor"] = true;

                        tmpValidDate = tmpDate.Date;
                        cntDay = 0;
                    }

                    cntDay++;
                    tmpDate = tmpDate.AddDays(1);
                }

                if (cntDay != 0)
                {
                    EnumerableRowCollection<DataRow> rowCollection = dtData.AsEnumerable().Where(r => r.Field<DateTime>("date").Date == tmpValidDate.AddDays(1 - tmpValidDate.Day).Date);

                    if (rowCollection.Count() > 0)
                        rowCollection.First()["isPaidColor"] = true;
                    //dtTmp.Rows.Add(tmpValidDate.AddDays(1 - tmpValidDate.Day), cntDay);                    
                }
            }

            foreach (DataRow row in dtContenctVacation_IsCompinsation.Rows)
            {
                DateTime _date_start = (DateTime)row["DataStartVacation"];
                DateTime _date_end = (DateTime)row["dateEnd"];

                DateTime tmpDate = _date_start.Date;
                DateTime tmpValidDate = _date_start.Date;
                int cntDay = 0;

                while (true)
                {
                    if (tmpDate.Date > _date_end.Date)
                        break;

                    //Console.WriteLine(tmpDate.ToLongDateString());
                    if (tmpValidDate.Year != tmpDate.Year || tmpValidDate.Month != tmpDate.Month)
                    {

                        EnumerableRowCollection<DataRow> rowCollection = dtData.AsEnumerable().Where(r => r.Field<DateTime>("date").Date == tmpValidDate.AddDays(1 - tmpValidDate.Day).Date);

                        if (rowCollection.Count() > 0)
                            rowCollection.First()["isCompensatoryColor"] = true;

                        tmpValidDate = tmpDate.Date;
                        cntDay = 0;
                    }

                    cntDay++;
                    tmpDate = tmpDate.AddDays(1);
                }

                if (cntDay != 0)
                {
                    EnumerableRowCollection<DataRow> rowCollection = dtData.AsEnumerable().Where(r => r.Field<DateTime>("date").Date == tmpValidDate.AddDays(1 - tmpValidDate.Day).Date);

                    if (rowCollection.Count() > 0)
                        rowCollection.First()["isCompensatoryColor"] = true;
                    //dtTmp.Rows.Add(tmpValidDate.AddDays(1 - tmpValidDate.Day), cntDay);                    
                }
            }

            foreach (DataRow row in dtDateAbsenceMonthSortIsCalNo.Rows)
            {
                DateTime _startDatAbsence = (DateTime)row["DataStartAbsence"];
                //DateTime _endDatAbsence = (DateTime)row["DataStopAbsence"];

                //TimeSpan time = _endDatAbsence - _startDatAbsence;

                EnumerableRowCollection<DataRow> rowCollection = dtData.AsEnumerable().Where(r => r.Field<DateTime>("date").Date == _startDatAbsence.AddDays(1 - _startDatAbsence.Day).Date);

                if (rowCollection.Count() > 0)
                    rowCollection.First()["inCalcColor"] = true;
            }

            #endregion

            tbCountVacantionUsed.Text = "0.00";

            object sumObj = dtData.Compute("SUM(cntDay)", "");
            if (sumObj != null && sumObj != DBNull.Value)
                tbCountVacantionUsed.Text = sumObj.ToString();

            sumObj = dtData.Compute("SUM(cntBreak)", "");
            if (sumObj != null && sumObj != DBNull.Value)
                tbBreak.Text = sumObj.ToString();


        }

        private void dgvAbsenc_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                if ((bool)dtData.DefaultView[e.RowIndex]["inCalcColor"])
                    dgvAbsenc.Rows[e.RowIndex].Cells[cBreak.Index].Style.BackColor = panel1.BackColor;

                if ((bool)dtData.DefaultView[e.RowIndex]["isPaidColor"])
                    dgvAbsenc.Rows[e.RowIndex].Cells[cVacation.Index].Style.BackColor = panel2.BackColor;

                if ((bool)dtData.DefaultView[e.RowIndex]["isCompensatoryColor"])
                    dgvAbsenc.Rows[e.RowIndex].Cells[cnDate.Index].Style.BackColor = panel3.BackColor;

            }
            catch
            {

            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            Logging.StartFirstLevel(79);
            Logging.Comment("Результат по месяцам");
            Logging.Comment("Сотрудник ID:" + kadrInfo.id_kadr + "; ФИО: " + kadrInfo.FIO);
            Logging.Comment("Отдел: " + kadrInfo.nameDep);
            Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                            + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
            Logging.StopFirstLevel();


            Nwuram.Framework.ToExcelNew.ExcelUnLoad report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad();
            int indexRow = 1;

            #region "Head"
            report.Merge(indexRow, 1, indexRow, 4);
            report.AddSingleValue("Результат по месяцам", indexRow, 1);
            report.SetFontBold(indexRow, 1, indexRow, 1);
            report.SetFontSize(indexRow, 1, indexRow, 1, 16);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
            indexRow++;
            indexRow++;
         
            report.Merge(indexRow, 1, indexRow, 4);
            report.AddSingleValue("Выгрузил: " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername, indexRow, 1);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 4);
            report.AddSingleValue("Дата выгрузки: " + DateTime.Now.ToString(), indexRow, 1);
            indexRow++;
            indexRow++;
            #endregion

            #region "Body"
            report.Merge(indexRow, 1, indexRow, 4);
            report.AddSingleValue("Сотрудник: "+tbFio.Text, indexRow, 1);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 4);
            report.AddSingleValue("Доступное количество дней отпуска: "+ tbDayWithPay.Text, indexRow, 1);
            indexRow++;

            if (tbDayWithOutPay.Visible) {
                report.Merge(indexRow, 1, indexRow, 4);
                report.AddSingleValue("С учётом неоплаченного отпуска: "+ tbDayWithOutPay.Text, indexRow, 1);
                indexRow++;
            }
            indexRow++;
            
            report.AddSingleValue("Дата", indexRow, 1);
            report.AddSingleValue("Процент отработки", indexRow, 2);
            report.AddSingleValue("Отпуск", indexRow, 3);
            report.AddSingleValue("Отсутствие", indexRow, 4);            
            report.SetFontBold(indexRow, 1, indexRow, 4);
            report.SetBorders(indexRow, 1, indexRow, 4);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 4);
            indexRow++;

            foreach (DataRowView row in dtData.DefaultView)
            {
                report.AddSingleValue(row["date"].ToString(), indexRow, 1);
                report.AddSingleValue(row["percent"].ToString(), indexRow, 2);
                report.AddSingleValue(row["cntDay"].ToString(), indexRow, 3);
                report.AddSingleValue(row["cntBreak"].ToString(), indexRow, 4);

                if ((bool)row["inCalcColor"])
                    report.SetCellColor(indexRow, 4, indexRow, 4, panel1.BackColor);
                    //dgvAbsenc.Rows[e.RowIndex].Cells[cBreak.Index].Style.BackColor = panel1.BackColor;

                if ((bool)row["isPaidColor"])
                    report.SetCellColor(indexRow, 3, indexRow, 3, panel2.BackColor);
                //dgvAbsenc.Rows[e.RowIndex].Cells[cVacation.Index].Style.BackColor = panel2.BackColor;

                if ((bool)row["isCompensatoryColor"])
                    report.SetCellColor(indexRow, 1, indexRow, 1, panel3.BackColor);
                    //dgvAbsenc.Rows[e.RowIndex].Cells[cnDate.Index].Style.BackColor = panel3.BackColor;


                report.SetBorders(indexRow, 1, indexRow, 4);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 4);
                indexRow++;
            }
            indexRow++;
            #endregion

            
            report.Merge(indexRow, 1, indexRow, 4);
            report.AddSingleValue("Кол-во месяцев: " + tbCountMonth.Text, indexRow, 1);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 4);
            report.AddSingleValue("Кол-во дней отгуленного отпуска: " + tbCountVacantionUsed.Text, indexRow, 1);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 4);
            report.AddSingleValue("Отсутствия: " + tbBreak.Text, indexRow, 1);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 4);
            report.AddSingleValue("Начисленно отпуска: " + tbCountDays.Text, indexRow, 1);
            indexRow++;
            indexRow++;
            //




            report.SetCellColor(indexRow, 1, indexRow, 1, panel1.BackColor);
            report.Merge(indexRow, 2, indexRow, 4);
            report.AddSingleValue(label7.Text, indexRow, 2);
            indexRow++;

            report.SetCellColor(indexRow, 1, indexRow, 1, panel2.BackColor);
            report.Merge(indexRow, 2, indexRow, 4);
            report.AddSingleValue(label8.Text, indexRow, 2);
            indexRow++;

            report.SetCellColor(indexRow, 1, indexRow, 1, panel3.BackColor);
            report.Merge(indexRow, 2, indexRow, 4);
            report.AddSingleValue(label9.Text, indexRow, 2);
            indexRow++;

            report.SetColumnAutoSize(9, 1, indexRow, 4);
            //report.SetColumnWidth(9, 2, indexRow, 2, 15);
            //report.SetColumnWidth(9, 4, indexRow, 4, 20);
            report.SetPageSetup(1, 9999, true);
            report.Show();

        }

        private void DoOnUIThread(MethodInvoker d)
        {
            if (this.InvokeRequired) { this.Invoke(d); } else { d(); }
        }
    }
}
