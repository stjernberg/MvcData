using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        [Display (Name= "Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Phone number")]
        [Required]
        public int PhoneNr { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

       
    }
}
