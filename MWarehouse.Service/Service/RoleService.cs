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

            var manHinhs = await (from pq in _iuow.GetRepository<QlPhanQuyen>().Entities
                                  join mh in _iuow.GetRepository<DmManHinh>().Entities
                                      on pq.MaManHinh equals mh.MaManHinh
                                  where pq.MaNhomNguoiDung == maNhom && pq.CoQuyen == 1
                                  select new ManHinhView
                                  {
                                      MaMH = pq.MaManHinh,
                                      TenMH = mh.TenManHinh
                                  }).AsNoTracking().ToListAsync();


            return manHinhs;

        }

        public async Task<List<UserRoleModelView>> GetUsers()
        {
            List<UserRoleModelView> users = await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().Entities.Where(r => r.TenDangNhap != "admin" && r.IsDeleted == false).Select(r => new UserRoleModelView()
            {
                User = r.TenDangNhap,
                GroupUser =  _iuow.GetRepository<QlNhomNguoiDung>().Entities.Where(e => e.MaNhom == r.MaNhomNguoiDung).Select(r => r.TenNhom).First(),
                Decsription = r.GhiChu

            }).ToListAsync();
            return users;
        }

        public async Task AddMhToGroupRole(string maNhom, string maMh)
        {
            QlPhanQuyen pq = await _iuow.GetRepository<QlPhanQuyen>().Entities.Where(r => r.MaManHinh == maMh && r.MaNhomNguoiDung == maNhom).FirstOrDefaultAsync();
            if(pq != null)
            {
                pq.CoQuyen = 1;
                await _iuow.GetRepository<QlPhanQuyen>().UpdateAsync(pq);
            }
            else
            {
                pq = new QlPhanQuyen();
                pq.MaNhomNguoiDung = maNhom;
                pq.MaManHinh = maMh;
                pq.CoQuyen = 1;
                await _iuow.GetRepository<QlPhanQuyen>().InsertAsync(pq);
            }
            await _iuow.GetRepository<QlPhanQuyen>().SaveAsync();
        }
        public async Task DeleteMHFromGroupRole(string maNhom, string maMh)
        {
            QlPhanQuyen pq = await _iuow.GetRepository<QlPhanQuyen>().Entities.Where(r => r.MaManHinh == maMh && r.MaNhomNguoiDung == maNhom).FirstOrDefaultAsync(); ;
            pq.CoQuyen = 0;
            await _iuow.GetRepository<QlPhanQuyen>().UpdateAsync(pq);
            await _iuow.GetRepository<QlPhanQuyen>().SaveAsync();
        }
        public async Task DeleteUserRole(string user, string role)
        {
            QlNguoiDungNhomNguoiDung pq = await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().Entities.Where(r => r.TenDangNhap == user && r.MaNhomNguoiDung == role).FirstAsync();
            pq.IsDeleted = true;

            QlNguoiDungNhomNguoiDung? hasDeleted = await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().Entities.Where(r => r.TenDangNhap == user && r.MaNhomNguoiDung == "0").FirstOrDefaultAsync();
                                                    
            if(hasDeleted != null)
            {
                // mo quyen bi xoa
                hasDeleted.IsDeleted = false;
                await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().UpdateAsync(hasDeleted);
            }
            else
            {
                hasDeleted = new QlNguoiDungNhomNguoiDung()
                            { TenDangNhap = user, MaNhomNguoiDung = "0" };
                await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().InsertAsync(hasDeleted);
            }
            await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().UpdateAsync(pq);
            await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().SaveAsync();
        }

        public async Task UpdateUserRole(string user, string oldRole, string newRole)
        {
            QlNguoiDungNhomNguoiDung pq = await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().Entities
                                          .Where(r => r.TenDangNhap == user &&
                                          r.MaNhomNguoiDung == oldRole
                                          ).FirstAsync();

            QlNguoiDungNhomNguoiDung? hasNewRole = await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().Entities
                                          .Where(r => r.TenDangNhap == user &&
                                          r.MaNhomNguoiDung == newRole
                                          ).FirstOrDefaultAsync();
            if(hasNewRole != null)
            {
                hasNewRole.IsDeleted = false;
                await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().UpdateAsync(hasNewRole);
            }
            else
            {
                hasNewRole = new QlNguoiDungNhomNguoiDung()
                {
                    TenDangNhap = user,
                    MaNhomNguoiDung = newRole
                };
                await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().InsertAsync(hasNewRole);
            }
            pq.IsDeleted = true;
            await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().UpdateAsync(pq);
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
