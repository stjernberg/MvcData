using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.Repos
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> peopleList = new List<Person>();
        private static int idCounter = 0;
        public Person Create(Person person)
        {
            person.Id = ++idCounter;
            peopleList.Add(person);
            return person;
        }

        public void Delete(Person person)
        {
           if (person != null)
            {
               peopleList.Remove(person);                
            }
                       
        }

        public Person GetById(int id)
        {
            Person person = null;
            foreach (Person aPerson in peopleList)
            {
                if (aPerson.Id == id)
                {
                    person = aPerson;
                    break;
                }               
            }
            return person;
        }

        public List<Person> GetAll()  
        {
            return peopleList;
        }

       
        public bool update(Person person)
        {
            Person originalPerson = GetById(person.Id);
            if (originalPerson != null)
            {
                originalPerson.Name = person.Name;
                originalPerson.PhoneNr = person.PhoneNr;
                originalPerson.City = person.City;
               
            }
            return originalPerson != null;

        }

        public bool Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
