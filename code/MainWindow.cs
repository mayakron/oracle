using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Oracle
{
    public partial class MainWindow : Form
    {
        private const string RichTextBoxMonospaceFontFamily = "Consolas";

        private const float RichTextBoxMonospaceFontSize = 9F;

        private const string RichTextBoxStandardFontFamily = "Calibri";

        private const float RichTextBoxStandardFontSize = 11.25F;

        private const string TreeViewStandardFontFamily = "Calibri";

        private const float TreeViewStandardFontSize = 11.25F;

        private int? RichTextBoxSetFirstVisibleCharIndex;

        private int? RichTextBoxSetSelectionStart;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.MainWindow_SaveSettings();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (new MessageWindow(this, "You might have unsaved changes, are you sure that you want to exit this application?", "Exit application...", MessageWindowType.Question).ShowDialog() != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private int MainWindow_GetBookmarksRichTextBoxFirstVisibleCharIndex(int index)
        {
            switch (index)
            {
                case 1: return Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex1;
                case 2: return Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex2;
                case 3: return Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex3;
                case 4: return Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex4;
                case 5: return Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex5;
                case 6: return Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex6;
                case 7: return Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex7;
                case 8: return Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex8;
                case 9: return Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex9;
            }

            return 0;
        }

        private int MainWindow_GetBookmarksRichTextBoxSelectionStart(int index)
        {
            switch (index)
            {
                case 1: return Properties.Settings.Default.BookmarksRichTextBoxSelectionStart1;
                case 2: return Properties.Settings.Default.BookmarksRichTextBoxSelectionStart2;
                case 3: return Properties.Settings.Default.BookmarksRichTextBoxSelectionStart3;
                case 4: return Properties.Settings.Default.BookmarksRichTextBoxSelectionStart4;
                case 5: return Properties.Settings.Default.BookmarksRichTextBoxSelectionStart5;
                case 6: return Properties.Settings.Default.BookmarksRichTextBoxSelectionStart6;
                case 7: return Properties.Settings.Default.BookmarksRichTextBoxSelectionStart7;
                case 8: return Properties.Settings.Default.BookmarksRichTextBoxSelectionStart8;
                case 9: return Properties.Settings.Default.BookmarksRichTextBoxSelectionStart9;
            }

            return 0;
        }

        private string MainWindow_GetBookmarksTreeNodeName(int index)
        {
            switch (index)
            {
                case 1: return Properties.Settings.Default.BookmarksTreeNodeName1;
                case 2: return Properties.Settings.Default.BookmarksTreeNodeName2;
                case 3: return Properties.Settings.Default.BookmarksTreeNodeName3;
                case 4: return Properties.Settings.Default.BookmarksTreeNodeName4;
                case 5: return Properties.Settings.Default.BookmarksTreeNodeName5;
                case 6: return Properties.Settings.Default.BookmarksTreeNodeName6;
                case 7: return Properties.Settings.Default.BookmarksTreeNodeName7;
                case 8: return Properties.Settings.Default.BookmarksTreeNodeName8;
                case 9: return Properties.Settings.Default.BookmarksTreeNodeName9;
            }

            return null;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.O:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                var directoryPath = this.TreeView_GetExistingNodeDataAttachmentsDirectoryPath(this.TreeView.SelectedNode);

                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }

                                Process.Start(Utilities.ConfigurationUtility.FileExplorer, directoryPath);

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.S:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.TreeView_SaveNode(this.TreeView.SelectedNode);

                                this.MainWindow_UpdateStatusInfo("Processing...");

                                this.TreeView_SaveTree();

                                this.MainWindow_UpdateStatusInfo($"Database saved successfully at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

                                e.SuppressKeyPress = true;

                                e.Handled = true;

                                GC.Collect();
                            }
                        }
                        else
                        {
                            if (!e.Alt)
                            {
                                this.TreeView_SaveNode(this.TreeView.SelectedNode);

                                this.MainWindow_UpdateStatusInfo("Processing...");

                                this.TreeView_SaveTree();

                                this.TreeView_CleanupNodeDataAttachmentsDirectories();

                                this.MainWindow_UpdateStatusInfo($"Database saved successfully at {DateTime.Now:yyyy-MM-dd HH:mm:ss}");

                                e.SuppressKeyPress = true;

                                e.Handled = true;

                                GC.Collect();
                            }
                        }
                    }

                    break;

                case Keys.D1:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_LoadBookmark(1);

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_SaveBookmark(1, this.TreeView.SelectedNode);

                                this.MainWindow_UpdateStatusInfo("Current node has been bookmarked in position 1");

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D2:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_LoadBookmark(2);

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_SaveBookmark(2, this.TreeView.SelectedNode);

                                this.MainWindow_UpdateStatusInfo("Current node has been bookmarked in position 2");

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D3:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_LoadBookmark(3);

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_SaveBookmark(3, this.TreeView.SelectedNode);

                                this.MainWindow_UpdateStatusInfo("Current node has been bookmarked in position 3");

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D4:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_LoadBookmark(4);

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_SaveBookmark(4, this.TreeView.SelectedNode);

                                this.MainWindow_UpdateStatusInfo("Current node has been bookmarked in position 4");

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D5:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_LoadBookmark(5);

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_SaveBookmark(5, this.TreeView.SelectedNode);

                                this.MainWindow_UpdateStatusInfo("Current node has been bookmarked in position 5");

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D6:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_LoadBookmark(6);

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_SaveBookmark(6, this.TreeView.SelectedNode);

                                this.MainWindow_UpdateStatusInfo("Current node has been bookmarked in position 6");

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D7:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_LoadBookmark(7);

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_SaveBookmark(7, this.TreeView.SelectedNode);

                                this.MainWindow_UpdateStatusInfo("Current node has been bookmarked in position 7");

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D8:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_LoadBookmark(8);

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_SaveBookmark(8, this.TreeView.SelectedNode);

                                this.MainWindow_UpdateStatusInfo("Current node has been bookmarked in position 8");

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D9:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_LoadBookmark(9);

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (!e.Alt)
                            {
                                this.MainWindow_SaveBookmark(9, this.TreeView.SelectedNode);

                                this.MainWindow_UpdateStatusInfo("Current node has been bookmarked in position 9");

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.TreeView_LoadTree();

            this.Text = Program.Title;

            this.MainWindow_LoadSettings();
        }

        private void MainWindow_LoadBookmark(int index)
        {
            var bookmarksTreeNodeName = this.MainWindow_GetBookmarksTreeNodeName(index);

            if (!string.IsNullOrEmpty(bookmarksTreeNodeName))
            {
                var foundNode = this.TreeView_FindNodeByName(bookmarksTreeNodeName); if ((foundNode != null) && (foundNode != this.TreeView.SelectedNode))
                {
                    this.TreeView_SaveNode(this.TreeView.SelectedNode);

                    var bookmarksRichTextBoxFirstVisibleCharIndex = this.MainWindow_GetBookmarksRichTextBoxFirstVisibleCharIndex(index);
                    var bookmarksRichTextBoxSelectionStart = this.MainWindow_GetBookmarksRichTextBoxSelectionStart(index);

                    this.RichTextBoxSetFirstVisibleCharIndex = (bookmarksRichTextBoxFirstVisibleCharIndex > -1) ? bookmarksRichTextBoxFirstVisibleCharIndex : (int?)null;
                    this.RichTextBoxSetSelectionStart = (bookmarksRichTextBoxSelectionStart > -1) ? bookmarksRichTextBoxSelectionStart : (int?)null;

                    this.TreeView.SelectedNode = foundNode; this.TreeView.SelectedNode.EnsureVisible();
                }
            }
        }

        private void MainWindow_LoadSettings()
        {
            this.Top = Properties.Settings.Default.MainWindowTop;
            this.Left = Properties.Settings.Default.MainWindowLeft;
            this.Width = Properties.Settings.Default.MainWindowWidth;
            this.Height = Properties.Settings.Default.MainWindowHeight;

            this.WindowState = (FormWindowState)Properties.Settings.Default.MainWindowState;

            this.TreeViewAndRichTextBoxSplitContainer.SplitterDistance = Properties.Settings.Default.MainWindowSplitContainerDistance;
        }

        private void MainWindow_SaveBookmark(int index, TreeNode treeNode)
        {
            this.MainWindow_SetBookmarksTreeNodeName(index, treeNode.Name);
            this.MainWindow_SetBookmarksRichTextBoxSelectionStart(index, this.RichTextBox.Focused ? this.RichTextBox.SelectionStart : -1);
            this.MainWindow_SetBookmarksRichTextBoxFirstVisibleCharIndex(index, this.RichTextBox.Focused ? this.RichTextBox.GetCharIndexFromPosition(new Point(0, 0)) : -1);
        }

        private void MainWindow_SaveSettings()
        {
            Properties.Settings.Default.MainWindowSplitContainerDistance = this.TreeViewAndRichTextBoxSplitContainer.SplitterDistance;

            switch (this.WindowState)
            {
                case FormWindowState.Normal:

                    Properties.Settings.Default.MainWindowState = (int)FormWindowState.Normal;

                    Properties.Settings.Default.MainWindowHeight = this.Height;
                    Properties.Settings.Default.MainWindowWidth = this.Width;
                    Properties.Settings.Default.MainWindowLeft = this.Left;
                    Properties.Settings.Default.MainWindowTop = this.Top;

                    break;

                case FormWindowState.Maximized:

                    Properties.Settings.Default.MainWindowState = (int)FormWindowState.Maximized;

                    break;

                case FormWindowState.Minimized:

                    Properties.Settings.Default.MainWindowState = (int)FormWindowState.Normal;

                    break;
            }

            Properties.Settings.Default.Save();
        }

        private void MainWindow_SetBookmarksRichTextBoxFirstVisibleCharIndex(int index, int richTextBoxFirstVisibleCharIndex)
        {
            switch (index)
            {
                case 1: Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex1 = richTextBoxFirstVisibleCharIndex; break;
                case 2: Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex2 = richTextBoxFirstVisibleCharIndex; break;
                case 3: Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex3 = richTextBoxFirstVisibleCharIndex; break;
                case 4: Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex4 = richTextBoxFirstVisibleCharIndex; break;
                case 5: Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex5 = richTextBoxFirstVisibleCharIndex; break;
                case 6: Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex6 = richTextBoxFirstVisibleCharIndex; break;
                case 7: Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex7 = richTextBoxFirstVisibleCharIndex; break;
                case 8: Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex8 = richTextBoxFirstVisibleCharIndex; break;
                case 9: Properties.Settings.Default.BookmarksRichTextBoxFirstVisibleCharIndex9 = richTextBoxFirstVisibleCharIndex; break;
            }
        }

        private void MainWindow_SetBookmarksRichTextBoxSelectionStart(int index, int richTextBoxSelectionStart)
        {
            switch (index)
            {
                case 1: Properties.Settings.Default.BookmarksRichTextBoxSelectionStart1 = richTextBoxSelectionStart; break;
                case 2: Properties.Settings.Default.BookmarksRichTextBoxSelectionStart2 = richTextBoxSelectionStart; break;
                case 3: Properties.Settings.Default.BookmarksRichTextBoxSelectionStart3 = richTextBoxSelectionStart; break;
                case 4: Properties.Settings.Default.BookmarksRichTextBoxSelectionStart4 = richTextBoxSelectionStart; break;
                case 5: Properties.Settings.Default.BookmarksRichTextBoxSelectionStart5 = richTextBoxSelectionStart; break;
                case 6: Properties.Settings.Default.BookmarksRichTextBoxSelectionStart6 = richTextBoxSelectionStart; break;
                case 7: Properties.Settings.Default.BookmarksRichTextBoxSelectionStart7 = richTextBoxSelectionStart; break;
                case 8: Properties.Settings.Default.BookmarksRichTextBoxSelectionStart8 = richTextBoxSelectionStart; break;
                case 9: Properties.Settings.Default.BookmarksRichTextBoxSelectionStart9 = richTextBoxSelectionStart; break;
            }
        }

        private void MainWindow_SetBookmarksTreeNodeName(int index, string treeNodeName)
        {
            switch (index)
            {
                case 1: Properties.Settings.Default.BookmarksTreeNodeName1 = treeNodeName; break;
                case 2: Properties.Settings.Default.BookmarksTreeNodeName2 = treeNodeName; break;
                case 3: Properties.Settings.Default.BookmarksTreeNodeName3 = treeNodeName; break;
                case 4: Properties.Settings.Default.BookmarksTreeNodeName4 = treeNodeName; break;
                case 5: Properties.Settings.Default.BookmarksTreeNodeName5 = treeNodeName; break;
                case 6: Properties.Settings.Default.BookmarksTreeNodeName6 = treeNodeName; break;
                case 7: Properties.Settings.Default.BookmarksTreeNodeName7 = treeNodeName; break;
                case 8: Properties.Settings.Default.BookmarksTreeNodeName8 = treeNodeName; break;
                case 9: Properties.Settings.Default.BookmarksTreeNodeName9 = treeNodeName; break;
            }
        }

        private void MainWindow_UpdateStatusInfo(string statusInfo = null)
        {
            this.Text = Program.Title + (!string.IsNullOrEmpty(statusInfo) ? " - " + statusInfo : string.Empty);
        }

        private void RichTextBox_InsertImage(string imageType, int imageWidth, int imageHeight, Stream stream)
        {
            const int pixelToTwipRatio = 15;

            this.RichTextBox.SelectedRtf = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1040\viewkind4\uc1\pard\sl240\slmult1{\pict\" + imageType + @"\picw" + imageWidth + @"\pich" + imageHeight + @"\picwgoal" + (imageWidth * pixelToTwipRatio) + @"\pichgoal" + (imageHeight * pixelToTwipRatio) + " " + Utilities.HexConverter.ToHexString(stream) + "}}";
        }

        private void RichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.B:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.RichTextBox.SelectionFont = new Font(this.RichTextBox.SelectionFont, this.RichTextBox.SelectionFont.Bold ? this.RichTextBox.SelectionFont.Style ^ FontStyle.Bold : this.RichTextBox.SelectionFont.Style | FontStyle.Bold);

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                if (this.TreeView.SelectedNode != null)
                                {
                                    this.SaveFileDialog.Title = "Export notes as...";

                                    this.SaveFileDialog.Filter = "Rich Text Format file (*.rtf)|*.rtf";

                                    if (this.SaveFileDialog.ShowDialog() == DialogResult.OK)
                                    {
                                        this.RichTextBox.SaveFile(this.SaveFileDialog.FileName);
                                    }
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (this.TreeView.SelectedNode != null)
                            {
                                this.OpenFileDialog.Title = "Import notes from...";

                                this.OpenFileDialog.Filter = "Rich Text Format file (*.rtf)|*.rtf";

                                if (this.OpenFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    this.RichTextBox.LoadFile(this.OpenFileDialog.FileName);

                                    this.RichTextBox.Modified = true;
                                }
                            }

                            e.SuppressKeyPress = true;

                            e.Handled = true;
                        }
                    }

                    break;

                case Keys.H:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.RichTextBox.SelectionIndent += 20;

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (!e.Alt)
                            {
                                this.RichTextBox.SelectionIndent = (this.RichTextBox.SelectionIndent > 20) ? (this.RichTextBox.SelectionIndent - 20) : 0;

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.I:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.RichTextBox.SelectionFont = new Font(this.RichTextBox.SelectionFont, this.RichTextBox.SelectionFont.Italic ? this.RichTextBox.SelectionFont.Style ^ FontStyle.Italic : this.RichTextBox.SelectionFont.Style | FontStyle.Italic);

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.K:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.RichTextBox.SelectionFont = new Font(this.RichTextBox.SelectionFont, this.RichTextBox.SelectionFont.Strikeout ? this.RichTextBox.SelectionFont.Style ^ FontStyle.Strikeout : this.RichTextBox.SelectionFont.Style | FontStyle.Strikeout);

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.M:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                if ((this.RichTextBox.SelectionFont != null) && (this.RichTextBox.SelectionFont.FontFamily != null) && (this.RichTextBox.SelectionFont.FontFamily.Name != RichTextBoxMonospaceFontFamily))
                                {
                                    this.RichTextBox.SelectionFont = new Font(RichTextBoxMonospaceFontFamily, RichTextBoxMonospaceFontSize, FontStyle.Regular);
                                }
                                else
                                {
                                    this.RichTextBox.SelectionFont = this.RichTextBox.Font;
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.U:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.RichTextBox.SelectionFont = new Font(this.RichTextBox.SelectionFont, this.RichTextBox.SelectionFont.Underline ? this.RichTextBox.SelectionFont.Style ^ FontStyle.Underline : this.RichTextBox.SelectionFont.Style | FontStyle.Underline);

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.V:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                if (Clipboard.ContainsText())
                                {
                                    this.RichTextBox.Paste();
                                }
                                else if (Clipboard.ContainsImage())
                                {
                                    this.RichTextBox_PasteImage(lossyImageFormatAllowed: false);
                                }
                                else
                                {
                                    this.RichTextBox.Paste();
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (!e.Alt)
                            {
                                if (Clipboard.ContainsText())
                                {
                                    this.RichTextBox.Paste(DataFormats.GetFormat(DataFormats.UnicodeText));
                                }
                                else if (Clipboard.ContainsImage())
                                {
                                    this.RichTextBox_PasteImage(lossyImageFormatAllowed: true);
                                }
                                else
                                {
                                    this.RichTextBox.Paste();
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D0:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.RichTextBox.SelectionColor = this.RichTextBox.ForeColor;
                                this.RichTextBox.SelectionBackColor = this.RichTextBox.BackColor;

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D1:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.RichTextBox.SelectionColor = Color.Red;
                                this.RichTextBox.SelectionBackColor = this.RichTextBox.BackColor;

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D2:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.RichTextBox.SelectionColor = Color.Green;
                                this.RichTextBox.SelectionBackColor = this.RichTextBox.BackColor;

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D3:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.RichTextBox.SelectionColor = Color.Blue;
                                this.RichTextBox.SelectionBackColor = this.RichTextBox.BackColor;

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D4:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.RichTextBox.SelectionColor = Color.Gray;
                                this.RichTextBox.SelectionBackColor = this.RichTextBox.BackColor;

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D5:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.RichTextBox.SelectionColor = Color.White;
                                this.RichTextBox.SelectionBackColor = Color.Black;

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D6:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.RichTextBox.SelectionColor = Color.White;
                                this.RichTextBox.SelectionBackColor = Color.Red;

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D7:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.RichTextBox.SelectionColor = Color.White;
                                this.RichTextBox.SelectionBackColor = Color.Green;

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D8:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.RichTextBox.SelectionColor = Color.White;
                                this.RichTextBox.SelectionBackColor = Color.Blue;

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D9:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.RichTextBox.SelectionColor = Color.White;
                                this.RichTextBox.SelectionBackColor = Color.Gray;

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;
            }
        }

        private void RichTextBox_Leave(object sender, EventArgs e)
        {
            this.TreeView_SaveNode(this.TreeView.SelectedNode);
        }

        private void RichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            var linkText = e.LinkText;

            if (linkText.Contains("{{NodePath}}"))
            {
                linkText = linkText.Replace("{{NodePath}}", this.TreeView_GetExistingNodeDataAttachmentsDirectoryPath(this.TreeView.SelectedNode));
            }

            if (linkText.StartsWith("gopher://"))
            {
                var gopherMatch = Regex.Match(linkText, @"^gopher://([^:]+):(.*)$", RegexOptions.None);

                if (gopherMatch.Success)
                {
                    var gopherMatchCmd = gopherMatch.Groups[1].Captures[0].Value;
                    var gopherMatchArg = gopherMatch.Groups[2].Captures[0].Value;

                    if (gopherMatchCmd.Equals("Goto", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var foundNode = this.TreeView_FindNodeByName(gopherMatchArg); if ((foundNode != null) && (foundNode != this.TreeView.SelectedNode))
                        {
                            this.TreeView_SaveNode(this.TreeView.SelectedNode);

                            this.TreeView.SelectedNode = foundNode; this.TreeView.SelectedNode.EnsureVisible();
                        }
                    }
                }
            }
            else if (linkText.StartsWith("file://"))
            {
                var fileMatch = Regex.Match(linkText, @"^file://(.*)$", RegexOptions.None);

                if (fileMatch.Success)
                {
                    var fileMatchValue = fileMatch.Groups[1].Captures[0].Value;

                    var path = fileMatchValue.Replace("%20", " ").Replace("/", @"\");

                    try
                    {
                        if (Directory.Exists(path)) Process.Start(Utilities.ConfigurationUtility.FileExplorer, path); else if (File.Exists(path)) Process.Start(path);
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                try
                {
                    Process.Start(linkText);
                }
                catch
                {
                }
            }
        }

        private void RichTextBox_PasteImage(bool lossyImageFormatAllowed)
        {
            using (var image = Clipboard.GetImage())
            {
                if (lossyImageFormatAllowed)
                {
                    using (var pngImageStream = new MemoryStream())
                    {
                        image.Save(pngImageStream, ImageFormat.Png);

                        using (var jpgImageStream = new MemoryStream())
                        {
                            image.Save(jpgImageStream, ImageFormat.Jpeg);

                            if (jpgImageStream.Length < pngImageStream.Length)
                            {
                                jpgImageStream.Seek(0, SeekOrigin.Begin);

                                this.RichTextBox_InsertImage("jpegblip", image.Width, image.Height, jpgImageStream);
                            }
                            else
                            {
                                pngImageStream.Seek(0, SeekOrigin.Begin);

                                this.RichTextBox_InsertImage("pngblip", image.Width, image.Height, pngImageStream);
                            }
                        }
                    }
                }
                else
                {
                    using (var pngImageStream = new MemoryStream())
                    {
                        image.Save(pngImageStream, ImageFormat.Png);

                        pngImageStream.Seek(0, SeekOrigin.Begin);

                        this.RichTextBox_InsertImage("pngblip", image.Width, image.Height, pngImageStream);
                    }
                }
            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectedNode = this.TreeView.SelectedNode;

            this.TreeView_LoadNode(selectedNode);

            if (this.RichTextBoxSetSelectionStart.HasValue)
            {
                if (this.RichTextBoxSetFirstVisibleCharIndex.HasValue)
                {
                    this.RichTextBox.SelectionStart = this.RichTextBoxSetFirstVisibleCharIndex.Value;

                    this.RichTextBoxSetFirstVisibleCharIndex = null;

                    this.RichTextBox.ScrollToCaret();
                }

                this.RichTextBox.SelectionStart = this.RichTextBoxSetSelectionStart.Value;

                this.RichTextBoxSetSelectionStart = null;

                if (!this.RichTextBox.Focused)
                {
                    this.RichTextBox.Focus();
                }
            }
            else
            {
                if (!this.TreeView.Focused)
                {
                    this.TreeView.Focus();
                }
            }

            this.MainWindow_UpdateStatusInfo(string.Format("Current node has {0:N0} characters of text and {1:N0} attachments", (this.RichTextBox.Rtf != null) ? this.RichTextBox.Rtf.Length : 0, this.TreeView_GetExistingNodeDataAttachmentsCount(selectedNode)));
        }

        private void TreeView_CleanupNodeDataAttachmentsDirectories()
        {
            var databaseDirectoryPath = this.TreeView_GetDatabaseDirectoryPath();

            if (Directory.Exists(databaseDirectoryPath))
            {
                var possibleDirectoryPathList = this.TreeView_GetTreeExpandedAsList().Select(x => this.TreeView_GetExistingNodeDataAttachmentsDirectoryPath(x));

                var existingDirectoryPathList = Directory.GetDirectories(databaseDirectoryPath, "*.*", SearchOption.TopDirectoryOnly).Where(x => Regex.IsMatch(Path.GetFileName(x), "^[a-f0-9A-F]{32}$", RegexOptions.None));

                foreach (var directoryPath in existingDirectoryPathList.Except(possibleDirectoryPathList, StringComparer.InvariantCultureIgnoreCase))
                {
                    try
                    {
                        Directory.Delete(directoryPath, true);
                    }
                    catch
                    {
                    }
                }
            }
        }

        private string TreeView_ExportNodeToRtf(TreeNode rootNode)
        {
            var document = new Controls.RichTextBoxEx { Rtf = null }; this.TreeView_ExportNodeToRtf(document, rootNode, 1, this.TreeView_GetMaxTreeNodeDepth(rootNode)); return document.Rtf;
        }

        private void TreeView_ExportNodeToRtf(RichTextBox document, TreeNode treeNode, int treeNodeDepth, int maxTreeNodeDepth)
        {
            var titleFontSize = 27 + ((maxTreeNodeDepth - treeNodeDepth) * 8);

            document.SelectedRtf = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1040{\fonttbl{\f0\fnil\fcharset0 Calibri;}{\f1\fnil\fcharset0 Consolas;}}\viewkind4\uc1\pard\sl240\slmult1\b\f0\fs" + titleFontSize + " " + treeNode.Text + @"\b0\f0\fs23\par\par}";

            var treeNodeDataNotes = this.TreeView_GetExistingNodeDataNotes(treeNode);

            if (!string.IsNullOrEmpty(treeNodeDataNotes))
            {
                document.SelectedRtf = treeNodeDataNotes;
            }

            foreach (TreeNode childTreeNode in treeNode.Nodes)
            {
                this.TreeView_ExportNodeToRtf(document, childTreeNode, treeNodeDepth + 1, maxTreeNodeDepth);
            }
        }

        private string TreeView_ExportNodeToText(TreeNode rootNode)
        {
            var document = new StringBuilder(); this.TreeView_ExportNodeToText(document, rootNode, 1); return document.ToString();
        }

        private void TreeView_ExportNodeToText(StringBuilder document, TreeNode treeNode, int treeNodeDepth)
        {
            var treeNodeDataNotes = this.TreeView_GetExistingNodeDataNotes(treeNode);

            var attachmentsDirectoryPath = this.TreeView_GetExistingNodeDataAttachmentsDirectoryPath(treeNode);

            document.Append(((treeNodeDepth > 1) ? new string(' ', treeNodeDepth - 1) : string.Empty) + treeNode.Text);
            document.Append("\t");
            document.Append(!string.IsNullOrEmpty(treeNodeDataNotes) ? Convert.ToBase64String(Encoding.UTF8.GetBytes(treeNodeDataNotes)) : string.Empty);
            document.Append("\t");
            document.Append(treeNode.Name);
            document.Append("\t");

            switch (treeNode.ForeColor.Name)
            {
                case "Black": document.Append("Black"); break;
                case "Blue": document.Append("Blue"); break;
                case "Gray": document.Append("Gray"); break;
                case "Green": document.Append("Green"); break;
                case "Red": document.Append("Red"); break;
                case "White": document.Append("White"); break;
                default: document.Append(string.Empty); break;
            }

            document.Append("\t");

            switch (treeNode.BackColor.Name)
            {
                case "Black": document.Append("Black"); break;
                case "Blue": document.Append("Blue"); break;
                case "Gray": document.Append("Gray"); break;
                case "Green": document.Append("Green"); break;
                case "Red": document.Append("Red"); break;
                case "White": document.Append("White"); break;
                default: document.Append(string.Empty); break;
            }

            document.Append("\t");
            document.Append((treeNode.NodeFont != null) ? ((int)treeNode.NodeFont.Style).ToString() : string.Empty);

            if (Directory.Exists(attachmentsDirectoryPath))
            {
                foreach (var filePath in Directory.GetFiles(attachmentsDirectoryPath))
                {
                    document.Append("\t");
                    document.Append(Path.GetFileName(filePath));
                    document.Append("\t");
                    document.Append(Convert.ToBase64String(File.ReadAllBytes(filePath)));
                }
            }

            document.AppendLine();

            foreach (TreeNode childTreeNode in treeNode.Nodes)
            {
                this.TreeView_ExportNodeToText(document, childTreeNode, treeNodeDepth + 1);
            }
        }

        private TreeNode TreeView_FindNodeByName(string nodeName, TreeNodeCollection treeNodeCollection = null)
        {
            foreach (TreeNode treeNode in (treeNodeCollection ?? this.TreeView.Nodes))
            {
                if (treeNode.Name == nodeName)
                {
                    return treeNode;
                }

                var foundNode = this.TreeView_FindNodeByName(nodeName, treeNode.Nodes);

                if (foundNode != null)
                {
                    return foundNode;
                }
            }

            return null;
        }

        private TreeNode TreeView_FindNodeByRegex(TreeNode fromNode, Regex findWhat, FindNodeWindowLookIn lookIn, FindNodeWindowDirection findDirection)
        {
            var treeList = this.TreeView_GetTreeExpandedAsList();

            var fromList = treeList.IndexOf(fromNode);

            if (!(fromList > -1))
            {
                return null;
            }

            switch (lookIn)
            {
                case FindNodeWindowLookIn.Tree:

                    switch (findDirection)
                    {
                        case FindNodeWindowDirection.Previous:

                            for (int i = fromList - 1; i > -1; i--)
                            {
                                if (findWhat.IsMatch(treeList[i].Text))
                                {
                                    return treeList[i];
                                }
                            }

                            break;

                        case FindNodeWindowDirection.Next:

                            for (int i = fromList + 1; i < treeList.Count; i++)
                            {
                                if (findWhat.IsMatch(treeList[i].Text))
                                {
                                    return treeList[i];
                                }
                            }

                            break;
                    }

                    break;

                case FindNodeWindowLookIn.TreeAndNotes:

                    switch (findDirection)
                    {
                        case FindNodeWindowDirection.Previous:

                            for (int i = fromList - 1; i > -1; i--)
                            {
                                if (findWhat.IsMatch(treeList[i].Text))
                                {
                                    return treeList[i];
                                }

                                var nodeDataNotes = this.TreeView_GetExistingNodeDataNotes(treeList[i]);

                                if (!string.IsNullOrEmpty(nodeDataNotes) && findWhat.IsMatch(nodeDataNotes))
                                {
                                    return treeList[i];
                                }
                            }

                            break;

                        case FindNodeWindowDirection.Next:

                            for (int i = fromList + 1; i < treeList.Count; i++)
                            {
                                if (findWhat.IsMatch(treeList[i].Text))
                                {
                                    return treeList[i];
                                }

                                var nodeDataNotes = this.TreeView_GetExistingNodeDataNotes(treeList[i]);

                                if (!string.IsNullOrEmpty(nodeDataNotes) && findWhat.IsMatch(nodeDataNotes))
                                {
                                    return treeList[i];
                                }
                            }

                            break;
                    }

                    break;
            }

            return null;
        }

        private string TreeView_GetDatabaseDirectoryPath()
        {
            return Application.StartupPath + @"\Database";
        }

        private string TreeView_GetDatabaseFilePath()
        {
            return this.TreeView_GetDatabaseDirectoryPath() + @"\Oracle.db";
        }

        private int TreeView_GetExistingNodeDataAttachmentsCount(TreeNode node)
        {
            var dataAttachmentsDirectoryPath = this.TreeView_GetExistingNodeDataAttachmentsDirectoryPath(node);

            if (!Directory.Exists(dataAttachmentsDirectoryPath))
            {
                return 0;
            }

            return Directory.EnumerateFiles(dataAttachmentsDirectoryPath, "*.*", SearchOption.AllDirectories).Count();
        }

        private string TreeView_GetExistingNodeDataAttachmentsDirectoryPath(TreeNode node)
        {
            return this.TreeView_GetDatabaseDirectoryPath() + @"\" + node.Name;
        }

        private string TreeView_GetExistingNodeDataNotes(TreeNode treeNode)
        {
            return treeNode.Tag is string ? treeNode.Tag as string : treeNode.Tag is byte[]? Utilities.CompressUtility.DecompressString(treeNode.Tag as byte[]) : null;
        }

        private int TreeView_GetMaxTreeNodeDepth(TreeNode rootNode)
        {
            var maxTreeNodeDepth = 1; this.TreeView_GetMaxTreeNodeDepth(rootNode, 1, ref maxTreeNodeDepth); return maxTreeNodeDepth;
        }

        private void TreeView_GetMaxTreeNodeDepth(TreeNode treeNode, int treeNodeDepth, ref int maxTreeNodeDepth)
        {
            if (treeNodeDepth > maxTreeNodeDepth)
            {
                maxTreeNodeDepth = treeNodeDepth;
            }

            foreach (TreeNode childTreeNode in treeNode.Nodes)
            {
                this.TreeView_GetMaxTreeNodeDepth(childTreeNode, treeNodeDepth + 1, ref maxTreeNodeDepth);
            }
        }

        private string TreeView_GetNewNodeName()
        {
            return Guid.NewGuid().ToString("N");
        }

        private string TreeView_GetNewNodeText()
        {
            return string.Empty;
        }

        private List<TreeNode> TreeView_GetTreeExpandedAsList()
        {
            var treeList = new List<TreeNode>();

            foreach (TreeNode treeNode in this.TreeView.Nodes)
            {
                treeList.Add(treeNode);

                this.TreeView_GetTreeExpandedAsList(treeList, treeNode);
            }

            return treeList;
        }

        private List<TreeNode> TreeView_GetTreeExpandedAsList(List<TreeNode> treeList, TreeNode treeNode)
        {
            foreach (TreeNode childTreeNode in treeNode.Nodes)
            {
                treeList.Add(childTreeNode);

                this.TreeView_GetTreeExpandedAsList(treeList, childTreeNode);
            }

            return treeList;
        }

        private void TreeView_ImportNodeFromText(TreeNode rootNode, string text)
        {
            var depthList = new List<TreeNode> { rootNode };

            using (var stringReader = new StringReader(text))
            {
                string line; while ((line = stringReader.ReadLine()) != null)
                {
                    int depth = 1;

                    var depthMatch = Regex.Match(line, "^( )+", RegexOptions.None);

                    if (depthMatch.Success)
                    {
                        depth = 1 + depthMatch.Groups[0].Captures[0].Value.Length;
                    }

                    if (depth > (depthList.Count + 1))
                    {
                        continue;
                    }

                    while (depth < depthList.Count)
                    {
                        depthList.RemoveAt(depthList.Count - 1);
                    }

                    var data = line.Split('\t');

                    var fNum = 6;

                    var f001 = data[0].Trim();
                    var f002 = (data.Length > 1) ? data[1] : null;
                    var f003 = (data.Length > 2) ? data[2] : null;
                    var f004 = (data.Length > 3) ? data[3] : null;
                    var f005 = (data.Length > 4) ? data[4] : null;
                    var f006 = (data.Length > 5) ? data[5] : null;

                    var treeNode = depthList[depthList.Count - 1].Nodes.Add((!string.IsNullOrEmpty(f003) ? f003 : this.TreeView_GetNewNodeName()), f001);

                    if (!string.IsNullOrEmpty(f002))
                    {
                        this.TreeView_SetExistingNodeDataNotes(treeNode, Encoding.UTF8.GetString(Convert.FromBase64String(f002)));
                    }

                    if (!string.IsNullOrEmpty(f004))
                    {
                        switch (f004)
                        {
                            case "Black": treeNode.ForeColor = Color.Black; break;
                            case "Blue": treeNode.ForeColor = Color.Blue; break;
                            case "Gray": treeNode.ForeColor = Color.Gray; break;
                            case "Green": treeNode.ForeColor = Color.Green; break;
                            case "Red": treeNode.ForeColor = Color.Red; break;
                            case "White": treeNode.ForeColor = Color.White; break;
                        }
                    }

                    if (!string.IsNullOrEmpty(f005))
                    {
                        switch (f005)
                        {
                            case "Black": treeNode.BackColor = Color.Black; break;
                            case "Blue": treeNode.BackColor = Color.Blue; break;
                            case "Gray": treeNode.BackColor = Color.Gray; break;
                            case "Green": treeNode.BackColor = Color.Green; break;
                            case "Red": treeNode.BackColor = Color.Red; break;
                            case "White": treeNode.BackColor = Color.White; break;
                        }
                    }

                    if (!string.IsNullOrEmpty(f006))
                    {
                        treeNode.NodeFont = new Font(this.TreeView.Font, (FontStyle)int.Parse(f006));
                    }

                    if ((data.Length > fNum) && (((data.Length - fNum) % 2) == 0))
                    {
                        var attachmentsDirectoryPath = this.TreeView_GetExistingNodeDataAttachmentsDirectoryPath(treeNode);

                        if (!Directory.Exists(attachmentsDirectoryPath))
                        {
                            Directory.CreateDirectory(attachmentsDirectoryPath);
                        }

                        for (int i = 0; i < ((data.Length - fNum) / 2); i++)
                        {
                            File.WriteAllBytes(attachmentsDirectoryPath + @"\" + data[fNum + (i * 2)], Convert.FromBase64String(data[fNum + 1 + (i * 2)]));
                        }
                    }

                    depthList.Add(treeNode);
                }
            }
        }

        private void TreeView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:

                    if (!e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                if (this.TreeView.SelectedNodes.Any())
                                {
                                    var selectedNodesCount = this.TreeView.SelectedNodes.Count;

                                    this.TreeView_Update
                                    (
                                        () =>
                                        {
                                            for (int i = 0; i < selectedNodesCount; i++)
                                            {
                                                this.TreeView.Nodes.Remove(this.TreeView.SelectedNodes[i]);

                                                this.TreeView.SelectedNode.Nodes.Add(this.TreeView.SelectedNodes[i]);
                                            }
                                        }
                                    );

                                    this.TreeView.SelectedNodes.Clear();

                                    this.MainWindow_UpdateStatusInfo((selectedNodesCount == 1) ? "Node moved successfully" : string.Format("{0:N0} nodes moved successfully", selectedNodesCount));
                                }
                                else
                                {
                                    this.TreeView_Update
                                    (
                                        () =>
                                        {
                                            this.TreeView.SelectedNode = this.TreeView.SelectedNode.Nodes.Add(this.TreeView_GetNewNodeName(), this.TreeView_GetNewNodeText()); this.TreeView.SelectedNode.EnsureVisible();

                                            this.TreeView.SelectedNode.BeginEdit();
                                        }
                                    );
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.F2:

                    if (!e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.TreeView_Update
                                (
                                    () =>
                                    {
                                        this.TreeView.SelectedNode.BeginEdit();
                                    }
                                );

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.F3:

                    if (!e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                if (this.TreeView.SelectedNode.Parent != null)
                                {
                                    if (this.TreeView.SelectedNodes.Any())
                                    {
                                        var selectedNodesCount = this.TreeView.SelectedNodes.Count;

                                        this.TreeView_Update
                                        (
                                            () =>
                                            {
                                                for (int i = 0; i < selectedNodesCount; i++)
                                                {
                                                    this.TreeView.Nodes.Remove(this.TreeView.SelectedNodes[i]);

                                                    this.TreeView.SelectedNode.Parent.Nodes.Insert(this.TreeView.SelectedNode.Index, this.TreeView.SelectedNodes[i]);
                                                }
                                            }
                                        );

                                        this.TreeView.SelectedNodes.Clear();

                                        this.MainWindow_UpdateStatusInfo((selectedNodesCount == 1) ? "Node moved successfully" : string.Format("{0:N0} nodes moved successfully", selectedNodesCount));
                                    }
                                    else
                                    {
                                        this.TreeView_Update
                                        (
                                            () =>
                                            {
                                                this.TreeView.SelectedNode = this.TreeView.SelectedNode.Parent.Nodes.Insert(this.TreeView.SelectedNode.Index, this.TreeView_GetNewNodeName(), this.TreeView_GetNewNodeText()); this.TreeView.SelectedNode.EnsureVisible();

                                                this.TreeView.SelectedNode.BeginEdit();
                                            }
                                        );
                                    }
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.F4:

                    if (!e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                if (this.TreeView.SelectedNode.Parent != null)
                                {
                                    if (this.TreeView.SelectedNodes.Any())
                                    {
                                        var selectedNodesCount = this.TreeView.SelectedNodes.Count;

                                        this.TreeView_Update
                                        (
                                            () =>
                                            {
                                                for (int i = 0; i < selectedNodesCount; i++)
                                                {
                                                    this.TreeView.Nodes.Remove(this.TreeView.SelectedNodes[i]);

                                                    this.TreeView.SelectedNode.Parent.Nodes.Insert(this.TreeView.SelectedNode.Index + 1 + i, this.TreeView.SelectedNodes[i]);
                                                }
                                            }
                                        );

                                        this.TreeView.SelectedNodes.Clear();

                                        this.MainWindow_UpdateStatusInfo((selectedNodesCount == 1) ? "Node moved successfully" : string.Format("{0:N0} nodes moved successfully", selectedNodesCount));
                                    }
                                    else
                                    {
                                        this.TreeView_Update
                                        (
                                            () =>
                                            {
                                                this.TreeView.SelectedNode = this.TreeView.SelectedNode.Parent.Nodes.Insert(this.TreeView.SelectedNode.Index + 1, this.TreeView_GetNewNodeName(), this.TreeView_GetNewNodeText()); this.TreeView.SelectedNode.EnsureVisible();

                                                this.TreeView.SelectedNode.BeginEdit();
                                            }
                                        );
                                    }
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.F12:

                    if (!e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                if (this.TreeView.SelectedNode.Nodes.Count > 1)
                                {
                                    this.TreeView_Update
                                    (
                                        () =>
                                        {
                                            var j = this.TreeView.SelectedNode.Nodes.Count - 1;

                                            while (j > 0)
                                            {
                                                var q = true;

                                                for (int i = 0; i < j; i++)
                                                {
                                                    var a = this.TreeView.SelectedNode.Nodes[i];
                                                    var b = this.TreeView.SelectedNode.Nodes[i + 1];

                                                    if (string.Compare(a.Text, b.Text) > 0)
                                                    {
                                                        this.TreeView.SelectedNode.Nodes.RemoveAt(i);
                                                        this.TreeView.SelectedNode.Nodes.RemoveAt(i);

                                                        this.TreeView.SelectedNode.Nodes.Insert(i, a);
                                                        this.TreeView.SelectedNode.Nodes.Insert(i, b);

                                                        q = false;
                                                    }
                                                }

                                                if (q)
                                                {
                                                    break;
                                                }

                                                j--;
                                            }
                                        }
                                    );
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (!e.Alt)
                            {
                                if (this.TreeView.SelectedNode.Nodes.Count > 1)
                                {
                                    this.TreeView_Update
                                    (
                                        () =>
                                        {
                                            var j = this.TreeView.SelectedNode.Nodes.Count - 1;

                                            while (j > 0)
                                            {
                                                var q = true;

                                                for (int i = 0; i < j; i++)
                                                {
                                                    var a = this.TreeView.SelectedNode.Nodes[i];
                                                    var b = this.TreeView.SelectedNode.Nodes[i + 1];

                                                    if (string.Compare(a.Text, b.Text) < 0)
                                                    {
                                                        this.TreeView.SelectedNode.Nodes.RemoveAt(i);
                                                        this.TreeView.SelectedNode.Nodes.RemoveAt(i);

                                                        this.TreeView.SelectedNode.Nodes.Insert(i, a);
                                                        this.TreeView.SelectedNode.Nodes.Insert(i, b);

                                                        q = false;
                                                    }
                                                }

                                                if (q)
                                                {
                                                    break;
                                                }

                                                j--;
                                            }
                                        }
                                    );
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.Enter:

                    if (!e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.TreeView_Update
                                (
                                    () =>
                                    {
                                        if (this.TreeView.SelectedNode.IsExpanded) this.TreeView.SelectedNode.Collapse(); else this.TreeView.SelectedNode.ExpandAll();
                                    }
                                );

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.Space:

                    if (!e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                if (this.TreeView.SelectedNode.Parent != null)
                                {
                                    if (!this.TreeView.SelectedNodes.Contains(this.TreeView.SelectedNode))
                                    {
                                        this.TreeView.SelectedNodes.Add(this.TreeView.SelectedNode);
                                    }

                                    this.MainWindow_UpdateStatusInfo((this.TreeView.SelectedNodes.Count == 1) ? "There is 1 node selected" : string.Format("There are {0:N0} nodes selected", this.TreeView.SelectedNodes.Count));
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (!e.Alt)
                            {
                                if (this.TreeView.SelectedNode.Nodes.Count > 0)
                                {
                                    foreach (TreeNode treeNode in this.TreeView.SelectedNode.Nodes)
                                    {
                                        if (!this.TreeView.SelectedNodes.Contains(this.TreeView.SelectedNode))
                                        {
                                            this.TreeView.SelectedNodes.Add(treeNode);
                                        }
                                    }

                                    this.MainWindow_UpdateStatusInfo((this.TreeView.SelectedNodes.Count == 1) ? "There is 1 node selected" : string.Format("There are {0:N0} nodes selected", this.TreeView.SelectedNodes.Count));
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }
                    else
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                if (this.TreeView.SelectedNodes.Any())
                                {
                                    this.TreeView.SelectedNodes.Clear();
                                }

                                this.MainWindow_UpdateStatusInfo("There are 0 nodes selected");

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.Delete:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                if (this.TreeView.SelectedNodes.Any())
                                {
                                    new MessageWindow(this, "Deleting a node when there are other nodes selected is not allowed.", "Delete node...", MessageWindowType.Information).ShowDialog();
                                }
                                else if (this.TreeView.SelectedNode.Parent != null)
                                {
                                    this.TreeView_Update
                                    (
                                        () =>
                                        {
                                            this.TreeView.SelectedNode.Remove();
                                        }
                                    );
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.B:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                if (this.TreeView.SelectedNode.NodeFont != null)
                                {
                                    this.TreeView_Update
                                    (
                                        () =>
                                        {
                                            this.TreeView.SelectedNode.NodeFont = this.TreeView.SelectedNode.NodeFont.Bold ? new Font(this.TreeView.SelectedNode.NodeFont, this.TreeView.SelectedNode.NodeFont.Style ^ FontStyle.Bold) : new Font(this.TreeView.SelectedNode.NodeFont, this.TreeView.SelectedNode.NodeFont.Style | FontStyle.Bold);
                                        }
                                    );
                                }
                                else
                                {
                                    this.TreeView_Update
                                    (
                                        () =>
                                        {
                                            this.TreeView.SelectedNode.NodeFont = new Font(this.TreeView.Font, this.TreeView.Font.Style | FontStyle.Bold);
                                        }
                                    );
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                this.SaveFileDialog.Title = "Export node as...";

                                this.SaveFileDialog.Filter = "Text file (*.txt)|*.txt|Rich Text Format file (*.rtf)|*.rtf"; this.SaveFileDialog.FilterIndex = 0;

                                if (this.SaveFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    switch (this.SaveFileDialog.FilterIndex)
                                    {
                                        case 1:

                                            this.MainWindow_UpdateStatusInfo("Processing...");

                                            File.WriteAllText(this.SaveFileDialog.FileName, this.TreeView_ExportNodeToText(this.TreeView.SelectedNode));

                                            this.MainWindow_UpdateStatusInfo("Export completed successfully");

                                            break;

                                        case 2:

                                            this.MainWindow_UpdateStatusInfo("Processing...");

                                            File.WriteAllText(this.SaveFileDialog.FileName, this.TreeView_ExportNodeToRtf(this.TreeView.SelectedNode));

                                            this.MainWindow_UpdateStatusInfo("Export completed successfully");

                                            break;
                                    }
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (!e.Alt)
                            {
                                this.OpenFileDialog.Title = "Import node from...";

                                this.OpenFileDialog.Filter = "Text file (*.txt)|*.txt"; this.SaveFileDialog.FilterIndex = 0;

                                if (this.OpenFileDialog.ShowDialog() == DialogResult.OK)
                                {
                                    switch (this.OpenFileDialog.FilterIndex)
                                    {
                                        case 1:

                                            this.MainWindow_UpdateStatusInfo("Processing...");

                                            this.TreeView_Update
                                            (
                                                () =>
                                                {
                                                    this.TreeView_ImportNodeFromText(this.TreeView.SelectedNode, File.ReadAllText(this.OpenFileDialog.FileName));
                                                }
                                            );

                                            this.MainWindow_UpdateStatusInfo("Import completed successfully");

                                            break;
                                    }
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.F:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                if (new FindNodeWindow(this).ShowDialog() == DialogResult.OK)
                                {
                                    var selectedNode = this.TreeView_FindNodeByRegex(this.TreeView.SelectedNode, FindNodeWindow.FindWhat, FindNodeWindow.LookIn, FindNodeWindow.Direction);

                                    if (selectedNode != null)
                                    {
                                        this.TreeView_Update
                                        (
                                            () =>
                                            {
                                                this.TreeView.SelectedNode = selectedNode; this.TreeView.SelectedNode.EnsureVisible();
                                            }
                                        );
                                    }
                                    else
                                    {
                                        new MessageWindow(this, "No nodes matching the specified criteria have been found.", "Find node...", MessageWindowType.Information).ShowDialog();
                                    }
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                        else
                        {
                            if (!e.Alt)
                            {
                                if (FindNodeWindow.FindWhat != null)
                                {
                                    var selectedNode = this.TreeView_FindNodeByRegex(this.TreeView.SelectedNode, FindNodeWindow.FindWhat, FindNodeWindow.LookIn, FindNodeWindow.Direction);

                                    if (selectedNode != null)
                                    {
                                        this.TreeView_Update
                                        (
                                            () =>
                                            {
                                                this.TreeView.SelectedNode = selectedNode; this.TreeView.SelectedNode.EnsureVisible();
                                            }
                                        );
                                    }
                                    else
                                    {
                                        new MessageWindow(this, "No nodes matching the specified criteria have been found.", "Find node...", MessageWindowType.Information).ShowDialog();
                                    }
                                }
                                else
                                {
                                    if (new FindNodeWindow(this).ShowDialog() == DialogResult.OK)
                                    {
                                        var selectedNode = this.TreeView_FindNodeByRegex(this.TreeView.SelectedNode, FindNodeWindow.FindWhat, FindNodeWindow.LookIn, FindNodeWindow.Direction);

                                        if (selectedNode != null)
                                        {
                                            this.TreeView_Update
                                            (
                                                () =>
                                                {
                                                    this.TreeView.SelectedNode = selectedNode; this.TreeView.SelectedNode.EnsureVisible();
                                                }
                                            );
                                        }
                                        else
                                        {
                                            new MessageWindow(this, "No nodes matching the specified criteria have been found.", "Find node...", MessageWindowType.Information).ShowDialog();
                                        }
                                    }
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.I:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                if (this.TreeView.SelectedNode.NodeFont != null)
                                {
                                    this.TreeView_Update
                                    (
                                        () =>
                                        {
                                            this.TreeView.SelectedNode.NodeFont = this.TreeView.SelectedNode.NodeFont.Italic ? new Font(this.TreeView.SelectedNode.NodeFont, this.TreeView.SelectedNode.NodeFont.Style ^ FontStyle.Italic) : new Font(this.TreeView.SelectedNode.NodeFont, this.TreeView.SelectedNode.NodeFont.Style | FontStyle.Italic);
                                        }
                                    );
                                }
                                else
                                {
                                    this.TreeView_Update
                                    (
                                        () =>
                                        {
                                            this.TreeView.SelectedNode.NodeFont = new Font(this.TreeView.Font, this.TreeView.Font.Style | FontStyle.Italic);
                                        }
                                    );
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.K:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                if (this.TreeView.SelectedNode.NodeFont != null)
                                {
                                    this.TreeView_Update
                                    (
                                        () =>
                                        {
                                            this.TreeView.SelectedNode.NodeFont = this.TreeView.SelectedNode.NodeFont.Strikeout ? new Font(this.TreeView.SelectedNode.NodeFont, this.TreeView.SelectedNode.NodeFont.Style ^ FontStyle.Strikeout) : new Font(this.TreeView.SelectedNode.NodeFont, this.TreeView.SelectedNode.NodeFont.Style | FontStyle.Strikeout);
                                        }
                                    );
                                }
                                else
                                {
                                    this.TreeView_Update
                                    (
                                        () =>
                                        {
                                            this.TreeView.SelectedNode.NodeFont = new Font(this.TreeView.Font, this.TreeView.Font.Style | FontStyle.Strikeout);
                                        }
                                    );
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.T:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                Clipboard.SetText("gopher://Goto:" + this.TreeView.SelectedNode.Name);

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.U:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (!e.Alt)
                            {
                                if (this.TreeView.SelectedNode.NodeFont != null)
                                {
                                    this.TreeView_Update
                                    (
                                        () =>
                                        {
                                            this.TreeView.SelectedNode.NodeFont = this.TreeView.SelectedNode.NodeFont.Underline ? new Font(this.TreeView.SelectedNode.NodeFont, this.TreeView.SelectedNode.NodeFont.Style ^ FontStyle.Underline) : new Font(this.TreeView.SelectedNode.NodeFont, this.TreeView.SelectedNode.NodeFont.Style | FontStyle.Underline);
                                        }
                                    );
                                }
                                else
                                {
                                    this.TreeView_Update
                                    (
                                        () =>
                                        {
                                            this.TreeView.SelectedNode.NodeFont = new Font(this.TreeView.Font, this.TreeView.Font.Style | FontStyle.Underline);
                                        }
                                    );
                                }

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D0:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.TreeView_Update
                                (
                                    () =>
                                    {
                                        this.TreeView.SelectedNode.ForeColor = this.TreeView.ForeColor;
                                        this.TreeView.SelectedNode.BackColor = this.TreeView.BackColor;
                                    }
                                );

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D1:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.TreeView_Update
                                (
                                    () =>
                                    {
                                        this.TreeView.SelectedNode.ForeColor = Color.Red;
                                        this.TreeView.SelectedNode.BackColor = this.TreeView.BackColor;
                                    }
                                );

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D2:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.TreeView_Update
                                (
                                    () =>
                                    {
                                        this.TreeView.SelectedNode.ForeColor = Color.Green;
                                        this.TreeView.SelectedNode.BackColor = this.TreeView.BackColor;
                                    }
                                );

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D3:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.TreeView_Update
                                (
                                    () =>
                                    {
                                        this.TreeView.SelectedNode.ForeColor = Color.Blue;
                                        this.TreeView.SelectedNode.BackColor = this.TreeView.BackColor;
                                    }
                                );

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D4:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.TreeView_Update
                                (
                                    () =>
                                    {
                                        this.TreeView.SelectedNode.ForeColor = Color.Gray;
                                        this.TreeView.SelectedNode.BackColor = this.TreeView.BackColor;
                                    }
                                );

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D5:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.TreeView_Update
                                (
                                    () =>
                                    {
                                        this.TreeView.SelectedNode.ForeColor = Color.White;
                                        this.TreeView.SelectedNode.BackColor = Color.Black;
                                    }
                                );

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D6:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.TreeView_Update
                                (
                                    () =>
                                    {
                                        this.TreeView.SelectedNode.ForeColor = Color.White;
                                        this.TreeView.SelectedNode.BackColor = Color.Red;
                                    }
                                );

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D7:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.TreeView_Update
                                (
                                    () =>
                                    {
                                        this.TreeView.SelectedNode.ForeColor = Color.White;
                                        this.TreeView.SelectedNode.BackColor = Color.Green;
                                    }
                                );

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D8:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.TreeView_Update
                                (
                                    () =>
                                    {
                                        this.TreeView.SelectedNode.ForeColor = Color.White;
                                        this.TreeView.SelectedNode.BackColor = Color.Blue;
                                    }
                                );

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;

                case Keys.D9:

                    if (e.Control)
                    {
                        if (!e.Shift)
                        {
                            if (e.Alt)
                            {
                                this.TreeView_Update
                                (
                                    () =>
                                    {
                                        this.TreeView.SelectedNode.ForeColor = Color.White;
                                        this.TreeView.SelectedNode.BackColor = Color.Gray;
                                    }
                                );

                                e.SuppressKeyPress = true;

                                e.Handled = true;
                            }
                        }
                    }

                    break;
            }
        }

        private void TreeView_LoadNode(TreeNode treeNode)
        {
            this.RichTextBox.Rtf = this.TreeView_GetExistingNodeDataNotes(treeNode);

            this.RichTextBox.Modified = false;
        }

        private void TreeView_LoadTree()
        {
            var databaseFilePath = this.TreeView_GetDatabaseFilePath();

            this.TreeView_Update(() =>
            {
                if (File.Exists(databaseFilePath))
                {
                    using (var fileStream = new FileStream(databaseFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        this.TreeView.Nodes.AddRange((TreeNode[])(new BinaryFormatter().Deserialize(fileStream)));
                    }

                    foreach (TreeNode treeNode in this.TreeView.Nodes)
                    {
                        treeNode.Expand();
                    }
                }

                if (this.TreeView.Nodes.Count == 0)
                {
                    this.TreeView.Nodes.Add(this.TreeView_GetNewNodeName(), "Root");
                }
            });
        }

        private void TreeView_SaveNode(TreeNode treeNode)
        {
            if (this.RichTextBox.Modified)
            {
                this.TreeView_SetExistingNodeDataNotes(treeNode, this.RichTextBox.Rtf);

                this.RichTextBox.Modified = false;
            }
        }

        private void TreeView_SaveTree()
        {
            var databaseDirectoryPath = this.TreeView_GetDatabaseDirectoryPath();

            if (!Directory.Exists(databaseDirectoryPath))
            {
                Directory.CreateDirectory(databaseDirectoryPath);
            }

            var databaseFilePath = this.TreeView_GetDatabaseFilePath();

            using (var fileStream = new FileStream(databaseFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read))
            {
                new BinaryFormatter().Serialize(fileStream, this.TreeView.Nodes.Cast<TreeNode>().ToArray());
            }
        }

        private void TreeView_SetExistingNodeDataNotes(TreeNode treeNode, string text)
        {
            treeNode.Tag = Utilities.CompressUtility.CompressString(text);
        }

        private void TreeView_Update(Action action)
        {
            this.TreeView.BeginUpdate();

            try
            {
                action();
            }
            finally
            {
                this.TreeView.EndUpdate();
            }
        }
    }
}