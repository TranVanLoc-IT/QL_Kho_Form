using AutoMapper;
using MWarehouse.ModelViews.GoodsReceiptDetailModelViews;
using MWarehouse.ModelViews.GoodsReceiptModelDetailViews;
using MWarehouse.ModelViews.GoodsReceiptModelViews;
using MWarehouse.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWarehouse.Service.MapperProfile
{
    public class GoodsReceiptDetailProfileMapper : Profile
    {
        public GoodsReceiptDetailProfileMapper()
        {
            // Mapper qua lại
            CreateMap<CreateGoodsReceiptDetailModel, TblXnkNhapKhoRawDatum>().ReverseMap();
            CreateMap<ResponseGoodsReceiptDetailModel, TblXnkNhapKhoRawDatum>().ReverseMap();
        }
    }
}
