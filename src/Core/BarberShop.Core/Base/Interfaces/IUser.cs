using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Core.Base.Interfaces
{
    public interface IUser
    {

        
        string Name { get; }
        string GetUserId();
        long GetAccountId();
        string GetUserEmail();
        bool IsAuthenticated();
        string GetLocalIpAddress();
        string GetRemoteIpAddress();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
