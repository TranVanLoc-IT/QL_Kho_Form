using Microsoft.VisualBasic.Logging;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core.Utils;
using System.Windows.Forms;
using UI.Controls;
using UI.CustomForm;

namespace UI.Layouts
{
    public partial class LayoutForm : Form
    {
        private readonly UnitControl _unitControl;
        private readonly ManageRoleControl _homeControl;
        private readonly ProductControl _productControl;
        private readonly SupplierControl _supplierControl;
        private readonly AIControl _warehouseControl;
        private readonly ExportViewControl _exportViewControl;
        private readonly ProductTypeControl _productTypeControl;
        private readonly GoodsReceiptControl _goodsReceiptControl;

        private readonly ILoginService _loginService;

        private string userName;

        public string user
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    userName = value;
                    this.label1.Text = "Xin chào " + value; // Cập nhật label
                }
            }
            get
            {
                return userName;
            }
        }


        public LayoutForm(UnitControl unitControl, ManageRoleControl homeControl, ProductControl productControl,
                       SupplierControl supplierControl, AIControl warehouseControl,
                       ExportViewControl exportViewControl, ProductTypeControl productTypeControl,
                       GoodsReceiptControl goodsReceiptControl, ILoginService loginService)
        {
            // Initialize controls with DI
            _unitControl = unitControl;
            _homeControl = homeControl;
            _productControl = productControl;
            _supplierControl = supplierControl;
            _warehouseControl = warehouseControl;
            _exportViewControl = exportViewControl;
            _productTypeControl = productTypeControl;
            _goodsReceiptControl = goodsReceiptControl;
            this._loginService = loginService;
            InitializeComponent();
            Login();
            this.WindowState = FormWindowState.Maximized;
            this.ResizeEnd += LayoutForm_Resize;
            this.MinimumSizeChanged += LayoutForm_Resize;
            this.navViewControl1.RolePage.Click += HomePage_Click;
            this.navViewControl1.UnitPage.Click += UnitPage_Click;
            this.navViewControl1.ProductTypePage.Click += ProductTypePage_Click;
            this.navViewControl1.ChatBot.Click += PrintPage_Click;
            header.Resize += Header_Resize;
            timer1.Tick += timer1_Tick;
            SetClickDropdown();
            timer1.Start();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timeWork.Text = TimeHelper.ConvertToUtcPlus7(DateTime.Now).ToString();
        }
        private void Header_Resize(object? sender, EventArgs e)
        {
            this.Page.Location = new Point((this.header.Width / 2) - this.Page.Width, this.Page.Height);
        }

        private void PrintPage_Click(object? sender, EventArgs e)
        {
            _exportViewControl.Dock = DockStyle.Fill;
            this.main.Controls.Add(_exportViewControl);
        }

        private void Login()
        {
            LoginForm login = new LoginForm(_loginService);
            login.FormClosed += Login_FormClosed;
            login.ShowDialog();
        }

        private void Login_FormClosed(object? sender, FormClosedEventArgs e)
        {
            LoginForm login = (sender as LoginForm);
            DisplayFormOnRole(login.forms);
            this.user = login.user;
            label1.Text = "Đang hoạt động: " + this.user;
        }

        private void SetClickDropdown()
        {
            foreach (Control c in navViewControl1.panel1.Controls)
            {
                if (c is DropdownButton b)
                {
                    foreach (Button p in b.Controls.Find("container", false).First().Controls)
                    {
                        p.Click += btn_Click;
                    }
                }
            }
        }
        private void btn_Click(object? sender, EventArgs e)
        {
            foreach (Control c in navViewControl1.panel1.Controls)
            {
                if (c is DropdownButton b)
                {
                    foreach (Button p in b.Controls.Find("container", false).First().Controls)
                    {
                        p.Click += subBtn_click;
                    }
                }
            }
        }
        private void subBtn_click(object? sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "EditSupplierPage":
                    this.main.Controls.Clear();
                    _supplierControl.Dock = DockStyle.Fill;
                    this.main.Controls.Add(_supplierControl);
                    break;
                case "ImportReceiptPage":
                    this.main.Controls.Clear();
                    _goodsReceiptControl.Dock = DockStyle.Fill;
                    this.main.Controls.Add(_goodsReceiptControl);
                    break;
                case "ExportReceiptPage":
                    this.main.Controls.Clear();
                    _exportViewControl.Dock = DockStyle.Fill;
                    this.main.Controls.Add(_exportViewControl);
                    break;
                case "EditProductPage":
                    this.main.Controls.Clear();
                    _productControl.Dock = DockStyle.Fill;
                    this.main.Controls.Add(_productControl);
                    break;

            }
        }
        private void ProductTypePage_Click(object? sender, EventArgs e)
        {
            _productTypeControl.Dock = DockStyle.Fill;
            this.main.Controls.Clear();
            this.main.Controls.Add(_productTypeControl);
        }

        private void WarehousePage_Click(object? sender, EventArgs e)
        {
            this.main.Controls.Clear();
            _warehouseControl.Dock = DockStyle.Fill;
            this.main.Controls.Add(_warehouseControl);
        }
        private void UnitPage_Click(object? sender, EventArgs e)
        {
            this.main.Controls.Clear();
            _unitControl.Dock = DockStyle.Fill;
            this.main.Controls.Add(_unitControl);
        }

        private void HomePage_Click(object? sender, EventArgs e)
        {
            this.main.Controls.Clear();
            _homeControl.Dock = DockStyle.Fill;
            this.main.Controls.Add(_homeControl);
        }

        /// <summary>
        ///     Handle khi resize form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LayoutForm_Resize(object? sender, EventArgs e)
        {
            Rectangle screen = Screen.PrimaryScreen.Bounds;

            this.Width = screen.Width / 2 + 200;
            this.Height = screen.Height / 2 + 200;

            this.StartPosition = FormStartPosition.CenterScreen;

        }

        /// <summary>
        ///     Mở các form có quyền truy cập
        /// </summary>
        /// <param name="forms"></param>
        private void DisplayFormOnRole(string[] forms)
        {
            foreach (string form in forms)
            {

                foreach (Control control in this.navViewControl1.panel1.Controls)
                {

                    if (control is Button b)
                    {
                        if (b.Name.Equals(form.Trim()))
                        {
                            b.Visible = true;
                            break;
                        }
                    }
                    if (form.Equals("WarehousePage"))
                    {
                        this.navViewControl1.WarehousePage.Visible = true;
                        break;
                    }
                    else if (form.Equals("SupplierPage"))
                    {
                        this.navViewControl1.SupplierPage.Visible = true;
                        break;
                    }
                    else if (form.Equals("ProductPage"))
                    {
                        this.navViewControl1.ProductPage.Visible = true;
                        break;
                    }


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.navViewControl1.panel1.Controls)
            {

                if (control is Button b)
                {
                    b.Visible = false;
                }
            }
            this.navViewControl1.WarehousePage.Visible = false;
            this.navViewControl1.SupplierPage.Visible = false;
            this.navViewControl1.ProductTypePage.Visible = false;

            Login();
        }
    }
}
