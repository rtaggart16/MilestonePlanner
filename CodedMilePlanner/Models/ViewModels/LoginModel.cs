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
        /// The User's password
        /// </summary>
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    
    
}
