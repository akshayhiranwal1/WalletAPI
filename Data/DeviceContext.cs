using WalletAPI.Database;
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

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<PaymentMaster> PaymentMaster { get; set; }
        public virtual DbSet<TransactionLogMaster> TransactionLogMaster { get; set; }
        public virtual DbSet<Wallet> Wallet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(tenantDbConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountNumber).IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.SortCode).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);
            });

            modelBuilder.Entity<PaymentMaster>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OrderId).IsUnicode(false);

                entity.Property(e => e.SuccessUrl).IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.PaymentMaster)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_PaymentMaster_Account");
            });

            modelBuilder.Entity<TransactionLogMaster>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.Txnid)
                    .HasColumnName("TXNId")
                    .IsUnicode(false);

                entity.HasOne(d => d.PaymentMaster)
                    .WithMany(p => p.TransactionLogMaster)
                    .HasForeignKey(d => d.PaymentMasterId)
                    .HasConstraintName("FK_TransactionLogMaster_PaymentMaster");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.TransactionLogMaster)
                    .HasForeignKey(d => d.WalletId)
                    .HasConstraintName("FK_TransactionLogMaster_Wallet");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Wallet)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Wallet_Account");
            });
        }
    }   
}
