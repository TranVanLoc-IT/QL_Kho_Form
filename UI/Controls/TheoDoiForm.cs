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

namespace UI.Controls
{
    public partial class TheoDoiForm : UserControl
    {
        private ITheoDoiService _theoDoi;
        public TheoDoiForm(ITheoDoiService theoDoiService)
        {
            InitializeComponent();
            this._theoDoi = theoDoiService;
            resetAll.Click += async (s, e) => await Click(s, e);
            this.Load += async (s, e) => await config(s, e);
            this.buttonRefresh.Click += async (s, e) => await refreshClick(s, e);
        }

        private async Task refreshClick(object sender, EventArgs e)
        {
            await RefreshDatagridview(sender, e);
        }
        private async Task config(object sender, EventArgs e)
        {
            dataGridView.DataSource = await _theoDoi.GetAllAsync();
        }
        private async Task Click(object sender, EventArgs e)
        {
            await _theoDoi.ResetAsync();
            DialogResult confirm = MessageBox.Show("Xác nhận !", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (confirm == DialogResult.OK)
            {
                MessageBox.Show("Reset thành công !");
                await RefreshDatagridview(sender, e);
            }
        }
        private async Task RefreshDatagridview(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;

            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();

            dataGridView.Refresh();
            await config(sender, e);

        }
    }
}
