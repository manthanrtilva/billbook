namespace BillBook
{
    partial class Customer
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
            this.nameGroupBox = new System.Windows.Forms.GroupBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.phoneGroupBox = new System.Windows.Forms.GroupBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.emailGroupBox = new System.Windows.Forms.GroupBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.addressGroupBox = new System.Windows.Forms.GroupBox();
            this.gstGroupBox = new System.Windows.Forms.GroupBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.gstTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nameGroupBox.SuspendLayout();
            this.phoneGroupBox.SuspendLayout();
            this.emailGroupBox.SuspendLayout();
            this.addressGroupBox.SuspendLayout();
            this.gstGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameGroupBox
            // 
            this.nameGroupBox.Controls.Add(this.nameTextBox);
            this.nameGroupBox.Location = new System.Drawing.Point(2, 0);
            this.nameGroupBox.Name = "nameGroupBox";
            this.nameGroupBox.Size = new System.Drawing.Size(790, 50);
            this.nameGroupBox.TabIndex = 0;
            this.nameGroupBox.TabStop = false;
            this.nameGroupBox.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(6, 21);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(780, 22);
            this.nameTextBox.TabIndex = 0;
            // 
            // phoneGroupBox
            // 
            this.phoneGroupBox.Controls.Add(this.phoneTextBox);
            this.phoneGroupBox.Location = new System.Drawing.Point(2, 60);
            this.phoneGroupBox.Name = "phoneGroupBox";
            this.phoneGroupBox.Size = new System.Drawing.Size(790, 50);
            this.phoneGroupBox.TabIndex = 1;
            this.phoneGroupBox.TabStop = false;
            this.phoneGroupBox.Text = "Phone";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(6, 21);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(780, 22);
            this.phoneTextBox.TabIndex = 0;
            // 
            // emailGroupBox
            // 
            this.emailGroupBox.Controls.Add(this.emailTextBox);
            this.emailGroupBox.Location = new System.Drawing.Point(2, 120);
            this.emailGroupBox.Name = "emailGroupBox";
            this.emailGroupBox.Size = new System.Drawing.Size(790, 50);
            this.emailGroupBox.TabIndex = 2;
            this.emailGroupBox.TabStop = false;
            this.emailGroupBox.Text = "EMail";
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(6, 21);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(780, 22);
            this.emailTextBox.TabIndex = 0;
            // 
            // addressGroupBox
            // 
            this.addressGroupBox.Controls.Add(this.addressTextBox);
            this.addressGroupBox.Location = new System.Drawing.Point(2, 180);
            this.addressGroupBox.Name = "addressGroupBox";
            this.addressGroupBox.Size = new System.Drawing.Size(790, 50);
            this.addressGroupBox.TabIndex = 3;
            this.addressGroupBox.TabStop = false;
            this.addressGroupBox.Text = "Address";
            // 
            // gstGroupBox
            // 
            this.gstGroupBox.Controls.Add(this.gstTextBox);
            this.gstGroupBox.Location = new System.Drawing.Point(2, 240);
            this.gstGroupBox.Name = "gstGroupBox";
            this.gstGroupBox.Size = new System.Drawing.Size(790, 50);
            this.gstGroupBox.TabIndex = 4;
            this.gstGroupBox.TabStop = false;
            this.gstGroupBox.Text = "GST";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(6, 21);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(780, 22);
            this.addressTextBox.TabIndex = 0;
            // 
            // gstTextBox
            // 
            this.gstTextBox.Location = new System.Drawing.Point(6, 21);
            this.gstTextBox.Name = "gstTextBox";
            this.gstTextBox.Size = new System.Drawing.Size(780, 22);
            this.gstTextBox.TabIndex = 0;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(13, 317);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(713, 317);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // Customer
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(800, 365);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.gstGroupBox);
            this.Controls.Add(this.addressGroupBox);
            this.Controls.Add(this.emailGroupBox);
            this.Controls.Add(this.phoneGroupBox);
            this.Controls.Add(this.nameGroupBox);
            this.Name = "Customer";
            this.Text = "Customer";
            this.nameGroupBox.ResumeLayout(false);
            this.nameGroupBox.PerformLayout();
            this.phoneGroupBox.ResumeLayout(false);
            this.phoneGroupBox.PerformLayout();
            this.emailGroupBox.ResumeLayout(false);
            this.emailGroupBox.PerformLayout();
            this.addressGroupBox.ResumeLayout(false);
            this.addressGroupBox.PerformLayout();
            this.gstGroupBox.ResumeLayout(false);
            this.gstGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox nameGroupBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.GroupBox phoneGroupBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.GroupBox emailGroupBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.GroupBox addressGroupBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.GroupBox gstGroupBox;
        private System.Windows.Forms.TextBox gstTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}