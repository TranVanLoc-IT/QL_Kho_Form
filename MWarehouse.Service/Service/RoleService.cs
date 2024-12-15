﻿using Microsoft.EntityFrameworkCore;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.ModelViews.LoginModelView;
using MWarehouse.ModelViews.RoleModelView;
using MWarehouse.Repository.Models;
using System.Data;

namespace MWarehouse.Service.Service
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _iuow;

        public RoleService(IUnitOfWork iuow)
        {
            _iuow = iuow;
        }

        /// <summary>
        ///     Lấy toàn bộ màn hình
        /// </summary>
        /// <returns></returns>
        public async Task<List<ManHinhView>> DsManHinh()
        {
            List<ManHinhView> manHinhs = await _iuow.GetRepository<DmManHinh>().Entities.Select(r => new ManHinhView()
            {
                MaMH = r.MaManHinh,
                TenMH = r.TenManHinh
            }).ToListAsync();
            return manHinhs;
        }

        /// <summary>
        ///     Lấy danh sách nhóm người dùng
        /// </summary>
        /// <returns></returns>
        public async Task<List<GroupRoleModelView>> DsRole()
        {
            var nhomNguoiDung = _iuow.GetRepository<QlNhomNguoiDung>().Entities.Where(r => r.IsDeleted == false)
                                    .Select(r => new
                                    {
                                        r.TenNhom,
                                        r.GhiChu,
                                        r.MaNhom
                                    })
                                    .ToList(); 

            var manHinhs = nhomNguoiDung.Select(r => new GroupRoleModelView
            {
                GroupId = r.MaNhom,
                GroupUser = r.TenNhom,
                Decsription = r.GhiChu
            }).ToList();

            return manHinhs;

        }

        /// <summary>
        ///     Lấy màn hình đang cho phép truy cập theo nhóm
        /// </summary>
        /// <param name="maNhom"></param>
        /// <returns></returns>
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

        /// <summary>
        ///     Lấy toàn bộ người dùng và nhóm quyền hoạt động
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserRoleModelView>> GetUsers()
        {
            List<UserRoleModelView> users = await _iuow.GetRepository<QlNguoiDung>().Entities.Where(us => us.IsDeleted == false && us.TenDangNhap != "admin").
                                                   Select(us => new UserRoleModelView
                                                   {
                                                       User = us.TenDangNhap,
                                                       GroupUser = _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().Entities.Where(e => e.TenDangNhap == us.TenDangNhap && e.IsDeleted == false).Select(r => r.MaNhomNguoiDung).FirstOrDefault() ?? "Không có quyền",
                                                       Decsription = "",
                                                       Email = us.Email ?? ""
                                                   }).ToListAsync();
            return users;
        }

        /// <summary>
        ///     Lấy người dùng để quản lí 
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserModelView>> GetUserInfo()
        {
            List<UserModelView> users = await _iuow.GetRepository<QlNguoiDung>().Entities.Where(r => r.TenDangNhap != "admin" && r.IsDeleted == false).Select(r => new UserModelView()
            {
                TenDangNhap = r.TenDangNhap,
                Email=r.Email ?? "",
                TrangThai = r.TrangThai
            }).ToListAsync();
            return users;
        }

        /// <summary>
        ///     Thêm màn hình truy cập cho nhóm
        /// </summary>
        /// <param name="maNhom"></param>
        /// <param name="maMh"></param>
        /// <returns></returns>
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
        /// <summary>
        ///     Xóa màn hình truy cập của nhóm
        /// </summary>
        /// <param name="maNhom"></param>
        /// <param name="maMh"></param>
        /// <returns></returns>
        public async Task DeleteMHFromGroupRole(string maNhom, string maMh)
        {
            QlPhanQuyen pq = await _iuow.GetRepository<QlPhanQuyen>().Entities.Where(r => r.MaManHinh == maMh && r.MaNhomNguoiDung == maNhom).FirstOrDefaultAsync(); ;
            pq.CoQuyen = 0;
            await _iuow.GetRepository<QlPhanQuyen>().UpdateAsync(pq);
            await _iuow.GetRepository<QlPhanQuyen>().SaveAsync();
        }

        /// <summary>
        ///     Xóa quyền người dùng
        /// </summary>
        /// <param name="user"></param>
        /// <param name="role"></param>
        /// <returns></returns>
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

        /// <summary>
        ///     Cập nhật quyền người dùng
        /// </summary>
        /// <param name="user"></param>
        /// <param name="oldRole"></param>
        /// <param name="newRole"></param>
        /// <returns></returns>
        public async Task UpdateUserRole(string user, string oldRole, string newRole)
        {
            
            QlNguoiDungNhomNguoiDung? pq = await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().Entities
                                          .Where(r => r.TenDangNhap == user &&
                                          r.MaNhomNguoiDung == oldRole
                                          ).FirstOrDefaultAsync();

            QlNguoiDungNhomNguoiDung? hasNewRole = await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().Entities
                                          .Where(r => r.TenDangNhap == user &&
                                          r.MaNhomNguoiDung == newRole
                                          ).FirstOrDefaultAsync();
            if(pq != null)
            {
                pq.IsDeleted = true;
                await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().UpdateAsync(pq);
            }
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
            await _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().SaveAsync();
        }

        /// <summary>
        ///     Lấy thông tin các quyền
        /// </summary>
        /// <returns></returns>
        public async Task<List<RoleView>> Roles()
        {
            List<RoleView> manHinhs = await _iuow.GetRepository<QlNhomNguoiDung>().Entities.Where(r=>r.IsDeleted==false).Select(r => new RoleView()
            {
                TenQuyen = r.TenNhom,
                MaQuyen = r.MaNhom
            }).ToListAsync();
            return manHinhs;
        }

        /// <summary>
        ///     Tạo mới nhóm người dùng
        /// </summary>
        /// <param name="manhom"></param>
        /// <param name="name"></param>
        /// <param name="ghichu"></param>
        /// <returns></returns>
        public async Task<string> CreateNewGroupUser(string manhom, string name, string ghichu)
        {

            // check user existed
            QlNhomNguoiDung newGroup = await _iuow.GetRepository<QlNhomNguoiDung>().Entities.Where(r => r.TenNhom.Equals(name) && r.IsDeleted==false).FirstOrDefaultAsync();
            if (newGroup != null)
            {
                return "Đã có nhóm người dùng này !";
            }
            newGroup = new QlNhomNguoiDung();
            newGroup.MaNhom = manhom;
            newGroup.TenNhom = name;
            newGroup.GhiChu = ghichu;

            await _iuow.GetRepository<QlNhomNguoiDung>().InsertAsync(newGroup);
            await _iuow.GetRepository<QlNhomNguoiDung>().SaveAsync();
            return "Tạo thành công nhóm !";

        }
        public async Task<string> DeleteGroupUser(string name)
        {
            // check user existed
            QlNhomNguoiDung oldGroup = await _iuow.GetRepository<QlNhomNguoiDung>().Entities.Where(r => r.TenNhom.Equals(name)).FirstOrDefaultAsync();
            if (oldGroup == null)
            {
                return "Chưa có nhóm người dùng này !";
            }
            oldGroup.IsDeleted = true;
            await _iuow.GetRepository<QlNhomNguoiDung>().UpdateAsync(oldGroup);
            await _iuow.GetRepository<QlNhomNguoiDung>().SaveAsync();
            return "Xóa thành công nhóm !";

        }

        /// <summary>
        ///     Xóa người dùng
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<string> DeleteUser(string name)
        {
            // check user existed
            QlNguoiDung user = await _iuow.GetRepository<QlNguoiDung>().Entities.Where(r => r.TenDangNhap.Equals(name)).FirstOrDefaultAsync();
            if(user == null)
            {
                return "Không thấy người dùng !";
            }
            user.IsDeleted = true;

            await _iuow.GetRepository<QlNguoiDung>().UpdateAsync(user);
            await _iuow.GetRepository<QlNguoiDung>().SaveAsync();
            return "Xóa thành công!";

        }

        /// <summary>
        ///     Tạo mới người dùng
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public async Task<string> CreateNewUser(EditUserModel u)
        {
            // check user existed
            QlNguoiDung user = await _iuow.GetRepository<QlNguoiDung>().Entities.Where(r => r.TenDangNhap.Equals(u.Name)).FirstOrDefaultAsync();
            if (user != null)
            {
                return "Đã có người dùng này !";
            }
            // check user existed
            user = new QlNguoiDung();
            user.TenDangNhap = u.Name;
            user.MatKhau = u.Pass;
            user.Email = u.Mail;
            user.TrangThai = u.Status;

            await _iuow.GetRepository<QlNguoiDung>().InsertAsync(user);
            await _iuow.GetRepository<QlNguoiDung>().SaveAsync();
            return "Tạo thành công !";
        }

        /// <summary>
        ///     Cập nhật: khóa, mở, password người dùng
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public async Task<string> UpdateUser(EditUserModel u)
        {
            // check user existed
            QlNguoiDung user = await _iuow.GetRepository<QlNguoiDung>().Entities.Where(r => r.TenDangNhap.Equals(u.Name)).FirstOrDefaultAsync();
            if (user == null)
            {
                return "Không có người dùng này !";
            }
            // check user existed

            user.Email = u.Mail;
            user.TrangThai = u.Status;
            if (!string.IsNullOrEmpty(u.Pass))
            {
                user.MatKhau = u.Pass;
            }

            await _iuow.GetRepository<QlNguoiDung>().UpdateAsync(user);
            await _iuow.GetRepository<QlNguoiDung>().SaveAsync();
            return "Cập nhật thành công !";
        }
    }
}
