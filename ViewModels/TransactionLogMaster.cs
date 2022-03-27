using System;
using System.Collections.Generic;

namespace WalletAPI.ViewModels
{
    public partial class TransactionLogMasterViewModel
    {
        public int Id { get; set; }
        public int? PaymentMasterId { get; set; }
        public string Description { get; set; }
        public string Txnid { get; set; }
        public string Status { get; set; }
        public decimal? Amount { get; set; }
        public int? WalletId { get; set; }

        public virtual PaymentMasterViewModel PaymentMaster { get; set; }
        public virtual WalletViewModel Wallet { get; set; }
    }
}
