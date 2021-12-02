using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevASPMVC.Models
{
    [Table("Languages")]
    public class Language
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public List<PersonLanguage> People { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
