using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Svg;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using SideBar;

namespace SideBar.Controls
{
    public class NavViewControl : UserControl
    {
        private NavigationItemUserControl navigationItemUserControl1 = new NavigationItemUserControl();
        private RadNavigationView radNavigationView1 = new RadNavigationView();
        public NavViewControl()
        {
            this.radNavigationView1.Dock = DockStyle.Fill;
            this.radNavigationView1.SelectedPageChanged += RadNavigationView1_SelectedPageChanged;
            this.radNavigationView1.ItemExpanded += RadNavigationView1_ItemExpanded;
            this.radNavigationView1.ItemClicked += RadNavigationView1_ItemClicked;
            this.radNavigationView1.ItemCollapsed += RadNavigationView1_ItemCollapsed;
            this.InitalPages();
            this.InitializeIcons();
            this.BindUserControl();
            this.Controls.Add(this.radNavigationView1);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.CenterUserControl();
        }

        /// <summary>
        ///     Khởi tạo các trang
        /// </summary>
        private void InitalPages()
        {
            Dictionary<string, string> navBarItems = new Dictionary<string, string> { { "HomePage", "Tổng quan"}, { "UnitPage", "Đơn vị tính" }, { "ProductPage", "Sản phẩm"}, { "ProductTypePage", "Loại sản phẩm" }, { "SupplierPage", "Nhà cung cấp" }, { "WarehousePage", "Kho" } };
            foreach (var item in navBarItems)
            {
                RadPageViewPage pageView = new RadPageViewPage();
                pageView.Location = new System.Drawing.Point(298, 37);
                pageView.Font = new System.Drawing.Font(pageView.Font, FontStyle.Bold);
                pageView.Name = item.Key;
                pageView.Size = new System.Drawing.Size(407, 528);
                pageView.Text = item.Value;

                radNavigationView1.Pages.Add(pageView);
            }
        }


        private void BindUserControl()
        {
            
            if (this.radNavigationView1.SelectedPage != null)
            {
                this.UpdateViewModelIcon(this.radNavigationView1.SelectedPage);
            }
        }

        /// <summary>
        ///     Căn lể giữa cho trang
        /// </summary>
        private void CenterUserControl()
        {
            if (this.radNavigationView1 == null)
            {
                return;
            }

            Size contentAreaSize = this.radNavigationView1.ViewElement.ContentArea.Size;
            Point location = new Point((contentAreaSize.Width - this.navigationItemUserControl1.Size.Width) / 2,
                                       (contentAreaSize.Height - this.navigationItemUserControl1.Size.Height) / 2);

            location.X = Math.Max(0, location.X);
            location.Y = Math.Max(0, location.Y);

            this.navigationItemUserControl1.Location = location;
        }

        /// <summary>
        ///     Sự kiện thay đổi chọn trang khác
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadNavigationView1_SelectedPageChanged(object sender, EventArgs e)
        {
            if (this.radNavigationView1.SelectedPage == null)
            {
                return;
            }

            this.radNavigationView1.SelectedPage.Controls.Add(this.navigationItemUserControl1);

            this.UpdateViewModelIcon(this.radNavigationView1.SelectedPage);
        }

        private void RadNavigationView1_ItemExpanded(object sender, EventArgs e)
        {
            this.UpdateViewModelIcon(((RadPageViewItem)sender).Page);
        }

        private void RadNavigationView1_ItemCollapsed(object sender, EventArgs e)
        {
            this.UpdateViewModelIcon(((RadPageViewItem)sender).Page);

        }

        private void RadNavigationView1_ItemClicked(object sender, EventArgs e)
        {
            this.UpdateViewModelIcon(((RadPageViewItem)sender).Page);
        }

        /// <summary>
        ///     Sự kiện khi đóng thanh tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadNavigationView1_ExpandCollapse(object sender, EventArgs e)
        {
            this.CenterUserControl();
        }

        /// <summary>
        ///     Khởi tạo page items
        /// </summary>
        private void InitializeIcons()
        {
            var iconsMap = new Dictionary<string, RadSvgImage>();
            string iconsPrefix = @"L:\MWarehouseFormApp\MWarehouseFormApp\SideBar\Controls\Icons\";
            iconsMap["HomePage"] = RadSvgImage.FromFile(iconsPrefix + "home.svg");
            iconsMap["Receipt"] = RadSvgImage.FromFile(iconsPrefix + "receipt.svg");
            iconsMap["SupplierPage"] = RadSvgImage.FromFile(iconsPrefix + "supplier.svg");
            iconsMap["UnitPage"] = RadSvgImage.FromFile(iconsPrefix + "unit.svg");
            iconsMap["ProductPage"] = RadSvgImage.FromFile(iconsPrefix + "box.svg");
            iconsMap["ProductTypePage"] = RadSvgImage.FromFile(iconsPrefix + "productType.svg");
            iconsMap["WarehousePage"] = RadSvgImage.FromFile(iconsPrefix + "warehouse.svg");

            this.AddPageIcons(iconsMap);
        }

        /// <summary>
        ///     Thêm icon cho trang
        /// </summary>
        /// <param name="iconsMap"></param>
        private void AddPageIcons(Dictionary<string, RadSvgImage> iconsMap)
        {
            foreach (RadPageViewPage page in this.radNavigationView1.Pages)
            {
                RadSvgImage svgImage = null;
                if (iconsMap.ContainsKey(page.Name))
                {
                    svgImage = iconsMap[page.Name];
                    svgImage.Size = new Size(16, 16);
                }

                page.Item.SvgImage = svgImage;
            }
        }

        /// <summary>
        ///     Thiết lập Icons
        /// </summary>
        private void SetIcons()
        {
            foreach (RadPageViewPage page in this.radNavigationView1.Pages)
            {
                if (page == this.radNavigationView1.SelectedPage)
                {
                    this.UpdateItemIcon(page);
                }
                this.UpdateViewModelIcon(page);
            }
        }

        /// <summary>
        ///     Cập nhật trạng thái trang đang chọn
        /// </summary>
        /// <param name="page"></param>
        private void UpdateItemIcon(RadPageViewPage page)
        {
            RadSvgImage svgImage = page.Item.SvgImage;
            if (svgImage == null)
            {
                return;
            }

            Color foreColor = page.Item.ForeColor.GetBrightness() > 0.5 ? Color.White : Color.Black;
            this.UpdateSvgColor(svgImage, foreColor);
        }

        private void UpdateSvgColor(RadSvgImage svgImage, Color foreColor)
        {
            SvgPath path = svgImage.Document.Children[0] as SvgPath;
            path.Fill = new SvgColourServer(foreColor);
            svgImage.ClearCache();
        }

        /// <summary>
        ///     Cập nhật lại trạng thái trang được chọn
        /// </summary>
        /// <param name="page"></param>
        private void UpdateViewModelIcon(RadPageViewPage page)
        {
            RadSvgImage svgImage = null;
            if (page.Item.SvgImage != null)
            {
                svgImage = page.Item.SvgImage.Clone() as RadSvgImage;
            }
        }

        private void Item_RadPropertyChanged(object sender, RadPropertyChangedEventArgs e)
        {
            if (e.Property == VisualElement.ForeColorProperty)
            {
                this.UpdateItemIcon(((RadPageViewItem)sender).Page);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // NavViewControl
            // 
            this.Name = "NavViewControl";
            this.Size = new System.Drawing.Size(301, 246);
            this.ResumeLayout(false);

        }
    }
}
