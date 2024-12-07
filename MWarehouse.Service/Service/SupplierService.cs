using AutoMapper;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.Core.Base;
using MWarehouse.Core.Constant;
using MWarehouse.ModelViews.GoodsReceiptModelViews;
using MWarehouse.ModelViews.SupplierModelViews;
using MWarehouse.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Service.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _iuow;
        private readonly IMapper _mapper;

        public SupplierService(IUnitOfWork iuow, IMapper mapper)
        {
            _iuow = iuow;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateSupplierModel obj)
        {
            if (obj == null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_NULL, ErrorCode.Code.OBJECT_NULL.ToString(), "Dữ liệu đối tượng không có !");
            }
            
            TblDmNcc newSupplier = _iuow.GetRepository<TblDmNcc>().Entities.Where(u => u.AutoId == obj.AutoId).FirstOrDefault()!;
            if (newSupplier is null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            }
            newSupplier = _mapper.Map<TblDmNcc>(obj);

            newSupplier.AutoId = IDGenerator.GenerateID(3, await GetAllAsync(), r => r.AutoId);
            newSupplier.MaNcc = IDGenerator.Generate("NCC", 3);
            await _iuow.GetRepository<TblDmNcc>().InsertAsync(newSupplier);
            await _iuow.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TblDmNcc delSupplier = _iuow.GetRepository<TblDmNcc>().Entities.Where(u => u.AutoId == id).FirstOrDefault()
                                    ?? throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            await _iuow.GetRepository<TblDmNcc>().DeleteAsync(delSupplier);
            await _iuow.SaveAsync();
        }

        public async Task UpdateAsync(string id, UpdateSupplierModel obj)
        {
            if (obj == null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_NULL, ErrorCode.Code.OBJECT_NULL.ToString(), "Dữ liệu đối tượng không có !");
            }

            TblDmNcc newSupplier = _iuow.GetRepository<TblDmNcc>().Entities.Where(u => u.AutoId == obj.AutoId).FirstOrDefault()!;
            if (newSupplier is null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            }
            newSupplier = _mapper.Map<TblDmNcc>(obj);
            await _iuow.GetRepository<TblDmNcc>().UpdateAsync(newSupplier);
            await _iuow.SaveAsync();
        }

        public async Task<IEnumerable<ResponseSupplierModel>> GetAllAsync()
        {
            IEnumerable<ResponseSupplierModel> result = _mapper.Map<IEnumerable<ResponseSupplierModel>>(await _iuow.GetRepository<TblDmNcc>().GetAllAsync());
            return result;
        }

        public async Task<ResponseSupplierModel> GetByIdAsync(int id)
        {
            ResponseSupplierModel result = _mapper.Map<ResponseSupplierModel>(await _iuow.GetRepository<TblDmNcc>().GetByIdAsync(id));
            return result;
        }
    }
}
