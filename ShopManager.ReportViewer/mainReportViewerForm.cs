#region using directives

using System;
using System.Windows.Forms;

#endregion

namespace ShopManager.ReportViewer
{
    public partial class mainReportViewerForm : Form
    {
        /// <summary>
        /// </summary>
        public mainReportViewerForm()
        {
            if (!Database.DatabaseExists)
                RetoreDatabase();
            InitializeComponent();
        }

        private static void RetoreDatabase()
        {
            var openDbFileDialog = new OpenFileDialog
                                       {
                                           DefaultExt = "smbak",
                                           Filter = "نسخة احتياطية من قاعدة بيانات(*.smbak)|*.smbak",
                                           Title = "اختر موقعا تسترد البيانات منه"
                                       };
            DialogResult dialogResult = openDbFileDialog.ShowDialog();
            switch (dialogResult)
            {
                case DialogResult.OK:
                    Database.RestoreFrom(openDbFileDialog.FileName);
                    break;
                default:
                    MessageBox.Show("يجب أن توجد قاعدة البيانات قبل العمل");
                    Application.Exit();
                    break;
            }
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            RetoreDatabase();
        }
    }
}