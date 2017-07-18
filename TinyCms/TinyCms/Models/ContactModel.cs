using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TinyCms.Models
{
    public class ContactModel
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required]
        public string Email { get; set; }

        [StringLength(maximumLength: 11, MinimumLength = 9)]
        public string Phone { get; set; }

        public string Address { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 20)]
        public string Message { get; set; }
    }
}
