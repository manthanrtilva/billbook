namespace BillBook
{
    partial class MasterBill
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.customerGroupBox = new System.Windows.Forms.GroupBox();
            this.cAddressGroupBox = new System.Windows.Forms.GroupBox();
            this.cAddressTextBox = new System.Windows.Forms.TextBox();
            this.cGSTGroupBox = new System.Windows.Forms.GroupBox();
            this.cGSTTextBox = new System.Windows.Forms.TextBox();
            this.cEmailgroupBox = new System.Windows.Forms.GroupBox();
            this.cEMailTextBox = new System.Windows.Forms.TextBox();
            this.phoneGroupBox = new System.Windows.Forms.GroupBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.cNameGroupBox = new System.Windows.Forms.GroupBox();
            this.cNameTextBox = new System.Windows.Forms.TextBox();
            this.purchaseGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.paystatusComboBox = new System.Windows.Forms.ComboBox();
            this.printButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.totalGroupBox = new System.Windows.Forms.GroupBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.itemGroupBox = new System.Windows.Forms.GroupBox();
            this.itemsLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.customerGroupBox.SuspendLayout();
            this.cAddressGroupBox.SuspendLayout();
            this.cGSTGroupBox.SuspendLayout();
            this.cEmailgroupBox.SuspendLayout();
            this.phoneGroupBox.SuspendLayout();
            this.cNameGroupBox.SuspendLayout();
            this.purchaseGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.totalGroupBox.SuspendLayout();
            this.itemGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.customerGroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.purchaseGroupBox);
            this.splitContainer1.Size = new System.Drawing.Size(1751, 556);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.TabIndex = 0;
            // 
            // customerGroupBox
            // 
            this.customerGroupBox.Controls.Add(this.cAddressGroupBox);
            this.customerGroupBox.Controls.Add(this.cGSTGroupBox);
            this.customerGroupBox.Controls.Add(this.cEmailgroupBox);
            this.customerGroupBox.Controls.Add(this.phoneGroupBox);
            this.customerGroupBox.Controls.Add(this.cNameGroupBox);
            this.customerGroupBox.Location = new System.Drawing.Point(3, 3);
            this.customerGroupBox.Name = "customerGroupBox";
            this.customerGroupBox.Size = new System.Drawing.Size(1742, 200);
            this.customerGroupBox.TabIndex = 0;
            this.customerGroupBox.TabStop = false;
            this.customerGroupBox.Text = "Customer";
            // 
            // cAddressGroupBox
            // 
            this.cAddressGroupBox.Controls.Add(this.cAddressTextBox);
            this.cAddressGroupBox.Location = new System.Drawing.Point(7, 133);
            this.cAddressGroupBox.Name = "cAddressGroupBox";
            this.cAddressGroupBox.Size = new System.Drawing.Size(470, 50);
            this.cAddressGroupBox.TabIndex = 2;
            this.cAddressGroupBox.TabStop = false;
            this.cAddressGroupBox.Text = "Address";
            // 
            // cAddressTextBox
            // 
            this.cAddressTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cAddressTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cAddressTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cAddressTextBox.Location = new System.Drawing.Point(6, 20);
            this.cAddressTextBox.Name = "cAddressTextBox";
            this.cAddressTextBox.Size = new System.Drawing.Size(458, 22);
            this.cAddressTextBox.TabIndex = 0;
            // 
            // cGSTGroupBox
            // 
            this.cGSTGroupBox.Controls.Add(this.cGSTTextBox);
            this.cGSTGroupBox.Location = new System.Drawing.Point(282, 78);
            this.cGSTGroupBox.Name = "cGSTGroupBox";
            this.cGSTGroupBox.Size = new System.Drawing.Size(195, 50);
            this.cGSTGroupBox.TabIndex = 2;
            this.cGSTGroupBox.TabStop = false;
            this.cGSTGroupBox.Text = "GST";
            // 
            // cGSTTextBox
            // 
            this.cGSTTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cGSTTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cGSTTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cGSTTextBox.Location = new System.Drawing.Point(6, 20);
            this.cGSTTextBox.Name = "cGSTTextBox";
            this.cGSTTextBox.Size = new System.Drawing.Size(183, 22);
            this.cGSTTextBox.TabIndex = 0;
            // 
            // cEmailgroupBox
            // 
            this.cEmailgroupBox.Controls.Add(this.cEMailTextBox);
            this.cEmailgroupBox.Location = new System.Drawing.Point(7, 78);
            this.cEmailgroupBox.Name = "cEmailgroupBox";
            this.cEmailgroupBox.Size = new System.Drawing.Size(236, 50);
            this.cEmailgroupBox.TabIndex = 1;
            this.cEmailgroupBox.TabStop = false;
            this.cEmailgroupBox.Text = "EMail";
            // 
            // cEMailTextBox
            // 
            this.cEMailTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cEMailTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cEMailTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cEMailTextBox.Location = new System.Drawing.Point(6, 20);
            this.cEMailTextBox.Name = "cEMailTextBox";
            this.cEMailTextBox.Size = new System.Drawing.Size(217, 22);
            this.cEMailTextBox.TabIndex = 0;
            // 
            // phoneGroupBox
            // 
            this.phoneGroupBox.Controls.Add(this.phoneTextBox);
            this.phoneGroupBox.Location = new System.Drawing.Point(282, 22);
            this.phoneGroupBox.Name = "phoneGroupBox";
            this.phoneGroupBox.Size = new System.Drawing.Size(195, 50);
            this.phoneGroupBox.TabIndex = 1;
            this.phoneGroupBox.TabStop = false;
            this.phoneGroupBox.Text = "Phone";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.phoneTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.phoneTextBox.Location = new System.Drawing.Point(6, 20);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(183, 22);
            this.phoneTextBox.TabIndex = 0;
            // 
            // cNameGroupBox
            // 
            this.cNameGroupBox.Controls.Add(this.cNameTextBox);
            this.cNameGroupBox.Location = new System.Drawing.Point(7, 22);
            this.cNameGroupBox.Name = "cNameGroupBox";
            this.cNameGroupBox.Size = new System.Drawing.Size(236, 50);
            this.cNameGroupBox.TabIndex = 0;
            this.cNameGroupBox.TabStop = false;
            this.cNameGroupBox.Text = "Name";
            // 
            // cNameTextBox
            // 
            this.cNameTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cNameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cNameTextBox.Location = new System.Drawing.Point(6, 20);
            this.cNameTextBox.Name = "cNameTextBox";
            this.cNameTextBox.Size = new System.Drawing.Size(217, 22);
            this.cNameTextBox.TabIndex = 0;
            // 
            // purchaseGroupBox
            // 
            this.purchaseGroupBox.AutoSize = true;
            this.purchaseGroupBox.Controls.Add(this.groupBox1);
            this.purchaseGroupBox.Controls.Add(this.printButton);
            this.purchaseGroupBox.Controls.Add(this.saveButton);
            this.purchaseGroupBox.Controls.Add(this.tableLayoutPanel1);
            this.purchaseGroupBox.Controls.Add(this.totalGroupBox);
            this.purchaseGroupBox.Controls.Add(this.itemGroupBox);
            this.purchaseGroupBox.Controls.Add(this.addButton);
            this.purchaseGroupBox.Location = new System.Drawing.Point(4, 4);
            this.purchaseGroupBox.Name = "purchaseGroupBox";
            this.purchaseGroupBox.Size = new System.Drawing.Size(1744, 322);
            this.purchaseGroupBox.TabIndex = 0;
            this.purchaseGroupBox.TabStop = false;
            this.purchaseGroupBox.Text = "Purchase";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.paystatusComboBox);
            this.groupBox1.Location = new System.Drawing.Point(583, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 52);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment";
            // 
            // paystatusComboBox
            // 
            this.paystatusComboBox.FormattingEnabled = true;
            this.paystatusComboBox.Items.AddRange(new object[] {
            "PAID",
            "PENDING",
            "PART_PAID"});
            this.paystatusComboBox.Location = new System.Drawing.Point(7, 18);
            this.paystatusComboBox.Name = "paystatusComboBox";
            this.paystatusComboBox.Size = new System.Drawing.Size(187, 24);
            this.paystatusComboBox.TabIndex = 0;
            // 
            // printButton
            // 
            this.printButton.Enabled = false;
            this.printButton.Location = new System.Drawing.Point(501, 22);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(75, 23);
            this.printButton.TabIndex = 5;
            this.printButton.Text = "Print";
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(419, 22);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 83);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(203, 114);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 48);
            this.label2.TabIndex = 1;
            this.label2.Text = "Units";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 112);
            this.label3.TabIndex = 2;
            this.label3.Text = "Unit Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 48);
            this.label4.TabIndex = 3;
            this.label4.Text = "GST";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 80);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total";
            // 
            // totalGroupBox
            // 
            this.totalGroupBox.AutoSize = true;
            this.totalGroupBox.Controls.Add(this.totalLabel);
            this.totalGroupBox.Location = new System.Drawing.Point(249, 22);
            this.totalGroupBox.Name = "totalGroupBox";
            this.totalGroupBox.Size = new System.Drawing.Size(164, 52);
            this.totalGroupBox.TabIndex = 2;
            this.totalGroupBox.TabStop = false;
            this.totalGroupBox.Text = "Total";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(6, 18);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(0, 16);
            this.totalLabel.TabIndex = 0;
            // 
            // itemGroupBox
            // 
            this.itemGroupBox.AutoSize = true;
            this.itemGroupBox.Controls.Add(this.itemsLabel);
            this.itemGroupBox.Location = new System.Drawing.Point(88, 21);
            this.itemGroupBox.Name = "itemGroupBox";
            this.itemGroupBox.Size = new System.Drawing.Size(155, 53);
            this.itemGroupBox.TabIndex = 1;
            this.itemGroupBox.TabStop = false;
            this.itemGroupBox.Text = "Items";
            // 
            // itemsLabel
            // 
            this.itemsLabel.AutoSize = true;
            this.itemsLabel.Location = new System.Drawing.Point(6, 18);
            this.itemsLabel.Name = "itemsLabel";
            this.itemsLabel.Size = new System.Drawing.Size(0, 16);
            this.itemsLabel.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(7, 22);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // MasterBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainer1);
            this.Name = "MasterBill";
            this.Size = new System.Drawing.Size(1751, 556);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.customerGroupBox.ResumeLayout(false);
            this.cAddressGroupBox.ResumeLayout(false);
            this.cAddressGroupBox.PerformLayout();
            this.cGSTGroupBox.ResumeLayout(false);
            this.cGSTGroupBox.PerformLayout();
            this.cEmailgroupBox.ResumeLayout(false);
            this.cEmailgroupBox.PerformLayout();
            this.phoneGroupBox.ResumeLayout(false);
            this.phoneGroupBox.PerformLayout();
            this.cNameGroupBox.ResumeLayout(false);
            this.cNameGroupBox.PerformLayout();
            this.purchaseGroupBox.ResumeLayout(false);
            this.purchaseGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.totalGroupBox.ResumeLayout(false);
            this.totalGroupBox.PerformLayout();
            this.itemGroupBox.ResumeLayout(false);
            this.itemGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox customerGroupBox;
        private System.Windows.Forms.GroupBox cNameGroupBox;
        private System.Windows.Forms.TextBox cNameTextBox;
        private System.Windows.Forms.GroupBox phoneGroupBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.GroupBox cGSTGroupBox;
        private System.Windows.Forms.TextBox cGSTTextBox;
        private System.Windows.Forms.GroupBox cEmailgroupBox;
        private System.Windows.Forms.TextBox cEMailTextBox;
        private System.Windows.Forms.GroupBox cAddressGroupBox;
        private System.Windows.Forms.TextBox cAddressTextBox;
        private System.Windows.Forms.GroupBox purchaseGroupBox;
        private System.Windows.Forms.GroupBox itemGroupBox;
        private System.Windows.Forms.Label itemsLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox totalGroupBox;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox paystatusComboBox;
    }
}
