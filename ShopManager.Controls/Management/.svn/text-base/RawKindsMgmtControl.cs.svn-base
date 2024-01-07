#region using directives

using System;
using System.Windows.Forms;
using ShopManager.Controls.Basic;
using ShopManager.Controls.Data;

#endregion

namespace ShopManager.Controls.Management
{
    // ReSharper disable UnusedMember.Global
    public partial class RawKindsMgmtControl : ParentControl
        // ReSharper restore UnusedMember.Global
    {
        public RawKindsMgmtControl()
            : this(null)
        {
        }

        public RawKindsMgmtControl(ShopDataSet ds)
            : base(ds)
        {
            InitializeComponent();
            DeleteDataAll += MgmtControl_DeleteDataAll;
        }

        void MgmtControl_DeleteDataAll(object sender, EventArgs e)
        {
            الأنواع_الخامTableAdapter.DeleteAll();

        }
        private void RawKindsMgmtControl_LoadAll(object sender, EventArgs e)
        {
            الأنواع_الخامTableAdapter.Fill(MainDataSet.الأنواع_الخام);
        }

        private void RawKindsMgmtControl_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            الأنواع_الخامTableAdapter.Update(MainDataSet.الأنواع_الخام);
        }
    }
}