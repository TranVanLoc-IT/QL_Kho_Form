namespace UI.Controls
{
    partial class ProductResultLine
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
            prName = new TextBox();
            quantity = new TextBox();
            deleteButton1 = new UCButton.DeleteButton();
            SuspendLayout();
            // 
            // prName
            // 
            prName.BorderStyle = BorderStyle.None;
            prName.Dock = DockStyle.Left;
            prName.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            prName.Location = new Point(0, 0);
            prName.Multiline = true;
            prName.Name = "prName";
            prName.Size = new Size(198, 67);
            prName.TabIndex = 0;
            // 
            // quantity
            // 
            quantity.BorderStyle = BorderStyle.None;
            quantity.Dock = DockStyle.Left;
            quantity.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            quantity.Location = new Point(198, 0);
            quantity.Multiline = true;
            quantity.Name = "quantity";
            quantity.Size = new Size(88, 67);
            quantity.TabIndex = 1;
            // 
            // deleteButton1
            // 
            deleteButton1.Location = new Point(336, 11);
            deleteButton1.Name = "deleteButton1";
            deleteButton1.Size = new Size(57, 53);
            deleteButton1.TabIndex = 2;
            // 
            // ProductResultLine
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(deleteButton1);
            Controls.Add(quantity);
            Controls.Add(prName);
            Name = "ProductResultLine";
            Size = new Size(418, 67);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox prName;
        public TextBox quantity;
        public UCButton.DeleteButton deleteButton1;
    }
}
