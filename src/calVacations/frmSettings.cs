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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            nudkdog.TextChanged += new EventHandler(numericUpDown_TextChanged);
            nudkdps.TextChanged += new EventHandler(numericUpDown_TextChanged);
            nudsous.TextChanged += new EventHandler(numericUpDown_TextChanged);
            nudskdg.TextChanged += new EventHandler(numericUpDown_TextChanged);
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
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
                var depsTask = get_settings();

                allTasks = new List<Task> { depsTask };

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

           

            DoOnUIThread(delegate ()
            {
                this.Enabled = true;
            });
        }

        private decimal _kdog = 0, _kdps = 0, _sous = 0, _skdg = 0;

        private void frmSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (_kdog != nudkdog.Value || _kdps != nudkdps.Value || _sous != nudsous.Value || _skdg != decimal.Parse(tbskdg.Text.ToString())) && DialogResult.No == MessageBox.Show(Config.centralText("На форме есть несохраненные данные.\nЗакрыть форму без сохранения данных?\n"), "Закрытие формы", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }

        private async Task get_settings()
        {
            DataTable dtSettings = await Config.hCntMain.getSettings("kdog");
            if (dtSettings != null && dtSettings.Rows.Count > 0)
                DoOnUIThread(delegate ()
                {
                    nudkdog.Value = decimal.Parse(dtSettings.Rows[0]["value"].ToString());
                    _kdog = nudkdog.Value;
                });

            dtSettings = await Config.hCntMain.getSettings("kdps");
            if (dtSettings != null && dtSettings.Rows.Count > 0)
                DoOnUIThread(delegate ()
                {
                    nudkdps.Value = decimal.Parse(dtSettings.Rows[0]["value"].ToString());
                    _kdps = nudkdps.Value;
                });

            dtSettings = await Config.hCntMain.getSettings("sous");
            if (dtSettings != null && dtSettings.Rows.Count > 0)
                DoOnUIThread(delegate ()
                {
                    nudsous.Value = decimal.Parse(dtSettings.Rows[0]["value"].ToString());
                    _sous = nudsous.Value;
                });

            dtSettings = await Config.hCntMain.getSettings("skdg");
            if (dtSettings != null && dtSettings.Rows.Count > 0)
                DoOnUIThread(delegate ()
                {
                    tbskdg.Text = decimal.Parse(dtSettings.Rows[0]["value"].ToString()).ToString("0.0");
                    //nudskdg.Value = decimal.Parse(dtSettings.Rows[0]["value"].ToString());
                    _skdg = decimal.Parse(dtSettings.Rows[0]["value"].ToString());
                });
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

        private void btSave_Click(object sender, EventArgs e)
        {
            Config.hCntMain.setSettings("kdog", nudkdog.Value.ToString());
            Config.hCntMain.setSettings("kdps", nudkdps.Value.ToString());
            Config.hCntMain.setSettings("sous", nudsous.Value.ToString());
            Config.hCntMain.setSettings("skdg", tbskdg.Text.ToString());

            Logging.StartFirstLevel(93);
                        
            Logging.VariableChange("Кол-во дней отпуска, положенных за 1 год: ", nudkdog.Value, _kdog, typeLog._decimal);
            Logging.VariableChange("Кол-во дней, которые допустимо пропустить подряд: ", nudkdps.Value, _kdps, typeLog._decimal);
            Logging.VariableChange("Кол-во дней отображения уволенных сотрудников: ", nudsous.Value, _sous, typeLog._decimal);
            Logging.VariableChange("Среднее кол-во календарный дней в месяце для расчёта отпуска: ", decimal.Parse(tbskdg.Text.ToString()), _skdg, typeLog._decimal);

            Logging.Comment("Операцию выполнил: ID:" + Nwuram.Framework.Settings.User.UserSettings.User.Id
                            + " ; ФИО:" + Nwuram.Framework.Settings.User.UserSettings.User.FullUsername);
            Logging.StopFirstLevel();




            _kdog = nudkdog.Value;
            _kdps = nudkdps.Value;
            _sous = nudsous.Value;
            _skdg = decimal.Parse(tbskdg.Text.ToString());

            MessageBox.Show("Данные сохранены!", "Сохранение данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
        }

        private void tbskdg_TextChanged(object sender, EventArgs e)
        {
            enButton();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void numericUpDown_TextChanged(object sender, EventArgs e)
        {
            NumericUpDown _nud = (NumericUpDown)sender;
            if (String.IsNullOrEmpty(_nud.Text))
            {
                _nud.Value = 1;
            }
            enButton();
        }

        private void enButton()
        {
            btSave.Enabled = (_kdog != nudkdog.Value || _kdps != nudkdps.Value || _sous != nudsous.Value || _skdg != decimal.Parse(tbskdg.Text.ToString())) && (decimal.Parse(tbskdg.Text.ToString()) != 0);
        }
    }
}
