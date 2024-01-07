#region using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.ServiceProcess;
using System.Windows.Forms;
using PrintDataGrid;
using ShopManager.ProjectResources.Properties;

#endregion

namespace ShopManager.Controls.Basic
{
    public static class PrintDGV
    {
        #region Variables

        private static readonly List<string> AvailableColumns = new List<string>(); // All Columns avaiable in DataGrid 
        private static readonly ArrayList ColumnLefts = new ArrayList(); // Left Coordinate of Columns
        private static readonly ArrayList ColumnTypes = new ArrayList(); // DataType of Columns
        private static readonly ArrayList ColumnWidths = new ArrayList(); // Width of Columns

        private static readonly PrintDocument PrintDoc =
            new PrintDocument(); // PrintDocumnet Object used for printing

        private static Button _cellButton; // Holds the Contents of Button Cell
        private static CheckBox _cellCheckBox; // Holds the Contents of CheckBox Cell 
        private static ComboBox _cellComboBox; // Holds the Contents of ComboBox Cell
        private static int _cellHeight; // Height of DataGrid Cell
        private static DataGridView _dgv; // Holds DataGridView Object to print its contents
        private static bool _fitToPageWidth = true;
        // True = Fits selected columns to page width ,  False = Print columns as showed    
        private static int _headerHeight;
        private static bool _newPage; // Indicates if a new page reached
        private static int _pageNo; // Number of pages to print
        private static bool _printAllRows = true; // True = print all rows,  False = print selected rows    
        private static string _printTitle = ""; // Header of pages
        private static string _printSubTitle = ""; // Sub Header of pages
        private static int _rowPos; // Position of currently printing row 
        private static int _rowsPerPage; // Number of Rows per Page
        private static List<string> _selectedColumns = new List<string>(); // The Columns Selected by user to print.
        private static StringFormat _strFormat; // Holds content of a TextBox Cell to write by DrawString
        private static StringFormat _strFormatComboBox; // Holds content of a Boolean Cell to write by DrawImage
        private static int _totalWidth; // Summation of Columns widths

        #endregion

        #region Methods

