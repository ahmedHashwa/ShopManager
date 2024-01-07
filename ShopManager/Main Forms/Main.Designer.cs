﻿
namespace ShopManager
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("1. المشتريات");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("2. المبيعات");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("3. المصروفات");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("4. تخزين الثلاجة");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("5. صرف ");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("6. التصنيع");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("7. التقارير");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("1- رئيسي", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("1. إدارة الموردين");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("2. إدارة العملاء");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("3. إدارة أنواع المصروفات");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("4. إدارة المواد الخام");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("5. إدارة أنواع البيع");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("6. إدارة أنواع البيع الفرعية");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("7. إدارة الثلاجات");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("2- الإدارات", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15});
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.DateTimeLabel = new System.Windows.Forms.Label();
            this.mainTreeView = new System.Windows.Forms.TreeView();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mgmtPanel = new System.Windows.Forms.Panel();
            this.noticeLabel = new System.Windows.Forms.Label();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.passwordGroupBox = new System.Windows.Forms.GroupBox();
            this.passErrorLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.rowNumberToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.manageToolsToolStrip = new System.Windows.Forms.ToolStrip();
            this.toggleShowNavToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.executetoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.clearToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.refreshDBToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toggleViewToolStripButton = new System.Windows.Forms.ToolStripSplitButton();
            this.toggleShowFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleInsertEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleShowDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleShowReportSelectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.manageToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.logoutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.optionsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.sendErrorReportEmailToolStripButton = new System.Windows.Forms.ToolStripSplitButton();
            this.إرسالالملفعنطريقالنتToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.حفظملفالأخطاءإلىToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.عرضالملفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgrammeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.sendReportBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.ShopDataSet = new ShopManager.Controls.Data.ShopDataSet();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.mainTableLayoutPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.mgmtPanel.SuspendLayout();
            this.loginPanel.SuspendLayout();
            this.passwordGroupBox.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.manageToolsToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShopDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.mainSplitContainer.Margin = new System.Windows.Forms.Padding(4);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.label2);
            this.mainSplitContainer.Panel1.Controls.Add(this.DateTimeLabel);
            this.mainSplitContainer.Panel1.Controls.Add(this.mainTreeView);
            this.mainSplitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.mainTableLayoutPanel);
            this.mainSplitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mainSplitContainer.Size = new System.Drawing.Size(734, 639);
            this.mainSplitContainer.SplitterDistance = 205;
            this.mainSplitContainer.SplitterWidth = 5;
            this.mainSplitContainer.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(3, 576);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 54);
            this.label2.TabIndex = 3;
            this.label2.Text = "لمشاهدة إختصارات\r\n لوحة المفاتيح \r\nاضغط Shift + F1";
            this.label2.Click += new System.EventHandler(this.HelpToolStripButtonClick);
            // 
            // DateTimeLabel
            // 
            this.DateTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimeLabel.Location = new System.Drawing.Point(3, 465);
            this.DateTimeLabel.Name = "DateTimeLabel";
            this.DateTimeLabel.Size = new System.Drawing.Size(199, 96);
            this.DateTimeLabel.TabIndex = 2;
            this.DateTimeLabel.Text = "الوقت\\التاريخ";
            // 
            // mainTreeView
            // 
            this.mainTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTreeView.HideSelection = false;
            this.mainTreeView.ImageIndex = 0;
            this.mainTreeView.ImageList = this.imageList;
            this.mainTreeView.Location = new System.Drawing.Point(0, 0);
            this.mainTreeView.Margin = new System.Windows.Forms.Padding(4);
            this.mainTreeView.Name = "mainTreeView";
            treeNode1.ImageKey = "buying.ico";
            treeNode1.Name = "Regular.PurchasesControl";
            treeNode1.SelectedImageKey = "buying.ico";
            treeNode1.Text = "1. المشتريات";
            treeNode2.ImageKey = "selling.ico";
            treeNode2.Name = "Regular.SalesControl";
            treeNode2.SelectedImageKey = "selling.ico";
            treeNode2.Text = "2. المبيعات";
            treeNode3.ImageKey = "expenses.ico";
            treeNode3.Name = "Regular.ExpensesControl";
            treeNode3.SelectedImageKey = "expenses.ico";
            treeNode3.Text = "3. المصروفات";
            treeNode4.ImageKey = "todaysales.ico";
            treeNode4.Name = "Regular.FridgeStoragesControl";
            treeNode4.SelectedImageKey = "todaysales.ico";
            treeNode4.Text = "4. تخزين الثلاجة";
            treeNode5.ImageKey = "mgmt.ico";
            treeNode5.Name = "Regular.FridgeOutsControl";
            treeNode5.SelectedImageKey = "mgmt.ico";
            treeNode5.Text = "5. صرف ";
            treeNode6.ImageKey = "mgmt.ico";
            treeNode6.Name = "Regular.ManufacturingsControl";
            treeNode6.SelectedImageKey = "mgmt.ico";
            treeNode6.Text = "6. التصنيع";
            treeNode7.ImageKey = "reports.ico";
            treeNode7.Name = "ReportViewerControl";
            treeNode7.SelectedImageKey = "reports.ico";
            treeNode7.Text = "7. التقارير";
            treeNode8.ImageKey = "home.png";
            treeNode8.Name = "main";
            treeNode8.SelectedImageKey = "home.png";
            treeNode8.Text = "1- رئيسي";
            treeNode9.ImageKey = "persons.png";
            treeNode9.Name = "Management.SuppliersMgmtControl";
            treeNode9.SelectedImageKey = "persons.png";
            treeNode9.Text = "1. إدارة الموردين";
            treeNode10.ImageKey = "persons.png";
            treeNode10.Name = "Management.ClientsMgmtControl";
            treeNode10.SelectedImageKey = "persons.png";
            treeNode10.Text = "2. إدارة العملاء";
            treeNode11.ImageKey = "mgmt.ico";
            treeNode11.Name = "Management.ExpensesMgmtControl";
            treeNode11.SelectedImageKey = "mgmt.ico";
            treeNode11.Text = "3. إدارة أنواع المصروفات";
            treeNode12.ImageKey = "mgmt.ico";
            treeNode12.Name = "Management.RawKindsMgmtControl";
            treeNode12.SelectedImageKey = "mgmt.ico";
            treeNode12.Text = "4. إدارة المواد الخام";
            treeNode13.ImageKey = "mgmt.ico";
            treeNode13.Name = "Management.SalesKindsMgmtControl";
            treeNode13.SelectedImageKey = "mgmt.ico";
            treeNode13.Text = "5. إدارة أنواع البيع";
            treeNode14.ImageKey = "mgmt.ico";
            treeNode14.Name = "Management.SalesSubKindsMgmtControl";
            treeNode14.SelectedImageKey = "mgmt.ico";
            treeNode14.Text = "6. إدارة أنواع البيع الفرعية";
            treeNode15.ImageKey = "mgmt.ico";
            treeNode15.Name = "Management.FridgesMgmtControl";
            treeNode15.SelectedImageKey = "mgmt.ico";
            treeNode15.Text = "7. إدارة الثلاجات";
            treeNode16.ImageKey = "mgmt.ico";
            treeNode16.Name = "mgmtNode";
            treeNode16.SelectedImageKey = "mgmt.ico";
            treeNode16.Text = "2- الإدارات";
            this.mainTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode16});
            this.mainTreeView.RightToLeftLayout = true;
            this.mainTreeView.SelectedImageIndex = 0;
            this.mainTreeView.Size = new System.Drawing.Size(205, 461);
            this.mainTreeView.TabIndex = 0;
            this.mainTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.MainTreeViewBeforeExpand);
            this.mainTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.MainTreeViewBeforeSelect);
            this.mainTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MainTreeViewAfterSelect);
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainTableLayoutPanel.ColumnCount = 1;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Controls.Add(this.mainPanel, 0, 1);
            this.mainTableLayoutPanel.Controls.Add(this.statusStrip, 0, 2);
            this.mainTableLayoutPanel.Controls.Add(this.manageToolsToolStrip, 0, 0);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.Padding = new System.Windows.Forms.Padding(2);
            this.mainTableLayoutPanel.RowCount = 3;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(524, 639);
            this.mainTableLayoutPanel.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.mgmtPanel);
            this.mainPanel.Controls.Add(this.loginPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(6, 31);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(512, 579);
            this.mainPanel.TabIndex = 3;
            // 
            // mgmtPanel
            // 
            this.mgmtPanel.Controls.Add(this.noticeLabel);
            this.mgmtPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mgmtPanel.Location = new System.Drawing.Point(0, 0);
            this.mgmtPanel.Name = "mgmtPanel";
            this.mgmtPanel.Size = new System.Drawing.Size(512, 579);
            this.mgmtPanel.TabIndex = 0;
            // 
            // noticeLabel
            // 
            this.noticeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.noticeLabel.Location = new System.Drawing.Point(66, 257);
            this.noticeLabel.Name = "noticeLabel";
            this.noticeLabel.Size = new System.Drawing.Size(380, 64);
            this.noticeLabel.TabIndex = 1;
            this.noticeLabel.Text = "اختر القسم المناسب من القائمة الموجودة بالجانب الأيمن \r\nو إذا كانت مخفية يمكنك فت" +
                "حها عن طريق الضغط \r\nعلى الزر الموجود بأقصى اليمين في الشريط العلوي";
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.passwordGroupBox);
            this.loginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginPanel.Location = new System.Drawing.Point(0, 0);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(512, 579);
            this.loginPanel.TabIndex = 1;
            this.loginPanel.Enter += new System.EventHandler(this.LoginPanelEnter);
            // 
            // passwordGroupBox
            // 
            this.passwordGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordGroupBox.Controls.Add(this.passErrorLabel);
            this.passwordGroupBox.Controls.Add(this.loginButton);
            this.passwordGroupBox.Controls.Add(this.passwordTextBox);
            this.passwordGroupBox.Controls.Add(this.label1);
            this.passwordGroupBox.Location = new System.Drawing.Point(38, 168);
            this.passwordGroupBox.Name = "passwordGroupBox";
            this.passwordGroupBox.Size = new System.Drawing.Size(435, 262);
            this.passwordGroupBox.TabIndex = 4;
            this.passwordGroupBox.TabStop = false;
            this.passwordGroupBox.Text = "كلمة السر";
            // 
            // passErrorLabel
            // 
            this.passErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.passErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.passErrorLabel.Location = new System.Drawing.Point(122, 128);
            this.passErrorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passErrorLabel.Name = "passErrorLabel";
            this.passErrorLabel.Size = new System.Drawing.Size(187, 36);
            this.passErrorLabel.TabIndex = 0;
            this.passErrorLabel.Text = "كلمة السر غير صحيحة.\r\nمن فضلك أعد المحاولة.";
            this.passErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.passErrorLabel.Visible = false;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(21, 20);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(83, 36);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "تابع";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.LoginButtonClick);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.Location = new System.Drawing.Point(122, 26);
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(107, 25);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "من فضلك أدخل كلمة السر";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripStatusLabel,
            this.rowNumberToolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(2, 614);
            this.statusStrip.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(19, 0, 1, 0);
            this.statusStrip.Size = new System.Drawing.Size(518, 23);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusToolStripStatusLabel
            // 
            this.statusToolStripStatusLabel.Font = new System.Drawing.Font("Tahoma", 11F);
            this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
            this.statusToolStripStatusLabel.Size = new System.Drawing.Size(38, 18);
            this.statusToolStripStatusLabel.Text = "جاهز";
            // 
            // rowNumberToolStripStatusLabel
            // 
            this.rowNumberToolStripStatusLabel.Name = "rowNumberToolStripStatusLabel";
            this.rowNumberToolStripStatusLabel.Size = new System.Drawing.Size(460, 18);
            this.rowNumberToolStripStatusLabel.Spring = true;
            this.rowNumberToolStripStatusLabel.Text = "يعرض الآن 0 صف";
            this.rowNumberToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // manageToolsToolStrip
            // 
            this.manageToolsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleShowNavToolStripButton,
            this.executetoolStripButton,
            this.clearToolStripButton,
            this.deleteToolStripButton,
            this.refreshDBToolStripButton,
            this.helpToolStripButton,
            this.toolStripSeparator1,
            this.toggleViewToolStripButton,
            this.printToolStripButton,
            this.manageToolStripSeparator,
            this.logoutToolStripButton,
            this.optionsToolStripButton,
            this.sendErrorReportEmailToolStripButton,
            this.aboutProgrammeToolStripButton,
            this.deleteAllToolStripButton});
            this.manageToolsToolStrip.Location = new System.Drawing.Point(2, 2);
            this.manageToolsToolStrip.Name = "manageToolsToolStrip";
            this.manageToolsToolStrip.Size = new System.Drawing.Size(520, 25);
            this.manageToolsToolStrip.TabIndex = 5;
            this.manageToolsToolStrip.Text = "toolStrip1";
            // 
            // toggleShowNavToolStripButton
            // 
            this.toggleShowNavToolStripButton.Checked = true;
            this.toggleShowNavToolStripButton.CheckOnClick = true;
            this.toggleShowNavToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toggleShowNavToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toggleShowNavToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("toggleShowNavToolStripButton.Image")));
            this.toggleShowNavToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggleShowNavToolStripButton.Name = "toggleShowNavToolStripButton";
            this.toggleShowNavToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.toggleShowNavToolStripButton.Text = "تبديل إظهار منطقة الإبحار";
            this.toggleShowNavToolStripButton.ToolTipText = "تبديل إظهار منطقة الإبحار(F12)";
            this.toggleShowNavToolStripButton.CheckedChanged += new System.EventHandler(this.ToggleShowNavToolStripButtonCheckedChanged);
            // 
            // executetoolStripButton
            // 
            this.executetoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("executetoolStripButton.Image")));
            this.executetoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.executetoolStripButton.Name = "executetoolStripButton";
            this.executetoolStripButton.Size = new System.Drawing.Size(49, 22);
            this.executetoolStripButton.Tag = "editTools";
            this.executetoolStripButton.Text = "أد&خل";
            this.executetoolStripButton.ToolTipText = "أدخل/ عدل (Ctrl + Enter)";
            this.executetoolStripButton.Click += new System.EventHandler(this.ExecutetoolStripButtonClick);
            // 
            // clearToolStripButton
            // 
            this.clearToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("clearToolStripButton.Image")));
            this.clearToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearToolStripButton.Name = "clearToolStripButton";
            this.clearToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.clearToolStripButton.Tag = "editTools";
            this.clearToolStripButton.Text = "ا&مسح لإدخال جديد";
            this.clearToolStripButton.ToolTipText = "امسح لإدخال جديد (Shift+Esc)";
            this.clearToolStripButton.Click += new System.EventHandler(this.ClearToolStripButtonClick);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteToolStripButton.Image")));
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteToolStripButton.Tag = "editTools";
            this.deleteToolStripButton.Text = "ال&غ هذا السجل";
            this.deleteToolStripButton.ToolTipText = "الغ هذا السجل (Delete)";
            this.deleteToolStripButton.Click += new System.EventHandler(this.DeleteToolStripButtonClick);
            // 
            // refreshDBToolStripButton
            // 
            this.refreshDBToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshDBToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshDBToolStripButton.Image")));
            this.refreshDBToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshDBToolStripButton.Name = "refreshDBToolStripButton";
            this.refreshDBToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refreshDBToolStripButton.Tag = "editTools";
            this.refreshDBToolStripButton.Text = "حد&ث البيانات ";
            this.refreshDBToolStripButton.ToolTipText = "حدث البيانات (F5)";
            this.refreshDBToolStripButton.Click += new System.EventHandler(this.RefreshDbToolStripButtonClick);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Tag = "editTools";
            this.helpToolStripButton.Text = "He&lp";
            this.helpToolStripButton.ToolTipText = "أظهر اختصارات لوحة المفاتيح (Shift +F1)";
            this.helpToolStripButton.Click += new System.EventHandler(this.HelpToolStripButtonClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toggleViewToolStripButton
            // 
            this.toggleViewToolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleShowFilterToolStripMenuItem,
            this.toggleInsertEditToolStripMenuItem,
            this.toggleShowDataToolStripMenuItem,
            this.toggleShowReportSelectorToolStripMenuItem});
            this.toggleViewToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("toggleViewToolStripButton.Image")));
            this.toggleViewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toggleViewToolStripButton.Name = "toggleViewToolStripButton";
            this.toggleViewToolStripButton.Size = new System.Drawing.Size(65, 22);
            this.toggleViewToolStripButton.Tag = "";
            this.toggleViewToolStripButton.Text = "عرض";
            this.toggleViewToolStripButton.ToolTipText = "اضغط لإخفاء/إظهار منطقة الإدارة(F10)";
            this.toggleViewToolStripButton.ButtonClick += new System.EventHandler(this.ToggleViewToolStripButtonButtonClick);
            // 
            // toggleShowFilterToolStripMenuItem
            // 
            this.toggleShowFilterToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toggleShowFilterToolStripMenuItem.Name = "toggleShowFilterToolStripMenuItem";
            this.toggleShowFilterToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.toggleShowFilterToolStripMenuItem.Text = "تبديل إظهار تصفية";
            this.toggleShowFilterToolStripMenuItem.Click += new System.EventHandler(this.ToggleShowFilterToolStripMenuItemClick);
            // 
            // toggleInsertEditToolStripMenuItem
            // 
            this.toggleInsertEditToolStripMenuItem.Name = "toggleInsertEditToolStripMenuItem";
            this.toggleInsertEditToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.toggleInsertEditToolStripMenuItem.Text = "تبديل إظهار إدخال و تعديل";
            this.toggleInsertEditToolStripMenuItem.Click += new System.EventHandler(this.ToggleInsertEditToolStripMenuItemClick);
            // 
            // toggleShowDataToolStripMenuItem
            // 
            this.toggleShowDataToolStripMenuItem.Name = "toggleShowDataToolStripMenuItem";
            this.toggleShowDataToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.toggleShowDataToolStripMenuItem.Text = "تبديل إظهار البيانات";
            this.toggleShowDataToolStripMenuItem.Click += new System.EventHandler(this.ToggleShowDataToolStripMenuItemClick);
            // 
            // toggleShowReportSelectorToolStripMenuItem
            // 
            this.toggleShowReportSelectorToolStripMenuItem.Name = "toggleShowReportSelectorToolStripMenuItem";
            this.toggleShowReportSelectorToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.toggleShowReportSelectorToolStripMenuItem.Text = "تبديل إظهار اختيار التقرير";
            this.toggleShowReportSelectorToolStripMenuItem.Visible = false;
            this.toggleShowReportSelectorToolStripMenuItem.Click += new System.EventHandler(this.ToggleShowReportSelectorToolStripMenuItemClick);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Tag = "editTools";
            this.printToolStripButton.Text = "&Print";
            this.printToolStripButton.ToolTipText = "طباعة (F7)";
            this.printToolStripButton.Click += new System.EventHandler(this.PrintToolStripButtonClick);
            // 
            // manageToolStripSeparator
            // 
            this.manageToolStripSeparator.Name = "manageToolStripSeparator";
            this.manageToolStripSeparator.Size = new System.Drawing.Size(6, 25);
            this.manageToolStripSeparator.Tag = "editTools";
            // 
            // logoutToolStripButton
            // 
            this.logoutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("logoutToolStripButton.Image")));
            this.logoutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logoutToolStripButton.Name = "logoutToolStripButton";
            this.logoutToolStripButton.Size = new System.Drawing.Size(52, 22);
            this.logoutToolStripButton.Tag = "mgmtTools";
            this.logoutToolStripButton.Text = "خروج";
            this.logoutToolStripButton.ToolTipText = "خروج (Ctrl +L)";
            this.logoutToolStripButton.Visible = false;
            this.logoutToolStripButton.Click += new System.EventHandler(this.LogoutToolStripButtonClick);
            // 
            // optionsToolStripButton
            // 
            this.optionsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.optionsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("optionsToolStripButton.Image")));
            this.optionsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optionsToolStripButton.Name = "optionsToolStripButton";
            this.optionsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.optionsToolStripButton.Tag = "mgmtTools";
            this.optionsToolStripButton.Text = "خيارات";
            this.optionsToolStripButton.ToolTipText = "خيارات(F8)";
            this.optionsToolStripButton.Visible = false;
            this.optionsToolStripButton.Click += new System.EventHandler(this.OptionsToolStripButtonClick);
            // 
            // sendErrorReportEmailToolStripButton
            // 
            this.sendErrorReportEmailToolStripButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.إرسالالملفعنطريقالنتToolStripMenuItem,
            this.حفظملفالأخطاءإلىToolStripMenuItem,
            this.عرضالملفToolStripMenuItem});
            this.sendErrorReportEmailToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("sendErrorReportEmailToolStripButton.Image")));
            this.sendErrorReportEmailToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sendErrorReportEmailToolStripButton.Name = "sendErrorReportEmailToolStripButton";
            this.sendErrorReportEmailToolStripButton.Size = new System.Drawing.Size(45, 22);
            this.sendErrorReportEmailToolStripButton.Tag = "";
            this.sendErrorReportEmailToolStripButton.Text = "0";
            this.sendErrorReportEmailToolStripButton.ToolTipText = "ارسل ملف الأخطاء (F11)";
            this.sendErrorReportEmailToolStripButton.ButtonClick += new System.EventHandler(this.SendErrorReportEmailToolStripButtonClick);
            // 
            // إرسالالملفعنطريقالنتToolStripMenuItem
            // 
            this.إرسالالملفعنطريقالنتToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.إرسالالملفعنطريقالنتToolStripMenuItem.Name = "إرسالالملفعنطريقالنتToolStripMenuItem";
            this.إرسالالملفعنطريقالنتToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.إرسالالملفعنطريقالنتToolStripMenuItem.Text = "إرسال الملف عن طريق النت";
            this.إرسالالملفعنطريقالنتToolStripMenuItem.Click += new System.EventHandler(this.SendErrorReportEmailToolStripButtonClick);
            // 
            // حفظملفالأخطاءإلىToolStripMenuItem
            // 
            this.حفظملفالأخطاءإلىToolStripMenuItem.Name = "حفظملفالأخطاءإلىToolStripMenuItem";
            this.حفظملفالأخطاءإلىToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.حفظملفالأخطاءإلىToolStripMenuItem.Text = "حفظ ملف الأخطاء إلى";
            this.حفظملفالأخطاءإلىToolStripMenuItem.Click += new System.EventHandler(this.حفظملفالأخطاءإلىToolStripMenuItem_Click);
            // 
            // عرضالملفToolStripMenuItem
            // 
            this.عرضالملفToolStripMenuItem.Name = "عرضالملفToolStripMenuItem";
            this.عرضالملفToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.عرضالملفToolStripMenuItem.Text = "عرض الملف";
            this.عرضالملفToolStripMenuItem.Click += new System.EventHandler(this.عرضالملفToolStripLabel_Click);
            // 
            // aboutProgrammeToolStripButton
            // 
            this.aboutProgrammeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("aboutProgrammeToolStripButton.Image")));
            this.aboutProgrammeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutProgrammeToolStripButton.Name = "aboutProgrammeToolStripButton";
            this.aboutProgrammeToolStripButton.Size = new System.Drawing.Size(86, 22);
            this.aboutProgrammeToolStripButton.Text = "حول البرنامج";
            this.aboutProgrammeToolStripButton.ToolTipText = "حول البرنامج (F1)";
            this.aboutProgrammeToolStripButton.Click += new System.EventHandler(this.AboutProgrammeToolStripButtonClick);
            // 
            // deleteAllToolStripButton
            // 
            this.deleteAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteAllToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteAllToolStripButton.Image")));
            this.deleteAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteAllToolStripButton.Name = "deleteAllToolStripButton";
            this.deleteAllToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteAllToolStripButton.Tag = "editTools";
            this.deleteAllToolStripButton.Text = "حذف جميع البيانات من هذا الجدول";
            this.deleteAllToolStripButton.Click += new System.EventHandler(this.DeleteAllToolStripButtonClick);
            // 
            // sendReportBackgroundWorker
            // 
            this.sendReportBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SendReportBackgroundWorkerDoWork);
            this.sendReportBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SendReportBackgroundWorkerRunWorkerCompleted);
            // 
            // ShopDataSet
            // 
            this.ShopDataSet.DataSetName = "DataSet";
            this.ShopDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "reports.ico");
            this.imageList.Images.SetKeyName(1, "selling.ico");
            this.imageList.Images.SetKeyName(2, "buying.ico");
            this.imageList.Images.SetKeyName(3, "supplier.ico");
            this.imageList.Images.SetKeyName(4, "expenses.ico");
            this.imageList.Images.SetKeyName(5, "todaysales.ico");
            this.imageList.Images.SetKeyName(6, "mgmt.ico");
            this.imageList.Images.SetKeyName(7, "home.png");
            this.imageList.Images.SetKeyName(8, "persons.png");
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 639);
            this.Controls.Add(this.mainSplitContainer);
            this.Font = new System.Drawing.Font("Tahoma", 11F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(750, 671);
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "ShopManager ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            this.mainSplitContainer.ResumeLayout(false);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mgmtPanel.ResumeLayout(false);
            this.loginPanel.ResumeLayout(false);
            this.passwordGroupBox.ResumeLayout(false);
            this.passwordGroupBox.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.manageToolsToolStrip.ResumeLayout(false);
            this.manageToolsToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShopDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplitContainer;
        internal System.Windows.Forms.TreeView mainTreeView;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.ToolStrip manageToolsToolStrip;
        private System.Windows.Forms.ToolStripButton toggleShowNavToolStripButton;
        private System.Windows.Forms.ToolStripButton executetoolStripButton;
        private System.Windows.Forms.ToolStripButton clearToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshDBToolStripButton;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolStripSeparator manageToolStripSeparator;
        private System.Windows.Forms.ToolStripButton logoutToolStripButton;
        private System.Windows.Forms.ToolStripButton optionsToolStripButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.GroupBox passwordGroupBox;
        private System.Windows.Forms.Label passErrorLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel mgmtPanel;
        private System.Windows.Forms.ToolStripSplitButton toggleViewToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem toggleShowFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleInsertEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleShowDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton aboutProgrammeToolStripButton;
        private System.Windows.Forms.Label noticeLabel;
        private System.Windows.Forms.ToolStripMenuItem toggleShowReportSelectorToolStripMenuItem;
        internal Controls.Data.ShopDataSet ShopDataSet;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.Label DateTimeLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.ComponentModel.BackgroundWorker sendReportBackgroundWorker;
        private System.Windows.Forms.ToolStripSplitButton sendErrorReportEmailToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem حفظملفالأخطاءإلىToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem إرسالالملفعنطريقالنتToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem عرضالملفToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel rowNumberToolStripStatusLabel;
        internal System.Windows.Forms.ToolStripStatusLabel statusToolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton deleteAllToolStripButton;
        private System.Windows.Forms.ImageList imageList;
    }
}