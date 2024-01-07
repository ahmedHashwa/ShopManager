#region using directives

using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using ShopManager.ProjectResources.Properties;

#endregion

namespace ShopManager.ReportViewer
{
    internal class Database
    {
        public static string Dir
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }

        public static bool DatabaseExists
        {
            get
            {
                return
                    !string.IsNullOrEmpty(ExecuteSql("master",
                                                     "SELECT name FROM sys.databases WHERE name = N'ShopDatabase'"));
            }
        }

        public static void KillProcessesHoldingDb()
        {
            ExecuteSql("master", string.Format(
                "DECLARE @SQL varchar(max) " +
                "SET @SQL = '' " +
                "SELECT @SQL = @SQL + 'Kill ' + Convert(varchar, SPId) + ';' " +
                "FROM MASTER.dbo.SysProcesses " +
                "WHERE DBId = DB_ID(N'{0}') " +
                "EXEC(@SQL) ", "ShopDatabase"));
        }

        public static void RestoreFrom(string filename)
        {
            if (!Directory.Exists(Dir + "data")) Directory.CreateDirectory(Dir + "data");
            KillProcessesHoldingDb();
            string sql =
                string.Format(
                    "restore database [{0}] from disk = '{1}' WITH REPLACE  , MOVE 'Database' To '{2}' , MOVE 'Database_log' TO '{3}'",
                    "ShopDatabase",
                    filename, Dir + "data\\ShopDatabase", Dir + "data\\ShopDatabase_log.ldf");
            try
            {
                ExecuteSql("master", sql);
            }
                // ReSharper disable EmptyGeneralCatchClause
            catch (Exception ex)
                // ReSharper restore EmptyGeneralCatchClause
            {
                MessageBox.Show("حدث خطأ أثناء استرداد قاعدة البيانات " + ex.Message);
            }
        }

        public static string ExecuteSql(string databaseName, string sql)
        {
            var command = new SqlCommand {Connection = new SqlConnection(Settings.Default.CreateDatabaseConnection)};
            command.Connection.Open();
            command.Connection.ChangeDatabase(databaseName);
            try
            {
                command.CommandText = sql;
                object obj = command.ExecuteScalar();
                return (obj == null) ? string.Empty : obj.ToString();
            }
                // ReSharper disable EmptyGeneralCatchClause
            finally
            {
                command.Connection.Close();
            }
        }
    }
}