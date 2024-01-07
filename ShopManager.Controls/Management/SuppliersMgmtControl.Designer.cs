using ShopManager.Controls.Data.ShopDataSetTableAdapters;

namespace ShopManager.Controls.Management
{
    partial class SuppliersMgmtControl
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
            this.الموردينTableAdapter = new الموردينTableAdapter ();
            this.معرفDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn ();
            this.الاسمDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn ();
            this.رصيدأولالمدةDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn ();
            ((System.ComponentModel.ISupportInitialize)(MainDataSet)).BeginInit ();
            this.insertEditPanel.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize)(this.parentBindingSource)).BeginInit ();
            this.SuspendLayout ();
            // 
            // insertEditPanel
            // 
            this.insertEditPanel.Size = new System.Drawing.Size (520, 284);
            // 
            // parentBindingSource
            // 
            this.parentBindingSource.DataMember = "الموردين";
            this.parentBindingSource.Filter = "";
            this.parentBindingSource.Position = -1;
            // 
            // الموردينTableAdapter
            // 
            this.الموردينTableAdapter.ClearBeforeFill = false;
            // 
            // معرفDataGridViewTextBoxColumn
            // 
            this.معرفDataGridViewTextBoxColumn.DataPropertyName = "معرف";
            this.معرفDataGridViewTextBoxColumn.HeaderText = "مسلسل";
            this.معرفDataGridViewTextBoxColumn.Name = "معرفDataGridViewTextBoxColumn";
            this.معرفDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // الاسمDataGridViewTextBoxColumn
            // 
            this.الاسمDataGridViewTextBoxColumn.DataPropertyName = "الاسم";
            this.الاسمDataGridViewTextBoxColumn.HeaderText = "الاسم";
            this.الاسمDataGridViewTextBoxColumn.Name = "الاسمDataGridViewTextBoxColumn";
            // 
            // رصيدأولالمدةDataGridViewTextBoxColumn
            // 
            this.رصيدأولالمدةDataGridViewTextBoxColumn.DataPropertyName = "رصيد أول المدة";
            this.رصيدأولالمدةDataGridViewTextBoxColumn.HeaderText = "رصيد أول المدة";
            this.رصيدأولالمدةDataGridViewTextBoxColumn.Name = "رصيدأولالمدةDataGridViewTextBoxColumn";
            this.رصيدأولالمدةDataGridViewTextBoxColumn.Width = 150;
            // 
            // 
            // SuppliersMgmtControl
            // 
            this.AllowDirectAdd = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF (8F, 18F);
            this.Columns.AddRange (new System.Windows.Forms.DataGridViewColumn[] {
                                                                                     this.معرفDataGridViewTextBoxColumn,
                                                                                     this.الاسمDataGridViewTextBoxColumn,
                                                                                     this.رصيدأولالمدةDataGridViewTextBoxColumn});
            this.FilterCollapsed = true;
            this.InsertEditCollapsed = true;
            this.ItemChanged = false;
            this.Name = "SuppliersMgmtControl";
            this.ReadOnly = false;
            this.RefreshingData += new System.EventHandler (this.SuppliersMgmtUserControl_LoadAll);
            this.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler (this.SuppliersMgmtUserControl_RowLeave);
            this.LoadAll += new System.EventHandler (this.SuppliersMgmtUserControl_LoadAll);
            ((System.ComponentModel.ISupportInitialize)(MainDataSet)).EndInit ();
            this.insertEditPanel.ResumeLayout (false);
            this.insertEditPanel.PerformLayout ();
            ((System.ComponentModel.ISupportInitialize)(this.parentBindingSource)).EndInit ();
            this.ResumeLayout (false);

        }

        #endregion

        private الموردينTableAdapter الموردينTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn معرفDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn الاسمDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn رصيدأولالمدةDataGridViewTextBoxColumn;
    }
}