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

        public List<Person> Search(string search)
        {
            List<Person> filteredList = new List<Person>();

            foreach (Person person in All())
            {
                if (person.Name.Contains(search) || person.City.Contains(search))
                {
                    filteredList.Add(person);
                }
            }

            return filteredList;
        }
    }

    
}

