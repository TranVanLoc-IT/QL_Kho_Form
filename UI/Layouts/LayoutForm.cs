﻿using Microsoft.VisualBasic.Logging;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core.Utils;
using System.Windows.Forms;
using UI.Controls;
using UI.CustomForm;

namespace UI.Layouts
{
    public partial class LayoutForm : Form
    {
        private readonly UserRoleControl _userRoleControl;
        private readonly GroupRoleControl _groupRoleControl;
        private readonly ConfirmImportControl _confirmImportControl;
        private readonly ConfirmExportControl _confirmExportControl;
        private readonly ReportExportControl _reportExportControl;
        private readonly ReportImportControl _reportImportControl;
        private readonly ManageUserControl _muser;
        private readonly ManageGroupUserRole _guser;
        private readonly Baocaotonkho bc;
        private readonly ViewReportControl _viewReportControl;

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


        public LayoutForm(ManageGroupUserRole guser, ManageUserControl muser,
                       UserRoleControl _userRoleControl,
                        ViewReportControl viewReport,
                        GroupRoleControl _groupRoleControl,
                        ConfirmImportControl _confirmImportControl,
                        ConfirmExportControl _confirmExportControl,
                        ReportExportControl _reportExportControl,
                       ReportImportControl _reportImportControl, Baocaotonkho bc, ILoginService loginService)
        {
            // Initialize controls with DI

            this._loginService = loginService;
            this._muser = muser;
            this.bc = bc;
            this._guser = guser;
            this._reportExportControl = _reportExportControl;
            this._reportImportControl = _reportImportControl;
            this._confirmExportControl = _confirmExportControl;
            this._confirmImportControl = _confirmImportControl;
            this._groupRoleControl = _groupRoleControl;
            this._userRoleControl = _userRoleControl;
            this._viewReportControl = viewReport;
            InitializeComponent();
            Login();
            this.WindowState = FormWindowState.Maximized;
            this.ResizeEnd += LayoutForm_Resize;
            this.MinimumSizeChanged += LayoutForm_Resize;
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


        private void Login()
        {
            LoginForm login = new LoginForm(_loginService);
            login.FormClosed += Login_FormClosed;
            login.ShowDialog();
        }

        private void Login_FormClosed(object? sender, FormClosedEventArgs e)
        {
            LoginForm login = (sender as LoginForm);
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
                case "UserRolePage":
                    this.main.Controls.Clear();
                    _userRoleControl.Dock = DockStyle.Fill;
                    this.main.Controls.Add(_userRoleControl);
                    break;
                case "GroupRolePage":
                    this.main.Controls.Clear();
                    _groupRoleControl.Dock = DockStyle.Fill;
                    this.main.Controls.Add(_groupRoleControl);
                    break;
                case "ReportExport":
                    this.main.Controls.Clear();
                    _reportExportControl.Dock = DockStyle.Fill;
                    this.main.Controls.Add(_reportExportControl);
                    break;
                case "ReportImport":
                    this.main.Controls.Clear();
                    _reportImportControl.Dock = DockStyle.Fill;
                    this.main.Controls.Add(_reportImportControl);
                    break;
                case "ConfirmExportPage":
                    this.main.Controls.Clear();
                    _confirmExportControl.Dock = DockStyle.Fill;
                    this.main.Controls.Add(_confirmExportControl);
                    break;
                case "ConfirmImportPage":
                    this.main.Controls.Clear();
                    _confirmImportControl.Dock = DockStyle.Fill;
                    this.main.Controls.Add(_confirmImportControl);
                    break;
                case "ViewReportPage":
                    this.main.Controls.Clear();
                    _viewReportControl.Dock = DockStyle.Fill;
                    this.main.Controls.Add(_viewReportControl);
                    break;
                case "ManageGroupRole":
                    this.main.Controls.Clear();
                    _guser.Dock = DockStyle.Fill;
                    this.main.Controls.Add(_guser);
                    break;
                    break;
                case "ManageUserRole":
                    this.main.Controls.Clear();
                    _muser.Dock = DockStyle.Fill;
                    this.main.Controls.Add(_muser);
                    break;

            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }


    }
}
