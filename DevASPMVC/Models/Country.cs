using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevASPMVC.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
