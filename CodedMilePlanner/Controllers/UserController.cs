using CodedMilePlanner.Database;
using CodedMilePlanner.Models;
using CodedMilePlanner.Models.ServiceModels;
using CodedMilePlanner.Models.ViewModels;
using CodedMilePlanner.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodedMilePlanner.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        /// <summary>
        /// Private instance of the UserManager class that will be initialised using dependency injection
        /// </summary>
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Private instance of the MilestoneDb class that will be initialised using dependency injection
        /// </summary>
        private readonly MilestoneDb _db;

        /// <summary>
        /// Private instance of the SignInManager class that will be initialised using dependency injection
        /// </summary>
        private readonly SignInManager<User> _signInManager;

        private readonly ICodedMileCookieCutter _cookieCutter;

        private readonly IHelper _helper;

        /// <summary>
        /// Constructor for the UserController that handles dependency injection
        /// </summary>
        /// <param name="userManager">Instance of UserManager class that will be used to initialise the global private instance</param>
        /// <param name="db">Instance of MilestoneDb class that will be used to initialise the global private instance</param>
        /// <param name="signInManager">Instance of SignInManager class that will be used to initialise the global private instance</param>
        public UserController(UserManager<User> userManager, MilestoneDb db, SignInManager<User> signInManager, ICodedMileCookieCutter cookieCutter, IHelper helper)
        {
            _userManager = userManager;
            _db = db;
            _signInManager = signInManager;
            _cookieCutter = cookieCutter;
            _helper = helper;
        }

        /// <summary>
        /// Method for handling the GET request to the login page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            // Specifies the content type of the response (HTML)
            Response.ContentType = "text/html";
            return View();
        }

        /// <summary>
        /// Method for handling the POST request to the login page
        /// </summary>
        /// <param name="model">Model with the user entered values bound to it</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            // If the model is valid (no null values, etc.)
            if (ModelState.IsValid)
            {
                // Gets the user using the email of the model
                User user = _db.Users.FirstOrDefault(x => x.Email == model.Email);
                
                // Signs in the user using the SignInManager
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);

                if(result.Succeeded)
                {
                    CookieCutterModel cookieCutterModel = new CookieCutterModel
                    {
                        User_ID = user.Id
                    };

                    CookieResultModel cookieModel = _cookieCutter.CreateCodedMileCookie(cookieCutterModel, CodedMileCookieTypes.Authorisation);

                    Response.Cookies.Append(cookieModel.Key, cookieModel.Value);

                    // Specifies the content type of the response (HTML)
                    Response.ContentType = "text/html";

                    // Redirects the user to the Projects Action
                    return RedirectToAction("Projects", "Project");
                }

                // Specifies the content type of the response (HTML)
                Response.ContentType = "text/html";
                return View();

            }
            else
            {
                // Specifies the content type of the response (HTML)
                Response.ContentType = "text/html";
                return View();
            }
        }

        /// <summary>
        /// Method for handling the GET request to the register page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            Result result = new Result();

            RegisterModel model = new RegisterModel
            {
                Result = result.CreateResult(true, "")
            };

            // Specifies the content type of the response (HTML)
            Response.ContentType = "text/html";
            return View(model);
        }

        /// <summary>
        /// Method for handling the POST request to the register page
        /// </summary>
        /// <param name="model">Model with the user entered values bound to it</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            // If the model is valid (no null values, etc.)
            if (ModelState.IsValid)
            {
                // Creates a new instance of the User class using the values in the model
                User user = new User
                {
                    First_Name = model.First_Name,
                    Last_Name = model.Last_Name,
                    Email = model.Email,
                    UserName = model.Email
                };

                try
                {
                    // Creates the user using the UserManager
                    var result = await _userManager.CreateAsync(user, model.Password);

                    if(result.Succeeded)
                    {
                        _userManager.AddToRoleAsync(user, "User").Wait();
                        _userManager.AddClaimsAsync(user, _helper.GetUserBasicClaims()).Wait();

                        var signInResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);

                        if(signInResult.Succeeded)
                        {
                            CookieCutterModel cookieCutterModel = new CookieCutterModel
                            {
                                User_ID = user.Id
                            };

                            CookieResultModel cookieModel = _cookieCutter.CreateCodedMileCookie(cookieCutterModel, CodedMileCookieTypes.Authorisation);

                            Response.Cookies.Append(cookieModel.Key, cookieModel.Value);

                            // Specifies the content type of the response (HTML)
                            Response.ContentType = "text/html";

                            // Redirects the user to the Projects Action
                            return RedirectToAction("Projects", "Project");
                        }

                        
                    }

                    Result modelResult = new Result();

                    model.Result = modelResult.CreateResult(false, "There was an error registering you");

                    // Specifies the content type of the response (HTML)
                    Response.ContentType = "text/html";
                    return View(model);

                }
                catch (Exception ex)
                {
                    // Specifies the content type of the response (HTML)
                    Response.ContentType = "text/html";
                    return View();
                }
                
            }
            else
            {
                // Specifies the content type of the response (HTML)
                Response.ContentType = "text/html";
                return View();
            }
            
        }
    }
}
