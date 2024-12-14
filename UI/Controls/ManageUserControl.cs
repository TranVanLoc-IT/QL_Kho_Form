using MWarehouse.Contract.Service.Interface;
using MWarehouse.ModelViews.RoleModelView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class ManageUserControl : UserControl
    {
        private readonly IRoleService roleService;
        private List<RoleView> roles;
        public ManageUserControl(IRoleService role)
        {

            InitializeComponent();
            this.roleService = role;
            this.Load += async (s, e) => await Config(s, e);
            this.createButton.button.Click += async (s, e) => await CreateBtnClick(s, e);
            this.updateButton.button.Click += async (s, e) => await UpdateBtnClick(s, e);
            dataGridView.RowHeaderMouseClick += DataGridView_RowHeaderMouseClick;

        }

        private void DataGridView_RowHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            var row = dataGridView.SelectedRows[0];
            tendn.Text = row.Cells[0].Value.ToString();
            email.Text = row.Cells[3].Value == null ? "" : row.Cells[3].Value.ToString();
            ghichu.Text = row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString();
        }

        private async Task CreateBtnClick(object sender, EventArgs e)
        {
            if (!Validate()) return;

            string result = await roleService.CreateNewUser(tendn.Text, email.Text, pass.Text);
            MessageBox.Show(result);
            await RefreshDatagridview(sender, e);

        }

        private bool Validate()
        {
            ErrorProvider err = new ErrorProvider();
            string uname = tendn.Text;
            string mail = email.Text;
            string mk = pass.Text;

            if (string.IsNullOrEmpty(uname))
            {
                err.SetError(tendn, "Nhập tên đăng nhập");
                return false;
            }
            if (!Regex.IsMatch(mail, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                err.SetError(tendn, "Email không hợp lệ");
                return false;
            }

            string pattern = @"^(?=.*\d)(?=.*[!@#$%^&*()_+={}\[\]:;'""\\|,.<>/?-]).+$";

            if (!Regex.IsMatch(mk, pattern))
            {
                err.SetError(this.pass, "Mật khẩu phải chứa ít nhất một chữ số và một ký tự đặc biệt");
                return false;
            }
            return true;
        }
        private async Task UpdateBtnClick(object sender, EventArgs e)
        {
            if (!Validate()) return;

            string result = await roleService.UpdateUser(tendn.Text, email.Text, pass.Text);
            MessageBox.Show(result);
            await RefreshDatagridview(sender, e);
        }

        private async Task Config(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;
            roles = await roleService.Roles();
            dataGridView.DataSource = await roleService.GetUsers();

        }
        private async Task RefreshDatagridview(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;

            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            dataGridView.Refresh();
            await Config(sender, e);
        }
    }
}
