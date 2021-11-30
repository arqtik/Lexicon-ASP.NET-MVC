using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevASPMVC.Models
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int CountryID { get; set; }
        public Country Country { get; set; }
        public List<Person> People { get; set; }
    }
}
