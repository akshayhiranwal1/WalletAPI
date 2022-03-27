using System;
using System.Collections.Generic;

namespace WalletAPI.ViewModels
{
    public partial class WalletViewModel
    {
        public WalletViewModel()
        {
            TransactionLogMaster = new HashSet<TransactionLogMasterViewModel>();
        }

        public int Id { get; set; }
        public int? AccountId { get; set; }
        public decimal? Amount { get; set; }
        public string Address { get; set; }

        public virtual AccountViewModel Account { get; set; }
        public virtual ICollection<TransactionLogMasterViewModel> TransactionLogMaster { get; set; }
    }
}
