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
            WarehousePage = new DropdownButton();
            SupplierPage = new DropdownButton();
            ProductTypePage = new Button();
            ProductPage = new DropdownButton();
            ChatBot = new Button();
            UnitPage = new Button();
            RolePage = new Button();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonFace;
            panel1.Controls.Add(WarehousePage);
            panel1.Controls.Add(SupplierPage);
            panel1.Controls.Add(ProductTypePage);
            panel1.Controls.Add(ProductPage);
            panel1.Controls.Add(ChatBot);
            panel1.Controls.Add(UnitPage);
            panel1.Controls.Add(RolePage);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(183, 551);
            panel1.TabIndex = 0;
            // 
            // WarehousePage
            // 
            WarehousePage.BackColor = SystemColors.ButtonFace;
            WarehousePage.Dock = DockStyle.Top;
            WarehousePage.HeaderPage = null;
            WarehousePage.Location = new Point(0, 546);
            WarehousePage.Name = "WarehousePage";
            WarehousePage.PageViewList = null;
            WarehousePage.Size = new Size(183, 90);
            WarehousePage.TabIndex = 14;
            // 
            // SupplierPage
            // 
            SupplierPage.BackColor = SystemColors.ButtonFace;
            SupplierPage.Dock = DockStyle.Top;
            SupplierPage.HeaderPage = null;
            SupplierPage.Location = new Point(0, 456);
            SupplierPage.Name = "SupplierPage";
            SupplierPage.PageViewList = null;
            SupplierPage.Size = new Size(183, 90);
            SupplierPage.TabIndex = 13;
            // 
            // ProductTypePage
            // 
            ProductTypePage.BackgroundImageLayout = ImageLayout.Stretch;
            ProductTypePage.Cursor = Cursors.Hand;
            ProductTypePage.Dock = DockStyle.Top;
            ProductTypePage.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            ProductTypePage.ForeColor = Color.DodgerBlue;
            ProductTypePage.Image = Resource.colors1;
            ProductTypePage.ImageAlign = ContentAlignment.MiddleLeft;
            ProductTypePage.Location = new Point(0, 366);
            ProductTypePage.Name = "ProductTypePage";
            ProductTypePage.Size = new Size(183, 90);
            ProductTypePage.TabIndex = 12;
            ProductTypePage.Text = "Loại sản phẩm";
            ProductTypePage.TextAlign = ContentAlignment.MiddleRight;
            ProductTypePage.UseVisualStyleBackColor = true;
            // 
            // ProductPage
            // 
            ProductPage.BackColor = SystemColors.ButtonFace;
            ProductPage.Dock = DockStyle.Top;
            ProductPage.HeaderPage = null;
            ProductPage.Location = new Point(0, 276);
            ProductPage.Name = "ProductPage";
            ProductPage.PageViewList = null;
            ProductPage.Size = new Size(183, 90);
            ProductPage.TabIndex = 11;
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
            // UnitPage
            // 
            UnitPage.BackgroundImageLayout = ImageLayout.Stretch;
            UnitPage.Cursor = Cursors.Hand;
            UnitPage.Dock = DockStyle.Top;
            UnitPage.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            UnitPage.ForeColor = Color.DodgerBlue;
            UnitPage.Image = Resource.calculator;
            UnitPage.ImageAlign = ContentAlignment.MiddleLeft;
            UnitPage.Location = new Point(0, 186);
            UnitPage.Name = "UnitPage";
            UnitPage.Size = new Size(183, 90);
            UnitPage.TabIndex = 2;
            UnitPage.Text = "Đơn vị tính";
            UnitPage.TextAlign = ContentAlignment.MiddleRight;
            UnitPage.UseVisualStyleBackColor = true;
            // 
            // RolePage
            // 
            RolePage.BackgroundImage = Resource.dashboard;
            RolePage.BackgroundImageLayout = ImageLayout.None;
            RolePage.Cursor = Cursors.Hand;
            RolePage.Dock = DockStyle.Top;
            RolePage.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            RolePage.ForeColor = Color.DodgerBlue;
            RolePage.ImageAlign = ContentAlignment.MiddleLeft;
            RolePage.Location = new Point(0, 96);
            RolePage.Name = "RolePage";
            RolePage.Size = new Size(183, 90);
            RolePage.TabIndex = 1;
            RolePage.Text = "Phân quyền";
            RolePage.TextAlign = ContentAlignment.MiddleRight;
            RolePage.UseVisualStyleBackColor = true;
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
        public Button RolePage;
        public Button UnitPage;
        public Button ChatBot;
        public Button ProductTypePage;
        public DropdownButton ProductPage;
        public DropdownButton WarehousePage;
        public DropdownButton SupplierPage;
    }
}
