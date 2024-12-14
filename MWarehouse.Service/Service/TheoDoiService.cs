using Microsoft.EntityFrameworkCore;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.ModelViews.TheoDoi;
using MWarehouse.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Service.Service
{
    public class TheoDoiService : ITheoDoiService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TheoDoiService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<List<TheoDoiModelView>> GetAllAsync()
        {
            return await _unitOfWork.GetRepository<TheoDoi>().Entities.Where(r => r.IsDeleted == false).Select(r => new TheoDoiModelView()
            {
                TenDangNhap = r.TenDangNhap,
                TrangThai = r.TrangThai,
                NgayThucHien = r.NgayThucHien,
                Lenh=r.Lenh,
                ThongTin = r.ThongTin
            }).ToListAsync();
        }

        public async Task ResetAsync()
        {
            var data = await _unitOfWork.GetRepository<TheoDoi>().Entities.Where(r => r.IsDeleted == false).ToListAsync();
            foreach (var item in data)
            {
                item.IsDeleted = true;
                await _unitOfWork.GetRepository<TheoDoi>().UpdateAsync(item);
            }
            await _unitOfWork.GetRepository<TheoDoi>().SaveAsync();

        }
    }
}
