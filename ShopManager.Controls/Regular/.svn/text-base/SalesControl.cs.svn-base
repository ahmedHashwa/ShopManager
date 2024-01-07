#region using directives

using System;
using System.Data;
using System.Drawing;
using System.Transactions;
using System.Windows.Forms;
using ShopManager.Controls.Basic;
using ShopManager.Controls.Data;
using ShopManager.ProjectResources.Properties;

#endregion

namespace ShopManager.Controls.Regular
{
    // ReSharper disable UnusedMember.Global
    public partial class SalesControl : ParentControl
    // ReSharper restore UnusedMember.Global
    {
        // ReSharper disable MemberCanBePrivate.Global
        public SalesControl(ShopDataSet ds)
            // ReSharper restore MemberCanBePrivate.Global
            : base(ds)
        {
            InitializeComponent();
            مسلسلDataGridViewTextBoxColumn.Frozen = true;
            اسمالعميلDataGridViewTextBoxColumn.Frozen = true;
            filteringContextMenu.FilteredDataGridView = salesItemsDataGridView;
            FilterCollapsed = true;
            ParentBindingSourceSortString = "[مسلسل] desc";
            AllowToggleInsertEdit = true;
            BeginningBalanceNumericUpDown.ValueChanged += NumericUpDownValueChanged;
            gainedNumericUpDown.ValueChanged += NumericUpDownValueChanged;
            clientComboBox.Validated += ValidatedOk;
            billNONumericUpDown.Validated += ValidatedOk;
            salesItemsDataGridView.RowLeave += SalesItemsDataGridViewRowLeave;
            سعرالقطعةDataGridViewTextBoxColumn.DefaultCellStyle =
                المدفوعDataGridViewTextBoxColumn.DefaultCellStyle =
                القيمةDataGridViewTextBoxColumn.DefaultCellStyle =
                رصيدأولالمدةDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCurrencyCellStyle;
            تاريخالبيعDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewDateCellStyle;
            DeleteDataAll += SalesControl_DeleteDataAll;
        }

        void SalesControl_DeleteDataAll(object sender, EventArgs e)
        {
            المبيعاتTableAdapter.DeleteAll();
        }

        public SalesControl()
            : this(null)
        {
        }
        #region Properties

        private int _counter;
        private string _currentClientName;

        private ShopDataSet.العملاءRow ClientRow
        {
            get
            {
                return (ShopDataSet.العملاءRow)GetRow(العملاءBindingSource,
                                                       string.Format("[{0}] = '{1}'", "الاسم",
                                                                     clientComboBox.Text.Trim()),
                                                       () =>
                                                       {

                                                           ShopDataSet.العملاءRow row =
                                                               MainDataSet.العملاء.AddالعملاءRow(
                                                                   clientComboBox.Text.Trim(), BeginningBalanceNumericUpDown.Enabled ?
                                                                   BeginningBalanceNumericUpDown.Value : 0);
                                                           العملاءTableAdapter.Update(row);
                                                           return row;
                                                       }
                                                    );
            }
        }

        #endregion

        #region EventHandlers

        #region Methods

        private void CalculateValue()
        {
            decimal currentvalue = 0;
            foreach (DataGridViewRow item in salesItemsDataGridView.Rows)
            {
                try
                {
                    int N_Cages = int.Parse(item.Cells[5].Value.ToString());
                    decimal pieceprice = decimal.Parse(item.Cells[6].Value.ToString());
                    currentvalue += pieceprice * N_Cages;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            salesvalue.Value = currentvalue;
            var row = CurrentDataRow as ShopDataSet.المبيعاتRow;
            aftersalesCredit.Value = BeginningBalanceNumericUpDown.Value +
                                     (((CurrentMode == SubmitMode.Insert || (!string.IsNullOrEmpty(_currentClientName) && _currentClientName != clientComboBox.Text))
                                           ? currentvalue - gainedNumericUpDown.Value
                                           : (row == null)
                                                 ? 0
                                                 : (currentvalue - row.القيمة) -
                                                   (gainedNumericUpDown.Value - row.المدفوع)));
        }

        #endregion

        #region Control Handlers

        public override void SelectFirstBoxInPanel()
        {
            clientComboBox.Select();
        }

        private void SalesControl_LoadAll(object sender, EventArgs e)
        {
            المبيعاتTableAdapter.Fill(MainDataSet.المبيعات, DateTime.MinValue, DateTime.MaxValue);
        }

        private void SalesControl_LoadByPeriod(object sender, EventArgs e)
        {
            المبيعاتTableAdapter.Fill(MainDataSet.المبيعات, FilterPeriodStartDate, DateTime.Now);
        }

        private void SalesControl_LoadByTimeRange(object sender, EventArgs e)
        {
            المبيعاتTableAdapter.Fill(MainDataSet.المبيعات, FilterStartDate, FilterEndDate);
        }
        protected override void AfterLoad()
        {
            foreach (ShopDataSet.المبيعاتRow row in MainDataSet.المبيعات)
            {
                row.رصيد_أول_المدة = (decimal)المبيعاتTableAdapter.sp_GetClientDebtSt(row.اسم_العميل);
            }
            MainDataSet.المبيعات.AcceptChanges();
        }
        private void SalesControl_ClearData(object sender, EventArgs e)
        {
            MakeNumericUpDownReadOnly(BeginningBalanceNumericUpDown);
            مفردات_البيعTableAdapter.Fill(MainDataSet.مفردات_البيع, -1);
        }

        private void SalesControl_RefreshingData(object sender, EventArgs e)
        {
            العملاءTableAdapter.ClearBeforeFill = أنواع_البيعTableAdapter.ClearBeforeFill =
                                                  الأنواع_الفرعية_للبيعTableAdapter.ClearBeforeFill =(bool)sender;
            العملاءTableAdapter.Fill(MainDataSet.العملاء);
            أنواع_البيعTableAdapter.Fill(MainDataSet.أنواع_البيع);
            الأنواع_الفرعية_للبيعTableAdapter.Fill(MainDataSet.الأنواع_الفرعية_للبيع);


            if (CurrentDataRow == null)
            {
                مفردات_البيعTableAdapter.Fill(MainDataSet.مفردات_البيع, -1);
            }
        }

        private void SalesControl_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _currentClientName = clientComboBox.Text;
            parentBindingSource_CurrentChanged(sender, e);
        }

        private void SalesControl_AddNewItem(object sender, EventArgs e)
        {
            ShopDataSet.العملاءRow clrow = ClientRow;
            using (var ts = new TransactionScope())
            {
                المبيعاتTableAdapter.Insert1(clrow.معرف, sellDateDateTimePicker.Value.Date, gainedNumericUpDown.Value,
                                             (long)billNONumericUpDown.Value);
                long serial = long.Parse(المبيعاتTableAdapter.GetLastID().ToString());
                if (salesItemsDataGridView.CurrentCell != null &&
                    salesItemsDataGridView.CurrentCell.RowIndex == salesItemsDataGridView.Rows.Count - 1)
                {
                    salesItemsDataGridView.CurrentCell = salesItemsDataGridView.Rows[0].Cells[0];
                }
                salesItemsDataGridView.EndEdit();
                مفرداتالبيعBindingSource.EndEdit();
                foreach (ShopDataSet.مفردات_البيعRow row in MainDataSet.مفردات_البيع.Rows)
                {
                    row.معرف_البيع = serial;
                }
                مفردات_البيعTableAdapter.Update(MainDataSet.مفردات_البيع);
                ShopDataSet.المبيعاتRow datarow = MainDataSet.المبيعات.AddالمبيعاتRow(clrow.الاسم,
                                                                                      gainedNumericUpDown.Value,
                                                                                      sellDateDateTimePicker.Value.Date,
                                                                                   salesvalue.Value,
                                                                                      (long)billNONumericUpDown.Value,
                                                                                      aftersalesCredit.Value);
                datarow.مسلسل = serial;
                UpdateBalance(datarow.اسم_العميل, aftersalesCredit.Value);
                ts.Complete();
            }
        }

        private void UpdateBalance(string clientName, decimal value)
        {
            foreach (ShopDataSet.المبيعاتRow row in MainDataSet.المبيعات.Rows)
                if (row.اسم_العميل == clientName)
                    row.رصيد_أول_المدة = value;
            MainDataSet.المبيعات.AcceptChanges();
        }

        /// <exception cref = "Exception">يجب إدخال اسم العميل</exception>
        protected override void CheckInputs()
        {
            if (string.IsNullOrEmpty(clientComboBox.Text))
                throw new Exception("يجب إدخال اسم العميل") { Source = clientComboBox.Name };
            long? value = المبيعاتTableAdapter.CheckIfBillNoExists((long)billNONumericUpDown.Value);
            if (value.HasValue && billNONumericUpDown.Value != 0
                &&
                (CurrentMode == SubmitMode.Update
                     ? ((ShopDataSet.المبيعاتRow)CurrentDataRow).رقم_الفاتورة != billNONumericUpDown.Value
                     : true))
                throw new Exception("تم إدخال هذا الرقم من قبل") { Source = billNONumericUpDown.Name };
        }

        private void SalesControl_UpdateItem(object sender, EventArgs e)
        {
            var datarow = (ShopDataSet.المبيعاتRow)CurrentDataRow;
            ShopDataSet.العملاءRow clrow = ClientRow;
            المبيعاتTableAdapter.Update1(clrow.معرف, sellDateDateTimePicker.Value,
                                         gainedNumericUpDown.Value,
                                         (long)billNONumericUpDown.Value, datarow.مسلسل);
            datarow.القيمة = salesvalue.Value;
            UpdateBalance(datarow.اسم_العميل, aftersalesCredit.Value);
            salesItemsDataGridView.EndEdit();
            مفرداتالبيعBindingSource.EndEdit();
            foreach (ShopDataSet.مفردات_البيعRow row in MainDataSet.مفردات_البيع.Rows)
                if (row.RowState != DataRowState.Deleted)
                    row.معرف_البيع = datarow.مسلسل;
            مفردات_البيعTableAdapter.Update(MainDataSet.مفردات_البيع);
            MainDataSet.المبيعات.AcceptChanges();
        }

        private void SalesControl_DeleteRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var datarow = ((ShopDataSet.المبيعاتRow)CurrentDataRow);
            UpdateBalance(datarow.اسم_العميل, aftersalesCredit.Value);
            المبيعاتTableAdapter.DeleteQuery(datarow.مسلسل);
        }

        private void ClientComboBoxValidated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(clientComboBox.Text)) return;
            object debt = المبيعاتTableAdapter.sp_GetClientDebtSt(clientComboBox.Text);
            if (debt != null)
            {
                MakeNumericUpDownReadOnly(BeginningBalanceNumericUpDown);

                BeginningBalanceNumericUpDown.Value = (decimal)debt;
                balanceLabel.Text = Resources.CurrentBalance;
            }
            else
            {
                // initialize data for a new client 
                MakeNumericUpDownWritable(BeginningBalanceNumericUpDown);

                BeginningBalanceNumericUpDown.Value = 0;
                BeginningBalanceNumericUpDown.Select();
                balanceLabel.Text = Resources.BeginninBalance;
            }
            CalculateValue();
        }

        private void parentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (CurrentMode == SubmitMode.Update && parentBindingSource.Current != null)
            {
                var srow = (ShopDataSet.المبيعاتRow)(((DataRowView)parentBindingSource.Current).Row);
                salesvalue.Text = "0";
                _counter = 0;
                balanceLabel.Text = Resources.CurrentBalance;
                filteringContextMenu.ClearAll();
                مفردات_البيعTableAdapter.Fill(MainDataSet.مفردات_البيع,
                                              srow.مسلسل);
                CalculateValue();
            }
        }

        private void NumericUpDownValueChanged(object sender, EventArgs e)
        {
            if (Submitting) return;
            CalculateValue();
        }

        #endregion

        #region SalesItems Handlers

        private void salesItemsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
            {
                OnItemSubmissionError(salesItemsDataGridView.EditingControl, "يجب إدخال رقم");
            }
            else if (e.Exception is NoNullAllowedException)
            {
                e.Cancel = true;
                OnItemSubmissionError(salesItemsDataGridView.CurrentCell, "يجب إدخال كل البيانات");
            }
            else if (e.Exception is ArgumentException) return;
        }

        private void salesItemsDataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row.Index != 1)
                salesItemsDataGridView.Rows[e.Row.Index - 1].Cells[0].Value =
                    int.Parse(salesItemsDataGridView.Rows[e.Row.Index - 2].Cells[0].Value + string.Empty) + 1;
            else
                salesItemsDataGridView.Rows[e.Row.Index - 1].Cells[0].Value = 1;
        }

        /// <exception cref = "Exception"><c>Exception</c>.</exception>
        private void salesItemsDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (salesItemsDataGridView.CurrentRow == null ||
                e.ColumnIndex == مسلسل_مفرداتDataGridViewTextBoxColumn.Index) return;
            var datarow = (ShopDataSet.مفردات_البيعRow)((DataRowView)مفرداتالبيعBindingSource.Current).Row;

            try
            {
                if (datarow[MainDataSet.مفردات_البيع.سعر_القطعةColumn].ToString() != string.Empty)
                    throw new Exception();
                object price =
                    المبيعاتTableAdapter.sp_GetLatestSalesPrice(clientComboBox.Text, datarow.النوع, datarow.النوع_الفرعي);
                if (price != null)
                    salesItemsDataGridView.CurrentRow.Cells[سعرالقطعةDataGridViewTextBoxColumn.Index].Value = price;
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch (Exception)
            // ReSharper restore EmptyGeneralCatchClause
            {
            }
            // Turn a combobox cell into editable mode on enter
            var dgv = (DataGridView)sender;
            dgv.BeginEdit(true);
            if ((dgv.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn))
            {
                dgv.EditingControl.PreviewKeyDown += salesItemsDataGridView_PreviewKeyDown;
            }

            if (!(dgv.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)) return;
            object filter = salesItemsDataGridView.CurrentRow.Cells[النوعDataGridViewTextBoxColumn.Name].Value;
            الأنواعالفرعيةللبيعbindingSource.Filter = "[معرف نوع البيع]=" +
                                                      (string.IsNullOrEmpty(filter.ToString()) ? -1 : filter);
            ((ComboBox)dgv.EditingControl).DropDownStyle = ComboBoxStyle.DropDown;
            // end 
        }

        private void SalesItemsDataGridViewRowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (salesItemsDataGridView.CurrentRow != null)
                foreach (DataGridViewCell cell in salesItemsDataGridView.CurrentRow.Cells)
                {
                    cell.Style.BackColor = new Color();
                }
            ValidationOk();
        }

        private void salesItemsDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            CalculateValue();
        }

        private void salesItemsDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
                if (salesItemsDataGridView.Rows[e.RowIndex + i].Cells[النوعDataGridViewTextBoxColumn.Name].Value != null)
                {
                    salesItemsDataGridView.Rows[e.RowIndex + i].Cells[مسلسل_مفرداتDataGridViewTextBoxColumn.Name].Value
                        = ++_counter;
                }
        }

        private void salesItemsDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (!(dgv.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)) return;
            var cbox = (ComboBox)dgv.EditingControl;
            if (cbox == null || string.IsNullOrEmpty(cbox.Text)) return;
            if (e.ColumnIndex == النوعDataGridViewTextBoxColumn.Index)
            {
                var kindrow =
                    (ShopDataSet.أنواع_البيعRow)GetRow(
                    أنواعالبيعbindingSource, string.Format("[{0}] = '{1}'", "الاسم", cbox.Text.Trim()),
                    () =>
                    {
                        ShopDataSet.أنواع_البيعRow row =
                            MainDataSet.أنواع_البيع.Addأنواع_البيعRow(cbox.Text.Trim());
                        أنواع_البيعTableAdapter.Update(row); return row;
                    });
                dgv.CurrentCell.Value = kindrow.معرف;
                dgv.EndEdit();
            }
            else if (e.ColumnIndex == النوعالفرعيDataGridViewTextBoxColumn.Index)
            {
                // ReSharper disable PossibleNullReferenceException
                var value = dgv.CurrentRow.Cells[النوعDataGridViewTextBoxColumn.Index].Value;
                if (value == null || value.ToString() == string.Empty) return;
                int kindindex = أنواعالبيعbindingSource.Find("معرف", value);
                // ReSharper restore PossibleNullReferenceException
                ShopDataSet.أنواع_البيعRow item = MainDataSet.أنواع_البيع[kindindex];
                var subKindRow =
                    (ShopDataSet.الأنواع_الفرعية_للبيعRow)GetRow(
                    الأنواعالفرعيةللبيعbindingSource, string.Format("[{0}] = '{1}' AND [{2}]='{3}'", "الاسم", cbox.Text.Trim(), "معرف نوع البيع", item.معرف),
                    () =>
                    {
                        ShopDataSet.الأنواع_الفرعية_للبيعRow subKindRowa =
                           MainDataSet.الأنواع_الفرعية_للبيع.Addالأنواع_الفرعية_للبيعRow(cbox.Text, item);
                        الأنواع_الفرعية_للبيعTableAdapter.Update(subKindRowa); return subKindRowa;
                    });
                dgv.EndEdit();
                dgv.CurrentCell.Value = subKindRow.معرف;
                الأنواعالفرعيةللبيعbindingSource.EndEdit();
                الأنواعالفرعيةللبيعbindingSource.Filter = string.Empty;
                dgv.Refresh();
            }
        }

        private void salesItemsDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            CleanIfOne(e);
        }

        private void CleanIfOne(KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Escape && salesItemsDataGridView.Rows.Count == 1)
            {
                مفردات_البيعTableAdapter.Fill(MainDataSet.مفردات_البيع, -1);
                return;
            }
        }

        private void salesItemsDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            CleanIfOne(new KeyEventArgs(e.KeyData));
        }

        #endregion

        #endregion
    }
}