using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevASPMVC.Models
{
    [Table("Cities")]
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int CountryID { get; set; }
        public Country Country { get; set; }
        public List<Person> People { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
