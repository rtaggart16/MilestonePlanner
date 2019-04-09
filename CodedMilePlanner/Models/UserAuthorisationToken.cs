using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodedMilePlanner.Models
{
    public class UserAuthorisationToken
    {
        [Key]
        public string ID { get; set; }

        public string User_ID { get; set; }

        public string Value { get; set; }

        [ForeignKey("User_ID")]
        public virtual User User { get; set; }
    }
}
