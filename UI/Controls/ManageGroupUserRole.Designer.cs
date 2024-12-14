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
            ghichu = new TextBox();
            tendn = new TextBox();
            dataGridView = new DataGridView();
            deleteButton = new UCButton.DeleteButton();
            createButton = new UCButton.CreateButton();
            manhom = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // ghichu
            // 
            ghichu.Font = new Font("Times New Roman", 13.8F);
            ghichu.Location = new Point(406, 367);
            ghichu.Multiline = true;
            ghichu.Name = "ghichu";
            ghichu.PlaceholderText = "Ghi chú thêm";
            ghichu.Size = new Size(271, 99);
            ghichu.TabIndex = 3;
            // 
            // tendn
            // 
            tendn.Font = new Font("Times New Roman", 13.8F);
            tendn.Location = new Point(56, 432);
            tendn.Margin = new Padding(5, 4, 5, 4);
            tendn.Name = "tendn";
            tendn.PlaceholderText = "Tên nhóm người dùng";
            tendn.Size = new Size(271, 34);
            tendn.TabIndex = 2;
            // 
            // dataGridView
            // 
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BackgroundColor = SystemColors.ActiveCaption;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Top;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Margin = new Padding(5, 4, 5, 4);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(858, 350);
            dataGridView.TabIndex = 14;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(683, 441);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(72, 70);
            deleteButton.TabIndex = 5;
            // 
            // createButton
            // 
            createButton.Location = new Point(683, 367);
            createButton.Name = "createButton";
            createButton.Size = new Size(72, 70);
            createButton.TabIndex = 4;
            // 
            // manhom
            // 
            manhom.Font = new Font("Times New Roman", 13.8F);
            manhom.Location = new Point(56, 367);
            manhom.Margin = new Padding(5, 4, 5, 4);
            manhom.Name = "manhom";
            manhom.PlaceholderText = "Mã nhóm";
            manhom.Size = new Size(271, 34);
            manhom.TabIndex = 1;
            // 
            // ManageGroupUserRole
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(manhom);
            Controls.Add(deleteButton);
            Controls.Add(createButton);
            Controls.Add(ghichu);
            Controls.Add(tendn);
            Controls.Add(dataGridView);
            Name = "ManageGroupUserRole";
            Size = new Size(858, 512);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox ghichu;
        private TextBox tendn;
        private DataGridView dataGridView;
        private UCButton.DeleteButton deleteButton;
        private UCButton.CreateButton createButton;
        private TextBox manhom;
    }
}
