namespace Randee
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelAPIKey = new System.Windows.Forms.Label();
            this.textboxAPIKey = new System.Windows.Forms.TextBox();
            this.buttonSaveKey = new System.Windows.Forms.Button();
            this.labelSaveStatus = new System.Windows.Forms.Label();
            this.checkBoxKeepHistory = new System.Windows.Forms.CheckBox();
            this.comboBoxSeperator = new System.Windows.Forms.ComboBox();
            this.labelSeperator = new System.Windows.Forms.Label();
            this.labelSeperatorExample = new System.Windows.Forms.Label();
            this.buttonHome = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAPIKey
            // 
            this.labelAPIKey.AutoSize = true;
            this.labelAPIKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelAPIKey.Location = new System.Drawing.Point(80, 43);
            this.labelAPIKey.Name = "labelAPIKey";
            this.labelAPIKey.Size = new System.Drawing.Size(274, 24);
            this.labelAPIKey.TabIndex = 0;
            this.labelAPIKey.Text = "Overwrite your current API key?";
            this.labelAPIKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxAPIKey
            // 
            this.textboxAPIKey.AcceptsReturn = true;
            this.textboxAPIKey.Location = new System.Drawing.Point(45, 80);
            this.textboxAPIKey.Name = "textboxAPIKey";
            this.textboxAPIKey.Size = new System.Drawing.Size(337, 20);
            this.textboxAPIKey.TabIndex = 1;
            this.textboxAPIKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textboxAPIKey.WordWrap = false;
            this.textboxAPIKey.Enter += new System.EventHandler(this.textboxAPIKey_Enter);
            this.textboxAPIKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxAPIKey_KeyDown);
            // 
            // buttonSaveKey
            // 
            this.buttonSaveKey.Location = new System.Drawing.Point(164, 164);
            this.buttonSaveKey.Name = "buttonSaveKey";
            this.buttonSaveKey.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveKey.TabIndex = 2;
            this.buttonSaveKey.Text = "Save Key";
            this.buttonSaveKey.UseVisualStyleBackColor = true;
            this.buttonSaveKey.Click += new System.EventHandler(this.buttonSaveKey_Click);
            // 
            // labelSaveStatus
            // 
            this.labelSaveStatus.AutoSize = true;
            this.labelSaveStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelSaveStatus.Location = new System.Drawing.Point(115, 124);
            this.labelSaveStatus.Name = "labelSaveStatus";
            this.labelSaveStatus.Size = new System.Drawing.Size(139, 20);
            this.labelSaveStatus.TabIndex = 3;
            this.labelSaveStatus.Text = "Save Status Label";
            this.labelSaveStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBoxKeepHistory
            // 
            this.checkBoxKeepHistory.AutoSize = true;
            this.checkBoxKeepHistory.Location = new System.Drawing.Point(45, 234);
            this.checkBoxKeepHistory.Name = "checkBoxKeepHistory";
            this.checkBoxKeepHistory.Size = new System.Drawing.Size(132, 17);
            this.checkBoxKeepHistory.TabIndex = 4;
            this.checkBoxKeepHistory.Text = "Keep Number History?";
            this.checkBoxKeepHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxKeepHistory.UseVisualStyleBackColor = true;
            this.checkBoxKeepHistory.CheckedChanged += new System.EventHandler(this.checkBoxKeepHistory_CheckedChanged);
            // 
            // comboBoxSeperator
            // 
            this.comboBoxSeperator.FormattingEnabled = true;
            this.comboBoxSeperator.Items.AddRange(new object[] {
            " ",
            ",",
            "|"});
            this.comboBoxSeperator.Location = new System.Drawing.Point(261, 277);
            this.comboBoxSeperator.MaxDropDownItems = 3;
            this.comboBoxSeperator.Name = "comboBoxSeperator";
            this.comboBoxSeperator.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSeperator.TabIndex = 1;
            this.comboBoxSeperator.Text = " ";
            this.comboBoxSeperator.Visible = false;
            this.comboBoxSeperator.SelectedIndexChanged += new System.EventHandler(this.comboBoxSeperator_SelectedIndexChanged);
            // 
            // labelSeperator
            // 
            this.labelSeperator.AutoSize = true;
            this.labelSeperator.Location = new System.Drawing.Point(42, 280);
            this.labelSeperator.Name = "labelSeperator";
            this.labelSeperator.Size = new System.Drawing.Size(197, 13);
            this.labelSeperator.TabIndex = 6;
            this.labelSeperator.Text = "Select a seperator for the number history";
            this.labelSeperator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSeperator.Visible = false;
            // 
            // labelSeperatorExample
            // 
            this.labelSeperatorExample.AutoSize = true;
            this.labelSeperatorExample.Location = new System.Drawing.Point(42, 305);
            this.labelSeperatorExample.Name = "labelSeperatorExample";
            this.labelSeperatorExample.Size = new System.Drawing.Size(124, 13);
            this.labelSeperatorExample.TabIndex = 7;
            this.labelSeperatorExample.Text = "Example Output) 1 2 3 4.";
            this.labelSeperatorExample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSeperatorExample.Visible = false;
            // 
            // buttonHome
            // 
            this.buttonHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonHome.Location = new System.Drawing.Point(164, 344);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(75, 32);
            this.buttonHome.TabIndex = 8;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 420);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.labelSeperatorExample);
            this.Controls.Add(this.labelSeperator);
            this.Controls.Add(this.comboBoxSeperator);
            this.Controls.Add(this.checkBoxKeepHistory);
            this.Controls.Add(this.labelSaveStatus);
            this.Controls.Add(this.buttonSaveKey);
            this.Controls.Add(this.textboxAPIKey);
            this.Controls.Add(this.labelAPIKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAPIKey;
        private System.Windows.Forms.TextBox textboxAPIKey;
        private System.Windows.Forms.Button buttonSaveKey;
        private System.Windows.Forms.Label labelSaveStatus;
        private System.Windows.Forms.ComboBox comboBoxSeperator;
        private System.Windows.Forms.Label labelSeperator;
        private System.Windows.Forms.Label labelSeperatorExample;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.CheckBox checkBoxKeepHistory;
    }
}