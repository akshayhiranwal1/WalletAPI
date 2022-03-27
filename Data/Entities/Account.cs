using System;
using System.Collections.Generic;

namespace WalletAPI.Database
{
    public partial class Account
    {
        public Account()
        {
            PaymentMaster = new HashSet<PaymentMaster>();
            Wallet = new HashSet<Wallet>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SortCode { get; set; }
        public string AccountNumber { get; set; }

        public virtual ICollection<PaymentMaster> PaymentMaster { get; set; }
        public virtual ICollection<Wallet> Wallet { get; set; }
    }
}
