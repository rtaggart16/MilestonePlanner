using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodedMilePlanner.Models.ViewModels
{
    /// <summary>
    /// ViewModel used to bind the inputs from a user logging in
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// The user's email
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// The user's password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
