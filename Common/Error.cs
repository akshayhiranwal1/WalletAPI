using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletAPI.Common
{
    public class Error
    {
        public string Error_code { get; set; }
        public string Message { get; set; }
        public dynamic ValidationErrors { get; set; }
    }
}
