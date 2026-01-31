using System;
using System.Windows.Forms;

namespace Oracle
{
    public partial class MessageWindow : Form
    {
        public MessageWindow(Form form, string message, string title, MessageWindowType windowType)
        {
            this.InitializeComponent(windowType);

            this.Left = form.Left + 32; this.Top = form.Top + 48;

            this.MessageLabel.Text = message;

            this.Text = title;
        }

        private void MessageWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;

                e.SuppressKeyPress = true;

                e.Handled = true;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}