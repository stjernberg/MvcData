using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.ViewModels
{
    public class CreateCountryViewModel
    {
        [Required]
        [StringLength(80, MinimumLength = 2)]
        [Display(Name = "Country name")]
        public string Name { get; set; }
        //public List<City> CityList { get; set; }
        public List<City> CityList { get; set; }
       
    }
}
