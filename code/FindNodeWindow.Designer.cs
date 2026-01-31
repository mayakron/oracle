using System.Drawing;

namespace Oracle
{
    partial class FindNodeWindow
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
            this.FindWhatLabel = new System.Windows.Forms.Label();
            this.FindWhatComboBox = new System.Windows.Forms.ComboBox();
            this.LookInLabel = new System.Windows.Forms.Label();
            this.LookInComboBox = new System.Windows.Forms.ComboBox();
            this.MatchCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.UseRegularExpressionsCheckBox = new System.Windows.Forms.CheckBox();
            this.FindPreviousButton = new System.Windows.Forms.Button();
            this.FindNextButton = new System.Windows.Forms.Button();
            
            this.SuspendLayout();

            this.FindWhatLabel.AutoSize = true;
            this.FindWhatLabel.Location = new System.Drawing.Point(20, 20);
            this.FindWhatLabel.TabIndex = 0;
            this.FindWhatLabel.Text = "Find &what:";

            this.FindWhatComboBox.Location = new System.Drawing.Point(20, 50);
            this.FindWhatComboBox.Size = new System.Drawing.Size(660, 30);
            this.FindWhatComboBox.TabIndex = 1;

            this.LookInLabel.AutoSize = true;
            this.LookInLabel.Location = new System.Drawing.Point(20, 90);
            this.LookInLabel.TabIndex = 2;
            this.LookInLabel.Text = "&Look in:";

            this.LookInComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LookInComboBox.Items.AddRange(new object[] { "Tree", "Tree and notes" });
            this.LookInComboBox.Location = new System.Drawing.Point(20, 120);
            this.LookInComboBox.Size = new System.Drawing.Size(660, 30);
            this.LookInComboBox.TabIndex = 3;

            this.MatchCaseCheckBox.AutoSize = true;
            this.MatchCaseCheckBox.Location = new System.Drawing.Point(20, 170);
            this.MatchCaseCheckBox.TabIndex = 4;
            this.MatchCaseCheckBox.Text = "Match ca&se";
            this.MatchCaseCheckBox.UseVisualStyleBackColor = true;

            this.UseRegularExpressionsCheckBox.AutoSize = true;
            this.UseRegularExpressionsCheckBox.Location = new System.Drawing.Point(20, 200);
            this.UseRegularExpressionsCheckBox.TabIndex = 5;
            this.UseRegularExpressionsCheckBox.Text = "Us&e regular expressions";
            this.UseRegularExpressionsCheckBox.UseVisualStyleBackColor = true;

            this.FindPreviousButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.FindPreviousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FindPreviousButton.Location = new System.Drawing.Point(180, 340);
            this.FindPreviousButton.Size = new System.Drawing.Size(160, 35);
            this.FindPreviousButton.TabIndex = 6;
            this.FindPreviousButton.Text = "Find &previous";
            this.FindPreviousButton.UseVisualStyleBackColor = true;
            this.FindPreviousButton.Click += new System.EventHandler(this.FindPreviousButton_Click);

            this.FindNextButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.FindNextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FindNextButton.Location = new System.Drawing.Point(360, 340);
            this.FindNextButton.Size = new System.Drawing.Size(160, 35);
            this.FindNextButton.TabIndex = 7;
            this.FindNextButton.Text = "Find &next";
            this.FindNextButton.UseVisualStyleBackColor = true;
            this.FindNextButton.Click += new System.EventHandler(this.FindNextButton_Click);

            this.AcceptButton = this.FindNextButton;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Font = Program.StandardFont;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Find node...";
            this.Load += new System.EventHandler(this.FindWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindWindow_KeyDown);

            this.Controls.Add(this.FindWhatLabel);
            this.Controls.Add(this.FindWhatComboBox);
            this.Controls.Add(this.LookInLabel);
            this.Controls.Add(this.LookInComboBox);
            this.Controls.Add(this.MatchCaseCheckBox);
            this.Controls.Add(this.UseRegularExpressionsCheckBox);
            this.Controls.Add(this.FindPreviousButton);
            this.Controls.Add(this.FindNextButton);

            this.ResumeLayout(false);
            
            this.PerformLayout();
        }

        private System.Windows.Forms.Label FindWhatLabel;
        private System.Windows.Forms.ComboBox FindWhatComboBox;
        private System.Windows.Forms.Label LookInLabel;
        private System.Windows.Forms.ComboBox LookInComboBox;
        private System.Windows.Forms.CheckBox MatchCaseCheckBox;
        private System.Windows.Forms.CheckBox UseRegularExpressionsCheckBox;
        private System.Windows.Forms.Button FindPreviousButton;
        private System.Windows.Forms.Button FindNextButton;
    }
}