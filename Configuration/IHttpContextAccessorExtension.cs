﻿using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace WalletAPI.Configuration
{
    public static class IHttpContextAccessorExtension
    {
        public static string CurrentUser(this IHttpContextAccessor httpContextAccessor)
        {
            var userId = httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId;
        }
    }
}
