namespace UI.Controls
{
    partial class ViewReportControl
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
            button1 = new Button();
            pictureBox1 = new PictureBox();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dateTimePickerKetthuc = new DateTimePicker();
            dateTimePickerBatdau = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button1.Location = new Point(122, 387);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(119, 55);
            button1.TabIndex = 16;
            button1.Text = "Truy Xuất";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resource.report;
            pictureBox1.Location = new Point(78, 387);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 55);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(67, 452);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1093, 347);
            dataGridView1.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.IndianRed;
            label3.Location = new Point(67, 297);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(166, 25);
            label3.TabIndex = 13;
            label3.Text = "Chọn ngày kết thúc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.IndianRed;
            label2.Location = new Point(67, 204);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(164, 25);
            label2.TabIndex = 12;
            label2.Text = "Chọn ngày bắt đầu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.OliveDrab;
            label1.Font = new Font("Sitka Subheading", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(235, 22);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(681, 104);
            label1.TabIndex = 11;
            label1.Text = "BÁO CÁO TỒN KHO";
            // 
            // dateTimePickerKetthuc
            // 
            dateTimePickerKetthuc.Format = DateTimePickerFormat.Short;
            dateTimePickerKetthuc.Location = new Point(67, 327);
            dateTimePickerKetthuc.Margin = new Padding(4, 5, 4, 5);
            dateTimePickerKetthuc.Name = "dateTimePickerKetthuc";
            dateTimePickerKetthuc.Size = new Size(333, 31);
            dateTimePickerKetthuc.TabIndex = 10;
            // 
            // dateTimePickerBatdau
            // 
            dateTimePickerBatdau.Format = DateTimePickerFormat.Short;
            dateTimePickerBatdau.Location = new Point(67, 234);
            dateTimePickerBatdau.Margin = new Padding(4, 5, 4, 5);
            dateTimePickerBatdau.Name = "dateTimePickerBatdau";
            dateTimePickerBatdau.Size = new Size(333, 31);
            dateTimePickerBatdau.TabIndex = 9;
            // 
            // ViewReportControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePickerKetthuc);
            Controls.Add(dateTimePickerBatdau);
            Margin = new Padding(4);
            Name = "ViewReportControl";
            Size = new Size(1312, 816);
            Load += ViewReportControl_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private DataGridView dataGridView1;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePickerKetthuc;
        private DateTimePicker dateTimePickerBatdau;
    }
}
