using MWarehouse.Contract.Service.Interface;
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
    public partial class ReportImportControl : UserControl
    {
        private readonly ILoginService _loginService;
        private readonly BC_Phieunhap PCPN;

        public ReportImportControl()
        {
            InitializeComponent();

            PCPN = new BC_Phieunhap(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ngày nhập và ngày xuất từ giao diện
                DateTime ngayNhap = dateTimePickerBatdau.Value;
                DateTime ngayXuat = dateTimePickerKetthuc.Value;

                // Gọi hàm để lấy báo cáo
                DataTable bcpntable = PCPN.GetBCphieuNhap(ngayNhap, ngayXuat);

                // Hiển thị dữ liệu trên DataGridView
                if (bcpntable.Rows.Count > 0)
                {
                    dataGridView.DataSource = bcpntable;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
