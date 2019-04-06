using CodedMilePlanner.Database;
using CodedMilePlanner.Models;
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
        CookieResultModel CreateCodedMileCookie(CookieCutterModel model, CodedMileCookieTypes type);
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

        public CookieResultModel CreateCodedMileCookie(CookieCutterModel model, CodedMileCookieTypes type)
        {
            CookieResultModel result = new CookieResultModel();

            switch (type)
            {
                case CodedMileCookieTypes.Authorisation:
                    result = GetAuthorisationCookieOptions(model);
                    break;
            }

            return result;
        }

        private CookieResultModel GetAuthorisationCookieOptions(CookieCutterModel model)
        {
            string randomString = _helper.GenerateRandomAlphaNumeric(9);

            UserAuthorisationToken dbToken = new UserAuthorisationToken
            {
                User_ID = model.User_ID,
                Value = randomString
            };

            _db.User_Auth_Tokens.Add(dbToken);
            _db.SaveChanges();

            CookieResultModel result = new CookieResultModel
            {
                Key = "cmAuthToken",
                Value = randomString
            };

            return result;
        }
    }

    

    public enum CodedMileCookieTypes
    {
        Authorisation = 0
    }
}
