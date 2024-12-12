namespace UI.Controls
{
    partial class NavViewControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavViewControl));
            panel1 = new Panel();
            ReportPage = new DropdownButton();
            ConfirmPage = new DropdownButton();
            RolePage = new DropdownButton();
            ChatBot = new Button();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonFace;
            panel1.Controls.Add(ReportPage);
            panel1.Controls.Add(ConfirmPage);
            panel1.Controls.Add(RolePage);
            panel1.Controls.Add(ChatBot);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(183, 551);
            panel1.TabIndex = 0;
            // 
            // ReportPage
            // 
            ReportPage.BackColor = SystemColors.ButtonFace;
            ReportPage.Dock = DockStyle.Top;
            ReportPage.HeaderPage = null;
            ReportPage.Location = new Point(0, 276);
            ReportPage.Name = "ReportPage";
            ReportPage.PageViewList = null;
            ReportPage.Size = new Size(183, 90);
            ReportPage.TabIndex = 14;
            ReportPage.Visible = false;
            // 
            // ConfirmPage
            // 
            ConfirmPage.BackColor = SystemColors.ButtonFace;
            ConfirmPage.Dock = DockStyle.Top;
            ConfirmPage.HeaderPage = null;
            ConfirmPage.Location = new Point(0, 186);
            ConfirmPage.Name = "ConfirmPage";
            ConfirmPage.PageViewList = null;
            ConfirmPage.Size = new Size(183, 90);
            ConfirmPage.TabIndex = 13;
            ConfirmPage.Visible = false;
            // 
            // RolePage
            // 
            RolePage.BackColor = SystemColors.ButtonFace;
            RolePage.BackgroundImage = (Image)resources.GetObject("RolePage.BackgroundImage");
            RolePage.Dock = DockStyle.Top;
            RolePage.HeaderPage = null;
            RolePage.Location = new Point(0, 96);
            RolePage.Name = "RolePage";
            RolePage.PageViewList = null;
            RolePage.Size = new Size(183, 90);
            RolePage.TabIndex = 11;
            RolePage.Visible = false;
            // 
            // ChatBot
            // 
            ChatBot.Cursor = Cursors.Hand;
            ChatBot.Dock = DockStyle.Bottom;
            ChatBot.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            ChatBot.ForeColor = Color.DodgerBlue;
            ChatBot.Image = (Image)resources.GetObject("ChatBot.Image");
            ChatBot.ImageAlign = ContentAlignment.MiddleLeft;
            ChatBot.Location = new Point(0, 461);
            ChatBot.Name = "ChatBot";
            ChatBot.Size = new Size(183, 90);
            ChatBot.TabIndex = 8;
            ChatBot.Text = "AI";
            ChatBot.TextAlign = ContentAlignment.MiddleRight;
            ChatBot.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Resource.warehouse;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(183, 96);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // NavViewControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "NavViewControl";
            Size = new Size(183, 551);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        public Panel panel1;
        public Button ChatBot;
        public DropdownButton RolePage;
        public DropdownButton ReportPage;
        public DropdownButton ConfirmPage;
    }
}
