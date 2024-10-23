using MWarehouse.ModelViews.GoodsReceptModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MWarehouse.Core.Base;
namespace MWarehouse.Contract.Service.Interface
{
    public interface IGoodsReceptService
    {
        // async
        Task<BasePaginatedList<ResponseGoodsReceiptModel>> GetAsync(string? id, string? name, string? code, int index, int pageSize);
        Task CreateAsync(ResponseGoodsReceiptModel obj);
        Task UpdateAsync(string id, ResponseGoodsReceiptModel obj);
        Task DeleteAsync(string id);
    }
}
