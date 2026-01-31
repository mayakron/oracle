using System.Drawing;
using System.Windows.Forms;

namespace Oracle
{
    partial class MessageWindow
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

        private void InitializeComponent(MessageWindowType windowType)
        {
            this.MessageLabel = new System.Windows.Forms.Label();
            this.MyOKButton = new System.Windows.Forms.Button();
            this.MyYesButton = new System.Windows.Forms.Button();
            this.MyNoButton = new System.Windows.Forms.Button();
            this.MyCancelButton = new System.Windows.Forms.Button();

            this.SuspendLayout();

            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Location = new System.Drawing.Point(20, 20);
            this.MessageLabel.MaximumSize = new Size(660, 0);
            this.MessageLabel.TabIndex = 0;
            this.MessageLabel.Text = "This is a sample message.";

            this.MyOKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.MyOKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyOKButton.Location = new System.Drawing.Point(290, 340);
            this.MyOKButton.Size = new System.Drawing.Size(120, 35);
            this.MyOKButton.TabIndex = 1;
            this.MyOKButton.Text = "&OK";
            this.MyOKButton.UseVisualStyleBackColor = true;

            this.MyYesButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.MyYesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyYesButton.Location = new System.Drawing.Point(160, 340);
            this.MyYesButton.Size = new System.Drawing.Size(120, 35);
            this.MyYesButton.TabIndex = 2;
            this.MyYesButton.Text = "&Yes";
            this.MyYesButton.UseVisualStyleBackColor = true;

            this.MyNoButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.MyNoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyNoButton.Location = new System.Drawing.Point(290, 340);
            this.MyNoButton.Size = new System.Drawing.Size(120, 35);
            this.MyNoButton.TabIndex = 3;
            this.MyNoButton.Text = "&No";
            this.MyNoButton.UseVisualStyleBackColor = true;

            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MyCancelButton.Location = new System.Drawing.Point(420, 340);
            this.MyCancelButton.Size = new System.Drawing.Size(120, 35);
            this.MyCancelButton.TabIndex = 4;
            this.MyCancelButton.Text = "&Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;

            switch (windowType)
            {
                case MessageWindowType.Information:

                    this.MyYesButton.Visible = false;
                    this.MyNoButton.Visible = false;
                    this.MyCancelButton.Visible = false;

                    this.AcceptButton = this.MyOKButton;

                    break;

                case MessageWindowType.Question:

                    this.MyOKButton.Visible = false;
                    
                    this.AcceptButton = this.MyYesButton;

                    break;
            }

            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Font = Program.StandardFont;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageWindow_KeyDown);

            this.Controls.Add(this.MessageLabel);
            this.Controls.Add(this.MyOKButton);
            this.Controls.Add(this.MyYesButton);
            this.Controls.Add(this.MyNoButton);
            this.Controls.Add(this.MyCancelButton);

            this.ResumeLayout(false);
            
            this.PerformLayout();
        }

        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Button MyOKButton;
        private System.Windows.Forms.Button MyYesButton;
        private System.Windows.Forms.Button MyNoButton;
        private System.Windows.Forms.Button MyCancelButton;
    }
}