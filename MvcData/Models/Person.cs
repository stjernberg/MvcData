using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int PhoneNr { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public City City { get; set; }

        
    }
}
