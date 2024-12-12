using MWarehouse.Contract.Service.Interface;
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
    public partial class UserRoleControl : UserControl
    {
        private readonly IRoleService roleService;
        public UserRoleControl(IRoleService role)
        {

            InitializeComponent();
            this.roleService = role;
            this.Load += async (s, e) => await Config(s, e);
        }
        private async Task Config(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;
            var screens = await roleService.Roles();
            dataGridView.DataSource = await roleService.GetUsers();
            DataGridViewComboBoxColumn colScreens = new DataGridViewComboBoxColumn();
            colScreens.DataSource = screens;
            colScreens.ValueMember = "MaQuyen";
            colScreens.DisplayMember = "TenQuyen";
            colScreens.HeaderText = "Nhóm người dùng";
            dataGridView.Columns.Add(colScreens);
            // Thêm các cột nút
            DataGridViewButtonColumn addColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Sửa",
                UseColumnTextForButtonValue = false // Không sử dụng văn bản mặc định
            };
            dataGridView.Columns.Add(addColumn);

            DataGridViewButtonColumn removeColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Xóa",
                UseColumnTextForButtonValue = false // Không sử dụng văn bản mặc định
            };
            dataGridView.Columns.Add(removeColumn);

            // Tùy chỉnh giao diện nút
            dataGridView.CellPainting += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
                    (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn))
                {
                    // Hủy vẽ mặc định
                    e.Handled = true;
                    e.PaintBackground(e.CellBounds, true);

                    bool isAddButton = dataGridView.Columns[e.ColumnIndex].Index == 4;

                    using (Brush brush = new SolidBrush(isAddButton ? Color.LightSkyBlue : Color.Red))
                    {
                        e.Graphics.FillRectangle(brush, e.CellBounds);
                    }

                    string buttonText = isAddButton ? "Sửa" : "Xóa";
                    TextRenderer.DrawText(e.Graphics, buttonText, e.CellStyle.Font, e.CellBounds,
                        Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Graphics.DrawRectangle(Pens.Gray, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1);
                }
            };

            dataGridView.CellContentClick += async (s, e) =>
            {
                if (e.RowIndex >= 0 && dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn col)
                {
                    // Lấy giá trị ô đầu tiên trong hàng hiện tại
                    var user = dataGridView.Rows[e.RowIndex].Cells[0].Value?.ToString();

                    // Lấy giá trị từ ComboBox trong ô thứ 2 (cột thứ ba)
                    var comboBoxCell = dataGridView.Rows[e.RowIndex].Cells[3] as DataGridViewComboBoxCell;
                    var role = comboBoxCell?.Value?.ToString();
                    if (string.IsNullOrWhiteSpace(role)){
                        MessageBox.Show("Chọn quyền mới !");

                        return;
                    }

                    if (col.Index == 4)
                    {
                        await roleService.UpdateUserRole(user, role);
                        MessageBox.Show("Cập nhật quyền thánh công");
                    }
                    if (col.Index == 5)
                    {
                        await roleService.DeleteUserRole(user, role);
                        MessageBox.Show("Xóa quyền thánh công");
                    }
                    await Config(s, e);

                }
            };


        }
    }
}
