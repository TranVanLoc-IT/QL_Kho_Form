using MWarehouse.Contract.Service.Interface;
using MWarehouse.ModelViews.ProductTypeModelViews;
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

namespace UI.Controls
{
    public partial class ProductTypeControl : UserControl
    {
        private readonly IProductTypeService _productTypeService;
        private readonly IProductService _productService;
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

        }

        private async Task LoadDataSource(int code)
        {
            this.dataGridView.DataSource = (await this._productTypeService.GetAllAsync()).Where(r => r.AutoId == code);
            this.comboBoxProductList.DataSource = await this._productService.GetAllAsync();
            this.comboBoxProductList.DisplayMember = "TenSanPham";
            this.comboBoxProductList.ValueMember = "AutoId";
        }

        private async Task DataGridView_RowHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCellCollection cells = this.dataGridView.SelectedRows[0].Cells;
            this.txtProductTypeCode.Text = cells[0].ToString();
            this.txtProductTypeName.Text = cells[1].ToString();
            await LoadDataSource(int.Parse(cells[0].ToString()));
        }

        private async Task DeleteButton_Click(object? sender, EventArgs e)
        {
            await _productTypeService.DeleteAsync(int.Parse(this.txtProductTypeCode.ToString()));
        }

        private async Task CreateButton_Click(object? sender, EventArgs e)
        {
            CreateProductTypeModel data = GetCreateData();
            if (data == null) return;
            await _productTypeService.CreateAsync(data);
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
