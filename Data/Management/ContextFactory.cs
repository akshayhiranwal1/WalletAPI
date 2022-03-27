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
        private const string TenantIdFieldName = Constants.TenantId;
        private const string DatabaseFieldKeyword = Constants.Database;

        private readonly HttpContext httpContext;

        private readonly IOptions<ConnectionSettings> connectionOptions;

        private readonly IDataBaseManager dataBaseManager;

        private readonly IDatabaseType databaseType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextFactory"/> class.
        /// </summary>
        /// <param name="httpContentAccessor">The HTTP content accessor.</param>
        /// <param name="connectionOptions">The connection options.</param>
        /// <param name="dataBaseManager">The data base manager.</param>
        /// <param name="databaseType"></param>
        public ContextFactory(
            IHttpContextAccessor httpContentAccessor,
            IOptions<ConnectionSettings> connectionOptions,
            IDataBaseManager dataBaseManager,
            IDatabaseType databaseType
            )
        {
            httpContext = httpContentAccessor.HttpContext;
            this.connectionOptions = connectionOptions;
            this.dataBaseManager = dataBaseManager;
            this.databaseType = databaseType;
        }

        /// <inheritdoc />
        public IDbContext DbContext => new DeviceContext(connectionOptions.Value.DefaultConnection);

        private DbContextOptionsBuilder<DeviceContext> ChangeDatabaseNameInConnectionString()
        {
            //ValidateDefaultConnection();

            //// 1. Create Connection String Builder using Default connection string
            //var connectionBuilder = databaseType.GetConnectionBuilder(connectionOptions.Value.DefaultConnection);

            //// 2. Remove old Database Name from connection string
            //connectionBuilder.Remove(DatabaseFieldKeyword);

            //// 3. Obtain Database name from DataBaseManager and Add new DB name to 
            //connectionBuilder.Add(DatabaseFieldKeyword, dataBaseManager.GetDataBaseName(connectionOptions.Value.MasterDbConnection, tenantId));

            // 4. Create DbContextOptionsBuilder with new Database name
            var contextOptionsBuilder = new DbContextOptionsBuilder<DeviceContext>();
            
            databaseType.SetConnectionString(contextOptionsBuilder, connectionOptions.Value.DefaultConnection);

            return contextOptionsBuilder;
        }
    }
}
