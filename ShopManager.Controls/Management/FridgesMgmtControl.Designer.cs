
using ShopManager.Controls.Data.ShopDataSetTableAdapters;

namespace ShopManager.Controls.Management
{
    partial class FridgesMgmtControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.الثلاجاتTableAdapter = new الثلاجاتTableAdapter();
            this.معرفDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn ();
            this.الاسمDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn ();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataSet)).BeginInit ();
            ((System.ComponentModel.ISupportInitialize)(this.parentBindingSource)).BeginInit ();
            this.SuspendLayout ();
            // 
            // insertEditPanel
            // 
            this.insertEditPanel.Size = new System.Drawing.Size (520, 320);
            // 
            // parentBindingSource
            // 
            this.parentBindingSource.DataMember = "الثلاجات";
            this.parentBindingSource.Filter = "";
            this.parentBindingSource.Position = -1;
            // 
            // العملاءTableAdapter
            // 
            this.الثلاجاتTableAdapter.ClearBeforeFill = false;
            // 
            // معرفDataGridViewTextBoxColumn
            // 
            this.معرفDataGridViewTextBoxColumn.DataPropertyName = "معرف";
            this.معرفDataGridViewTextBoxColumn.HeaderText = "معرف";
            this.معرفDataGridViewTextBoxColumn.Name = "معرفDataGridViewTextBoxColumn";
            this.معرفDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // الاسمDataGridViewTextBoxColumn
            // 
            this.الاسمDataGridViewTextBoxColumn.DataPropertyName = "الاسم";
            this.الاسمDataGridViewTextBoxColumn.HeaderText = "الاسم";
            this.الاسمDataGridViewTextBoxColumn.Name = "الاسمDataGridViewTextBoxColumn";

            // 
            // FridgeMgmtControl
            // 
            this.AllowDirectAdd = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF (8F, 18F);
            this.Columns.AddRange (new System.Windows.Forms.DataGridViewColumn[] {
                                                                                     this.معرفDataGridViewTextBoxColumn,
                                                                                     this.الاسمDataGridViewTextBoxColumn});
            this.ConfirmationMessage = "هل أنت متأكد من حذف هذا السجل؟\r\nحذف أي بيان يلغي جميع البيانات المتعلقة به";
            this.FilterCollapsed = true;
            this.InsertEditCollapsed = true;
            this.Name = "FridgeMgmtControl";
            this.ReadOnly = false;
            this.RefreshingData += new System.EventHandler (this.FridgesMgmtControl_LoadAll);
            this.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler (this.FridgesMgmtControl_RowLeave);
            this.LoadAll += new System.EventHandler (this.FridgesMgmtControl_LoadAll);
            ((System.ComponentModel.ISupportInitialize)(this.MainDataSet)).EndInit ();
            ((System.ComponentModel.ISupportInitialize)(this.parentBindingSource)).EndInit ();
            this.ResumeLayout (false);

        }



        #endregion

        private الثلاجاتTableAdapter الثلاجاتTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn معرفDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn الاسمDataGridViewTextBoxColumn;
    }
}