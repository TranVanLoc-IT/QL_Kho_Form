namespace UI.Controls.MiniControl
{
    partial class ScreenCard
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
            hinhAnh = new PictureBox();
            TenMH = new TextBox();
            ((System.ComponentModel.ISupportInitialize)hinhAnh).BeginInit();
            SuspendLayout();
            // 
            // hinhAnh
            // 
            hinhAnh.BackgroundImageLayout = ImageLayout.Stretch;
            hinhAnh.Dock = DockStyle.Top;
            hinhAnh.Location = new Point(0, 0);
            hinhAnh.Name = "hinhAnh";
            hinhAnh.Size = new Size(171, 133);
            hinhAnh.TabIndex = 0;
            hinhAnh.TabStop = false;
            // 
            // TenMH
            // 
            TenMH.Dock = DockStyle.Bottom;
            TenMH.Font = new Font("Times New Roman", 10.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            TenMH.Location = new Point(0, 139);
            TenMH.Multiline = true;
            TenMH.Name = "TenMH";
            TenMH.Size = new Size(171, 42);
            TenMH.TabIndex = 1;
            // 
            // ScreenCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TenMH);
            Controls.Add(hinhAnh);
            Name = "ScreenCard";
            Size = new Size(171, 181);
            ((System.ComponentModel.ISupportInitialize)hinhAnh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public PictureBox hinhAnh;
        public TextBox TenMH;
    }
}
