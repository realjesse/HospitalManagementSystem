namespace HospitalClient.Forms
{
    partial class InventoryForm
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
            this.inventoryGridView = new System.Windows.Forms.DataGridView();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.itemNameLabel = new System.Windows.Forms.Label();
            this.quantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minimumStockNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.unitTextBox = new System.Windows.Forms.TextBox();
            this.unitLabel = new System.Windows.Forms.Label();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.minimumStockLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumStockNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // inventoryGridView
            // 
            this.inventoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventoryGridView.Location = new System.Drawing.Point(27, 40);
            this.inventoryGridView.Name = "inventoryGridView";
            this.inventoryGridView.Size = new System.Drawing.Size(365, 193);
            this.inventoryGridView.TabIndex = 0;
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.Location = new System.Drawing.Point(468, 40);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.itemNameTextBox.TabIndex = 1;
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.Location = new System.Drawing.Point(468, 72);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(100, 20);
            this.categoryTextBox.TabIndex = 2;
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(400, 79);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(52, 13);
            this.categoryLabel.TabIndex = 3;
            this.categoryLabel.Text = "Category:";
            // 
            // itemNameLabel
            // 
            this.itemNameLabel.AutoSize = true;
            this.itemNameLabel.Location = new System.Drawing.Point(400, 47);
            this.itemNameLabel.Name = "itemNameLabel";
            this.itemNameLabel.Size = new System.Drawing.Size(30, 13);
            this.itemNameLabel.TabIndex = 4;
            this.itemNameLabel.Text = "Item:";
            // 
            // quantityNumericUpDown
            // 
            this.quantityNumericUpDown.Location = new System.Drawing.Point(123, 295);
            this.quantityNumericUpDown.Name = "quantityNumericUpDown";
            this.quantityNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.quantityNumericUpDown.TabIndex = 5;
            // 
            // minimumStockNumericUpDown
            // 
            this.minimumStockNumericUpDown.Location = new System.Drawing.Point(123, 256);
            this.minimumStockNumericUpDown.Name = "minimumStockNumericUpDown";
            this.minimumStockNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.minimumStockNumericUpDown.TabIndex = 6;
            // 
            // unitTextBox
            // 
            this.unitTextBox.Location = new System.Drawing.Point(468, 110);
            this.unitTextBox.Name = "unitTextBox";
            this.unitTextBox.Size = new System.Drawing.Size(100, 20);
            this.unitTextBox.TabIndex = 7;
            // 
            // unitLabel
            // 
            this.unitLabel.AutoSize = true;
            this.unitLabel.Location = new System.Drawing.Point(401, 117);
            this.unitLabel.Name = "unitLabel";
            this.unitLabel.Size = new System.Drawing.Size(29, 13);
            this.unitLabel.TabIndex = 8;
            this.unitLabel.Text = "Unit:";
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(24, 295);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(49, 13);
            this.quantityLabel.TabIndex = 9;
            this.quantityLabel.Text = "Quantity:";
            // 
            // minimumStockLabel
            // 
            this.minimumStockLabel.AutoSize = true;
            this.minimumStockLabel.Location = new System.Drawing.Point(24, 258);
            this.minimumStockLabel.Name = "minimumStockLabel";
            this.minimumStockLabel.Size = new System.Drawing.Size(82, 13);
            this.minimumStockLabel.TabIndex = 10;
            this.minimumStockLabel.Text = "Minimum Stock:";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(317, 258);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(317, 295);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 12;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(398, 258);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 13;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(398, 295);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 14;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(493, 379);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 15;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 410);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.minimumStockLabel);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.unitLabel);
            this.Controls.Add(this.unitTextBox);
            this.Controls.Add(this.minimumStockNumericUpDown);
            this.Controls.Add(this.quantityNumericUpDown);
            this.Controls.Add(this.itemNameLabel);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.itemNameTextBox);
            this.Controls.Add(this.inventoryGridView);
            this.Name = "InventoryForm";
            this.Text = "InventoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumStockNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView inventoryGridView;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label itemNameLabel;
        private System.Windows.Forms.NumericUpDown quantityNumericUpDown;
        private System.Windows.Forms.NumericUpDown minimumStockNumericUpDown;
        private System.Windows.Forms.TextBox unitTextBox;
        private System.Windows.Forms.Label unitLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label minimumStockLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button backButton;
    }
}