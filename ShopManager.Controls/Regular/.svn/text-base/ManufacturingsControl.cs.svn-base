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
    public partial class ManufacturingsControl : ParentControl
    // ReSharper restore UnusedMember.Global
    {
        /// <summary>
        /// </summary>
        /// <param name = "ds"></param>
        // ReSharper disable MemberCanBePrivate.Global
        public ManufacturingsControl(ShopDataSet ds)
            // ReSharper restore MemberCanBePrivate.Global
            : base(ds)
        {
            InitializeComponent();
            التاريخDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewDateCellStyle;
            سعرالكيلوDataGridViewTextBoxColumn.DefaultCellStyle =
            قيمةالجراكنDataGridViewTextBoxColumn.DefaultCellStyle =
            قيمةالسكرDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCurrencyCellStyle;
            اسمالخامDataGridViewTextBoxColumn.Frozen = true;
            مسلسلDataGridViewTextBoxColumn.Visible = false;
            FilterCollapsed = true;
            ParentBindingSourceSortString = "[مسلسل] desc";
            AllowToggleInsertEdit = true;
            rawkindsComboBox.Validated += ValidatedOk;
            salesKindNameComboBox.Validated += ValidatedOk;
            DeleteDataAll += ManufacuringsControl_DeleteDataAll;
        }
        void ManufacuringsControl_DeleteDataAll(object sender, EventArgs e)
        {
            التصنيعTableAdapter.DeleteAll();
        }
        /// <summary>
        /// </summary>
        public ManufacturingsControl()
            : this(null)
        {
        }
        #region Properties

        private ShopDataSet.الأنواع_الخامRow RawKindRow
        {
            get
            {
                return (ShopDataSet.الأنواع_الخامRow)GetRow(اسم_الخامBindingSource,
                                                             string.Format("[{0}] = '{1}'", "الاسم",
                                                                           rawkindsComboBox.Text.Trim()),
                                                             () =>
                                                             {
                                                                 ShopDataSet.الأنواع_الخامRow row =
                                                                     MainDataSet.الأنواع_الخام.Addالأنواع_الخامRow(
                                                                         rawkindsComboBox.Text.Trim());
                                                                 الأنواع_الخامTableAdapter.Update(row);
                                                                 return row;
                                                             }
                                                          );
            }
        }
        private ShopDataSet.أنواع_البيعRow SaleKindRow
        {
            get
            {
                return (ShopDataSet.أنواع_البيعRow)GetRow(أنواعالبيعbindingSource,
                      string.Format("[{0}] = '{1}'", "الاسم",
                                    salesKindNameComboBox.Text.Trim()), () =>
                                    {
                                        ShopDataSet.أنواع_البيعRow row =
                                            MainDataSet.أنواع_البيع.Addأنواع_البيعRow(salesKindNameComboBox.Text.Trim());
                                        أنواع_البيعTableAdapter.Update(row); return row;
                                    });
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
            rawkindsComboBox.Select();
        }
        private void Manufacturing_LoadAll(object sender, EventArgs e)
        {
            التصنيعTableAdapter.Fill(MainDataSet.التصنيع, DateTime.MinValue, DateTime.MaxValue);
        }
        private void Manufacturing_LoadByPeriod(object sender, EventArgs e)
        {
            التصنيعTableAdapter.Fill(MainDataSet.التصنيع, FilterPeriodStartDate, DateTime.Now);
        }
        private void Manufacturing_LoadByTimeRange(object sender, EventArgs e)
        {
            التصنيعTableAdapter.Fill(MainDataSet.التصنيع, FilterStartDate, FilterEndDate);
        }
        private void Manufacturing_ClearData(object sender, EventArgs e)
        {
        }
        private void Manufacturing_RefreshingData(object sender, EventArgs e)
        {
            الأنواع_الخامTableAdapter.ClearBeforeFill = أنواع_البيعTableAdapter.ClearBeforeFill = (bool) sender;
            الأنواع_الخامTableAdapter.Fill(MainDataSet.الأنواع_الخام);
            أنواع_البيعTableAdapter.Fill(MainDataSet.أنواع_البيع);

        }

        private void Manufacturing_AddNewItem(object sender, EventArgs e)
        {
            var raw = RawKindRow;
            var sales = SaleKindRow;
            التصنيعTableAdapter.Insert1(raw.معرف,
                                            (int)N_KilosNumericUpDown.Value,
                                          kiloPriceNumericUpDown.Value, sugarPriceNumericUpDown.Value,
                                           jerkinPriceNumericUpDown.Value,
                                              outputDateDateTimePicker.Value.Date, sales.معرف, (int)N_CagesInLitersNumericUpDown.Value);
            long serial = long.Parse(التصنيعTableAdapter.GetLastID().ToString());
            ShopDataSet.التصنيعRow datarow =
                MainDataSet.التصنيع.AddالتصنيعRow(raw.الاسم,
                                            (int)N_KilosNumericUpDown.Value,
                                          kiloPriceNumericUpDown.Value, sugarPriceNumericUpDown.Value,
                                           jerkinPriceNumericUpDown.Value,
                                              outputDateDateTimePicker.Value.Date, (int)N_CagesInLitersNumericUpDown.Value, salesKindNameComboBox.Text
                    );
            datarow.مسلسل = serial;
            MainDataSet.التصنيع.AcceptChanges();

        }

        /// <exception cref = "Exception">يجب إدخال اسم العميل</exception>
        protected override void CheckInputs()
        {
            if (string.IsNullOrEmpty(rawkindsComboBox.Text.Trim()))
                throw new Exception("يجب إدخال اسم الخام") { Source = rawkindsComboBox.Name };
            if (string.IsNullOrEmpty(salesKindNameComboBox.Text.Trim()))
                throw new Exception("يجب إدخال اسم العصير") { Source = salesKindNameComboBox.Name };
        }
        private void Manufacturing_UpdateItem(object sender, EventArgs e)
        {
            var datarow = (ShopDataSet.التصنيعRow)CurrentDataRow;
            var raw = RawKindRow;
            var sales = SaleKindRow;
            التصنيعTableAdapter.Update1(raw.معرف,
                                                (int)N_KilosNumericUpDown.Value,
                                              kiloPriceNumericUpDown.Value, sugarPriceNumericUpDown.Value,
                                               jerkinPriceNumericUpDown.Value,
                                                  outputDateDateTimePicker.Value.Date, sales.معرف, (int)N_CagesInLitersNumericUpDown.Value,
                                            datarow.مسلسل);

            MainDataSet.التصنيع.AcceptChanges();
        }
        private void Manufacturing_DeleteRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var datarow = ((ShopDataSet.التصنيعRow)CurrentDataRow);
            MainDataSet.التصنيع.AcceptChanges();
            التصنيعTableAdapter.sp_Manufacturing_Delete(datarow.مسلسل);
        }
      
        #endregion
       

        private void KiloPriceNumericUpDownValueChanged(object sender, EventArgs e)
        {
            totalPriceNumericUpDown.Value = kiloPriceNumericUpDown.Value * N_KilosNumericUpDown.Value;
        }
        #endregion
    }
}