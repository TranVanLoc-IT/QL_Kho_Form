using Microsoft.Data.SqlClient;
using MWarehouse.Contract.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Service.Service
{
    public class BC_Phieunhap
    {
        private readonly IUnitOfWork _iuow;
        public BC_Phieunhap(IUnitOfWork iuow)
        {
            _iuow = iuow;
        }

        /// <summary>
        ///     Lấy báo cáo phiếu nhập
        /// </summary>
        /// <param name="ngayNhap"></param>
        /// <param name="ngayXuat"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DataTable GetBCphieuNhap(DateTime ngayNhap, DateTime ngayXuat)
        {
            DataTable baoCaoTable = new DataTable();

            using (SqlConnection connection = new SqlConnection("Server=MSI;Database=QL_Kho;User Id=sa;Password=123456;Trust Server Certificate=True;"))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("[dbo].[sp_GetNhapKhoByDateRange]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho thủ tục
                        command.Parameters.Add(new SqlParameter("@DATEFROM", ngayNhap));
                        command.Parameters.Add(new SqlParameter("@DATETO", ngayXuat));

                        // Thực thi và lấy dữ liệu
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(baoCaoTable);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi khi lấy báo cáo phiếu nhập: {ex.Message}", ex);
                }
            }

            return baoCaoTable;
        }

    }
}
