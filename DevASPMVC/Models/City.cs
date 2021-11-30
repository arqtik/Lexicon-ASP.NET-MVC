using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevASPMVC.Models
{
    public class City
    {
        [Key]
        public string Name { get; set; }

        [Key]
        public Country Country { get; set; }

        [Required]
        public List<Person> People { get; set; }
    }
}
