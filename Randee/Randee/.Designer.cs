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
            this.buttonGenerateNumber = new System.Windows.Forms.Button();
            this.inputMaxRange = new System.Windows.Forms.NumericUpDown();
            this.labelNumberDisplay = new System.Windows.Forms.Label();
            this.labelCustomRange = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.inputMinRange = new System.Windows.Forms.NumericUpDown();
            this.labelTo = new System.Windows.Forms.Label();
            this.labelNumberOfNumbers = new System.Windows.Forms.Label();
            this.inputNumberOfNumbers = new System.Windows.Forms.NumericUpDown();
            this.labelMultipleNumbers = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonSettings = new System.Windows.Forms.PictureBox();
            this.buttonHome = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.PictureBox();
            this.windowMask = new System.Windows.Forms.PictureBox();
            this.labelErrorMessage = new System.Windows.Forms.Label();
            this.buttonCheckQuota = new System.Windows.Forms.Button();
            this.labelQuotaTitle = new System.Windows.Forms.Label();
            this.labelBitsLeft = new System.Windows.Forms.Label();
            this.labelRequestsLeft = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inputMaxRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputMinRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumberOfNumbers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowMask)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGenerateNumber
            // 
            this.buttonGenerateNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateNumber.Location = new System.Drawing.Point(81, 377);
            this.buttonGenerateNumber.Name = "buttonGenerateNumber";
            this.buttonGenerateNumber.Size = new System.Drawing.Size(100, 57);
            this.buttonGenerateNumber.TabIndex = 1;
            this.buttonGenerateNumber.Text = "Generate Number";
            this.buttonGenerateNumber.UseVisualStyleBackColor = true;
            this.buttonGenerateNumber.Click += new System.EventHandler(this.buttonGenerateNumber_Click);
            // 
            // inputMaxRange
            // 
            this.inputMaxRange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputMaxRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputMaxRange.Location = new System.Drawing.Point(260, 143);
            this.inputMaxRange.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.inputMaxRange.Name = "inputMaxRange";
            this.inputMaxRange.Size = new System.Drawing.Size(94, 25);
            this.inputMaxRange.TabIndex = 3;
            this.inputMaxRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputMaxRange.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // labelNumberDisplay
            // 
            this.labelNumberDisplay.AutoSize = true;
            this.labelNumberDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberDisplay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelNumberDisplay.Location = new System.Drawing.Point(530, 84);
            this.labelNumberDisplay.Name = "labelNumberDisplay";
            this.labelNumberDisplay.Size = new System.Drawing.Size(121, 24);
            this.labelNumberDisplay.TabIndex = 4;
            this.labelNumberDisplay.Text = "One Number";
            // 
            // labelCustomRange
            // 
            this.labelCustomRange.AutoSize = true;
            this.labelCustomRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomRange.Location = new System.Drawing.Point(77, 69);
            this.labelCustomRange.Name = "labelCustomRange";
            this.labelCustomRange.Size = new System.Drawing.Size(277, 24);
            this.labelCustomRange.TabIndex = 5;
            this.labelCustomRange.Text = "Number Generation Parameters";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFrom.Location = new System.Drawing.Point(65, 143);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(55, 24);
            this.labelFrom.TabIndex = 6;
            this.labelFrom.Text = "From";
            // 
            // inputMinRange
            // 
            this.inputMinRange.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputMinRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputMinRange.Location = new System.Drawing.Point(126, 143);
            this.inputMinRange.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.inputMinRange.Name = "inputMinRange";
            this.inputMinRange.Size = new System.Drawing.Size(95, 25);
            this.inputMinRange.TabIndex = 7;
            this.inputMinRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputMinRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTo.Location = new System.Drawing.Point(227, 143);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(25, 24);
            this.labelTo.TabIndex = 8;
            this.labelTo.Text = "to";
            // 
            // labelNumberOfNumbers
            // 
            this.labelNumberOfNumbers.AutoSize = true;
            this.labelNumberOfNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelNumberOfNumbers.Location = new System.Drawing.Point(65, 217);
            this.labelNumberOfNumbers.Name = "labelNumberOfNumbers";
            this.labelNumberOfNumbers.Size = new System.Drawing.Size(289, 24);
            this.labelNumberOfNumbers.TabIndex = 11;
            this.labelNumberOfNumbers.Text = "Number of numbers to generate?";
            // 
            // inputNumberOfNumbers
            // 
            this.inputNumberOfNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputNumberOfNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.inputNumberOfNumbers.Location = new System.Drawing.Point(167, 300);
            this.inputNumberOfNumbers.Name = "inputNumberOfNumbers";
            this.inputNumberOfNumbers.Size = new System.Drawing.Size(95, 25);
            this.inputNumberOfNumbers.TabIndex = 12;
            this.inputNumberOfNumbers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputNumberOfNumbers.Value = new decimal(new int[] {
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
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelTitle.Location = new System.Drawing.Point(13, 13);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(82, 24);
            this.labelTitle.TabIndex = 15;
            this.labelTitle.Text = "Randee ";
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
            // buttonCheckQuota
            // 
            this.buttonCheckQuota.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonCheckQuota.Location = new System.Drawing.Point(254, 377);
            this.buttonCheckQuota.Name = "buttonCheckQuota";
            this.buttonCheckQuota.Size = new System.Drawing.Size(100, 57);
            this.buttonCheckQuota.TabIndex = 19;
            this.buttonCheckQuota.Text = "Check Quota";
            this.buttonCheckQuota.UseVisualStyleBackColor = true;
            this.buttonCheckQuota.Visible = false;
            this.buttonCheckQuota.Click += new System.EventHandler(this.buttonCheckQuota_Click);
            // 
            // labelQuotaTitle
            // 
            this.labelQuotaTitle.AutoSize = true;
            this.labelQuotaTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelQuotaTitle.Location = new System.Drawing.Point(556, 69);
            this.labelQuotaTitle.Name = "labelQuotaTitle";
            this.labelQuotaTitle.Size = new System.Drawing.Size(150, 24);
            this.labelQuotaTitle.TabIndex = 20;
            this.labelQuotaTitle.Text = "Daily Quota Stats";
            // 
            // labelBitsLeft
            // 
            this.labelBitsLeft.AutoSize = true;
            this.labelBitsLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelBitsLeft.Location = new System.Drawing.Point(501, 142);
            this.labelBitsLeft.Name = "labelBitsLeft";
            this.labelBitsLeft.Size = new System.Drawing.Size(103, 24);
            this.labelBitsLeft.TabIndex = 21;
            this.labelBitsLeft.Text = "Bits Left: 14";
            // 
            // labelRequestsLeft
            // 
            this.labelRequestsLeft.AutoSize = true;
            this.labelRequestsLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelRequestsLeft.Location = new System.Drawing.Point(501, 182);
            this.labelRequestsLeft.Name = "labelRequestsLeft";
            this.labelRequestsLeft.Size = new System.Drawing.Size(153, 24);
            this.labelRequestsLeft.TabIndex = 22;
            this.labelRequestsLeft.Text = "Requests Left: 14";
            // 
            // Randee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(840, 473);
            this.Controls.Add(this.labelRequestsLeft);
            this.Controls.Add(this.labelBitsLeft);
            this.Controls.Add(this.labelQuotaTitle);
            this.Controls.Add(this.buttonCheckQuota);
            this.Controls.Add(this.labelErrorMessage);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelMultipleNumbers);
            this.Controls.Add(this.inputNumberOfNumbers);
            this.Controls.Add(this.labelNumberOfNumbers);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.inputMinRange);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.labelCustomRange);
            this.Controls.Add(this.labelNumberDisplay);
            this.Controls.Add(this.inputMaxRange);
            this.Controls.Add(this.buttonGenerateNumber);
            this.Controls.Add(this.windowMask);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Randee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Randee";
            this.LocationChanged += new System.EventHandler(this.Randee_LocationChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Randee_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.inputMaxRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputMinRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputNumberOfNumbers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowMask)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonGenerateNumber;
        private System.Windows.Forms.NumericUpDown inputMinRange;
        private System.Windows.Forms.NumericUpDown inputMaxRange;
        private System.Windows.Forms.Label labelNumberDisplay;
        private System.Windows.Forms.Label labelCustomRange;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.PictureBox buttonClose;
        private System.Windows.Forms.Label labelNumberOfNumbers;
        private System.Windows.Forms.NumericUpDown inputNumberOfNumbers;
        private System.Windows.Forms.Label labelMultipleNumbers;
        private System.Windows.Forms.PictureBox windowMask;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox buttonHome;
        private System.Windows.Forms.PictureBox buttonSettings;
        private System.Windows.Forms.Label labelErrorMessage;
        private System.Windows.Forms.Button buttonCheckQuota;
        private System.Windows.Forms.Label labelQuotaTitle;
        private System.Windows.Forms.Label labelBitsLeft;
        private System.Windows.Forms.Label labelRequestsLeft;
    }
}

