using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.ViewModels
{
    public class CreateLanguageViewModel
    {
       
        [Required]
        [StringLength(80, MinimumLength = 2)]
        [Display(Name = "Language name")]
        public string Name { get; set; }
    }
}
