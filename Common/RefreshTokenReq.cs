using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletAPI.Common
{
    public class RefreshTokenReq
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
