namespace Oracle
{
    partial class MainWindow
    {
        private System.ComponentModel.IContainer Components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.Components != null))
            {
                this.Components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));

            this.TreeViewAndRichTextBoxSplitContainer = new System.Windows.Forms.SplitContainer();
            this.TreeView = new Oracle.Controls.TreeViewEx();
            this.RichTextBox = new Oracle.Controls.RichTextBoxEx();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();

            ((System.ComponentModel.ISupportInitialize)(this.TreeViewAndRichTextBoxSplitContainer)).BeginInit();

            this.TreeViewAndRichTextBoxSplitContainer.Panel1.SuspendLayout();
            this.TreeViewAndRichTextBoxSplitContainer.Panel2.SuspendLayout();
            this.TreeViewAndRichTextBoxSplitContainer.SuspendLayout();
            this.SuspendLayout();

            this.TreeViewAndRichTextBoxSplitContainer.BackColor = System.Drawing.Color.LightGray;
            this.TreeViewAndRichTextBoxSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeViewAndRichTextBoxSplitContainer.Location = new System.Drawing.Point(0, 0);

            this.TreeViewAndRichTextBoxSplitContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.TreeViewAndRichTextBoxSplitContainer.Panel1.Controls.Add(this.TreeView);
            this.TreeViewAndRichTextBoxSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);

            this.TreeViewAndRichTextBoxSplitContainer.Panel2.BackColor = System.Drawing.Color.White;
            this.TreeViewAndRichTextBoxSplitContainer.Panel2.Controls.Add(this.RichTextBox);
            this.TreeViewAndRichTextBoxSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);

            this.TreeViewAndRichTextBoxSplitContainer.SplitterDistance = 300;
            this.TreeViewAndRichTextBoxSplitContainer.SplitterWidth = 3;
            this.TreeViewAndRichTextBoxSplitContainer.TabStop = false;

            this.TreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView.Font = new System.Drawing.Font(TreeViewStandardFontFamily, TreeViewStandardFontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeView.HideSelection = false;
            this.TreeView.LabelEdit = true;
            this.TreeView.Location = new System.Drawing.Point(5, 5);
            this.TreeView.Margin = new System.Windows.Forms.Padding(0);
            this.TreeView.Size = new System.Drawing.Size(290, 552);
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            this.TreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TreeView_KeyDown);

            this.RichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RichTextBox.Font = new System.Drawing.Font(RichTextBoxStandardFontFamily, RichTextBoxStandardFontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBox.AutoWordSelection = true;
            this.RichTextBox.HideSelection = false;
            this.RichTextBox.WordWrap = true;
            this.RichTextBox.Multiline = true;
            this.RichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.RichTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.RichTextBox_LinkClicked);
            this.RichTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RichTextBox_KeyDown);
            this.RichTextBox.Leave += new System.EventHandler(this.RichTextBox_Leave);

            this.SaveFileDialog.Title = "Save file...";
            this.OpenFileDialog.Title = "Open file...";

            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.DoubleBuffered = true;
            this.Font = Program.StandardFont;
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Controls.Add(this.TreeViewAndRichTextBoxSplitContainer);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainWindow_FormClosed);
            
            this.TreeViewAndRichTextBoxSplitContainer.Panel1.ResumeLayout(false);
            this.TreeViewAndRichTextBoxSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TreeViewAndRichTextBoxSplitContainer)).EndInit();
            this.TreeViewAndRichTextBoxSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.SplitContainer TreeViewAndRichTextBoxSplitContainer;
        private Oracle.Controls.TreeViewEx TreeView;
        private Oracle.Controls.RichTextBoxEx RichTextBox;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
    }
}