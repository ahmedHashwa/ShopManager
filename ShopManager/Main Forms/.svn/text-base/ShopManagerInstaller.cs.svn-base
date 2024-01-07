#region using directives

using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using ShopManager.ProjectResources.Properties;

#endregion

namespace ShopManager.Main_Forms
{
    [RunInstaller(true)]
    public partial class ShopManagerInstaller : Installer
    {
        public ShopManagerInstaller()
        {
            InitializeComponent();
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            if (MainInstaller.DatabaseExists)
            {
                DialogResult deleteDBresult = MessageBox.Show(
                    "هل تريد حذف قاعدة البيانات؟ " + Environment.NewLine +
                    "اضغط (Yes)لحذف قاعدة البيانات" + Environment.NewLine +
                    "اضغط (No)لإبقاء قاعدة البيانات للاستخدام عند التثبيت مرة أخرى"
                    , "حذف قاعدة البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                if (deleteDBresult == DialogResult.Yes)
                    MainInstaller.DeleteDataBase();
            }
            DialogResult deleteDataresult = MessageBox.Show(
                "هل تريد حذف بيانات البرنامج مثل كلمة السر و مكان الحفظ التقائي و غيره؟ " + Environment.NewLine +
                "اضغط (Yes)لحذف البيانات" + Environment.NewLine +
                "اضغط (No)لإبقاء البيانات للاستخدام عند التثبيت مرة أخرى"
                , "حذف البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            if (deleteDataresult == DialogResult.Yes)
            {
                // ReSharper disable PossibleNullReferenceException
                Registry.LocalMachine.CreateSubKey("software").CreateSubKey("Microsoft").DeleteSubKey(
                    "SRQQAP", false);
                Registry.LocalMachine.CreateSubKey("software").CreateSubKey("Microsoft").DeleteSubKey(
                    "SM", false);
                Settings.Default.Reset();
                Directory.Delete(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\sOlOnXPL_Software",
                    true);
                // ReSharper restore PossibleNullReferenceException
            }
        }
    }
}