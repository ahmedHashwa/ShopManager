#region using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Media;
using System.Text.RegularExpressions;
using System.Web.Mail;
using System.Windows.Forms;
using Logger;
using ShopManager.Controls.Data;
using ShopManager.ProjectResources.Properties;
#endregion
#pragma warning disable 618,612
namespace ShopManager.Controls.Basic
{
    /// <summary>
    /// </summary>
    [ToolboxBitmap(typeof(Bitmap), "ParentControl.bmp")]
    [DesignerSerializer(typeof(MyCodeDomSerializer), typeof(CodeDomSerializer))]
    [Docking(DockingBehavior.Ask)]
    public partial class ParentControl : UserControl
    {
        /// <summary>
        /// </summary>
        public ParentControl()
            : this(null)
        {
        }
        /// <summary>
        /// </summary>
        /// <param name = "ds"></param>
        protected ParentControl(ShopDataSet ds)
        {
            MainDataSet = ds ?? new ShopDataSet
                                    {
                                        DataSetName = "DataSet",
                                        SchemaSerializationMode = SchemaSerializationMode.IncludeSchema
                                    };
            InitializeComponent();
            parentBindingSource.DataSource = MainDataSet;
            mainFilteringContextMenu.FilteredDataGridView = parentDataGridView;
        }
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly string Reportfilename = Application.StartupPath + @"\LogFile.txt";
        /// <summary>
        /// 
        /// </summary>
        protected readonly ShopDataSet MainDataSet;
        /// <summary>
        ///   Controls the format of Datagridview Cell containing currency information
        /// </summary>
        protected readonly DataGridViewCellStyle DataGridViewCurrencyCellStyle = new DataGridViewCellStyle { Format = "N1" };
        /// <summary>
        ///   Controls the format of Datagridview Cell containing Date information
        /// </summary>
        protected readonly DataGridViewCellStyle DataGridViewDateCellStyle = new DataGridViewCellStyle { Format = "yyyy/MM/dd" };
        private Dictionary<Control, Binding> _bindings;
        private string _confirmationMessage = "هل أنت متأكد من حذف هذا السجل؟";
        private LoadMode _loadMode = LoadMode.Period;
        #region Nested type: AddItem
        /// <summary>
        /// 
        /// </summary>
        protected delegate DataRow AddItem();
        #endregion
        #region Nested type: LoadMode
        private enum LoadMode
        {
            Period,
            FromTo,
            All
        }
        #endregion
        #endregion
        #region Events & Handlers
        #region Events
        /// <summary>
        /// 
        /// </summary>
        [Category("Form")]
        [Description("Fires when a Time Range Has Changed (to Update the Form Title)")]
        public event EventHandler TimeRangeChanged;
        /// <summary>
        /// 
        /// </summary>
        [Category("Form")]
        [Description("Fires when a Time Range Has Changed (to Update the Form Title)")]
        public event EventHandler NumberOfrowsChanged;
        /// <summary>
        /// 
        /// </summary>
        [Category("DataGridView Action")]
        [Description("Fires when a row is being deleted.")]
        public event DataGridViewRowCancelEventHandler DeleteRow;
        /// <summary>
        /// 
        /// </summary>
        [Category("DataGridView Action")]
        [Description("Fires when a row is deselected.")]
        public event DataGridViewCellEventHandler RowLeave;
        /// <summary>
        /// 
        /// </summary>
        [Category("DataGridView Action")]
        [Description("Fires when a row is selected.")]
        public event DataGridViewCellEventHandler RowEnter;
        /// <summary>
        /// 
        /// </summary>
        [Category("DataGridView Action")]
        [Description("Fires when loading data by time range.")]
        public event EventHandler LoadByTimeRange;
        /// <summary>
        /// 
        /// </summary>
        [Category("DataGridView Action")]
        [Description("Fires when loading data by period.")]
        public event EventHandler LoadByPeriod;
        /// <summary>
        /// 
        /// </summary>
        [Category("DataGridView Action")]
        [Description("Fires when loading all data.")]
        public event EventHandler LoadAll;
        /// <summary>
        /// 
        /// </summary>
        [Category("InsertEditPanel Action")]
        [Description("Fires when clearing data from entry panel.")]
        public event EventHandler ClearData;
        /// <summary>
        /// 
        /// </summary>
        [Category("InsertEditPanel Action")]
        [Description("Fires alter clearing data from entry panel.")]
        public event EventHandler AfterClearData;
        /// <summary>
        /// 
        /// </summary>
        [Category("InsertEditPanel Action")]
        [Description("Fires when adding data from entry panel.")]
        public event EventHandler AddNewItem;
        /// <summary>
        /// 
        /// </summary>
        [Category("InsertEditPanel Action")]
        [Description("Fires when an item is successfully added.")]
        public event EventHandler ItemSuccessfullySubmitted;
        /// <summary>
        /// 
        /// </summary>
        [Category("Validate")]
        [Description("Fires when an item is successfully added.")]
        public event EventHandler ValidationPassed;
        /// <summary>
        /// 
        /// </summary>
        [Category("Data")]
        [Description("Fires when refreshing data")]
        public event EventHandler RefreshingData;
        /// <summary>
        /// 
        /// </summary>
        [Category("Data")]
        [Description("Fires when an error occurs while submission.")]
        public event EventHandler ItemSubmissionError;
        /// <summary>
        /// 
        /// </summary>
        [Category("Data")]
        [Description("Fires when updating a data item.")]
        public event EventHandler UpdateItem;
        /// <summary>
        /// 
        /// </summary>
        protected event EventHandler DeleteDataAll;
        #endregion
        #region Handlers
        #region ParentControl
        private void ParentControl_Enter(object sender, EventArgs e)
        {
            if (DoneBefore) return;
            loadTypeComboBox.SelectedIndex = 0;
            startdateTimePicker.Value =
                DateTime.Now.Subtract(new TimeSpan(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month), 0, 0, 0));
            foreach (Control item in insertEditPanel.Controls)
            {
                if (item is ComboBox)
                {
                    var cbox = (ComboBox)item;
                    cbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cbox.AutoCompleteSource = AutoCompleteSource.ListItems;
                    continue;
                }
                if (item is NumericUpDown)
                {
                    var num = (NumericUpDown)item;
                    num.Enter += SelectNumericUpDownClick;
                    num.Maximum = 50000000;
                    if (!num.Enabled || num.ReadOnly)
                        num.Minimum = -50000000;
                    continue;
                }
            }
            var dates = new List<string>();
            foreach (DataGridViewColumn column in parentDataGridView.Columns)
                if ((column.Visible && column.ValueType != null) && column.ValueType == typeof(DateTime))
                    dates.Add(column.HeaderText);
            dateTypeComboBox.DataSource = dates;
            DoneBefore = true;
        }
        private static void SelectNumericUpDownClick(object sender, EventArgs e)
        {
            var num = (NumericUpDown)sender;
            num.Select(0, 10);
        }
        #endregion
        #region parentDataGridView
        private void ParentDataGridViewUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show(ConfirmationMessage, Resources.ParentControl_ParentDataGridViewUserDeletingRow_تأكيد_حذف_سجل, MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question, MessageBoxDefaultButton.Button2,
                                                  MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            switch (result)
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                case DialogResult.Yes:
                    parentDataGridView.EndEdit();
                    if (DeleteRow != null) DeleteRow(sender, e);
                    e.Cancel = false;
                    ItemChanged = true;
                    break;
            }
        }
        private void ParentDataGridViewRowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (NumberOfrowsChanged != null) NumberOfrowsChanged(this, null);
            if (RowLeave != null && parentDataGridView.Rows.Count == 1 && parentDataGridView.AllowUserToAddRows)
                RowLeave(null, null);
        }
        private void ParentDataGridViewRowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!Submitting && RowEnter != null && parentDataGridView.CurrentRow != null &&
                parentDataGridView.Rows.Count != 0)
            {
                CurrentMode = SubmitMode.Update;
                LoadBindings();
                RowEnter(sender, e);
            }
        }
        private void ParentDataGridViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToggleFilter();
            }
            else if (e.Button == MouseButtons.Middle && AllowToggleInsertEdit)
            {
                ToggleInsertEdit();
            }
        }
        private void ParentDataGridViewCellEnter(object sender, DataGridViewCellEventArgs e)
        {
            parentDataGridView.Columns[e.ColumnIndex].DefaultCellStyle.SelectionForeColor = Color.White;
            parentDataGridView.Columns[e.ColumnIndex].DefaultCellStyle.SelectionBackColor = Color.Orange;
        }
        private void ParentDataGridViewCellLeave(object sender, DataGridViewCellEventArgs e)
        {
            parentDataGridView.Columns[e.ColumnIndex].DefaultCellStyle.SelectionForeColor = new Color();
            parentDataGridView.Columns[e.ColumnIndex].DefaultCellStyle.SelectionBackColor = new Color();
        }
        private void ParentDataGridViewDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
                MessageBox.Show(string.Format("يجب إدخال أرقام من 0 إلى {0} في هذا الحقل", short.MaxValue));
            else if (e.Exception is ConstraintException)
                MessageBox.Show(Resources.ParentControl_ParentDataGridViewDataError_هذا_الكود_موجود_مسبقا);
            else if (e.Exception is ArgumentException)
            {
            }
            else if (e.Exception is IndexOutOfRangeException)
            {
                e.ThrowException = false;
                return;
            }
            else MessageBox.Show(e.Exception.Message);
            e.ThrowException = true;
        }
        private void ParentDataGridViewUserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (RowLeave != null)
                RowLeave(sender, null);
        }
        private void ParentDataGridViewValidating(object sender, CancelEventArgs e)
        {
            parentDataGridView.EndEdit();
            if (!ItemChanged) return;
            try
            {
                parentBindingSource.EndEdit();
            }
            catch (Exception)
            {
                parentBindingSource.CancelEdit();
            }
            if (RowLeave != null && parentDataGridView.AllowUserToAddRows)
            {
                RowLeave(sender, null);
                MainDataSet.AcceptChanges();
            }
            ItemChanged = false;
        }
        private void ParentDataGridViewCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ItemChanged = true;
        }
        private void ParentDataGridViewRowLeave(object sender, DataGridViewCellEventArgs e)
        {
            ParentDataGridViewValidating(null, null);
            if (NumberOfrowsChanged != null) NumberOfrowsChanged(this, e);
        }
        private void ParentDataGridViewColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (DesignMode)
            {
                // Debugger.Break ();
                for (int i = parentDataGridView.Columns.Count - 1; i >= 0; i--)
                    if (parentDataGridView.Columns[i].Name != e.Column.Name &&
                        parentDataGridView.Columns[i].DataPropertyName == e.Column.DataPropertyName &&
                        parentDataGridView.Columns[i].DefaultCellStyle.Format == e.Column.DefaultCellStyle.Format)
                    {
                        parentDataGridView.Columns.Remove(parentDataGridView.Columns[i]);
                        return;
                    }
            }
        }
        private void ParentDataGridViewDataMemberChanged(object sender, EventArgs e)
        {
            parentDataGridView.AutoGenerateColumns = false;
        }
        #endregion
        #region Filter
        private void ViewButtonClick(object sender, EventArgs e)
        {
            string startend = "";
            if (_loadMode == LoadMode.FromTo && LoadByTimeRange != null)
            {
                LoadByTimeRange(dateTypeComboBox.Text, e);
                startend = " من " + string.Format("{0:yyyy/MM/dd}", FilterPeriodStartDate) + " إلى " +
                           string.Format("{0:yyyy/MM/dd}", FilterEndDate);
            }
            else if (_loadMode == LoadMode.Period && LoadByPeriod != null)
            {
                LoadByPeriod(dateTypeComboBox.Text, e);
                startend = " من " + string.Format("{0:yyyy/MM/dd}", FilterPeriodStartDate) + " إلى " +
                           string.Format("{0:yyyy/MM/dd}", DateTime.Now);
            }
            else if (_loadMode == LoadMode.All && LoadAll != null)
            {
                LoadAll(dateTypeComboBox.Text, e);
            }
            if (TimeRangeChanged != null)
            {
                TimeRangeChanged(startend, e);
            }
            AfterLoad();
        }

        protected virtual void AfterLoad()
        {
           
        }
        private void LoadTypeComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            atLastPanel.Visible =
                fromToPanel.Visible = false;
            switch (loadTypeComboBox.Text)
            {
                case "في آخر":
                    atLastPanel.Visible = true;
                    _loadMode = LoadMode.Period;
                    break;
                case "من / إلى":
                    fromToPanel.Visible = true;
                    _loadMode = LoadMode.FromTo;
                    break;
                default:
                    _loadMode = LoadMode.All;
                    break;
            }
        }
        #endregion
        #region insertEditPanel
        private void InsertEditPanelDoubleClick(object sender, EventArgs e)
        {
            ToggleDataGrid();
        }
        private void InsertEditPanelValidating(object sender, CancelEventArgs e)
        {
            DoNotAllowExit = false;
            parentBindingSource.EndEdit();
            if ((IsDirty && CurrentMode == SubmitMode.Insert) ||
                (CurrentMode == SubmitMode.Update && StateChanged))
            {
                DialogResult result =
                    MessageBox.Show(
                        Resources.ParentControl_InsertEditPanelValidating_يوجد_بيانات_بالصفحة_ + Environment.NewLine + Resources.ParentControl_InsertEditPanelValidating_ +
                        Environment.NewLine + Resources.ParentControl_InsertEditPanelValidating__yes_أريد_الإدخال_التحديث_الآن + Environment.NewLine +
                        Resources.ParentControl_InsertEditPanelValidating__No_أريد_حذفها + Environment.NewLine + Resources.ParentControl_InsertEditPanelValidating__Cancel_أريد_تعديل_البيانات, Resources.ParentControl_InsertEditPanelValidating_يوجد_بيانات,
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
                switch (result)
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        DoNotAllowExit = true;
                        return;
                    case DialogResult.No:
                        Clear();
                        e.Cancel = false;
                        break;
                    case DialogResult.Yes:
                        SubmitItem();
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ValidatedOk(object sender, EventArgs e)
        {
            var control = (Control)sender;
            control.BackColor = new Color();
        }
        #endregion
        #endregion
        #endregion
        #region Properties
        #region Non Browsable
        /// <summary>
        /// 
        /// </summary>
        protected string ParentBindingSourceSortString { private get; set; }
        private bool DoneBefore { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DataGridView ParentDataGridView
        {
            get { return parentDataGridView; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public string ControlTitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public int NumberOfRows
        {
            get { return parentDataGridView.Rows.Count - (parentDataGridView.AllowUserToAddRows ? 1 : 0); }
        }
        [Browsable(false)]
        private Dictionary<Control, Binding> Bindings
        {
            get { return _bindings ?? (_bindings = new Dictionary<Control, Binding>()); }
        }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        protected DateTime FilterStartDate
        {
            get { return startdateTimePicker.Value.Date; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        protected DateTime FilterPeriodStartDate
        {
            get { return DateTime.Now.Subtract(new TimeSpan((int)lastperiodNumericUpDown.Value, 0, 0, 0)); }
        }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        protected DateTime FilterEndDate
        {
            get { return endDateTimePicker.Value.Date.AddDays(1).Subtract(new TimeSpan(0, 0, 1)); }
        }
        /// <summary>
        ///   True if any data exists in the insert update panel other than clear state data.
        /// </summary>
        [Browsable(false)]
        public bool IsDirty
        {
            get
            {
                foreach (Control item in insertEditPanel.Controls)
                    if (item is ComboBox && !String.IsNullOrEmpty(item.Text)
                        || item is NumericUpDown && ((NumericUpDown)item).Value != 0
                        )
                        return true;
                return false;
            }
        }
        [Browsable(false)]
        private bool StateChanged
        {
            get { return MainDataSet.HasChanges(); }
        }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        [DefaultValue(false)]
        protected bool ItemChanged { private get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        protected SubmitMode CurrentMode { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public bool SupportsAddingAndUpdating
        {
            get { return AddNewItem != null; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public bool SupportsClearingData
        {
            get { return ClearData != null; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public bool SupportsRefreshingData
        {
            get { return RefreshingData != null; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public bool SupportsDeletingData
        {
            get { return DeleteRow != null || RowLeave != null; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        protected bool Submitting { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        protected DataRow CurrentDataRow
        {
            get
            {
                if (parentBindingSource.Current != null)
                    return
                        ((DataRowView)parentBindingSource.Current).Row;
                return null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public static long NumberOfExceptions
        {
            get
            {
                if (!File.Exists(Reportfilename)) return 0;
                var regex = new Regex("Source		:");
                return regex.Matches(
                    File.ReadAllText(Reportfilename)).Count;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public bool DoNotAllowExit { get; private set; }
        #endregion
        #region Behavior
        /// <summary>
        /// 
        /// </summary>
        [Category("Behavior")]
        protected bool AllowDirectAdd
        {
            set { parentDataGridView.AllowUserToAddRows = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Category("Behavior")]
        protected bool ReadOnly
        {
            set { parentDataGridView.ReadOnly = value; }
        }
        #endregion
        #region Appearance
        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance")]
        public bool AllowToggleInsertEdit { get; protected set; }
        #endregion
        #region Appearance - Collapses
        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance - Collapses")]
        protected bool FilterCollapsed
        {
            set { gridFilterSplitContainer.Panel1Collapsed = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance - Collapses")]
        protected bool InsertEditCollapsed
        {
            set { parentSplitContainer.Panel2Collapsed = value; }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        [Editor(
            "System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
            , typeof(UITypeEditor))]
        protected string ConfirmationMessage
        {
            private get { return _confirmationMessage; }
            set { _confirmationMessage = value; }
        }
        #region Data
        /// <summary>
        /// 
        /// </summary>
        [Category("Data")]
        [Description("The Columns contained in the DataGridView .")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        //[Editor("System.Windows.Forms.Design.DataGridViewColumnCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Editor(typeof(MyCollectionEditor), typeof(UITypeEditor))]
        [MergableProperty(true)]
        public DataGridViewColumnCollection Columns
        {
            get { return parentDataGridView.Columns; }
        }
        #endregion
        #endregion
        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteToLog(Exception ex)
        {
            //false for writing log entry to customized text file
            if (false == ErrorLog.ErrorRoutine(false, ex))
                MessageBox.Show(Resources.ParentControl_WriteToLog_Unable_to_write_a_log);
        }
        /// <summary>
        /// 
        /// </summary>
        public static void SendErrorReportEmail()
        {
            var message = new MailMessage
                              {
                                  From = "a_samy20036@yahoo.com",
                                  Subject =
                                      string.Format("ErrorReport {0} {1}", Settings.Default.ShopName,
                                                    DateTime.Today.ToShortDateString()),
                                  To = "a_samy20036@yahoo.com"
                              };
            message.Attachments.Add(new MailAttachment(Reportfilename));
            try
            {
                GmailMessage.SendMailMessageFromGmail("pclubmail@gmail.com", "Software2008", message);
                MessageBox.Show(Resources.ParentControl_SendErrorReportEmail_تم_إرسال_التقرير_بنجاح);
                File.Delete(Reportfilename);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.ParentControl_SendErrorReportEmail_لم_يتم_الإرسال_تأكد_من_اتصالك_بالإنترنت);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void CopyErrorReportTo()
        {
            var saveFileDialog = new SaveFileDialog
                                     {
                                         FileName = "ErrorLog.txt",
                                         DefaultExt = "txt",
                                         Filter = Resources.ParentControl_CopyErrorReportTo_ErrorLogFile_ErrorLog_txt__ErrorLog_txt
                                     };
            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                File.Copy(Reportfilename, saveFileDialog.FileName);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void ToggleFilter()
        {
            if (dateTypeComboBox.Items.Count == 0) return;
            gridFilterSplitContainer.Panel1Collapsed = !gridFilterSplitContainer.Panel1Collapsed;
        }
        /// <summary>
        /// 
        /// </summary>
        public void ToggleDataGrid()
        {
            parentSplitContainer.Panel1Collapsed = !parentSplitContainer.Panel1Collapsed;
        }
        /// <summary>
        /// 
        /// </summary>
        public void ToggleInsertEdit()
        {
            parentSplitContainer.Panel2Collapsed = !parentSplitContainer.Panel2Collapsed;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            if (AllowToggleInsertEdit) SaveBindings();
            if (ClearData != null)
                ClearData(insertEditPanel, EventArgs.Empty);
            CurrentMode = SubmitMode.Insert;
            if (parentDataGridView.Rows.Count > 0)
                parentDataGridView.FirstDisplayedScrollingRowIndex = 0;
            ClearItemsInContainerControl(insertEditPanel);
            if (CurrentDataRow != null) CurrentDataRow.RejectChanges();
            if (AfterClearData != null)
                AfterClearData(this, null);
            SelectFirstBoxInPanel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refreshTables"></param>
        /// <param name="clearBeforeFill"></param>
        public void RefreshData(bool refreshTables, bool clearBeforeFill)
        {
            if (refreshTables)
            {
                ViewButtonClick(null, null);
            }
            if (RefreshingData != null && !DesignMode)
            {
                RefreshingData(clearBeforeFill, null);

            }
            if (IsDirty)
            {
                Clear();
            } 
            parentBindingSource.Sort = ParentBindingSourceSortString;
            mainFilteringContextMenu.ClearAll();
        }
        /// <summary>
        /// </summary>
        public virtual void SelectFirstBoxInPanel()
        {
        }
        /// <summary>
        /// </summary>
        protected virtual void CheckInputs()
        {
        }
        /// <summary>
        /// </summary>
        public void SubmitItem()
        {
            Submitting = true;
            try
            {
                CheckInputs();
                switch (CurrentMode)
                {
                    case SubmitMode.Insert:
                        AddNewItem(null, EventArgs.Empty);
                        if (NumberOfrowsChanged != null) NumberOfrowsChanged(this, null);
                        break;
                    case SubmitMode.Update:
                        insertUpdateLabel.Select();
                        UpdateItem(null, EventArgs.Empty);
                        parentBindingSource.EndEdit();
                        break;
                    default:
                        break;
                }
                parentBindingSource.Sort = ParentBindingSourceSortString;
                ItemSuccessfullySubmitted(null, null);
                Clear();
            }
            catch (Exception ex)
            {
                Control[] errorControl = Controls.Find(ex.Source, true);
                // Must specify Control Name as Source when throwing a new exception
                if (errorControl.Length != 0)
                    OnItemSubmissionError(errorControl[0], ex.Message);
                else WriteToLog(ex);
            }
            finally
            {
                Submitting = false;
            }
        }
        /// <summary>
        /// </summary>
        protected void ValidationOk()
        {
            ValidationPassed(null, null);
        }
        /// <summary>
        /// </summary>
        /// <param name = "sender"></param>
        /// <param name = "errorMessage"></param>
        protected void OnItemSubmissionError(object sender, string errorMessage)
        {
            Color c = Color.OrangeRed;
            if (sender is Control)
            {
                var control = (Control)sender;
                control.BackColor = c;
                control.Select();
            }
            else if (sender is ToolStripItem)
            {
                var control = (ToolStripItem)sender;
                control.BackColor = c;
                control.Select();
            }
            else if (sender is DataGridViewTextBoxCell)
            {
                var control = (DataGridViewTextBoxCell)sender;
                control.Style.BackColor = c;
            }
            SystemSounds.Exclamation.Play();
            if (sender is Exception)
                ItemSubmissionError(sender, null);
            else
                ItemSubmissionError(errorMessage, null);
        }
        private void SaveBindings()
        {
            foreach (Control item in insertEditPanel.Controls)
            {
                if (item.Tag == null || item.Tag.ToString() != "bind" || item.DataBindings.Count == 0) continue;
                Bindings[item] = item.DataBindings[0];
                item.DataBindings.Clear();
            }
        }
        private void LoadBindings()
        {
            foreach (Control item in insertEditPanel.Controls)
                if (item.Tag != null && item.Tag.ToString() == "bind" && item.DataBindings.Count == 0)
                    item.DataBindings.Add(Bindings[item]);
        }
        private static void ClearItemsInContainerControl(Control control)
        {
            foreach (Control ctrl in control.Controls)
            {
                if (ctrl is ComboBox)
                {
                    ((ComboBox)ctrl).SelectedIndex = -1;
                    ((ComboBox)ctrl).SelectedIndex = -1;
                    ctrl.Text = "";
                    continue;
                }
                if (ctrl is TextBoxBase)
                {
                    ((TextBoxBase)ctrl).Clear();
                    continue;
                }
                if (ctrl is NumericUpDown)
                {
                    ((NumericUpDown)ctrl).Value = 0;
                   // MakeNumericUpDownWritable(numericUpDown);
                    continue;
                }
                if (ctrl is DateTimePicker)
                {
                    ((DateTimePicker)ctrl).Value = DateTime.Today;
                    continue;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void FocusOnDataGridView()
        {
            parentDataGridView.Focus();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bindingSource"></param>
        /// <param name="filter"></param>
        /// <param name="addItem"></param>
        /// <returns></returns>
        protected DataRow GetRow(BindingSource bindingSource, string filter, AddItem addItem)
        {
            DataRow[] results = MainDataSet.Tables[bindingSource.DataMember].Select(filter);
            if (results.Length == 0)
            {
                return addItem != null ? addItem() : null;
            }
            return results[0];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numericUpDown"></param>
        protected static void MakeNumericUpDownReadOnly(NumericUpDown numericUpDown)
        {
            numericUpDown.ReadOnly = true;
            numericUpDown.Increment = 0;
            numericUpDown.TabStop = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numericUpDown"></param>
        protected static void MakeNumericUpDownWritable(NumericUpDown numericUpDown)
        {
            numericUpDown.ReadOnly = false;
            numericUpDown.Increment = 1;
        }        /// <summary>
        /// 
        /// </summary>
        public void DeleteAllData()
        {
            DialogResult result = MessageBox.Show(Resources.ParentControl_DeleteAllData, Resources.ParentControl_DeleteAllData_تأكيد_حذف_البيانات, MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button2,
                                                 MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
            switch (result)
            {
                case DialogResult.Yes:
                    if (DeleteDataAll != null)
                        DeleteDataAll(null, null);
                    RefreshData(true, false);
                    break;
            }
        }
        #endregion
    }
    /// <summary>
    /// 
    /// </summary>
    public enum SubmitMode
    {
        Insert,
        Update
    }
}