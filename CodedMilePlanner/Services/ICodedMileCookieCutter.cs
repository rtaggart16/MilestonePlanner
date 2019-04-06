using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodedMilePlanner.Services
{
    public interface ICodedMileCookieCutter
    {
    }

    public class CodedMileCookieCutter : ICodedMileCookieCutter
    {
        public bool CreateCodedMileCookie()
        {

        }
    }

    public enum CodedMileCookieTypes
    {
        Authorisation = 0
    }
}
