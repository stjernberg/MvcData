using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        [Display(Name = "First name")]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(80, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
                

        [Required]
        [EmailAddress]
        public string Email { get; set; }


    }
}
