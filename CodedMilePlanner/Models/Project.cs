using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodedMilePlanner.Models
{
    public class Project
    {
        /// <summary>
        /// ID for the class
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        /// <summary>
        /// Holds the foreign key for the user who accesses the project
        /// </summary>
        public string User_ID { get; set; }

        /// <summary>
        /// Attribute for the name of the project
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Attribute for the start time of the project
        /// </summary>
        public DateTime Start_Time { get; set; }

        /// <summary>
        /// Attribute for the end time of the project
        /// </summary>
        public DateTime End_Time { get; set; }

        /// <summary>
        /// Attribute for the description of the project
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// instance for the user the project is attatched to
        /// </summary>
        [ForeignKey("User_ID")]
        public virtual User User { get; set; }

        /// <summary>
        /// List of milestones for the project
        /// </summary>
        public virtual List<Milestone> Milestones { get; set; }

        /// <summary>
        /// parameterless constructor
        /// </summary>
        public Project()
        {

        }

        /// <summary>
        /// Constructor for the project class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="description"></param>
        /// <param name="userID"></param>
        public Project(string name, DateTime startTime, DateTime endTime, string description, string userID)
        {
            this.Name = name;
            this.Description = description;
            this.Start_Time = startTime;
            this.End_Time = endTime;
            this.User_ID = userID;
        }

        /// <summary>
        /// Method that allows the user to create a milestone
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="dueDate"></param>
        /// <returns></returns>
        public Milestone createMilestone(string name, string description, DateTime dueDate)
        {
            Milestone milestone = new Milestone(name, description, dueDate, this.ID);

            return milestone;
        }

        /// <summary>
        /// Method that allows the user to delete a milestone
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Milestone deleteMilestone(int ID)
        {
            Milestone milestone = this.Milestones.FirstOrDefault(x => x.ID == ID);

            this.Milestones.Remove(milestone);

            return milestone;
        }

        /// <summary>
        /// Method that gets the milestones
        /// </summary>
        /// <returns></returns>
        public List<Milestone> getMilestones()
        {
            return this.Milestones;
        }

        /// <summary>
        /// Method that allows the user to update the project
        /// </summary>
        /// <param name="name"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public Project updateProject(string name, DateTime startTime, DateTime endTime, string description)
        {
            this.Name = name;
            this.Description = description;
            this.Start_Time = startTime;
            this.End_Time = endTime;

            return this;
        }

        /// <summary>
        /// Method that allows the user to delete the project
        /// </summary>
        /// <returns></returns>
        public Project deleteProject()
        {
            return this;
        }
    }
}
