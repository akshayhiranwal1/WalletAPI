using WalletAPI.Services.Generic;
using WalletAPI.ViewModels;

namespace WalletAPI.Controllers
{
    public class PaymentMasterController
        : BaseController<PaymentMasterViewModel>
    {
        private readonly IGenericService<PaymentMasterViewModel> Service;

        public PaymentMasterController(IGenericService<PaymentMasterViewModel> service) : base(service)
        {
            Service = service;
        }
    }
}