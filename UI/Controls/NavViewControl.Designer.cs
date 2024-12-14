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
        public DropdownButton RolePage;
        public DropdownButton ReportPage;
        public DropdownButton ConfirmPage;
    }
}
