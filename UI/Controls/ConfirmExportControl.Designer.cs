namespace UI.Controls
{
    partial class ConfirmExportControl
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
            acceptButton = new UCButton.AcceptButton();
            ngayxuat = new TextBox();
            label3 = new Label();
            kho = new TextBox();
            label1 = new Label();
            comboBox = new ComboBox();
            dataGridView = new DataGridView();
            dssp = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // acceptButton
            // 
            acceptButton.Enabled = false;
            acceptButton.Location = new Point(368, 535);
            acceptButton.Name = "acceptButton";
            acceptButton.Size = new Size(67, 62);
            acceptButton.TabIndex = 33;
            // 
            // ngayxuat
            // 
            ngayxuat.Enabled = false;
            ngayxuat.Font = new Font("Times New Roman", 13.8F);
            ngayxuat.Location = new Point(53, 567);
            ngayxuat.Name = "ngayxuat";
            ngayxuat.Size = new Size(269, 34);
            ngayxuat.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label3.Location = new Point(53, 535);
            label3.Name = "label3";
            label3.Size = new Size(114, 25);
            label3.TabIndex = 30;
            label3.Text = "Ngày xuất";
            // 
            // kho
            // 
            kho.Enabled = false;
            kho.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            kho.ForeColor = Color.Red;
            kho.Location = new Point(125, 476);
            kho.Name = "kho";
            kho.Size = new Size(197, 34);
            kho.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label1.Location = new Point(53, 485);
            label1.Name = "label1";
            label1.Size = new Size(55, 25);
            label1.TabIndex = 27;
            label1.Text = "Kho";
            // 
            // comboBox
            // 
            comboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox.FormattingEnabled = true;
            comboBox.Location = new Point(682, 458);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(145, 34);
            comboBox.TabIndex = 26;
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
            dataGridViewCellStyle3.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.Size = new Size(830, 260);
            dataGridView.TabIndex = 25;
            // 
            // dssp
            // 
            dssp.Location = new Point(3, 267);
            dssp.Name = "dssp";
            dssp.Size = new Size(824, 185);
            dssp.TabIndex = 24;
            // 
            // ConfirmExportControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(acceptButton);
            Controls.Add(ngayxuat);
            Controls.Add(label3);
            Controls.Add(kho);
            Controls.Add(label1);
            Controls.Add(comboBox);
            Controls.Add(dataGridView);
            Controls.Add(dssp);
            Name = "ConfirmExportControl";
            Size = new Size(830, 612);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private UCButton.AcceptButton acceptButton;
        private TextBox ngayxuat;
        private Label label3;
        private TextBox kho;
        private Label label1;
        private ComboBox comboBox;
        private DataGridView dataGridView;
        private FlowLayoutPanel dssp;
    }
}
