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
        /// <summary>
        /// Private instance of the MilestoneDb class that will be initialised using dependency injection
        /// </summary>
        private readonly MilestoneDb _db;

        /// <summary>
        /// Private instance of the UserManager class that will be initialised using dependency injection
        /// </summary>
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Constructor for the ProjectController that handles dependency injection
        /// </summary>
        /// <param name="db">Instance of MilestoneDb class that will be used to initialise the global private instance</param>
        /// <param name="userManager">Instance of UserManager class that will be used to initialise the global private instance</param>
        public ProjectController(MilestoneDb db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        /// <summary>
        /// Method for handling the GET request to the projects page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Projects()
        {
            // Gets a list of all projects that belong to the current logged in user
            List<Project> projects = _db.Projects.Where(x => x.User_ID == _userManager.GetUserId(User)).ToList();

            // Specifies the content type of the response (HTML)
            Response.ContentType = "text/html";

            // Returns the Projects view passing in the user's projects
            return View(projects);
        }

        /// <summary>
        /// Method for handling the GET request to the addproject page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddProject()
        {
            // Specifies the content type of the response (HTML)
            Response.ContentType = "text/html";
            return View();
        }

        /// <summary>
        /// Method for handling the POST request to the addproject page
        /// </summary>
        /// <param name="model">Model with the user entered project values bound to it</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddProject(Project model)
        {
            // Creates a new Project by using the constructor defined in the Project class (Project.cs)
            Project project = new Project(model.Name, model.Start_Time, model.End_Time, model.Description, _userManager.GetUserId(User));

            // Add the project to the database
            _db.Projects.Add(project);

            // Saves the changes made to the database
            _db.SaveChanges();

            // Redirect the user to the Projects page
            return RedirectToAction("Projects");
        }

        /// <summary>
        /// Method for handling the GET request to the editproject page
        /// </summary>
        /// <param name="id">ID of the project being edited</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditProject(int id)
        {
            // Specifies the content type of the response (HTML)
            Response.ContentType = "text/html";

            // Gets the project by the id passed in
            Project project = _db.Projects.FirstOrDefault(x => x.ID == id);

            // Pass the project into the View
            return View(project);
        }

        /// <summary>
        /// Method for handling the POST request to the editproject page
        /// </summary>
        /// <param name="model">Model with the user entered project values bound to it</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditProject(Project model)
        {
            // Gets an updated version of the project using the updateProject method in the Project class (Project.cs)
            Project updateProject = model.updateProject(model.Name, model.Start_Time, model.End_Time, model.Description);

            // Update the current instance of the project
            _db.Projects.Update(updateProject);

            // Save the changes made to the database
            _db.SaveChanges();

            // Redirect the user to the Projects
            return RedirectToAction("Projects");
        }

        /// <summary>
        /// Method for handling the GET request to the delete method
        /// </summary>
        /// <param name="id">ID of the project being deleted</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Gets the project by the ID passed in
            Project project = _db.Projects.FirstOrDefault(x => x.ID == id);

            // Remove the project from the database
            _db.Projects.Remove(project);

            // Save the changes made to the database
            _db.SaveChanges();

            // Redirect the user to the Projects page
            return RedirectToAction("Projects");
        }
    }
}
