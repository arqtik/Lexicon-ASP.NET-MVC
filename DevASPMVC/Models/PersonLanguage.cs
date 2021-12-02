using System;
namespace DevASPMVC.Models
{
    public class PersonLanguage
    {
        public int PersonID { get; set; }
        public Person Person { get; set; }

        public int LanguageID { get; set; }
        public Language Language { get; set; }
    }
}
