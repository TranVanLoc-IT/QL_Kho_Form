using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Controls.UCButton
{
    public partial class UpdateButton : UserControl
    {
        public Button button = new Button();
        public UpdateButton()
        {
            InitializeComponent();
            Config();
            this.Controls.Add(button);
        }
        private void Config()
        {
            this.button.BackColor = System.Drawing.Color.SteelBlue;
            this.button.BackgroundImage = Resource.update;
            this.button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button.Dock = DockStyle.Fill;
            this.button.Location = new System.Drawing.Point(1, 1);
            this.button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button.Size = new System.Drawing.Size(125, 54);
            this.Size = new System.Drawing.Size(125, 54);
            this.button.TabIndex = 0;
            this.button.Text = "";
            this.button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // events
            this.button.MouseHover += Button_MouseHover;
        }

        private void Button_MouseHover(object sender, EventArgs e)
        {
            this.button.BackColor = System.Drawing.Color.Blue;
        }
    }
}
