﻿using AutoMapper;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.Core.Constant;
using MWarehouse.ModelViews.GoodsReceiptDetailModelViews;
using MWarehouse.ModelViews.GoodsReceiptModelDetailViews;
using MWarehouse.ModelViews.GoodsReceiptModelViews;
using MWarehouse.ModelViews.UnitModelViews;
using MWarehouse.Repository.Models;

namespace MWarehouse.Service.Service
{
    public class ImportReceiptDetailService : IImportReceiptDetailService
    {
        private readonly IUnitOfWork _iuow;
        private readonly IMapper _mapper;

        public ImportReceiptDetailService(IUnitOfWork iuow, IMapper mapper)
        {
            _iuow = iuow;
            _mapper = mapper;
        }

        /// <summary>
        ///     Tạo mới
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception>
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

        /// <summary>
        ///     Lấy toàn bộ chi tiết của phiếu nhập
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ResponseGoodsReceiptDetailModel>> GetAllAsync(int code)
        {
            var data = await _iuow.GetRepository<TblXnkNhapKhoRawDatum>().GetAllAsync();

            IEnumerable<ResponseGoodsReceiptDetailModel> result = _mapper.Map<IEnumerable<ResponseGoodsReceiptDetailModel>>(data.Where(r => r.NhapKhoId == code));
            return result;
        }
    }
}
