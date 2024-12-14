using MWarehouse.Contract.Service.Interface;
using MWarehouse.ModelViews.RoleModelView;
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
    public partial class ManageUserControl : UserControl
    {
        private readonly IRoleService roleService;
        private List<RoleView> roles;
        public ManageUserControl(IRoleService role)
        {

            InitializeComponent();
            this.roleService = role;
            this.Load += async (s, e) => await Config(s, e);
            dataGridView.CellContentClick += async (s, e) => await cellContentClick(s, e);

        }

        private async Task cellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn col)
            {
                var user = dataGridView.Rows[e.RowIndex].Cells[0].Value?.ToString();
                var oldRole = dataGridView.Rows[e.RowIndex].Cells[1].Value?.ToString();
                // lay ma cua role
                oldRole = roles.Where(r => r.TenQuyen.Equals(oldRole)).Select(r => r.MaQuyen).First();
                var comboBoxCell = dataGridView.Rows[e.RowIndex].Cells[3] as DataGridViewComboBoxCell;
                var role = comboBoxCell?.Value?.ToString();

                if (col.Index == 4)
                {
                    if (string.IsNullOrWhiteSpace(role))
                    {
                        MessageBox.Show("Chọn quyền mới !");
                        return;
                    }
                    await roleService.UpdateUserRole(user, oldRole, role);
                    MessageBox.Show("Cập nhật quyền thành công");
                }
                if (col.Index == 5)
                {
                    await roleService.DeleteUserRole(user, oldRole);
                    MessageBox.Show("Xóa quyền thành công");
                }
                await RefreshDatagridview(sender, e);

            }
        }
        private async Task Config(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;
            roles = await roleService.Roles();
            dataGridView.DataSource = await roleService.GetUsers();
            DataGridViewComboBoxColumn colScreens = new DataGridViewComboBoxColumn();
            colScreens.DataSource = roles;
            colScreens.ValueMember = "MaQuyen";
            colScreens.DisplayMember = "TenQuyen";
            colScreens.HeaderText = "Nhóm người dùng";
            dataGridView.Columns.Add(colScreens);

            ButtonGridConfig();

        }

        private void ButtonGridConfig()
        {
            // Thêm các biến lưu trạng thái hover/click
            int hoveredColumnIndex = -1;
            int hoveredRowIndex = -1;
            int clickedColumnIndex = -1;
            int clickedRowIndex = -1;

            // Thêm các cột nút
            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Sửa",
                UseColumnTextForButtonValue = true // Hiển thị văn bản trên nút
            };
            dataGridView.Columns.Add(editColumn);

            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Xóa",
                UseColumnTextForButtonValue = true // Hiển thị văn bản trên nút
            };
            dataGridView.Columns.Add(deleteColumn);

            // Tùy chỉnh giao diện nút
            dataGridView.CellPainting += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
                    dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    // Hủy vẽ mặc định
                    e.Handled = true;

                    // Xác định trạng thái hover/click
                    bool isHovered = e.ColumnIndex == hoveredColumnIndex && e.RowIndex == hoveredRowIndex;
                    bool isClicked = e.ColumnIndex == clickedColumnIndex && e.RowIndex == clickedRowIndex;

                    // Xác định màu sắc và văn bản nút
                    Brush brush;
                    string buttonText;

                    if (dataGridView.Columns[e.ColumnIndex] == editColumn)
                    {
                        brush = new SolidBrush(isClicked ? Color.SteelBlue : isHovered ? Color.LightSkyBlue : Color.SkyBlue);
                        buttonText = "Sửa";
                    }
                    else if (dataGridView.Columns[e.ColumnIndex] == deleteColumn)
                    {
                        brush = new SolidBrush(isClicked ? Color.DarkRed : isHovered ? Color.LightCoral : Color.Red);
                        buttonText = "Xóa";
                    }
                    else
                    {
                        return;
                    }

                    // Vẽ nền nút
                    e.Graphics.FillRectangle(brush, e.CellBounds);

                    // Vẽ văn bản
                    TextRenderer.DrawText(e.Graphics, buttonText, e.CellStyle.Font, e.CellBounds,
                        Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    // Vẽ viền
                    e.Graphics.DrawRectangle(Pens.Gray, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1);

                    // Giải phóng brush
                    brush.Dispose();
                }
            };

            // Thêm sự kiện hover
            dataGridView.CellMouseEnter += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
                    dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    hoveredColumnIndex = e.ColumnIndex;
                    hoveredRowIndex = e.RowIndex;
                    dataGridView.InvalidateCell(e.ColumnIndex, e.RowIndex); // Vẽ lại ô
                }
            };

            dataGridView.CellMouseLeave += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
                    dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    hoveredColumnIndex = -1;
                    hoveredRowIndex = -1;
                    dataGridView.InvalidateCell(e.ColumnIndex, e.RowIndex); // Vẽ lại ô
                }
            };

            // Thêm sự kiện click
            dataGridView.CellClick += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
                    dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    clickedColumnIndex = e.ColumnIndex;
                    clickedRowIndex = e.RowIndex;
                    dataGridView.InvalidateCell(e.ColumnIndex, e.RowIndex); // Vẽ lại ô

                    // Đặt trạng thái clicked về mặc định sau một thời gian ngắn (hiệu ứng click)
                    Task.Delay(200).ContinueWith(_ =>
                    {
                        clickedColumnIndex = -1;
                        clickedRowIndex = -1;
                        dataGridView.Invoke(new Action(() =>
                        {
                            dataGridView.InvalidateCell(e.ColumnIndex, e.RowIndex); // Vẽ lại ô
                        }));
                    });
                }
            };

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
