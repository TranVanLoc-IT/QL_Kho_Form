using Microsoft.Office.Interop.Excel;
using MWarehouse.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Controls.MiniControl
{
    public partial class ScreenListLine : UserControl
    {
        public List<DmManHinh> mhs { get; set; }
        public ScreenListLine(List<DmManHinh> mhs)
        {
            InitializeComponent();
            this.mhs = mhs;
            LoadLine();
        }
        private void LoadLine()
        {
            foreach(DmManHinh mh in mhs)
            {
                ScreenCard card = new ScreenCard();
                card.hinhAnh.Image = Image.FromFile($"../../../Images/manhinh/{mh.MaManHinh}.jpg");
                card.TenMH.Text = mh.TenManHinh;
                flowLayoutPanel1.Controls.Add(card);
            }
        }
    }
}
