using AutoMapper;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.Core.Base;
using MWarehouse.Core.Constant;
using MWarehouse.ModelViews.ExportReceiptDetailModelView;
using MWarehouse.ModelViews.GoodsReceiptDetailModelViews;
using MWarehouse.ModelViews.GoodsReceiptModelDetailViews;
using MWarehouse.ModelViews.GoodsReceiptModelViews;
using MWarehouse.ModelViews.UnitModelViews;
using MWarehouse.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Service.Service
{
    public class ExportReceiptDetailService : IExportReceiptDetailService
    {
        private readonly IUnitOfWork _iuow;
        private readonly IMapper _mapper;

        public ExportReceiptDetailService(IUnitOfWork iuow, IMapper mapper)
        {
            _iuow = iuow;
            _mapper = mapper;
        }
        /// <summary>
        ///     Lấy toàn bộ chi tiết của phiếu xuất
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ResponseExportReceiptDetailModel>> GetDetailAsync(int code)
        {
            var data = await _iuow.GetRepository<TblXnkXuatKhoRawDatum>().GetAllAsync();

            IEnumerable<ResponseExportReceiptDetailModel> result = _mapper.Map<IEnumerable<ResponseExportReceiptDetailModel>>(data.Where(r => r.XuatKhoId == code));
            return result;
        }
    }
}
