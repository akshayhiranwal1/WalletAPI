using WalletAPI.Services.Generic;
using WalletAPI.ViewModels;

namespace WalletAPI.Controllers
{
    public class WalletController
        : BaseController<WalletViewModel>
    {
        private readonly IGenericService<WalletViewModel> Service;

        public WalletController(IGenericService<WalletViewModel> service) : base(service)
        {
            Service = service;
        }
    }
}