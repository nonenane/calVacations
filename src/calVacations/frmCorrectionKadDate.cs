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
    public partial class frmCorrectionKadDate : Form
    {
        public DataTable dtDateAbsence_new { set; get; }
        public frmCorrectionKadDate()
        {
            InitializeComponent();
            dgvAbsenc.AutoGenerateColumns = false;
            tbFIO.Text = kadrInfo.FIO;
        }

        private void frmCorrectionKadDate_Load(object sender, EventArgs e)
        {
            dgvAbsenc.DataSource = dtDateAbsence_new;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            dtDateAbsence_new.AcceptChanges();
            foreach (DataRow r in dtDateAbsence_new.Rows)
            {
                Config.hCntMain.setSingleContentDayAbsence(0, kadrInfo.id_kadr, (DateTime)r["DataStartAbsence"], (DateTime)r["DataStopAbsence"],(bool)r["inCalc"], "", false);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
