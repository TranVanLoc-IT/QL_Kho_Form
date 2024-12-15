namespace UI.Controls
{
    partial class TheoDoiForm
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
            resetAll = new Button();
            buttonRefresh = new Button();
            dataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // resetAll
            // 
            resetAll.BackColor = SystemColors.ActiveCaption;
            resetAll.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 192);
            resetAll.FlatAppearance.MouseOverBackColor = Color.Teal;
            resetAll.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            resetAll.ForeColor = SystemColors.ButtonFace;
            resetAll.Location = new Point(54, 515);
            resetAll.Margin = new Padding(4);
            resetAll.Name = "resetAll";
            resetAll.Size = new Size(189, 60);
            resetAll.TabIndex = 18;
            resetAll.Text = "Reset Data";
            resetAll.UseVisualStyleBackColor = false;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRefresh.Location = new Point(312, 515);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(119, 60);
            buttonRefresh.TabIndex = 19;
            buttonRefresh.Text = "Làm mới";
            buttonRefresh.UseVisualStyleBackColor = true;
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
            dataGridView.Size = new Size(1162, 490);
            dataGridView.TabIndex = 20;
            // 
            // TheoDoiForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView);
            Controls.Add(buttonRefresh);
            Controls.Add(resetAll);
            Margin = new Padding(4);
            Name = "TheoDoiForm";
            Size = new Size(1162, 594);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button resetAll;
        private Button buttonRefresh;
        private DataGridView dataGridView;
    }
}
