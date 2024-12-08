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
            Button refreshBtn;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductControl));
            dataGridView = new DataGridView();
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
            refreshBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // refreshBtn
            // 
            refreshBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            refreshBtn.BackgroundImage = (Image)resources.GetObject("refreshBtn.BackgroundImage");
            refreshBtn.BackgroundImageLayout = ImageLayout.Stretch;
            refreshBtn.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            refreshBtn.Location = new Point(425, 225);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(56, 55);
            refreshBtn.TabIndex = 29;
            refreshBtn.UseVisualStyleBackColor = true;
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
            // cbUnit
            // 
            cbUnit.Font = new Font("Times New Roman", 13.8F);
            cbUnit.FormattingEnabled = true;
            cbUnit.Location = new Point(178, 176);
            cbUnit.Name = "cbUnit";
            cbUnit.Size = new Size(184, 34);
            cbUnit.TabIndex = 28;
            // 
            // cbProductType
            // 
            cbProductType.Font = new Font("Times New Roman", 13.8F);
            cbProductType.FormattingEnabled = true;
            cbProductType.Location = new Point(178, 127);
            cbProductType.Name = "cbProductType";
            cbProductType.Size = new Size(184, 34);
            cbProductType.TabIndex = 27;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(244, 222);
            updateButton.Margin = new Padding(5, 4, 5, 4);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(60, 63);
            updateButton.TabIndex = 26;
            // 
            // comboBoxFilter
            // 
            comboBoxFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxFilter.BackColor = SystemColors.InactiveCaption;
            comboBoxFilter.Font = new Font("Times New Roman", 13.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            comboBoxFilter.ForeColor = SystemColors.MenuHighlight;
            comboBoxFilter.FormattingEnabled = true;
            comboBoxFilter.Location = new Point(496, 246);
            comboBoxFilter.Name = "comboBoxFilter";
            comboBoxFilter.Size = new Size(238, 34);
            comboBoxFilter.TabIndex = 25;
            // 
            // txtProductNote
            // 
            txtProductNote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtProductNote.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProductNote.Location = new Point(496, 37);
            txtProductNote.Multiline = true;
            txtProductNote.Name = "txtProductNote";
            txtProductNote.Size = new Size(233, 173);
            txtProductNote.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label5.Location = new Point(390, 37);
            label5.Name = "label5";
            label5.Size = new Size(91, 25);
            label5.TabIndex = 23;
            label5.Text = "Ghi chú";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label4.Location = new Point(26, 188);
            label4.Name = "label4";
            label4.Size = new Size(123, 25);
            label4.TabIndex = 22;
            label4.Text = "Đơn vị tính";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label3.Location = new Point(26, 140);
            label3.Name = "label3";
            label3.Size = new Size(56, 25);
            label3.TabIndex = 21;
            label3.Text = "Loại";
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(159, 222);
            deleteButton.Margin = new Padding(7, 4, 7, 4);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(60, 63);
            deleteButton.TabIndex = 18;
            // 
            // createButton
            // 
            createButton.Location = new Point(76, 222);
            createButton.Margin = new Padding(7, 4, 7, 4);
            createButton.Name = "createButton";
            createButton.Size = new Size(60, 63);
            createButton.TabIndex = 19;
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Times New Roman", 13.8F);
            txtProductName.Location = new Point(178, 74);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(206, 34);
            txtProductName.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label2.Location = new Point(26, 86);
            label2.Name = "label2";
            label2.Size = new Size(153, 25);
            label2.TabIndex = 20;
            label2.Text = "Tên sản phẩm";
            // 
            // txtProductCode
            // 
            txtProductCode.BorderStyle = BorderStyle.None;
            txtProductCode.Enabled = false;
            txtProductCode.Font = new Font("Times New Roman", 13.8F);
            txtProductCode.Location = new Point(178, 30);
            txtProductCode.Name = "txtProductCode";
            txtProductCode.Size = new Size(206, 27);
            txtProductCode.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label1.Location = new Point(26, 37);
            label1.Name = "label1";
            label1.Size = new Size(106, 25);
            label1.TabIndex = 16;
            label1.Text = "Mã Code";
            // 
            // ProductControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(refreshBtn);
            Controls.Add(cbUnit);
            Controls.Add(cbProductType);
            Controls.Add(updateButton);
            Controls.Add(comboBoxFilter);
            Controls.Add(txtProductNote);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(deleteButton);
            Controls.Add(createButton);
            Controls.Add(txtProductName);
            Controls.Add(label2);
            Controls.Add(txtProductCode);
            Controls.Add(label1);
            Controls.Add(dataGridView);
            Name = "ProductControl";
            Size = new Size(742, 426);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView;
        private Button refreshBtn;
        private ComboBox cbUnit;
        private ComboBox cbProductType;
        private UCButton.UpdateButton updateButton;
        private ComboBox comboBoxFilter;
        private TextBox txtProductNote;
        private Label label5;
        private Label label4;
        private Label label3;
        private UCButton.DeleteButton deleteButton;
        private UCButton.CreateButton createButton;
        private TextBox txtProductName;
        private Label label2;
        private TextBox txtProductCode;
        private Label label1;
    }
}
