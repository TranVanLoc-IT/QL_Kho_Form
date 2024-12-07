using MWarehouse.Core.Base;
using MWarehouse.ModelViews.GoodsReceiptModelViews;
using MWarehouse.ModelViews.ProductModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Contract.Service.Interface
{
    public interface IProductService
    {
        // async
        Task CreateAsync(CreateProductModel obj);
        Task UpdateAsync(string id, UpdateProductModel obj);
        Task UpdateUnitAsync(int id, int[] obj);
        Task DeleteAsync(int id);
        Task<IEnumerable<ResponseProductModel>> GetAllAsync();
        Task<ResponseProductModel> GetByIdAsync(int id);
    }
}
