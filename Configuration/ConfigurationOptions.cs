using WalletAPI.Configuration.Settings;
using WalletAPI.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WalletAPI.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConfigurationOptions
    {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureService(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<ConnectionSettings>(configuration.GetSection(Constants.ConnectionStrings));
            services.Configure<APIs>(configuration.GetSection(Constants.Services));
        }
    }
}