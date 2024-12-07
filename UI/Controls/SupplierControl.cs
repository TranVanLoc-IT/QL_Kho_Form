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

namespace UI.Controls
{
    public partial class SupplierControl : UserControl
    {
        private readonly ISupplierService _supplierService;
        private readonly IProductService _productService;
        public SupplierControl(ISupplierService supplierService, IProductService productService)
        {
            this._supplierService = supplierService;
            this._productService = productService;
            InitializeComponent();
            this.Load += async (s, e) => await ConfigAll();
        }
        private async Task ConfigAll()
        {
            createButton1.button.Click += async (s, e) => await CreateButton_Click(s, e);
            deleteButton1.button.Click += async (s, e) => await DeleteButton_Click(s, e);
            this.dataGridView.RowHeaderMouseClick += async (s, e) => await DataGridView_RowHeaderMouseClick(s, e);

        }

        private async Task LoadDataSource(int code)
        {
            this.dataGridView.DataSource = (await this._supplierService.GetAllAsync()).Where(r => r.AutoId == code);
            this.comboBoxProductSupply.DataSource = await this._productService.GetAllAsync();
            this.comboBoxProductSupply.DisplayMember = "TenSanPham";
            this.comboBoxProductSupply.ValueMember = "AutoId";
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
            await _supplierService.DeleteAsync(int.Parse(this.txtSupplierCode.ToString()));
        }

        private async Task CreateButton_Click(object? sender, EventArgs e)
        {
            CreateSupplierModel data = GetCreateData();
            if (data == null) return;
            await _supplierService.CreateAsync(data);
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
            if (string.IsNullOrWhiteSpace(this.txtSupplierCode.Text))
            {
                DialogResult result = MessageBox.Show("Nhập mã code hoặc tự sinh", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    err.SetError(this.txtSupplierCode, "Nhập mã code");
                    return false;
                }
            }
            if (string.IsNullOrWhiteSpace(this.txtSupplierName.Text))
            {
                err.SetError(this.txtSupplierName, "Nhập tên loại sản phẩm");

                return false;
            }

            return true;
        }
    }
}
