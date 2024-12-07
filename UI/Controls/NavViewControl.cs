using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class NavViewControl : UserControl
    {
        public NavViewControl()
        {
            InitializeComponent();
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMinSize = new Size(0, this.panel1.Height);
            ComboBoxConfig();
            ButtonConfig();
        }

        /// <summary>
        ///     Cấu hình event khi di chuột vào nút
        /// </summary>
        private void ButtonConfig()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button b)
                {
                    c.MouseHover += (sender, e) =>
                    {
                        (sender as Button)!.BackColor = Color.LightBlue;
                    };
                }
            }
        }

        /// <summary>
        ///     Cấu hình combobox button khi thả các thao tác
        /// </summary>
        private void ComboBoxConfig()
        {
            WarehousePage.HeaderPage = new PageViewModel() { PageName = "WarehousePage", PageTitle = "Quản lí kho"};
            SupplierPage.HeaderPage = new PageViewModel() { PageName = "SupplierPage", PageTitle = "Nhà cung cấp" };
            ProductPage.HeaderPage = new PageViewModel() { PageName = "ProductPage", PageTitle = "Quản lí sản phẩm" };

            this.SupplierPage.PageViewList = new PageViewModel[] {new PageViewModel { PageName = "EditSupplierPage", PageTitle = "Thao tác" }
                                                              };


            this.WarehousePage.PageViewList = new PageViewModel[] {
                                                                    new PageViewModel { PageName = "ImportReceiptPage", PageTitle = "Nhập kho" },
                                                                    new PageViewModel { PageName = "ExportReceiptPage", PageTitle = "Xuất kho" }
                                                                };
            this.ProductPage.PageViewList = new PageViewModel[] {
                                                                    new PageViewModel { PageName = "EditProductPage", PageTitle = "Thao tác" }
                                                                };
        }

    }
}
