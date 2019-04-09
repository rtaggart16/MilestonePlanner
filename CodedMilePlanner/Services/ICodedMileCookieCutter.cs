using CodedMilePlanner.Database;
using CodedMilePlanner.Models;
using CodedMilePlanner.Models.ServiceModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CodedMilePlanner.Services
{
    public interface ICodedMileCookieCutter
    {
        CookieResultModel CreateCodedMileCookie(CookieCutterModel model, CodedMileCookieTypes type);

        CheckForCookieModel CheckForCodedMileCookie(CodedMileCookieTypes type, List<KeyValuePair<string, string>> cookies);
    }

    public class CodedMileCookieCutter : ICodedMileCookieCutter
    {
        private readonly MilestoneDb _db;
        private readonly ICodedMileServiceHelper _helper;
        //private readonly HttpContext _context;

        public CodedMileCookieCutter(MilestoneDb db, ICodedMileServiceHelper helper)
        {
            _db = db;
            _helper = helper;
            //_context = context;
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

        public CheckForCookieModel CheckForCodedMileCookie(CodedMileCookieTypes type, List<KeyValuePair<string, string>> cookies)
        {
            CheckForCookieModel model = new CheckForCookieModel
            {
                HasCookie = false,
                Value = ""
            };

            switch(type)
            {
                case CodedMileCookieTypes.Authorisation:
                    if (cookies.Where(x => x.Key == "cmAuthToken").Count() > 0)
                    {
                        model.HasCookie = true;
                        model.Value = cookies.FirstOrDefault(x => x.Key == "cmAuthToken").Value;
                    }
                    break;
            }

            return model;
        }

        private CookieResultModel GetAuthorisationCookieOptions(CookieCutterModel model)
        {
            string randomString = _helper.GenerateRandomAlphaNumeric(9);

            var existingDbToken = _db.User_Auth_Tokens.FirstOrDefault(x => x.User_ID == model.User_ID);

            if(existingDbToken == null)
            {
                UserAuthorisationToken dbToken = new UserAuthorisationToken
                {
                    User_ID = model.User_ID,
                    Value = randomString
                };

                _db.User_Auth_Tokens.Add(dbToken);
            }
            else
            {
                existingDbToken.Value = randomString;

                _db.User_Auth_Tokens.Update(existingDbToken);
            }
            
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
