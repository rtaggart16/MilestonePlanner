using CodedMilePlanner.Database;
using CodedMilePlanner.Models.ServiceModels;
using Microsoft.AspNetCore.Http;
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
        private readonly MilestoneDb _db;
        private readonly ICodedMileServiceHelper _helper;

        public CodedMileCookieCutter(MilestoneDb db, ICodedMileServiceHelper helper)
        {
            _db = db;
            _helper = helper;
        }

        public bool CreateCodedMileCookie(CookieCutterModel model, CodedMileCookieTypes type)
        {
            bool result = false;

            switch(type)
            {
                case CodedMileCookieTypes.Authorisation:

                    break;
            }

            return result;
        }

        /*private CookieOptions GetAuthorisationCookieOptions(CookieCutterModel model)
        {
            CookieOptions cookie = new CookieOptions();


        }*/
    }

    

    public enum CodedMileCookieTypes
    {
        Authorisation = 0
    }
}
