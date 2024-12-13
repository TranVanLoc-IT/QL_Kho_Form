using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MWarehouse.Contract.Repository.Interface;
using MWarehouse.Contract.Service.Interface;
using MWarehouse.Repository.Models;
using System.Configuration;
using UI.Controls;
using UI.Controls.UCButton;
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
                //options.UseSqlServer("Server=MSI;Database=QL_Kho;Trusted_Connection=True;TrustServerCertificate=True;"));
            options.UseSqlServer("Server=DESKTOP-QBTN8I9\\SQLEXPRESS;Database=QL_Kho;Trusted_Connection=True;TrustServerCertificate=True;"));

            AddControlService(service);
        }

        private static void AddControlService(this IServiceCollection services)
        {
            services.AddScoped<AIControl>();
            services.AddScoped<UserRoleControl>();
            services.AddScoped<GroupRoleControl>();
            services.AddScoped<ConfirmReportBCTK>();
            services.AddScoped<ConfirmImportControl>();
            services.AddScoped<ReportExportControl>();
            services.AddScoped<ReportImportControl>();
            services.AddScoped<Baocaotonkho>();
      
            // Register LayoutForm with DI and pass the control names you want
            services.AddTransient(provider => new LayoutForm(
                provider.GetRequiredService<AIControl>(),
                provider.GetRequiredService<UserRoleControl>(),
                provider.GetRequiredService<GroupRoleControl>(),
                provider.GetRequiredService<ConfirmImportControl>(),
                provider.GetRequiredService<ConfirmReportBCTK>(),
                provider.GetRequiredService<ReportExportControl>(),
                provider.GetRequiredService<ReportImportControl>(),
                provider.GetRequiredService<ILoginService>()
            ));
        }
    }
}
