using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodedMilePlanner.Models
{
    /// <summary>
    /// The class that contains the details of a user of the system. This class inherits from IdentityUser
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// The first name of a User of the system
        /// </summary>
        public string First_Name { get; set; }

        /// <summary>
        /// The last name of a User of the system
        /// </summary>
        public string Last_Name { get; set; }
    }
}
