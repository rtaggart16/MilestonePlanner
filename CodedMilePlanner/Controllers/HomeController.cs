using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodedMilePlanner.Controllers
{
        /// <summary>
        /// Method that handles the displaying of the landing page
        /// </summary>
        public class HomeController : Controller
        {
            [HttpGet]
            public IActionResult Index()
            {
                // Specifies the response type
                Response.ContentType = "text/html";
                return View();
            }
        }
    
}
