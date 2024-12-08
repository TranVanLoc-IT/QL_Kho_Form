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
            flowLayoutPanel1 = new FlowLayoutPanel();
            txtNote = new TextBox();
            comboBoxProductList = new ComboBox();
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
            dataGridView.Location = new Point(0, 300);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(705, 173);
            dataGridView.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(txtNote);
            panel1.Controls.Add(comboBoxProductList);
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
            panel1.Size = new Size(705, 300);
            panel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(484, 139);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(250, 155);
            flowLayoutPanel1.TabIndex = 15;
            // 
            // txtNote
            // 
            txtNote.BorderStyle = BorderStyle.None;
            txtNote.Font = new Font("Times New Roman", 13.8F);
            txtNote.Location = new Point(39, 139);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.PlaceholderText = "Thêm ghi chú..";
            txtNote.Size = new Size(422, 94);
            txtNote.TabIndex = 14;
            // 
            // comboBoxProductList
            // 
            comboBoxProductList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBoxProductList.Font = new Font("Times New Roman", 13.8F);
            comboBoxProductList.FormattingEnabled = true;
            comboBoxProductList.Location = new Point(484, 75);
            comboBoxProductList.Name = "comboBoxProductList";
            comboBoxProductList.Size = new Size(218, 34);
            comboBoxProductList.TabIndex = 13;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            deleteButton.Location = new Point(153, 239);
            deleteButton.Margin = new Padding(4, 3, 4, 3);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(60, 63);
            deleteButton.TabIndex = 8;
            // 
            // createButton
            // 
            createButton.Location = new Point(60, 239);
            createButton.Margin = new Padding(4, 3, 4, 3);
            createButton.Name = "createButton";
            createButton.Size = new Size(60, 63);
            createButton.TabIndex = 7;
            // 
            // txtProductTypeName
            // 
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
        private Label label3;
        private UCButton.DeleteButton deleteButton;
        private UCButton.CreateButton createButton;
        private TextBox txtProductTypeName;
        private Label label2;
        private TextBox txtProductTypeCode;
        private Label label1;
        private TextBox txtNote;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
