using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Repository.Models;
using System.Configuration;
using UI.Controls;
using UI.Layouts;

namespace UI
{
    // expand class DI
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection service)
        {
            // Thêm cấu hình cho DbContext QlKhoContext
            service.AddDbContext<QlKhoContext>(options =>
                options.UseSqlServer("Server=MSI;Database=QL_Kho;Trusted_Connection=True;TrustServerCertificate=True;"));

            AddControlService(service);
        }

        private static void AddControlService(this IServiceCollection services)
        {
            services.AddScoped<UnitControl>();
            services.AddScoped<HomeControl>();
            services.AddScoped<ProductControl>();
            services.AddScoped<SupplierControl>();
            services.AddScoped<AIControl>();
            services.AddScoped<ExportViewControl>();
            services.AddScoped<ProductTypeControl>();
            services.AddScoped<GoodsReceiptControl>();

            // Register LayoutForm with DI and pass the control names you want
            services.AddScoped(provider => new LayoutForm(
                provider.GetRequiredService<UnitControl>(),
                provider.GetRequiredService<HomeControl>(),
                provider.GetRequiredService<ProductControl>(),
                provider.GetRequiredService<SupplierControl>(),
                provider.GetRequiredService<AIControl>(),
                provider.GetRequiredService<ExportViewControl>(),
                provider.GetRequiredService<ProductTypeControl>(),
                provider.GetRequiredService<GoodsReceiptControl>(),
                provider.GetRequiredService<ILoginService>()
            ));
        }
    }
}
