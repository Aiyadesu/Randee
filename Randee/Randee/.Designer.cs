namespace Randee
{
    partial class Randee
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
            this.titleBar = new System.Windows.Forms.PictureBox();
            this.generateNumber = new System.Windows.Forms.Button();
            this.numberDisplay = new System.Windows.Forms.TextBox();
            this.rangeInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.titleBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeInput)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.Transparent;
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(1280, 50);
            this.titleBar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.titleBar.TabIndex = 0;
            this.titleBar.TabStop = false;
            this.titleBar.Click += new System.EventHandler(this.titleBar_Click);
            // 
            // generateNumber
            // 
            this.generateNumber.Location = new System.Drawing.Point(340, 211);
            this.generateNumber.Name = "generateNumber";
            this.generateNumber.Size = new System.Drawing.Size(75, 23);
            this.generateNumber.TabIndex = 1;
            this.generateNumber.Text = "Generate!";
            this.generateNumber.UseVisualStyleBackColor = true;
            this.generateNumber.Click += new System.EventHandler(this.generateNumber_Click);
            // 
            // numberDisplay
            // 
            this.numberDisplay.BackColor = System.Drawing.SystemColors.Control;
            this.numberDisplay.Location = new System.Drawing.Point(327, 185);
            this.numberDisplay.Name = "numberDisplay";
            this.numberDisplay.Size = new System.Drawing.Size(100, 20);
            this.numberDisplay.TabIndex = 2;
            this.numberDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numberDisplay.TextChanged += new System.EventHandler(this.numberDisplay_TextChanged);
            // 
            // rangeInput
            // 
            this.rangeInput.Location = new System.Drawing.Point(327, 146);
            this.rangeInput.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.rangeInput.Name = "rangeInput";
            this.rangeInput.Size = new System.Drawing.Size(120, 20);
            this.rangeInput.TabIndex = 3;
            this.rangeInput.ValueChanged += new System.EventHandler(this.rangeInput_ValueChanged);
            // 
            // Randee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.rangeInput);
            this.Controls.Add(this.numberDisplay);
            this.Controls.Add(this.generateNumber);
            this.Controls.Add(this.titleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Randee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Randee";
            this.Load += new System.EventHandler(this.Randee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.titleBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangeInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox titleBar;
        private System.Windows.Forms.Button generateNumber;
        private System.Windows.Forms.TextBox numberDisplay;
        private System.Windows.Forms.NumericUpDown rangeInput;
    }
}

