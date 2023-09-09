namespace AutoClicker
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.titleLabel = new System.Windows.Forms.Label();
            this.delayLabel = new System.Windows.Forms.Label();
            this.mbuttonLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.startStopButton = new System.Windows.Forms.Button();
            this.leftRadioButton = new System.Windows.Forms.RadioButton();
            this.midRadioButton = new System.Windows.Forms.RadioButton();
            this.rightRadioButton = new System.Windows.Forms.RadioButton();
            this.delayInputBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.delayInputBox)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(110, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(160, 30);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Spooki\'s Autoclicker";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(66, 74);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(56, 13);
            this.delayLabel.TabIndex = 1;
            this.delayLabel.Text = "Delay (ms)";
            // 
            // mbuttonLabel
            // 
            this.mbuttonLabel.AutoSize = true;
            this.mbuttonLabel.Location = new System.Drawing.Point(66, 109);
            this.mbuttonLabel.Name = "mbuttonLabel";
            this.mbuttonLabel.Size = new System.Drawing.Size(73, 13);
            this.mbuttonLabel.TabIndex = 2;
            this.mbuttonLabel.Text = "Mouse Button";
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.statusLabel.Location = new System.Drawing.Point(150, 190);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(80, 15);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "Stopped";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(348, 194);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(28, 13);
            this.versionLabel.TabIndex = 4;
            this.versionLabel.Text = "v1.0";
            // 
            // startStopButton
            // 
            this.startStopButton.Location = new System.Drawing.Point(120, 150);
            this.startStopButton.Margin = new System.Windows.Forms.Padding(0);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(140, 25);
            this.startStopButton.TabIndex = 5;
            this.startStopButton.Text = "Start/Stop (F9)";
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.ButtonClick);
            // 
            // leftRadioButton
            // 
            this.leftRadioButton.AutoSize = true;
            this.leftRadioButton.Checked = true;
            this.leftRadioButton.Location = new System.Drawing.Point(159, 107);
            this.leftRadioButton.Name = "leftRadioButton";
            this.leftRadioButton.Size = new System.Drawing.Size(43, 17);
            this.leftRadioButton.TabIndex = 7;
            this.leftRadioButton.TabStop = true;
            this.leftRadioButton.Text = "Left";
            this.leftRadioButton.UseVisualStyleBackColor = true;
            // 
            // midRadioButton
            // 
            this.midRadioButton.AutoSize = true;
            this.midRadioButton.Location = new System.Drawing.Point(208, 107);
            this.midRadioButton.Name = "midRadioButton";
            this.midRadioButton.Size = new System.Drawing.Size(56, 17);
            this.midRadioButton.TabIndex = 8;
            this.midRadioButton.Text = "Middle";
            this.midRadioButton.UseVisualStyleBackColor = true;
            // 
            // rightRadioButton
            // 
            this.rightRadioButton.AutoSize = true;
            this.rightRadioButton.Location = new System.Drawing.Point(270, 107);
            this.rightRadioButton.Name = "rightRadioButton";
            this.rightRadioButton.Size = new System.Drawing.Size(50, 17);
            this.rightRadioButton.TabIndex = 9;
            this.rightRadioButton.Text = "Right";
            this.rightRadioButton.UseVisualStyleBackColor = true;
            // 
            // delayInputBox
            // 
            this.delayInputBox.Location = new System.Drawing.Point(179, 72);
            this.delayInputBox.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.delayInputBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.delayInputBox.Name = "delayInputBox";
            this.delayInputBox.Size = new System.Drawing.Size(120, 20);
            this.delayInputBox.TabIndex = 10;
            this.delayInputBox.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.delayInputBox);
            this.Controls.Add(this.rightRadioButton);
            this.Controls.Add(this.midRadioButton);
            this.Controls.Add(this.leftRadioButton);
            this.Controls.Add(this.startStopButton);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.mbuttonLabel);
            this.Controls.Add(this.delayLabel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spooki\'s Autoclicker";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.delayInputBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.Label mbuttonLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Button startStopButton;
        private System.Windows.Forms.RadioButton leftRadioButton;
        private System.Windows.Forms.RadioButton midRadioButton;
        private System.Windows.Forms.RadioButton rightRadioButton;
        private System.Windows.Forms.NumericUpDown delayInputBox;
    }
}

