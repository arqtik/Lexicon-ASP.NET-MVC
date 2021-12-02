using System;
using System.Collections.Generic;

namespace DevASPMVC.Models
{
    public class Language
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<Person> People { get; set; }
    }
}
