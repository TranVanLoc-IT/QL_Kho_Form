using MWarehouse.Contract.Service.Interface;
using MWarehouse.ModelViews.ProductModelViews;
using MWarehouse.ModelViews.ProductTypeModelViews;
using MWarehouse.Repository.Models;
using System.Threading.Tasks;
namespace UI.Controls
{
    public partial class ProductControl : UserControl
    {
        private readonly IProductService _productService;
        private readonly IUnitService _unitService;
        private readonly IProductTypeService _productTypeService;
        private IEnumerable<ResponseProductModel> products;
        public ProductControl(IProductService productService, IUnitService unitService, IProductTypeService productTypeService)
        {
            this._productService = productService;
            this._unitService = unitService;
            this._productTypeService = productTypeService;
            InitializeComponent();

            this.Load += async (s, e) => await Config();
        }

        private async Task Config()
        {
            products = await _productService.GetAllAsync();
            this.dataGridView.DataSource = products;
            await ConfigEvent();
            await LoadFilterData();
        }
        private async Task LoadFilterData()
        {
            IEnumerable<ResponseProductModel> data = await _productService.GetAllAsync();
            this.comboBoxFilter.Items.Clear();
            this.comboBoxFilter.DataSource = data;
            this.comboBoxFilter.DisplayMember = "TenLsp";
            this.comboBoxFilter.ValueMember = "AutoId";
            this.comboBoxFilter.Items.Add(new { TenLsp = "Tất cả", AutoId = "All" });

            this.comboBoxFilter.SelectedIndexChanged += (s, e) =>
            {
                IEnumerable<ResponseProductModel> filters = products;
                this.dataGridView.DataSource = products.Where(r => r.LoaiSanPhamId == int.Parse(this.comboBoxFilter.SelectedValue!.ToString()!)).ToList();
            };

        }
        private async Task ConfigEvent()
        {
            createButton.button.Click += async (s, e) => await CreateButton_Click(s, e);
            deleteButton.button.Click += async (s, e) => await DeleteButton_Click(s, e);
            updateButton.button.Click += async (s, e) => await UpdateButton_Click(s, e);
            refreshBtn.Click += async(s, e) => {
                this.products = await _productService.GetAllAsync();
            };
            // combo
            comboBoxFilter.SelectedIndexChanged += ComboBoxFilter_SelectedIndexChanged;
        }

        private void ComboBoxFilter_SelectedIndexChanged(object? sender, EventArgs e)
        {
            int result;
            bool parse = int.TryParse(this.comboBoxFilter.SelectedValue.ToString(), out result);
            if (parse)
            {
                dataGridView.DataSource = products.Where(r => r.LoaiSanPhamId == result);
            }
            else
            {
                dataGridView.DataSource = products;
            }
        }

        private async Task UpdateButton_Click(object? sender, EventArgs e)
        {
            UpdateProductModel model = GetUpdateData();
            if (model == null) return;
            await _productService.UpdateAsync(dataGridView.SelectedRows[0].Cells[0].ToString(), model);
        }

        private async Task DeleteButton_Click(object? sender, EventArgs e)
        {
            await _productService.DeleteAsync(int.Parse(dataGridView.SelectedRows[0].Cells[0].ToString()));
        }

        private async Task CreateButton_Click(object? sender, EventArgs e)
        {
            CreateProductModel model = GetCreateData();
            if (model == null) return;
            await _productService.CreateAsync(model);
        }

        private CreateProductModel GetCreateData()
        {
            if (!ValidateData()) return null;
            CreateProductModel model = new CreateProductModel();
            model.GhiChu = this.txtProductNote.Text;
            model.TenSanPham = this.txtProductName.Text;

            return model;
        }

        private void DisplaySelectedResponseData()
        {
            DataGridViewCellCollection cell = dataGridView.SelectedRows[0].Cells;
            this.txtProductCode.Text = cell[0].ToString();
            this.cbProductType.SelectedValue = cell[2].ToString();
            this.txtProductName.Text = cell[1].ToString();
            this.cbUnit.SelectedValue = cell[3].ToString();
            this.txtProductNote.Text = cell[4].ToString();
        }

        private UpdateProductModel GetUpdateData()
        {
            if (!ValidateData()) return null;

            UpdateProductModel model = new UpdateProductModel();
            model.GhiChu = this.txtProductNote.Text;
            model.AutoId = this.txtProductCode.Text == "" ? model.AutoId : int.Parse(this.txtProductCode.Text);
            model.TenSanPham = this.txtProductCode.ProductName == "" ? model.TenSanPham : this.txtProductName.Text;
            return model;
        }

        private bool ValidateData()
        {
            ErrorProvider err = new ErrorProvider();
            if(string.IsNullOrWhiteSpace(this.txtProductCode.Text))
            {
                DialogResult result = MessageBox.Show("Nhập mã code hoặc tự sinh", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    err.SetError(this.txtProductCode, "Nhập mã code");
                    return false;
                }
            }
            if (string.IsNullOrWhiteSpace(this.txtProductName.Text))
            {
                err.SetError(this.txtProductName, "Nhập tên sản phẩm");

                return false;
            }
            if (this.cbProductType.SelectedIndex == 0)
            {
                err.SetError(this.cbProductType, "Chọn loại sản phẩm");

                return false;
            }
            if (this.cbUnit.SelectedIndex == 0)
            {
                err.SetError(this.cbUnit, "Chọn đơn vị tính");

                return false;
            }

            return true;
        }
    }
}
