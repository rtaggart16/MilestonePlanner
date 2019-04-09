using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CodedMilePlanner.Services
{
    public interface IHelper
    {
        List<Claim> GetUserBasicClaims();
    }

    public class Helper : IHelper
    {
        public List<Claim> GetUserBasicClaims()
        {
            return new List<Claim>()
            {
                new Claim("hasSiteAccess", "true"),
                new Claim("isUser", "true")
            };
        }
    }
}
