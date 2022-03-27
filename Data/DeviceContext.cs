using Microsoft.EntityFrameworkCore;

namespace WalletAPI.Data
{
    /// <summary>
    /// The device DB (entity framework's) context
    /// </summary>
    public class DeviceContext : DbContext, IDbContext
    {
        private bool isTenantDbConnection = false;
        private string tenantDbConnectionString { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public DeviceContext(DbContextOptions<DeviceContext> options)
            : base(options)
        {


            // TODO: Comment below this if you are running migrations commands
            // TODO: uncomment below line of you are running the application for the first time
            //this.Database.EnsureCreated();
        }

        public DeviceContext(string connection)
        {
            isTenantDbConnection = true;
            tenantDbConnectionString = connection;
        }

        //public virtual DbSet<WorkFlowMaster> WorkFlowMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(tenantDbConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }   
}
