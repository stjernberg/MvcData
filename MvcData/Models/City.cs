﻿using MvcData.Models.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}