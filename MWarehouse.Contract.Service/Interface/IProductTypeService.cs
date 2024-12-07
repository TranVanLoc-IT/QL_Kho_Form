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
        Task<IEnumerable<ResponseProductTypeModel>> GetAllAsync();
        Task CreateAsync(CreateProductTypeModel obj);
        Task DeleteAsync(int id);
    }
}
