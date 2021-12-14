using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcData.Models
{
    public class City
    {
        [Key]       
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string CityName { get; set; }

        public List<Person> People { get; set; }
    }
}