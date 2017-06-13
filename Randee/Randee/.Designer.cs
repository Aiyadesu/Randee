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
            this.numberOfNumbersLabel = new System.Windows.Forms.Label();
            this.numberOfNumbersInput = new System.Windows.Forms.NumericUpDown();
            this.labelMultipleNumbers = new System.Windows.Forms.Label();
            this.titleText = new System.Windows.Forms.Label();
            this.buttonSettings = new System.Windows.Forms.PictureBox();
            this.buttonHome = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.PictureBox();
            this.windowMask = new System.Windows.Forms.PictureBox();
            this.labelErrorMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.maxRangeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRangeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfNumbersInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowMask)).BeginInit();
            this.SuspendLayout();
            // 
            // generateNumber
            // 
            this.generateNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateNumber.Location = new System.Drawing.Point(167, 380);
            this.generateNumber.Name = "generateNumber";
            this.generateNumber.Size = new System.Drawing.Size(100, 35);
            this.generateNumber.TabIndex = 1;
            this.generateNumber.Text = "Generate!";
            this.generateNumber.UseVisualStyleBackColor = true;
            this.generateNumber.Click += new System.EventHandler(this.generateNumber_Click);
            // 
            // maxRangeInput
            // 
            this.maxRangeInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maxRangeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxRangeInput.Location = new System.Drawing.Point(260, 143);
            this.maxRangeInput.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.maxRangeInput.Name = "maxRangeInput";
            this.maxRangeInput.Size = new System.Drawing.Size(94, 25);
            this.maxRangeInput.TabIndex = 3;
            this.maxRangeInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maxRangeInput.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // numberDisplay
            // 
            this.numberDisplay.AutoSize = true;
            this.numberDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberDisplay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numberDisplay.Location = new System.Drawing.Point(530, 84);
            this.numberDisplay.Name = "numberDisplay";
            this.numberDisplay.Size = new System.Drawing.Size(121, 24);
            this.numberDisplay.TabIndex = 4;
            this.numberDisplay.Text = "One Number";
            // 
            // customRangeLabel
            // 
            this.customRangeLabel.AutoSize = true;
            this.customRangeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customRangeLabel.Location = new System.Drawing.Point(77, 69);
            this.customRangeLabel.Name = "customRangeLabel";
            this.customRangeLabel.Size = new System.Drawing.Size(277, 24);
            this.customRangeLabel.TabIndex = 5;
            this.customRangeLabel.Text = "Number Generation Parameters";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromLabel.Location = new System.Drawing.Point(65, 143);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(55, 24);
            this.fromLabel.TabIndex = 6;
            this.fromLabel.Text = "From";
            // 
            // minRangeInput
            // 
            this.minRangeInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.minRangeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minRangeInput.Location = new System.Drawing.Point(126, 143);
            this.minRangeInput.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.minRangeInput.Name = "minRangeInput";
            this.minRangeInput.Size = new System.Drawing.Size(95, 25);
            this.minRangeInput.TabIndex = 7;
            this.minRangeInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minRangeInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toLabel.Location = new System.Drawing.Point(227, 143);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(25, 24);
            this.toLabel.TabIndex = 8;
            this.toLabel.Text = "to";
            // 
            // numberOfNumbersLabel
            // 
            this.numberOfNumbersLabel.AutoSize = true;
            this.numberOfNumbersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.numberOfNumbersLabel.Location = new System.Drawing.Point(65, 217);
            this.numberOfNumbersLabel.Name = "numberOfNumbersLabel";
            this.numberOfNumbersLabel.Size = new System.Drawing.Size(289, 24);
            this.numberOfNumbersLabel.TabIndex = 11;
            this.numberOfNumbersLabel.Text = "Number of numbers to generate?";
            // 
            // numberOfNumbersInput
            // 
            this.numberOfNumbersInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numberOfNumbersInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.numberOfNumbersInput.Location = new System.Drawing.Point(167, 300);
            this.numberOfNumbersInput.Name = "numberOfNumbersInput";
            this.numberOfNumbersInput.Size = new System.Drawing.Size(95, 25);
            this.numberOfNumbersInput.TabIndex = 12;
            this.numberOfNumbersInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numberOfNumbersInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelMultipleNumbers
            // 
            this.labelMultipleNumbers.AutoEllipsis = true;
            this.labelMultipleNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelMultipleNumbers.Location = new System.Drawing.Point(451, 120);
            this.labelMultipleNumbers.Name = "labelMultipleNumbers";
            this.labelMultipleNumbers.Size = new System.Drawing.Size(368, 332);
            this.labelMultipleNumbers.TabIndex = 13;
            this.labelMultipleNumbers.Text = "Multiple Numbers";
            this.labelMultipleNumbers.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // titleText
            // 
            this.titleText.AutoSize = true;
            this.titleText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.titleText.Location = new System.Drawing.Point(13, 13);
            this.titleText.Name = "titleText";
            this.titleText.Size = new System.Drawing.Size(82, 24);
            this.titleText.TabIndex = 15;
            this.titleText.Text = "Randee ";
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackgroundImage = global::Randee.Properties.Resources.settings_button_c0c0c0;
            this.buttonSettings.Location = new System.Drawing.Point(721, -1);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(42, 42);
            this.buttonSettings.TabIndex = 17;
            this.buttonSettings.TabStop = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            this.buttonSettings.MouseLeave += new System.EventHandler(this.buttonSettings_Leave);
            this.buttonSettings.MouseHover += new System.EventHandler(this.buttonSettings_MouseOver);
            // 
            // buttonHome
            // 
            this.buttonHome.BackgroundImage = global::Randee.Properties.Resources.home_button_c0c0c0;
            this.buttonHome.Location = new System.Drawing.Point(760, -1);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(42, 42);
            this.buttonHome.TabIndex = 16;
            this.buttonHome.TabStop = false;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            this.buttonHome.MouseLeave += new System.EventHandler(this.buttonHome_Leave);
            this.buttonHome.MouseHover += new System.EventHandler(this.buttonHome_MouseOver);
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClose.BackgroundImage")));
            this.buttonClose.Location = new System.Drawing.Point(799, -1);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(42, 42);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.TabStop = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonClose.MouseLeave += new System.EventHandler(this.buttonClose_Leave);
            this.buttonClose.MouseHover += new System.EventHandler(this.buttonClose_MouseOver);
            // 
            // windowMask
            // 
            this.windowMask.Location = new System.Drawing.Point(1, 40);
            this.windowMask.Name = "windowMask";
            this.windowMask.Size = new System.Drawing.Size(840, 431);
            this.windowMask.TabIndex = 14;
            this.windowMask.TabStop = false;
            // 
            // labelErrorMessage
            // 
            this.labelErrorMessage.AutoSize = true;
            this.labelErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelErrorMessage.Location = new System.Drawing.Point(502, 46);
            this.labelErrorMessage.Name = "labelErrorMessage";
            this.labelErrorMessage.Size = new System.Drawing.Size(71, 17);
            this.labelErrorMessage.TabIndex = 18;
            this.labelErrorMessage.Text = "Error Text";
            this.labelErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Randee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(840, 473);
            this.Controls.Add(this.labelErrorMessage);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.titleText);
            this.Controls.Add(this.labelMultipleNumbers);
            this.Controls.Add(this.numberOfNumbersInput);
            this.Controls.Add(this.numberOfNumbersLabel);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.minRangeInput);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.customRangeLabel);
            this.Controls.Add(this.numberDisplay);
            this.Controls.Add(this.maxRangeInput);
            this.Controls.Add(this.generateNumber);
            this.Controls.Add(this.windowMask);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Randee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Randee";
            this.LocationChanged += new System.EventHandler(this.Randee_LocationChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Randee_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.maxRangeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRangeInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfNumbersInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowMask)).EndInit();
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
        private System.Windows.Forms.PictureBox buttonClose;
        private System.Windows.Forms.Label numberOfNumbersLabel;
        private System.Windows.Forms.NumericUpDown numberOfNumbersInput;
        private System.Windows.Forms.Label labelMultipleNumbers;
        private System.Windows.Forms.PictureBox windowMask;
        private System.Windows.Forms.Label titleText;
        private System.Windows.Forms.PictureBox buttonHome;
        private System.Windows.Forms.PictureBox buttonSettings;
        private System.Windows.Forms.Label labelErrorMessage;
    }
}

