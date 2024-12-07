namespace UI.Controls
{
    partial class ExportViewControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportViewControl));
            flowLayoutPanelProduct = new FlowLayoutPanel();
            label4 = new Label();
            dataGridView = new DataGridView();
            btnPrint = new Button();
            txtNote = new TextBox();
            updateButton = new UCButton.UpdateButton();
            cbWarehouse = new ComboBox();
            importDate = new DateTimePicker();
            cbProducts = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            cbSuppliers = new ComboBox();
            deleteButton = new UCButton.DeleteButton();
            cbFilter = new ComboBox();
            label7 = new Label();
            quantitySupply = new NumericUpDown();
            createButton = new UCButton.CreateButton();
            addProduct = new UCButton.CreateButton();
            label2 = new Label();
            label1 = new Label();
            removeProduct = new UCButton.DeleteButton();
            txtReceiptCode = new TextBox();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)quantitySupply).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanelProduct
            // 
            flowLayoutPanelProduct.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelProduct.AutoScroll = true;
            flowLayoutPanelProduct.AutoSize = true;
            flowLayoutPanelProduct.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelProduct.Location = new Point(13, 201);
            flowLayoutPanelProduct.Name = "flowLayoutPanelProduct";
            flowLayoutPanelProduct.Size = new Size(342, 357);
            flowLayoutPanelProduct.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 34);
            label4.Name = "label4";
            label4.Size = new Size(169, 23);
            label4.TabIndex = 11;
            label4.Text = "Sản phẩm cung cấp";
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = SystemColors.GradientActiveCaption;
            dataGridView.BorderStyle = BorderStyle.Fixed3D;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.Location = new Point(0, 373);
            dataGridView.Name = "dataGridView";
            dataGridView.RightToLeft = RightToLeft.Yes;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(827, 82);
            dataGridView.TabIndex = 15;
            // 
            // btnPrint
            // 
            btnPrint.BackgroundImage = (Image)resources.GetObject("btnPrint.BackgroundImage");
            btnPrint.Location = new Point(453, 271);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(56, 55);
            btnPrint.TabIndex = 16;
            btnPrint.UseVisualStyleBackColor = true;
            // 
            // txtNote
            // 
            txtNote.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtNote.BorderStyle = BorderStyle.None;
            txtNote.Font = new Font("Times New Roman", 13.8F);
            txtNote.Location = new Point(873, 238);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.PlaceholderText = "Nhập ghi chú nếu có";
            txtNote.Size = new Size(312, 72);
            txtNote.TabIndex = 15;
            // 
            // updateButton
            // 
            updateButton.Location = new Point(38, 276);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(56, 55);
            updateButton.TabIndex = 14;
            // 
            // cbWarehouse
            // 
            cbWarehouse.Font = new Font("Times New Roman", 13.8F);
            cbWarehouse.FormattingEnabled = true;
            cbWarehouse.Location = new Point(197, 180);
            cbWarehouse.Name = "cbWarehouse";
            cbWarehouse.Size = new Size(219, 34);
            cbWarehouse.TabIndex = 12;
            // 
            // importDate
            // 
            importDate.Font = new Font("Times New Roman", 13.8F);
            importDate.Location = new Point(197, 128);
            importDate.Name = "importDate";
            importDate.Size = new Size(312, 34);
            importDate.TabIndex = 5;
            // 
            // cbProducts
            // 
            cbProducts.FormattingEnabled = true;
            cbProducts.Location = new Point(13, 67);
            cbProducts.Name = "cbProducts";
            cbProducts.Size = new Size(234, 31);
            cbProducts.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label6.Location = new Point(34, 186);
            label6.Name = "label6";
            label6.Size = new Size(110, 25);
            label6.TabIndex = 11;
            label6.Text = "Chọn kho";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label5.Location = new Point(32, 238);
            label5.Name = "label5";
            label5.Size = new Size(91, 25);
            label5.TabIndex = 9;
            label5.Text = "Ghi chú";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label3.Location = new Point(34, 134);
            label3.Name = "label3";
            label3.Size = new Size(161, 25);
            label3.TabIndex = 4;
            label3.Text = "Ngày cung cấp";
            // 
            // cbSuppliers
            // 
            cbSuppliers.Font = new Font("Times New Roman", 13.8F);
            cbSuppliers.FormattingEnabled = true;
            cbSuppliers.Location = new Point(197, 84);
            cbSuppliers.Name = "cbSuppliers";
            cbSuppliers.Size = new Size(219, 34);
            cbSuppliers.TabIndex = 3;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(101, 276);
            deleteButton.Margin = new Padding(4, 3, 4, 3);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(56, 55);
            deleteButton.TabIndex = 2;
            // 
            // cbFilter
            // 
            cbFilter.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbFilter.FormattingEnabled = true;
            cbFilter.Items.AddRange(new object[] { "Tất cả" });
            cbFilter.Location = new Point(663, 338);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(151, 33);
            cbFilter.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 111);
            label7.Name = "label7";
            label7.Size = new Size(84, 23);
            label7.TabIndex = 15;
            label7.Text = "Số lượng";
            // 
            // quantitySupply
            // 
            quantitySupply.Location = new Point(104, 104);
            quantitySupply.Name = "quantitySupply";
            quantitySupply.Size = new Size(143, 30);
            quantitySupply.TabIndex = 13;
            // 
            // createButton
            // 
            createButton.Location = new Point(165, 276);
            createButton.Margin = new Padding(4, 3, 4, 3);
            createButton.Name = "createButton";
            createButton.Size = new Size(56, 55);
            createButton.TabIndex = 2;
            // 
            // addProduct
            // 
            addProduct.Location = new Point(13, 137);
            addProduct.Margin = new Padding(6, 3, 6, 3);
            addProduct.Name = "addProduct";
            addProduct.Size = new Size(56, 55);
            addProduct.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label2.Location = new Point(34, 90);
            label2.Name = "label2";
            label2.Size = new Size(151, 25);
            label2.TabIndex = 2;
            label2.Text = "Nhà cung cấp";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label1.Location = new Point(34, 41);
            label1.Name = "label1";
            label1.Size = new Size(106, 25);
            label1.TabIndex = 0;
            label1.Text = "Mã Code";
            // 
            // removeProduct
            // 
            removeProduct.Location = new Point(81, 137);
            removeProduct.Margin = new Padding(6, 3, 6, 3);
            removeProduct.Name = "removeProduct";
            removeProduct.Size = new Size(56, 55);
            removeProduct.TabIndex = 14;
            // 
            // txtReceiptCode
            // 
            txtReceiptCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtReceiptCode.BorderStyle = BorderStyle.None;
            txtReceiptCode.Font = new Font("Times New Roman", 13.8F);
            txtReceiptCode.Location = new Point(873, 34);
            txtReceiptCode.Name = "txtReceiptCode";
            txtReceiptCode.Size = new Size(172, 27);
            txtReceiptCode.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanelProduct);
            panel1.Controls.Add(removeProduct);
            panel1.Controls.Add(addProduct);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(quantitySupply);
            panel1.Controls.Add(cbProducts);
            panel1.Controls.Add(label4);
            panel1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            panel1.Location = new Point(543, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(284, 332);
            panel1.TabIndex = 16;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnPrint);
            groupBox1.Controls.Add(txtNote);
            groupBox1.Controls.Add(updateButton);
            groupBox1.Controls.Add(cbWarehouse);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(importDate);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cbSuppliers);
            groupBox1.Controls.Add(deleteButton);
            groupBox1.Controls.Add(createButton);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtReceiptCode);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(-1, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(538, 332);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin phiếu nhập";
            // 
            // ExportViewControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView);
            Controls.Add(cbFilter);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Name = "ExportViewControl";
            Size = new Size(827, 455);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)quantitySupply).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelProduct;
        private Label label4;
        private DataGridView dataGridView;
        private Button btnPrint;
        private TextBox txtNote;
        private UCButton.UpdateButton updateButton;
        private ComboBox cbWarehouse;
        private DateTimePicker importDate;
        private ComboBox cbProducts;
        private Label label6;
        private Label label5;
        private Label label3;
        private ComboBox cbSuppliers;
        private UCButton.DeleteButton deleteButton;
        private ComboBox cbFilter;
        private Label label7;
        private NumericUpDown quantitySupply;
        private UCButton.CreateButton createButton;
        private UCButton.CreateButton addProduct;
        private Label label2;
        private Label label1;
        private UCButton.DeleteButton removeProduct;
        private TextBox txtReceiptCode;
        private Panel panel1;
        private GroupBox groupBox1;
    }
}
