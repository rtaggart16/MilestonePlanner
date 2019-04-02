using CodedMilePlanner.Database;
using CodedMilePlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodedMilePlanner.Controllers
{
    [Route("[controller]/[action]")]
    public class ProjectController : Controller
    {
        private readonly MilestoneDb _db;
        private readonly UserManager<User> _userManager;

        public ProjectController(MilestoneDb db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Projects()
        {
            List<Project> projects = _db.Projects.Where(x => x.User_ID == _userManager.GetUserId(User)).ToList();

            Response.ContentType = "text/html";
            return View(projects);
        }

        [HttpGet]
        public IActionResult AddProject()
        {
            Response.ContentType = "text/html";
            return View();
        }


        [HttpPost]
        public IActionResult AddProject(Project model)
        {
            Project project = new Project(model.Name, model.Start_Time, model.End_Time, model.Description, _userManager.GetUserId(User));

            _db.Projects.Add(project);

            _db.SaveChanges();
            return RedirectToAction("Projects");
        }

        [HttpGet]
        public IActionResult EditProject(int id)
        {
            Response.ContentType = "text/html";

            Project milestone = _db.Projects.FirstOrDefault(x => x.ID == id);

            return View(milestone);
        }

        [HttpPost]
        public IActionResult EditProject(Project model)
        {
            Project updateProject = model.updateProject(model.Name, model.Start_Time, model.End_Time, model.Description);

            _db.Projects.Update(updateProject);

            _db.SaveChanges();

            return RedirectToAction("Projects");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Project project = _db.Projects.FirstOrDefault(x => x.ID == id);

            _db.Projects.Remove(project);

            _db.SaveChanges();

            return RedirectToAction("Projects");
        }
    }
}
