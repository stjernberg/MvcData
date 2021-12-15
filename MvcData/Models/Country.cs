using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.ViewModels
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        public List<City> Cities { get; set; }

        internal object ToList()
        {
            throw new NotImplementedException();
        }
    }
}
