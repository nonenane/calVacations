using System;
using System.Windows.Forms;
using Nwuram.Framework.Project;
using Nwuram.Framework.Logging;
using Nwuram.Framework.Settings.Connection;
using System.Data;
using System.Threading.Tasks;

namespace calVacations
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length != 0)
                if (Project.FillSettings(args))
                {
                    Config.hCntMain = new Procedures(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);

                    Logging.Init(ConnectionSettings.GetServer(), ConnectionSettings.GetDatabase(), ConnectionSettings.GetUsername(), ConnectionSettings.GetPassword(), ConnectionSettings.ProgramName);
                    Logging.StartFirstLevel(1);
                    Logging.Comment("Вход в программу");
                    Logging.StopFirstLevel();

                    Task dtTask =  get_settings();
                    dtTask.Wait();

                    Application.Run(new frmMain());

                    Logging.StartFirstLevel(2);
                    Logging.Comment("Выход из программы");
                    Logging.StopFirstLevel();

                    Project.clearBufferFiles();
                }
        }

        private static async Task get_settings()
        {
            DataTable dtSettings = await Config.hCntMain.getSettings("kdog");
            if (dtSettings == null || dtSettings.Rows.Count == 0)
                Config.hCntMain.setSettings("kdog", "28");

            dtSettings = await Config.hCntMain.getSettings("kdps");
            if (dtSettings == null || dtSettings.Rows.Count == 0)
                Config.hCntMain.setSettings("kdps", "14");


            dtSettings = await Config.hCntMain.getSettings("sous");
            if (dtSettings == null || dtSettings.Rows.Count == 0)
                Config.hCntMain.setSettings("sous", "60");


            dtSettings = await Config.hCntMain.getSettings("skdg");
            if (dtSettings == null || dtSettings.Rows.Count == 0)
                Config.hCntMain.setSettings("skdg", "29,3");

        }
    }
}
