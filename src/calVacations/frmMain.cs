using Nwuram.Framework.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calVacations
{
    public partial class frmMain : Form
    {
        private DataTable dtData;
        public frmMain()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = Nwuram.Framework.Settings.Connection.ConnectionSettings.GetServer() + @"\" + Nwuram.Framework.Settings.Connection.ConnectionSettings.GetDatabase();
            this.Text = Nwuram.Framework.Settings.Connection.ConnectionSettings.ProgramName 
                //+ "; " + Nwuram.Framework.Settings.User.UserSettings.User.Status 
                + "; " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername;            
            Task.Run(() => start_init_all(1));
        }

        private void DoOnUIThread(MethodInvoker d)
        {
            if (this.InvokeRequired) { this.Invoke(d); } else { d(); }
        }

        private async Task start_init_all(int type)
        {
            DoOnUIThread(delegate ()
            { this.Enabled = false; });

            List<Task> allTasks;

            if (type == 1)
            {
                var depsTask = init_deps();                                

                allTasks = new List<Task> {  depsTask };

                while (allTasks.Any())
                {
                    Task finished = await Task.WhenAny(allTasks);                   
                    if (finished == depsTask)
                    {
                        //Console.WriteLine("eggs are ready");
                    }                    
                    allTasks.Remove(finished);
                }
            }

            var dataTask = getListKadrForDep();
            allTasks = new List<Task> { dataTask };
            while (allTasks.Any())
            {
                Task finished = await Task.WhenAny(allTasks);
                if (finished == dataTask)
                {
                    //Console.WriteLine("eggs are ready");
                }
                allTasks.Remove(finished);
            }

            DoOnUIThread(delegate ()
            {
                this.Enabled = true;               
            });
        }

        private async Task init_deps()
        {
            DataTable dtDeps = await Config.hCntMain.getDeps();
            DoOnUIThread(delegate ()
            {
                //cmbShop.Enabled = true;
                cmbDeps.DataSource = dtDeps;
                cmbDeps.DisplayMember = "name";
                cmbDeps.ValueMember = "id";
            });
        }

        private async Task getListKadrForDep()
        {
            int id_dep = 0;

            DoOnUIThread(delegate ()
            {
                id_dep = int.Parse(cmbDeps.SelectedValue.ToString());
            });

            dtData = await Config.hCntMain.getListKadrForDep(id_dep);

            DoOnUIThread(delegate ()
            {
                setFilter();
                dgvData.DataSource = dtData;
            });
        }

        private void setFilter()
        {
            if (dtData == null || dtData.Rows.Count == 0)
            {
                btPrint.Enabled = false;
                return;
            }

            try
            {
                string filter = "";

                if (tbFIO.Text.Trim().Length != 0)
                    filter += (filter.Trim().Length == 0 ? "" : " and ") + string.Format("FIO like '%{0}%'", tbFIO.Text.Trim());

                if(!chbUnemploy.Checked)
                    filter += (filter.Trim().Length == 0 ? "" : " and ") + string.Format("id_WorkStatus = 4", "");

                if(chbShowTransfer.Checked)
                    filter += (filter.Trim().Length == 0 ? "" : " and ") + string.Format("kadrPersonnelType = 2 and personalPersonnelType = 1", "");

                dtData.DefaultView.RowFilter = filter;
                btPrint.Enabled = dtData.DefaultView.Count != 0;
                dtData.DefaultView.Sort = "nameDep asc, namePost asc, FIO asc";
            }
            catch
            {
                dtData.DefaultView.RowFilter = "id = -1";
                btPrint.Enabled = false;
            }

        }

        private void getData()
        {
            Task.Run(() => start_init_all(2)); 
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void cmbDeps_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getData();
        }

        private void tbFIO_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void chbUnemploy_CheckedChanged(object sender, EventArgs e)
        {
            cDateEnd.Visible = chbUnemploy.Checked;
            setFilter();
        }

        private void dgvData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex != -1 && dtData != null && dtData.DefaultView.Count != 0)
            {

                Color rColor = Color.White;
                if ((int)dtData.DefaultView[e.RowIndex]["id_WorkStatus"] == 5)
                    rColor = pUnemploy.BackColor;

                dgvData.Rows[e.RowIndex].DefaultCellStyle.BackColor = rColor;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = rColor;

                dgvData.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvData.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            //Рисуем рамку для выделеной строки
            if (dgv.Rows[e.RowIndex].Selected)
            {
                int width = dgv.Width;
                Rectangle r = dgv.GetRowDisplayRectangle(e.RowIndex, false);
                Rectangle rect = new Rectangle(r.X, r.Y, width - 1, r.Height - 1);

                ControlPaint.DrawBorder(e.Graphics, rect,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid,
                    SystemColors.Highlight, 2, ButtonBorderStyle.Solid);
            }
        }

        private void dgvData_Paint(object sender, PaintEventArgs e)
        {
            tbFIO.Location = new System.Drawing.Point(15 + cDep.Width + cPost.Width , tbFIO.Location.Y);

            if (tbFIO.Width != cFIO.Width)
                tbFIO.Width = cFIO.Width;
        }

        private void dgvData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1)
            {
                dgvData.CurrentCell = dgvData[e.ColumnIndex, e.RowIndex];
                cmsMenu.Show(MousePosition);
                Console.WriteLine(dtData.DefaultView[dgvData.CurrentCell.RowIndex]["id"].ToString());
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = DialogResult.No == MessageBox.Show(Config.centralText("Вы действительно хотите выйти\nиз программы?\n"), "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (dtData == null || dtData.DefaultView.Count == 0) return;


            Logging.StartFirstLevel(79);
            Logging.Comment("Произведена выгрузка отчёта по отпускам:");
            Logging.Comment("Отдел ID: " + cmbDeps.SelectedValue.ToString() + "; наименование: " + cmbDeps.Text);
            Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                            + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
            Logging.StopFirstLevel();

            Nwuram.Framework.ToExcelNew.ExcelUnLoad report = new Nwuram.Framework.ToExcelNew.ExcelUnLoad();

            int indexRow = 1;

            report.Merge(indexRow, 1, indexRow, 7);
            report.AddSingleValue("Отчёт по отпускам" , indexRow, 1);
            report.SetCellAlignmentToCenter(indexRow, 1, indexRow, 1);
            report.SetFontBold(indexRow, 1, indexRow, 1);
            report.SetFontSize(indexRow, 1, indexRow, 1, 16);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 3);
            report.AddSingleValue("Отдел: " + cmbDeps.Text, indexRow, 1);

            report.Merge(indexRow, 5, indexRow, 7);
            report.AddSingleValue("Выгрузил: " + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername, indexRow, 5);
            indexRow++;

            report.Merge(indexRow, 1, indexRow, 3);
            report.AddSingleValue("Фильтр: " + tbFIO.Text.Trim(), indexRow, 1);

            report.Merge(indexRow, 5, indexRow, 7);
            report.AddSingleValue("Дата выгрузки: " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(), indexRow, 5);
            indexRow++;
            indexRow++;

            int indexCol = 0;
            foreach (DataGridViewColumn col in dgvData.Columns)
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

                report.AddSingleValueObject(row["nameDep"], indexRow, 1);
                report.AddSingleValueObject(row["namePost"], indexRow, 2);
                report.AddSingleValueObject(row["FIO"], indexRow, 3);
                report.AddSingleValueObject(row["dateEmploy"] == DBNull.Value ? "" : ((DateTime)row["dateEmploy"]).ToShortDateString(), indexRow, 4);
                if (chbUnemploy.Checked)
                {
                    if (row["dateUnemploy"] != DBNull.Value)
                        report.AddSingleValueObject(((DateTime)row["dateUnemploy"]).ToShortDateString(), indexRow, 5);
                    report.AddSingleValueObject(row["FirstVacationDays"], indexRow, 6);
                    //report.AddSingleValueObject(row["StartCalculation"], indexRow, 7);
                    report.AddSingleValueObject(row["StartCalculation"] == DBNull.Value ? "" : ((DateTime)row["StartCalculation"]).ToShortDateString(), indexRow, 7);

                    if ((int)row["id_WorkStatus"] == 5)
                        report.SetCellColor(indexRow, 1, indexRow, 7, pUnemploy.BackColor);

                }
                else
                {
                    report.AddSingleValueObject(row["FirstVacationDays"], indexRow, 5);
                    report.AddSingleValueObject(row["StartCalculation"] == DBNull.Value ? "" : ((DateTime)row["StartCalculation"]).ToShortDateString(), indexRow, 6);
                }

                report.SetBorders(indexRow, 1, indexRow, indexCol);
                report.SetCellAlignmentToCenter(indexRow, 1, indexRow, indexCol);
                indexRow++;
            }
            

            report.Merge(indexRow, 2, indexRow, 3);
            report.SetCellColor(indexRow, 1, indexRow, 1, pUnemploy.BackColor);
            report.AddSingleValue("- уволенные сотрудники", indexRow, 2);
            indexRow++;


            report.SetColumnAutoSize(2, 1, indexRow, 7);
            report.SetPageSetup(1, 999, true);

            report.Show();
        }

        private void btSettings_Click(object sender, EventArgs e)
        {
            new frmSettings().ShowDialog();
        }

        private void btAddFirstDayVacation_Click(object sender, EventArgs e)
        {
            if (dtData == null || dtData.DefaultView.Count == 0) return;

            kadrInfo.id_kadr = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];
            kadrInfo.dateEmploy = (DateTime)dtData.DefaultView[dgvData.CurrentRow.Index]["dateEmploy"];
            kadrInfo.dateUnEmploy = dtData.DefaultView[dgvData.CurrentRow.Index]["dateUnemploy"] == DBNull.Value ? null : (DateTime?)dtData.DefaultView[dgvData.CurrentRow.Index]["dateUnemploy"];
            kadrInfo.FIO = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["FIO"];
            kadrInfo.StartCalculation = dtData.DefaultView[dgvData.CurrentRow.Index]["StartCalculation"];
            kadrInfo.nameDep = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["nameDep"];


            if (DialogResult.OK == new frmFirstDaysVacation().ShowDialog())
                getData();
        }

        private void btGraFWorkKadr_Click(object sender, EventArgs e)
        {
            if (dtData == null || dtData.DefaultView.Count == 0) return;

            kadrInfo.id_kadr = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];
            kadrInfo.dateEmploy = (DateTime)dtData.DefaultView[dgvData.CurrentRow.Index]["dateEmploy"];
            kadrInfo.dateUnEmploy = dtData.DefaultView[dgvData.CurrentRow.Index]["dateUnemploy"] == DBNull.Value ? null : (DateTime?)dtData.DefaultView[dgvData.CurrentRow.Index]["dateUnemploy"];
            kadrInfo.FIO = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["FIO"];
            kadrInfo.StartCalculation = dtData.DefaultView[dgvData.CurrentRow.Index]["StartCalculation"];
            kadrInfo.nameDep = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["nameDep"];

            if (DialogResult.OK == new frmGrafWorkKadr().ShowDialog())
                getData();
        }

        private void рассчитатьДоступноеКоличествоДнейОтпускаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dtData == null || dtData.DefaultView.Count == 0) return;

            kadrInfo.id_kadr = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id"];
            kadrInfo.id_WorkStatus = (int)dtData.DefaultView[dgvData.CurrentRow.Index]["id_WorkStatus"];
            kadrInfo.dateEmploy = (DateTime)dtData.DefaultView[dgvData.CurrentRow.Index]["dateEmploy"];
            kadrInfo.dateUnEmploy = dtData.DefaultView[dgvData.CurrentRow.Index]["dateUnemploy"] == DBNull.Value ? null : (DateTime?)dtData.DefaultView[dgvData.CurrentRow.Index]["dateUnemploy"];
            kadrInfo.FIO = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["FIO"];
            kadrInfo.StartCalculation = dtData.DefaultView[dgvData.CurrentRow.Index]["StartCalculation"];
            kadrInfo.countDay = dtData.DefaultView[dgvData.CurrentRow.Index]["StartCalculation"] == DBNull.Value ? 0 : (decimal)dtData.DefaultView[dgvData.CurrentRow.Index]["FirstVacationDays"];
            kadrInfo.nameDep = (string)dtData.DefaultView[dgvData.CurrentRow.Index]["nameDep"];
            if (dtData.Columns.Contains("personalPersonnelType"))
                kadrInfo.personalPersonnelType = dtData.DefaultView[dgvData.CurrentRow.Index]["personalPersonnelType"]==DBNull.Value?0:(int)dtData.DefaultView[dgvData.CurrentRow.Index]["personalPersonnelType"];


            new frmInserDateStartCalculation().ShowDialog();

        }

        private void cmbDeps_DropDown(object sender, EventArgs e)
        {
            var senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;

            int vertScrollBarWidth = (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                    ? SystemInformation.VerticalScrollBarWidth : 0;

            //var itemsList = senderComboBox.Items.Cast<object>().Select(item => item.ToString());
            //foreach (string s in itemsList)
            //{
            //    int newWidth = (int)g.MeasureString(s, font).Width + vertScrollBarWidth;

            //    if (width < newWidth)
            //    {
            //        width = newWidth;
            //    }
            //}

            DataTable dtList = (DataTable)senderComboBox.DataSource;


            foreach (DataRow r in dtList.Rows)
            {
                string s = (string)r["name"];

                int newWidth = (int)g.MeasureString(s, font).Width + vertScrollBarWidth;

                if (width < newWidth)
                {
                    width = newWidth;
                }
            }

            senderComboBox.DropDownWidth = width;
        }

        private void btReportNotPayVacation_Click(object sender, EventArgs e)
        {
            new frmReportNotPayVacation().ShowDialog();
        }
    }
}
