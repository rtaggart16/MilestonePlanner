using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodedMilePlanner.Models
{
    public class User : IdentityUser
    {
        public string First_Name { get; set; }

        public string Last_Name { get; set; }
    }
}
