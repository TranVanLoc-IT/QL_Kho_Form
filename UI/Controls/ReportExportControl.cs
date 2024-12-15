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
    public partial class ReportExportControl : UserControl
    {
        private readonly BC_PHIEUXUAT bC_PHIEUXUAT;
        public ReportExportControl()
        {
            InitializeComponent();
            bC_PHIEUXUAT = new BC_PHIEUXUAT(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ngày nhập và ngày xuất từ giao diện
                DateTime ngayNhap = dateTimePickerBatdau.Value;
                DateTime ngayXuat = dateTimePickerKetthuc.Value;

                // Gọi hàm để lấy báo cáo
                DataTable bcxuat = bC_PHIEUXUAT.GetBCphieuXuat(ngayNhap, ngayXuat);

                // Hiển thị dữ liệu trên DataGridView
                if (bcxuat.Rows.Count > 0)
                {
                    dataGridView.DataSource = bcxuat;
                }
                else
                {
                    MessageBox.Show("chưa có du liệu");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
    }
}
