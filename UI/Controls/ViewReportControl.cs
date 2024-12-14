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
    public partial class ViewReportControl : UserControl
    {

        private readonly ILoginService _loginService;
        private readonly Tonkho tonkho;
        public ViewReportControl()
        {
            InitializeComponent();
            tonkho = new Tonkho(null);
        }

        private void ViewReportControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ngày nhập và ngày xuất từ giao diện
                DateTime ngayNhap = dateTimePickerBatdau.Value;
                DateTime ngayXuat = dateTimePickerKetthuc.Value;
                string ngayNhapString = ngayNhap.ToString("yyyy-MM-dd HH:mm:ss");
                string ngayXuatString = ngayXuat.ToString("yyyy-MM-dd HH:mm:ss");
                // Gọi hàm để lấy báo cáo
                DataTable baoCaoTable = tonkho.GetBaoCaoTonKho(ngayNhap, ngayXuat);

                // Hiển thị dữ liệu trên DataGridView
                if (baoCaoTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = baoCaoTable;
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
