using UI.Layouts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using MWarehouse.Service;
using MWarehouse.Repository.DI;
using UI.CustomForm;
using UI.Controls;

namespace UI
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>,
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddApplication();
            serviceCollection.AddMapperService();
            serviceCollection.AddInfrastructure();
            serviceCollection.AddModelViewService();
            ServiceProvider = serviceCollection.BuildServiceProvider();
            Application.Run(ServiceProvider.GetRequiredService<Baocaotonkho>());
        }
    }
}