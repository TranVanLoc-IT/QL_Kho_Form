using AutoMapper;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.Core.Constant;
using MWarehouse.ModelViews.ProductModelViews;
using MWarehouse.ModelViews.UnitModelViews;
using MWarehouse.Repository.Models;
using System.Collections.Generic;

namespace MWarehouse.Service.Service
{
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _iuow;
        private readonly IMapper _mapper;

        public UnitService(IUnitOfWork iuow, IMapper mapper)
        {
            _iuow = iuow;
            _mapper = mapper;
        }
        public async Task CreateAsync(CreateUnitModel obj)
        {
            if(obj == null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_NULL, ErrorCode.Code.OBJECT_NULL.ToString(), "Dữ liệu đối tượng không có !");
            }
            TblDmDonViTinh newUnit = _iuow.GetRepository<TblDmDonViTinh>().Entities.Where(u => u.AutoId == obj.AutoId).FirstOrDefault()!;
            if(newUnit != null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            }
            newUnit = _mapper.Map<TblDmDonViTinh>(obj);
            newUnit.MaDvt = newUnit.TenDvt.ToUpper();
            await _iuow.GetRepository<TblDmDonViTinh>().InsertAsync(newUnit);
            await _iuow.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TblDmDonViTinh delUnit = _iuow.GetRepository<TblDmDonViTinh>().Entities.Where(u => u.AutoId == id).FirstOrDefault()
                                    ?? throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            await _iuow.GetRepository<TblDmDonViTinh>().DeleteAsync(delUnit);
            await _iuow.SaveAsync();
        }

        public async Task<IEnumerable<ResponseUnitModel>> GetAllAsync()
        {
            IEnumerable<ResponseUnitModel> result = _mapper.Map<IEnumerable<ResponseUnitModel>>(await _iuow.GetRepository<TblDmDonViTinh>().GetAllAsync());
            return result;
        }

        public async Task<IEnumerable<ResponseProductModel>> GetAllProductAsync(int code)
        {
            IEnumerable<ResponseProductModel> result = _mapper.Map<IEnumerable<ResponseProductModel>>((await _iuow.GetRepository<TblDmSanPham>().GetAllAsync()).Where(r => r.DonViTinhId == code));
            return result;
        }
    }
}
