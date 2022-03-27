namespace WalletAPI.Data.Management
{
    /// <summary>
    /// Context factory interface
    /// </summary>
    public interface IContextFactory
    {
        IDbContext DbContext { get; }
    }
}