using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodedMilePlanner.Models.ViewModels
{
    /// <summary>
    /// ViewModel used to bind the inputs from a user registering
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// The User's first name
        /// </summary>
        [Required]
        public string First_Name { get; set; }
        /// <summary>
        /// The User's last name
        /// </summary>
        [Required]
        public string Last_Name { get; set; }
        /// <summary>
        /// The User's password
        /// </summary>
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        /// <summary>
        /// The User's confirmed password
        /// </summary>
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Confirm_Password { get; set; }
        /// <summary>
        /// The User's email
        /// </summary>
        [Required]
        public string Email { get; set; }

        public Result Result { get; set; }
    }
}
