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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI.Controls
{
    public partial class ConfirmExportControl : UserControl
    {
        private readonly IExportReceiptService _exportService;
        public ConfirmExportControl(IExportReceiptService importService)
        {

            InitializeComponent();
            this._exportService = importService;
            var options = new List<Option>
                    {
                        new Option { Text = "Chưa duyệt", Value = "UnConfirmed" },
                        new Option { Text = "Đã duyệt", Value = "Confirmed" }
                    };

            comboBox.DataSource = options;
            comboBox.DisplayMember = "Text";
            comboBox.ValueMember = "Value";


            this.Load += async (s, e) => await Config(s, e);
            dataGridView.CellContentClick += async (s, e) => await cellContentClick(s, e);

        }
        private class Option
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }

        private async Task cellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn col)
            {
                var gr = dataGridView.Rows[e.RowIndex].Cells[0].Value?.ToString();
                var act = dataGridView.Rows[e.RowIndex].Cells[2] as DataGridViewComboBoxCell;
                var allMhs = dataGridView.Rows[e.RowIndex].Cells[3] as DataGridViewComboBoxCell;

                if (col.Index == 6)
                {


                }
                else
                {

                    MessageBox.Show("Cập nhật thành công");
                }
            }
        }


        private async Task Config(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;

            dataGridView.DataSource = await _exportService.GetAllAsync();

            ButtonOptionConfig();

        }
        private void ButtonOptionConfig()
        {
            // Thêm các cột nút
            DataGridViewButtonColumn confirmColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Thêm",
                UseColumnTextForButtonValue = true // Hiển thị văn bản trên nút
            };
            dataGridView.Columns.Add(confirmColumn);

            DataGridViewButtonColumn detailColumn = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Xác nhận",
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

                    if (dataGridView.Columns[e.ColumnIndex] == confirmColumn)
                    {
                        brush = new SolidBrush(Color.Green);
                        buttonText = "Xác nhận";
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

                    if (dataGridView.Columns[e.ColumnIndex] == confirmColumn)
                    {
                        brush = new SolidBrush(isClicked ? Color.DarkGreen : isHovered ? Color.Green : Color.LightGreen);
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
    }
}
