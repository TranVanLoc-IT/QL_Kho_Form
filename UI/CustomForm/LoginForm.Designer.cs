namespace UI.CustomForm
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label3 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            button1 = new Button();
            loginBtn = new Button();
            password = new TextBox();
            label2 = new Label();
            userName = new TextBox();
            label1 = new Label();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.BackColor = Color.Snow;
            label3.FlatStyle = FlatStyle.System;
            label3.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.SteelBlue;
            label3.Location = new Point(456, 61);
            label3.Name = "label3";
            label3.Size = new Size(398, 35);
            label3.TabIndex = 5;
            label3.Text = "PHẦN MỀM QUẢN LÍ KHO";
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(399, 383);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Controls.Add(button1);
            panel2.Controls.Add(loginBtn);
            panel2.Controls.Add(password);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(userName);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(427, 120);
            panel2.Name = "panel2";
            panel2.Size = new Size(459, 242);
            panel2.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(396, 162);
            button1.Name = "button1";
            button1.Size = new Size(8, 8);
            button1.TabIndex = 9;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // loginBtn
            // 
            loginBtn.BackColor = Color.WhiteSmoke;
            loginBtn.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
            loginBtn.FlatAppearance.MouseOverBackColor = Color.SteelBlue;
            loginBtn.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginBtn.ForeColor = Color.LightSkyBlue;
            loginBtn.Location = new Point(177, 142);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(198, 54);
            loginBtn.TabIndex = 8;
            loginBtn.Text = "ĐĂNG NHẬP";
            loginBtn.UseVisualStyleBackColor = false;
            // 
            // password
            // 
            password.Anchor = AnchorStyles.None;
            password.BackColor = Color.WhiteSmoke;
            password.BorderStyle = BorderStyle.FixedSingle;
            password.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            password.Location = new Point(178, 72);
            password.Name = "password";
            password.PasswordChar = '*';
            password.PlaceholderText = "Nhập mật khẩu";
            password.Size = new Size(249, 34);
            password.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.WhiteSmoke;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(2, 38);
            label2.Name = "label2";
            label2.Size = new Size(170, 25);
            label2.TabIndex = 7;
            label2.Text = "Tên người dùng";
            // 
            // userName
            // 
            userName.Anchor = AnchorStyles.None;
            userName.BackColor = Color.WhiteSmoke;
            userName.BorderStyle = BorderStyle.FixedSingle;
            userName.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            userName.Location = new Point(178, 24);
            userName.MaxLength = 30;
            userName.Name = "userName";
            userName.PlaceholderText = "Nhập tên đăng nhập";
            userName.Size = new Size(249, 34);
            userName.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.WhiteSmoke;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(3, 81);
            label1.Name = "label1";
            label1.Size = new Size(111, 25);
            label1.TabIndex = 4;
            label1.Text = "Mật khẩu";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(899, 383);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label3);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            ImeMode = ImeMode.Off;
            KeyPreview = true;
            Name = "LoginForm";
            Text = "Đăng nhập quản lí kho";
            TransparencyKey = Color.Transparent;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Panel panel1;
        private Panel panel2;
        private TextBox password;
        private Label label2;
        private TextBox userName;
        private Label label1;
        private Button button1;
        private Button loginBtn;
    }
}