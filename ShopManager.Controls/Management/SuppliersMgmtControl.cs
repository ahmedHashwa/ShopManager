#region using directives

using System;
using System.Windows.Forms;
using ShopManager.Controls.Basic;
using ShopManager.Controls.Data;

#endregion

namespace ShopManager.Controls.Management
{
    // ReSharper disable UnusedMember.Global
    public partial class SuppliersMgmtControl : ParentControl
        // ReSharper restore UnusedMember.Global
    {
        public SuppliersMgmtControl()
            : this(null)
        {
        }

        public SuppliersMgmtControl(ShopDataSet ds)
            : base(ds)
        {
            InitializeComponent();
            DeleteDataAll += MgmtControl_DeleteDataAll;
        }

        void MgmtControl_DeleteDataAll(object sender, EventArgs e)
        {
          الموردينTableAdapter.DeleteAll();

        }

        private void SuppliersMgmtUserControl_LoadAll(object sender, EventArgs e)
        {
            الموردينTableAdapter.Fill(MainDataSet.الموردين);
        }

        private void SuppliersMgmtUserControl_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            الموردينTableAdapter.Update(MainDataSet.الموردين);
        }
    }
}