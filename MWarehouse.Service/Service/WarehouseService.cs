using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.Core.Constant;
using MWarehouse.ModelViews.WarehouseModelViews;
using MWarehouse.Repository.Models;

namespace MWarehouse.Service.Service
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IUnitOfWork _iuow;
        private readonly IMapper _mapper;
        public WarehouseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._iuow = unitOfWork;
            this._mapper = mapper;
        }
        public async Task CreateAsync(CreateWarehouseModel obj)
        {
            if (obj == null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_NULL, ErrorCode.Code.OBJECT_NULL.ToString(), "Dữ liệu đối tượng không có !");
            }
            TblDmKho newWarehouse = _iuow.GetRepository<TblDmKho>().Entities.Where(u => u.AutoId == obj.AutoId).FirstOrDefault()!;
            if (newWarehouse is null)
            {
                throw new ErrorException((int)ErrorCode.Code.OBJECT_EXISTED, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng đã có !");
            }
            newWarehouse = _mapper.Map<TblDmKho>(obj);
            await _iuow.GetRepository<TblDmKho>().InsertAsync(newWarehouse);
            await _iuow.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TblDmKho delWarehouse = _iuow.GetRepository<TblDmKho>().Entities.Where(u => u.AutoId == id).FirstOrDefault()
                                    ?? throw new ErrorException((int)ErrorCode.Code.NOT_FOUND, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng không có!");
            await _iuow.GetRepository<TblDmKho>().DeleteAsync(delWarehouse);
            await _iuow.SaveAsync();
        }

        public async Task<IEnumerable<ResponseWarehouseModel>> GetAllAsync()
        {
            IEnumerable<ResponseWarehouseModel> result = _mapper.Map<IEnumerable<ResponseWarehouseModel>>(await _iuow.GetRepository<TblDmKho>().GetAllAsync());
            return result;
        }

        public async Task<ResponseWarehouseModel> GetByIDAsync(int code)
        {
            ResponseWarehouseModel result = _mapper.Map<ResponseWarehouseModel>(await _iuow.GetRepository<TblDmKho>().Entities.Where(r => r.AutoId == code).FirstAsync());
            return result;
        }

        public async Task UpdateAsync(int id, ResponseWarehouseModel obj)
        {
            TblDmKho warehouse = _iuow.GetRepository<TblDmKho>().Entities.Where(u => u.AutoId == id).FirstOrDefault()
                                   ?? throw new ErrorException((int)ErrorCode.Code.NOT_FOUND, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng không có!");
            warehouse.AutoId = obj.AutoId;
            warehouse.TenKho = obj.TenKho;
            warehouse.GhiChu = obj.GhiChu;
            
            await _iuow.GetRepository<TblDmKho>().UpdateAsync(warehouse);
            await _iuow.SaveAsync();
        }
    }
}
