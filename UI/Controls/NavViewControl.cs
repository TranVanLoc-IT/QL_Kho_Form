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
            ConfirmPage.HeaderPage = new PageViewModel() { PageName = "ConfirmPageForm", PageTitle = "Duyệt phiếu"};
            RolePage.HeaderPage = new PageViewModel() { PageName = "RolePageForm", PageTitle = "Phân quyền" };
            ReportPage.HeaderPage = new PageViewModel() { PageName = "ReportPageForm", PageTitle = "Báo cáo phiếu" };

            this.RolePage.PageViewList = new PageViewModel[] {new PageViewModel { PageName = "UserRolePage", PageTitle = "Phân quyền người dùng" },
                new PageViewModel { PageName = "GroupRolePage", PageTitle = "Phân quyền nhóm" },
                new PageViewModel { PageName = "ManageGroupRole", PageTitle = "Quản lí nhóm người dùng" },
                new PageViewModel { PageName = "ManageUserRole", PageTitle = "Quản lí người dùng" }
                                                              };


            this.ReportPage.PageViewList = new PageViewModel[] {
                                                                    new PageViewModel { PageName = "ReportExport", PageTitle = "Phiếu xuất" },
                                                                    new PageViewModel { PageName = "ReportImport", PageTitle = "Phiếu nhập" },
                                                                    new PageViewModel { PageName = "ViewReportPage", PageTitle = "Xem báo cáo" }

                                                                };
            this.ConfirmPage.PageViewList = new PageViewModel[] {
                                                                    new PageViewModel { PageName = "ConfirmExportPage", PageTitle = "Duyệt phiếu xuất" },
                                                                    new PageViewModel { PageName = "ConfirmImportPage", PageTitle = "Duyệt phiếu nhập" },
                                                                    new PageViewModel { PageName = "TheoDoi", PageTitle = "Theo dõi phiếu" },
                                                                };
        }

    }
}
