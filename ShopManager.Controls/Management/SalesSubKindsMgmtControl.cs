#region using directives

using System;
using System.Windows.Forms;
using ShopManager.Controls.Basic;
using ShopManager.Controls.Data;
using ShopManager.Controls.Data.ShopDataSetTableAdapters;

#endregion

namespace ShopManager.Controls.Management
{
    // ReSharper disable UnusedMember.Global
    public partial class SalesSubKindsMgmtControl : ParentControl
    // ReSharper restore UnusedMember.Global
    {
        public SalesSubKindsMgmtControl()
            : this(null)
        {
        }

        public SalesSubKindsMgmtControl(ShopDataSet ds)
            : base(ds)
        {
            InitializeComponent();
            AllowToggleInsertEdit = true;
            AllowDirectAdd = true;
            ConfirmationMessage = "هل أنت متأكد من حذف هذا السجل؟\r\nحذف أي بيان يلغي جميع البيانات المتعلقة به";
            FilterCollapsed = true;
            InsertEditCollapsed = false;
            ReadOnly = false;
            DeleteDataAll += MgmtControl_DeleteDataAll;
        }

        void MgmtControl_DeleteDataAll(object sender, EventArgs e)
        {
            أنواع_البيعTableAdapter.DeleteAll();

        }

        private void SalesSubKindsMgmtControl_Load(object sender, EventArgs e)
        {
            sourceKindComboBox_SelectedIndexChanged(null, null);
        }

        private void SalesSubKindsMgmtControl_LoadAll(object sender, EventArgs e)
        {
            الأنواع_الفرعية_للبيعTableAdapter.Fill(MainDataSet.الأنواع_الفرعية_للبيع);
            أنواع_البيعTableAdapter.Fill(MainDataSet.أنواع_البيع);
        }

        private void SalesSubKindsMgmtControl_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            الأنواع_الفرعية_للبيعTableAdapter.Update(MainDataSet.الأنواع_الفرعية_للبيع);
        }

        private void sourceKindComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sourceSubKindBindingSource.Filter = string.Format("[{0}]='{1}'", "معرف نوع البيع",
                                                              sourceKindComboBox.SelectedValue ?? "-1");
            if (sourceKindComboBox.SelectedValue == null || sourceSubKindComboBox.SelectedValue == null) return;
            int? output = new مفردات_البيعTableAdapter().KindSubCount(
                (short)sourceKindComboBox.SelectedValue, (short)sourceSubKindComboBox.SelectedValue);
            itemUsageLabel.Text = string.Format("يوجد {0} استخدامات لهذا العنصر", output.HasValue ? output.Value : 0);
        }


        private void updateButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sourceKindComboBox.Text.Trim()))
            {
                OnItemSubmissionError(sourceKindComboBox, "يجب إدخال النوع");
                return;
            }
            if (string.IsNullOrEmpty(sourceSubKindComboBox.Text.Trim()))
            {
                OnItemSubmissionError(sourceSubKindComboBox, "يجب إدخال النوع الفرعي");
                return;
            }
            if (string.IsNullOrEmpty(destinationKindComboBox.Text.Trim()))
            {
                OnItemSubmissionError(destinationKindComboBox, "يجب إدخال النوع");
                return;
            }
            if (string.IsNullOrEmpty(destinationSubKindComboBox.Text.Trim()))
            {
                OnItemSubmissionError(destinationSubKindComboBox, "يجب إدخال النوع الفرعي");
                return;
            }
            var kind = (ShopDataSet.أنواع_البيعRow)GetRow(destinationKindBindingSource,
                                                           string.Format("[{0}] = '{1}'", "الاسم",
                                                                         destinationKindComboBox.Text.Trim()), () =>
                                                                                                                   {
                                                                                                                       ShopDataSet
                                                                                                                           .
                                                                                                                           أنواع_البيعRow
                                                                                                                           row
                                                                                                                               =
                                                                                                                               MainDataSet
                                                                                                                                   .
                                                                                                                                   أنواع_البيع
                                                                                                                                   .
                                                                                                                                   Addأنواع_البيعRow
                                                                                                                                   (destinationKindComboBox
                                                                                                                                        .
                                                                                                                                        Text
                                                                                                                                        .
                                                                                                                                        Trim
                                                                                                                                        ());
                                                                                                                       أنواع_البيعTableAdapter
                                                                                                                           .
                                                                                                                           Update
                                                                                                                           (row);
                                                                                                                       return
                                                                                                                           row;
                                                                                                                   });
            var subkind = (ShopDataSet.الأنواع_الفرعية_للبيعRow)GetRow(destinationSubKindBindingSource,
                                                                        string.Format("[{0}] = '{1}' AND [{2}]='{3}'",
                                                                                      "الاسم",
                                                                                      destinationSubKindComboBox.Text.
                                                                                          Trim(), "معرف نوع البيع",
                                                                                      kind.معرف), () =>
                                                                                                      {
                                                                                                          ShopDataSet.
                                                                                                              الأنواع_الفرعية_للبيعRow
                                                                                                              subKindRowa
                                                                                                                  =
                                                                                                                  MainDataSet
                                                                                                                      .
                                                                                                                      الأنواع_الفرعية_للبيع
                                                                                                                      .
                                                                                                                      Addالأنواع_الفرعية_للبيعRow
                                                                                                                      (destinationSubKindComboBox
                                                                                                                           .
                                                                                                                           Text,
                                                                                                                       kind);
                                                                                                          الأنواع_الفرعية_للبيعTableAdapter
                                                                                                              .Update(
                                                                                                                  subKindRowa);
                                                                                                          return
                                                                                                              subKindRowa;
                                                                                                      });


            new مفردات_البيعTableAdapter().ChangeSalesKind(
                kind.معرف, subkind.معرف,
                (short)sourceKindComboBox.SelectedValue, (short)sourceSubKindComboBox.SelectedValue
                );
            sourceKindComboBox_SelectedIndexChanged(null, null);
        }

        private void destinationSubKindComboBox_Enter(object sender, EventArgs e)
        {
            destinationSubKindBindingSource.Filter = string.Format("[{0}]='{1}'", "معرف نوع البيع",
                                                                   destinationKindComboBox.SelectedValue ?? -1);
        }
    }
}