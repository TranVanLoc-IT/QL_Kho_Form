namespace UI.Controls
{
    partial class ReportImportControl
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
            dateTimePickerBatdau = new DateTimePicker();
            dateTimePickerKetthuc = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dateTimePickerBatdau
            // 
            dateTimePickerBatdau.Format = DateTimePickerFormat.Short;
            dateTimePickerBatdau.Location = new Point(29, 240);
            dateTimePickerBatdau.Margin = new Padding(4, 5, 4, 5);
            dateTimePickerBatdau.Name = "dateTimePickerBatdau";
            dateTimePickerBatdau.Size = new Size(333, 31);
            dateTimePickerBatdau.TabIndex = 1;

            // 
            // dateTimePickerKetthuc
            // 
            dateTimePickerKetthuc.Format = DateTimePickerFormat.Short;
            dateTimePickerKetthuc.Location = new Point(29, 333);
            dateTimePickerKetthuc.Margin = new Padding(4, 5, 4, 5);
            dateTimePickerKetthuc.Name = "dateTimePickerKetthuc";
            dateTimePickerKetthuc.Size = new Size(333, 31);
            dateTimePickerKetthuc.TabIndex = 2;
          
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.OliveDrab;
            label1.Font = new Font("Sitka Subheading", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(147, 23);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(897, 104);
            label1.TabIndex = 3;
            label1.Text = "THÔNG TIN PHIÊU NHẬP";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.IndianRed;
            label2.Location = new Point(29, 210);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(164, 25);
            label2.TabIndex = 4;
            label2.Text = "Chọn ngày bắt đầu";
           
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.IndianRed;
            label3.Location = new Point(29, 303);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(166, 25);
            label3.TabIndex = 5;
            label3.Text = "Chọn ngày kết thúc";
         
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(29, 458);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1093, 347);
            dataGridView1.TabIndex = 6;
         
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resource.report;
            pictureBox1.Location = new Point(40, 393);
            pictureBox1.Margin = new Padding(4, 5, 4, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(49, 55);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
         
            // 
            // button1
            // 
            button1.BackColor = Color.Lime;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            button1.Location = new Point(84, 393);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(119, 55);
            button1.TabIndex = 8;
            button1.Text = "Truy Xuất";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // ReportImportControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePickerKetthuc);
            Controls.Add(dateTimePickerBatdau);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ReportImportControl";
            Size = new Size(1146, 810);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dateTimePickerBatdau;
        private DateTimePicker dateTimePickerKetthuc;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView1;
        private PictureBox pictureBox1;
        private Button button1;
    }
}
