using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevASPMVC.Models
{
    public class Country
    {
        [Key]
        public string Name { get; set; }

        [Required]
        public List<City> Cities { get; set; }
    }
}
