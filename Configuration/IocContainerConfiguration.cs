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
            services.AddTransient<IContextFactory, ContextFactory>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            

            services.AddScoped(typeof(IGenericService<AccountViewModel>), typeof(AccountService<AccountViewModel>));
            services.AddScoped(typeof(IGenericService<PaymentMasterViewModel>), typeof(PaymentMasterService<PaymentMasterViewModel>));
            services.AddScoped(typeof(IGenericService<TransactionLogMasterViewModel>), typeof(TransactionLogMasterService<TransactionLogMasterViewModel>));
            services.AddScoped(typeof(IGenericService<WalletViewModel>), typeof(WalletService<WalletViewModel>));


        }
    }
}