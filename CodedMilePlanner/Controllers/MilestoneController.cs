using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodedMilePlanner.Models;
using CodedMilePlanner.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodedMilePlanner.Controllers
{
    
    [Route("[controller]/[action]")]
    public class MilestoneController : Controller
    {
        /// <summary>
        /// Attribute for the database
        /// </summary>
        private readonly MilestoneDb _db;

        /// <summary>
        /// Milestone controller that handles the milestone page
        /// </summary>
        /// <param name="db"></param>
        public MilestoneController(MilestoneDb db)
        {
            _db = db;
        }

        /// <summary>
        /// Method that displays all milestones depending on project id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Milestones(int id)
        {
            var project = _db.Projects.Include(x => x.Milestones).FirstOrDefault(x => x.ID == id);

            Response.ContentType = "text/html";
            return View(project);
        }

        /// <summary>
        /// Get Method that allows the use to add a milestone
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddMilestone(int id)
        {
            Response.ContentType = "text/html";
            Milestone milestone = new Milestone("", "", new DateTime(), id);
            return View(milestone);
        }

        /// <summary>
        /// Post method that allows the user to add a milestone
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddMilestone(Milestone model)
        {
            var project = _db.Projects.FirstOrDefault(x => x.ID == model.Project_ID);

            Milestone milestone = project.createMilestone(model.Name, model.Description, model.Due_Date);

            _db.Milestones.Add(milestone);

            _db.SaveChanges();

            return RedirectToAction("Milestones", new { id = project.ID });
        }

        /// <summary>
        /// Get milestone that allows the user to edit a milestone
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditMilestone(int id)
        {
            Response.ContentType = "text/html";

            Milestone milestone = _db.Milestones.FirstOrDefault(x => x.ID == id);

            return View(milestone);
        }

        /// <summary>
        /// Post method that allows the user to edit a milestone
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditMilestone(Milestone model)
        {
            Milestone updateMilestone = model.updateMilestone(model.Name, model.Description, model.Due_Date, model.Action_Completion_Date.Value);

            _db.Milestones.Update(updateMilestone);

            _db.SaveChanges();

            return RedirectToAction("Milestones", new { id = model.Project_ID });
        }

        /// <summary>
        /// get method that allows the user to mark a milestone as complete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Complete(int id)
        {
            Milestone milestone = _db.Milestones.FirstOrDefault(x => x.ID == id);

            milestone.Action_Completion_Date = DateTime.Now;

            _db.Milestones.Update(milestone);

            _db.SaveChanges();

            return RedirectToAction("Milestones", new { id = milestone.Project_ID });
        }

        /// <summary>
        /// get method that allows the user to delete a milestone
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Milestone milestone = _db.Milestones.FirstOrDefault(x => x.ID == id);

            int projectId = milestone.Project_ID;

            _db.Milestones.Remove(milestone);

            _db.SaveChanges();

            return RedirectToAction("Milestones", new { id = projectId });
        }
    }
}