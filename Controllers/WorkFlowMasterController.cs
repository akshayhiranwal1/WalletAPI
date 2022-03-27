using WalletAPI.Services.Generic;
using WalletAPI.ViewModels;

namespace WalletAPI.Controllers
{
    public class AccountController
        : BaseController<AccountViewModel>
    {
        private readonly IGenericService<AccountViewModel> Service;

        public AccountController(IGenericService<AccountViewModel> service) : base(service)
        {
            Service = service;
        }
    }
}