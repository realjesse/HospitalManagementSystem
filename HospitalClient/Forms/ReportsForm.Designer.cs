namespace HospitalClient.Forms
{
    partial class ReportsForm
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
            this.dataGridView_data = new System.Windows.Forms.DataGridView();
            this.comboBox_reportType = new System.Windows.Forms.ComboBox();
            this.button_generateReport = new System.Windows.Forms.Button();
            this.button_calculateAnalytics = new System.Windows.Forms.Button();
            this.comboBox_exportFormat = new System.Windows.Forms.ComboBox();
            this.button_export = new System.Windows.Forms.Button();
            this.button_backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_data
            // 
            this.dataGridView_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_data.Location = new System.Drawing.Point(73, 95);
            this.dataGridView_data.Name = "dataGridView_data";
            this.dataGridView_data.Size = new System.Drawing.Size(565, 150);
            this.dataGridView_data.TabIndex = 0;
            // 
            // comboBox_reportType
            // 
            this.comboBox_reportType.FormattingEnabled = true;
            this.comboBox_reportType.Items.AddRange(new object[] {
            "Patient Visits",
            "Common Ailments",
            "Medication"});
            this.comboBox_reportType.Location = new System.Drawing.Point(73, 266);
            this.comboBox_reportType.Name = "comboBox_reportType";
            this.comboBox_reportType.Size = new System.Drawing.Size(152, 21);
            this.comboBox_reportType.TabIndex = 1;
            this.comboBox_reportType.Text = "Report Type...";
            // 
            // button_generateReport
            // 
            this.button_generateReport.Location = new System.Drawing.Point(231, 266);
            this.button_generateReport.Name = "button_generateReport";
            this.button_generateReport.Size = new System.Drawing.Size(106, 23);
            this.button_generateReport.TabIndex = 2;
            this.button_generateReport.Text = "Generate Report";
            this.button_generateReport.UseVisualStyleBackColor = true;
            this.button_generateReport.Click += new System.EventHandler(this.button_generateReport_Click);
            // 
            // button_calculateAnalytics
            // 
            this.button_calculateAnalytics.Location = new System.Drawing.Point(515, 264);
            this.button_calculateAnalytics.Name = "button_calculateAnalytics";
            this.button_calculateAnalytics.Size = new System.Drawing.Size(123, 23);
            this.button_calculateAnalytics.TabIndex = 3;
            this.button_calculateAnalytics.Text = "Calculate Analytics";
            this.button_calculateAnalytics.UseVisualStyleBackColor = true;
            this.button_calculateAnalytics.Click += new System.EventHandler(this.button_calculateAnalytics_Click);
            // 
            // comboBox_exportFormat
            // 
            this.comboBox_exportFormat.FormattingEnabled = true;
            this.comboBox_exportFormat.Items.AddRange(new object[] {
            "CSV"});
            this.comboBox_exportFormat.Location = new System.Drawing.Point(73, 306);
            this.comboBox_exportFormat.Name = "comboBox_exportFormat";
            this.comboBox_exportFormat.Size = new System.Drawing.Size(152, 21);
            this.comboBox_exportFormat.TabIndex = 4;
            this.comboBox_exportFormat.Text = "Export Type...";
            // 
            // button_export
            // 
            this.button_export.Location = new System.Drawing.Point(231, 304);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(106, 23);
            this.button_export.TabIndex = 5;
            this.button_export.Text = "Export Report";
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_backButton
            // 
            this.button_backButton.Location = new System.Drawing.Point(73, 374);
            this.button_backButton.Name = "button_backButton";
            this.button_backButton.Size = new System.Drawing.Size(75, 23);
            this.button_backButton.TabIndex = 6;
            this.button_backButton.Text = "Return";
            this.button_backButton.UseVisualStyleBackColor = true;
            this.button_backButton.Click += new System.EventHandler(this.button_backButton_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_backButton);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.comboBox_exportFormat);
            this.Controls.Add(this.button_calculateAnalytics);
            this.Controls.Add(this.button_generateReport);
            this.Controls.Add(this.comboBox_reportType);
            this.Controls.Add(this.dataGridView_data);
            this.Name = "ReportsForm";
            this.Text = "ReportsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_data;
        private System.Windows.Forms.ComboBox comboBox_reportType;
        private System.Windows.Forms.Button button_generateReport;
        private System.Windows.Forms.Button button_calculateAnalytics;
        private System.Windows.Forms.ComboBox comboBox_exportFormat;
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.Button button_backButton;
    }
}