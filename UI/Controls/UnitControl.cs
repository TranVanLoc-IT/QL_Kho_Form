using MWarehouse.Contract.Service.Interface;
using MWarehouse.ModelViews.ProductModelViews;
using MWarehouse.ModelViews.UnitModelViews;

namespace UI.Controls
{
    public partial class UnitControl : UserControl
    {
        private readonly IUnitService _unitService;
        private readonly IProductService _productService;
        private IEnumerable<ResponseProductModel> _productData;
        private List<ResponseProductModel> _productApplied;
        public UnitControl(IUnitService unitService, IProductService productService)
        {
            this._unitService = unitService;
            this._productService = productService;
            _productApplied = new List<ResponseProductModel>();
            InitializeComponent();
            this.Load += async (s, e) => await ConfigAll();
        }

        private async Task ConfigAll()
        {
            createButton.button.Click += async (s, e) => await CreateButton_Click(s, e);
            deleteButton.button.Click += async (s, e) => await DeleteButton_Click(s, e);
            acceptButton.Click += async (s, e) => await AcceptButton_Click(s, e);
            dataGridView1.RowHeaderMouseClick += DataGridView1_RowHeaderMouseClick;
            dataGridViewProductApply.RowHeaderMouseClick += DataGridViewProductApply_RowHeaderMouseClick;
            _productData = await _productService.GetAllAsync();
            cbProducts.DataSource = _productData.ToList();
            cbProducts.DisplayMember = "TenSanPham";
            cbProducts.ValueMember = "AutoId";
            await LoadDataGridData();
            cbProducts.SelectedIndexChanged += CbProducts_SelectedIndexChanged;
        }

        private void DataGridViewProductApply_RowHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Xác nhận xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                _productApplied.Remove(_productApplied.Where(r => r.AutoId == int.Parse(cbProducts.SelectedValue.ToString())).First());
                dataGridViewProductApply.DataSource = _productApplied;
            }
        }

        private async Task AcceptButton_Click(object? sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Xác nhận lưu ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                await _productService.UpdateUnitAsync(int.Parse(txtUnitCode.Text), _productApplied.Select(r => r.AutoId).ToArray());

            }
        }

        private void CbProducts_SelectedIndexChanged(object? sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Xác nhận thêm ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                _productApplied.Add(_productData.Where(r => r.AutoId == int.Parse(cbProducts.SelectedValue.ToString())).First());
                dataGridViewProductApply.DataSource = _productApplied;
            }
        }

        private void BtnRemovePr_Click(object? sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridViewProductApply.SelectedRows;
            foreach (var r in rows)
            {
                dataGridViewProductApply.Rows.Remove((DataGridViewRow)r);
            }
        }


        private void DataGridView1_RowHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewCellCollection cells = this.dataGridView1.SelectedRows[0].Cells;
            this.txtUnitCode.Text = cells[0].ToString();
            this.txtUnitName.Text = cells[1].ToString();
        }

        private async Task DeleteButton_Click(object? sender, EventArgs e)
        {
            await _unitService.DeleteAsync(int.Parse(this.txtUnitCode.ToString()));
        }

        private async Task CreateButton_Click(object? sender, EventArgs e)
        {
            CreateUnitModel data = GetCreateData();
            if (data == null) return;
            await _unitService.CreateAsync(data);
        }

        private async Task LoadDataGridData()
        {
            this.dataGridView1.DataSource = await _unitService.GetAllAsync();
            this.dataGridView1.Show();
        }
        private CreateUnitModel GetCreateData()
        {
            if (!ValidateData())
            {
                return null;
            }
            CreateUnitModel model = new CreateUnitModel();
            model.TenDvt = this.txtUnitName.Text;
            model.GhiChu = txtNote.Text;
            return model;
        }
        private bool ValidateData()
        {
            ErrorProvider err = new ErrorProvider();
            if (string.IsNullOrWhiteSpace(this.txtUnitCode.Text))
            {
                DialogResult result = MessageBox.Show("Nhập mã code hoặc tự sinh", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                {
                    err.SetError(this.txtUnitCode, "Nhập mã code");
                    return false;
                }
            }
            if (string.IsNullOrWhiteSpace(this.txtUnitName.Text))
            {
                err.SetError(this.txtUnitName, "Nhập tên đơn vị tính");
                return false;
            }

            return true;
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string find = cbProducts.Text;
            int value;
            int.TryParse(find, out value);
            if (!string.IsNullOrWhiteSpace(find))
            {
                var result = _productData.Where(item => item.TenSanPham.ToLower().Contains(find.ToLower()) || item.AutoId == value);
                cbProducts.DataSource = result.ToList();
            }
        }
    }
}
