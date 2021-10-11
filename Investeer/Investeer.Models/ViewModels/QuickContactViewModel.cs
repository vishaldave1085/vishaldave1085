using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Investeer.Models.ViewModels
{
    public class QuickContactViewModel
    {
        [Display(Name = "First Name")]
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Display(Name = "Contact Number")]
        [Required]
        [MaxLength(15)]
        public string ContactNumber { get; set; }

        [Display(Name = "Email Id")]
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        [Display(Name = "Investment Amount")]
        [Required]
        [Range(10000, int.MaxValue, ErrorMessage = "Please enter amount greated then $10,000")]
        public int InvestmentAmount { get; set; }

        [Display(Name = "Investment Period")]
        [Required]
        public string InvestmentPeriod { get; set; }

        public string Message { get; set; }

        public string LastFirst {
            get { return LastName + " " + FirstName; }
            }
        public string FirstLast
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
