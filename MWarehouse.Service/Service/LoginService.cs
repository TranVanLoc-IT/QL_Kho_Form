using Microsoft.EntityFrameworkCore;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Core;
using MWarehouse.Core.Constant;
using MWarehouse.ModelViews.LoginModelView;
using MWarehouse.Repository.Models;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Service.Service
{
    public class LoginService:ILoginService
    {
        private readonly IUnitOfWork _iuow;

        private static string _user;
        public LoginService(IUnitOfWork iuow)
        {
            this._iuow = iuow;
        }

        public string GetCurrentuser()
        {
            return _user ?? throw new ErrorException((int)ErrorCode.Code.NOT_FOUND, ErrorCode.Code.NOT_FOUND.ToString(), "Không có người dùng nào");
        }

        /// <summary>
        ///     Handle login , success => form array <> throw exception
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        /// <exception cref="ErrorException"></exception>
        public string[] HandleLoginRequest(LoginModel login)
        {
            QlNguoiDung user = _iuow.GetRepository<QlNguoiDung>().Entities
                .Where(u => u.MatKhau == login.MatKhau && 
                            u.TenDangNhap == login.TenDangNhap && u.TrangThai == 1).FirstOrDefault() ?? throw new ErrorException((int)ErrorCode.Code.NOT_FOUND, ErrorCode.Code.NOT_FOUND.ToString(), "Không có người dùng nào");
            _user = user.TenDangNhap;
            string[] forms = (from mh in _iuow.GetRepository<DmManHinh>().Entities
                             join q in _iuow.GetRepository<QlPhanQuyen>().Entities
                             on mh.MaManHinh equals q.MaManHinh
                             join nnd in _iuow.GetRepository<QlNhomNguoiDung>().Entities
                             on q.MaNhomNguoiDung equals nnd.MaNhom
                             join b in _iuow.GetRepository<QlNguoiDungNhomNguoiDung>().Entities
                             on q.MaNhomNguoiDung equals b.MaNhomNguoiDung
                             where b.TenDangNhap == user.TenDangNhap
                             select mh.MaManHinh).ToArray();

            return forms;
        }
    }
}
