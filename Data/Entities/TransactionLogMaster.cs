using System;
using System.Collections.Generic;

namespace WalletAPI.Database
{
    public partial class TransactionLogMaster
    {
        public int Id { get; set; }
        public int? PaymentMasterId { get; set; }
        public string Description { get; set; }
        public string Txnid { get; set; }
        public string Status { get; set; }
        public decimal? Amount { get; set; }
        public int? WalletId { get; set; }

        public virtual PaymentMaster PaymentMaster { get; set; }
        public virtual Wallet Wallet { get; set; }
    }
}
