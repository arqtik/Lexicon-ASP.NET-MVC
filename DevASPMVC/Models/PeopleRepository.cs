using System;
using System.Collections.Generic;
using System.Linq;

namespace DevASPMVC.Models
{
    public static class PeopleRepository
    {
        private static int _counter = 0;
        
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

        public static void AddPerson(Person person)
        {
            person.ID = _counter;
            _counter++;
            AllPeople.Add(person);
        }

        public static void RemovePerson(int id)
        {
            if (AllPeople.Exists(p => p.ID == id))
            {
                AllPeople.Remove(AllPeople.First(p => p.ID == id));
            }
        }
    }
}