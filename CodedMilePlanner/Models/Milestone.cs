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

        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int Project_ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Due_Date { get; set; }

        public DateTime? Action_Completion_Date { get; set; }

        [ForeignKey("Project_ID")]
        public virtual Project Project { get; set; }

        public Milestone()
        {

        }

        public Milestone(string name, string description, DateTime dueDate, int projectID)
        {
            this.Name = name;
            this.Description = description;
            this.Due_Date = dueDate;
            this.Action_Completion_Date = null;
            this.Project_ID = projectID;
        }

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
