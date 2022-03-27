using System;
using System.Collections.Generic;

namespace WalletAPI.Database
{
    public partial class Wallet
    {
        public Wallet()
        {
            TransactionLogMaster = new HashSet<TransactionLogMaster>();
        }

        public int Id { get; set; }
        public int? AccountId { get; set; }
        public decimal? Amount { get; set; }
        public string Address { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<TransactionLogMaster> TransactionLogMaster { get; set; }
    }
}
