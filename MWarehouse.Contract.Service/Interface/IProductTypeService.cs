using MWarehouse.Core.Base;
using MWarehouse.ModelViews.ProductTypeModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Contract.Service.Interface
{
    public interface IProductTypeService
    {
        // async
        Task<BasePaginatedList<ResponseProductTypeModel>> GetAsync(string? id, string? name, string? code, int index, int pageSize);
        Task CreateAsync(ResponseProductTypeModel obj);
        Task UpdateAsync(string id, ResponseProductTypeModel obj);
        Task DeleteAsync(string id);
    }
}
