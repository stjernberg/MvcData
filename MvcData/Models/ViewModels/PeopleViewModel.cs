using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.ViewModels
{
    public class PeopleViewModel
    {
        public List<Person> Persons { get; set; }
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string City { get; set; }
        public string Search { get; set; }

    }
}