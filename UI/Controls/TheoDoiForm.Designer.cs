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
            dataGridView = new DataGridView();
            resetAll = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
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
            dataGridView.Size = new Size(930, 394);
            dataGridView.TabIndex = 17;
            // 
            // resetAll
            // 
            resetAll.BackColor = SystemColors.ActiveCaption;
            resetAll.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 192);
            resetAll.FlatAppearance.MouseOverBackColor = Color.Teal;
            resetAll.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            resetAll.ForeColor = SystemColors.ButtonFace;
            resetAll.Location = new Point(43, 412);
            resetAll.Name = "resetAll";
            resetAll.Size = new Size(151, 48);
            resetAll.TabIndex = 18;
            resetAll.Text = "Reset Data";
            resetAll.UseVisualStyleBackColor = false;
            // 
            // TheoDoiForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(resetAll);
            Controls.Add(dataGridView);
            Name = "TheoDoiForm";
            Size = new Size(930, 475);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private Button resetAll;
    }
}
