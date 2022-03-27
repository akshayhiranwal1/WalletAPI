using WalletAPI.Common.HttpRequestClient;
using WalletAPI.Data.Management;
using WalletAPI.Repository;
using WalletAPI.Services;
using WalletAPI.Services.Generic;
using WalletAPI.Services.Implementation;
using WalletAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WalletAPI.Configuration
{
    /// <summary>
    /// IOC contaner start-up configuration
    /// </summary>
    public static class IocContainerConfiguration
    {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureService(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped<IDeviceViewModelValidationRules, DeviceViewModelValidationRules>();
            //services.AddTransient<IDeviceValidationService, DeviceValidationService>();
            services.AddTransient<IDataBaseManager, DataBaseManager>();
            services.AddTransient<IContextFactory, ContextFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            

            //services.AddScoped(typeof(IGenericService<WorkFlowMasterViewModel>), typeof(WorkFlowMasterService<WorkFlowMasterViewModel>));
            //API Calling
            services.AddTransient<IRequestClient, RequestClient>();

            
        }
    }
}