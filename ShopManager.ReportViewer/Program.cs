﻿#region using directives

using System;
using System.Windows.Forms;

#endregion

namespace ShopManager.ReportViewer
{
    internal static class Program
    {
        /// <summary>
        ///   The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainReportViewerForm());
        }
    }
}