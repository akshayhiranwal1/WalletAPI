using WalletAPI.Services.Generic;
using WalletAPI.ViewModels;

namespace WalletAPI.Controllers
{
    public class TransactionLogMasterController : BaseController<TransactionLogMasterViewModel>
    {
        private readonly IGenericService<TransactionLogMasterViewModel> Service;

        public TransactionLogMasterController(IGenericService<TransactionLogMasterViewModel> service) : base(service)
        {
            Service = service;
        }
    }
}