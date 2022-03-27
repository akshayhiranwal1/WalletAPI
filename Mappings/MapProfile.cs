using AutoMapper.Configuration;
using WalletAPI.Database;
using WalletAPI.ViewModels;

namespace WalletAPI.Mappings
{
    /// <summary>
    /// Contains objects mapping
    /// </summary>
    /// <seealso cref="MapperConfigurationExpression" />
    public class MapsProfile : MapperConfigurationExpression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapsProfile"/> class
        /// </summary>
        public MapsProfile()
        {
            CreateMap<AccountViewModel,Account>().ReverseMap();
            CreateMap <PaymentMasterViewModel, PaymentMaster>().ReverseMap();
            CreateMap <TransactionLogMasterViewModel, TransactionLogMaster>().ReverseMap();
            CreateMap <WalletViewModel, Wallet>().ReverseMap();
        }
    }
}
