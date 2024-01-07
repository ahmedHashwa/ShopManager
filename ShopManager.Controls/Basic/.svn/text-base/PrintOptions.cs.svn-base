#region using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;

#endregion

namespace PrintDataGrid
{
    public partial class PrintOptions : Form
    {
        public PrintOptions()
        {
            InitializeComponent();
        }

        public PrintOptions(List<string> availableFields, String title)
        {
            InitializeComponent();
            txtTitle.Text = title;
            foreach (string field in availableFields)
                chklst.Items.Add(field, true);
        }

        public string PrintTitle
        {
            get { return txtTitle.Text; }
            //set { txtTitle.Text = value; }
        }

        public bool PrintAllRows
        {
            get { return rdoAllRows.Checked; }
        }


        public bool Landscape
        {
            get { return horizontalRadioButton.Checked; }
        }

        public bool FitToPageWidth
        {
            get { return chkFitToPageWidth.Checked; }
        }

        private void PrintOtions_Load(object sender, EventArgs e)
        {
            // Initialize some controls
            rdoAllRows.Checked = true;
            chkFitToPageWidth.Checked = true;
            verticalRadioButton.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public List<string> GetSelectedColumns()
        {
            var lst = new List<string>();
            foreach (object item in chklst.CheckedItems)
                lst.Add(item.ToString());
            return lst;
        }
    }
}