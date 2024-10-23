using MWarehouse.Core.Base;
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
        Task<BasePaginatedList<ResponseProductModel>> GetAsync(string? id, string? name, string? code, int index, int pageSize);
        Task CreateAsync(ResponseProductModel obj);
        Task UpdateAsync(string id, ResponseProductModel obj);
        Task DeleteAsync(string id);
    }
}
