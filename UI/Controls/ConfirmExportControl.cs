using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.ModelViews.ExportReceiptDetailModelView;
using MWarehouse.ModelViews.ExportReceiptModelView;
using MWarehouse.ModelViews.GoodsReceiptModelViews;
using MWarehouse.Service.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Controls.MiniControl;
using UI.Controls.UCButton;

namespace UI.Controls
{
    public partial class ConfirmExportControl : UserControl
    {
        private readonly IExportReceiptService _exportService;
        private readonly IProductService _productService;
        private readonly IExportReceiptDetailService _exportDetailService;
        private readonly IWarehouseService _warehouseService;
        private IEnumerable<ResponseExportReceiptModel> receipts;
        private int code;
        private class Option
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }
        public ConfirmExportControl(IExportReceiptService exportService, IWarehouseService warehouse,
                                    IExportReceiptDetailService exportReceiptDetailService,
                                    IProductService productService)
        {

            InitializeComponent();
            this._exportService = exportService;
            this._warehouseService = warehouse;
            this._productService = productService;
            this._exportDetailService = exportReceiptDetailService;
            var options = new List<Option>
                    {
                        new Option { Text = "Chưa duyệt", Value = "UnConfirmed" },
                        new Option { Text = "Đã duyệt", Value = "Confirmed" },
                        new Option { Text = "Tất cả", Value = "All" }
                    };

            comboBox.DataSource = options;
            comboBox.DisplayMember = "Text";
            comboBox.ValueMember = "Value";
            comboBox.SelectedValueChanged += async (s, e) => await ComboBox_SelectedValueChanged(s, e);
            this.Load += async (s, e) => await Config(s, e);
            acceptButton.button.Click += async (s, e) => await AcceptButton(s, e);
            dataGridView.CellContentClick += async (s, e) => await cellContentClick(s, e);
        }
        private async Task AcceptButton(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Xác nhận duyệt !", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (confirm == DialogResult.OK)
            {
                try
                {
                    await _exportService.ConfirmAsync(code);
                    MessageBox.Show("Xác nhận thành công");
                }
                catch (ErrorException ex)
                {
                    MessageBox.Show("Không thấy phiếu");
                }
                acceptButton.Enabled = false;
                await RefreshDatagridview(sender, e);
            }
        }
        private async Task ComboBox_SelectedValueChanged(object? sender, EventArgs e)
        {
            string value = comboBox.SelectedValue.ToString();
            await RefreshDatagridview(sender, e);
            if (value == "Confirmed")
            {
                dataGridView.DataSource = receipts.Where(r => r.TrangThai == 1).ToList();
            }
            else if (value == "UnConfirmed")
            {
                dataGridView.DataSource = receipts.Where(r => r.TrangThai == 0).ToList();
            }
            else
            {
                receipts = await _exportService.GetAllAsync();
                dataGridView.DataSource = receipts.ToList();
            }
        }

        private async Task RefreshDatagridview(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;

            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            dataGridView.Refresh();
            await Config(sender, e);
        }
        private async Task cellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn col)
            {
                code = int.Parse(GetCellValue("AutoId", e.RowIndex).ToString()!);

                if (col.Index == 5)
                {
                    int khoid = int.Parse(GetCellValue("KhoId", e.RowIndex).ToString()!);
                    var tt = int.Parse(GetCellValue("TrangThai", e.RowIndex).ToString());
                    acceptButton.Enabled = false;
                    if (tt == 0)
                    {
                        acceptButton.Enabled = true;
                    }

                    kho.Text = (await _warehouseService.GetByIDAsync(khoid)).TenKho;
                    ngayxuat.Text = GetCellValue("NgayXuatKho", e.RowIndex).ToString();
                    dssp.Controls.Clear();
                    foreach (var product in (await _exportDetailService.GetDetailAsync(code)))
                    {
                        ScreenCard card = new ScreenCard();
                        card.TenMH.Text = (await _productService.GetByIdAsync(product.SanPhamId)).TenSanPham + $" SL: {product.SlXuat}";
                        card.price.Text = product.DonGiaXuat.ToString() + "VND";
                        dssp.Controls.Add(card);
                    }
                }
            }
        }

        private object GetCellValue(string columnName, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dataGridView.Rows.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(rowIndex), "Index dòng nằm ngoài phạm vi hợp lệ.");
            }

            var column = dataGridView.Columns[columnName];
            var cell = dataGridView.Rows[rowIndex].Cells[column.Index];

            return cell.Value;
        }

        private async Task Config(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;
            receipts = await _exportService.GetAllAsync();

            dataGridView.DataSource = receipts.ToList();

            ButtonOptionConfig();

        }
        private void ButtonOptionConfig()
        {
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

                    if (dataGridView.Columns[e.ColumnIndex] == detailColumn)
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

                    if (dataGridView.Columns[e.ColumnIndex] == detailColumn)
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
