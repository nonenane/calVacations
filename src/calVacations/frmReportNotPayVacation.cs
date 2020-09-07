using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calVacations
{
    public partial class frmReportNotPayVacation : Form
    {
        public frmReportNotPayVacation()
        {
            InitializeComponent();
        }

        private void frmReportNotPayVacation_Load(object sender, EventArgs e)
        {
           
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            Task<DataTable> task = Config.hCntMain.getReportNotPayVacation(dtpStart.Value.Date,dtpEnd.Value.Date);
            task.Wait();
            DataTable dtData = task.Result;

            if (dtData == null || dtData.DefaultView.Count == 0)
            {
                MessageBox.Show("Нет данных для формирования отчёта!","Выгрузка отчёта",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }


            Logging.StartFirstLevel(79);
            Logging.Comment("Произведена выгрузка отчёта \"Отчет по неоплаченным отпускам\"");
            Logging.Comment($"Период с {dtpStart.Value.ToShortDateString()} по {dtpEnd.Value.ToShortDateString()}");
            Logging.StopFirstLevel();

            Nwuram.Framework.ToExcelNew.ExcelUnLoad report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad();

            int indexRow = 1;

            report.Merge(indexRow, 1, indexRow, 5);
            report.AddSingleValue("Отчет по неоплаченным отпускам", indexRow, 1);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
            report.SetFontBold(indexRow, 1, indexRow, 1);
            report.SetFontSize(indexRow, 1, indexRow, 1, 16);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 2);
            report.AddSingleValue($"Период с {dtpStart.Value.ToShortDateString()} по {dtpEnd.Value.ToShortDateString()}", indexRow, 1);

            report.Merge(indexRow, 3, indexRow, 5);
            report.AddSingleValue("Выгрузил: " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername, indexRow, 5);
            indexRow++;

            report.Merge(indexRow, 3, indexRow, 5);
            report.AddSingleValue("Дата выгрузки: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), indexRow, 5);
            indexRow++;
            indexRow++;

            int indexCol = 5;
            report.AddSingleValue("Сотрудник", indexRow, 1);
            report.AddSingleValue("Дата начала отпуска", indexRow, 2);
            report.AddSingleValue("Продолжителность отпуска", indexRow, 3);
            report.AddSingleValue("Компенсация", indexRow, 4);
            report.AddSingleValue("Комментарий", indexRow, 5);

            report.SetBorders(indexRow, 1, indexRow, indexCol);
            report.SetFontBold(indexRow, 1, indexRow, indexCol);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, indexCol);
            indexRow++;

            foreach (DataRowView row in dtData.DefaultView)
            {

                report.AddSingleValueObject(row["FIO"], indexRow, 1);
                report.AddSingleValueObject(((DateTime)row["DataStartVacation"]).ToShortDateString(), indexRow, 2);
                report.AddSingleValueObject(row["CountVacation"], indexRow, 3);
                report.AddSingleValueObject((bool)row["isCompensatory"] ? "V" : "", indexRow, 4);
                report.AddSingleValueObject(row["Comment"], indexRow, 5);

                report.SetBorders(indexRow, 1, indexRow, indexCol);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, indexCol);
                indexRow++;
            }

            report.SetColumnAutoSize(2, 1, indexRow, 5);
            report.SetPageSetup(1, 999, true);

            report.Show();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date)
                dtpEnd.Value = dtpStart.Value.Date;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value.Date > dtpEnd.Value.Date)
                dtpStart.Value = dtpEnd.Value.Date;
        }
    }
}
