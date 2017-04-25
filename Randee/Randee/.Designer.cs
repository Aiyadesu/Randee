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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Randee));
            this.generateNumber = new System.Windows.Forms.Button();
            this.maxRangeInput = new System.Windows.Forms.NumericUpDown();
            this.numberDisplay = new System.Windows.Forms.Label();
            this.customRangeLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.minRangeInput = new System.Windows.Forms.NumericUpDown();
            this.toLabel = new System.Windows.Forms.Label();
            this.settingsButton = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.maxRangeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRangeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonClose)).BeginInit();
            this.SuspendLayout();
            // 
            // generateNumber
            // 
            this.generateNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateNumber.Location = new System.Drawing.Point(300, 325);
            this.generateNumber.Name = "generateNumber";
            this.generateNumber.Size = new System.Drawing.Size(100, 32);
            this.generateNumber.TabIndex = 1;
            this.generateNumber.Text = "Generate!";
            this.generateNumber.UseVisualStyleBackColor = true;
            this.generateNumber.Click += new System.EventHandler(this.generateNumber_Click);
            // 
            // maxRangeInput
            // 
            this.maxRangeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxRangeInput.Location = new System.Drawing.Point(203, 325);
            this.maxRangeInput.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.maxRangeInput.Name = "maxRangeInput";
            this.maxRangeInput.Size = new System.Drawing.Size(80, 29);
            this.maxRangeInput.TabIndex = 3;
            this.maxRangeInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maxRangeInput.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.maxRangeInput.ValueChanged += new System.EventHandler(this.rangeInput_ValueChanged);
            // 
            // numberDisplay
            // 
            this.numberDisplay.AutoSize = true;
            this.numberDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberDisplay.Location = new System.Drawing.Point(93, 375);
            this.numberDisplay.Name = "numberDisplay";
            this.numberDisplay.Size = new System.Drawing.Size(234, 24);
            this.numberDisplay.TabIndex = 4;
            this.numberDisplay.Text = "Your random number is 14";
            this.numberDisplay.Click += new System.EventHandler(this.numberDisplay_Click);
            // 
            // customRangeLabel
            // 
            this.customRangeLabel.AutoSize = true;
            this.customRangeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customRangeLabel.Location = new System.Drawing.Point(75, 284);
            this.customRangeLabel.Name = "customRangeLabel";
            this.customRangeLabel.Size = new System.Drawing.Size(279, 24);
            this.customRangeLabel.TabIndex = 5;
            this.customRangeLabel.Text = "Custom Range (min 1, max 255)";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromLabel.Location = new System.Drawing.Point(20, 325);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(55, 24);
            this.fromLabel.TabIndex = 6;
            this.fromLabel.Text = "From";
            // 
            // minRangeInput
            // 
            this.minRangeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minRangeInput.Location = new System.Drawing.Point(81, 325);
            this.minRangeInput.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.minRangeInput.Name = "minRangeInput";
            this.minRangeInput.Size = new System.Drawing.Size(80, 29);
            this.minRangeInput.TabIndex = 7;
            this.minRangeInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minRangeInput.ValueChanged += new System.EventHandler(this.minRangeInput_ValueChanged);
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toLabel.Location = new System.Drawing.Point(170, 325);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(25, 24);
            this.toLabel.TabIndex = 8;
            this.toLabel.Text = "to";
            // 
            // settingsButton
            // 
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.settingsButton.Location = new System.Drawing.Point(157, 237);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(115, 33);
            this.settingsButton.TabIndex = 9;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClose.BackgroundImage")));
            this.buttonClose.Location = new System.Drawing.Point(379, -1);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(42, 42);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.TabStop = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // Randee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 420);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.minRangeInput);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.customRangeLabel);
            this.Controls.Add(this.numberDisplay);
            this.Controls.Add(this.maxRangeInput);
            this.Controls.Add(this.generateNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Randee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Randee";
            this.Load += new System.EventHandler(this.Randee_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Randee_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.maxRangeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRangeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button generateNumber;
        private System.Windows.Forms.NumericUpDown minRangeInput;
        private System.Windows.Forms.NumericUpDown maxRangeInput;
        private System.Windows.Forms.Label numberDisplay;
        private System.Windows.Forms.Label customRangeLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.PictureBox buttonClose;
    }
}

