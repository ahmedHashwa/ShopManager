#region using directives

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ShopManager.Controls.Basic;
using ShopManager.Main_Forms;
using ShopManager.Properties;

#endregion

namespace ShopManager
{
    internal static class Program
    {
        /// <summary>
        ///   The main entry point for the application.
        /// </summary>
        /// <exception cref = "Exception"><c>Exception</c>.</exception>
        [STAThread]
        private static void Main()
        {
            bool exthrown = false;
        startAgain:
            try
            {
                if (
                    Process.GetProcessesByName(Path.GetFileNameWithoutExtension(AppDomain.CurrentDomain.FriendlyName)).
                        Length > 1)
                {
                    MessageBox.Show(Resources.Program_Main_UseOnlyOneInstance);
                    return;
                }
                Application.EnableVisualStyles();
                if (!exthrown)
                    Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new StartUpWizard());
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Dispose()"))
                    return;
                exthrown = true;
                ParentControl.WriteToLog(ex);
                DialogResult result = MessageBox.Show(Resources.Program_Main_FollowingErrorHappened + ex.Message
                                                      + Environment.NewLine
                                                      + Resources.Program_Main_WhatToDo
                                                      + Environment.NewLine
                                                      + Resources.Program_Main__Yes__SendReportOnline
                                                      + Environment.NewLine
                                                      + Resources.Program_Main__No__CopyToAFile
                                                      + Environment.NewLine
                                                      + Resources.Program_Main__Cancel_DoNothing
                                                      , Resources.Program_Main_ErrorOccured,
                                                      MessageBoxButtons.YesNoCancel,
                                                      MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                                                      MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                switch (result)
                {
                    case DialogResult.Yes:
                        ParentControl.SendErrorReportEmail();
                        break;
                    case DialogResult.No:
                        ParentControl.CopyErrorReportTo();
                        break;
                }
                if (Debugger.IsAttached)
                    throw;
                if (DialogResult.Yes == MessageBox.Show(
                                                              Resources.Program_Main_ProgramWillBeRestarted
                                                             , "إعادة تشغيل البرنامج",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                                                             MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign))
                    goto startAgain;
            }
        }
    }
}