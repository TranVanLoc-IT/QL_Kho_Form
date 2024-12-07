namespace UI.Controls
{
    partial class ProductTypeControl
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
            dataGridView = new DataGridView();
            panel1 = new Panel();
            comboBoxProductList = new ComboBox();
            totalProductQuantity = new TextBox();
            label4 = new Label();
            label3 = new Label();
            deleteButton = new UCButton.DeleteButton();
            createButton = new UCButton.CreateButton();
            txtProductTypeName = new TextBox();
            label2 = new Label();
            txtProductTypeCode = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.Location = new Point(0, 262);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(705, 211);
            dataGridView.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBoxProductList);
            panel1.Controls.Add(totalProductQuantity);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(deleteButton);
            panel1.Controls.Add(createButton);
            panel1.Controls.Add(txtProductTypeName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtProductTypeCode);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(705, 262);
            panel1.TabIndex = 1;
            // 
            // comboBoxProductList
            // 
            comboBoxProductList.Font = new Font("Times New Roman", 13.8F);
            comboBoxProductList.FormattingEnabled = true;
            comboBoxProductList.Location = new Point(484, 75);
            comboBoxProductList.Name = "comboBoxProductList";
            comboBoxProductList.Size = new Size(172, 34);
            comboBoxProductList.TabIndex = 13;
            // 
            // totalProductQuantity
            // 
            totalProductQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            totalProductQuantity.BorderStyle = BorderStyle.None;
            totalProductQuantity.Enabled = false;
            totalProductQuantity.Font = new Font("Times New Roman", 13.8F);
            totalProductQuantity.Location = new Point(379, 141);
            totalProductQuantity.Name = "totalProductQuantity";
            totalProductQuantity.Size = new Size(93, 27);
            totalProductQuantity.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label4.Location = new Point(42, 143);
            label4.Name = "label4";
            label4.Size = new Size(331, 25);
            label4.TabIndex = 12;
            label4.Text = "Số lượng sản phẩm đã cung cấp";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label3.Location = new Point(484, 44);
            label3.Name = "label3";
            label3.Size = new Size(169, 25);
            label3.TabIndex = 10;
            label3.Text = "Dòng sản phẩm";
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(176, 183);
            deleteButton.Margin = new Padding(4, 3, 4, 3);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(56, 55);
            deleteButton.TabIndex = 8;
            // 
            // createButton
            // 
            createButton.Location = new Point(99, 183);
            createButton.Margin = new Padding(4, 3, 4, 3);
            createButton.Name = "createButton";
            createButton.Size = new Size(56, 55);
            createButton.TabIndex = 7;
            // 
            // txtProductTypeName
            // 
            txtProductTypeName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtProductTypeName.BorderStyle = BorderStyle.None;
            txtProductTypeName.Font = new Font("Times New Roman", 13.8F);
            txtProductTypeName.Location = new Point(250, 93);
            txtProductTypeName.Name = "txtProductTypeName";
            txtProductTypeName.Size = new Size(211, 27);
            txtProductTypeName.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label2.Location = new Point(39, 95);
            label2.Name = "label2";
            label2.Size = new Size(193, 25);
            label2.TabIndex = 6;
            label2.Text = "Tên loại sản phẩm";
            // 
            // txtProductTypeCode
            // 
            txtProductTypeCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtProductTypeCode.BorderStyle = BorderStyle.None;
            txtProductTypeCode.Enabled = false;
            txtProductTypeCode.Font = new Font("Times New Roman", 13.8F);
            txtProductTypeCode.Location = new Point(250, 44);
            txtProductTypeCode.Name = "txtProductTypeCode";
            txtProductTypeCode.Size = new Size(172, 27);
            txtProductTypeCode.TabIndex = 3;
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
            // ProductTypeControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(dataGridView);
            Name = "ProductTypeControl";
            Size = new Size(705, 473);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private Panel panel1;
        private ComboBox comboBoxProductList;
        private TextBox totalProductQuantity;
        private Label label4;
        private Label label3;
        private UCButton.DeleteButton deleteButton;
        private UCButton.CreateButton createButton;
        private TextBox txtProductTypeName;
        private Label label2;
        private TextBox txtProductTypeCode;
        private Label label1;
    }
}
