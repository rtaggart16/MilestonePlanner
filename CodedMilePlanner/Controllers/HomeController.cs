using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodedMilePlanner.Controllers
{
    
        public class HomeController : Controller
        {
            [HttpGet]
            public IActionResult Index()
            {
                Response.ContentType = "text/html";
                return View();
            }
        }
    
}
