using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace WalletAPI.Configuration.Settings
{
    /// <summary>
    /// Connection configuration options
    /// </summary>
    public class ConnectionSettings
    {
        /// <summary>
        /// Gets or sets the database type (No sql or MsSql)
        /// </summary>
        public DatabaseType DatabaseType { get; set; }

        /// <summary>
        /// Gets or sets the default connection.
        /// </summary>
        /// <value>
        /// The default connection.
        /// </value>
        public string DefaultConnection { get; set; }

        /// <summary>
        /// Connection for Master DB
        /// </summary>
        public string MasterDbConnection { get; set; }

        public double PassswordExpirationDays { get; set; }
        public string VstockDBConnection { get; set; }
        public string VstockDBConnectionDataSync { get; set; }

    }

    public class APIs
    {
        public string VehicleBaseUrl { get; set; }
        public string VehiclePurchaseUrl { get; set; }
        public string VehicleMasterByIdUrl { get; set; }
        public string VehicleForSale { get; set; }
        public string CustomerBaseUrl { get; set; }
        public string CustomerUrl { get; set; }
        public string VehicleStatsByDate { get; set; }
        public string VehicleStatsByVehicleIds { get; set; }
        public string IdentityBaseUrl { get; set; }
        public string GlobalMasterBaseUrl { get; set; }
        public string EmployeeById { get; set; }
        public string NonRefundableStatusUrl { get; set; }
        public string GetAllFranchise { get; set; }
        public string UpdateBuyerPremium { get; set; }
        public string BuyerPremiumAccountCode { get; set; }
        public string UpdatePreferredPickupDate { get; set;}        
        public string RepossessionStatusUpdationUrl { get; set; }
        public string ArchivedStatusUpdationUrl { get; set; }   
        public string VehicleStatusUpdationUrl { get; set; }
    }
}
