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
            this.buttonSaveKey.Location = new System.Drawing.Point(165, 118);
            this.buttonSaveKey.Name = "buttonSaveKey";
            this.buttonSaveKey.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveKey.TabIndex = 2;
            this.buttonSaveKey.Text = "Save Key";
            this.buttonSaveKey.UseVisualStyleBackColor = true;
            this.buttonSaveKey.Click += new System.EventHandler(this.buttonSaveKey_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 420);
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
    }
}