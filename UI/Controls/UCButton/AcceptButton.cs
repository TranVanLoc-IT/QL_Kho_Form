using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Controls.UCButton
{
    public partial class AcceptButton : UserControl
    {
        public Button button = new Button();
        public AcceptButton()
        {
            InitializeComponent();
            Config();
            this.Controls.Add(button);
        }
        private void Config()
        {
            this.button.BackColor = System.Drawing.Color.DarkGreen;
            this.button.BackgroundImage = Resource.accept;
            this.button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button.Dock = DockStyle.Fill;
            this.button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button.Size = new System.Drawing.Size(125, 54);
            this.Size = new System.Drawing.Size(125, 54);
            this.button.TabIndex = 0;
            this.button.FlatStyle = FlatStyle.Flat;
            this.button.TextAlign = ContentAlignment.MiddleRight;
            this.button.ImageAlign = ContentAlignment.MiddleLeft;
        }

    }
}
