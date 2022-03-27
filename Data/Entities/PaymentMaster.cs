using System;
using System.Collections.Generic;

namespace WalletAPI.Database
{
    public partial class PaymentMaster
    {
        public PaymentMaster()
        {
            TransactionLogMaster = new HashSet<TransactionLogMaster>();
        }

        public int Id { get; set; }
        public int? AccountId { get; set; }
        public string OrderId { get; set; }
        public decimal? Amount { get; set; }
        public string SuccessUrl { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<TransactionLogMaster> TransactionLogMaster { get; set; }
    }
}
