using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WalletAPI.Data
{
    /// <summary>
    /// Interface for the Device EF Context
    /// </summary>
    public interface IDbContext
    {
        int SaveChanges();
        //int SaveChanges(bool acceptAllChangesOnSuccess);
        //Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        //Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);
        void Dispose();

        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;
    }
}