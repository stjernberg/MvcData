using MvcData.Models.Repos;
using MvcData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.Service
{

    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo;
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }
        public Person Add(CreatePersonViewModel createPerson)
        {
            if (string.IsNullOrWhiteSpace(createPerson.Name) || string.IsNullOrWhiteSpace(createPerson.City))
            {
                throw new ArgumentException("Model and brand cannot consist of backsapce and whitespace");
            }

            Person person = new Person()
            {
                Name = createPerson.Name,
                PhoneNr = createPerson.PhoneNr,
                City = createPerson.City
            };
            _peopleRepo.Create(person);
            return person;
        }

        public List<Person> All()
        {
            return _peopleRepo.GetAll();
        }

        public bool Edit(int id, CreatePersonViewModel person)
        {
            throw new NotImplementedException();
        }

        public Person FindById(int id)
        {
            return _peopleRepo.GetById(id);
        }

        public bool Remove(int id)
        {
            bool remove;
            Person personToDelete = _peopleRepo.GetById(id);
            if (personToDelete != null)
            {
                remove = _peopleRepo.Delete(personToDelete);
            }
            else 
            {
                remove = false;
            }
            return remove;
        }

        public List<Person> Search(string search, string type)
        {
            List<Person> filteredList = new List<Person>();
            List<Person> personList = All();

            foreach (Person person in personList)
            {
                if (type == "city")
                {
                    if (person.City.Contains(search))
                    {
                        filteredList.Add(person);
                    }
                }

                if (type == "name")
                {
                    if (person.Name.Contains(search))
                    {
                        filteredList.Add(person);
                    }
                }
            }
            return filteredList;
        }

        public List<Person> Sort()
        {
            List<Person> personList = All();
            List<Person> sortedList = personList.OrderBy(o => o.Name).ToList();
          
            //personList.Sort((x, y) => x.Name.CompareTo(y.Name));
            return sortedList;
        }
        
    }        
}

