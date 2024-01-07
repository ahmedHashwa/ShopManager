#region using directives
using System;
using System.Configuration.Install;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ShopManager.ProjectResources.Properties;
using Resources = ShopManager.Properties.Resources;
#endregion
namespace ShopManager.Main_Forms
{
    internal static class MainInstaller
    {
        #region ExecuteMode enum
        public enum ExecuteMode
        {
            SingleWithReturnValue,
            ExecuteBatch
        }
        #endregion
        public static string Dir
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }
        public static bool DatabaseExists
        {
            get
            {
                return
                     File.Exists(Dir + "Data\\ShopDatabase.mdf") ;
                    //!string.IsNullOrEmpty(ExecuteSql("master",
                    //                                 "SELECT name FROM sys.databases WHERE name = N'ShopDatabase'",
                    //                                 ExecuteMode.SingleWithReturnValue, true))
            }
        }
        public static string ExecuteSql(string databaseName, string sql, ExecuteMode executeMode, bool silent)
        {
            var command = new SqlCommand { Connection = new SqlConnection(Settings.Default.CreateDatabaseConnection) };
            command.Connection.Open();
            command.Connection.ChangeDatabase(databaseName);
            try
            {
                switch (executeMode)
                {
                    case ExecuteMode.ExecuteBatch:
                        var regex = new Regex("^GO", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                        string[] commands = regex.Split(sql);
                        foreach (string comm in commands)
                        {
                            if (comm.Length <= 0) continue;
                            command.CommandText = comm;
                            command.CommandType = CommandType.Text;
                            command.ExecuteNonQuery();
                        }
                        break;
                    case ExecuteMode.SingleWithReturnValue:
                        command.CommandText = sql;
                        object obj = command.ExecuteScalar();
                        return (obj == null) ? string.Empty : obj.ToString();
                }
                if (!silent)
                    MessageBox.Show(Resources.MainInstaller_ExecuteSql_ExecutedwithSuccess,
                                    Resources.MainInstaller_ExecuteSql_ExecutedwithSuccess, MessageBoxButtons.OK,
                                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            }
            catch (Exception exception)
            {
                if (!silent)
                    MessageBox.Show(exception.Message, Resources.MainInstaller_ExecuteSql_ErrorInExecution,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            }
            // ReSharper disable EmptyGeneralCatchClause
            finally
            {
                command.Connection.Close();
            }
            return string.Empty;
        }
        /// <exception cref = "InstallException"><c>InstallException</c>.
        /// </exception>
        private static string GetSql(string name)
        {
            try
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                Stream strm = asm.GetManifestResourceStream(asm.GetName().Name + ".Data." + name);
                if (strm != null)
                {
                    var reader = new StreamReader(strm);
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new InstallException("In GetSQL: " + ex);
            }
            return string.Empty;
        }
        public static void CreateBlankDataBase(string dir, decimal treasuryBeginningBalance, bool silent)
        {
            string command = string.Format(
                "CREATE DATABASE [ShopDatabase] ON  PRIMARY" +
                "( NAME = N'Database', FILENAME = N'{0}\\ShopDatabase.mdf' , SIZE = 3000KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )" +
                "LOG ON " +
                "( NAME = N'Database_log', FILENAME = N'{0}\\ShopDatabase_log.ldf' , SIZE = 1088KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)",
                dir + @"Data");
            // Creates the database.
            ExecuteSql("master", command, ExecuteMode.SingleWithReturnValue, true);
            ExecuteSql("master", GetSql("masterscript.sql"), ExecuteMode.ExecuteBatch, true);
            // Creates the tables.
            ExecuteSql("ShopDatabase", GetSql("dbscript.sql"), ExecuteMode.ExecuteBatch, silent);
            ExecuteSql("ShopDatabase",
                       "INSERT Into Flags  ( Name,Value) VALUES ('TreasuryBeginningBalance'," +
                       treasuryBeginningBalance + ")", ExecuteMode.SingleWithReturnValue, true);
            ExecuteSql("ShopDatabase",
                       "SET IDENTITY_INSERT [dbo].[Expenses Types] ON " +
                       "INSERT [dbo].[Expenses Types] ([ExpenseTypeID], [Description]) VALUES (1, N'إيجار')              " +
                       "INSERT [dbo].[Expenses Types] ([ExpenseTypeID], [Description]) VALUES (2, N'كهرباء')             " +
                       "INSERT [dbo].[Expenses Types] ([ExpenseTypeID], [Description]) VALUES (3, N'ضرائب و تأمينات')   " +
                       "INSERT [dbo].[Expenses Types] ([ExpenseTypeID], [Description]) VALUES (4, N'دش')                  " +
                       "INSERT [dbo].[Expenses Types] ([ExpenseTypeID], [Description]) VALUES (5, N'شخصي')               " +
                       "INSERT [dbo].[Expenses Types] ([ExpenseTypeID], [Description]) VALUES (6, N'إصلاحات')             " +
                       "INSERT [dbo].[Expenses Types] ([ExpenseTypeID], [Description]) VALUES (7, N'مرتبات')             " +
                       "INSERT [dbo].[Expenses Types] ([ExpenseTypeID], [Description]) VALUES (8, N'مواصلات')             " +
                       "SET IDENTITY_INSERT [dbo].[Expenses Types] OFF", ExecuteMode.SingleWithReturnValue, true);
        }
        public static void DeleteDataBase()
        {
            if (
                !string.IsNullOrEmpty(ExecuteSql("master",
                                                 "SELECT name FROM sys.databases WHERE name = N'ShopDatabase'",
                                                 ExecuteMode.SingleWithReturnValue, true)))
            {
                ExecuteSql("master", " Drop database [ShopDatabase]", ExecuteMode.SingleWithReturnValue, true);
            }
            else if (File.Exists(Dir + "Data\\ShopDatabase"))
            {
                File.Delete(Dir + "Data\\ShopDatabase");
                File.Delete(Dir + "Data\\ShopDatabase_log.ldf");
            }
        }
        public static void GrantAccessToUsers(DirectoryInfo info2)
        {
            DirectorySecurity dirSec = info2.GetAccessControl();
            dirSec.AddAccessRule(new FileSystemAccessRule(@"Users", FileSystemRights.FullControl,
                                                          InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly,
                                                          AccessControlType.Allow));
            dirSec.AddAccessRule(new FileSystemAccessRule(@"Users", FileSystemRights.FullControl,
                                                          InheritanceFlags.ContainerInherit,
                                                          PropagationFlags.InheritOnly, AccessControlType.Allow));
            dirSec.AddAccessRule(new FileSystemAccessRule(@"Users", FileSystemRights.FullControl, InheritanceFlags.None,
                                                          PropagationFlags.InheritOnly, AccessControlType.Allow));
            info2.SetAccessControl(dirSec);
        }
        public static bool UpgradeIsNeeded
        {
            get
            {
                return string.IsNullOrEmpty(ExecuteSql("ShopDatabase",
                                                       "SELECT name FROM sys.tables WHERE name = 'fridgestorages' AND schema_id = SCHEMA_ID('dbo')",
                                                       ExecuteMode.SingleWithReturnValue, true));
            }
        }
        public static void UpgradeDb()
        {
            ExecuteSql("ShopDatabase", GetSql("dbscript.sql"), ExecuteMode.ExecuteBatch, false);
        }
    }
}