        public static void Print_DataGridView(DataGridView dgv1, string title, string subtitle)
        {
            PrintPreviewDialog ppvw;
            try
            {
                // Getting DataGridView object to print
                _dgv = dgv1;
                // Getting all Coulmns Names in the DataGridView
                AvailableColumns.Clear();
                foreach (DataGridViewColumn c in _dgv.Columns)
                {
                    if (!c.Visible) continue;
                    AvailableColumns.Add(c.HeaderText);
                }
                // Showing the PrintOption Form
                var dlg = new PrintOptions(AvailableColumns, title);
                if (dlg.ShowDialog() != DialogResult.OK) return;
                CheckSpoolerService();
                _printTitle = dlg.PrintTitle;
                _printSubTitle = subtitle;
                _printAllRows = dlg.PrintAllRows;
                _fitToPageWidth = dlg.FitToPageWidth;
                _selectedColumns = dlg.GetSelectedColumns();
                _rowsPerPage = 0;
                ppvw = new PrintPreviewDialog
                           {
                               KeyPreview = true,
                               Text = "„⁄«Ì‰… „«  ﬁ»· «·ÿ»«⁄…",
                               RightToLeft = RightToLeft.Yes,
                               RightToLeftLayout = true,
                               WindowState = FormWindowState.Maximized,
                               Document = PrintDoc,
                               PrintPreviewControl = {Zoom = 1}
                           };
                ((Form) ppvw).Icon = Resources.building;
                ppvw.KeyUp +=
                    (sender, e) =>
                        {
                            if (e.KeyValue == (int) Keys.Escape)
                                ((Form) sender).Close();
                        };
                PrintDoc.DefaultPageSettings.Landscape = dlg.Landscape;
                PrintDoc.DefaultPageSettings.Margins.Top = 150;
                PrintDoc.DefaultPageSettings.Margins.Left = 10;
                PrintDoc.DefaultPageSettings.Margins.Right = 10;
                // Showing the Print Preview Page
                PrintDoc.BeginPrint += PrintDoc_BeginPrint;
                PrintDoc.PrintPage += PrintDoc_PrintPage;
                if (ppvw.ShowDialog() != DialogResult.OK)
                {
                    PrintDoc.BeginPrint -= PrintDoc_BeginPrint;
                    PrintDoc.PrintPage -= PrintDoc_PrintPage;
                    return;
                }
                // Printing the Documnet
                PrintDoc.Print();
                PrintDoc.BeginPrint -= PrintDoc_BeginPrint;
                PrintDoc.PrintPage -= PrintDoc_PrintPage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.PrintDGV_PrintDoc_PrintPage_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void CheckSpoolerService()
        {
            var scSqlServer = new ServiceController("Spooler");
            if (scSqlServer.Status == ServiceControllerStatus.Running) return;
            scSqlServer.Start();
        }

        private static void PrintDoc_BeginPrint(object sender,
                                                PrintEventArgs e)
        {
            try
            {
                // Formatting the Content of Text Cell to print
                _strFormat = new StringFormat
                                 {
                                     Alignment = StringAlignment.Near,
                                     LineAlignment = StringAlignment.Center,
                                     Trimming = StringTrimming.None,
                                     FormatFlags = StringFormatFlags.DirectionRightToLeft,
                                 };
                // Formatting the Content of Combo Cells to print
                _strFormatComboBox = new StringFormat
                                         {
                                             LineAlignment = StringAlignment.Center,
                                             FormatFlags = StringFormatFlags.DirectionRightToLeft,
                                             Trimming = StringTrimming.EllipsisCharacter,
                                         };
                ColumnLefts.Clear();
                ColumnWidths.Clear();
                ColumnTypes.Clear();
                _cellHeight = 0;
                _rowsPerPage = 0;
                // For various column types
                _cellButton = new Button();
                _cellCheckBox = new CheckBox();
                _cellComboBox = new ComboBox();
                // Calculating Total Widths
                _totalWidth = 0;
                foreach (DataGridViewColumn gridCol in _dgv.Columns)
                {
                    if (!gridCol.Visible) continue;
                    if (!_selectedColumns.Contains(gridCol.HeaderText)) continue;
                    _totalWidth += gridCol.Width;
                }
                _pageNo = 1;
                _newPage = true;
                _rowPos = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.PrintDGV_PrintDoc_PrintPage_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void PrintDoc_PrintPage(object sender,
                                               PrintPageEventArgs e)
        {
            int tmpTop = e.MarginBounds.Top;
            int tmpLeft = e.MarginBounds.Left;
            try
            {
                // Before starting first page, it saves Width & Height of Headers and CoulmnType
                if (_pageNo == 1)
                {
                    for (int ii = 0; ii < _dgv.Columns.Count; ii++)
                    {
                        if (!_dgv.Columns[ii].Visible) continue;
                        // Skip if the current column not selected
                        if (!_selectedColumns.Contains(_dgv.Columns[ii].HeaderText)) continue;
                        // Detemining whether the columns are fitted to page or not.
                        int tmpWidth;
                        if (_fitToPageWidth)
                            tmpWidth = (int) (Math.Floor((_dgv.Columns[ii].Width/
                                                          (double) _totalWidth*_totalWidth*
                                                          (e.MarginBounds.Width/(double) _totalWidth))));
                        else
                            tmpWidth = _dgv.Columns[ii].Width;
                        _headerHeight = (int) (e.Graphics.MeasureString(_dgv.Columns[ii].HeaderText,
                                                                        _dgv.Columns[ii].InheritedStyle.Font, tmpWidth).
                                                  Height) + 11;
                        // Save width & height of headres and ColumnType
                        ColumnLefts.Add(tmpLeft);
                        ColumnWidths.Add(tmpWidth);
                        ColumnTypes.Add(_dgv.Columns[ii].GetType());
                        tmpLeft += tmpWidth;
                    }
                }
                // Printing Current Page, Row by Row
                while (_rowPos <= _dgv.Rows.Count - 1)
                {
                    DataGridViewRow gridRow = _dgv.Rows[_rowPos];
                    if (gridRow.IsNewRow || (!_printAllRows && !gridRow.Selected))
                    {
                        _rowPos++;
                        continue;
                    }
                    // Determine the largest Height
                    var heights = new List<float>();
                    for (int c = ColumnWidths.Count - 1, cc = _dgv.Columns.Count - 1; cc >= 0; cc--)
                    {
                        if (!_dgv.Columns[cc].Visible ||
                            !_selectedColumns.Contains(_dgv.Columns[cc].HeaderText)) continue;

                        heights.Add(
                            e.Graphics.MeasureString(gridRow.Cells[cc].FormattedValue.ToString(),
                                                     gridRow.Cells[cc].InheritedStyle.Font,
                                                     (int) ColumnWidths[c--],
                                                     new StringFormat
                                                         {
                                                             Trimming = StringTrimming.None,
                                                             FormatFlags =
                                                                 StringFormatFlags.DirectionRightToLeft |
                                                                 StringFormatFlags.NoClip
                                                         }).Height);
                    }
                    heights.Sort();
                    // Assigin the largest height
                    _cellHeight = (int) heights[heights.Count - 1] + 1;
                    if (tmpTop + _cellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        DrawFooter(e, _rowsPerPage);
                        _newPage = true;
                        _pageNo++;
                        e.HasMorePages = true;
                        return;
                    }
                    int i;
                    if (_newPage)
                    {
                        // Pages Header
                        // Prepare Today
                        string dateString = " «—ÌŒ «·ÿ»«⁄…: " + DateTime.Now.ToLongDateString() + " " +
                                            DateTime.Now.ToShortTimeString();
                        var datefont = new Font(_dgv.Font, FontStyle.Bold);
                        float dateHeight = e.Graphics.MeasureString(dateString, datefont, e.MarginBounds.Width).Height;
                        // Prepare ShopName
                        var format = new StringFormat
                                         {
                                             FormatFlags =
                                                 StringFormatFlags.NoWrap | StringFormatFlags.DirectionRightToLeft
                                         };
                        string shopName =  Settings.Default.ShopName;
                        var shopFont = new Font(_dgv.Font, FontStyle.Bold);
                        float shopNameHeight = e.Graphics.MeasureString(
                            shopName, shopFont, e.MarginBounds.Width).Height;
                        // Prepare Header
                        var printTitleFont = new Font(_dgv.Font.FontFamily, 20.0f, FontStyle.Regular);
                        float printTitleHeight = e.Graphics.MeasureString(
                            _printTitle, printTitleFont, e.MarginBounds.Width).Height;
                        // Prepare SubHeader
                        var printSubTitleFont = new Font(_dgv.Font.FontFamily, 8, FontStyle.Regular);
                        float printSubTitleHeight = e.Graphics.MeasureString(
                            _printSubTitle, printSubTitleFont, e.MarginBounds.Width).Height;
                        // Draw Today
                        e.Graphics.DrawString(dateString, datefont,
                                              Brushes.Black, e.MarginBounds.Right,
                                              e.MarginBounds.Top - dateHeight - shopNameHeight - printTitleHeight -
                                              printSubTitleHeight, format);
                        // Draw ShopName
                        e.Graphics.DrawString(shopName, shopFont,
                                              Brushes.Black, e.MarginBounds.Right,
                                              e.MarginBounds.Top - shopNameHeight - printTitleHeight -
                                              printSubTitleHeight, format);
                        // Draw Header
                        e.Graphics.DrawString(_printTitle, printTitleFont,
                                              Brushes.Black,
                                              (e.PageBounds.Width +
                                               e.Graphics.MeasureString(_printTitle, printTitleFont,
                                                                        e.MarginBounds.Width).Width)/2
                                              , e.MarginBounds.Top - printTitleHeight - printSubTitleHeight, format);
                        // Draw SubHeader
                        e.Graphics.DrawString(_printSubTitle, printSubTitleFont,
                                              Brushes.Black,
                                              e.Graphics.MeasureString(_printSubTitle, printSubTitleFont,
                                                                       e.MarginBounds.Width).Width + 10
                                              , e.MarginBounds.Top - printSubTitleHeight, format);
                        // End Page Headers
                        // Draw Columns
                        tmpTop = e.MarginBounds.Top;
                        i = 0;
                        for (int ii = _dgv.Columns.Count - 1; ii >= 0; ii--)
                        {
                            if (!_dgv.Columns[ii].Visible) continue;
                            if (!_selectedColumns.Contains(_dgv.Columns[ii].HeaderText))
                                continue;
                            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                                     new Rectangle((int) ColumnLefts[i], tmpTop,
                                                                   (int) ColumnWidths[i], _headerHeight));
                            e.Graphics.DrawRectangle(Pens.Black,
                                                     new Rectangle((int) ColumnLefts[i], tmpTop,
                                                                   (int) ColumnWidths[i], _headerHeight));
                            e.Graphics.DrawString(_dgv.Columns[ii].HeaderText, _dgv.Columns[ii].InheritedStyle.Font,
                                                  new SolidBrush(_dgv.Columns[ii].InheritedStyle.ForeColor),
                                                  new RectangleF((int) ColumnLefts[i], tmpTop,
                                                                 (int) ColumnWidths[i], _headerHeight), _strFormat);
                            i++;
                        }
                        _newPage = false;
                        tmpTop += _headerHeight;
                    }
                    // Draw Columns Contents
                    i = 0;
                    for (int ii = gridRow.Cells.Count - 1; ii >= 0; ii--)
                    {
                        if (!gridRow.Cells[ii].OwningColumn.Visible) continue;
                        if (!_selectedColumns.Contains(gridRow.Cells[ii].OwningColumn.HeaderText))
                            continue;
                        // For the TextBox Column
                        if (((Type) ColumnTypes[i]).Name == "DataGridViewTextBoxColumn" ||
                            ((Type) ColumnTypes[i]).Name == "DataGridViewLinkColumn")
                        {
                            e.Graphics.DrawString(gridRow.Cells[ii].FormattedValue.ToString(),
                                                  gridRow.Cells[ii].InheritedStyle.Font,
                                                  new SolidBrush(gridRow.Cells[ii].InheritedStyle.ForeColor),
                                                  new RectangleF((int) ColumnLefts[i], tmpTop,
                                                                 (int) ColumnWidths[i], _cellHeight), _strFormat);
                        }
                            // For the Button Column
                        else if (((Type) ColumnTypes[i]).Name == "DataGridViewButtonColumn")
                        {
                            _cellButton.Text = gridRow.Cells[ii].Value.ToString();
                            _cellButton.Size = new Size((int) ColumnWidths[i], _cellHeight);
                            var bmp = new Bitmap(_cellButton.Width, _cellButton.Height);
                            _cellButton.DrawToBitmap(bmp, new Rectangle(0, 0,
                                                                        bmp.Width, bmp.Height));
                            e.Graphics.DrawImage(bmp, new Point((int) ColumnLefts[i], tmpTop));
                        }
                            // For the CheckBox Column
                        else if (((Type) ColumnTypes[i]).Name == "DataGridViewCheckBoxColumn")
                        {
                            _cellCheckBox.Size = new Size(14, 14);
                            _cellCheckBox.Checked = (bool) gridRow.Cells[ii].Value;
                            var bmp = new Bitmap((int) ColumnWidths[i], _cellHeight);
                            Graphics tmpGraphics = Graphics.FromImage(bmp);
                            tmpGraphics.FillRectangle(Brushes.White, new Rectangle(0, 0,
                                                                                   bmp.Width, bmp.Height));
                            _cellCheckBox.DrawToBitmap(bmp,
                                                       new Rectangle(((bmp.Width - _cellCheckBox.Width)/2),
                                                                     ((bmp.Height - _cellCheckBox.Height)/2),
                                                                     _cellCheckBox.Width, _cellCheckBox.Height));
                            e.Graphics.DrawImage(bmp, new Point((int) ColumnLefts[i], tmpTop));
                        }
                            // For the ComboBox Column
                        else if (((Type) ColumnTypes[i]).Name == "DataGridViewComboBoxColumn")
                        {
                            _cellComboBox.Size = new Size((int) ColumnWidths[i], _cellHeight);
                            var bmp = new Bitmap(_cellComboBox.Width, _cellComboBox.Height);
                            _cellComboBox.DrawToBitmap(bmp, new Rectangle(0, 0,
                                                                          bmp.Width, bmp.Height));
                            e.Graphics.DrawImage(bmp, new Point((int) ColumnLefts[i], tmpTop));
                            e.Graphics.DrawString(gridRow.Cells[ii].FormattedValue.ToString(),
                                                  gridRow.Cells[ii].InheritedStyle.Font,
                                                  new SolidBrush(gridRow.Cells[ii].InheritedStyle.ForeColor),
                                                  new RectangleF((int) ColumnLefts[i] + 1, tmpTop,
                                                                 (int) ColumnWidths[i]
                                                                 - 16, _cellHeight), _strFormatComboBox);
                        }
                            // For the Image Column
                        else if (((Type) ColumnTypes[i]).Name == "DataGridViewImageColumn")
                        {
                            var celSize = new Rectangle((int) ColumnLefts[i],
                                                        tmpTop, (int) ColumnWidths[i], _cellHeight);
                            Size imgSize = ((Image) (gridRow.Cells[ii].FormattedValue)).Size;
                            e.Graphics.DrawImage((Image) gridRow.Cells[ii].FormattedValue,
                                                 new Rectangle(
                                                     (int) ColumnLefts[i] + ((celSize.Width - imgSize.Width)/2),
                                                     tmpTop + ((celSize.Height - imgSize.Height)/2),
                                                     ((Image) (gridRow.Cells[ii].FormattedValue)).Width,
                                                     ((Image) (gridRow.Cells[ii].FormattedValue)).Height));
                        }
                        // Drawing Cells Borders 
                        e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int) ColumnLefts[i],
                                                                           tmpTop, (int) ColumnWidths[i],
                                                                           _cellHeight));
                        i++;
                    }
                    tmpTop += _cellHeight;
                    _rowPos++;
                    // For the first page it calculates Rows per Page
                    if (_pageNo == 1) _rowsPerPage++;
                }
                if (_rowsPerPage == 0) return;
                // Write Footer (Page Number)
                DrawFooter(e, _rowsPerPage);
                e.HasMorePages = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Resources.PrintDGV_PrintDoc_PrintPage_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void DrawFooter(PrintPageEventArgs e,
                                       int rowsPerPage)
        {
            double cnt;
            // Detemining rows number to print
            if (_printAllRows)
            {
                if (_dgv.Rows[_dgv.Rows.Count - 1].IsNewRow)
                    cnt = _dgv.Rows.Count - 2; // When the DataGridView doesn't allow adding rows
                else
                    cnt = _dgv.Rows.Count; // When the DataGridView allows adding rows
            }
            else
                cnt = _dgv.SelectedRows.Count;
            // Writing the Page Number on the Bottom of Page
            string pageNum = _pageNo + " „‰ " +
                             Math.Ceiling((cnt/rowsPerPage));
            var format = new StringFormat
                             {
                                 FormatFlags =
                                     StringFormatFlags.NoWrap | StringFormatFlags.DirectionRightToLeft
                             };
            e.Graphics.DrawString(pageNum, _dgv.Font, Brushes.Black,
                                  (e.PageBounds.Width +
                                   e.Graphics.MeasureString(pageNum, _dgv.Font,
                                                            e.MarginBounds.Width).Width)/2,
                                  e.MarginBounds.Top +
                                  e.MarginBounds.Height + 31, format);
        }

        #endregion
    }
}