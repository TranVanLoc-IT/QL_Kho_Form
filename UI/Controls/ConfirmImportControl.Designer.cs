namespace UI.Controls
{
    partial class ConfirmImportControl
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
            dssp = new FlowLayoutPanel();
            dataGridView = new DataGridView();
            acceptButton = new UCButton.AcceptButton();
            label2 = new Label();
            ngaynhap = new TextBox();
            label3 = new Label();
            ncc = new TextBox();
            kho = new TextBox();
            label1 = new Label();
            comboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dssp
            // 
            dssp.Location = new Point(3, 317);
            dssp.Name = "dssp";
            dssp.Size = new Size(754, 185);
            dssp.TabIndex = 10;
            // 
            // dataGridView
            // 
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BackgroundColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
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
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(754, 317);
            dataGridView.TabIndex = 2;
            // 
            // comboBox
            // 
            comboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new Point(609, 317);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(145, 28);
            comboBox.TabIndex = 3;
            // 
            // ConfirmImportControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(acceptButton);
            Controls.Add(label2);
            Controls.Add(ngaynhap);
            Controls.Add(label3);
            Controls.Add(ncc);
            Controls.Add(kho);
            Controls.Add(label1);
            Controls.Add(comboBox);
            Controls.Add(dataGridView);
            Name = "ConfirmImportControl";
            Size = new Size(754, 406);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel dssp;
        private DataGridView dataGridView;
        private UCButton.AcceptButton acceptButton;
        private Label label2;
        private TextBox ngaynhap;
        private Label label3;
        private TextBox ncc;
        private TextBox kho;
        private Label label1;
        private ComboBox comboBox;
    }
}
