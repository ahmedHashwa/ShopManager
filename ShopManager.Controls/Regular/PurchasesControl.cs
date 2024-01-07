﻿#region using directives
using System;
using System.Drawing;
using System.Windows.Forms;
using ShopManager.Controls.Basic;
using ShopManager.Controls.Data;
using ShopManager.ProjectResources.Data.commonDataSetTableAdapters;
using ShopManager.ProjectResources.Properties;
#endregion
namespace ShopManager.Controls.Regular
{
    // ReSharper disable UnusedMember.Global
    /// <summary>
    /// 
    /// </summary>
    public partial class PurchasesControl : ParentControl
    // ReSharper restore UnusedMember.Global
    {
        private string _currentSupplierName;
        /// <summary>
        /// 
        /// </summary>
        public PurchasesControl()
            : this(null)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds"></param>
        public PurchasesControl(ShopDataSet ds)
            : base(ds)
        {
            InitializeComponent();
            RowEnter += PurchasesControl_RowEnter;
            FilterCollapsed = true;
            ParentBindingSourceSortString = "[مسلسل] desc";
            AllowToggleInsertEdit = true;
            رقمالفاتورةDataGridViewTextBoxColumn.Frozen =
                اسمالموردDataGridViewTextBoxColumn.Frozen = اسمالخامDataGridViewTextBoxColumn.Frozen = true;
            مسلسلDataGridViewTextBoxColumn.Visible = false;
            supplierComboBox.Validated += ValidatedOk;
            rawKindComboBox.Validated += ValidatedOk;
            billNONumericUpDown.Validated += ValidatedOk;
            المدفوعDataGridViewTextBoxColumn.DefaultCellStyle =
                الرصيدالحاليDataGridViewTextBoxColumn.DefaultCellStyle =
                سعرالكيلوDataGridViewTextBoxColumn.DefaultCellStyle =
                البيعهDataGridViewTextBoxColumn.DefaultCellStyle =
                القيمةDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCurrencyCellStyle;
            تاريخالشراءDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewDateCellStyle;
            DeleteDataAll += PurchasesControl_DeleteDataAll;
        }
        void PurchasesControl_DeleteDataAll(object sender, EventArgs e)
        {
            المشترياتTableAdapter.DeleteAll();
        }
        #region Properties
        private ShopDataSet.الأنواع_الخامRow RawKindRow
        {
            get
            {
                return (ShopDataSet.الأنواع_الخامRow)GetRow(الأنواعالخامBindingSource,
                                                             string.Format("[{0}] = '{1}'", "الاسم",
                                                                           rawKindComboBox.Text.Trim()),
                                                             () =>
                                                             {
                                                                 ShopDataSet.الأنواع_الخامRow row =
                                                                     MainDataSet.الأنواع_الخام.Addالأنواع_الخامRow(
                                                                         rawKindComboBox.Text.Trim());
                                                                 الأنواع_الخامTableAdapter.Update(row);
                                                                 return row;
                                                             }
                                                          );
            }
        }
        private ShopDataSet.الموردينRow SupplierRow
        {
            get
            {
                return (ShopDataSet.الموردينRow)GetRow(الموردينBindingSource,
                                                        string.Format("[{0}] = '{1}'", "الاسم",
                                                                      supplierComboBox.Text.Trim()),
                                                        () =>
                                                        {
                                                            var row =
                                                                MainDataSet.الموردين.AddالموردينRow(
                                                                    supplierComboBox.Text.Trim(), beginningBalanceNumericUpDown.Enabled ?
                                                                    beginningBalanceNumericUpDown.Value : 0);
                                                            الموردينTableAdapter.Update(row);
                                                            return row;
                                                        }
                                                     );
            }
        }
        #endregion
        #region Control Handlers
        private void CalculateValue()
        {
            valueNumericUpDown.Value = kiloPriceNumericUpDown.Value * N_KilosNumericUpDown.Value + cagePriceNumericUpDown.Value * N_CagesNumericUpDown.Value;
            var row = CurrentDataRow as ShopDataSet.المشترياتRow;
            balanceAfterPurchasenumericUpDown.Value = beginningBalanceNumericUpDown.Value +
                                                      (((CurrentMode == SubmitMode.Insert || (!string.IsNullOrEmpty(_currentSupplierName) && _currentSupplierName != supplierComboBox.Text)
                                                       )
                                                            ? valueNumericUpDown.Value - paidNumericUpDown.Value
                                                            : (row == null)
                                                                  ? 0
                                                                  : (valueNumericUpDown.Value - row.القيمة) -
                                                                    (paidNumericUpDown.Value - row.المدفوع)));
        }
        private void PurchasesControl_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            balanceLabel.Text = "الرصيد الحالي";
            _currentSupplierName = supplierComboBox.Text;
        }
        private void PurchasesUserControl_AddNewItem(object sender, EventArgs e)
        {
           
            ShopDataSet.الأنواع_الخامRow raw = RawKindRow;
            ShopDataSet.الموردينRow sup = SupplierRow;
            المشترياتTableAdapter.Insert1(raw.معرف,
                                          (int)N_CagesNumericUpDown.Value,
                                          depositeDateDateTimePicker.Value.Date,
                                          sup.معرف, kiloPriceNumericUpDown.Value,
                                          (int)N_KilosNumericUpDown.Value, paidNumericUpDown.Value,
                                          (long)billNONumericUpDown.Value, cagePriceNumericUpDown.Value);
            ShopDataSet.المشترياتRow datarow =
                MainDataSet.المشتريات.AddالمشترياتRow(depositeDateDateTimePicker.Value.Date,
                                                      (int)N_CagesNumericUpDown.Value, kiloPriceNumericUpDown.Value,
                                                      (int)N_KilosNumericUpDown.Value, paidNumericUpDown.Value,
                                                      (long)billNONumericUpDown.Value, raw.الاسم,
                                                      sup.الاسم, cagePriceNumericUpDown.Value, valueNumericUpDown.Value,
                                                      beginningBalanceNumericUpDown.Value);
            // ReSharper disable PossibleInvalidOperationException
            datarow.مسلسل = (long)المشترياتTableAdapter.GetLastID().Value;
            // ReSharper restore PossibleInvalidOperationException
            UpdateBalance(datarow.اسم_المورد, balanceAfterPurchasenumericUpDown.Value);
        }
        /// <exception cref = "Exception">يجب إدخال اسم المورد</exception>
        protected override void CheckInputs()
        {
            if (string.IsNullOrEmpty(supplierComboBox.Text.Trim()))
                throw new Exception("يجب إدخال اسم المورد") { Source = supplierComboBox.Name };
            if (string.IsNullOrEmpty(rawKindComboBox.Text.Trim()))
                throw new Exception("يجب إدخال اسم الخام") { Source = rawKindComboBox.Name };
            long? value = المشترياتTableAdapter.CheckIfBillNoExists((long)billNONumericUpDown.Value);
            if (value.HasValue && billNONumericUpDown.Value != 0
                &&
                (CurrentMode == SubmitMode.Update
                     ? ((ShopDataSet.المشترياتRow)CurrentDataRow).رقم_الفاتورة != billNONumericUpDown.Value
                     : true))
                throw new Exception("تم إدخال هذا الرقم من قبل") { Source = billNONumericUpDown.Name };
        }
        private void PurchasesUserControl_UpdateItem(object sender, EventArgs e)
        {
            ShopDataSet.الأنواع_الخامRow raw = RawKindRow;
            ShopDataSet.الموردينRow sup = SupplierRow;
            var datarow = (ShopDataSet.المشترياتRow)CurrentDataRow;
            المشترياتTableAdapter.Update1(raw.معرف,
                                          (int)N_CagesNumericUpDown.Value,
                                          depositeDateDateTimePicker.Value, sup.معرف,
                                          kiloPriceNumericUpDown.Value,
                                          (int)N_KilosNumericUpDown.Value, paidNumericUpDown.Value,
                                          (long)billNONumericUpDown.Value, cagePriceNumericUpDown.Value, datarow.مسلسل);
            datarow.القيمة = valueNumericUpDown.Value;
            UpdateBalance(datarow.اسم_المورد, balanceAfterPurchasenumericUpDown.Value);
        }
        private void UpdateBalance(string supplierName, decimal value)
        {
            foreach (ShopDataSet.المشترياتRow row in MainDataSet.المشتريات.Rows)
                if (row.اسم_المورد == supplierName)
                    row.الرصيد_الحالي = value;
            MainDataSet.المشتريات.AcceptChanges();
        }
        private void PurchasesUserControl_LoadAll(object sender, EventArgs e)
        {
            المشترياتTableAdapter.Fill(MainDataSet.المشتريات, DateTime.MinValue, DateTime.MaxValue);
        }
        private void PurchasesUserControl_LoadByPeriod(object sender, EventArgs e)
        {
            المشترياتTableAdapter.Fill(MainDataSet.المشتريات, FilterPeriodStartDate, DateTime.Now);
        }
        private void PurchasesUserControl_LoadByTimeRange(object sender, EventArgs e)
        {
            المشترياتTableAdapter.Fill(MainDataSet.المشتريات, FilterStartDate, FilterEndDate);
        }
        protected override void AfterLoad()
        {
            foreach (ShopDataSet.المشترياتRow row in MainDataSet.المشتريات.Rows)
            {
                row.الرصيد_الحالي = (decimal)new CommonQueriesTableAdapter().sp_GetSupplierCredit(row.اسم_المورد);
            }
        }
        private void PurchasesUserControl_DeleteRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var datarow = (ShopDataSet.المشترياتRow)CurrentDataRow;
            UpdateBalance(datarow.اسم_المورد, datarow.الرصيد_الحالي - datarow.القيمة + datarow.المدفوع);
            المشترياتTableAdapter.sp_Purchase_Delete(datarow.مسلسل);
        }
        private void SupplierComboBoxValidated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(supplierComboBox.Text))
            {
                supplierComboBox.BackColor = new Color();
                object debt = new CommonQueriesTableAdapter().sp_GetSupplierCredit(supplierComboBox.Text);
                if (debt != null)
                {
                    MakeNumericUpDownReadOnly(beginningBalanceNumericUpDown);
                    beginningBalanceNumericUpDown.Value = (decimal)debt;
                    balanceLabel.Text = Resources.CurrentBalance;
                }
                else
                {
                    MakeNumericUpDownWritable(beginningBalanceNumericUpDown);
                    beginningBalanceNumericUpDown.Select();
                    balanceLabel.Text = Resources.BeginninBalance;
                    beginningBalanceNumericUpDown.Value = 0;
                }
            }
        }
        private void PurchasesUserControl_ClearData(object sender, EventArgs e)
        {
            MakeNumericUpDownReadOnly(beginningBalanceNumericUpDown);
        }
        private void PurchasesUserControl_RefreshingData(object sender, EventArgs e)
        {
            الموردينTableAdapter.ClearBeforeFill = الأنواع_الخامTableAdapter.ClearBeforeFill = (bool) sender;
            الموردينTableAdapter.Fill(MainDataSet.الموردين);
            الأنواع_الخامTableAdapter.Fill(MainDataSet.الأنواع_الخام);
        }
        /// <summary>
        /// 
        /// </summary>
        public override void SelectFirstBoxInPanel()
        {
            supplierComboBox.Select();
        }
        private void BeginningBalanceNumericUpDownValueChanged(object sender, EventArgs e)
        {
            CalculateValue();
        }
        #endregion
    }
}