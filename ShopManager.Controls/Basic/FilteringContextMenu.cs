#region using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace ShopManager.Controls.Basic
{
    public sealed partial class FilteringContextMenu : ContextMenuStrip
    {
        #region Constants

        private const string And = "و";
        private const string EndsWith = "ينتهي ب";
        private const string LargerThan = ">";
        private const string LargerThanOrEquals = ">=";
        private const string LessThan = "<";
        private const string LessThanOrEquals = "<=";
        private const string NotEquals = "≠";
        private const string Or = "أو";
        private const string SContains = "يحتوي على";
        private const string Selectall = "اختر الكل";
        private const string SEquals = "=";
        private const string Single = "مفرد";
        private const string StartsWith = "يبدأ ب";

        private const string Hidden = "Hidden";

        #endregion

        #region Constructors

        public FilteringContextMenu()
            : this(null)
        {
        }

        private FilteringContextMenu(DataGridView dataGridView)
        {
            FilteredDataGridView = dataGridView;
            InitializeComponent();
            filtersToolStripMenuItem.DropDownOpening += FiltersToolStripMenuItemDropDownOpening;
            RelationComboBox.Refresh();
            foreach (object s in Items)
            {
                if (s is ToolStripMenuItem) ((ToolStripMenuItem) s).MouseEnter += ToolStripMenuItemMouseEnter;
            }
            okToolStripMenuItem.Click += OkToolStripMenuItemClick;
            cancelToolStripMenuItem.Click += CancelToolStripMenuItemClick;
            filtersToolStripMenuItem.DropDownOpening += FiltersToolStripMenuItemDropDownOpening;
            hideColumnToolStripMenuItem.Click += HideColumnToolStripMenuItemClick;
            showAllColumnsToolStripMenuItem.Click += ShowAllColumnsToolStripMenuItemClick;
            freezeColumnToolStripMenuItem.Click += FreezeColumnToolStripMenuItemClick;
            unFreezeAllColumnToolStripMenuItem.Click += UnFreezeAllColumnToolStripMenuItemClick;
            sortAscToolStripMenuItem.Click += SortAscToolStripMenuItemClick;
            sortDesToolStripMenuItem.Click += SortDesToolStripMenuItemClick;
        }

        #endregion

        #region Properties

        private readonly Stack<string> _filteredColums = new Stack<string>();
        private DataGridView _filteredDataGridView;

        [Category("Data")]
        [Browsable(true)]
        public DataGridView FilteredDataGridView
        {
            private get { return _filteredDataGridView; }
            set
            {
                _filteredDataGridView = value;
                if (value == null) return;
                _filteredDataGridView.CellMouseClick += ClientsDataGridViewCellMouseClick;
                _filteredDataGridView.MouseClick += ClientsDataGridViewMouseClick;
            }
        }

        private DataSet FilteredDataSet
        {
            get { return (DataSet) FilteredBindingSource.DataSource; }
        }

        private BindingSource FilteredBindingSource
        {
            get { return (BindingSource) FilteredDataGridView.DataSource; }
        }

        private ComboBox RelationComboBox
        {
            get
            {
                const string cname = "relationComboBox";
                if (filtersToolStripMenuItem.DropDownItems.ContainsKey(cname))
                    return (ComboBox) ((ToolStripControlHost) filtersToolStripMenuItem.DropDownItems[cname]).Control;
                var cbox = new ComboBox
                               {
                                   DropDownStyle = ComboBoxStyle.DropDownList
                               };
                // Fill relationCombobox with data.
                cbox.Items.AddRange(new[] {Single, And, Or});
                var host = new ToolStripControlHost(cbox, cname);
                filtersToolStripMenuItem.DropDownItems.Insert(0, host);
                cbox.SelectedIndex = 0;
                return cbox;
            }
        }

        private ComboBox OperatorComboBox
        {
            get
            {
                const string cname = "operatorComboBox";
                ComboBox cbox;
                if (filtersToolStripMenuItem.DropDownItems.ContainsKey(cname))
                {
                    cbox = (ComboBox) ((ToolStripControlHost) filtersToolStripMenuItem.DropDownItems[cname]).Control;
                    if (
                        cbox.Items[0].ToString() == SEquals && (CurrentColumnIsNumeric || CurrentColumnIsDateTime)
                        || cbox.Items[0].ToString() == SContains && CurrentColumnIsString
                        )
                        return cbox;
                    goto go;
                }
                cbox = new ComboBox
                           {
                               DropDownStyle = ComboBoxStyle.DropDownList
                           };
                var host = new ToolStripControlHost(cbox, cname);
                filtersToolStripMenuItem.DropDownItems.Insert(1, host);
                go:
                cbox.Items.Clear();
                if (CurrentColumnIsNumeric || CurrentColumnIsDateTime)
                    cbox.Items.AddRange(new[]
                                            {
                                                SEquals, LargerThan, LessThan, LargerThanOrEquals, LessThanOrEquals,
                                                NotEquals
                                            });
                else if (CurrentColumnIsString)
                    cbox.Items.AddRange(new[] {SContains, StartsWith, EndsWith});
                cbox.SelectedIndex = 0;
                return cbox;
            }
        }

        private DataGridViewColumn CurrentColumn
        {
            get { return FilteredDataGridView.CurrentCell.OwningColumn; }
        }

        private bool CurrentColumnIsNumeric
        {
            get
            {
                return new List<Type> {typeof (int), typeof (long), typeof (decimal), typeof (short)}.
                    Contains(CurrentColumn.ValueType);
            }
        }

        private bool CurrentColumnIsString
        {
            get { return CurrentColumn.ValueType == typeof (string); }
        }

        private bool CurrentColumnIsDateTime
        {
            get { return CurrentColumn.ValueType == typeof (DateTime); }
        }

        private Control ValueControl
        {
            get
            {
                const string cname = "valueTextBox";
                Control ctrl;
                if (filtersToolStripMenuItem.DropDownItems.ContainsKey(cname))
                {
                    ctrl = ((ToolStripControlHost) filtersToolStripMenuItem.DropDownItems[cname]).Control;
                    if (CurrentColumnIsNumeric && ctrl is NumericUpDown
                        || CurrentColumnIsString && ctrl is TextBox
                        || CurrentColumnIsDateTime && ctrl is DateTimePicker)
                        return ctrl;
                    filtersToolStripMenuItem.DropDownItems.RemoveAt(2);
                }
                if (CurrentColumnIsNumeric)
                    ctrl = new NumericUpDown {DecimalPlaces = 2, Maximum = 999999999};
                else if (CurrentColumnIsString)
                    ctrl = new TextBox();
                else
                    //if (CurrentColumnIsDateTime)
                    ctrl = new DateTimePicker {Format = DateTimePickerFormat.Short, Width = 120};
                var host = new ToolStripControlHost(ctrl, cname) {AutoSize = false};
                filtersToolStripMenuItem.DropDownItems.Insert(2, host);
                return ctrl;
            }
        }

        private ToolStripMenuItem InsertUpdateSearchItemButton
        {
            get
            {
                const string cname = "insertUpdaetSearchItemButton";
                if (filtersToolStripMenuItem.DropDownItems.ContainsKey(cname))
                    return (ToolStripMenuItem) filtersToolStripMenuItem.DropDownItems[cname];
                var tsmb = new ToolStripMenuItem();
                tsmb.Click += InsertUpdateSearchItemButtonClick;
                tsmb.MouseEnter += ToolStripMenuItemMouseEnter;
                tsmb.Text = "أضف شرط جديد";
                tsmb.Name = cname;
                filtersToolStripMenuItem.DropDownItems.Insert(3, tsmb);
                return tsmb;
            }
        }

        private CheckedListBox FilteringCheckedListBox
        {
            get
            {
                CheckedListBox chl;
                if (Items["CheckBoxes"] == null)
                {
                    chl = new CheckedListBox {CheckOnClick = true, HorizontalScrollbar = true};
                    var host = new ToolStripControlHost((chl)) {AutoSize = false, Name = "CheckBoxes"};
                    Items.Insert(1, host);
                }
                else
                    chl = (CheckedListBox) ((ToolStripControlHost) Items["CheckBoxes"]).Control;
                return chl;
            }
        }

        private bool LastFilteredAllSelected
        {
            get
            {
                if (_filteredColums.Count < 2)
                    return false;
                DataGridViewColumn column = FilteredDataGridView.Columns[_filteredColums.Peek()];
                Dictionary<string, ItemData> columndatadic = GetDataDictionary(column);
                return columndatadic[Selectall].State == CheckState.Checked;
            }
        }

        private string DataFilter
        {
            get
            {
                var conditions = new List<string>();
                foreach (DataGridViewColumn column in FilteredDataGridView.Columns)
                {
                    if (column.Tag == null)
                        continue;
                    Dictionary<string, ItemData> datadic = GetDataDictionary(column);
                    if (datadic[Selectall].State == CheckState.Checked)
                        continue;
                    var list = new List<string>();
                    foreach (string key in datadic.Keys)
                        if (datadic[key].State == CheckState.Checked && key != Selectall)
                            list.Add(string.Format("'{0}'",
                                                   (datadic[key].Value == string.Empty) ? key : datadic[key].Value));
                    string filterlist = string.Join(",", list.ToArray());
                    if (string.IsNullOrEmpty(filterlist))
                    {
                        if (column.ValueType == typeof (int) || column.ValueType == typeof (long) ||
                            column.ValueType == typeof (decimal) || column.ValueType == typeof (short))
                            //  filterlist = int.MinValue + string.Empty;
                            filterlist = column.ValueType.GetField("MinValue").GetValue(column.ValueType) + string.Empty;
                        else if (column.ValueType == typeof (string))
                            filterlist = "''";
                    }
                    conditions.Add(string.Format("[{0}] IN ({1})", column.DataPropertyName, filterlist));
                }
                return string.Join(" AND ", conditions.ToArray());
            }
        }

        private void UpdateVisibleValues()
        {
            string notUpdatedColumn = string.Empty;
            if (_filteredColums.Count != 0)
            {
                notUpdatedColumn = _filteredColums.Peek();
            }
            string allVisibleColumn = string.Empty;
            if (LastFilteredAllSelected)
            {
                _filteredColums.Pop();
                allVisibleColumn = _filteredColums.Peek();
            }
            foreach (DataGridViewColumn column in FilteredDataGridView.Columns)
            {
                if (column.Tag == null || _filteredColums.Count == 0 || column.Name == notUpdatedColumn)
                    continue;
                var currentValues =
                    new List<string>(GetDistinctValues(column,
                                                       ((DataView) FilteredBindingSource.List).ToTable()));
                Dictionary<string, ItemData> columndatadic = GetDataDictionary(column);
                DataGridViewColumn viewColumn = column;
                ModifyDataDictionary(columndatadic,
                                     key => true,
                                     key => columndatadic[key].State,
                                     key =>
                                     (viewColumn.Name == allVisibleColumn || currentValues.Contains(key) ||
                                      key == Selectall));
            }
        }

        private struct ItemData
        {
            public CheckState State { get; set; }
            public string Value { get; set; }
            public bool ItemVisible { get; set; }

            public override string ToString()
            {
                return string.Format("Value ={0}, State = {1}, ItemVisible = {2}", Value, State, ItemVisible);
            }
        }

        #endregion

        #region Nested type: ActOnDgv

        private delegate void ActOnDgv(DataGridViewColumn dataGridViewColumn);

        #endregion

        #region Nested type: SetCheckState

        private delegate CheckState SetCheckState(string key);

        #endregion

        #region Nested type: SetCondition

        private delegate bool SetCondition(string key);

        #endregion

        #region Methods

        private void ProcessFilteredDataGridView(ActOnDgv actOnDgv)
        {
            foreach (DataGridViewColumn column in FilteredDataGridView.Columns)
                actOnDgv(column);
        }

        private void SetSelectAllState()
        {
            CheckState cs = CheckState.Indeterminate;
            if (FilteringCheckedListBox.CheckedIndices.Count == FilteringCheckedListBox.Items.Count)
                cs = CheckState.Checked;
            else if (FilteringCheckedListBox.CheckedIndices.Count == 1
                     && FilteringCheckedListBox.CheckedIndices[0] == 0)
                cs = CheckState.Unchecked;
            FilteringCheckedListBox.SetItemCheckState(0, cs);
        }

        private static IEnumerable<string> GetDistinctValues(DataGridViewColumn column, DataTable dataTable)
        {
            DataRow[] rows = dataTable.Select(string.Empty, column.DataPropertyName);
            string lastitem = string.Empty;
            foreach (DataRow s in rows)
                if (s[column.DataPropertyName].ToString() != lastitem)
                {
                    lastitem = s[column.DataPropertyName].ToString();
                    yield return s[column.DataPropertyName].ToString();
                }
        }

        private Dictionary<string, ItemData> GetDataDictionary(DataGridViewColumn column)
        {
            var dataDic = column.Tag as Dictionary<string, ItemData>;
            if (dataDic == null)
            {
                dataDic = new Dictionary<string, ItemData>();
                dataDic[Selectall] = new ItemData {Value = string.Empty, ItemVisible = true, State = CheckState.Checked};
                foreach (
                    string value in
                        GetDistinctValues(column, FilteredDataSet.Tables[FilteredBindingSource.DataMember]))
                {
                    string key;
                    if (column is DataGridViewComboBoxColumn)
                    {
                        var cboxcol = ((DataGridViewComboBoxColumn) column);
                        var clmbsrc = (BindingSource) cboxcol.DataSource;
                        int i = clmbsrc.Find(cboxcol.ValueMember, value);
                        var dr = (DataRowView) clmbsrc[i];

                        key = dr[cboxcol.DisplayMember].ToString();
                    }
                    else
                        key = value;
                    dataDic[key] = new ItemData
                                       {
                                           Value = (key == value) ? string.Empty : value,
                                           ItemVisible = true,
                                           State = CheckState.Checked
                                       };
                }
            }
            return dataDic;
        }

        private void LoadCheckedListBox(Dictionary<string, ItemData> ctrl)
        {
            CheckedListBox chl = FilteringCheckedListBox;
            chl.Items.Clear();
            foreach (KeyValuePair<string, ItemData> data in ctrl)
                if (data.Value.ItemVisible)
                    chl.SetItemCheckState(chl.Items.Add(data.Key), data.Value.State);
        }

        private void ModifyCheckList(SetConditionAtIndex checkcondition, SetCheckState setCheckState)
        {
            CheckedListBox chl = FilteringCheckedListBox;
            for (int i = 0; i < chl.Items.Count; i++)
                if (checkcondition(chl.Items[i].ToString(), i))
                    chl.SetItemCheckState(i, setCheckState(chl.Items[i].ToString()));
        }

        private static void SaveCheckListBox(CheckedListBox chl, IDictionary<string, ItemData> datadic)
        {
            for (int i = 0; i < chl.Items.Count; i++)
                datadic[chl.Items[i].ToString()] = new ItemData
                                                       {
                                                           Value = datadic[chl.Items[i].ToString()].Value,
                                                           State = chl.GetItemCheckState(i),
                                                           ItemVisible = true
                                                       };
        }

        private static void ModifyDataDictionary(Dictionary<string, ItemData> columndatadic, SetCondition checkcondition,
                                                 SetCheckState setCheckState, SetCondition setVisible)
        {
            var keys = new List<string>(columndatadic.Keys);
            foreach (string key in keys)
                if (checkcondition(key))
                    columndatadic[key] = new ItemData
                                             {
                                                 Value = columndatadic[key].Value,
                                                 State = setCheckState(key),
                                                 ItemVisible = setVisible(key)
                                             };
        }

        public void ClearAll()
        {
            ProcessFilteredDataGridView
                (column =>
                     {
                         if (column.Tag != null &&
                             column.Tag.ToString() != Hidden)
                             column.Tag = null;
                         column.HeaderCell.Style.Font =
                             new Font(FilteredDataGridView.ColumnHeadersDefaultCellStyle.Clone().Font, FontStyle.Regular);
                     }
                );
            FilteredBindingSource.RemoveFilter();
        }

        private delegate bool SetConditionAtIndex(string key, int index);

        #endregion

        #region Handlers

        private void SortDesToolStripMenuItemClick(object sender, EventArgs e)
        {
            FilteredDataGridView.Sort(CurrentColumn, ListSortDirection.Descending);
        }

        private void FilteringContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (FilteredDataGridView.CurrentCell == null)
            {
                e.Cancel = true;
                return;
            }
            Dictionary<string, ItemData> dataDic = GetDataDictionary(FilteredDataGridView.CurrentCell.OwningColumn);
            FilteredDataGridView.CurrentCell.OwningColumn.Tag = dataDic;
            UpdateVisibleValues();
            LoadCheckedListBox(dataDic);
            FilteringCheckedListBox.SelectedIndexChanged += ChlSelectedIndexChanged;
        }

        private void InsertUpdateSearchItemButtonClick(object sender, EventArgs e)
        {
            string comparedText = ValueControl.Text.ToLower().Trim(' ', '.');
            ModifyCheckList(
                (key, i) => (key != Selectall && (
                                                     RelationComboBox.Text == Single
                                                     ||
                                                     RelationComboBox.Text == And &&
                                                     FilteringCheckedListBox.GetItemCheckState(i) == CheckState.Checked
                                                     ||
                                                     RelationComboBox.Text == Or &&
                                                     FilteringCheckedListBox.GetItemCheckState(i) ==
                                                     CheckState.Unchecked
                                                 )),
                key => (
                           //String Operations
                       (CurrentColumnIsString && (
                                                     OperatorComboBox.Text == SContains &&
                                                     key.ToLower().Contains(comparedText)
                                                     ||
                                                     OperatorComboBox.Text == StartsWith &&
                                                     key.ToLower().StartsWith(comparedText)
                                                     ||
                                                     OperatorComboBox.Text == EndsWith &&
                                                     key.ToLower().EndsWith(comparedText)
                                                 ))
                       // Numerical Operations
                       || (CurrentColumnIsNumeric && (
                                                         OperatorComboBox.Text == SEquals &&
                                                         decimal.Parse(key) == decimal.Parse(comparedText)
                                                         ||
                                                         OperatorComboBox.Text == NotEquals &&
                                                         decimal.Parse(key) != decimal.Parse(comparedText)
                                                         ||
                                                         OperatorComboBox.Text == LargerThan &&
                                                         decimal.Parse(key) > decimal.Parse(comparedText)
                                                         ||
                                                         OperatorComboBox.Text == LessThan &&
                                                         decimal.Parse(key) < int.Parse(comparedText)
                                                         ||
                                                         OperatorComboBox.Text == LargerThanOrEquals &&
                                                         decimal.Parse(key) >= decimal.Parse(comparedText)
                                                         ||
                                                         OperatorComboBox.Text == LessThanOrEquals &&
                                                         decimal.Parse(key) <= decimal.Parse(comparedText)
                                                     ))
                       // DateTime Operations
                       || (CurrentColumnIsDateTime && (
                                                          OperatorComboBox.Text == SEquals &&
                                                          DateTime.Parse(key).Date == DateTime.Parse(comparedText).Date
                                                          ||
                                                          OperatorComboBox.Text == NotEquals &&
                                                          DateTime.Parse(key).Date != DateTime.Parse(comparedText).Date
                                                          ||
                                                          OperatorComboBox.Text == LargerThan &&
                                                          DateTime.Parse(key).Date > DateTime.Parse(comparedText).Date
                                                          ||
                                                          OperatorComboBox.Text == LessThan &&
                                                          DateTime.Parse(key).Date < DateTime.Parse(comparedText).Date
                                                          ||
                                                          OperatorComboBox.Text == LargerThanOrEquals &&
                                                          DateTime.Parse(key).Date >= DateTime.Parse(comparedText).Date
                                                          ||
                                                          OperatorComboBox.Text == LessThanOrEquals &&
                                                          DateTime.Parse(key).Date <= DateTime.Parse(comparedText).Date
                                                      ))
                       )
                           ? CheckState.Checked
                           : CheckState.Unchecked);
            filtersToolStripMenuItem.ShowDropDown();
            SetSelectAllState();
        }

        private void FiltersToolStripMenuItemDropDownOpening(object sender, EventArgs e)
        {
            // satrtdateTimePicker starts from last month and enddateTimePicker ends today
            OperatorComboBox.Refresh();
            ValueControl.Refresh();
            InsertUpdateSearchItemButton.ToString();
        }

        private void ChlSelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBox clb = FilteringCheckedListBox;
            CheckState newValue = clb.GetItemCheckState(clb.SelectedIndex);
            if (clb.SelectedIndex == 0 && newValue != CheckState.Indeterminate)
                for (int i = 1; i < clb.Items.Count; i++)
                    clb.SetItemCheckState(i, newValue);
            else
            {
                CheckState cs = CheckState.Indeterminate;
                if (FilteringCheckedListBox.CheckedIndices.Count == FilteringCheckedListBox.Items.Count)
                    cs = CheckState.Checked;
                else if (FilteringCheckedListBox.CheckedIndices.Count == 0)
                    cs = CheckState.Unchecked;
                FilteringCheckedListBox.SetItemCheckState(0, cs);
            }
        }

        private void SortAscToolStripMenuItemClick(object sender, EventArgs e)
        {
            FilteredDataGridView.Sort(CurrentColumn, ListSortDirection.Ascending);
        }

        private void UnFreezeAllColumnToolStripMenuItemClick(object sender, EventArgs e)
        {
            ProcessFilteredDataGridView(column => column.Frozen = false);
        }

        private void FreezeColumnToolStripMenuItemClick(object sender, EventArgs e)
        {
            CurrentColumn.Frozen = true;
        }

        private void ShowAllColumnsToolStripMenuItemClick(object sender, EventArgs e)
        {
            ProcessFilteredDataGridView(column =>
                                            {
                                                if (column.Tag != null && column.Tag.ToString() != Hidden)
                                                    column.Visible = true;
                                            });
        }

        private void HideColumnToolStripMenuItemClick(object sender, EventArgs e)
        {
            CurrentColumn.Visible = false;
        }

        private void OkToolStripMenuItemClick(object sender, EventArgs e)
        {
            SaveCheckListBox(FilteringCheckedListBox, GetDataDictionary(FilteredDataGridView.CurrentCell.OwningColumn));
            if (!_filteredColums.Contains(FilteredDataGridView.CurrentCell.OwningColumn.Name))
                _filteredColums.Push(FilteredDataGridView.CurrentCell.OwningColumn.Name);
            DataGridViewCellStyle cs = FilteredDataGridView.ColumnHeadersDefaultCellStyle.Clone();
            cs.Font = FilteringCheckedListBox.GetItemCheckState(0) != CheckState.Checked
                          ? new Font(cs.Font, FontStyle.Bold)
                          : new Font(cs.Font, FontStyle.Regular);
            CurrentColumn.HeaderCell.Style = cs;
            FilteredBindingSource.Filter = DataFilter;
            Close();
        }

        private void CancelToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        // ReSharper disable MemberCanBeMadeStatic.Local
        private void ToolStripMenuItemMouseEnter(object sender, EventArgs e)
            // ReSharper restore MemberCanBeMadeStatic.Local
        {
            var ctrl = (ToolStripMenuItem) sender;
            ctrl.Select();
        }

        private void ClientsDataGridViewMouseClick(object sender, MouseEventArgs e)
        {
            if (Visible && e.Button == MouseButtons.Left)
            {
                Close();
            }
        }

        private void ClientsDataGridViewCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || e.Button != MouseButtons.Right) return;
            FilteredDataGridView.CurrentCell = FilteredDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            Rectangle r = FilteredDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            Show((Control) sender, r.Left + e.X, r.Top + e.Y);
            Visible = true;
        }

        private void FilteringContextMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.AppFocusChange ||
                e.CloseReason == ToolStripDropDownCloseReason.CloseCalled)
                e.Cancel = true;
        }

        #endregion
    }
}