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
    public partial class ClientsMgmtControl : ParentControl
    // ReSharper restore UnusedMember.Global
    {
        /// <summary>
        /// </summary>
        public ClientsMgmtControl()
            : this(null)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name = "ds"></param>
        public ClientsMgmtControl(ShopDataSet ds)
            : base(ds)
        {
            InitializeComponent();
            DeleteDataAll += MgmtControl_DeleteDataAll;
        }

        void MgmtControl_DeleteDataAll(object sender, EventArgs e)
        {
            العملاءTableAdapter.DeleteAll();

        }

        private void ClientsMgmtControl_LoadAll(object sender, EventArgs e)
        {
            العملاءTableAdapter.Fill(MainDataSet.العملاء);
        }

        private void ClientsMgmtControl_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            العملاءTableAdapter.Update(MainDataSet.العملاء);
        }
    }
}