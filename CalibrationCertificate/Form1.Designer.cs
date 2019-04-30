namespace CalibrationCertificate
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
            this.grpSource = new System.Windows.Forms.GroupBox();
            this.btnSource = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.fbdBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.grpDestination = new System.Windows.Forms.GroupBox();
            this.btnDestination = new System.Windows.Forms.Button();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.grpPressure = new System.Windows.Forms.GroupBox();
            this.txtIncrement = new System.Windows.Forms.NumericUpDown();
            this.txtFrom = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstStatus = new System.Windows.Forms.ListBox();
            this.grpSource.SuspendLayout();
            this.grpDestination.SuspendLayout();
            this.grpPressure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIncrement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSource
            // 
            this.grpSource.Controls.Add(this.btnSource);
            this.grpSource.Controls.Add(this.txtSource);
            this.grpSource.Location = new System.Drawing.Point(13, 13);
            this.grpSource.Name = "grpSource";
            this.grpSource.Size = new System.Drawing.Size(436, 58);
            this.grpSource.TabIndex = 2;
            this.grpSource.TabStop = false;
            this.grpSource.Text = "Source";
            // 
            // btnSource
            // 
            this.btnSource.Location = new System.Drawing.Point(401, 17);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(27, 23);
            this.btnSource.TabIndex = 1;
            this.btnSource.Text = "...";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // txtSource
            // 
            this.txtSource.Enabled = false;
            this.txtSource.Location = new System.Drawing.Point(7, 20);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(388, 20);
            this.txtSource.TabIndex = 0;
            // 
            // grpDestination
            // 
            this.grpDestination.Controls.Add(this.btnDestination);
            this.grpDestination.Controls.Add(this.txtDestination);
            this.grpDestination.Location = new System.Drawing.Point(12, 77);
            this.grpDestination.Name = "grpDestination";
            this.grpDestination.Size = new System.Drawing.Size(436, 58);
            this.grpDestination.TabIndex = 3;
            this.grpDestination.TabStop = false;
            this.grpDestination.Text = "Destination";
            // 
            // btnDestination
            // 
            this.btnDestination.Location = new System.Drawing.Point(401, 17);
            this.btnDestination.Name = "btnDestination";
            this.btnDestination.Size = new System.Drawing.Size(27, 23);
            this.btnDestination.TabIndex = 1;
            this.btnDestination.Text = "...";
            this.btnDestination.UseVisualStyleBackColor = true;
            this.btnDestination.Click += new System.EventHandler(this.btnDestination_Click);
            // 
            // txtDestination
            // 
            this.txtDestination.Enabled = false;
            this.txtDestination.Location = new System.Drawing.Point(7, 20);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(388, 20);
            this.txtDestination.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(365, 157);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // grpPressure
            // 
            this.grpPressure.Controls.Add(this.txtIncrement);
            this.grpPressure.Controls.Add(this.txtFrom);
            this.grpPressure.Controls.Add(this.label1);
            this.grpPressure.Controls.Add(this.lblStart);
            this.grpPressure.Location = new System.Drawing.Point(12, 142);
            this.grpPressure.Name = "grpPressure";
            this.grpPressure.Size = new System.Drawing.Size(312, 49);
            this.grpPressure.TabIndex = 6;
            this.grpPressure.TabStop = false;
            this.grpPressure.Text = "Pressure(psi)";
            // 
            // txtIncrement
            // 
            this.txtIncrement.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtIncrement.Location = new System.Drawing.Point(209, 16);
            this.txtIncrement.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtIncrement.Name = "txtIncrement";
            this.txtIncrement.Size = new System.Drawing.Size(82, 20);
            this.txtIncrement.TabIndex = 3;
            this.txtIncrement.ThousandsSeparator = true;
            // 
            // txtFrom
            // 
            this.txtFrom.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtFrom.Location = new System.Drawing.Point(63, 16);
            this.txtFrom.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(82, 20);
            this.txtFrom.TabIndex = 2;
            this.txtFrom.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Increment:";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(8, 20);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(58, 13);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "Start From:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstStatus);
            this.groupBox1.Location = new System.Drawing.Point(13, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 121);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process Log";
            // 
            // lstStatus
            // 
            this.lstStatus.FormattingEnabled = true;
            this.lstStatus.Location = new System.Drawing.Point(7, 20);
            this.lstStatus.Name = "lstStatus";
            this.lstStatus.Size = new System.Drawing.Size(420, 95);
            this.lstStatus.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 331);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpPressure);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.grpDestination);
            this.Controls.Add(this.grpSource);
            this.Name = "Form1";
            this.Text = "Calibration Certificate Loader";
            this.grpSource.ResumeLayout(false);
            this.grpSource.PerformLayout();
            this.grpDestination.ResumeLayout(false);
            this.grpDestination.PerformLayout();
            this.grpPressure.ResumeLayout(false);
            this.grpPressure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIncrement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpSource;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowse;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.GroupBox grpDestination;
        private System.Windows.Forms.Button btnDestination;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox grpPressure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.NumericUpDown txtIncrement;
        private System.Windows.Forms.NumericUpDown txtFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstStatus;
    }
}

