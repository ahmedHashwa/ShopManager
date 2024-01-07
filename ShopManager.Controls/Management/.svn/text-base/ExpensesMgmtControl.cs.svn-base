#region using directives

using System;
using System.Windows.Forms;
using ShopManager.Controls.Basic;
using ShopManager.Controls.Data;

#endregion

namespace ShopManager.Controls.Management
{
    // ReSharper disable UnusedMember.Global
    public partial class ExpensesMgmtControl : ParentControl
        // ReSharper restore UnusedMember.Global
    {
        public ExpensesMgmtControl()
            : this(null)
        {
        }

        public ExpensesMgmtControl(ShopDataSet ds)
            : base(ds)
        {
            InitializeComponent();
            DeleteDataAll += MgmtControl_DeleteDataAll;
        }

        void MgmtControl_DeleteDataAll(object sender, EventArgs e)
        {
            أنواع_الصرفTableAdapter.DeleteAll();

        }

        private void ExpensesMgmtControl_LoadAll(object sender, EventArgs e)
        {
            أنواع_الصرفTableAdapter.Fill(MainDataSet.أنواع_الصرف);
        }

        private void ExpensesMgmtControl_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            أنواع_الصرفTableAdapter.Update(MainDataSet.أنواع_الصرف);
        }
    }
}