using System.Text;
using System.Collections;
using Nwuram.Framework.Data;
using Nwuram.Framework.Settings.Connection;
using System.Data;
using System;
using Nwuram.Framework.Settings.User;
using System.Threading.Tasks;
using System.Threading;

namespace calVacations
{
    public class Procedures : SqlProvider
    {
        public Procedures(string server, string database, string username, string password, string appName)
            : base(server, database, username, password, appName)
        {
        }
        ArrayList ap = new ArrayList();

        public async Task<DataTable> getDate()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[dbo].[GetDate]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }

        public async Task<DataTable> getDeps()
        {
            ap.Clear();

            DataTable dtResult = executeProcedure("[Vacation].[getDeps]",
                 new string[0] { },
                 new DbType[0] { }, ap);

            return dtResult;
        }

        public async Task<DataTable> getListKadrForDep(int id_dep)
        {
            ap.Clear();

            ap.Add(id_dep);
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());

            DataTable dtResult = executeProcedure("[Vacation].[getListKadrForDep]",
                 new string[2] { "@id_dep","@id_prog" },
                 new DbType[2] { DbType.Int32,DbType.Int32 }, ap);

            return dtResult;
        }

        public async Task<DataTable> getSettings(string id_value)
        {
            ap.Clear();

            
            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());
            ap.Add(id_value);

            DataTable dtResult = executeProcedure("[Vacation].[getSettings]",
                 new string[2] {  "@id_prog","@id_value" },
                 new DbType[2] { DbType.Int32,DbType.String }, ap);

            return dtResult;
        }

        public DataTable setSettings(string id_value,string value)
        {
            ap.Clear();


            ap.Add(Nwuram.Framework.Settings.Connection.ConnectionSettings.GetIdProgram());
            ap.Add(id_value);
            ap.Add(value);

            DataTable dtResult = executeProcedure("[Vacation].[setSettings]",
                 new string[3] { "@id_prog", "@id_value","@value" },
                 new DbType[3] { DbType.Int32, DbType.String,DbType.String }, ap);

            return dtResult;
        }

        public async Task<DataTable> getFirstVacationData(int id_kadr)
        {
            ap.Clear();

            ap.Add(id_kadr);            

            DataTable dtResult = executeProcedure("[Vacation].[getFirstVacationData]",
                 new string[1] { "@id_kadr" },
                 new DbType[1] { DbType.Int32 }, ap);

            return dtResult;
        }

        public DataTable setFirstVacationData(int id_kadr, decimal FirstVacationDays, DateTime StartCalculation,bool isDel)
        {
            ap.Clear();


            ap.Add(id_kadr);
            ap.Add(FirstVacationDays);
            ap.Add(StartCalculation);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(isDel);

            DataTable dtResult = executeProcedure("[Vacation].[setFirstVacationData]",
                 new string[5] { "@id_kadr", "@FirstVacationDays", "@StartCalculation","@id_user","@isDel" },
                 new DbType[5] { DbType.Int32, DbType.Decimal, DbType.Date,DbType.Int32,DbType.Boolean }, ap);

            return dtResult;
        }

        public async Task<DataTable> getSingleContentVacationAsync(int id)
        {
            ap.Clear();

            ap.Add(id);

            DataTable dtResult = executeProcedure("[Vacation].[getSingleContentVacation]",
                 new string[1] { "@id" },
                 new DbType[1] { DbType.Int32 }, ap);

            return dtResult;
        }
        
        public DataTable getSingleContentVacation(int id)
        {
            ap.Clear();

            ap.Add(id);

            DataTable dtResult = executeProcedure("[Vacation].[getSingleContentVacation]",
                 new string[1] { "@id" },
                 new DbType[1] { DbType.Int32 }, ap);

            return dtResult;
        }

        public DataTable setSingleContentVacation(int id, int id_kadr, int CountVacation, DateTime DataStartVacation,bool isPaid,bool isCompensatory,string Comment,  bool isDel)
        {
            ap.Clear();


            ap.Add(id);
            ap.Add(id_kadr);
            ap.Add(CountVacation);
            ap.Add(DataStartVacation);
            ap.Add(isPaid);
            ap.Add(isCompensatory);
            ap.Add(Comment);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(isDel);

            DataTable dtResult = executeProcedure("[Vacation].[setSingleContentVacation]",
                 new string[9] { "@id","@id_kadr", "@CountVacation", "@DataStartVacation","@isPaid", "@isCompensatory","@Comment", "@id_user", "@isDel" },
                 new DbType[9] { DbType.Int32, DbType.Int32, DbType.Int32, DbType.Date,DbType.Boolean,DbType.Boolean,DbType.String, DbType.Int32, DbType.Boolean }, ap);

            return dtResult;
        }

        public async Task<DataTable> getContentVacation(int id_kadr,DateTime? dateStart,DateTime? dateEnd)
        {
            ap.Clear();

            ap.Add(id_kadr);
            ap.Add(dateStart);
            ap.Add(dateEnd);

            DataTable dtResult = executeProcedure("[Vacation].[getContentVacation]",
                 new string[3] { "@id_kadr", "@dateStart", "@dateEnd" },
                 new DbType[3] { DbType.Int32, DbType.Date, DbType.Date }, ap);

            return dtResult;
        }

        public async Task<DataTable> getDayAbsence(int id_kadr, DateTime dateStart, DateTime dateEnd)
        {
            ap.Clear();

            ap.Add(id_kadr);
            ap.Add(dateStart);
            ap.Add(dateEnd);

            DataTable dtResult = executeProcedure("[Vacation].[getDayAbsence]",
                 new string[3] { "@id_kadr", "@dateStart", "@dateEnd" },
                 new DbType[3] { DbType.Int32, DbType.Date, DbType.Date }, ap);

            return dtResult;
        }

        public async Task<DataTable> getSingleContentDayAbsence(int id)
        {
            ap.Clear();

            ap.Add(id);

            DataTable dtResult = executeProcedure("[Vacation].[getSingleContentDayAbsence]",
                 new string[1] { "@id" },
                 new DbType[1] { DbType.Int32 }, ap);

            return dtResult;
        }

        public DataTable setSingleContentDayAbsence(int id, int id_kadr, DateTime DataStartAbsence, DateTime DataStopAbsence, bool inCalc, string Comment, bool isDel)
        {
            ap.Clear();


            ap.Add(id);
            ap.Add(id_kadr);
            ap.Add(DataStartAbsence);
            ap.Add(DataStopAbsence);
            ap.Add(inCalc);            
            ap.Add(Comment);
            ap.Add(Nwuram.Framework.Settings.User.UserSettings.User.Id);
            ap.Add(isDel);

            DataTable dtResult = executeProcedure("[Vacation].[setSingleContentDayAbsence]",
                 new string[8] { "@id", "@id_kadr", "@DataStartAbsence", "@DataStopAbsence", "@inCalc", "@Comment", "@id_user", "@isDel" },
                 new DbType[8] { DbType.Int32, DbType.Int32, DbType.Date, DbType.Date, DbType.Boolean, DbType.String, DbType.Int32, DbType.Boolean }, ap);

            return dtResult;
        }

        public async Task<DataTable> getHolidaysForDate(DateTime date, DateTime dateEnd)
        {
            ap.Clear();

            ap.Add(date);
            ap.Add(dateEnd);
            DataTable dtResult = executeProcedure("[Vacation].[getHolidaysForDate]",
                 new string[2] { "@date","@dateEnd" },
                 new DbType[2] { DbType.Date, DbType.Date }, ap);

            return dtResult;
        }

        public async Task<DataTable> getWorkTimeDataForKadrForDate(int id_kadr, DateTime date,DateTime dateEnd)
        {
            ap.Clear();

            ap.Add(id_kadr);
            ap.Add(date);
            ap.Add(dateEnd);
            DataTable dtResult = executeProcedure("[Vacation].[getWorkTimeDataForKadrForDate]",
                 new string[3] {"@id_kadr", "@date","@dateEnd" },
                 new DbType[3] { DbType.Int32, DbType.Date, DbType.Date }, ap);

            return dtResult;
        }

        //
        public async Task<DataTable> getReportNotPayVacation(DateTime dateStart, DateTime dateEnd)
        {
            ap.Clear();
            ap.Add(dateStart);
            ap.Add(dateEnd);

            DataTable dtResult = executeProcedure("[Vacation].[getReportNotPayVacation]",
                 new string[2] { "@dateStart", "@dateEnd" },
                 new DbType[2] { DbType.Date, DbType.Date }, ap);

            return dtResult;
        }


        //


        public async Task<DataTable> getDictonaryPriceChecker()
        {
            ap.Clear();
            DataTable dtResult = executeProcedure("[WorkTime].[getDictonaryPriceChecker]",
                 new string[] { },
                 new DbType[] { }, ap);

            return dtResult;
        }

        public DataTable setDictonaryPriceChecker(int id, int id_shop, bool isInOut, string IP, string comment)
        {
            ap.Clear();

            ap.Add(id);
            ap.Add(id_shop);
            ap.Add(isInOut);
            ap.Add(IP);
            ap.Add(comment);
            ap.Add(UserSettings.User.Id);

            DataTable dtResult = executeProcedure("[WorkTime].[setDictonaryPriceChecker]",
                 new string[6] { "@id", "@id_shop", "@isInOut", "@IP", "@comment", "@id_user" },
                 new DbType[6] { DbType.Int32, DbType.Int32, DbType.Boolean, DbType.String, DbType.String, DbType.Int32 }, ap);

            return dtResult;
        }

        public async Task<DataTable> getDataSmokingNow(int id_shop, int id_deps, DateTime? dateStart, DateTime? dateEnd)
        {
            ap.Clear();

            ap.Add(id_shop);
            ap.Add(id_deps);

            ap.Add(dateStart);
            ap.Add(dateEnd);

            DataTable dtResult = executeProcedure("[WorkTime].[getDataSmokingNow]",
                 new string[4] { "@id_shop", "@id_deps", "@dateStart", "@dateEnd" },
                 new DbType[4] { DbType.Int32, DbType.Int32, DbType.Date, DbType.Date }, ap);

            return dtResult;
        }

        public async Task<DataTable> getConfig()
        {
            DataTable dtResult = executeCommand(" select value from dbo.prog_config where id_value = 'zoio' and id_prog = " + ConnectionSettings.GetIdProgram());

            return dtResult;


        }
    }
}
