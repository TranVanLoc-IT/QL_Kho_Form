namespace Forms.Layouts
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
            this.navViewControl1 = new SideBar.Controls.NavViewControl();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // navViewControl1
            // 
            this.navViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navViewControl1.Location = new System.Drawing.Point(0, 0);
            this.navViewControl1.Name = "navViewControl1";
            this.navViewControl1.Size = new System.Drawing.Size(576, 373);
            this.navViewControl1.TabIndex = 0;
            // 
            // LayoutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 373);
            this.Controls.Add(this.navViewControl1);
            this.Name = "LayoutForm";
            this.Text = "LayoutForm";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SideBar.Controls.NavViewControl navViewControl1;
    }
}
