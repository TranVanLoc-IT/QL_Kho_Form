using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.ModelViews.RoleModelView;
using MWarehouse.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MWarehouse.Service.Service
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _iuow;

        public RoleService(IUnitOfWork iuow)
        {
            _iuow = iuow;
        }
        public async Task<List<ManHinhView>> DsManHinh()
        {
            List<ManHinhView> manHinhs = await _iuow.GetRepository<DmManHinh>().Entities.Select(r => new ManHinhView()
            {
                MaMH = r.MaManHinh,
                TenMH = r.TenManHinh
            }).ToListAsync();
            return manHinhs;
        }

        public async Task<List<GroupRoleModelView>> DsRole()
        {
            var nhomNguoiDung = _iuow.GetRepository<QlNhomNguoiDung>().Entities
                                    .Select(r => new
                                    {
                                        r.TenNhom,
                                        r.GhiChu,
                                        r.MaNhom
                                    })
                                    .ToList(); 

            var manHinhs = nhomNguoiDung.Select(r => new GroupRoleModelView
            {
                GroupUser = r.MaNhom,
                Decsription = r.GhiChu
            }).ToList();

            return manHinhs;

        }

        public async Task<List<ManHinhView>> GetMhActivating(string maNhom)
        {
            List<ManHinhView> manHinhs = _iuow.GetRepository<QlPhanQuyen>().Entities.Where(r => r.MaNhomNguoiDung == maNhom && r.CoQuyen == 1).Select(r => new ManHinhView()
            {
                MaMH = r.MaManHinh,
                TenMH = _iuow.GetRepository<DmManHinh>().Entities.Where(e => e.MaManHinh == r.MaManHinh).Select(r => r.TenManHinh).First()
            }).ToList();
            return manHinhs;
        }

        public async Task<List<UserRoleModelView>> GetUsers()
        {
            List<UserRoleModelView> manHinhs = await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().Entities.Where(r => r.TenDangNhap != "admin").Select(r => new UserRoleModelView()
            {
                User = r.TenDangNhap,
                GroupUser = _iuow.GetRepository<QlNhomNguoiDung>().Entities.Where(e => e.MaNhom == r.MaNhomNguoiDung).Select(r => r.TenNhom).First(),
                Decsription = r.GhiChu

            }).ToListAsync();
            return manHinhs;
        }

        public async Task AddMhToGroupRole(string maNhom, string maMh)
        {
            QlPhanQuyen pq = new QlPhanQuyen();
            pq.MaManHinh = maMh;
            pq.MaNhomNguoiDung = maNhom;
            pq.CoQuyen = 1;

            await _iuow.GetRepository<QlPhanQuyen>().InsertAsync(pq);
            await _iuow.GetRepository<QlPhanQuyen>().SaveAsync();
        }
        public async Task DeleteMHFromGroupRole(string maNhom, string maMh)
        {
            QlPhanQuyen pq = await _iuow.GetRepository<QlPhanQuyen>().Entities.Where(r => r.MaManHinh == maMh && r.MaNhomNguoiDung == maNhom).FirstAsync(); ;
            pq.CoQuyen = 0;
            await _iuow.GetRepository<QlPhanQuyen>().UpdateAsync(pq);
            await _iuow.GetRepository<QlPhanQuyen>().SaveAsync();
        }
        public async Task DeleteUserRole(string user, string role)
        {
            QlNguoiDungNhomNguoiDung pq = await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().Entities.Where(r => r.TenDangNhap == user && r.MaNhomNguoiDung == role).FirstAsync();
            pq.IsDeleted = true;
            await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().UpdateAsync(pq);
            await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().SaveAsync();
        }

        public async Task UpdateUserRole(string user, string role)
        {
            QlNguoiDungNhomNguoiDung pq = await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().Entities.Where(r => r.TenDangNhap == user && r.MaNhomNguoiDung == role).FirstOrDefaultAsync() ?? new QlNguoiDungNhomNguoiDung() { MaNhomNguoiDung = role, TenDangNhap = user };
            if (pq != null)
            {
                pq.IsDeleted = true;
                await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().UpdateAsync(pq);
                await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().SaveAsync();
                return;
            }
            await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().InsertAsync(pq);
            await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().SaveAsync();
        }

        public async Task<List<RoleView>> Roles()
        {
            List<RoleView> manHinhs = await _iuow.GetRepository<QlNhomNguoiDung>().Entities.Select(r => new RoleView()
            {
                TenQuyen = r.TenNhom,
                MaQuyen = r.MaNhom
            }).ToListAsync();
            return manHinhs;
        }
    }
}
