using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Investeer.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "First Name")]
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Display(Name = "Mobile Number")]
        [Required]
        [MaxLength(15)]
        public string ContactNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Terms & Conditions")]
        //[Range(typeof(bool), "true", "true", ErrorMessage = "Please accept Terms & Conditions")]
        public bool Terms { get; set; }

    }
}
