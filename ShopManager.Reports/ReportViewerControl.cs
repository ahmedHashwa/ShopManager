#region using directives

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using ShopManager.ProjectResources.Data.commonDataSetTableAdapters;
using ShopManager.ProjectResources.Properties;
using ShopManager.Reports.ReportDataSetTableAdapters;

#endregion

namespace ShopManager.Reports
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ReportViewerControl : UserControl
    {
        private readonly ReportDataSet _mainDataSet;

        /// <summary>
        /// 
        /// </summary>
        public ReportViewerControl()
            : this(null)
        {
        }

        private ReportViewerControl(ReportDataSet ds)
        {
            InitializeComponent();
            secondComboBoxBindingSource.DataSource =
                firstComboBoxBindingSource.DataSource =
                mainBindingSource.DataSource = _mainDataSet = ds ?? new ReportDataSet();

            foreach (String item in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                if (item.Contains("rdlc"))
                {
                    selectReportComboBox.Items.Add(item.Split('.')[3]);
                }
            }
            selectReportComboBox.Sorted = true;
            selectReportComboBox.SelectedIndex = 0;
            reportStartDateDateTimePicker.Value =
                DateTime.Now.Subtract(new TimeSpan(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 0, 0, 0));
            RefrehCapitalPictureBoxClick(null, null);
        }

        private String StartDate
        {
            get
            {
                return (reportviewAllcheckBox.Checked)
                           ? DateTime.Parse("1-1-1800").ToShortDateString()
                           : reportStartDateDateTimePicker.Value.Date.ToShortDateString();
            }
        }

        private String EndDate
        {
            get
            {
                return (reportviewAllcheckBox.Checked)
                           ? DateTime.MaxValue.ToShortDateString()
                           : reportEndDatedateTimePicker.Value.Date.ToShortDateString();
            }
        }

        private string ReportPath
        {
            get { return "ShopManager.Reports.Reports." + selectReportComboBox.Text + ".rdlc"; }
        }

        private void PrepareReport(params ReportParameter[] parameters)
        {
            var rp = new List<ReportParameter>
                         {
                             new ReportParameter("StartDate", StartDate),
                             new ReportParameter("EndDate", EndDate),
                             new ReportParameter("ReportName", selectReportComboBox.Text),
                             new ReportParameter("ShopName", Settings.Default.ShopName)
                         };
            rp.AddRange(parameters);
            mainReportViewer.LocalReport.SetParameters(rp);
            mainReportViewer.RefreshReport();
        }

        private void ShowSalesN_CagesReport(Action action)
        {
            switch (action)
            {
                case Action.Click:
                    mainBindingSource.DataMember = "مبيعات كميات";
                    mainReportViewer.LocalReport.DataSources.Add(
                        new ReportDataSource("DataSet_مبيعات_كميات", mainBindingSource));
                    new مبيعات_كمياتTableAdapter().Fill(_mainDataSet.مبيعات_كميات, firstComboBox.Text);

                    PrepareReport(new ReportParameter("ClientName", firstComboBox.Text),
                                  new ReportParameter("SalesKind",
                                                      (allsecondcheckBox.Checked) ? "*" : secondComboBox.Text),
                                  new ReportParameter("TotalPaidSum",
                                                      (new QueriesTableAdapter().GetTotalGain(
                                                          DateTime.Parse(StartDate), DateTime.Parse(EndDate),
                                                          firstComboBox.Text,
                                                          (allsecondcheckBox.Checked) ? "%" : secondComboBox.Text) ??
                                                       "0").ToString())
                        );
                    break;
                case Action.Choose:
                    periodPanel.Visible = firstComboPanel.Visible = secondComboPanel.Visible = true;
                    firstComboBoxBindingSource.DataMember = "العملاء";
                    secondComboBoxBindingSource.DataMember = "أنواع البيع";
                    firstLabel.Text = Resources.ReportViewerControl_ShowSalesN_CagesReport_clientName;
                    secondLabel.Text = Resources.ReportViewerControl_ShowSalesN_CagesReport_juiceType;
                    allsecondcheckBox.Text = Resources.ReportViewerControl_ShowSalesN_CagesReport_AllJuice;
                    new أنواع_البيعTableAdapter().Fill(_mainDataSet.أنواع_البيع);
                    new العملاءTableAdapter().Fill(_mainDataSet.العملاء);
                    AfterSelectActions();
                    viewReportButton.Enabled = secondComboBox.Items.Count != 0 && firstComboBox.Items.Count != 0;
                    break;
            }
        }

        private void ShowSalesN_CagesforClientsReport(Action action)
        {
            switch (action)
            {
                case Action.Click:
                    mainBindingSource.DataMember = "مبيعات كميات";
                    mainReportViewer.LocalReport.DataSources.Add(
                        new ReportDataSource("DataSet_مبيعات_كميات", mainBindingSource));
                    new مبيعات_كمياتTableAdapter().FillBy(_mainDataSet.مبيعات_كميات);

                    PrepareReport();
                    break;
                case Action.Choose:
                    periodPanel.Visible = true;
                    firstComboPanel.Visible = secondComboPanel.Visible = false;
                    AfterSelectActions();
                    viewReportButton.Enabled = true;
                    break;
            }
        }

        private void ShowClientsDebtReport(Action action)
        {
            switch (action)
            {
                case Action.Click:
                    mainBindingSource.DataMember = "حساب العملاء";
                    mainReportViewer.LocalReport.DataSources.Add(
                        new ReportDataSource("ReportDataSet_حساب_العملاء", mainBindingSource));
                    new حساب_العملاءTableAdapter().Fill(_mainDataSet.حساب_العملاء, DateTime.Parse(StartDate),
                                                        DateTime.Parse(EndDate));
                    PrepareReport();
                    break;
                case Action.Choose:
                    periodPanel.Visible = true;
                    firstComboPanel.Visible = secondComboPanel.Visible = false;
                    AfterSelectActions();
                    viewReportButton.Enabled = true;
                    break;
            }
        }

        private void ShowSuppliersCreditReport(Action action)
        {
            switch (action)
            {
                case Action.Click:
                    mainBindingSource.DataMember = "حساب الموردين";
                    mainReportViewer.LocalReport.DataSources.Add(
                        new ReportDataSource("ReportDataSet_حساب_الموردين", mainBindingSource));
                    new حساب_الموردينTableAdapter().Fill(_mainDataSet.حساب_الموردين, DateTime.Parse(StartDate),
                                                         DateTime.Parse(EndDate));
                    PrepareReport();
                    break;
                case Action.Choose:
                    periodPanel.Visible = true;
                    firstComboPanel.Visible = secondComboPanel.Visible = false;
                    AfterSelectActions();
                    viewReportButton.Enabled = true;
                    break;
            }
        }

        private void ShowClientsGrossDebtReport(Action action)
        {
            switch (action)
            {
                case Action.Click:
                    mainBindingSource.DataMember = "صافي حساب العملاء";
                    mainReportViewer.LocalReport.DataSources.Add(
                        new ReportDataSource("ReportDataSet_صافي_حساب_العملاء", mainBindingSource));
                    new صافي_حساب_العملاءTableAdapter().Fill(_mainDataSet.صافي_حساب_العملاء);
                    PrepareReport();
                    break;
                case Action.Choose:
                    periodPanel.Visible = firstComboPanel.Visible = secondComboPanel.Visible = false;
                    AfterSelectActions();
                    viewReportButton.Enabled = true;

                    break;
            }
        }

        private void ShowSuppliersGrossCreditReport(Action action)
        {
            switch (action)
            {
                case Action.Click:
                    mainBindingSource.DataMember = "صافي حساب الموردين";
                    mainReportViewer.LocalReport.DataSources.Add(
                        new ReportDataSource("ReportDataSet_صافي_حساب_الموردين", mainBindingSource));
                    new صافي_حساب_الموردينTableAdapter().Fill(_mainDataSet.صافي_حساب_الموردين);
                    foreach (ReportDataSet.صافي_حساب_الموردينRow row in _mainDataSet.صافي_حساب_الموردين.Rows)
                    {
                        row.رصيد_أول_المدة = (decimal)new CommonQueriesTableAdapter().sp_GetSupplierCredit(row.اسم_المورد);
                    }
                    _mainDataSet.صافي_حساب_الموردين.AcceptChanges();
                    PrepareReport();
                    break;
                case Action.Choose:
                    periodPanel.Visible = firstComboPanel.Visible = secondComboPanel.Visible = false;
                    AfterSelectActions();
                    viewReportButton.Enabled = true;
                    break;
            }
        }

        private void ShowSalesMoneyReport(Action action)
        {
            switch (action)
            {
                case Action.Click:
                    mainBindingSource.DataMember = "مبيعات نقود";
                    object debt =
                        new QueriesTableAdapter().sp_GetClientDebtSt(firstComboBox.Text);
                    mainReportViewer.LocalReport.DataSources.Add(
                        new ReportDataSource("DataSet_مبيعات_نقود", mainBindingSource));
                    new مبيعات_نقودTableAdapter().Fill(_mainDataSet.مبيعات_نقود, firstComboBox.Text);
                    PrepareReport(new ReportParameter("ClientName", firstComboBox.Text)
                                  , new ReportParameter("Debt", debt.ToString())
                        );
                    break;
                case Action.Choose:
                    periodPanel.Visible = firstComboPanel.Visible = true;
                    secondComboPanel.Visible = false;
                    firstComboBoxBindingSource.DataMember = "العملاء";
                    firstLabel.Text = Resources.ReportViewerControl_ShowSalesN_CagesReport_clientName;
                    new العملاءTableAdapter().Fill(_mainDataSet.العملاء);
                    AfterSelectActions();
                    viewReportButton.Enabled = firstComboBox.Items.Count != 0;
                    break;
            }
        }

        private void ShowPurchaseReport(Action action)
        {
            switch (action)
            {
                case Action.Click:
                    mainBindingSource.DataMember = "المشتريات";
                    var tableAdapter = new المشترياتTableAdapter();
                    tableAdapter.Fill(_mainDataSet.المشتريات);
                    mainReportViewer.LocalReport.DataSources.Add(
                        new ReportDataSource("DataSet_المشتريات", mainBindingSource));
                    PrepareReport(new ReportParameter("ClientName", firstComboBox.Text)
                                  ,
                                  new ReportParameter("Credit",
                                                       new CommonQueriesTableAdapter().sp_GetSupplierCredit(firstComboBox.Text).ToString())
                                  , new ReportParameter("SalesKind",
                                                        (allsecondcheckBox.Checked) ? "*" : secondComboBox.Text)
                        );
                    break;
                case Action.Choose:
                    periodPanel.Visible = firstComboPanel.Visible = secondComboPanel.Visible = true;
                    firstComboBoxBindingSource.DataMember = "الموردين";
                    secondComboBoxBindingSource.DataMember = "الأنواع الخام";
                    firstLabel.Text = Resources.ReportViewerControl_ShowSelectPurchaseReport_SupplierName;
                    secondLabel.Text = Resources.ReportViewerControl_ShowSelectPurchaseReport_RawType;
                    allsecondcheckBox.Text = Resources.ReportViewerControl_ShowSelectPurchaseReport_AllRaw;
                    new الأنواع_الخامTableAdapter().Fill(_mainDataSet.الأنواع_الخام);
                    new الموردينTableAdapter().Fill(_mainDataSet.الموردين);
                    AfterSelectActions();
                    viewReportButton.Enabled = secondComboBox.Items.Count != 0 && firstComboBox.Items.Count != 0;
                    break;
            }
        }

        private void ShowManufacturingsReport(Action action)
        {
            switch (action)
            {
                case Action.Click:
                    mainBindingSource.DataMember = "التصنيع";
                    var tableAdapter = new التصنيعTableAdapter();
                    tableAdapter.Fill(_mainDataSet.التصنيع);
                    mainReportViewer.LocalReport.DataSources.Add(
                        new ReportDataSource("DataSet_التصنيع", mainBindingSource));
                    PrepareReport(new ReportParameter("SalesKind",
                                                      (allsecondcheckBox.Checked) ? "*" : secondComboBox.Text)
                        );
                    break;
                case Action.Choose:
                    firstComboPanel.Visible = false;
                    periodPanel.Visible = secondComboPanel.Visible = true;
                    secondComboBoxBindingSource.DataMember = "الأنواع الخام";
                    secondLabel.Text = Resources.ReportViewerControl_ShowSelectPurchaseReport_RawType;
                    allsecondcheckBox.Text = Resources.ReportViewerControl_ShowSelectPurchaseReport_AllRaw;
                    new الأنواع_الخامTableAdapter().Fill(_mainDataSet.الأنواع_الخام);
                    AfterSelectActions();
                    viewReportButton.Enabled = secondComboBox.Items.Count != 0;
                    break;
            }
        }

        private void ShowFridgesStoragesReport(Action action)
        {
            switch (action)
            {
                case Action.Click:
                    mainBindingSource.DataMember = "وارد_الثلاجة";
                    new وارد_الثلاجةTableAdapter().FillByFridgeID(_mainDataSet.وارد_الثلاجة, (int)firstComboBox.SelectedValue);
                    mainReportViewer.LocalReport.DataSources.Add(
                        new ReportDataSource("DataSet_وارد_الثلاجة", mainBindingSource));
                    int? N_Kilos = new CommonQueriesTableAdapter().GetRawN_KilosBalance((int)firstComboBox.SelectedValue,
                        (int)secondComboBox.SelectedValue);
                    PrepareReport(new ReportParameter("ClientName", firstComboBox.Text),
                                  new ReportParameter("N_Kilos",
                                                      N_Kilos.HasValue ? N_Kilos.Value.ToString() : "-1"),
                                  new ReportParameter("SalesKind",
                                                      (allsecondcheckBox.Checked) ? "*" : secondComboBox.Text)
                        );
                    break;
                case Action.Choose:
                    firstComboPanel.Visible = periodPanel.Visible = secondComboPanel.Visible = true;
                    firstComboBoxBindingSource.DataMember = "الثلاجات";
                    secondComboBoxBindingSource.DataMember = "الأنواع الخام";
                    firstLabel.Text = Resources.ReportViewerControl_ShowFridgesStoragesReport_FridgeName;
                    secondLabel.Text = Resources.ReportViewerControl_ShowSelectPurchaseReport_RawType;
                    allsecondcheckBox.Text = Resources.ReportViewerControl_ShowSelectPurchaseReport_AllRaw;
                    new الثلاجاتTableAdapter().Fill(_mainDataSet.الثلاجات);
                    new الأنواع_الخامTableAdapter().Fill(_mainDataSet.الأنواع_الخام);
                    AfterSelectActions();
                    viewReportButton.Enabled = secondComboBox.Items.Count != 0 && firstComboBox.Items.Count != 0;
                    break;
            }
        }
        private void ShowFridgesInOutReport(Action action)
        {
            switch (action)
            {
                case Action.Click:
                    mainBindingSource.DataMember = "وارد_الثلاجة";
                    new وارد_الثلاجةTableAdapter().FillByFridgeID(_mainDataSet.وارد_الثلاجة, (int)firstComboBox.SelectedValue);

                    new منصرف_الثلاجةTableAdapter().Fill(_mainDataSet.منصرف_الثلاجة, (int)firstComboBox.SelectedValue);

                    mainReportViewer.LocalReport.DataSources.Add(
                        new ReportDataSource("DataSet_وارد_الثلاجة", mainBindingSource));
                    mainReportViewer.LocalReport.DataSources.Add(
                        new ReportDataSource("DataSet_منصرف_الثلاجة", new BindingSource { DataSource = _mainDataSet, DataMember = "منصرف_الثلاجة" }));
                    var N_Kilos = new CommonQueriesTableAdapter().GetRawN_KilosBalance((int)firstComboBox.SelectedValue,
                        (int)secondComboBox.SelectedValue);
                    var N_Cages = new CommonQueriesTableAdapter().GetRawN_Cages((int)firstComboBox.SelectedValue,
                        (int)secondComboBox.SelectedValue);
                    PrepareReport(new ReportParameter("ClientName", firstComboBox.Text),
                              new ReportParameter("N_Cages",
                                                  N_Cages.HasValue ? N_Cages.Value.ToString() : "-1"),

                              new ReportParameter("N_Kilos",
                                                  N_Kilos.HasValue ? N_Kilos.Value.ToString() : "-1"),
                              new ReportParameter("SalesKind", secondComboBox.Text)
                    );
                    break;
                case Action.Choose:
                    firstComboPanel.Visible = periodPanel.Visible = secondComboPanel.Visible = true;
                    allsecondcheckBox.Visible = false;
                    firstComboBoxBindingSource.DataMember = "الثلاجات";
                    secondComboBoxBindingSource.DataMember = "الأنواع الخام";
                    firstLabel.Text = Resources.ReportViewerControl_ShowFridgesStoragesReport_FridgeName;
                    secondLabel.Text = Resources.ReportViewerControl_ShowSelectPurchaseReport_RawType;
                    allsecondcheckBox.Text = Resources.ReportViewerControl_ShowSelectPurchaseReport_AllRaw;
                    new الثلاجاتTableAdapter().Fill(_mainDataSet.الثلاجات);
                    new الأنواع_الخامTableAdapter().Fill(_mainDataSet.الأنواع_الخام);
                    AfterSelectActions();
                    viewReportButton.Enabled = secondComboBox.Items.Count != 0 && firstComboBox.Items.Count != 0;
                    break;
            }
        }
        private void ShowCashReport(Action action)
        {
            switch (action)
            {
                case Action.Click:
                    mainBindingSource.DataMember = "الخزينة";
                    mainReportViewer.LocalReport.DataSources.Add(
                        new ReportDataSource("DataSet_الخزينة", mainBindingSource));
                    var treasuryTa = new الخزينةTableAdapter();
                    treasuryTa.Fill(_mainDataSet.الخزينة);
                    decimal? initialbalance = treasuryTa.GetInitialBalance();
                    foreach (ReportDataSet.الخزينةRow row in _mainDataSet.الخزينة.Rows)
                    {
                        initialbalance += row.التغيير;
                        if (initialbalance != null) row.الرصيد = initialbalance.Value;
                    }


                    PrepareReport();
                    break;
                case Action.Choose:
                    periodPanel.Visible = firstComboPanel.Visible = secondComboPanel.Visible = false;
                    AfterSelectActions();
                    viewReportButton.Enabled = true;
                    break;
            }
        }

        private void ShowTotalExpensesReport(Action action)
        {
            switch (action)
            {
                case Action.Click:
                    mainBindingSource.DataMember = "إجمالي مصروفات";
                    mainReportViewer.LocalReport.DataSources.Add(
                        new ReportDataSource("ReportDataSet_إجمالي_مصروفات", mainBindingSource));
                    new إجمالي_مصروفاتTableAdapter().Fill(_mainDataSet.إجمالي_مصروفات, DateTime.Parse(StartDate),
                                                          DateTime.Parse(EndDate));
                    PrepareReport();
                    break;
                case Action.Choose:
                    periodPanel.Visible = true;
                    firstComboPanel.Visible = secondComboPanel.Visible = false;
                    AfterSelectActions();
                    viewReportButton.Enabled = true;
                    break;
            }
        }

        private void ShowTotalSalesReport(Action action)
        {
            switch (action)
            {
                case Action.Click:
                    mainBindingSource.DataMember = "إجمالي مبيعات كمية العصير";

                    mainReportViewer.LocalReport.DataSources.Add(
                        new ReportDataSource("ReportDataSet_إجمالي_مبيعات_كمية_العصير", mainBindingSource));
                    new إجمالي_مبيعات_كمية_العصيرTableAdapter().Fill(_mainDataSet.إجمالي_مبيعات_كمية_العصير,
                                                                     DateTime.Parse(StartDate), DateTime.Parse(EndDate));
                    PrepareReport();
                    break;
                case Action.Choose:
                    periodPanel.Visible = true;
                    firstComboPanel.Visible = secondComboPanel.Visible = false;
                    AfterSelectActions();
                    viewReportButton.Enabled = true;
                    break;
            }
        }

        private void ReportViewInternalButtonClick(object sender, EventArgs e)
        {
            var action = (sender is ComboBox) ? Action.Choose : Action.Click;

            if (sender is Button)
            {
                mainReportViewer.Reset();
                mainReportViewer.LocalReport.ReportEmbeddedResource = ReportPath;
            }
            else
            {
                allsecondcheckBox.Visible = true;

            }

            switch (selectReportComboBox.Text)
            {
                case "مبيعات كمية":
                    ShowSalesN_CagesReport(action);
                    break;
                case "التصنيع":
                    ShowManufacturingsReport(action);
                    break;
                case "مبيعات للعملاء":
                    ShowSalesN_CagesforClientsReport(action);
                    break;
                case "مبيعات نقود":
                    ShowSalesMoneyReport(action);
                    break;
                case "المشتريات":
                    ShowPurchaseReport(action);
                    break;
                case "الخزينة":
                    ShowCashReport(action);
                    break;
                case "حساب العملاء":
                    ShowClientsDebtReport(action);
                    break;
                case "حساب الموردين":
                    ShowSuppliersCreditReport(action);
                    break;
                case "صافي حساب العملاء":
                    ShowClientsGrossDebtReport(action);
                    break;
                case "صافي حساب الموردين":
                    ShowSuppliersGrossCreditReport(action);
                    break;
                case "إجمالي المصروفات":
                    ShowTotalExpensesReport(action);
                    break;
                case "وارد الثلاجة":
                    ShowFridgesStoragesReport(action);
                    break;
                case "حركة الثلاجة":
                    ShowFridgesInOutReport(action);
                    break;
                case "إجمالي المبيعات":
                    ShowTotalSalesReport(action);
                    break;
            }

        }

        private void AfterSelectActions()
        {
            allsecondcheckBox.Checked = reportviewAllcheckBox.Checked = false;
            if (firstComboPanel.Visible)
            {
                firstComboBox.DataSource = firstComboBoxBindingSource;
                firstComboBoxBindingSource.Sort =
                    firstComboBox.DisplayMember = "الاسم";
                firstComboBox.ValueMember = "معرف";
            }
            if (secondComboPanel.Visible)
            {
                secondComboBox.DataSource = secondComboBoxBindingSource;
                secondComboBoxBindingSource.Sort =
                    secondComboBox.DisplayMember = "الاسم";
                secondComboBox.ValueMember = "معرف";
            }
        }

        private void RefrehCapitalPictureBoxClick(object sender, EventArgs e)
        {
            balanceNumericUpDown.Value = (decimal)new الخزينةTableAdapter().GetBalance();
            if (ParentForm != null) ParentForm.AcceptButton = viewReportButton;
        }


        private void ReportviewAllcheckBoxCheckedChanged(object sender, EventArgs e)
        {
            reportStartDateDateTimePicker.Enabled = reportEndDatedateTimePicker.Enabled = !reportviewAllcheckBox.Checked;
        }

        private void ReportViewerControl_Load(object sender, EventArgs e)
        {
            RefrehCapitalPictureBoxClick(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ToggleReportSelector()
        {
            mainSplitContainer.Panel1Collapsed = !mainSplitContainer.Panel1Collapsed;
        }

        private void AllkindscheckBoxCheckedChanged(object sender, EventArgs e)
        {
            secondComboBox.Enabled = !allsecondcheckBox.Checked;
        }

        #region Nested type: Action

        private enum Action
        {
            Click,
            Choose
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void SelectFirstBoxInPanel()
        {
            selectReportComboBox.Select();
        }
    }
}