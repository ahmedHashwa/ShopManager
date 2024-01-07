using System.Windows.Forms;
using ShopManager.Controls.Data.ShopDataSetTableAdapters;

namespace ShopManager.Controls.Regular
{
    partial class FridgeOutsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fridgesComboBox = new System.Windows.Forms.ComboBox();
            this.الثلاجاتBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.العملاءBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.outputDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label34 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.اسم_الخامBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.billNONumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.N_KilosNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.صرف_الثلاجاتTableAdapter = new ShopManager.Controls.Data.ShopDataSetTableAdapters.صرف_الثلاجاتTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.rawkindsComboBox = new System.Windows.Forms.ComboBox();
            this.الأنواع_الخامTableAdapter = new ShopManager.Controls.Data.ShopDataSetTableAdapters.الأنواع_الخامTableAdapter();
            this.الثلاجاتTableAdapter = new ShopManager.Controls.Data.ShopDataSetTableAdapters.الثلاجاتTableAdapter();
            this.العملاءTableAdapter = new ShopManager.Controls.Data.ShopDataSetTableAdapters.العملاءTableAdapter();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BeginningBalanceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.N_CagesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.جهةالصرفDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.التاريخDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.الوزنبالكيلوDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.اسمالخامDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.اسمالثلاجةDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.رقمإذنالصرفDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.مسلسلDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.الكميةبالأقفاصDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataSet)).BeginInit();
            this.insertEditPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.الثلاجاتBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.العملاءBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.اسم_الخامBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billNONumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.N_KilosNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeginningBalanceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.N_CagesNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // insertEditPanel
            // 
            this.insertEditPanel.Controls.Add(this.clientComboBox);
            this.insertEditPanel.Controls.Add(this.label5);
            this.insertEditPanel.Controls.Add(this.BeginningBalanceNumericUpDown);
            this.insertEditPanel.Controls.Add(this.label6);
            this.insertEditPanel.Controls.Add(this.balanceLabel);
            this.insertEditPanel.Controls.Add(this.rawkindsComboBox);
            this.insertEditPanel.Controls.Add(this.fridgesComboBox);
            this.insertEditPanel.Controls.Add(this.outputDateDateTimePicker);
            this.insertEditPanel.Controls.Add(this.label4);
            this.insertEditPanel.Controls.Add(this.label34);
            this.insertEditPanel.Controls.Add(this.billNONumericUpDown);
            this.insertEditPanel.Controls.Add(this.N_CagesNumericUpDown);
            this.insertEditPanel.Controls.Add(this.N_KilosNumericUpDown);
            this.insertEditPanel.Controls.Add(this.label7);
            this.insertEditPanel.Controls.Add(this.label13);
            this.insertEditPanel.Controls.Add(this.label25);
            this.insertEditPanel.Controls.Add(this.label2);
            this.insertEditPanel.Controls.Add(this.label14);
            this.insertEditPanel.Controls.Add(this.label1);
            this.insertEditPanel.Size = new System.Drawing.Size(520, 413);
            this.insertEditPanel.TabIndex = 0;
            this.insertEditPanel.Controls.SetChildIndex(this.insertUpdateLabel, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label1, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label14, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label2, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label25, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label13, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label7, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.N_KilosNumericUpDown, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.N_CagesNumericUpDown, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.billNONumericUpDown, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label34, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label4, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.outputDateDateTimePicker, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.fridgesComboBox, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.rawkindsComboBox, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.balanceLabel, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label6, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.BeginningBalanceNumericUpDown, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label5, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.clientComboBox, 0);
            // 
            // parentBindingSource
            // 
            this.parentBindingSource.DataMember = "صرف_الثلاجات";
            this.parentBindingSource.Filter = "";
            this.parentBindingSource.Position = -1;
            // 
            // fridgesComboBox
            // 
            this.fridgesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fridgesComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.parentBindingSource, "اسم الثلاجة", true));
            this.fridgesComboBox.DataSource = this.الثلاجاتBindingSource;
            this.fridgesComboBox.DisplayMember = "الاسم";
            this.fridgesComboBox.Location = new System.Drawing.Point(225, 40);
            this.fridgesComboBox.Name = "fridgesComboBox";
            this.fridgesComboBox.Size = new System.Drawing.Size(147, 26);
            this.fridgesComboBox.TabIndex = 0;
            this.fridgesComboBox.Tag = "bind";
            this.fridgesComboBox.ValueMember = "معرف";
            // 
            // الثلاجاتBindingSource
            // 
            this.الثلاجاتBindingSource.DataMember = "الثلاجات";
            this.الثلاجاتBindingSource.DataSource = this.MainDataSet;
            // 
            // العملاءBindingSource
            // 
            this.العملاءBindingSource.DataMember = "العملاء";
            this.العملاءBindingSource.DataSource = this.MainDataSet;
            // 
            // outputDateDateTimePicker
            // 
            this.outputDateDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.parentBindingSource, "التاريخ", true));
            this.outputDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.outputDateDateTimePicker.Location = new System.Drawing.Point(225, 182);
            this.outputDateDateTimePicker.Name = "outputDateDateTimePicker";
            this.outputDateDateTimePicker.RightToLeftLayout = true;
            this.outputDateDateTimePicker.Size = new System.Drawing.Size(147, 25);
            this.outputDateDateTimePicker.TabIndex = 3;
            this.outputDateDateTimePicker.Tag = "bind";
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(399, 44);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(95, 18);
            this.label34.TabIndex = 18;
            this.label34.Text = "اسم الثلاجة :";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(403, 185);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(91, 18);
            this.label25.TabIndex = 13;
            this.label25.Text = "تاريخ الصرف :";
            // 
            // اسم_الخامBindingSource
            // 
            this.اسم_الخامBindingSource.DataMember = "الأنواع الخام";
            this.اسم_الخامBindingSource.DataSource = this.MainDataSet;
            // 
            // billNONumericUpDown
            // 
            this.billNONumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.billNONumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.parentBindingSource, "رقم إذن الصرف", true));
            this.billNONumericUpDown.Location = new System.Drawing.Point(225, 135);
            this.billNONumericUpDown.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.billNONumericUpDown.Name = "billNONumericUpDown";
            this.billNONumericUpDown.Size = new System.Drawing.Size(147, 25);
            this.billNONumericUpDown.TabIndex = 2;
            this.billNONumericUpDown.Tag = "bind";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(404, 232);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 19;
            this.label1.Text = "الوزن بالكيلو :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(178, 232);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 18);
            this.label13.TabIndex = 11;
            this.label13.Text = "كيلو";
            // 
            // N_KilosNumericUpDown
            // 
            this.N_KilosNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.N_KilosNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.parentBindingSource, "الوزن بالكيلو", true));
            this.N_KilosNumericUpDown.Location = new System.Drawing.Point(225, 229);
            this.N_KilosNumericUpDown.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.N_KilosNumericUpDown.Name = "N_KilosNumericUpDown";
            this.N_KilosNumericUpDown.Size = new System.Drawing.Size(147, 25);
            this.N_KilosNumericUpDown.TabIndex = 4;
            this.N_KilosNumericUpDown.Tag = "bind";
            this.N_KilosNumericUpDown.ThousandsSeparator = true;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(389, 138);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 18);
            this.label14.TabIndex = 19;
            this.label14.Text = "رقم إذن الصرف:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // صرف_الثلاجاتTableAdapter
            // 
            this.صرف_الثلاجاتTableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 91);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "اسم الخام :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rawkindsComboBox
            // 
            this.rawkindsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rawkindsComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.parentBindingSource, "اسم الخام", true));
            this.rawkindsComboBox.DataSource = this.اسم_الخامBindingSource;
            this.rawkindsComboBox.DisplayMember = "الاسم";
            this.rawkindsComboBox.Location = new System.Drawing.Point(225, 87);
            this.rawkindsComboBox.Name = "rawkindsComboBox";
            this.rawkindsComboBox.Size = new System.Drawing.Size(147, 26);
            this.rawkindsComboBox.TabIndex = 1;
            this.rawkindsComboBox.Tag = "bind";
            this.rawkindsComboBox.ValueMember = "معرف";
            // 
            // الأنواع_الخامTableAdapter
            // 
            this.الأنواع_الخامTableAdapter.ClearBeforeFill = false;
            // 
            // الثلاجاتTableAdapter
            // 
            this.الثلاجاتTableAdapter.ClearBeforeFill = false;
            // 
            // العملاءTableAdapter
            // 
            this.العملاءTableAdapter.ClearBeforeFill = false;
            // 
            // clientComboBox
            // 
            this.clientComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clientComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.parentBindingSource, "جهة الصرف", true));
            this.clientComboBox.DataSource = this.العملاءBindingSource;
            this.clientComboBox.DisplayMember = "الاسم";
            this.clientComboBox.Location = new System.Drawing.Point(228, 318);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(147, 26);
            this.clientComboBox.TabIndex = 6;
            this.clientComboBox.Tag = "bind";
            this.clientComboBox.ValueMember = "معرف";
            this.clientComboBox.Validated += new System.EventHandler(this.ClientComboBoxValidated);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(405, 322);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 18);
            this.label5.TabIndex = 23;
            this.label5.Text = "اسم العميل :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BeginningBalanceNumericUpDown
            // 
            this.BeginningBalanceNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BeginningBalanceNumericUpDown.DecimalPlaces = 1;
            this.BeginningBalanceNumericUpDown.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.BeginningBalanceNumericUpDown.Location = new System.Drawing.Point(228, 366);
            this.BeginningBalanceNumericUpDown.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.BeginningBalanceNumericUpDown.Name = "BeginningBalanceNumericUpDown";
            this.BeginningBalanceNumericUpDown.ReadOnly = true;
            this.BeginningBalanceNumericUpDown.Size = new System.Drawing.Size(147, 25);
            this.BeginningBalanceNumericUpDown.TabIndex = 7;
            this.BeginningBalanceNumericUpDown.Tag = "";
            this.BeginningBalanceNumericUpDown.ThousandsSeparator = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(131, 369);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 18);
            this.label6.TabIndex = 22;
            this.label6.Text = "جنيه مصري";
            // 
            // balanceLabel
            // 
            this.balanceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.balanceLabel.AutoSize = true;
            this.balanceLabel.Location = new System.Drawing.Point(394, 369);
            this.balanceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(103, 18);
            this.balanceLabel.TabIndex = 24;
            this.balanceLabel.Text = "الرصيد الحالي :";
            this.balanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 277);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "عدد الأقفاص :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(171, 277);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 18);
            this.label7.TabIndex = 11;
            this.label7.Text = "قفص";
            // 
            // N_CagesNumericUpDown
            // 
            this.N_CagesNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.N_CagesNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.parentBindingSource, "الكمية بالأقفاص", true));
            this.N_CagesNumericUpDown.Location = new System.Drawing.Point(225, 274);
            this.N_CagesNumericUpDown.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.N_CagesNumericUpDown.Name = "N_CagesNumericUpDown";
            this.N_CagesNumericUpDown.Size = new System.Drawing.Size(147, 25);
            this.N_CagesNumericUpDown.TabIndex = 5;
            this.N_CagesNumericUpDown.Tag = "bind";
            this.N_CagesNumericUpDown.ThousandsSeparator = true;
            // 
            // جهةالصرفDataGridViewTextBoxColumn
            // 
            this.جهةالصرفDataGridViewTextBoxColumn.DataPropertyName = "جهة الصرف";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.جهةالصرفDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.جهةالصرفDataGridViewTextBoxColumn.HeaderText = "جهة الصرف";
            this.جهةالصرفDataGridViewTextBoxColumn.Name = "جهةالصرفDataGridViewTextBoxColumn";
            this.جهةالصرفDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // التاريخDataGridViewTextBoxColumn
            // 
            this.التاريخDataGridViewTextBoxColumn.DataPropertyName = "التاريخ";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.التاريخDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.التاريخDataGridViewTextBoxColumn.HeaderText = "التاريخ";
            this.التاريخDataGridViewTextBoxColumn.Name = "التاريخDataGridViewTextBoxColumn";
            this.التاريخDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // الوزنبالكيلوDataGridViewTextBoxColumn
            // 
            this.الوزنبالكيلوDataGridViewTextBoxColumn.DataPropertyName = "الوزن بالكيلو";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.الوزنبالكيلوDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.الوزنبالكيلوDataGridViewTextBoxColumn.HeaderText = "الوزن بالكيلو";
            this.الوزنبالكيلوDataGridViewTextBoxColumn.Name = "الوزنبالكيلوDataGridViewTextBoxColumn";
            this.الوزنبالكيلوDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // اسمالخامDataGridViewTextBoxColumn
            // 
            this.اسمالخامDataGridViewTextBoxColumn.DataPropertyName = "اسم الخام";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.اسمالخامDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.اسمالخامDataGridViewTextBoxColumn.HeaderText = "اسم الخام";
            this.اسمالخامDataGridViewTextBoxColumn.Name = "اسمالخامDataGridViewTextBoxColumn";
            this.اسمالخامDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // اسمالثلاجةDataGridViewTextBoxColumn
            // 
            this.اسمالثلاجةDataGridViewTextBoxColumn.DataPropertyName = "اسم الثلاجة";
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.اسمالثلاجةDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.اسمالثلاجةDataGridViewTextBoxColumn.HeaderText = "اسم الثلاجة";
            this.اسمالثلاجةDataGridViewTextBoxColumn.Name = "اسمالثلاجةDataGridViewTextBoxColumn";
            this.اسمالثلاجةDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // رقمإذنالصرفDataGridViewTextBoxColumn
            // 
            this.رقمإذنالصرفDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.رقمإذنالصرفDataGridViewTextBoxColumn.DataPropertyName = "رقم إذن الصرف";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.رقمإذنالصرفDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.رقمإذنالصرفDataGridViewTextBoxColumn.HeaderText = "رقم إذن الصرف";
            this.رقمإذنالصرفDataGridViewTextBoxColumn.Name = "رقمإذنالصرفDataGridViewTextBoxColumn";
            this.رقمإذنالصرفDataGridViewTextBoxColumn.ReadOnly = true;
            this.رقمإذنالصرفDataGridViewTextBoxColumn.Width = 125;
            // 
            // مسلسلDataGridViewTextBoxColumn
            // 
            this.مسلسلDataGridViewTextBoxColumn.DataPropertyName = "مسلسل";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.مسلسلDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.مسلسلDataGridViewTextBoxColumn.HeaderText = "مسلسل";
            this.مسلسلDataGridViewTextBoxColumn.Name = "مسلسلDataGridViewTextBoxColumn";
            this.مسلسلDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // الكميةبالأقفاصDataGridViewTextBoxColumn
            // 
            this.الكميةبالأقفاصDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.الكميةبالأقفاصDataGridViewTextBoxColumn.DataPropertyName = "الكمية بالأقفاص";
            this.الكميةبالأقفاصDataGridViewTextBoxColumn.HeaderText = "العدد بالأقفاص";
            this.الكميةبالأقفاصDataGridViewTextBoxColumn.Name = "الكميةبالأقفاصDataGridViewTextBoxColumn";
            this.الكميةبالأقفاصDataGridViewTextBoxColumn.ReadOnly = true;
            this.الكميةبالأقفاصDataGridViewTextBoxColumn.Width = 129;
            // 
            // FridgeOutsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.مسلسلDataGridViewTextBoxColumn,
            this.رقمإذنالصرفDataGridViewTextBoxColumn,
            this.اسمالثلاجةDataGridViewTextBoxColumn,
            this.اسمالخامDataGridViewTextBoxColumn,
            this.الوزنبالكيلوDataGridViewTextBoxColumn,
            this.الكميةبالأقفاصDataGridViewTextBoxColumn,
            this.التاريخDataGridViewTextBoxColumn,
            this.جهةالصرفDataGridViewTextBoxColumn});
            this.Name = "FridgeOutsControl";
            this.DeleteRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.FridgeOut_DeleteRow);
            this.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.FridgeOut_RowEnter);
            this.LoadByTimeRange += new System.EventHandler(this.FridgeOut_LoadByTimeRange);
            this.LoadByPeriod += new System.EventHandler(this.FridgeOut_LoadByPeriod);
            this.LoadAll += new System.EventHandler(this.FridgeOut_LoadAll);
            this.ClearData += new System.EventHandler(this.FridgeOut_ClearData);
            this.AddNewItem += new System.EventHandler(this.FridgeOut_AddNewItem);
            this.RefreshingData += new System.EventHandler(this.FridgeOut_RefreshingData);
            this.UpdateItem += new System.EventHandler(this.FridgeOut_UpdateItem);
            ((System.ComponentModel.ISupportInitialize)(this.MainDataSet)).EndInit();
            this.insertEditPanel.ResumeLayout(false);
            this.insertEditPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.الثلاجاتBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.العملاءBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.اسم_الخامBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billNONumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.N_KilosNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeginningBalanceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.N_CagesNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }





        #endregion

        private System.Windows.Forms.ComboBox fridgesComboBox;
        private System.Windows.Forms.DateTimePicker outputDateDateTimePicker;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.BindingSource اسم_الخامBindingSource;
        private System.Windows.Forms.BindingSource العملاءBindingSource;

        private NumericUpDown billNONumericUpDown;
        private Label label13;
        private Label label1;
        private NumericUpDown N_KilosNumericUpDown;
        private Label label14;
        private صرف_الثلاجاتTableAdapter صرف_الثلاجاتTableAdapter;
        private ComboBox rawkindsComboBox;
        private Label label4;
        private الأنواع_الخامTableAdapter الأنواع_الخامTableAdapter;
        private BindingSource الثلاجاتBindingSource;
        private الثلاجاتTableAdapter الثلاجاتTableAdapter;
        private العملاءTableAdapter العملاءTableAdapter;
        private ComboBox clientComboBox;
        private Label label5;
        private NumericUpDown BeginningBalanceNumericUpDown;
        private Label label6;
        private Label balanceLabel;
        private NumericUpDown N_CagesNumericUpDown;
        private Label label7;
        private Label label2;
        private DataGridViewTextBoxColumn جهةالصرفDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn التاريخDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn الوزنبالكيلوDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn اسمالخامDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn اسمالثلاجةDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn رقمإذنالصرفDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn مسلسلDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn الكميةبالأقفاصDataGridViewTextBoxColumn;



    }
}