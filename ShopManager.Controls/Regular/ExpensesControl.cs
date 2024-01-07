#region using directives

using System;
using System.Windows.Forms;
using ShopManager.Controls.Basic;
using ShopManager.Controls.Data;

#endregion

namespace ShopManager.Controls.Regular
{
    // ReSharper disable UnusedMember.Global
    /// <summary>
    /// </summary>
    public partial class ExpensesControl : ParentControl
    // ReSharper restore UnusedMember.Global
    {
        /// <summary>
        /// </summary>
        public ExpensesControl()
            : this(null)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name = "ds"></param>
        public ExpensesControl(ShopDataSet ds)
            : base(ds)
        {
            InitializeComponent();
            الكميةDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCurrencyCellStyle;
            التاريخDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewDateCellStyle;
            مسلسلDataGridViewTextBoxColumn.Frozen = true;
            FilterCollapsed = true;
            ParentBindingSourceSortString = "[مسلسل] desc";
            AllowToggleInsertEdit = true;
            expensesTypeDescComboBox.Validated += ValidatedOk;
            DeleteDataAll += new EventHandler(ExpensesControl_DeleteDataAll);

        }

        void ExpensesControl_DeleteDataAll(object sender, EventArgs e)
        {
            expensesTableAdapter.DeleteAll();
        }

        #region Properties

        #endregion

        #region EventHandlers

        #region Control Handlers

        private ShopDataSet.أنواع_الصرفRow ExpenseTypeRow
        {
            get
            {
                return (ShopDataSet.أنواع_الصرفRow)GetRow(أنواعالمصروفاتBindingSource,
                                                           string.Format("[{0}] = '{1}'", "الاسم",
                                                                         expensesTypeDescComboBox.Text.Trim()),
                                                           () =>
                                                           {
                                                               ShopDataSet.أنواع_الصرفRow row =
                                                                   MainDataSet.أنواع_الصرف.Addأنواع_الصرفRow(
                                                                       expensesTypeDescComboBox.Text.Trim());
                                                               أنواع_الصرفTableAdapter.Update(row);
                                                               return row;
                                                           }
                                                        );
            }
        }

        private void ExpensesControl_DeleteRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            expensesTableAdapter.sp_Expenses_Delete(int.Parse(e.Row.Cells[0].Value.ToString()));
        }

        private void ExpensesControl_LoadAll(object sender, EventArgs e)
        {
            expensesTableAdapter.Fill(MainDataSet.المصاريف, DateTime.MinValue, DateTime.MaxValue);
        }

        private void ExpensesControl_LoadByPeriod(object sender, EventArgs e)
        {
            expensesTableAdapter.Fill(MainDataSet.المصاريف, FilterPeriodStartDate, DateTime.Now);
        }

        private void ExpensesControl_LoadByTimeRange(object sender, EventArgs e)
        {
            expensesTableAdapter.Fill(MainDataSet.المصاريف, FilterStartDate, FilterEndDate);
        }

        private void ExpensesControl_AddNewItem(object sender, EventArgs e)
        {
            ShopDataSet.أنواع_الصرفRow exrow = ExpenseTypeRow;
            expensesTableAdapter.Insert1(
                exrow.معرف,
                expenseamountNumericUpDown.Value,
                expensesDateTimePicker.Value, (long)orderForPaymentNumericUpDown.Value);
            ShopDataSet.المصاريفRow datarow = MainDataSet.المصاريف.AddالمصاريفRow(
                exrow.الاسم, (long)orderForPaymentNumericUpDown.Value,
                expenseamountNumericUpDown.Value,
                expensesDateTimePicker.Value);
            datarow.مسلسل = (long)expensesTableAdapter.GetLastID().Value;
            datarow.AcceptChanges();
        }

        private void ExpensesControl_UpdateItem(object sender, EventArgs e)
        {
            var datarow = (ShopDataSet.المصاريفRow)CurrentDataRow;
            ShopDataSet.أنواع_الصرفRow exrow = ExpenseTypeRow;
            expensesTableAdapter.Update1(exrow.معرف,
                                         expenseamountNumericUpDown.Value,
                                         expensesDateTimePicker.Value,
                                         (long)orderForPaymentNumericUpDown.Value, datarow.مسلسل);
            datarow.AcceptChanges();
        }

        private void ExpensesControl_RefreshingData(object sender, EventArgs e)
        {
            أنواع_الصرفTableAdapter.ClearBeforeFill = (bool) sender;
            أنواع_الصرفTableAdapter.Fill(MainDataSet.أنواع_الصرف);
        }

        private void ExpensesControl_ClearData(object sender, EventArgs e)
        {
        }

        protected override void CheckInputs()
        {
            if (string.IsNullOrEmpty(expensesTypeDescComboBox.Text.Trim()))
                throw new Exception("يجب إدخال نوع الصرف") { Source = expensesTypeDescComboBox.Name };
            long? value = expensesTableAdapter.CheckIfOrderNoExits((long)orderForPaymentNumericUpDown.Value);
            if (value.HasValue && orderForPaymentNumericUpDown.Value != 0
                &&
                (CurrentMode == SubmitMode.Update
                     ? ((ShopDataSet.المصاريفRow)CurrentDataRow).اذن_الصرف != orderForPaymentNumericUpDown.Value
                     : true))
                throw new Exception("تم إدخال هذا الرقم من قبل") { Source = orderForPaymentNumericUpDown.Name };
        }

        public override void SelectFirstBoxInPanel()
        {
            expensesTypeDescComboBox.Select();
        }

        #endregion

        #endregion
    }
}