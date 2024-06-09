namespace BillBook
{
    partial class BillList
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITEMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VIEW = new System.Windows.Forms.DataGridViewButtonColumn();
            this.nameGroupBox = new System.Windows.Forms.GroupBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.phoneGroupBox = new System.Windows.Forms.GroupBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.nameGroupBox.SuspendLayout();
            this.phoneGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NAME,
            this.PHONE,
            this.TOTAL,
            this.ITEMS,
            this.VIEW});
            this.dataGridView1.Location = new System.Drawing.Point(0, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(818, 582);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 49;
            // 
            // NAME
            // 
            this.NAME.HeaderText = "NAME";
            this.NAME.MinimumWidth = 6;
            this.NAME.Name = "NAME";
            this.NAME.ReadOnly = true;
            this.NAME.Width = 75;
            // 
            // PHONE
            // 
            this.PHONE.HeaderText = "PHONE";
            this.PHONE.MinimumWidth = 6;
            this.PHONE.Name = "PHONE";
            this.PHONE.ReadOnly = true;
            this.PHONE.Width = 84;
            // 
            // TOTAL
            // 
            this.TOTAL.HeaderText = "TOTAL";
            this.TOTAL.MinimumWidth = 6;
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.ReadOnly = true;
            this.TOTAL.Width = 80;
            // 
            // ITEMS
            // 
            this.ITEMS.HeaderText = "ITEMS";
            this.ITEMS.MinimumWidth = 6;
            this.ITEMS.Name = "ITEMS";
            this.ITEMS.ReadOnly = true;
            this.ITEMS.Width = 77;
            // 
            // VIEW
            // 
            this.VIEW.HeaderText = "VIEW";
            this.VIEW.MinimumWidth = 6;
            this.VIEW.Name = "VIEW";
            this.VIEW.ReadOnly = true;
            this.VIEW.Width = 47;
            // 
            // nameGroupBox
            // 
            this.nameGroupBox.Controls.Add(this.nameTextBox);
            this.nameGroupBox.Location = new System.Drawing.Point(4, 4);
            this.nameGroupBox.Name = "nameGroupBox";
            this.nameGroupBox.Size = new System.Drawing.Size(200, 50);
            this.nameGroupBox.TabIndex = 1;
            this.nameGroupBox.TabStop = false;
            this.nameGroupBox.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(7, 20);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(187, 22);
            this.nameTextBox.TabIndex = 0;
            // 
            // phoneGroupBox
            // 
            this.phoneGroupBox.Controls.Add(this.phoneTextBox);
            this.phoneGroupBox.Location = new System.Drawing.Point(210, 4);
            this.phoneGroupBox.Name = "phoneGroupBox";
            this.phoneGroupBox.Size = new System.Drawing.Size(200, 50);
            this.phoneGroupBox.TabIndex = 2;
            this.phoneGroupBox.TabStop = false;
            this.phoneGroupBox.Text = "Phone";
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(7, 20);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(187, 22);
            this.phoneTextBox.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(433, 15);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // BillList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.phoneGroupBox);
            this.Controls.Add(this.nameGroupBox);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BillList";
            this.Size = new System.Drawing.Size(821, 720);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.nameGroupBox.ResumeLayout(false);
            this.nameGroupBox.PerformLayout();
            this.phoneGroupBox.ResumeLayout(false);
            this.phoneGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PHONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITEMS;
        private System.Windows.Forms.DataGridViewButtonColumn VIEW;
        private System.Windows.Forms.GroupBox nameGroupBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.GroupBox phoneGroupBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Button searchButton;
    }
}
