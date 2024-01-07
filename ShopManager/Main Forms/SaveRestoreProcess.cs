#region using directives

using System;
using Microsoft.Win32;
using ShopManager.Main_Forms;
using ShopManager.ProjectResources.Properties;
using ShopManager.Reports.ReportDataSetTableAdapters;

#endregion

namespace ShopManager
{
    public class SaveRestoreProcess
    {
        private static string LastSaveTime
        {
            // ReSharper disable PossibleNullReferenceException
            set { Registry.LocalMachine.CreateSubKey("software").CreateSubKey("SM").SetValue("lastsaveday", value); }
            // ReSharper restore PossibleNullReferenceException
        }

        public static string DefaultBackupName
        {
            get
            {
                return "backup " + DateTime.Now.ToShortDateString().Replace("/", string.Empty) +
                       DateTime.Now.GetDateTimeFormats()[33].Replace(":", string.Empty);
            }
        }


        public static void Saveto(String filename)
        {
            string sql = string.Format("backup database [{0}] to disk ='{1}'", "ShopDatabase", filename);
            try
            {
                MainInstaller.ExecuteSql("ShopDatabase", sql, MainInstaller.ExecuteMode.SingleWithReturnValue, false);

                Settings.Default.lastsavePath = filename;
                LastSaveTime = Settings.Default.lastsaveday = DateTime.Now.GetDateTimeFormats()[5];
                Settings.Default.Save();
            }
                // ReSharper disable EmptyGeneralCatchClause
            catch (Exception)
                // ReSharper restore EmptyGeneralCatchClause
            {
            }
        }

        public static void SaveWithDefaultName(string directory)
        {
            Saveto(directory + @"\" + DefaultBackupName + ".smbak");
        }

        public static void RestoreFrom(string filename)
        {
            KillProcessesHoldingDb();
            string sql = string.Format(
                      "restore database [{0}] from disk = '{1}' WITH REPLACE  , MOVE 'Database' To '{2}' , MOVE 'Database_log' TO '{3}'",
                      "ShopDatabase",
                      filename, MainInstaller.Dir + "data\\ShopDatabase", MainInstaller.Dir + "data\\ShopDatabase_log.ldf");
            try
            {
                MainInstaller.ExecuteSql("master", sql, MainInstaller.ExecuteMode.SingleWithReturnValue, false);
                Settings.Default.lastrestoreday = DateTime.Now.GetDateTimeFormats()[5];
                Settings.Default.lastrestorePath = filename;
                Settings.Default.Save();
            }
                // ReSharper disable EmptyGeneralCatchClause
            catch (Exception)
                // ReSharper restore EmptyGeneralCatchClause
            {
            }
            try
            {
                new الخزينةTableAdapter().GetBalance();
            }
                // ReSharper disable EmptyGeneralCatchClause
            catch (Exception)
                // ReSharper restore EmptyGeneralCatchClause
            {
            }
        }

        public static void KillProcessesHoldingDb()
        {
            MainInstaller.ExecuteSql("master", string.Format(
                "DECLARE @SQL varchar(max) " +
                "SET @SQL = '' " +
                "SELECT @SQL = @SQL + 'Kill ' + Convert(varchar, SPId) + ';' " +
                "FROM MASTER.dbo.SysProcesses " +
                "WHERE DBId = DB_ID(N'{0}') " +
                "EXEC(@SQL) ", "ShopDatabase"), MainInstaller.ExecuteMode.SingleWithReturnValue, true);
        }
    }

    #region Nested _type: OperationType

    #endregion
}