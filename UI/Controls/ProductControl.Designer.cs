namespace UI.Controls
{
    partial class ProductControl
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
            groupBox1 = new GroupBox();
            refreshBtn = new Button();
            cbUnit = new ComboBox();
            cbProductType = new ComboBox();
            updateButton = new UCButton.UpdateButton();
            comboBoxFilter = new ComboBox();
            txtProductNote = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            deleteButton = new UCButton.DeleteButton();
            createButton = new UCButton.CreateButton();
            txtProductName = new TextBox();
            label2 = new Label();
            txtProductCode = new TextBox();
            label1 = new Label();
            dataGridView = new DataGridView();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(refreshBtn);
            groupBox1.Controls.Add(cbUnit);
            groupBox1.Controls.Add(cbProductType);
            groupBox1.Controls.Add(updateButton);
            groupBox1.Controls.Add(comboBoxFilter);
            groupBox1.Controls.Add(txtProductNote);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(deleteButton);
            groupBox1.Controls.Add(createButton);
            groupBox1.Controls.Add(txtProductName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtProductCode);
            groupBox1.Controls.Add(label1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(742, 293);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin sản phẩm";
            // 
            // refreshBtn
            // 
            refreshBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refreshBtn.Location = new Point(431, 250);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(110, 31);
            refreshBtn.TabIndex = 14;
            refreshBtn.Text = "Làm mới";
            refreshBtn.UseVisualStyleBackColor = true;
            // 
            // cbUnit
            // 
            cbUnit.Font = new Font("Times New Roman", 13.8F);
            cbUnit.FormattingEnabled = true;
            cbUnit.Location = new Point(186, 180);
            cbUnit.Name = "cbUnit";
            cbUnit.Size = new Size(184, 34);
            cbUnit.TabIndex = 12;
            // 
            // cbProductType
            // 
            cbProductType.Font = new Font("Times New Roman", 13.8F);
            cbProductType.FormattingEnabled = true;
            cbProductType.Location = new Point(186, 131);
            cbProductType.Name = "cbProductType";
            cbProductType.Size = new Size(184, 34);
            cbProductType.TabIndex = 11;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(252, 226);
            updateButton.Margin = new Padding(5, 4, 5, 4);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(56, 55);
            updateButton.TabIndex = 10;
            // 
            // comboBoxFilter
            // 
            comboBoxFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxFilter.BackColor = SystemColors.InactiveCaption;
            comboBoxFilter.ForeColor = SystemColors.MenuHighlight;
            comboBoxFilter.FormattingEnabled = true;
            comboBoxFilter.Location = new Point(547, 250);
            comboBoxFilter.Name = "comboBoxFilter";
            comboBoxFilter.Size = new Size(195, 33);
            comboBoxFilter.TabIndex = 9;
            // 
            // txtProductNote
            // 
            txtProductNote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtProductNote.Font = new Font("Times New Roman", 12F);
            txtProductNote.Location = new Point(504, 41);
            txtProductNote.Multiline = true;
            txtProductNote.Name = "txtProductNote";
            txtProductNote.Size = new Size(233, 160);
            txtProductNote.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(398, 41);
            label5.Name = "label5";
            label5.Size = new Size(91, 25);
            label5.TabIndex = 7;
            label5.Text = "Ghi chú";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 192);
            label4.Name = "label4";
            label4.Size = new Size(123, 25);
            label4.TabIndex = 4;
            label4.Text = "Đơn vị tính";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 144);
            label3.Name = "label3";
            label3.Size = new Size(56, 25);
            label3.TabIndex = 3;
            label3.Text = "Loại";
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(167, 226);
            deleteButton.Margin = new Padding(7, 4, 7, 4);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(56, 55);
            deleteButton.TabIndex = 2;
            // 
            // createButton
            // 
            createButton.Location = new Point(84, 226);
            createButton.Margin = new Padding(7, 4, 7, 4);
            createButton.Name = "createButton";
            createButton.Size = new Size(56, 55);
            createButton.TabIndex = 2;
            // 
            // txtProductName
            // 
            txtProductName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtProductName.Font = new Font("Times New Roman", 13.8F);
            txtProductName.Location = new Point(186, 78);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(206, 34);
            txtProductName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 90);
            label2.Name = "label2";
            label2.Size = new Size(153, 25);
            label2.TabIndex = 2;
            label2.Text = "Tên sản phẩm";
            // 
            // txtProductCode
            // 
            txtProductCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtProductCode.BorderStyle = BorderStyle.None;
            txtProductCode.Enabled = false;
            txtProductCode.Font = new Font("Times New Roman", 13.8F);
            txtProductCode.Location = new Point(186, 34);
            txtProductCode.Name = "txtProductCode";
            txtProductCode.Size = new Size(206, 27);
            txtProductCode.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 41);
            label1.Name = "label1";
            label1.Size = new Size(106, 25);
            label1.TabIndex = 0;
            label1.Text = "Mã Code";
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = SystemColors.GradientActiveCaption;
            dataGridView.BorderStyle = BorderStyle.Fixed3D;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.Location = new Point(0, 293);
            dataGridView.Name = "dataGridView";
            dataGridView.RightToLeft = RightToLeft.Yes;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(742, 133);
            dataGridView.TabIndex = 4;
            // 
            // ProductControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Controls.Add(dataGridView);
            Name = "ProductControl";
            Size = new Size(742, 426);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private UCButton.DeleteButton deleteButton;
        private UCButton.CreateButton createButton;
        private TextBox txtProductName;
        private Label label2;
        private TextBox txtProductCode;
        private Label label1;
        private DataGridView dataGridView;
        private Label label4;
        private ComboBox comboBoxFilter;
        private TextBox txtProductNote;
        private Label label5;
        private UCButton.UpdateButton updateButton;
        private ComboBox cbUnit;
        private ComboBox cbProductType;
        private Button refreshBtn;
    }
}
