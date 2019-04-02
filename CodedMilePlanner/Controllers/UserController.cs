using CodedMilePlanner.Database;
using CodedMilePlanner.Models;
using CodedMilePlanner.Models.ViewModels;
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
        private readonly UserManager<User> _userManager;
        private readonly MilestoneDb _db;
        private readonly SignInManager<User> _signInManager;

        public UserController(UserManager<User> userManager, MilestoneDb db, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _db = db;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {

            Response.ContentType = "text/html";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _db.Users.FirstOrDefault(x => x.Email == model.Email);

                await _signInManager.SignInAsync(user, false);

                Response.ContentType = "text/html";
                return RedirectToAction("Projects", "Project");
            }
            else
            {
                Response.ContentType = "text/html";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            Response.ContentType = "text/html";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                User user = new User
                {
                    First_Name = model.First_Name,
                    Last_Name = model.Last_Name,
                    Email = model.Email,
                    UserName = model.Email
                };

                await _userManager.CreateAsync(user, model.Password);

                Response.ContentType = "text/html";
                return RedirectToAction("Projects", "Project");
            }
            else
            {
                Response.ContentType = "text/html";
                return View();
            }
            
        }
    }
}
