﻿namespace UI.Controls
{
    partial class ManageUserControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridView = new DataGridView();
            tendn = new TextBox();
            createButton = new UCButton.CreateButton();
            label1 = new Label();
            email = new TextBox();
            pass = new TextBox();
            label2 = new Label();
            updateButton = new UCButton.UpdateButton();
            label3 = new Label();
            status = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.BackgroundColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 16F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Top;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Margin = new Padding(5, 4, 5, 4);
            dataGridView.Name = "dataGridView";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Times New Roman", 16F, FontStyle.Regular, GraphicsUnit.Point, 163);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(1341, 350);
            dataGridView.TabIndex = 4;
            // 
            // tendn
            // 
            tendn.Location = new Point(67, 379);
            tendn.Margin = new Padding(5, 4, 5, 4);
            tendn.Name = "tendn";
            tendn.PlaceholderText = "Tên đăng nhập";
            tendn.Size = new Size(271, 39);
            tendn.TabIndex = 1;
            // 
            // createButton
            // 
            createButton.Location = new Point(783, 447);
            createButton.Margin = new Padding(4, 4, 4, 4);
            createButton.Name = "createButton";
            createButton.Size = new Size(72, 70);
            createButton.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(378, 389);
            label1.Name = "label1";
            label1.Size = new Size(80, 33);
            label1.TabIndex = 10;
            label1.Text = "Email";
            // 
            // email
            // 
            email.Location = new Point(485, 379);
            email.Margin = new Padding(5, 4, 5, 4);
            email.Name = "email";
            email.PlaceholderText = "Nhập email";
            email.Size = new Size(271, 39);
            email.TabIndex = 11;
            // 
            // pass
            // 
            pass.Location = new Point(485, 481);
            pass.Margin = new Padding(5, 4, 5, 4);
            pass.Name = "pass";
            pass.Size = new Size(271, 39);
            pass.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(378, 493);
            label2.Name = "label2";
            label2.Size = new Size(121, 33);
            label2.TabIndex = 12;
            label2.Text = "Mật khẩu";
            // 
            // updateButton
            // 
            updateButton.Location = new Point(906, 447);
            updateButton.Margin = new Padding(4, 4, 4, 4);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(72, 70);
            updateButton.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(786, 389);
            label3.Name = "label3";
            label3.Size = new Size(127, 33);
            label3.TabIndex = 15;
            label3.Text = "Trạng thái";
            // 
            // status
            // 
            status.FormattingEnabled = true;
            status.Location = new Point(916, 377);
            status.Name = "status";
            status.Size = new Size(226, 41);
            status.TabIndex = 16;
            // 
            // ManageUserControl
            // 
            AutoScaleDimensions = new SizeF(15F, 33F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(status);
            Controls.Add(label3);
            Controls.Add(updateButton);
            Controls.Add(pass);
            Controls.Add(label2);
            Controls.Add(email);
            Controls.Add(label1);
            Controls.Add(createButton);
            Controls.Add(tendn);
            Controls.Add(dataGridView);
            Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(5, 4, 5, 4);
            Name = "ManageUserControl";
            Size = new Size(1341, 556);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView;
        private TextBox tendn;
        private UCButton.CreateButton createButton;
        private Label label1;
        private TextBox email;
        private TextBox pass;
        private Label label2;
        private UCButton.UpdateButton updateButton;
        private Label label3;
        private ComboBox status;
    }
}
