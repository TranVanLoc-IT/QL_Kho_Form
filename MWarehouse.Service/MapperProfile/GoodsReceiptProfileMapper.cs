using AutoMapper;
using MWarehouse.ModelViews.GoodsReceiptModelViews;
using MWarehouse.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Service.MapperProfile
{
    public class GoodsReceiptProfileMapper: Profile
    {
        public GoodsReceiptProfileMapper()
        {
            // Mapper qua lại
            CreateMap<CreateGoodsReceiptModel, TblXnkNhapKho>().ReverseMap();
            CreateMap<ResponseGoodsReceiptModel, TblXnkNhapKho>().ReverseMap();
        }
    }
}
