using ShopManager.Controls.Data.ShopDataSetTableAdapters;

namespace ShopManager.Controls.Regular
{
    partial class ExpensesControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.أنواعالمصروفاتBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.expensesTypeDescComboBox = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.expenseamountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label38 = new System.Windows.Forms.Label();
            this.expensesDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.أنواع_الصرفTableAdapter = new ShopManager.Controls.Data.ShopDataSetTableAdapters.أنواع_الصرفTableAdapter();
            this.expensesTableAdapter = new ShopManager.Controls.Data.ShopDataSetTableAdapters.المصاريفTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.orderForPaymentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.مسلسلDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.نوعالصرفDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.اذنالصرفDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.الكميةDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.التاريخDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataSet)).BeginInit();
            this.insertEditPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.أنواعالمصروفاتBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expenseamountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderForPaymentNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.insertUpdateLabel.Location = new System.Drawing.Point(430, 15);
            // 
            // insertEditPanel
            // 
            this.insertEditPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.insertEditPanel.Controls.Add(this.expensesTypeDescComboBox);
            this.insertEditPanel.Controls.Add(this.orderForPaymentNumericUpDown);
            this.insertEditPanel.Controls.Add(this.expenseamountNumericUpDown);
            this.insertEditPanel.Controls.Add(this.expensesDateTimePicker);
            this.insertEditPanel.Controls.Add(this.label38);
            this.insertEditPanel.Controls.Add(this.label28);
            this.insertEditPanel.Controls.Add(this.label1);
            this.insertEditPanel.Controls.Add(this.label27);
            this.insertEditPanel.Controls.Add(this.label37);
            this.insertEditPanel.Dock = System.Windows.Forms.DockStyle.None;
            this.insertEditPanel.Size = new System.Drawing.Size(538, 401);
            this.insertEditPanel.Controls.SetChildIndex(this.insertUpdateLabel, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label37, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label27, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label1, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label28, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label38, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.expensesDateTimePicker, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.expenseamountNumericUpDown, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.orderForPaymentNumericUpDown, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.expensesTypeDescComboBox, 0);
            // 
            // parentBindingSource
            // 
            this.parentBindingSource.DataMember = "المصاريف";
            this.parentBindingSource.Filter = "";
            this.parentBindingSource.Position = -1;
            // 
            // أنواعالمصروفاتBindingSource
            // 
            this.أنواعالمصروفاتBindingSource.DataMember = "أنواع الصرف";
            this.أنواعالمصروفاتBindingSource.DataSource = this.MainDataSet;
            // 
            // expensesTypeDescComboBox
            // 
            this.expensesTypeDescComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.expensesTypeDescComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.parentBindingSource, "نوع الصرف", true));
            this.expensesTypeDescComboBox.DataSource = this.أنواعالمصروفاتBindingSource;
            this.expensesTypeDescComboBox.DisplayMember = "الاسم";
            this.expensesTypeDescComboBox.FormattingEnabled = true;
            this.expensesTypeDescComboBox.Location = new System.Drawing.Point(324, 67);
            this.expensesTypeDescComboBox.Name = "expensesTypeDescComboBox";
            this.expensesTypeDescComboBox.Size = new System.Drawing.Size(121, 26);
            this.expensesTypeDescComboBox.TabIndex = 0;
            this.expensesTypeDescComboBox.Tag = "bind";
            this.expensesTypeDescComboBox.ValueMember = "معرف";
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(461, 71);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(51, 18);
            this.label27.TabIndex = 0;
            this.label27.Text = "السبب";
            // 
            // label37
            // 
            this.label37.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(468, 165);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(44, 18);
            this.label37.TabIndex = 8;
            this.label37.Text = "المبلغ";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(276, 165);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(82, 18);
            this.label28.TabIndex = 9;
            this.label28.Text = "جنيه مصري";
            // 
            // expenseamountNumericUpDown
            // 
            this.expenseamountNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.expenseamountNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.parentBindingSource, "الكمية", true));
            this.expenseamountNumericUpDown.DecimalPlaces = 1;
            this.expenseamountNumericUpDown.Location = new System.Drawing.Point(360, 162);
            this.expenseamountNumericUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.expenseamountNumericUpDown.Name = "expenseamountNumericUpDown";
            this.expenseamountNumericUpDown.Size = new System.Drawing.Size(85, 25);
            this.expenseamountNumericUpDown.TabIndex = 2;
            this.expenseamountNumericUpDown.Tag = "bind";
            this.expenseamountNumericUpDown.ThousandsSeparator = true;
            // 
            // label38
            // 
            this.label38.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(467, 212);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(45, 18);
            this.label38.TabIndex = 0;
            this.label38.Text = "التاريخ";
            // 
            // expensesDateTimePicker
            // 
            this.expensesDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.expensesDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.parentBindingSource, "التاريخ", true));
            this.expensesDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.expensesDateTimePicker.Location = new System.Drawing.Point(313, 209);
            this.expensesDateTimePicker.Name = "expensesDateTimePicker";
            this.expensesDateTimePicker.RightToLeftLayout = true;
            this.expensesDateTimePicker.Size = new System.Drawing.Size(142, 25);
            this.expensesDateTimePicker.TabIndex = 3;
            this.expensesDateTimePicker.Tag = "bind";
            // 
            // أنواع_الصرفTableAdapter
            // 
            this.أنواع_الصرفTableAdapter.ClearBeforeFill = false;
            // 
            // expensesTableAdapter
            // 
            this.expensesTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(447, 118);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "اذن صرف";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // orderForPaymentNumericUpDown
            // 
            this.orderForPaymentNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.orderForPaymentNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.parentBindingSource, "اذن الصرف", true));
            this.orderForPaymentNumericUpDown.Location = new System.Drawing.Point(339, 115);
            this.orderForPaymentNumericUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.orderForPaymentNumericUpDown.Name = "orderForPaymentNumericUpDown";
            this.orderForPaymentNumericUpDown.Size = new System.Drawing.Size(85, 25);
            this.orderForPaymentNumericUpDown.TabIndex = 1;
            this.orderForPaymentNumericUpDown.Tag = "bind";
            // 
            // مسلسلDataGridViewTextBoxColumn
            // 
            this.مسلسلDataGridViewTextBoxColumn.DataPropertyName = "مسلسل";
            this.مسلسلDataGridViewTextBoxColumn.HeaderText = "مسلسل";
            this.مسلسلDataGridViewTextBoxColumn.Name = "مسلسلDataGridViewTextBoxColumn";
            this.مسلسلDataGridViewTextBoxColumn.ReadOnly = true;
            this.مسلسلDataGridViewTextBoxColumn.Visible = false;
            // 
            // نوعالصرفDataGridViewTextBoxColumn
            // 
            this.نوعالصرفDataGridViewTextBoxColumn.DataPropertyName = "نوع الصرف";
            this.نوعالصرفDataGridViewTextBoxColumn.HeaderText = "نوع الصرف";
            this.نوعالصرفDataGridViewTextBoxColumn.Name = "نوعالصرفDataGridViewTextBoxColumn";
            this.نوعالصرفDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // اذنالصرفDataGridViewTextBoxColumn
            // 
            this.اذنالصرفDataGridViewTextBoxColumn.DataPropertyName = "اذن الصرف";
            this.اذنالصرفDataGridViewTextBoxColumn.HeaderText = "اذن الصرف";
            this.اذنالصرفDataGridViewTextBoxColumn.Name = "اذنالصرفDataGridViewTextBoxColumn";
            this.اذنالصرفDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // الكميةDataGridViewTextBoxColumn
            // 
            this.الكميةDataGridViewTextBoxColumn.DataPropertyName = "الكمية";
            this.الكميةDataGridViewTextBoxColumn.HeaderText = "الكمية";
            this.الكميةDataGridViewTextBoxColumn.Name = "الكميةDataGridViewTextBoxColumn";
            this.الكميةDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // التاريخDataGridViewTextBoxColumn
            // 
            this.التاريخDataGridViewTextBoxColumn.DataPropertyName = "التاريخ";
            this.التاريخDataGridViewTextBoxColumn.HeaderText = "التاريخ";
            this.التاريخDataGridViewTextBoxColumn.Name = "التاريخDataGridViewTextBoxColumn";
            this.التاريخDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ExpensesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.مسلسلDataGridViewTextBoxColumn,
            this.نوعالصرفDataGridViewTextBoxColumn,
            this.اذنالصرفDataGridViewTextBoxColumn,
            this.الكميةDataGridViewTextBoxColumn,
            this.التاريخDataGridViewTextBoxColumn});
            this.Name = "ExpensesControl";
            this.Size = new System.Drawing.Size(538, 578);
            this.AddNewItem += new System.EventHandler(this.ExpensesControl_AddNewItem);
            this.UpdateItem += new System.EventHandler(this.ExpensesControl_UpdateItem);
            this.RefreshingData += new System.EventHandler(this.ExpensesControl_RefreshingData);
            this.DeleteRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.ExpensesControl_DeleteRow);
            this.LoadByTimeRange += new System.EventHandler(this.ExpensesControl_LoadByTimeRange);
            this.LoadByPeriod += new System.EventHandler(this.ExpensesControl_LoadByPeriod);
            this.ClearData += new System.EventHandler(this.ExpensesControl_ClearData);
            this.LoadAll += new System.EventHandler(this.ExpensesControl_LoadAll);
            ((System.ComponentModel.ISupportInitialize)(this.MainDataSet)).EndInit();
            this.insertEditPanel.ResumeLayout(false);
            this.insertEditPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.أنواعالمصروفاتBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expenseamountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderForPaymentNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox expensesTypeDescComboBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.BindingSource أنواعالمصروفاتBindingSource;
        private System.Windows.Forms.NumericUpDown expenseamountNumericUpDown;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.DateTimePicker expensesDateTimePicker;
        private System.Windows.Forms.Label label38;
        private أنواع_الصرفTableAdapter أنواع_الصرفTableAdapter;
        private المصاريفTableAdapter expensesTableAdapter;
        private System.Windows.Forms.NumericUpDown orderForPaymentNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn مسلسلDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn نوعالصرفDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn اذنالصرفDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn الكميةDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn التاريخDataGridViewTextBoxColumn;

    }
}