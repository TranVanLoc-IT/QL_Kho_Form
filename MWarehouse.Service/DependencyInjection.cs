using Microsoft.Extensions.DependencyInjection;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Service.Service;
using System.Reflection;

namespace MWarehouse.Service
{
    public static class DependencyInjection
    {
        public static void AddMapperService(this IServiceCollection service)
        {
            // Scan code hiện tại, các lớp kế thừa từ Profile -> automapper từ profile easy hơn mà k cần thêm từng cái
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
        public static void AddModelViewService(this IServiceCollection services)
        {
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<IExcelExportService, ExcelExportService>();
            services.AddScoped<IWordExportService, WordExportService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IGoodsReceiptService, GoodsReceiptService>();
            services.AddScoped<IGoodsReceiptDetailService, GoodsReceiptDetailService>();
        }
    }
}
