using MWarehouse.Contract.Service.Interface;
using MWarehouse.ModelViews.RoleModelView;
using MWarehouse.Repository.Models;
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
    public partial class GroupRoleControl : UserControl
    {
        private readonly IRoleService roleService;
        public GroupRoleControl(IRoleService role)
        {
            
            InitializeComponent();
            this.roleService = role;
            // Sự kiện này sẽ gọi lại dữ liệu cho các cột ComboBox khi DataGridView được load.
            dataGridView.ColumnAdded += async (s, e) =>
            {
                if (dataGridView.ColumnCount <= 3) return;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    var gr = row.Cells[0].Value?.ToString();

                    // Cập nhật cột ComboBox có index = 2
                    if (dataGridView.Columns[2] is DataGridViewComboBoxColumn com2)
                    {
                        com2.DataSource = await roleService.GetMhActivating(gr);
                    }

                    // Cập nhật cột ComboBox có index = 3
                    if (dataGridView.Columns[3] is DataGridViewComboBoxColumn com3)
                    {
                        var act = await roleService.GetMhActivating(gr);
                        var availableData = (await roleService.DsManHinh())
                            .Except(act)
                            .ToList();
                        com3.DataSource = availableData;
                    }
                }
            };
            this.Load += async (s, e) => await Config(s, e);
        }
        private async Task Config(object sender, EventArgs e)
        {
            var screens = await roleService.DsManHinh();

            var listRoles = await roleService.DsRole();
            dataGridView.DataSource = listRoles;

            DataGridViewComboBoxColumn actScreens = new DataGridViewComboBoxColumn();
            actScreens.DataSource = screens;
            actScreens.ValueMember = "MaMH";
            actScreens.DisplayMember = "TenMH";
            actScreens.HeaderText = "Được truy cập";
            actScreens.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            dataGridView.Columns.Add(actScreens);

            DataGridViewComboBoxColumn colScreens = new DataGridViewComboBoxColumn();
            colScreens.DataSource = screens;
            colScreens.ValueMember = "MaMH";
            colScreens.DisplayMember = "TenMH";
            colScreens.HeaderText = "Màn hình";
            colScreens.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            dataGridView.Columns.Add(colScreens);
            // Thêm các cột nút
            DataGridViewButtonColumn addColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Thêm",
                Text = "Thêm",
                UseColumnTextForButtonValue = false // Không sử dụng văn bản mặc định
            };
            dataGridView.Columns.Add(addColumn);

            DataGridViewButtonColumn removeColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Xóa",
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

                    bool isAddButton = dataGridView.Columns[e.ColumnIndex].HeaderText == "Thêm";

                    using (Brush brush = new SolidBrush(isAddButton ? Color.Green : Color.Red))
                    {
                        e.Graphics.FillRectangle(brush, e.CellBounds);
                    }

                    string buttonText = isAddButton ? "Thêm" : "Xóa";
                    TextRenderer.DrawText(e.Graphics, buttonText, e.CellStyle.Font, e.CellBounds,
                        Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Graphics.DrawRectangle(Pens.Gray, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1);
                }
            };
        

            dataGridView.CellContentClick += async (s, e) =>
            {
                if (e.RowIndex >= 0 && dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn col)
                {

                    var gr = dataGridView.Rows[e.RowIndex].Cells[0].Value?.ToString();

                    var comboBoxCell = dataGridView.Rows[e.RowIndex].Cells[3] as DataGridViewComboBoxCell;
                    var mh = comboBoxCell?.Value?.ToString();

                    if (string.IsNullOrWhiteSpace(mh))
                    {
                        MessageBox.Show("Chọn màn hình !");
                        return;
                    }
                    if (col.Index == 3)
                    {
                        await roleService.AddMhToGroupRole(gr, mh);
                    }
                    if (col.Index == 4)
                    {
                        await roleService.DeleteMHFromGroupRole(gr, mh);
                    }
                    await Config(s, e);
                    MessageBox.Show("Cập nhật thành công");
                }
                
            };

        }
    }
}
