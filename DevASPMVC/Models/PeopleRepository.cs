using System.Collections.Generic;

namespace DevASPMVC.Models
{
    public static class PeopleRepository
    {
        public static List<Person> AllPeople = new List<Person>()
        {
            new Person()
            {
                FirstName = "Mikael",
                LastName = "Persson",
                Gender = Gender.Male,
                Address = "Götagatan 65E 76321 Stockholm",
                Email = "mikaelpersson@domain.com"
            },
            new Person()
            {
                FirstName = "Mikael",
                LastName = "Johansson",
                Gender = Gender.Male,
                Address = "Jurgengatan 6D 76221 Stockholm",
                Email = "mikaelJohansson@domain.com"
            }
        };
    }
}