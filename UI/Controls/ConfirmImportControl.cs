﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.ModelViews.GoodsReceiptModelViews;
using MWarehouse.ModelViews.RoleModelView;
using MWarehouse.Repository.Models;
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
    public partial class ConfirmImportControl : UserControl
    {
        private readonly IImportReceiptService _importService;
        private readonly IProductService _productService;
        private readonly IImportReceiptDetailService _importDetailService;
        private readonly IWarehouseService _warehouseService;
        private readonly ISupplierService _supplierService;
        private IEnumerable<ResponseGoodsReceiptModel> receipts;
        private string code;
        private class Option
        {
            public string Text { get; set; }
            public string Value { get; set; }
        }
        public ConfirmImportControl(IImportReceiptService importService, IWarehouseService warehouse, 
                                    ISupplierService supplierService, IImportReceiptDetailService importReceiptDetailService,
                                    IProductService productService)
        {

            InitializeComponent();
            this._importService = importService;
            this._warehouseService = warehouse;
            this._productService = productService;
            this._supplierService = supplierService;
            this._importDetailService = importReceiptDetailService;
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
            
            if(confirm == DialogResult.OK)
            {
                try
                {
                    await _importService.ConfirmAsync(code);
                    MessageBox.Show("Xác nhận thành công");
                }
                catch(ErrorException ex)
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
                receipts = await _importService.GetAllAsync();
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
                code = GetCellValue("Id", e.RowIndex).ToString();

                if (col.Index == 6 || col.Index == 0)
                {
                    int khoid = int.Parse(GetCellValue("KhoId", e.RowIndex).ToString()!);
                    int nccid = int.Parse(GetCellValue("NccId", e.RowIndex).ToString()!);
                    var tt = int.Parse(GetCellValue("TrangThai", e.RowIndex).ToString());
                    acceptButton.Enabled = false;

                    if (tt == 0)
                    {
                        acceptButton.Enabled = true;
                    }

                    ncc.Text = (await _supplierService.GetByIdAsync(nccid)).TenNcc;
                    kho.Text = (await _warehouseService.GetByIDAsync(khoid)).TenKho;
                    ngaynhap.Text = GetCellValue("NgayNhapKho", e.RowIndex).ToString();
                    dssp.Controls.Clear();
                    foreach(var product in (await _importDetailService.GetAllAsync(await _importService.GetAutoId(code))))
                    {
                        ScreenCard card = new ScreenCard();
                        card.TenMH.Text = (await _productService.GetByIdAsync(product.SanPhamId)).TenSanPham + $" SL: {product.SlNhap}";
                        card.price.Text = product.DonGiaNhap.ToString() + " VND";
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
            receipts = await _importService.GetAllAsync();

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

            dataGridView.CellPainting += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
                    dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    // Hủy ve mac dinh
                    e.Handled = true;

                    // Vẽ nền
                    e.PaintBackground(e.CellBounds, true);

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

                    e.Graphics.FillRectangle(brush, e.CellBounds);

                    TextRenderer.DrawText(e.Graphics, buttonText, e.CellStyle.Font, e.CellBounds,
                        Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Graphics.DrawRectangle(Pens.Gray, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1);

                    // Giải phóng brush
                    brush.Dispose();
                }
            };
            int hoveredColumnIndex = -1;
            int hoveredRowIndex = -1;
            int clickedColumnIndex = -1;
            int clickedRowIndex = -1;

            // giao dien nut
            dataGridView.CellPainting += (s, e) =>
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
                    dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    e.Handled = true;

                    bool isHovered = e.ColumnIndex == hoveredColumnIndex && e.RowIndex == hoveredRowIndex;
                    bool isClicked = e.ColumnIndex == clickedColumnIndex && e.RowIndex == clickedRowIndex;

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

                    e.Graphics.FillRectangle(brush, e.CellBounds);

                    TextRenderer.DrawText(e.Graphics, buttonText, e.CellStyle.Font, e.CellBounds,
                        Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                    e.Graphics.DrawRectangle(Pens.Gray, e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width - 1, e.CellBounds.Height - 1);

                    // Giải phóng brush
                    brush.Dispose();
                }
            };

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
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView.Rows.Count &&
                    e.ColumnIndex >= 0 && e.ColumnIndex < dataGridView.Columns.Count &&
                    dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    clickedColumnIndex = e.ColumnIndex;
                    clickedRowIndex = e.RowIndex;

                    dataGridView.InvalidateCell(e.ColumnIndex, e.RowIndex);

                    Task.Delay(200).ContinueWith(_ =>
                    {
                        clickedColumnIndex = -1;
                        clickedRowIndex = -1;
                        dataGridView.Invoke(new Action(() =>
                        {
                            // ve lai
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
