#region using directives

using System;
using System.Drawing;
using System.Windows.Forms;
using ShopManager.Controls.Basic;
using ShopManager.Controls.Data;
using ShopManager.Controls.Data.ShopDataSetTableAdapters;
using ShopManager.ProjectResources.Data.commonDataSetTableAdapters;
using ShopManager.ProjectResources.Properties;

#endregion

namespace ShopManager.Controls.Regular
{
    // ReSharper disable UnusedMember.Global
    /// <summary>
    /// </summary>
    public partial class FridgeOutsControl : ParentControl
    // ReSharper restore UnusedMember.Global
    {
        /// <summary>
        /// </summary>
        /// <param name = "ds"></param>
        // ReSharper disable MemberCanBePrivate.Global
        public FridgeOutsControl(ShopDataSet ds)
            // ReSharper restore MemberCanBePrivate.Global
            : base(ds)
        {
            InitializeComponent();
            التاريخDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewDateCellStyle;
            مسلسلDataGridViewTextBoxColumn.Visible = false;
            رقمإذنالصرفDataGridViewTextBoxColumn.Frozen =
                   اسمالثلاجةDataGridViewTextBoxColumn.Frozen = true;
            FilterCollapsed = true;
            ParentBindingSourceSortString = "[مسلسل] desc";
            AllowToggleInsertEdit = true;
            fridgesComboBox.Validated += ValidatedOk;
            billNONumericUpDown.Validated += ValidatedOk;
            N_KilosNumericUpDown.Validated += ValidatedOk;
            N_CagesNumericUpDown.Validated += ValidatedOk;
            rawkindsComboBox.Validated += ValidatedOk;
            N_KilosNumericUpDown.ValueChanged += N_KilosNumericUpDownValueChanged;
            DeleteDataAll += FridgeOutControl_DeleteDataAll;
            N_CagesNumericUpDown.ValueChanged += N_CagesNumericUpDown_ValueChanged;
        }

        void N_CagesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rawkindsComboBox.Text.Trim()) && RawKindRow != null &&
              !string.IsNullOrEmpty(fridgesComboBox.Text.Trim()) && FridgeRow != null)
            {
                var balance = new CommonQueriesTableAdapter().GetRawN_Cages(FridgeRow.معرف, RawKindRow.معرف);
                N_CagesNumericUpDown.BackColor = balance == null || (int)balance - (int)N_CagesNumericUpDown.Value + ((CurrentMode == SubmitMode.Update) ? ((ShopDataSet.صرف_الثلاجاتRow)CurrentDataRow).الكمية_بالأقفاص : 0) < 0

                                                      ? Color.OrangeRed
                                                      : new Color();
            }
        }

        void FridgeOutControl_DeleteDataAll(object sender, EventArgs e)
        {
            صرف_الثلاجاتTableAdapter.DeleteAll();


        }

        void N_KilosNumericUpDownValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rawkindsComboBox.Text.Trim()) && RawKindRow != null &&
            !string.IsNullOrEmpty(fridgesComboBox.Text.Trim()) && FridgeRow != null)
            {
                var balance = new CommonQueriesTableAdapter().GetRawN_KilosBalance(FridgeRow.معرف, RawKindRow.معرف);
                N_KilosNumericUpDown.BackColor = balance == null || (int)balance - (int)N_KilosNumericUpDown.Value + ((CurrentMode == SubmitMode.Update) ? ((ShopDataSet.صرف_الثلاجاتRow)CurrentDataRow).الوزن_بالكيلو : 0) < 0

                                                      ? Color.OrangeRed
                                                      : new Color();
            }
        }

        /// <summary>
        /// </summary>
        public FridgeOutsControl()
            : this(null)
        {
        }

        #region Properties

        private ShopDataSet.العملاءRow ClientRow
        {
            get
            {
                return (ShopDataSet.العملاءRow)GetRow(العملاءBindingSource,
                                                       string.Format("[{0}] = '{1}'", "الاسم",
                                                                     clientComboBox.Text.Trim()),
                                                       () =>
                                                       {
                                                           var row =
                                                               MainDataSet.العملاء.AddالعملاءRow(
                                                                   clientComboBox.Text.Trim(),
                                                                   BeginningBalanceNumericUpDown.Value);
                                                           العملاءTableAdapter.Update(row);
                                                           return row;
                                                       }
                                                    );
            }
        }
        private ShopDataSet.الأنواع_الخامRow RawKindRow
        {
            get
            {
                return GetRow(اسم_الخامBindingSource,
                              string.Format("[{0}] = '{1}'", "الاسم", rawkindsComboBox.Text.Trim()), null) as
                       ShopDataSet.الأنواع_الخامRow;
            }
        }

        private ShopDataSet.الثلاجاتRow FridgeRow
        {
            get
            {
                return GetRow(الثلاجاتBindingSource,
                              string.Format("[{0}] = '{1}'", "الاسم", fridgesComboBox.Text.Trim()), null) as
                       ShopDataSet.الثلاجاتRow;
            }
        }

        #endregion

        #region EventHandlers

        #region Methods

        #endregion

        #region Control Handlers

        /// <summary>
        /// </summary>
        public override void SelectFirstBoxInPanel()
        {
            fridgesComboBox.Select();
        }

        private void FridgeOut_LoadAll(object sender, EventArgs e)
        {
            صرف_الثلاجاتTableAdapter.Fill(MainDataSet.صرف_الثلاجات,DateTime.MinValue,DateTime.MaxValue);
        }

        private void FridgeOut_LoadByPeriod(object sender, EventArgs e)
        {
            صرف_الثلاجاتTableAdapter.Fill(MainDataSet.صرف_الثلاجات, FilterPeriodStartDate, DateTime.Now);
        }

        private void FridgeOut_LoadByTimeRange(object sender, EventArgs e)
        {
            صرف_الثلاجاتTableAdapter.Fill(MainDataSet.صرف_الثلاجات, FilterStartDate, FilterEndDate);
        }

        private void FridgeOut_ClearData(object sender, EventArgs e)
        {
            MakeNumericUpDownReadOnly(BeginningBalanceNumericUpDown);
        }



        private void FridgeOut_RefreshingData(object sender, EventArgs e)
        {
            الثلاجاتTableAdapter.ClearBeforeFill =
                الأنواع_الخامTableAdapter.ClearBeforeFill =
                العملاءTableAdapter.ClearBeforeFill = (bool) sender;
            الثلاجاتTableAdapter.Fill(MainDataSet.الثلاجات);
            الأنواع_الخامTableAdapter.Fill(MainDataSet.الأنواع_الخام);
            العملاءTableAdapter.Fill(MainDataSet.العملاء);

        }

        private void FridgeOut_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            balanceLabel.Text = Resources.CurrentBalance;
            BeginningBalanceNumericUpDown.Value = (Decimal)
                                                  new المبيعاتTableAdapter().sp_GetClientDebtSt(
                                                      ((ShopDataSet.صرف_الثلاجاتRow)CurrentDataRow).جهة_الصرف);

        }

        private void FridgeOut_AddNewItem(object sender, EventArgs e)
        {
            var raw = RawKindRow;
            var fridge = FridgeRow;
            var client = ClientRow;

            صرف_الثلاجاتTableAdapter.Insert1(fridge.معرف
                                            , raw.معرف,
                                            (int)N_KilosNumericUpDown.Value,
                                           (long)billNONumericUpDown.Value, outputDateDateTimePicker.Value.Date,
                                          client.معرف,
                                            (int)N_CagesNumericUpDown.Value);
            long serial = long.Parse(صرف_الثلاجاتTableAdapter.GetLastID().ToString());

            ShopDataSet.صرف_الثلاجاتRow datarow =
                MainDataSet.صرف_الثلاجات.Addصرف_الثلاجاتRow(fridge.الاسم, raw.الاسم, (int)N_KilosNumericUpDown.Value,
                    outputDateDateTimePicker.Value.Date, (long)billNONumericUpDown.Value, client.الاسم, (int)N_CagesNumericUpDown.Value);
            datarow.مسلسل = serial;
            MainDataSet.صرف_الثلاجات.AcceptChanges();

        }

        /// <exception cref = "Exception">يجب إدخال اسم العميل</exception>
        protected override void CheckInputs()
        {
            MainDataSet.صرف_الثلاجات.RejectChanges();
            if (string.IsNullOrEmpty(clientComboBox.Text))
                throw new Exception("يجب إدخال اسم العميل") { Source = clientComboBox.Name };
            if (string.IsNullOrEmpty(fridgesComboBox.Text.Trim()) || FridgeRow == null)
                throw new Exception("يجب إدخال اسم ثلاجة موجودة") { Source = fridgesComboBox.Name };
            if (string.IsNullOrEmpty(rawkindsComboBox.Text.Trim()) || RawKindRow == null)
                throw new Exception("يجب إدخال اسم خام موجود") { Source = rawkindsComboBox.Name };
            var balance = new CommonQueriesTableAdapter().GetRawN_KilosBalance(FridgeRow.معرف, RawKindRow.معرف);
            if (balance == null || (int)balance - (int)N_KilosNumericUpDown.Value + ((CurrentMode == SubmitMode.Update) ? ((ShopDataSet.صرف_الثلاجاتRow)CurrentDataRow).الوزن_بالكيلو : 0) < 0)
                throw new Exception("لا يوجد مخزون كافي") { Source = N_KilosNumericUpDown.Name };


            var qbalance = new CommonQueriesTableAdapter().GetRawN_Cages(FridgeRow.معرف, RawKindRow.معرف);
            if (qbalance == null || (int)qbalance - (int)N_CagesNumericUpDown.Value + ((CurrentMode == SubmitMode.Update) ? ((ShopDataSet.صرف_الثلاجاتRow)CurrentDataRow).الكمية_بالأقفاص : 0) < 0)
                throw new Exception("لا يوجد عدد  كافي من الأقفاص") { Source = N_CagesNumericUpDown.Name };
            var value = صرف_الثلاجاتTableAdapter.CheckIfRecieptNoExists((long)billNONumericUpDown.Value);
            if (value!=null && billNONumericUpDown.Value != 0
                &&
                (CurrentMode == SubmitMode.Update
                     ? ((ShopDataSet.صرف_الثلاجاتRow)CurrentDataRow).رقم_إذن_الصرف != billNONumericUpDown.Value
                     : true))
                throw new Exception("تم إدخال هذا الرقم من قبل") { Source = billNONumericUpDown.Name };
        }

        private void FridgeOut_UpdateItem(object sender, EventArgs e)
        {
            var datarow = (ShopDataSet.صرف_الثلاجاتRow)CurrentDataRow;
            var raw = RawKindRow;
            var fridge = FridgeRow;
            var client = ClientRow;

            صرف_الثلاجاتTableAdapter.Update1(fridge.معرف
                                            , raw.معرف,
                                            (int)N_KilosNumericUpDown.Value,
                                        outputDateDateTimePicker.Value.Date, (long)billNONumericUpDown.Value,
                                          client.معرف,
                                            (int)N_CagesNumericUpDown.Value,
                                            datarow.مسلسل);
            MainDataSet.صرف_الثلاجات.AcceptChanges();
        }

        private void FridgeOut_DeleteRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var datarow = ((ShopDataSet.صرف_الثلاجاتRow)CurrentDataRow);
            MainDataSet.صرف_الثلاجات.AcceptChanges();
            صرف_الثلاجاتTableAdapter.sp_FridgeOut_Delete(datarow.مسلسل);
        }

        #endregion



        private void ClientComboBoxValidated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(clientComboBox.Text)) return;
            object debt = new المبيعاتTableAdapter().sp_GetClientDebtSt(clientComboBox.Text);
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
        }

        #endregion
    }
}