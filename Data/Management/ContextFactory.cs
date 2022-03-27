using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using WalletAPI.Helpers;
using WalletAPI.Configuration.Settings;
using WalletAPI.Configuration.DatabaseTypes;

namespace WalletAPI.Data.Management
{
    /// <summary>
    /// Entity Framework context service
    /// (Switches the db context according to tenant id field)
    /// </summary>
    /// <seealso cref="IContextFactory"/>
    public class ContextFactory : IContextFactory
    {
        private readonly IOptions<ConnectionSettings> connectionOptions;

        public ContextFactory(
            IOptions<ConnectionSettings> connectionOptions,
            IDatabaseType databaseType
            )
        {
            this.connectionOptions = connectionOptions;
        }

        /// <inheritdoc />
        public IDbContext DbContext => new DeviceContext(connectionOptions.Value.DefaultConnection);
    }
}
