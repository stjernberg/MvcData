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
        private  IPeopleRepo _peopleRepo;
        private readonly ILanguageRepo _languageRepo;


        public PeopleService(IPeopleRepo peopleRepo, ILanguageRepo languageRepo)
        {
            _peopleRepo = peopleRepo;
            _languageRepo = languageRepo;
        }
        public Person Add(CreatePersonViewModel createPerson)
        {
            if (string.IsNullOrWhiteSpace(createPerson.Name))
            {
                throw new ArgumentException("Name cannot consist of backsapce and whitespace");
            }
             
            Person person = new Person()
            {
                Name = createPerson.Name,
                PhoneNr = createPerson.PhoneNr,
                CityId = createPerson.CityId
            };
            _peopleRepo.Create(person);
            return person;
        }

        public List<Person> All()
        {
            return _peopleRepo.GetAll();
        }

        public void Edit(int id, CreatePersonViewModel person)
        {
            throw new NotImplementedException();
        }

        public Person FindById(int id)
        {
            return _peopleRepo.GetById(id);
        } 

        public LanguageConnectionViewModel LanguageConnection(Person person)
        {
             LanguageConnectionViewModel languageConnection = new LanguageConnectionViewModel();
            languageConnection.Person = person;
            List<Language> allLanguages = _languageRepo.GetAll();

            foreach (PersonLanguage personLanguage in person.PersonLanguages)
            {
                Language language = allLanguages.Single(lang => lang.Id == personLanguage.LanguageId);
                languageConnection.SpokenLanguages.Add(language);
                allLanguages.Remove(language);
            }

            languageConnection.AllLanguages = allLanguages;

            return languageConnection;
        }

        public void Remove(int id)
        {
            
            Person personToDelete = _peopleRepo.GetById(id);
            if (personToDelete != null)
            {
                _peopleRepo.Delete(personToDelete);
            }
            
        }

        public List<Person> Search(string search, string type)
        {
            List<Person> filteredList = new List<Person>();
            List<Person> personList = All();
            if (!string.IsNullOrWhiteSpace(search))
            {

                foreach (Person person in personList)
                {
                    if (type == "city")
                    {
                        if (person.City.CityName.Contains(search))
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
            }
            return filteredList;
        }

        public List<Person> Sort(string sorting)
        {
            List<Person> personList = All();
            List<Person> sortedList;

            switch (sorting)
            {
                case "nameAsc":
                    sortedList = personList.OrderBy(o => o.Name).ToList(); ;
                    break;

                case "nameDes":
                    sortedList = personList.OrderByDescending(o => o.Name).ToList();
                    break;

                case "cityAsc":
                    sortedList = personList.OrderBy(o => o.City.CityName).ToList();
                    break;

                default:
                    sortedList = personList.OrderByDescending(o => o.City.CityName).ToList();
                    break;
            }

            return sortedList;
        }

        public void RemoveLanguage(Person person, int langId)
        {
           PersonLanguage language = person.PersonLanguages.SingleOrDefault(persLang => persLang.LanguageId == langId);
           person.PersonLanguages.Remove(language);
            _peopleRepo.Update(person);
        }

        public void AddLanguage(Person person, int langId)
        {
           PersonLanguage language = new PersonLanguage()
            {
                LanguageId = langId,
                PersonId = person.Id
            };

            person.PersonLanguages.Add(language);

            _peopleRepo.Update(person);
        }

       
    }
}

