namespace UI.Controls
{
    partial class UnitControl
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

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            txtNote = new TextBox();
            dataGridViewProductApply = new DataGridView();
            deleteButton = new UCButton.DeleteButton();
            panel1 = new Panel();
            acceptButton = new UCButton.AcceptButton();
            cbProducts = new ComboBox();
            createButton = new UCButton.CreateButton();
            txtUnitName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtUnitCode = new TextBox();
            dataGridView1 = new DataGridView();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductApply).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.AutoSize = true;
            groupBox1.Dock = DockStyle.Left;
            groupBox1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(6, 426);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin đơn vị tính";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.GradientInactiveCaption;
            groupBox2.Controls.Add(txtNote);
            groupBox2.Controls.Add(dataGridViewProductApply);
            groupBox2.Controls.Add(deleteButton);
            groupBox2.Controls.Add(panel1);
            groupBox2.Controls.Add(createButton);
            groupBox2.Controls.Add(txtUnitName);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtUnitCode);
            groupBox2.Dock = DockStyle.Right;
            groupBox2.FlatStyle = FlatStyle.System;
            groupBox2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(401, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(522, 426);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Các sản phẩm áp dụng";
            // 
            // txtNote
            // 
            txtNote.BorderStyle = BorderStyle.None;
            txtNote.Font = new Font("Times New Roman", 13.8F);
            txtNote.Location = new Point(200, 328);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.PlaceholderText = "Ghi chú thêm ..";
            txtNote.Size = new Size(316, 90);
            txtNote.TabIndex = 11;
            // 
            // dataGridViewProductApply
            // 
            dataGridViewProductApply.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProductApply.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewProductApply.BackgroundColor = Color.Silver;
            dataGridViewProductApply.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewProductApply.ColumnHeadersHeight = 29;
            dataGridViewProductApply.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewProductApply.Dock = DockStyle.Top;
            dataGridViewProductApply.Location = new Point(3, 90);
            dataGridViewProductApply.Name = "dataGridViewProductApply";
            dataGridViewProductApply.RightToLeft = RightToLeft.No;
            dataGridViewProductApply.RowHeadersWidth = 51;
            dataGridViewProductApply.Size = new Size(516, 134);
            dataGridViewProductApply.TabIndex = 7;
            // 
            // deleteButton
            // 
            deleteButton.AutoSize = true;
            deleteButton.Font = new Font("Times New Roman", 13.8F);
            deleteButton.Location = new Point(51, 346);
            deleteButton.Margin = new Padding(29, 8, 29, 8);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(56, 56);
            deleteButton.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.Controls.Add(acceptButton);
            panel1.Controls.Add(cbProducts);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(516, 64);
            panel1.TabIndex = 6;
            // 
            // acceptButton
            // 
            acceptButton.Location = new Point(303, 0);
            acceptButton.Name = "acceptButton";
            acceptButton.Size = new Size(50, 50);
            acceptButton.TabIndex = 10;
            // 
            // cbProducts
            // 
            cbProducts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbProducts.FormattingEnabled = true;
            cbProducts.Location = new Point(3, 13);
            cbProducts.Name = "cbProducts";
            cbProducts.Size = new Size(278, 31);
            cbProducts.TabIndex = 8;
            cbProducts.TextChanged += comboBox1_TextChanged;
            // 
            // createButton
            // 
            createButton.AutoSize = true;
            createButton.Font = new Font("Times New Roman", 13.8F);
            createButton.Location = new Point(108, 346);
            createButton.Margin = new Padding(29, 8, 29, 8);
            createButton.Name = "createButton";
            createButton.Size = new Size(56, 56);
            createButton.TabIndex = 9;
            // 
            // txtUnitName
            // 
            txtUnitName.BorderStyle = BorderStyle.None;
            txtUnitName.Font = new Font("Times New Roman", 13.8F);
            txtUnitName.Location = new Point(200, 282);
            txtUnitName.Name = "txtUnitName";
            txtUnitName.Size = new Size(226, 27);
            txtUnitName.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.8F);
            label1.Location = new Point(65, 248);
            label1.Name = "label1";
            label1.Size = new Size(96, 26);
            label1.TabIndex = 6;
            label1.Text = "Mã Code";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F);
            label2.Location = new Point(65, 290);
            label2.Name = "label2";
            label2.Size = new Size(100, 26);
            label2.TabIndex = 10;
            label2.Text = "Tên DVT";
            // 
            // txtUnitCode
            // 
            txtUnitCode.BorderStyle = BorderStyle.None;
            txtUnitCode.Font = new Font("Times New Roman", 13.8F);
            txtUnitCode.Location = new Point(199, 239);
            txtUnitCode.Name = "txtUnitCode";
            txtUnitCode.Size = new Size(227, 27);
            txtUnitCode.TabIndex = 5;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(6, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RightToLeft = RightToLeft.No;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(395, 426);
            dataGridView1.TabIndex = 11;
            // 
            // UnitControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "UnitControl";
            Size = new Size(923, 426);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProductApply).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Panel panel1;
        private UCButton.AcceptButton acceptButton;
        private ComboBox cbProducts;
        private DataGridView dataGridViewProductApply;
        private DataGridView dataGridView1;
        private UCButton.DeleteButton deleteButton;
        private UCButton.CreateButton createButton;
        private TextBox txtUnitName;
        private Label label2;
        private TextBox txtUnitCode;
        private Label label1;
        private TextBox txtNote;
    }
}
