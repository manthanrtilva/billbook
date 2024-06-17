namespace BillBook
{
    partial class SellerSettings
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
            this.gstGroupBox = new System.Windows.Forms.GroupBox();
            this.gstTextBox = new System.Windows.Forms.TextBox();
            this.panGroupBox = new System.Windows.Forms.GroupBox();
            this.panTextBox = new System.Windows.Forms.TextBox();
            this.statecodeGroupBox = new System.Windows.Forms.GroupBox();
            this.statecodeTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.gstGroupBox.SuspendLayout();
            this.panGroupBox.SuspendLayout();
            this.statecodeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gstGroupBox
            // 
            this.gstGroupBox.Controls.Add(this.gstTextBox);
            this.gstGroupBox.Location = new System.Drawing.Point(3, 3);
            this.gstGroupBox.Name = "gstGroupBox";
            this.gstGroupBox.Size = new System.Drawing.Size(236, 42);
            this.gstGroupBox.TabIndex = 0;
            this.gstGroupBox.TabStop = false;
            this.gstGroupBox.Text = "GST NO";
            // 
            // gstTextBox
            // 
            this.gstTextBox.Location = new System.Drawing.Point(0, 16);
            this.gstTextBox.Name = "gstTextBox";
            this.gstTextBox.Size = new System.Drawing.Size(231, 20);
            this.gstTextBox.TabIndex = 0;
            // 
            // panGroupBox
            // 
            this.panGroupBox.Controls.Add(this.panTextBox);
            this.panGroupBox.Location = new System.Drawing.Point(3, 51);
            this.panGroupBox.Name = "panGroupBox";
            this.panGroupBox.Size = new System.Drawing.Size(236, 42);
            this.panGroupBox.TabIndex = 1;
            this.panGroupBox.TabStop = false;
            this.panGroupBox.Text = "PAN NO";
            // 
            // panTextBox
            // 
            this.panTextBox.Location = new System.Drawing.Point(0, 16);
            this.panTextBox.Name = "panTextBox";
            this.panTextBox.Size = new System.Drawing.Size(231, 20);
            this.panTextBox.TabIndex = 0;
            // 
            // statecodeGroupBox
            // 
            this.statecodeGroupBox.Controls.Add(this.statecodeTextBox);
            this.statecodeGroupBox.Location = new System.Drawing.Point(3, 99);
            this.statecodeGroupBox.Name = "statecodeGroupBox";
            this.statecodeGroupBox.Size = new System.Drawing.Size(236, 42);
            this.statecodeGroupBox.TabIndex = 2;
            this.statecodeGroupBox.TabStop = false;
            this.statecodeGroupBox.Text = "STATE CODE";
            // 
            // statecodeTextBox
            // 
            this.statecodeTextBox.Location = new System.Drawing.Point(0, 16);
            this.statecodeTextBox.Name = "statecodeTextBox";
            this.statecodeTextBox.Size = new System.Drawing.Size(231, 20);
            this.statecodeTextBox.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(164, 147);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // SellerSettings
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 181);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.statecodeGroupBox);
            this.Controls.Add(this.panGroupBox);
            this.Controls.Add(this.gstGroupBox);
            this.Name = "SellerSettings";
            this.Text = "SellerSettings";
            this.gstGroupBox.ResumeLayout(false);
            this.gstGroupBox.PerformLayout();
            this.panGroupBox.ResumeLayout(false);
            this.panGroupBox.PerformLayout();
            this.statecodeGroupBox.ResumeLayout(false);
            this.statecodeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gstGroupBox;
        private System.Windows.Forms.TextBox gstTextBox;
        private System.Windows.Forms.GroupBox panGroupBox;
        private System.Windows.Forms.TextBox panTextBox;
        private System.Windows.Forms.GroupBox statecodeGroupBox;
        private System.Windows.Forms.TextBox statecodeTextBox;
        private System.Windows.Forms.Button saveButton;
    }
}