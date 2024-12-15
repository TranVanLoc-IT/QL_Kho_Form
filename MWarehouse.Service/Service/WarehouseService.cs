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
        /// <summary>
        ///     Tạo kho
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception>
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

        /// <summary>
        ///     Xóa kho
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception>
        public async Task DeleteAsync(int id)
        {
            TblDmKho delWarehouse = _iuow.GetRepository<TblDmKho>().Entities.Where(u => u.AutoId == id).FirstOrDefault()
                                    ?? throw new ErrorException((int)ErrorCode.Code.NOT_FOUND, ErrorCode.Code.OBJECT_EXISTED.ToString(), "Dữ liệu đối tượng không có!");
            delWarehouse.IsDeleted = true;
            await _iuow.GetRepository<TblDmKho>().UpdateAsync(delWarehouse);
            await _iuow.SaveAsync();
        }

        /// <summary>
        ///     Lấy toàn bộ kho
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ResponseWarehouseModel>> GetAllAsync()
        {
            IEnumerable<ResponseWarehouseModel> result = _mapper.Map<IEnumerable<ResponseWarehouseModel>>(await _iuow.GetRepository<TblDmKho>().Entities.Where(r=> r.IsDeleted==false).ToListAsync());
            return result;
        }

        /// <summary>
        ///     Lấy kho theo id
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<ResponseWarehouseModel> GetByIDAsync(int code)
        {
            ResponseWarehouseModel result = _mapper.Map<ResponseWarehouseModel>(await _iuow.GetRepository<TblDmKho>().Entities.Where(r => r.AutoId == code).FirstAsync());
            return result;
        }

        /// <summary>
        ///     Cập nhật kho
        /// </summary>
        /// <param name="id"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception>
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
