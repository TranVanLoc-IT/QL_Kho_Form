using MWarehouse.Core.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class DropdownButton : UserControl
    {
        public PageViewModel[] PageViewList { get; set; }

        private Size DropSizeBox { get; set; } = new Size(199, 68);

        public Panel container = new Panel();
        private PageViewModel _headerPage { get; set; }
        private bool _isDroped { get; set; }

        public Button headBtn = new Button();
        public PageViewModel HeaderPage { get => _headerPage;set{
            this._headerPage = value;
            FirstButtonConfig();
            } }


        public DropdownButton()
        {
            this.container.Name = "container";
            this._isDroped = false;
            this.container.Dock = DockStyle.Fill;
            this.Controls.Add(container);
        }

        /// <summary>
        ///     Cấu hình nút tiêu đề đầu tiên
        /// </summary>
        private void FirstButtonConfig()
        {
            if (_headerPage == null) return;
            // quan trọng !, để trước
            InitializeComponent();
            headBtn.Cursor = Cursors.Hand;
            headBtn.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            headBtn.ForeColor = Color.DodgerBlue;
            headBtn.Name = _headerPage.PageName;
            headBtn.Size = DropSizeBox;
            headBtn.Text = _headerPage.PageTitle;
            headBtn.Click += OnClickFirst;
            // trên cùng
            headBtn.Dock = DockStyle.Top;
            headBtn.BackgroundImageLayout = ImageLayout.None;
            headBtn.TextAlign = ContentAlignment.MiddleCenter;
            headBtn.ImageAlign = ContentAlignment.MiddleRight;
            AssignIcon(headBtn, _headerPage.PageName!);
            container.Controls.Clear();
            container.Controls.Add(headBtn);
            // reset sau khi initialize()
            this.Size = DropSizeBox;
        }

        /// <summary>
        ///  Gán icon cho nút tiêu đề
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="pageName"></param>
        private void AssignIcon(Button btn, string pageName)
        {
            btn.Image = Resource.down_arrow;
            switch (pageName)
            {
                case "RolePageForm":
                    btn.BackgroundImage = Resource.role;
                    break;
                case "ConfirmPageForm":
                   btn.BackgroundImage = Resource.cconfirm;
                    break;
                case "ReportPageForm":
                   btn.BackgroundImage = Resource.report;
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        ///     Kéo thả lựa chọn khi click hoặc ẩn đi bằng cách thu lại trạng thái ban đầu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnClickFirst(object sender, EventArgs args)
        {
            if (_isDroped)
            {
                _isDroped = false;
                FirstButtonConfig();
                return;
            }
            for (int count = 1; count <= PageViewList.Length; count++) {
                Button btn = ButtonConfig(PageViewList[count - 1]);
                btn.Size = DropSizeBox;
                btn.TextAlign = ContentAlignment.MiddleRight;
                container.Controls.Add(btn); // phải dc added
                _isDroped = true;
            }
           
            this.Size = new Size(199, DropSizeBox.Height * (PageViewList.Length + 1));
        }

        /// <summary>
        ///     Cấu hình chung cho các nút con
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private Button ButtonConfig(PageViewModel model)
        {
            Button btn = new Button();
            btn.Cursor = Cursors.Hand;
            btn.Dock = DockStyle.Bottom;
            btn.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btn.ForeColor = Color.DodgerBlue;
            btn.Name = model.PageName;
            btn.Size = new Size(199, 90);
            btn.Text = model.PageTitle;
          

            btn.UseVisualStyleBackColor = true;
            return btn;
        }
    }
}
