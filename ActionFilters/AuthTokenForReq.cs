using WalletAPI.Common.HttpRequestClient;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletAPI.ActionFilters
{
    public class AuthTokenForReq: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string token = context.HttpContext.Request.Headers["Authorization"].ToString().Split(" ")[1];
            Token.BearerToken = token;
            base.OnActionExecuting(context);
        }
    }
}
