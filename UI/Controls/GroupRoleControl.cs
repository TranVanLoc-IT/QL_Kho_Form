using MWarehouse.Contract.Service.Interface;
using MWarehouse.ModelViews.RoleModelView;
using System.Data.Common;
using System.Linq;

namespace UI.Controls
{
    public partial class GroupRoleControl : UserControl
    {
        private readonly IRoleService roleService;
        private List<ManHinhView> dsManHinh;
        public GroupRoleControl(IRoleService role)
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
                var gr = dataGridView.Rows[e.RowIndex].Cells[0].Value?.ToString();
                var act = dataGridView.Rows[e.RowIndex].Cells[3] as DataGridViewComboBoxCell;
                var allMhs = dataGridView.Rows[e.RowIndex].Cells[4] as DataGridViewComboBoxCell;

                if (7 - col.Index == 3 || 7 - col.Index == 4 || 7 -  col.Index == 5)
                {
                    act = dataGridView.Rows[e.RowIndex].Cells[0] as DataGridViewComboBoxCell;
                    allMhs = dataGridView.Rows[e.RowIndex].Cells[1] as DataGridViewComboBoxCell;
                    gr = dataGridView.Rows[e.RowIndex].Cells[5].Value?.ToString();
                }

                if (7 - col.Index == 3 && col.Text == "Chi tiết" || col.Index == 7)
                {
                    if(act == null)
                    {

                        act = new DataGridViewComboBoxCell();
                        allMhs = new DataGridViewComboBoxCell();
                    }

                    List<ManHinhView> actMhs = await roleService.GetMhActivating(gr);
                    act.DataSource = actMhs;
                    act.DisplayMember = "TenMH";
                    act.ValueMember = "MaMH";
                    if (actMhs.Count > 0)
                    {
                        act.Value = actMhs.First().MaMH;
                    }

                    var actMhsIds = new HashSet<string>(actMhs.Select(m => m.MaMH));
                    var differentMhs = dsManHinh.Where(m => !actMhsIds.Contains(m.MaMH)).ToList();
                    allMhs.DataSource = differentMhs;
                    allMhs.DisplayMember = "TenMH";
                    allMhs.ValueMember = "MaMH";
                    if (differentMhs.Count > 0)
                    {
                        allMhs.Value = differentMhs.First().MaMH;
                    }
                }
                else
                {
                    if (7 - col.Index == 5 || col.Index == 5)
                    {
                        string mh = allMhs?.Value?.ToString();
                        if (string.IsNullOrWhiteSpace(mh))
                        {
                            MessageBox.Show("Chọn màn hình mới để thêm !");
                            return;
                        }
                        await roleService.AddMhToGroupRole(gr, mh);
                    }
                    else if (7 - col.Index == 4 || col.Index == 6)
                    {
                        string mh = act?.Value?.ToString();

                        if (string.IsNullOrWhiteSpace(mh))
                        {
                            MessageBox.Show("Chọn màn hình đang được truy cập để xóa !");
                            return;
                        }
                        await roleService.DeleteMHFromGroupRole(gr, mh);
                    }
                    await RefreshDatagridview(sender, e);
                    MessageBox.Show("Cập nhật thành công");
                }
            }
        }

        private async Task Config(object sender, EventArgs e)
        {
            dsManHinh = await roleService.DsManHinh();


            var listRoles = await roleService.DsRole();
            dataGridView.DataSource = listRoles;

            DataGridViewComboBoxColumn actScreens = new DataGridViewComboBoxColumn();
            actScreens.HeaderText = "Được truy cập";
            actScreens.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            dataGridView.Columns.Add(actScreens);

            DataGridViewComboBoxColumn colScreens = new DataGridViewComboBoxColumn();
           
            colScreens.HeaderText = "Màn hình";
            colScreens.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            dataGridView.Columns.Add(colScreens);

            ButtonOptionConfig();



        }

        private void ButtonOptionConfig()
        {
            // Thêm các cột nút
            DataGridViewButtonColumn addColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Thêm",
                UseColumnTextForButtonValue = true // Hiển thị văn bản trên nút
            };
            dataGridView.Columns.Add(addColumn);

            DataGridViewButtonColumn removeColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Xóa",
                UseColumnTextForButtonValue = true
            };
            dataGridView.Columns.Add(removeColumn);

            DataGridViewButtonColumn detailColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Chi tiết",
                UseColumnTextForButtonValue = true
            };
            dataGridView.Columns.Add(detailColumn);

            // Tùy chỉnh giao diện nút
            dataGridView.CellPainting += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
                    dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    // Hủy vẽ mặc định
                    e.Handled = true;

                    // Vẽ nền
                    e.PaintBackground(e.CellBounds, true);

                    // Xác định màu sắc và văn bản nút dựa vào tên cột
                    Brush brush;
                    string buttonText;

                    if (dataGridView.Columns[e.ColumnIndex] == addColumn)
                    {
                        brush = new SolidBrush(Color.Green);
                        buttonText = "Thêm";
                    }
                    else if (dataGridView.Columns[e.ColumnIndex] == removeColumn)
                    {
                        brush = new SolidBrush(Color.Red);
                        buttonText = "Xóa";
                    }
                    else if (dataGridView.Columns[e.ColumnIndex] == detailColumn)
                    {
                        brush = new SolidBrush(Color.Blue);
                        buttonText = "Chi tiết";
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
            // Thêm các biến lưu trạng thái hover/click
            int hoveredColumnIndex = -1;
            int hoveredRowIndex = -1;
            int clickedColumnIndex = -1;
            int clickedRowIndex = -1;

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

                    // Xác định màu sắc và văn bản nút dựa vào tên cột
                    Brush brush;
                    string buttonText;

                    if (dataGridView.Columns[e.ColumnIndex] == addColumn)
                    {
                        brush = new SolidBrush(isClicked ? Color.DarkGreen : isHovered ? Color.LightGreen : Color.Green);
                        buttonText = "Thêm";
                    }
                    else if (dataGridView.Columns[e.ColumnIndex] == removeColumn)
                    {
                        brush = new SolidBrush(isClicked ? Color.DarkRed : isHovered ? Color.LightCoral : Color.Red);
                        buttonText = "Xóa";
                    }
                    else if (dataGridView.Columns[e.ColumnIndex] == detailColumn)
                    {
                        brush = new SolidBrush(isClicked ? Color.LightSkyBlue : isHovered ? Color.LightBlue : Color.Blue);
                        buttonText = "Chi tiết";
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

            dataGridView.CellClick += (s, e) =>
            {
                // Kiểm tra chỉ số cột và hàng hợp lệ
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView.Rows.Count &&
                    e.ColumnIndex >= 0 && e.ColumnIndex < dataGridView.Columns.Count &&
                    dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    clickedColumnIndex = e.ColumnIndex;
                    clickedRowIndex = e.RowIndex;

                    // Vẽ lại ô để hiển thị hiệu ứng click
                    dataGridView.InvalidateCell(e.ColumnIndex, e.RowIndex);

                    // Đặt trạng thái clicked về mặc định sau một thời gian ngắn (hiệu ứng click)
                    Task.Delay(200).ContinueWith(_ =>
                    {
                        clickedColumnIndex = -1;
                        clickedRowIndex = -1;
                        dataGridView.Invoke(new Action(() =>
                        {
                            // Kiểm tra lại chỉ số trước khi vẽ lại
                            if (e.RowIndex >= 0 && e.RowIndex < dataGridView.Rows.Count &&
                                e.ColumnIndex >= 0 && e.ColumnIndex < dataGridView.Columns.Count)
                            {
                                dataGridView.InvalidateCell(e.ColumnIndex, e.RowIndex);
                            }
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
