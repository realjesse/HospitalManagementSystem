namespace HospitalClient.Forms
{
    partial class MenuForm
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
            this.viewPatientInfoButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.appointmentsButton = new System.Windows.Forms.Button();
            this.inventoryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // viewPatientInfoButton
            // 
            this.viewPatientInfoButton.Location = new System.Drawing.Point(121, 87);
            this.viewPatientInfoButton.Name = "viewPatientInfoButton";
            this.viewPatientInfoButton.Size = new System.Drawing.Size(110, 23);
            this.viewPatientInfoButton.TabIndex = 0;
            this.viewPatientInfoButton.Text = "View Patient Info";
            this.viewPatientInfoButton.UseVisualStyleBackColor = true;
            this.viewPatientInfoButton.Click += new System.EventHandler(this.viewPatientInfoButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hello user";
            // 
            // appointmentsButton
            // 
            this.appointmentsButton.Location = new System.Drawing.Point(121, 129);
            this.appointmentsButton.Name = "appointmentsButton";
            this.appointmentsButton.Size = new System.Drawing.Size(110, 23);
            this.appointmentsButton.TabIndex = 2;
            this.appointmentsButton.Text = "View Appointments";
            this.appointmentsButton.UseVisualStyleBackColor = true;
            this.appointmentsButton.Click += new System.EventHandler(this.appointmentsButton_Click);
            // 
            // inventoryButton
            // 
            this.inventoryButton.Location = new System.Drawing.Point(121, 171);
            this.inventoryButton.Name = "inventoryButton";
            this.inventoryButton.Size = new System.Drawing.Size(110, 23);
            this.inventoryButton.TabIndex = 3;
            this.inventoryButton.Text = "View Inventory";
            this.inventoryButton.UseVisualStyleBackColor = true;
            this.inventoryButton.Click += new System.EventHandler(this.inventoryButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 293);
            this.Controls.Add(this.inventoryButton);
            this.Controls.Add(this.appointmentsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewPatientInfoButton);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button viewPatientInfoButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button appointmentsButton;
        private System.Windows.Forms.Button inventoryButton;
    }
}