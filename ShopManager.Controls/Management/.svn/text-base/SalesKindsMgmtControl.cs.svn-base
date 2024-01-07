#region using directives

using System;
using System.Windows.Forms;
using ShopManager.Controls.Basic;
using ShopManager.Controls.Data;

#endregion

namespace ShopManager.Controls.Management
{
    // ReSharper disable UnusedMember.Global
    public partial class SalesKindsMgmtControl : ParentControl
        // ReSharper restore UnusedMember.Global
    {
        public SalesKindsMgmtControl()
            : this(null)
        {
        }

        public SalesKindsMgmtControl(ShopDataSet ds)
            : base(ds)
        {
            InitializeComponent();
            DeleteDataAll += MgmtControl_DeleteDataAll;
        }

        void MgmtControl_DeleteDataAll(object sender, EventArgs e)
        {
            أنواع_البيعTableAdapter.DeleteAll();

        }
        private void SalesKinds_LoadAll(object sender, EventArgs e)
        {
            أنواع_البيعTableAdapter.Fill(MainDataSet.أنواع_البيع);
        }

        private void SalesKinds_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            أنواع_البيعTableAdapter.Update(MainDataSet.أنواع_البيع);
        }
    }
}