#region using directives

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using ShopManager.Main_Forms;
using ShopManager.ProjectResources.Properties;

#endregion

namespace ShopManager
{
    public partial class OptionsForm : Form
    {
        public OptionsForm(Main main)
        {
            InitializeComponent();
            _main = main;
        }

        #region Properties

        private readonly Main _main;

        private decimal Balance
        {
            get { return (decimal)الخزينةTableAdapter.GetBalance(); }
        }

        #endregion

        #region Methods

        public static string Hash(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            byte[] hashed = md5.ComputeHash(Encoding.Unicode.GetBytes(password));
            string passhashed = string.Empty;
            foreach (byte cbyte in hashed)
            {
                passhashed += string.Format("{0:X}", cbyte);
            }
            return passhashed;
        }

        private void RefreshData()
        {
            Main.RefreshDataInControls(_main.mainTreeView.Nodes[0].Nodes);
            Main.RefreshDataInControls(_main.mainTreeView.Nodes[1].Nodes);
        }

        #endregion

        #region Handlers

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            errorLabel.ForeColor = Color.Red;
            string currentpassword =
                // ReSharper disable PossibleNullReferenceException
                Registry.LocalMachine.CreateSubKey("software").CreateSubKey("SM").GetValue("key", "SecurityCorrupted").
                // ReSharper restore PossibleNullReferenceException
                    ToString();
            if (currentpassword == "SecurityCorrupted")
            {
                errorLabel.Text = "تم التلاعب بالبرنامج من فضلك قم بإعادة تثبيت البرنامج.";
                errorLabel.Visible = true;
                return;
            }
            if (!(Hash(OldPasswordTextBox.Text) == currentpassword))
            {
                errorLabel.Text = "كلمة السر الحالية التي أدخلتها خطأ.";
                errorLabel.Visible = true;
                return;
            }
            if (String.IsNullOrEmpty(newPasswordTextBox.Text) || String.IsNullOrEmpty(confirmNewPasswordTextBox.Text))
            {
                errorLabel.Text = "لا يمكن أن تكون كلمة السر الجديدة أو تأكيدها فارغة.";
                errorLabel.Visible = true;
                return;
            }
            if (newPasswordTextBox.Text != confirmNewPasswordTextBox.Text)
            {
                errorLabel.Text = "كلمة السر و تأكيدها غير متطابقتين.";
                errorLabel.Visible = true;
                return;
            }
            // ReSharper disable PossibleNullReferenceException
            Registry.LocalMachine.CreateSubKey("software").CreateSubKey("SM").SetValue("key",
                // ReSharper restore PossibleNullReferenceException
                                                                                       Hash(newPasswordTextBox.Text));
            errorLabel.Text = "تم التغيير بنجاح.";
            errorLabel.ForeColor = Color.Black;
            errorLabel.Visible = true;
        }

