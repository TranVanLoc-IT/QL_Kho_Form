namespace UI.Controls
{
    partial class ManageGroupUserRole
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            ghichu = new TextBox();
            tendn = new TextBox();
            deleteButton = new UCButton.DeleteButton();
            createButton = new UCButton.CreateButton();
            manhom = new TextBox();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // ghichu
            // 
            ghichu.Font = new Font("Times New Roman", 13.8F);
            ghichu.Location = new Point(508, 459);
            ghichu.Margin = new Padding(4);
            ghichu.Multiline = true;
            ghichu.Name = "ghichu";
            ghichu.PlaceholderText = "Ghi chú thêm";
            ghichu.Size = new Size(338, 123);
            ghichu.TabIndex = 3;
            // 
            // tendn
            // 
            tendn.Font = new Font("Times New Roman", 13.8F);
            tendn.Location = new Point(70, 540);
            tendn.Margin = new Padding(6, 5, 6, 5);
            tendn.Name = "tendn";
            tendn.PlaceholderText = "Tên nhóm người dùng";
            tendn.Size = new Size(338, 39);
            tendn.TabIndex = 2;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(854, 551);
            deleteButton.Margin = new Padding(4);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(90, 88);
            deleteButton.TabIndex = 5;
            // 
            // createButton
            // 
            createButton.Location = new Point(854, 459);
            createButton.Margin = new Padding(5);
            createButton.Name = "createButton";
            createButton.Size = new Size(90, 88);
            createButton.TabIndex = 4;
            // 
            // manhom
            // 
            manhom.Font = new Font("Times New Roman", 13.8F);
            manhom.Location = new Point(70, 459);
            manhom.Margin = new Padding(6, 5, 6, 5);
            manhom.Name = "manhom";
            manhom.PlaceholderText = "Mã nhóm";
            manhom.Size = new Size(338, 39);
            manhom.TabIndex = 1;
            // 
            // dataGridView
            // 
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BackgroundColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 16F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Top;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Margin = new Padding(5, 4, 5, 4);
            dataGridView.Name = "dataGridView";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 16F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.Size = new Size(1072, 434);
            dataGridView.TabIndex = 6;
            // 
            // ManageGroupUserRole
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView);
            Controls.Add(manhom);
            Controls.Add(deleteButton);
            Controls.Add(createButton);
            Controls.Add(ghichu);
            Controls.Add(tendn);
            Margin = new Padding(4);
            Name = "ManageGroupUserRole";
            Size = new Size(1072, 640);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox ghichu;
        private TextBox tendn;
        private UCButton.DeleteButton deleteButton;
        private UCButton.CreateButton createButton;
        private TextBox manhom;
        private DataGridView dataGridView;
    }
}
