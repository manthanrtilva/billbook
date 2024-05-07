namespace BillBook
{
    partial class Product
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameGroupBox = new System.Windows.Forms.GroupBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.priceGroupBox = new System.Windows.Forms.GroupBox();
            this.priceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gstGroupBox = new System.Windows.Forms.GroupBox();
            this.gstNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.quantityGroupBox = new System.Windows.Forms.GroupBox();
            this.quantityNmericUpDown = new System.Windows.Forms.NumericUpDown();
            this.nameGroupBox.SuspendLayout();
            this.priceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).BeginInit();
            this.gstGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gstNumericUpDown)).BeginInit();
            this.quantityGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNmericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // nameGroupBox
            // 
            this.nameGroupBox.Controls.Add(this.nameTextBox);
            this.nameGroupBox.Location = new System.Drawing.Point(2, 0);
            this.nameGroupBox.Name = "nameGroupBox";
            this.nameGroupBox.Size = new System.Drawing.Size(330, 50);
            this.nameGroupBox.TabIndex = 0;
            this.nameGroupBox.TabStop = false;
            this.nameGroupBox.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(6, 19);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(304, 22);
            this.nameTextBox.TabIndex = 0;
            // 
            // priceGroupBox
            // 
            this.priceGroupBox.Controls.Add(this.priceNumericUpDown);
            this.priceGroupBox.Location = new System.Drawing.Point(2, 60);
            this.priceGroupBox.Name = "priceGroupBox";
            this.priceGroupBox.Size = new System.Drawing.Size(330, 50);
            this.priceGroupBox.TabIndex = 1;
            this.priceGroupBox.TabStop = false;
            this.priceGroupBox.Text = "Price";
            // 
            // priceNumericUpDown
            // 
            this.priceNumericUpDown.Location = new System.Drawing.Point(6, 19);
            this.priceNumericUpDown.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.priceNumericUpDown.Name = "priceNumericUpDown";
            this.priceNumericUpDown.Size = new System.Drawing.Size(304, 22);
            this.priceNumericUpDown.TabIndex = 0;
            // 
            // gstGroupBox
            // 
            this.gstGroupBox.Controls.Add(this.gstNumericUpDown);
            this.gstGroupBox.Location = new System.Drawing.Point(2, 120);
            this.gstGroupBox.Name = "gstGroupBox";
            this.gstGroupBox.Size = new System.Drawing.Size(330, 50);
            this.gstGroupBox.TabIndex = 2;
            this.gstGroupBox.TabStop = false;
            this.gstGroupBox.Text = "GST";
            // 
            // gstNumericUpDown
            // 
            this.gstNumericUpDown.Location = new System.Drawing.Point(6, 19);
            this.gstNumericUpDown.Name = "gstNumericUpDown";
            this.gstNumericUpDown.Size = new System.Drawing.Size(304, 22);
            this.gstNumericUpDown.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 240);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(228, 240);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // quantityGroupBox
            // 
            this.quantityGroupBox.Controls.Add(this.quantityNmericUpDown);
            this.quantityGroupBox.Location = new System.Drawing.Point(2, 180);
            this.quantityGroupBox.Name = "quantityGroupBox";
            this.quantityGroupBox.Size = new System.Drawing.Size(330, 50);
            this.quantityGroupBox.TabIndex = 3;
            this.quantityGroupBox.TabStop = false;
            this.quantityGroupBox.Text = "Quantity";
            // 
            // quantityNmericUpDown
            // 
            this.quantityNmericUpDown.Location = new System.Drawing.Point(6, 19);
            this.quantityNmericUpDown.Name = "quantityNmericUpDown";
            this.quantityNmericUpDown.Size = new System.Drawing.Size(304, 22);
            this.quantityNmericUpDown.TabIndex = 1;
            // 
            // Product
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(336, 275);
            this.Controls.Add(this.quantityGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.gstGroupBox);
            this.Controls.Add(this.priceGroupBox);
            this.Controls.Add(this.nameGroupBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Product";
            this.Load += new System.EventHandler(this.Product_Load);
            this.nameGroupBox.ResumeLayout(false);
            this.nameGroupBox.PerformLayout();
            this.priceGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).EndInit();
            this.gstGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gstNumericUpDown)).EndInit();
            this.quantityGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.quantityNmericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox nameGroupBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.GroupBox priceGroupBox;
        private System.Windows.Forms.GroupBox gstGroupBox;
        private System.Windows.Forms.NumericUpDown priceNumericUpDown;
        private System.Windows.Forms.NumericUpDown gstNumericUpDown;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox quantityGroupBox;
        private System.Windows.Forms.NumericUpDown quantityNmericUpDown;
    }
}
