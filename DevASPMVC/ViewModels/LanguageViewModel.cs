using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevASPMVC.Models;

namespace DevASPMVC.ViewModels
{
    public class LanguageViewModel
    {
        public List<Language> Languages { get; set; }
        public List<Person> People { get; set; }

        public Person Person { get; set; }
        public List<Language> PersonLanguages { get; set; }

        public Language Language { get; set; }

        [Required]
        public int PersonId { get; set; }
        [Required(ErrorMessage = "Select a language")]
        public int LanguageId { get; set; }
    }
}
