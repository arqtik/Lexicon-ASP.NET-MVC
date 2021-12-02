using System;
using System.ComponentModel.DataAnnotations;

namespace DevASPMVC.Models
{
    public class PersonLanguage
    {
        [Required] 
        public int PersonID { get; set; }
        public Person Person { get; set; }

        [Required]
        public int LanguageID { get; set; }
        public Language Language { get; set; }
    }
}
