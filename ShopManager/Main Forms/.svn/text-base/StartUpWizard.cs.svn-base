#region using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Web.Mail;
using System.Windows.Forms;
using Microsoft.Win32;
using ShopManager.Controls.Data.ShopDataSetTableAdapters;
using ShopManager.ProjectResources.Properties;
using Image = System.Drawing.Image;
using Label = System.Windows.Forms.Label;
#endregion
namespace ShopManager.Main_Forms
{
#pragma warning disable 618,612
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class StartUpWizard : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public StartUpWizard()
        {
            _mainthread = new Thread(new ThreadStart(delegate { _main = new Main(); }));
            _mainthread.Start();
            dbBackgroundWorker = new BackgroundWorker { WorkerReportsProgress = true };
            dbBackgroundWorker.DoWork += DbBackgroundWorkerDoWork;
            dbBackgroundWorker.ProgressChanged += DbBackgroundWorkerProgressChanged;
            dbBackgroundWorker.RunWorkerCompleted += DbBackgroundWorkerRunWorkerCompleted;
            dbBackgroundWorker.RunWorkerAsync();
            StartPosition = FormStartPosition.CenterScreen;
            // ReSharper disable PossibleNullReferenceException
            var activiated = Registry.LocalMachine.CreateSubKey("software").CreateSubKey("Microsoft").CreateSubKey(
                "SRQQAP").GetValue
                                  ("key", "none").ToString() == GetPassword();
            // ReSharper restore PossibleNullReferenceException
            if (activiated && MainInstaller.DatabaseExists)
            {
                InitializeNormal();
                Shown += Loading_Shown;
                return;
            }
            InitializeComponent();
            label1.Text = label1.Text.Replace("<برنامج>", AboutBox.AssemblyProduct);
            if (MainInstaller.DatabaseExists)
            {
                TreasuryBalanceNumericUpDown.Enabled = false;
            }
            if (activiated)
            {
                activiationPanel.Visible = false;
            }
            ShopNameTextBox.Text = Settings.Default.ShopName;
        }
        #region Loading Code
        void DbBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var msdtcSqlServer = new ServiceController("MSDTC");
            if (msdtcSqlServer.Status != ServiceControllerStatus.Running)
            {
                msdtcSqlServer.Start();
                dbBackgroundWorker.ReportProgress(50);
            }
            if (_scSqlServer.Status == ServiceControllerStatus.Running) return;
            _scSqlServer.Start();
            dbBackgroundWorker.ReportProgress(100);
        }
        void DbBackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (startProgressBar == null) return;
            startProgressBar.Style = ProgressBarStyle.Continuous;
            startProgressBar.Value = e.ProgressPercentage;
            statusLabel.Text = "جاري بدء الخدمات المساعدة";
        }
        static void DbBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var filterService =
                String.Format("SELECT * FROM Win32_Service WHERE Name = '{0}'", "MSSQL$SQLEXPRESS");
            var querySearch = new ManagementObjectSearcher(filterService);
            try
            {
                ManagementObjectCollection services = querySearch.Get(); //get that service
                foreach (ManagementObject service in services)
                {
                    if (Convert.ToString(service.GetPropertyValue("StartMode")) != "Manual") continue;
                    var inParams =
                        service.GetMethodParameters("ChangeStartMode");
                    inParams["startmode"] = "Auto";
                    service.InvokeMethod("ChangeStartMode", inParams, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InitializeNormal()
        {
            ClientSize = new Size(512, 384);
            FormBorderStyle = FormBorderStyle.None;
            ShowIcon = ShowInTaskbar = false;
            TransparencyKey = SystemColors.Control;
            if (RightToLeft == RightToLeft.Yes)
                RightToLeft = RightToLeft.No;
            BackgroundImage = File.Exists(Settings.Default.StartUpImage)
              ? Image.FromFile(Settings.Default.StartUpImage)
              : Resources.loading;
            startProgressBar = new ProgressBar
                                      {
                                          RightToLeft = RightToLeft.Yes,
                                          RightToLeftLayout = true,
                                          Location = new Point(128, 300),
                                          Name = "startProgressBar",
                                          Size = new Size(250, 15),
                                          BackColor = Color.LightGreen,
                                          Style = ProgressBarStyle.Marquee,
                                          MarqueeAnimationSpeed = 100
                                      };
            Controls.Add(startProgressBar);
            // 
            // statusLabel
            //          
            statusLabel = new Label
                                  {
                                      Size = new Size(340, 34),
                                      TextAlign = ContentAlignment.MiddleCenter,
                                      BackColor = Color.Transparent,
                                      Font = new Font("Tahoma", 14F),
                                      ForeColor = Color.Navy,
                                      Location = new Point(83, 256),
                                      Name = "statusLabel"
                                  };
            Controls.Add(statusLabel);
            upgradeDbBackgroundWorker = new BackgroundWorker { WorkerReportsProgress = true };
            upgradeDbBackgroundWorker.DoWork += UpgradeDbBackgroundWorkerDoWork;
            upgradeDbBackgroundWorker.ProgressChanged += UpgradeDbBackgroundWorkerProgressChanged;
            upgradeDbBackgroundWorker.RunWorkerCompleted += UpgradeDbBackgroundWorkerRunWorkerCompleted;
            upgradeDbBackgroundWorker.RunWorkerAsync();
        }
        void UpgradeDbBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _scSqlServer.WaitForStatus(ServiceControllerStatus.Running);
            if (!MainInstaller.DatabaseExists || !MainInstaller.UpgradeIsNeeded) return;
            upgradeDbBackgroundWorker.ReportProgress(50);
            MainInstaller.UpgradeDb();
        }
        void UpgradeDbBackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (startProgressBar == null) return;
            startProgressBar.Value = 50;
            statusLabel.Text = "جاري ترقية قاعدة البيانات";
        }
        void UpgradeDbBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadingBackgroundWorker = new BackgroundWorker { WorkerReportsProgress = true };
            loadingBackgroundWorker.DoWork += LoadingBackgroundWorkerDoWork;
            loadingBackgroundWorker.ProgressChanged += LoadingBackgroundWorkerProgressChanged;
            loadingBackgroundWorker.RunWorkerCompleted += LoadingBackgroundWorkerRunWorkerCompleted;
            loadingBackgroundWorker.RunWorkerAsync();
        }
        private void LoadingBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var info2 = new DirectoryInfo(Application.StartupPath + "\\Data");
            if (info2.Attributes != FileAttributes.Directory)
            {
                string objPath = string.Format(@"Win32_Directory.Name='{0}'", info2.FullName);
                using (var dir = new ManagementObject(objPath))
                {
                    // ReSharper disable AssignNullToNotNullAttribute
                    dir.InvokeMethod("uncompress", null, null);
                    // ReSharper restore AssignNullToNotNullAttribute
                }
            }
            Thread.Sleep(7000);
            while (_mainthread.ThreadState == ThreadState.Running)
                continue;
            _scSqlServer.WaitForStatus(ServiceControllerStatus.Running);
            new العملاءTableAdapter().Fill(_main.ShopDataSet.العملاء);
            loadingBackgroundWorker.ReportProgress(40);
            new الموردينTableAdapter().Fill(_main.ShopDataSet.الموردين);
            loadingBackgroundWorker.ReportProgress(50);
            new أنواع_البيعTableAdapter().Fill(_main.ShopDataSet.أنواع_البيع);
            loadingBackgroundWorker.ReportProgress(60);
            new الأنواع_الفرعية_للبيعTableAdapter().Fill(_main.ShopDataSet.الأنواع_الفرعية_للبيع);
            loadingBackgroundWorker.ReportProgress(70);
            new الأنواع_الخامTableAdapter().Fill(_main.ShopDataSet.الأنواع_الخام);
            loadingBackgroundWorker.ReportProgress(80);
            new الثلاجاتTableAdapter().Fill(_main.ShopDataSet.الثلاجات);
            loadingBackgroundWorker.ReportProgress(90);
            new أنواع_الصرفTableAdapter().Fill(_main.ShopDataSet.أنواع_الصرف);
            loadingBackgroundWorker.ReportProgress(100);
        }
        void LoadingBackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            startProgressBar.Style = ProgressBarStyle.Continuous;
            startProgressBar.Value = e.ProgressPercentage;
            switch (e.ProgressPercentage)
            {
                case 0:
                    statusLabel.Text = Properties.Resources.Loading + "البرنامج";
                    break;
                case 30:
                    statusLabel.Text = Properties.Resources.Loading + "جدول العملاء";
                    break;
                case 40:
                    statusLabel.Text = Properties.Resources.Loading + "جدول الموردين";
                    break;
                case 50:
                    statusLabel.Text = Properties.Resources.Loading + "جدول أنواع البيع";
                    break;
                case 60:
                    statusLabel.Text = Properties.Resources.Loading + "جدول أنواع البيع الفرعية";
                    break;
                case 70:
                    statusLabel.Text = Properties.Resources.Loading + "جدول الأنواع الخام"; 
                    break;
                case 80:
                    statusLabel.Text = Properties.Resources.Loading + "جدول الثلاجات";
                    break;
                case 90:
                    statusLabel.Text = Properties.Resources.Loading + "جدول أنواع الصرف";
                    break;
                case 100:
                    statusLabel.Text = "";
                    break;
            }
        }
        private void LoadingBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            // 
            // autoSaveBackgroundWorker
            // 
            autoSaveBackgroundWorker = new BackgroundWorker { WorkerReportsProgress = true };
            autoSaveBackgroundWorker.DoWork += AutoSaveBackgroundWorkerDoWork;
            autoSaveBackgroundWorker.ProgressChanged += AutoSaveBackgroundWorkerProgressChanged;
            autoSaveBackgroundWorker.RunWorkerAsync();
            Click += delegate { Hide(); };
            startProgressBar.Click += delegate { Hide(); };
            startProgressBar.Style = ProgressBarStyle.Marquee;
            _main.Show();
        }
        private static DateTime LastBackupdate
        {
            get
            {
                return
                    DateTime.Parse(
                    // ReSharper disable PossibleNullReferenceException
                        Registry.LocalMachine.CreateSubKey("software").CreateSubKey("SM").GetValue("lastsaveday",
                    // ReSharper restore PossibleNullReferenceException
                                                                                                   DateTime.MinValue).
                            ToString());
            }
        }
        /// <exception cref = "Exception"><c>Exception</c>.</exception>
        private void Loading_Shown(object sender, EventArgs e)
        {
            TopMost = true;
        }
        private Main _main;
        private readonly ServiceController _scSqlServer = new ServiceController("MSSQL$SQLEXPRESS");
        private readonly Thread _mainthread;
        private void AutoSaveBackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 50:
                    statusLabel.Visible = true;
                    statusLabel.Text = Properties.Resources.StartUpWizard_InitializeNormal_DoingAnAutomaticBackup;
                    break;
                case 100:
                    Hide();
                    break;
            }
        }
        private void AutoSaveBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            decimal elapsedDays = Convert.ToDecimal(DateTime.Today.Subtract(LastBackupdate).Days);
            String message = "لم يتم حفظ البيانات منذ " + elapsedDays + " يوم";
            if (LastBackupdate == DateTime.MinValue)
            {
                message = "لم يتم حفظ البيانات من قبل";
            }
            if (elapsedDays >= Settings.Default.SaveEvery && (!Settings.Default.PromptSaveEvery || MessageBox.Show(this,
                message + Environment.NewLine + Properties.Resources.StartUpWizard_Loading_Shown_SaveNow,
                Properties.Resources.StartUpWizard_Loading_Shown_DatabaseBackup,
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign)
                                                              == DialogResult.Yes))
            {
                autoSaveBackgroundWorker.ReportProgress(50);
                Directory.CreateDirectory(Settings.Default.BackUpDir);
                SaveRestoreProcess.SaveWithDefaultName(Settings.Default.BackUpDir);
                autoSaveBackgroundWorker.ReportProgress(100);
            }
            Thread.Sleep(3000);
            autoSaveBackgroundWorker.ReportProgress(100);
        }
        #endregion
        #region Wizard Code
        private void StartButtonClick(object sender, EventArgs e)
        {
            if (serialTextBox.Text != GetPassword() && activiationPanel.Visible)
            {
                statusToolStripStatusLabel.Text = Properties.Resources.StartUpWizard_startButton_Click_IncorrectSerial;
                return;
            }
            if (passwordTextBox.Text != confirmPasswordTextBox.Text || string.IsNullOrEmpty(passwordTextBox.Text) ||
                string.IsNullOrEmpty(confirmPasswordTextBox.Text))
            {
                statusToolStripStatusLabel.Text =
                    Properties.Resources.StartUpWizard_startButton_Click__PasswordAndConfirmationNotMatchingOrOneIsEmpty;
                return;
            }
            // ReSharper disable PossibleNullReferenceException
            Registry.LocalMachine.CreateSubKey("software").CreateSubKey("SM").SetValue("key",
                                                                                       OptionsForm.Hash(
                                                                                           passwordTextBox.Text));
            if (activiationPanel.Visible)
                Registry.LocalMachine.CreateSubKey("software").CreateSubKey("Microsoft").CreateSubKey("SRQQAP").SetValue
                    (
                        "key",
                    // ReSharper restore PossibleNullReferenceException
                        serialTextBox.Text);
            Settings.Default.ShopName = ShopNameTextBox.Text;
            Settings.Default.Save();
            startButton.Enabled = false;
            if (MainInstaller.DatabaseExists)
            {
                CreateDatabaseBackgroundWorkerRunWorkerCompleted(null, null);
                return;
            }
            statusToolStripStatusLabel.Text = Properties.Resources.StartUpWizard_startButton_Click_BuildingDatabase;
            createDatabaseBackgroundWorker.RunWorkerAsync();
        }
        private static string GetPass(IEnumerable<byte> bytes)
        {
            string passhashed = string.Empty;
            foreach (byte cbyte in bytes)
            {
                passhashed += string.Format("{0:X}", cbyte);
            }
            return passhashed;
        }
        private static byte[] Xor(byte[] arr1, byte[] arr2)
        {
            if (arr1.Length != arr2.Length) return null;
            var xor = new byte[arr1.Length];
            for (int i = 0; i < xor.Length; i++)
            {
                xor[i] = (byte)(arr1[i] ^ arr2[i]);
            }
            return xor;
        }
        private static string GetInfoItem(string key, string property)
        {
            var searcher = new ManagementObjectSearcher(string.Format("select {0} from  {1}", property, key));
            foreach (ManagementObject share in searcher.Get())
                return
                    share.Properties[property].Value.ToString();
            return null;
        }
        private static byte[] GetHash(string key, string property)
        {
            return
                new MD5CryptoServiceProvider().ComputeHash(
                    Encoding.Unicode.GetBytes(GetInfoItem(key, property)));
        }
        private static string GetPassword()
        {
            byte[] x = GetHash("win32_Bios", "SerialNumber");
            byte[] y = GetHash("win32_processor", "processorid");
            byte[] s = GetHash("win32_diskdrive", "signature");
            byte[] t = Xor(x, Xor(y, s));
            return GetPass(t);
        }
        private void SendInfoIdButtonClick(object sender, EventArgs e)
        {
            sendInfoIDButton.Enabled = false;
            statusToolStripStatusLabel.Text = Properties.Resources.StartUpWizard_sendInfoIDButton_Click_Sending;
            sendInfoBackgroundWorker.RunWorkerAsync(emailTextBox.Text);
        }
        private void SendInfoBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var message = new MailMessage
                                  {
                                      From = e.Argument.ToString(),
                                      Subject = string.Format("MachineInfo from {0}", e.Argument),
                                      To = "a_samy20036@yahoo.com",
                                      Body =
                                          string.Format("{0}&{1}&{2}", GetInfoItem("win32_Bios", "SerialNumber"),
                                                        GetInfoItem("win32_processor", "processorid"),
                                                        GetInfoItem("win32_diskdrive", "signature"))
                                  };
                GmailMessage.SendMailMessageFromGmail("pclubmail@gmail.com", "Software2008", message);
                e.Result = true;
            }
            catch
            {
                e.Result = false;
            }
        }
        private void SendInfoBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var result = (bool)e.Result;
            MessageBox.Show(result
                                ? Properties.Resources.
                                      StartUpWizard_sendInfoBackgroundWorker_RunWorkerCompleted_SendingSucceeded
                                : Properties.Resources.
                                      StartUpWizard_sendInfoBackgroundWorker_RunWorkerCompleted_NoInternet);
            statusToolStripStatusLabel.Text = Properties.Resources.Main_Ready;
            sendInfoIDButton.Enabled = true;
        }
        private void StartUpWizard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((e.CloseReason != CloseReason.UserClosing || !startButton.Enabled) &&
                e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
            }
        }
        private void CreateDatabaseBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _scSqlServer.WaitForStatus(ServiceControllerStatus.Running);
            Directory.CreateDirectory(MainInstaller.Dir + "Data");
            MainInstaller.GrantAccessToUsers(new DirectoryInfo(MainInstaller.Dir + "Data"));
            MainInstaller.DeleteDataBase();
            MainInstaller.CreateBlankDataBase(MainInstaller.Dir, TreasuryBalanceNumericUpDown.Value, true);
        }
        private void CreateDatabaseBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Controls.Remove(panel1);
            InitializeNormal();
            Loading_Shown(null, null);
        }
        private void PasteButtonClick(object sender, EventArgs e)
        {
            serialTextBox.Text = Clipboard.GetText();
        }
        #endregion
    }
}