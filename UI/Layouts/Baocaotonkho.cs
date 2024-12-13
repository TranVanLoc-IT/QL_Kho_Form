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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI.Layouts
{
    public partial class Baocaotonkho : Form
    {
        private readonly ILoginService _loginService;
        private readonly Tonkho tonkho;
        private readonly BC_Phieunhap bcpn;
        private readonly BC_PHIEUXUAT bC_PHIEUXUAT;
        public Baocaotonkho()
        {
            InitializeComponent();
            tonkho = new Tonkho(null);
            bcpn = new BC_Phieunhap(null);
            bC_PHIEUXUAT = new BC_PHIEUXUAT(null);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string formattedDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            string formattedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ngày nhập và ngày xuất từ giao diện
                DateTime ngayNhap = dateTimePicker1.Value;
                DateTime ngayXuat = dateTimePicker2.Value;
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ngày nhập và ngày xuất từ giao diện
                DateTime ngayNhap = dateTimePicker1.Value;
                DateTime ngayXuat = dateTimePicker2.Value;

                // Gọi hàm để lấy báo cáo
                DataTable bcpntable = bcpn.GetBCphieuNhap(ngayNhap, ngayXuat);

                // Hiển thị dữ liệu trên DataGridView
                if (bcpntable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = bcpntable;
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ngày nhập và ngày xuất từ giao diện
                DateTime ngayNhap = dateTimePicker1.Value;
                DateTime ngayXuat = dateTimePicker2.Value;

                // Gọi hàm để lấy báo cáo
                DataTable bcxuat = bC_PHIEUXUAT.GetBCphieuXuat(ngayNhap, ngayXuat);

                // Hiển thị dữ liệu trên DataGridView
                if (bcxuat.Rows.Count > 0)
                {
                    dataGridView1.DataSource = bcxuat;
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
