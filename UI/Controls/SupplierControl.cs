using MWarehouse.Contract.Service.Interface;
using MWarehouse.ModelViews.SupplierModelViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Controls.UCButton;
using static MWarehouse.Core.Constant.ErrorCode;

namespace UI.Controls
{
    public partial class SupplierControl : UserControl
    {
        private readonly ISupplierService _supplierService;
        private readonly IGoodsReceiptService _importService;
        private readonly IProductService _productService;
        private IEnumerable<ResponseSupplierModel> _responseSupplierModels;
        public SupplierControl(ISupplierService supplierService, IProductService productService, IGoodsReceiptService importService)
        {
            this._supplierService = supplierService;
            this._productService = productService;
            InitializeComponent();
            this.Load += async (s, e) => await ConfigAll();
            _importService = importService;
        }
        private async Task ConfigAll()
        {
            createButton1.button.Click += async (s, e) => await CreateButton_Click(s, e);
            deleteButton1.button.Click += async (s, e) => await DeleteButton_Click(s, e);
            cbProduct.SelectedIndexChanged += CbProduct_SelectedIndexChanged;
            this.dataGridView.RowHeaderMouseClick += async (s, e) => await DataGridView_RowHeaderMouseClick(s, e);
            await LoadGrid();


        }

        private void CbProduct_SelectedIndexChanged(object? sender, EventArgs e)
        {
            this.dataGridView.DataSource = _responseSupplierModels.Where(r => r.AutoId == int.Parse(cbProduct.SelectedValue.ToString()));
        }

        private async Task LoadDataSource(int code)
        {
            ErrorProvider err = new ErrorProvider();
            if (string.IsNullOrWhiteSpace(this.txtSupplierCode.Text))
            {
                err.SetError(this.txtSupplierName, "Nhập mã");

                return;
            }
            var pr = await _importService.GetAllByBrandAsync(int.Parse(txtSupplierCode.Text));
            dataGridViewProductSupplied.DataSource = pr.ToList();
            textBoxTotalQuantitySupply.Text = pr.Sum(r => r.Quantity).ToString();
        }

        private void ClearTB()
        {
            foreach(Control c in this.Controls)
            {
                if(c is TextBox t)
                {
                    t.Text = "";
                }
            }
        }
        private async Task DataGridView_RowHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCellCollection cells = this.dataGridView.SelectedRows[0].Cells;
            this.txtSupplierCode.Text = cells[0].ToString();
            this.txtSupplierName.Text = cells[1].ToString();
            await LoadDataSource(int.Parse(cells[0].ToString()));
        }

        private async Task DeleteButton_Click(object? sender, EventArgs e)
        {
            DialogResult choose = MessageBox.Show("Xác nhận xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (choose == DialogResult.Yes)
            {
                await _supplierService.DeleteAsync(int.Parse(this.txtSupplierCode.ToString()));
                ClearTB();
                await LoadGrid();
            }
        }

        private async Task LoadGrid()
        {
            _responseSupplierModels = await this._supplierService.GetAllAsync();
            dataGridView.DataSource = _responseSupplierModels.ToList();
        }
        private async Task CreateButton_Click(object? sender, EventArgs e)
        {
            CreateSupplierModel data = GetCreateData();
            if (data == null) return;
            await _supplierService.CreateAsync(data);
            ClearTB();
            await LoadGrid();
        }

        private CreateSupplierModel GetCreateData()
        {
            if (!ValidateData())
            {
                return null;
            }
            CreateSupplierModel model = new CreateSupplierModel();
            model.TenNcc = this.txtSupplierName.Text;
            return model;
        }
        private bool ValidateData()
        {
            ErrorProvider err = new ErrorProvider();
            if (string.IsNullOrWhiteSpace(this.txtSupplierName.Text))
            {
                err.SetError(this.txtSupplierName, "Nhập tên loại sản phẩm");

                return false;
            }

            return true;
        }
    }
}
