using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Oracle
{
    public partial class FindNodeWindow : Form
    {
        private const string InvalidRegularExpressionErrorMessage = "The regular expression you entered is not valid.";

        public FindNodeWindow(Form form)
        {
            this.InitializeComponent();

            this.Left = form.Left + 32; this.Top = form.Top + 48;
        }

        public static FindNodeWindowDirection Direction { get; private set; }

        public static Regex FindWhat { get; private set; }

        public static List<string> FindWhatHistory { get; private set; }

        public static FindNodeWindowLookIn LookIn { get; private set; }

        public static bool MatchCase { get; private set; }

        public static bool UseRegularExpressions { get; private set; }

        private void FindNextButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.FindNodeWindow_SetFindProperties(FindNodeWindowDirection.Next);

                this.DialogResult = DialogResult.OK;
            }
            catch
            {
            }
        }

        private void FindNodeWindow_SetFindProperties(FindNodeWindowDirection direction)
        {
            var findWhat = this.FindWhatComboBox.Text;

            FindWhatHistory.Insert(0, findWhat);

            FindWhat = new Regex(this.UseRegularExpressionsCheckBox.Checked ? findWhat : Regex.Escape(findWhat), RegexOptions.Singleline | (!this.MatchCaseCheckBox.Checked ? RegexOptions.IgnoreCase : RegexOptions.None));

            LookIn = (FindNodeWindowLookIn)this.LookInComboBox.SelectedIndex;

            MatchCase = this.MatchCaseCheckBox.Checked;

            UseRegularExpressions = this.UseRegularExpressionsCheckBox.Checked;

            Direction = direction;
        }

        private void FindPreviousButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.FindNodeWindow_SetFindProperties(FindNodeWindowDirection.Previous);

                this.DialogResult = DialogResult.OK;
            }
            catch
            {
            }
        }

        private void FindWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;

                e.SuppressKeyPress = true;

                e.Handled = true;
            }
        }

        private void FindWindow_Load(object sender, EventArgs e)
        {
            if (FindWhatHistory == null)
            {
                FindWhatHistory = new List<string>();
            }

            foreach (var findWhat in FindWhatHistory)
            {
                this.FindWhatComboBox.Items.Add(findWhat);
            }

            this.LookInComboBox.SelectedIndex = (int)LookIn;

            this.MatchCaseCheckBox.Checked = MatchCase;

            this.UseRegularExpressionsCheckBox.Checked = UseRegularExpressions;
        }
    }
}