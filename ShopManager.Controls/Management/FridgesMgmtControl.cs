#region using directives

using System;
using System.Windows.Forms;
using ShopManager.Controls.Basic;
using ShopManager.Controls.Data;

#endregion

namespace ShopManager.Controls.Management
{
    // ReSharper disable UnusedMember.Global
    /// <summary>
    /// </summary>
    public partial class FridgesMgmtControl : ParentControl
        // ReSharper restore UnusedMember.Global
    {
        /// <summary>
        /// </summary>
        public FridgesMgmtControl()
            : this(null)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name = "ds"></param>
        public FridgesMgmtControl(ShopDataSet ds)
            : base(ds)
        {
            InitializeComponent();
            DeleteDataAll += MgmtControl_DeleteDataAll;
        }

        void MgmtControl_DeleteDataAll(object sender, EventArgs e)
        {
            الثلاجاتTableAdapter.DeleteAll();

        }

        private void FridgesMgmtControl_LoadAll(object sender, EventArgs e)
        {
            الثلاجاتTableAdapter.Fill(MainDataSet.الثلاجات);
        }

        private void FridgesMgmtControl_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            الثلاجاتTableAdapter.Update(MainDataSet.الثلاجات);
        }
    }
}