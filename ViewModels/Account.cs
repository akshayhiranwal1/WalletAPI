using System;
using System.Collections.Generic;

namespace WalletAPI.ViewModels
{
    public partial class AccountViewModel
    {
        public AccountViewModel()
        {
            PaymentMaster = new HashSet<PaymentMasterViewModel>();
            Wallet = new HashSet<WalletViewModel>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SortCode { get; set; }
        public string AccountNumber { get; set; }

        public virtual ICollection<PaymentMasterViewModel> PaymentMaster { get; set; }
        public virtual ICollection<WalletViewModel> Wallet { get; set; }
    }
}
