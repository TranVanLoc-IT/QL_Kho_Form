using AutoMapper;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.Core.Base;
using MWarehouse.Core.Constant;
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
    public class GoodsReceiptDetailService : IGoodsReceiptDetailService
    {
        private readonly IUnitOfWork _iuow;
        private readonly IMapper _mapper;

        public GoodsReceiptDetailService(IUnitOfWork iuow, IMapper mapper)
        {
            _iuow = iuow;
            _mapper = mapper;
        }

        public async Task CreateAsync(IEnumerable<CreateGoodsReceiptDetailModel> obj)
        {
            foreach (var item in obj)
            {
                if(obj == null)
                {
                    throw new ErrorException((int)ErrorCode.Code.OBJECT_NULL, ErrorCode.Code.OBJECT_NULL.ToString(), "Dữ liệu đối tượng không có !");
                }

                TblXnkNhapKhoRawDatum newReceipt = _iuow.GetRepository<TblXnkNhapKhoRawDatum>().Entities.Where(u => u.AutoId == item.AutoId).FirstOrDefault()!;
                if (newReceipt is null)
                {
                    throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
                }
                newReceipt = _mapper.Map<TblXnkNhapKhoRawDatum>(obj);
                await _iuow.GetRepository<TblXnkNhapKhoRawDatum>().InsertAsync(newReceipt);
                await _iuow.SaveAsync();
            }
        }

        public async Task<IEnumerable<ResponseGoodsReceiptDetailModel>> GetAllAsync(int code)
        {
            var data = await _iuow.GetRepository<TblXnkNhapKhoRawDatum>().GetAllAsync();

            IEnumerable<ResponseGoodsReceiptDetailModel> result = _mapper.Map<IEnumerable<ResponseGoodsReceiptDetailModel>>(data.Where(r => r.NhapKhoId == code));
            return result;
        }
    }
}
