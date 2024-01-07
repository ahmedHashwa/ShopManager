using System.Windows.Forms;
using ShopManager.Controls.Data.ShopDataSetTableAdapters;

namespace ShopManager.Controls.Regular
{
    partial class ManufacturingsControl
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
            this.outputDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.أنواعالبيعbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.اسم_الخامBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.jerkinPriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.أنواع_البيعTableAdapter = new ShopManager.Controls.Data.ShopDataSetTableAdapters.أنواع_البيعTableAdapter();
            this.sugarPriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.N_KilosNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.kiloPriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rawkindsComboBox = new System.Windows.Forms.ComboBox();
            this.الأنواع_الخامTableAdapter = new ShopManager.Controls.Data.ShopDataSetTableAdapters.الأنواع_الخامTableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.totalPriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.salesKindNameComboBox = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.N_CagesInLitersNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.التصنيعTableAdapter = new ShopManager.Controls.Data.ShopDataSetTableAdapters.التصنيعTableAdapter();
            this.مسلسلDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.اسمالخامDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.كميةالخامDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.سعرالكيلوDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.قيمةالسكرDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.قيمةالجراكنDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.التاريخDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.الكميةباللترDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.اسمالعصيرDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataSet)).BeginInit();
            this.insertEditPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.أنواعالبيعbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.اسم_الخامBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jerkinPriceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sugarPriceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.N_KilosNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kiloPriceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalPriceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.N_CagesInLitersNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // insertEditPanel
            // 
            this.insertEditPanel.Controls.Add(this.salesKindNameComboBox);
            this.insertEditPanel.Controls.Add(this.rawkindsComboBox);
            this.insertEditPanel.Controls.Add(this.outputDateDateTimePicker);
            this.insertEditPanel.Controls.Add(this.label16);
            this.insertEditPanel.Controls.Add(this.label4);
            this.insertEditPanel.Controls.Add(this.jerkinPriceNumericUpDown);
            this.insertEditPanel.Controls.Add(this.sugarPriceNumericUpDown);
            this.insertEditPanel.Controls.Add(this.totalPriceNumericUpDown);
            this.insertEditPanel.Controls.Add(this.kiloPriceNumericUpDown);
            this.insertEditPanel.Controls.Add(this.N_CagesInLitersNumericUpDown);
            this.insertEditPanel.Controls.Add(this.N_KilosNumericUpDown);
            this.insertEditPanel.Controls.Add(this.label15);
            this.insertEditPanel.Controls.Add(this.label12);
            this.insertEditPanel.Controls.Add(this.label5);
            this.insertEditPanel.Controls.Add(this.label8);
            this.insertEditPanel.Controls.Add(this.label18);
            this.insertEditPanel.Controls.Add(this.label13);
            this.insertEditPanel.Controls.Add(this.label25);
            this.insertEditPanel.Controls.Add(this.label6);
            this.insertEditPanel.Controls.Add(this.label9);
            this.insertEditPanel.Controls.Add(this.label7);
            this.insertEditPanel.Controls.Add(this.label14);
            this.insertEditPanel.Controls.Add(this.label17);
            this.insertEditPanel.Controls.Add(this.label1);
            this.insertEditPanel.Size = new System.Drawing.Size(520, 410);
            this.insertEditPanel.TabIndex = 0;
            this.insertEditPanel.Controls.SetChildIndex(this.insertUpdateLabel, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label1, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label17, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label14, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label7, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label9, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label6, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label25, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label13, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label18, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label8, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label5, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label12, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label15, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.N_KilosNumericUpDown, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.N_CagesInLitersNumericUpDown, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.kiloPriceNumericUpDown, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.totalPriceNumericUpDown, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.sugarPriceNumericUpDown, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.jerkinPriceNumericUpDown, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label4, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.label16, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.outputDateDateTimePicker, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.rawkindsComboBox, 0);
            this.insertEditPanel.Controls.SetChildIndex(this.salesKindNameComboBox, 0);
            // 
            // parentBindingSource
            // 
            this.parentBindingSource.DataMember = "التصنيع";
            this.parentBindingSource.Filter = "";
            this.parentBindingSource.Position = -1;
            // 
            // outputDateDateTimePicker
            // 
            this.outputDateDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.parentBindingSource, "التاريخ", true));
            this.outputDateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.outputDateDateTimePicker.Location = new System.Drawing.Point(223, 118);
            this.outputDateDateTimePicker.Name = "outputDateDateTimePicker";
            this.outputDateDateTimePicker.RightToLeftLayout = true;
            this.outputDateDateTimePicker.Size = new System.Drawing.Size(147, 25);
            this.outputDateDateTimePicker.TabIndex = 2;
            this.outputDateDateTimePicker.Tag = "bind";
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(401, 123);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(96, 18);
            this.label25.TabIndex = 13;
            this.label25.Text = "تاريخ التصنيع :";
            // 
            // أنواعالبيعbindingSource
            // 
            this.أنواعالبيعbindingSource.DataMember = "أنواع البيع";
            this.أنواعالبيعbindingSource.DataSource = this.MainDataSet;
            // 
            // اسم_الخامBindingSource
            // 
            this.اسم_الخامBindingSource.DataMember = "الأنواع الخام";
            this.اسم_الخامBindingSource.DataSource = this.MainDataSet;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(399, 237);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 18);
            this.label7.TabIndex = 19;
            this.label7.Text = "قيمة الجراكن :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(184, 237);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 18);
            this.label8.TabIndex = 11;
            this.label8.Text = "جنيه";
            // 
            // jerkinPriceNumericUpDown
            // 
            this.jerkinPriceNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jerkinPriceNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.parentBindingSource, "قيمة الجراكن", true));
            this.jerkinPriceNumericUpDown.DecimalPlaces = 1;
            this.jerkinPriceNumericUpDown.Location = new System.Drawing.Point(272, 235);
            this.jerkinPriceNumericUpDown.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.jerkinPriceNumericUpDown.Name = "jerkinPriceNumericUpDown";
            this.jerkinPriceNumericUpDown.Size = new System.Drawing.Size(98, 25);
            this.jerkinPriceNumericUpDown.TabIndex = 5;
            this.jerkinPriceNumericUpDown.Tag = "bind";
            this.jerkinPriceNumericUpDown.ThousandsSeparator = true;
            // 
            // أنواع_البيعTableAdapter
            // 
            this.أنواع_البيعTableAdapter.ClearBeforeFill = true;
            // 
            // sugarPriceNumericUpDown
            // 
            this.sugarPriceNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sugarPriceNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.parentBindingSource, "قيمة السكر", true));
            this.sugarPriceNumericUpDown.DecimalPlaces = 1;
            this.sugarPriceNumericUpDown.Location = new System.Drawing.Point(272, 159);
            this.sugarPriceNumericUpDown.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.sugarPriceNumericUpDown.Name = "sugarPriceNumericUpDown";
            this.sugarPriceNumericUpDown.Size = new System.Drawing.Size(98, 25);
            this.sugarPriceNumericUpDown.TabIndex = 3;
            this.sugarPriceNumericUpDown.Tag = "bind";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(413, 199);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 18);
            this.label9.TabIndex = 19;
            this.label9.Text = "سعر الكيلو :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(184, 199);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 18);
            this.label12.TabIndex = 6;
            this.label12.Text = "جنيه";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(407, 85);
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
            this.label13.Location = new System.Drawing.Point(189, 85);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 18);
            this.label13.TabIndex = 11;
            this.label13.Text = "كيلو";
            // 
            // N_KilosNumericUpDown
            // 
            this.N_KilosNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.N_KilosNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.parentBindingSource, "كمية الخام", true));
            this.N_KilosNumericUpDown.Location = new System.Drawing.Point(272, 83);
            this.N_KilosNumericUpDown.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.N_KilosNumericUpDown.Name = "N_KilosNumericUpDown";
            this.N_KilosNumericUpDown.Size = new System.Drawing.Size(98, 25);
            this.N_KilosNumericUpDown.TabIndex = 1;
            this.N_KilosNumericUpDown.Tag = "bind";
            this.N_KilosNumericUpDown.ThousandsSeparator = true;
            this.N_KilosNumericUpDown.ValueChanged += new System.EventHandler(this.KiloPriceNumericUpDownValueChanged);
            // 
            // kiloPriceNumericUpDown
            // 
            this.kiloPriceNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kiloPriceNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.parentBindingSource, "سعر الكيلو", true));
            this.kiloPriceNumericUpDown.DecimalPlaces = 1;
            this.kiloPriceNumericUpDown.Location = new System.Drawing.Point(272, 197);
            this.kiloPriceNumericUpDown.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.kiloPriceNumericUpDown.Name = "kiloPriceNumericUpDown";
            this.kiloPriceNumericUpDown.Size = new System.Drawing.Size(98, 25);
            this.kiloPriceNumericUpDown.TabIndex = 4;
            this.kiloPriceNumericUpDown.Tag = "bind";
            this.kiloPriceNumericUpDown.ThousandsSeparator = true;
            this.kiloPriceNumericUpDown.ValueChanged += new System.EventHandler(this.KiloPriceNumericUpDownValueChanged);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(412, 161);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 18);
            this.label14.TabIndex = 19;
            this.label14.Text = "قيمة السكر:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(414, 47);
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
            this.rawkindsComboBox.Location = new System.Drawing.Point(223, 43);
            this.rawkindsComboBox.Name = "rawkindsComboBox";
            this.rawkindsComboBox.Size = new System.Drawing.Size(147, 26);
            this.rawkindsComboBox.TabIndex = 0;
            this.rawkindsComboBox.Tag = "bind";
            this.rawkindsComboBox.ValueMember = "معرف";
            // 
            // الأنواع_الخامTableAdapter
            // 
            this.الأنواع_الخامTableAdapter.ClearBeforeFill = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 161);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "جنيه";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(374, 275);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 18);
            this.label6.TabIndex = 19;
            this.label6.Text = "سعر الخام الكلي :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(184, 275);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 18);
            this.label15.TabIndex = 6;
            this.label15.Text = "جنيه";
            // 
            // totalPriceNumericUpDown
            // 
            this.totalPriceNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPriceNumericUpDown.DecimalPlaces = 1;
            this.totalPriceNumericUpDown.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.totalPriceNumericUpDown.Location = new System.Drawing.Point(272, 273);
            this.totalPriceNumericUpDown.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.totalPriceNumericUpDown.Name = "totalPriceNumericUpDown";
            this.totalPriceNumericUpDown.ReadOnly = true;
            this.totalPriceNumericUpDown.Size = new System.Drawing.Size(98, 25);
            this.totalPriceNumericUpDown.TabIndex = 4;
            this.totalPriceNumericUpDown.TabStop = false;
            this.totalPriceNumericUpDown.Tag = "";
            this.totalPriceNumericUpDown.ThousandsSeparator = true;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(406, 313);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(91, 18);
            this.label16.TabIndex = 18;
            this.label16.Text = "اسم العصير :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // salesKindNameComboBox
            // 
            this.salesKindNameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.salesKindNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.parentBindingSource, "اسم العصير", true));
            this.salesKindNameComboBox.DataSource = this.أنواعالبيعbindingSource;
            this.salesKindNameComboBox.DisplayMember = "الاسم";
            this.salesKindNameComboBox.Location = new System.Drawing.Point(223, 310);
            this.salesKindNameComboBox.Name = "salesKindNameComboBox";
            this.salesKindNameComboBox.Size = new System.Drawing.Size(147, 26);
            this.salesKindNameComboBox.TabIndex = 6;
            this.salesKindNameComboBox.Tag = "bind";
            this.salesKindNameComboBox.ValueMember = "معرف";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(440, 351);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 18);
            this.label17.TabIndex = 19;
            this.label17.Text = "الكمية :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(198, 351);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 18);
            this.label18.TabIndex = 11;
            this.label18.Text = "لتر";
            // 
            // N_CagesInLitersNumericUpDown
            // 
            this.N_CagesInLitersNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.N_CagesInLitersNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.parentBindingSource, "الكمية باللتر", true));
            this.N_CagesInLitersNumericUpDown.Location = new System.Drawing.Point(272, 349);
            this.N_CagesInLitersNumericUpDown.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.N_CagesInLitersNumericUpDown.Name = "N_CagesInLitersNumericUpDown";
            this.N_CagesInLitersNumericUpDown.Size = new System.Drawing.Size(98, 25);
            this.N_CagesInLitersNumericUpDown.TabIndex = 7;
            this.N_CagesInLitersNumericUpDown.Tag = "bind";
            this.N_CagesInLitersNumericUpDown.ThousandsSeparator = true;
            this.N_CagesInLitersNumericUpDown.ValueChanged += new System.EventHandler(this.KiloPriceNumericUpDownValueChanged);
            // 
            // التصنيعTableAdapter
            // 
            this.التصنيعTableAdapter.ClearBeforeFill = true;
            // 
            // مسلسلDataGridViewTextBoxColumn
            // 
            this.مسلسلDataGridViewTextBoxColumn.DataPropertyName = "مسلسل";
            this.مسلسلDataGridViewTextBoxColumn.HeaderText = "مسلسل";
            this.مسلسلDataGridViewTextBoxColumn.Name = "مسلسلDataGridViewTextBoxColumn";
            this.مسلسلDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // اسمالخامDataGridViewTextBoxColumn
            // 
            this.اسمالخامDataGridViewTextBoxColumn.DataPropertyName = "اسم الخام";
            this.اسمالخامDataGridViewTextBoxColumn.HeaderText = "اسم الخام";
            this.اسمالخامDataGridViewTextBoxColumn.Name = "اسمالخامDataGridViewTextBoxColumn";
            this.اسمالخامDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // كميةالخامDataGridViewTextBoxColumn
            // 
            this.كميةالخامDataGridViewTextBoxColumn.DataPropertyName = "كمية الخام";
            this.كميةالخامDataGridViewTextBoxColumn.HeaderText = "وزن الخام";
            this.كميةالخامDataGridViewTextBoxColumn.Name = "كميةالخامDataGridViewTextBoxColumn";
            this.كميةالخامDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // سعرالكيلوDataGridViewTextBoxColumn
            // 
            this.سعرالكيلوDataGridViewTextBoxColumn.DataPropertyName = "سعر الكيلو";
            this.سعرالكيلوDataGridViewTextBoxColumn.HeaderText = "سعر الكيلو";
            this.سعرالكيلوDataGridViewTextBoxColumn.Name = "سعرالكيلوDataGridViewTextBoxColumn";
            this.سعرالكيلوDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // قيمةالسكرDataGridViewTextBoxColumn
            // 
            this.قيمةالسكرDataGridViewTextBoxColumn.DataPropertyName = "قيمة السكر";
            this.قيمةالسكرDataGridViewTextBoxColumn.HeaderText = "قيمة السكر";
            this.قيمةالسكرDataGridViewTextBoxColumn.Name = "قيمةالسكرDataGridViewTextBoxColumn";
            this.قيمةالسكرDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // قيمةالجراكنDataGridViewTextBoxColumn
            // 
            this.قيمةالجراكنDataGridViewTextBoxColumn.DataPropertyName = "قيمة الجراكن";
            this.قيمةالجراكنDataGridViewTextBoxColumn.HeaderText = "قيمة الجراكن";
            this.قيمةالجراكنDataGridViewTextBoxColumn.Name = "قيمةالجراكنDataGridViewTextBoxColumn";
            this.قيمةالجراكنDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // التاريخDataGridViewTextBoxColumn
            // 
            this.التاريخDataGridViewTextBoxColumn.DataPropertyName = "التاريخ";
            this.التاريخDataGridViewTextBoxColumn.HeaderText = "التاريخ";
            this.التاريخDataGridViewTextBoxColumn.Name = "التاريخDataGridViewTextBoxColumn";
            this.التاريخDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // الكميةباللترDataGridViewTextBoxColumn
            // 
            this.الكميةباللترDataGridViewTextBoxColumn.DataPropertyName = "الكمية باللتر";
            this.الكميةباللترDataGridViewTextBoxColumn.HeaderText = "الكمية باللتر";
            this.الكميةباللترDataGridViewTextBoxColumn.Name = "الكميةباللترDataGridViewTextBoxColumn";
            this.الكميةباللترDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // اسمالعصيرDataGridViewTextBoxColumn
            // 
            this.اسمالعصيرDataGridViewTextBoxColumn.DataPropertyName = "اسم العصير";
            this.اسمالعصيرDataGridViewTextBoxColumn.HeaderText = "اسم العصير";
            this.اسمالعصيرDataGridViewTextBoxColumn.Name = "اسمالعصيرDataGridViewTextBoxColumn";
            this.اسمالعصيرDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ManufacturingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.مسلسلDataGridViewTextBoxColumn,
            this.اسمالخامDataGridViewTextBoxColumn,
            this.كميةالخامDataGridViewTextBoxColumn,
            this.سعرالكيلوDataGridViewTextBoxColumn,
            this.قيمةالسكرDataGridViewTextBoxColumn,
            this.قيمةالجراكنDataGridViewTextBoxColumn,
            this.الكميةباللترDataGridViewTextBoxColumn,
            this.اسمالعصيرDataGridViewTextBoxColumn,
            this.التاريخDataGridViewTextBoxColumn});
            this.Name = "ManufacturingsControl";
            this.DeleteRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.Manufacturing_DeleteRow);
            this.LoadByTimeRange += new System.EventHandler(this.Manufacturing_LoadByTimeRange);
            this.LoadByPeriod += new System.EventHandler(this.Manufacturing_LoadByPeriod);
            this.LoadAll += new System.EventHandler(this.Manufacturing_LoadAll);
            this.ClearData += new System.EventHandler(this.Manufacturing_ClearData);
            this.AddNewItem += new System.EventHandler(this.Manufacturing_AddNewItem);
            this.RefreshingData += new System.EventHandler(this.Manufacturing_RefreshingData);
            this.UpdateItem += new System.EventHandler(this.Manufacturing_UpdateItem);
            ((System.ComponentModel.ISupportInitialize)(this.MainDataSet)).EndInit();
            this.insertEditPanel.ResumeLayout(false);
            this.insertEditPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.أنواعالبيعbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.اسم_الخامBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jerkinPriceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sugarPriceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.N_KilosNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kiloPriceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalPriceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.N_CagesInLitersNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }





        #endregion

        private System.Windows.Forms.DateTimePicker outputDateDateTimePicker;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown jerkinPriceNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource اسم_الخامBindingSource;
        private أنواع_البيعTableAdapter أنواع_البيعTableAdapter;

        private NumericUpDown sugarPriceNumericUpDown;
        private Label label12;
        private Label label9;
        private Label label13;
        private Label label1;
        private NumericUpDown kiloPriceNumericUpDown;
        private NumericUpDown N_KilosNumericUpDown;
        private Label label14;
        private BindingSource أنواعالبيعbindingSource;
        private ComboBox rawkindsComboBox;
        private Label label4;
        private الأنواع_الخامTableAdapter الأنواع_الخامTableAdapter;
        private Label label5;
        private NumericUpDown totalPriceNumericUpDown;
        private Label label15;
        private Label label6;
        private ComboBox salesKindNameComboBox;
        private Label label16;
        private NumericUpDown N_CagesInLitersNumericUpDown;
        private Label label18;
        private Label label17;
        
        private التصنيعTableAdapter التصنيعTableAdapter;
      
        private DataGridViewTextBoxColumn مسلسلDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn اسمالخامDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn كميةالخامDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn سعرالكيلوDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn قيمةالسكرDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn قيمةالجراكنDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn التاريخDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn الكميةباللترDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn اسمالعصيرDataGridViewTextBoxColumn;






    }
}