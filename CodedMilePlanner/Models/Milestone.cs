using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodedMilePlanner.Models
{
    public class Milestone
    {
        /// <summary>
        /// Attribute for the ID of the Class
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        
        /// <summary>
        /// Attribute for the Project ID foreign key
        /// </summary>
        public int Project_ID { get; set; }


        /// <summary>
        /// Attribute for the milestone name
        /// </summary>
        /// 
        [StringLength(60, MinimumLength = 1, ErrorMessage = "The length of the milestone name is either too short or too long")]
        public string Name { get; set; }


        /// <summary>
        /// Attribute for the description of the milestone
        /// </summary>
        /// 
        [StringLength(150, MinimumLength = 3, ErrorMessage = "The length of the milestone description is either too short or too long")]
        public string Description { get; set; }


        /// <summary>
        /// Attribute for the due date of the milestone
        /// </summary>
        /// 
        [DataType(DataType.Date)]
        public DateTime Due_Date { get; set; }

        
        /// <summary>
        /// Attribute for the completion date
        /// </summary>
        /// 
        [DataType(DataType.Date)]
        public DateTime? Action_Completion_Date { get; set; }

        /// <summary>
        /// instance for the project the milestone is attatched to
        /// </summary>
        [ForeignKey("Project_ID")]
        public virtual Project Project { get; set; }

        /// <summary>
        /// paramaterless constructor
        /// </summary>
        public Milestone()
        {

        }

        /// <summary>
        /// Constructor for the milestone class
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="dueDate"></param>
        /// <param name="projectID"></param>
        public Milestone(string name, string description, DateTime dueDate, int projectID)
        {
            this.Name = name;
            this.Description = description;
            this.Due_Date = dueDate;
            this.Action_Completion_Date = null;
            this.Project_ID = projectID;
        }

        /// <summary>
        /// This method allows us to update a milestone with the passed in parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="dueDate"></param>
        /// <param name="actionCompletionDate"></param>
        /// <returns></returns>
        public Milestone updateMilestone(string name, string description, DateTime dueDate, DateTime actionCompletionDate)
        {
            this.Name = name;
            this.Description = description;
            this.Due_Date = dueDate;
            this.Action_Completion_Date = actionCompletionDate;

            return this;
        }
    }
}
