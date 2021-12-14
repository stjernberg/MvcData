using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.ViewModels
{
    public class PeopleViewModel
    {
        public List<Person> Persons { get; set; }
     
        public string Search { get; set; }

    }
}