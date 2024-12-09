using MWarehouse.Contract.Service.Interface;
using MWarehouse.ModelViews.GoodsReceiptModelDetailViews;
using MWarehouse.ModelViews.GoodsReceiptModelViews;
using MWarehouse.Service.Service;
using System.ComponentModel;

namespace UI.Controls
{
    public partial class GoodsReceiptControl : UserControl
    {
        private readonly IGoodsReceiptService _goodsReceiptService;
        private readonly IGoodsReceiptDetailService _goodsReceiptDetailService;
        private readonly ISupplierService _supplierService;
        private readonly IProductService _productService;
        private readonly IWarehouseService _warehouseService;
        private IEnumerable<ResponseGoodsReceiptModel> _receipts;
        private ErrorProvider err = new ErrorProvider();
        private class ProductImportModel
        {
            [DisplayName("Mã sản phẩm")]
            public string ProductCode { get; set; }

            [DisplayName("Tên sản phẩm")]
            public string ProductName { get; set; }

            [DisplayName("Số lượng nhập")]
            public int Quantity { get; set; }
        }

        public GoodsReceiptControl(IGoodsReceiptService goodsReceiptService, ISupplierService supplierService, 
                                        IWarehouseService warehouseService, IProductService productService, IGoodsReceiptDetailService goodsReceiptDetailService)
        {
            this._productService = productService;
            this._supplierService = supplierService;
            this._warehouseService = warehouseService;
            this._goodsReceiptService = goodsReceiptService;
            this._goodsReceiptDetailService = goodsReceiptDetailService;
            InitializeComponent();
            quantitySupply.ValueChanged += quantitySupply_ValueChanged;
            addProduct.button.Click += AddProduct_Click;
            createButton.Click += async (s, e) => await CreateButton_Click(s, e);
            updateButton.Click += async (s, e) => await UpdateButton_Click(s, e);
            deleteButton.Click += async(s,e)=>await DeleteButton_Click(s, e);
            removeProduct.button.Click += RemoveButton_Click;
            this.Load += async (s, e) => await ConfigAll();
        }

        private async Task DeleteButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtReceiptCode.Text))
            {
                MessageBox.Show("Mã code không được để trống", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            await _goodsReceiptService.DeleteAsync(int.Parse(this.txtReceiptCode.Text));
        }

        private async Task UpdateButton_Click(object? sender, EventArgs e)
        {
            UpdateGoodsReceiptModel update = new UpdateGoodsReceiptModel();
            await _goodsReceiptService.UpdateAsync(update);
        }

        private async Task CreateButton_Click(object? sender, EventArgs e)
        {
            CreateGoodsReceiptModel create = new CreateGoodsReceiptModel();
            List<CreateGoodsReceiptDetailModel> details = new List<CreateGoodsReceiptDetailModel>();
            create.NgayNhapKho = DateOnly.FromDateTime(DateTime.Now);
            create.GhiChu = txtNote.Text;
            create.KhoId = int.Parse(cbWarehouse.SelectedValue!.ToString()!);
            create.NccId = int.Parse(cbSuppliers.SelectedValue!.ToString()!);

            await _goodsReceiptService.CreateAsync(create);
        }

        private void RemoveButton_Click(object? sender, EventArgs e)
        {
           
        }

        private void AddProduct_Click(object? sender, EventArgs e)
        {
            if (this.quantitySupply.Value <= 0)
            {
                err.SetError(quantitySupply, "Số lượng nhập phải > 0");
                return;
            }
            else
            {
                this.quantitySupply.Value = 0;
                ProductImportModel productImport = new ProductImportModel();
                productImport.ProductName = this.cbProducts.SelectedText;
                productImport.ProductCode = this.cbProducts.SelectedValue!.ToString()!;
            }
        }

        private async Task ConfigAll()
        {
            _receipts = await _goodsReceiptService.GetAllAsync();
            cbFilter.DataSource = _receipts.GroupBy(r => r.NgayNhapKho).Distinct().ToList();
            if(cbFilter.DataSource != null)
            {
                cbFilter.DisplayMember = "NgayNhapKho";
            }
            dataGridView.DataSource = _receipts;
            cbProducts.DataSource = await _productService.GetAllAsync();
            cbProducts.DisplayMember = "TenSanPham";
            cbProducts.ValueMember = "AutoId";
            cbWarehouse.DataSource = await _warehouseService.GetAllAsync();
            cbSuppliers.DataSource = await _productService.GetAllAsync();
            cbSuppliers.DisplayMember = "TenNcc";
            cbSuppliers.ValueMember = "AutoId";

            createButton.button.Click += async (s, e) =>
            {
                try
                {
                    CreateGoodsReceiptModel model = GetCreateDataModel();
                    await _goodsReceiptService.CreateAsync(model);
                    await _goodsReceiptDetailService.CreateAsync(GetDetailsData(model.AutoId));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private CreateGoodsReceiptModel GetCreateDataModel()
        {
            CreateGoodsReceiptModel model = new CreateGoodsReceiptModel();
            model.AutoId = int.Parse(this.txtReceiptCode.Text);
            model.GhiChu = this.txtNote.Text ;
            model.KhoId = int.Parse(this.cbWarehouse.SelectedValue!.ToString()!);
            model.NccId = int.Parse(this.cbSuppliers.SelectedValue!.ToString()!);

            return model;
        }

        private IEnumerable<CreateGoodsReceiptDetailModel> GetDetailsData(int code)
        {
            List<CreateGoodsReceiptDetailModel> details = new List<CreateGoodsReceiptDetailModel>();
            //foreach (DataGridViewRow row in dataGridViewProductImport.Rows)
            //{
            //    CreateGoodsReceiptDetailModel model = new CreateGoodsReceiptDetailModel();
            //    model.SlNhap = int.Parse(row.Cells[2].ToString());
            //    model.SanPhamId = int.Parse(row.Cells[0].ToString());
            //    model.NhapKhoId = code;
            //    model.AutoId = IDGenerator.GenerateImportReceiptID(5, _receipts);
            //    details.Add(model);
            //}
            return details;
        }

        private bool ValidateData()
        {
            if (cbProducts.SelectedValue == null)
            {
                err.SetError(this.cbProducts, "Chọn sản phẩm");

                return false;
            }
            if (cbWarehouse.SelectedValue == null)
            {
                err.SetError(this.cbWarehouse, "Chọn kho nhập sản phẩm");

                return false;
            }
         
            return true;
        }

        private void quantitySupply_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
