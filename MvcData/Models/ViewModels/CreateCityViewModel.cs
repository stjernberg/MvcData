using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.ViewModels
{
    public class CreateCityViewModel
    {
        [Required]
        [StringLength(80, MinimumLength = 2)]
        [Display(Name = "City name")]
        public string CityName { get; set; }
         public List<Person> PeopleList { get; set; }
        public int CountryId { get;  set; }
        public List<Country> Countries { get; set; }

        public CreateCityViewModel()
        {
            Countries = new List<Country>();
        }
    }
}
