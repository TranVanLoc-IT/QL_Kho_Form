namespace UI.Layouts
{
    partial class LayoutForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            navViewControl1 = new Controls.NavViewControl();
            header = new Panel();
            timeWork = new Label();
            button1 = new Button();
            label1 = new Label();
            Page = new Label();
            main = new Panel();
            button2 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            header.SuspendLayout();
            main.SuspendLayout();
            SuspendLayout();
            // 
            // navViewControl1
            // 
            navViewControl1.AutoScroll = true;
            navViewControl1.AutoScrollMinSize = new Size(0, 538);
            navViewControl1.Dock = DockStyle.Left;
            navViewControl1.Location = new Point(0, 0);
            navViewControl1.Margin = new Padding(3, 2, 3, 2);
            navViewControl1.Name = "navViewControl1";
            navViewControl1.Size = new Size(205, 474);
            navViewControl1.TabIndex = 0;
            // 
            // header
            // 
            header.BorderStyle = BorderStyle.FixedSingle;
            header.Controls.Add(timeWork);
            header.Controls.Add(button1);
            header.Controls.Add(label1);
            header.Controls.Add(Page);
            header.Dock = DockStyle.Top;
            header.Location = new Point(205, 0);
            header.Margin = new Padding(3, 2, 3, 2);
            header.Name = "header";
            header.Size = new Size(677, 58);
            header.TabIndex = 1;
            // 
            // timeWork
            // 
            timeWork.AutoSize = true;
            timeWork.Dock = DockStyle.Right;
            timeWork.Font = new Font("Times New Roman", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            timeWork.Location = new Point(510, 0);
            timeWork.Name = "timeWork";
            timeWork.Size = new Size(48, 19);
            timeWork.TabIndex = 4;
            timeWork.Text = "label2";
            // 
            // button1
            // 
            button1.BackColor = Color.Orange;
            button1.Dock = DockStyle.Right;
            button1.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 0);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 128);
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 192, 128);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(558, 0);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(117, 56);
            button1.TabIndex = 1;
            button1.Text = "Đăng xuất";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Left;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(164, 21);
            label1.TabIndex = 2;
            label1.Text = "Nhân viên - Chức vụ";
            // 
            // Page
            // 
            Page.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Page.AutoSize = true;
            Page.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Page.ForeColor = SystemColors.MenuHighlight;
            Page.Location = new Point(163, 14);
            Page.Name = "Page";
            Page.Size = new Size(231, 25);
            Page.TabIndex = 0;
            Page.Text = "Phần mềm quản lí Kho";
            // 
            // main
            // 
            main.Controls.Add(button2);
            main.Dock = DockStyle.Fill;
            main.Location = new Point(205, 58);
            main.Margin = new Padding(3, 2, 3, 2);
            main.Name = "main";
            main.Size = new Size(677, 416);
            main.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(436, 46);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(7, 6);
            button2.TabIndex = 0;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // LayoutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 474);
            Controls.Add(main);
            Controls.Add(header);
            Controls.Add(navViewControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LayoutForm";
            Text = "Phần mềm quản lí kho";
            header.ResumeLayout(false);
            header.PerformLayout();
            main.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Controls.NavViewControl navViewControl1;
        private Panel header;
        private Label Page;
        private Panel main;
        private Label label1;
        private Button button2;
        private System.Windows.Forms.Timer timer1;
        private Button button1;
        private Label timeWork;
    }
}