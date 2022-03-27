using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletAPI.Common.HttpRequestClient
{
    public interface IRequestClient
    {
        Task<string> GetAsync(string url);
        Task<string> PostAsync(string url, dynamic model);
        Task<string> PutAsync(string url, dynamic model);
        Task<string> PatchAsync(string url, dynamic model);
    }
}