        private void startupimageOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            startupimagepathTextBox.Text = startupimageOpenFileDialog.FileName;
        }

        private void chooseImageButton_Click(object sender, EventArgs e)
        {
            startupimageOpenFileDialog.ShowDialog();
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.None)
            {
                e.Cancel = true;
            }
            Settings.Default.Save();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            AcceptButton = changePasswordButton;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            AcceptButton = chooseImageButton;
        }

        private void SQLExecuteButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(SQLtextBox.Text)) return;

            MainInstaller.ExecuteSql("ShopDatabase", SQLtextBox.Text, MainInstaller.ExecuteMode.ExecuteBatch, false);
            RefreshData();
        }

        private void SQLtextBox_Enter(object sender, EventArgs e)
        {
            AcceptButton = SQLExecuteButton;
            CancelButton = clearButton;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            SQLtextBox.Text = string.Empty;
        }

        private void OptionsForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Escape && e.Shift && tabControl.SelectedTab == SQLtabPage)
                SQLtextBox.Clear();
            else if (e.KeyValue == (int)Keys.Escape)
                Close();
        }

        private void chooseDirButton_Click(object sender, EventArgs e)
        {
            while (true)
            {
                if (backupfolderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetPathRoot(Environment.SystemDirectory) ==
                        Path.GetPathRoot(backupfolderBrowserDialog.SelectedPath))
                    {
                        MessageBox.Show("يجب الحفظ بعيدا عن قرص النظام");
                    }
                    else
                    {
                        break;
                    }
                }
                backupPathTextBox.Text = backupfolderBrowserDialog.SelectedPath;
            }
        }

        private void addToBalanceButton_Click(object sender, EventArgs e)
        {
            الخزينةTableAdapter.InsertBalance(balanceNumericUpDown.Value, DateTime.Today);
            OptionsForm_Load(null, null);
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            balanceNowNumericUpDown.Value = Balance;
        }

        private void savetoLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            saveFileDialog.FileName = SaveRestoreProcess.DefaultBackupName;
            DialogResult result = saveFileDialog.ShowDialog();
            if (result != DialogResult.OK) return;
            errorMessageTextBox.Text = "جاري التنفيذ ...";
            SaveRestoreProcess.Saveto(saveFileDialog.FileName);
            errorMessageTextBox.Text = "تم تنفيذ العملية بنجاح";
        }

        private void restorefromLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            errorMessageTextBox.Text = "جاري التنفيذ ...";
            SaveRestoreProcess.RestoreFrom(openFileDialog.FileName);
            errorMessageTextBox.Text = "تم تنفيذ العملية بنجاح";
            RefreshData();
        }

        private void restorelastlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!File.Exists(Settings.Default.lastsavePath)) return;
            errorMessageTextBox.Text = "جاري التنفيذ ...";
            SaveRestoreProcess.RestoreFrom(Settings.Default.lastsavePath);
            errorMessageTextBox.Text = "تم تنفيذ العملية بنجاح";
            RefreshData();
        }

        private void savetolastLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!File.Exists(Settings.Default.lastrestorePath)) return;
            errorMessageTextBox.Text = "جاري التنفيذ ...";
            SaveRestoreProcess.Saveto(Settings.Default.lastrestorePath);
            errorMessageTextBox.Text = "تم تنفيذ العملية بنجاح";
        }

        private void restoreImageDefaultButton_Click(object sender, EventArgs e)
        {
            startupimagepathTextBox.Clear();
        }

        private void newDatabaseButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes ==
                MessageBox.Show(
                    "هل أنت متأكد من أنك تريد مسح قاعدة البيانات الحالية و بدء قاعدة بيانات جديدة؟" +
                    Environment.NewLine + " !!جميع البيانات التي لم يتم عمل حفظ احتياطي لها سوف تفقد للأبد",
                    "بدء قاعدة بيانات جديدة", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign))
            {
                SaveRestoreProcess.KillProcessesHoldingDb();
                try
                {
                    MainInstaller.DeleteDataBase();
                }
                catch (Exception)
                {
                    MainInstaller.DeleteDataBase();
                }
                MainInstaller.CreateBlankDataBase(MainInstaller.Dir, 0, false);
                try
                {
                    balanceNowNumericUpDown.Value = Balance;
                }
                // ReSharper disable EmptyGeneralCatchClause
                catch
                // ReSharper restore EmptyGeneralCatchClause
                {
                }
                finally
                {
                    balanceNowNumericUpDown.Value = Balance;
                }
            }
            RefreshData();
        }

        #endregion

        private void openSqlButton_Click(object sender, EventArgs e)
        {
            if (sqlOpenFileDialog.ShowDialog() != DialogResult.OK) return;
            MainInstaller.ExecuteSql("ShopDatabase", File.ReadAllText(sqlOpenFileDialog.FileName), MainInstaller.ExecuteMode.ExecuteBatch, false);
            RefreshData();
        }
    }
}