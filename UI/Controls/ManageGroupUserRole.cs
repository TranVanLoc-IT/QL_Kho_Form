using Microsoft.Office.Interop.Word;
using MWarehouse.Contract.Service.Interface;
using System.Text.RegularExpressions;

namespace UI.Controls
{
    public partial class ManageGroupUserRole : UserControl
    {
        private readonly IRoleService roleService;
        public ManageGroupUserRole(IRoleService role)
        {

            InitializeComponent();
            this.roleService = role;
            this.Load += async (s, e) => await Config(s, e);
            this.createButton.button.Click += async (s, e) => await CreateBtnClick(s, e);
            this.deleteButton.button.Click += async (s, e) => await DeleteBtnClick(s, e);
            dataGridView.RowHeaderMouseClick += DataGridView_RowHeaderMouseClick;
        }

        private void DataGridView_RowHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            var row = dataGridView.SelectedRows[0];
            manhom.Text = row.Cells[0].Value.ToString();
            tendn.Text = row.Cells[1].Value == null ? "" : row.Cells[1].Value.ToString();
            ghichu.Text = row.Cells[2].Value == null ? "" : row.Cells[2].Value.ToString();
        }

        private async System.Threading.Tasks.Task CreateBtnClick(object sender, EventArgs e)
        {
            ErrorProvider err = new ErrorProvider();
            string uname = tendn.Text;
            string manom = manhom.Text;

            if (string.IsNullOrEmpty(uname))
            {
                err.SetError(tendn, "Nhập tên nhóm người dùng");
                return;
            }
            if (string.IsNullOrEmpty(manom))
            {
                err.SetError(manhom, "Nhập mã nhóm người dùng");
                return;
            }

            err.SetError(tendn, null);
            string result = await roleService.CreateNewGroupUser(manom, uname, ghichu.Text);
            MessageBox.Show(result);
            await RefreshDatagridview(sender, e);

        }
        private async System.Threading.Tasks.Task DeleteBtnClick(object sender, EventArgs e)
        {
            ErrorProvider err = new ErrorProvider();
            string uname = tendn.Text;

            if (string.IsNullOrEmpty(uname))
            {
                err.SetError(tendn, "Chọn tên nhóm người dùng");
                return;
            }

            err.SetError(tendn, null);
            string result = await roleService.DeleteGroupUser(uname);
            MessageBox.Show(result);
            await RefreshDatagridview(sender, e);
        }

        private async System.Threading.Tasks.Task Config(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = await roleService.DsRole();

        }
        private async System.Threading.Tasks.Task RefreshDatagridview(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;

            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            dataGridView.Refresh();
            await Config(sender, e);
        }
    }
}
