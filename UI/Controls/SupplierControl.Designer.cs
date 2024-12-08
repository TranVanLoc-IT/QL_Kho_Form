namespace UI.Controls
{
    partial class SupplierControl
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
            panel1 = new Panel();
            dataGridViewProductSupplied = new DataGridView();
            textBoxTotalQuantitySupply = new TextBox();
            textBox2 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            deleteButton1 = new UCButton.DeleteButton();
            createButton1 = new UCButton.CreateButton();
            txtSupplierName = new TextBox();
            label2 = new Label();
            txtSupplierCode = new TextBox();
            label1 = new Label();
            dataGridView = new DataGridView();
            cbProduct = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductSupplied).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cbProduct);
            panel1.Controls.Add(dataGridViewProductSupplied);
            panel1.Controls.Add(textBoxTotalQuantitySupply);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(deleteButton1);
            panel1.Controls.Add(createButton1);
            panel1.Controls.Add(txtSupplierName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtSupplierCode);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(759, 269);
            panel1.TabIndex = 3;
            // 
            // dataGridViewProductSupplied
            // 
            dataGridViewProductSupplied.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewProductSupplied.BackgroundColor = SystemColors.ActiveCaption;
            dataGridViewProductSupplied.BorderStyle = BorderStyle.None;
            dataGridViewProductSupplied.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProductSupplied.Location = new Point(308, 139);
            dataGridViewProductSupplied.Name = "dataGridViewProductSupplied";
            dataGridViewProductSupplied.RowHeadersWidth = 51;
            dataGridViewProductSupplied.Size = new Size(296, 124);
            dataGridViewProductSupplied.TabIndex = 4;
            // 
            // textBoxTotalQuantitySupply
            // 
            textBoxTotalQuantitySupply.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxTotalQuantitySupply.Enabled = false;
            textBoxTotalQuantitySupply.Font = new Font("Times New Roman", 13.8F);
            textBoxTotalQuantitySupply.Location = new Point(524, 82);
            textBoxTotalQuantitySupply.Name = "textBoxTotalQuantitySupply";
            textBoxTotalQuantitySupply.Size = new Size(172, 34);
            textBoxTotalQuantitySupply.TabIndex = 14;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox2.Font = new Font("Times New Roman", 12F);
            textBox2.Location = new Point(769, 212);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(93, 30);
            textBox2.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label4.Location = new Point(518, 39);
            label4.Name = "label4";
            label4.Size = new Size(228, 25);
            label4.TabIndex = 12;
            label4.Text = "Số lượng đã cung cấp";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label3.Location = new Point(39, 155);
            label3.Name = "label3";
            label3.Size = new Size(266, 25);
            label3.TabIndex = 10;
            label3.Text = "Dòng sản phẩm cung cấp";
            // 
            // deleteButton1
            // 
            deleteButton1.Location = new Point(107, 189);
            deleteButton1.Margin = new Padding(4, 3, 4, 3);
            deleteButton1.Name = "deleteButton1";
            deleteButton1.Size = new Size(56, 55);
            deleteButton1.TabIndex = 8;
            // 
            // createButton1
            // 
            createButton1.Location = new Point(192, 189);
            createButton1.Margin = new Padding(4, 3, 4, 3);
            createButton1.Name = "createButton1";
            createButton1.Size = new Size(56, 55);
            createButton1.TabIndex = 7;
            // 
            // txtSupplierName
            // 
            txtSupplierName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSupplierName.Font = new Font("Times New Roman", 13.8F);
            txtSupplierName.Location = new Point(152, 82);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(331, 34);
            txtSupplierName.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label2.Location = new Point(39, 95);
            label2.Name = "label2";
            label2.Size = new Size(107, 25);
            label2.TabIndex = 6;
            label2.Text = "Tên NCC";
            // 
            // txtSupplierCode
            // 
            txtSupplierCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtSupplierCode.BorderStyle = BorderStyle.None;
            txtSupplierCode.Enabled = false;
            txtSupplierCode.Font = new Font("Times New Roman", 13.8F);
            txtSupplierCode.Location = new Point(152, 39);
            txtSupplierCode.Name = "txtSupplierCode";
            txtSupplierCode.Size = new Size(172, 27);
            txtSupplierCode.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label1.Location = new Point(39, 46);
            label1.Name = "label1";
            label1.Size = new Size(106, 25);
            label1.TabIndex = 4;
            label1.Text = "Mã Code";
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.Location = new Point(0, 269);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(759, 166);
            dataGridView.TabIndex = 2;
            // 
            // cbProduct
            // 
            cbProduct.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbProduct.FormattingEnabled = true;
            cbProduct.Location = new Point(610, 232);
            cbProduct.Name = "cbProduct";
            cbProduct.Size = new Size(151, 33);
            cbProduct.TabIndex = 15;
            // 
            // SupplierControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(dataGridView);
            Name = "SupplierControl";
            Size = new Size(759, 435);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductSupplied).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox2;
        private Label label4;
        private Label label3;
        private UCButton.DeleteButton deleteButton1;
        private UCButton.CreateButton createButton1;
        private TextBox txtSupplierName;
        private Label label2;
        private TextBox txtSupplierCode;
        private Label label1;
        private DataGridView dataGridView;
        private TextBox textBoxTotalQuantitySupply;
        private DataGridView dataGridViewProductSupplied;
        private ComboBox cbProduct;
    }
}
