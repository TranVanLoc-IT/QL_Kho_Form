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
    public class Tonkho
    {
      

        private readonly IUnitOfWork _iuow;

        
        public Tonkho(IUnitOfWork iuow)
        {
            _iuow = iuow;
        }

        public DataTable GetBaoCaoTonKho(DateTime ngayNhap, DateTime ngayXuat)
        {
            DataTable baoCaoTable = new DataTable();

            using (SqlConnection connection = new SqlConnection("Server=KIETBANHTRAI\\SQLEXPRESS;Database=QL_Kho;User Id=sa;Password=123;Trust Server Certificate=True;"))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("[dbo].[BaoCaoTonKho]", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho thủ tục
                        command.Parameters.Add(new SqlParameter("@NgayNhap", SqlDbType.DateTime) { Value = ngayNhap });
                        command.Parameters.Add(new SqlParameter("@NgayXuat", SqlDbType.DateTime) { Value = ngayXuat });

                        // Thực thi và lấy dữ liệu
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(baoCaoTable);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Lỗi khi lấy báo cáo tồn kho: {ex.Message}", ex);
                }
            }

            return baoCaoTable;
        }
    }
}
