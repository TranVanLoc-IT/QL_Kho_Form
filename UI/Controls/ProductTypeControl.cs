using MWarehouse.Contract.Service.Interface;
using MWarehouse.ModelViews.ProductModelViews;
using MWarehouse.ModelViews.ProductTypeModelViews;

namespace UI.Controls
{
    public partial class ProductTypeControl : UserControl
    {
        private readonly IProductTypeService _productTypeService;
        private readonly IProductService _productService;
        private List<ProductResultLine> _resultLines = new List<ProductResultLine>();
        private IEnumerable<ResponseProductModel> _products;
        public ProductTypeControl(IProductService productService, IProductTypeService productTypeService)
        {
            this._productService = productService;
            this._productTypeService = productTypeService;
            InitializeComponent();
            this.Load += async (s, e) => await ConfigAll();
        }

        private async Task ConfigAll()
        {
            createButton.button.Click += async (s, e) => await CreateButton_Click(s, e);
            deleteButton.button.Click += async (s, e) => await DeleteButton_Click(s, e);
            this.dataGridView.RowHeaderMouseClick += async (s, e) => await DataGridView_RowHeaderMouseClick(s, e);
            this.dataGridView.DataSource = (await this._productTypeService.GetAllAsync());
            _products = await this._productService.GetAllAsync();
            this.comboBoxProductList.DataSource = _products.ToList();
            this.comboBoxProductList.DisplayMember = "TenSanPham";
            this.comboBoxProductList.ValueMember = "AutoId";

        }

        private async Task LoadDataSource(int code)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var i in _products.Where(r => r.LoaiSanPhamId == code))
            {
                ProductResultLine line = new ProductResultLine();
                line.prName.Text = i.TenSanPham;
                line.deleteButton1.button.Click += Button_Click;
                flowLayoutPanel1.Controls.Add(line);
            }
        }

        private void ClearTB()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox t)
                {
                    t.Text = "";
                }
            }
        }
        private void Button_Click(object? sender, EventArgs e)
        {
            if (!ValidateData()) return;
            _productService.UpdateProductTypeAsync(int.Parse(comboBoxProductList.SelectedValue.ToString()), int.Parse(txtProductTypeCode.Text));
        }

        private async Task DataGridView_RowHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCellCollection cells = this.dataGridView.SelectedRows[0].Cells;
            this.txtProductTypeCode.Text = cells[0].ToString();
            this.txtProductTypeName.Text = cells[1].ToString();
            this.txtNote.Text = cells[2].ToString();
            await LoadDataSource(int.Parse(cells[0].ToString()));
        }

        private async Task DeleteButton_Click(object? sender, EventArgs e)
        {
            ErrorProvider err = new ErrorProvider();
            if (string.IsNullOrWhiteSpace(this.txtProductTypeCode.Text))
            {
                err.SetError(this.txtProductTypeCode, "Nhập mã");

                return;
            }
            DialogResult choose = MessageBox.Show("Xác nhận xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (choose == DialogResult.Yes)
            {
                await _productTypeService.DeleteAsync(int.Parse(this.txtProductTypeCode.ToString()));
            }
            this.dataGridView.DataSource = (await this._productTypeService.GetAllAsync()).ToList();
            ClearTB();
        }

        private async Task CreateButton_Click(object? sender, EventArgs e)
        {
            CreateProductTypeModel data = GetCreateData();
            if (data == null) return;
            await _productTypeService.CreateAsync(data);
            this.dataGridView.DataSource = (await this._productTypeService.GetAllAsync()).ToList();
            ClearTB();
        }

        private CreateProductTypeModel GetCreateData()
        {
            if (!ValidateData())
            {
                return null;
            }
            CreateProductTypeModel model = new CreateProductTypeModel();
            model.TenLsp = this.txtProductTypeName.Text;
            return model;
        }
        private bool ValidateData()
        {
            ErrorProvider err = new ErrorProvider();
            if (string.IsNullOrWhiteSpace(this.txtProductTypeCode.Text))
            {
                DialogResult result = MessageBox.Show("Nhập mã code hoặc tự sinh", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    err.SetError(this.txtProductTypeCode, "Nhập mã code");
                    return false;
                }
            }
            if (string.IsNullOrWhiteSpace(this.txtProductTypeName.Text))
            {
                err.SetError(this.txtProductTypeName, "Nhập tên loại sản phẩm");

                return false;
            }

            return true;
        }
    }
}
