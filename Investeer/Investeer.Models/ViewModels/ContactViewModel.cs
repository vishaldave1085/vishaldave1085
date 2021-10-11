using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Investeer.Models.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

       
        [Display(Name = "Email Id")]
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        [Display(Name = "Investment Period")]
        [Required]
        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
