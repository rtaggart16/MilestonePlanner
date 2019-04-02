using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodedMilePlanner.Models;

namespace CodedMilePlanner.Controllers
{
    /// <summary>
    /// Method that handles the displaying of the landing page
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}
