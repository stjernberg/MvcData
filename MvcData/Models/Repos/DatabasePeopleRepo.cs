using MvcData.Models.Data;
using MvcData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MvcData.Models.Repos
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
      readonly PeopleDbContext _peopleDbContext;

        public DatabasePeopleRepo (PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public Person Create(Person person)
        {
           
            _peopleDbContext.People.Add(person);
            _peopleDbContext.SaveChanges();
            return person;
        }
              

        public List<Person> GetAll()
        {
            return _peopleDbContext.People.ToList();
        }

        public Person GetById(int id)
        {
            return _peopleDbContext.People.SingleOrDefault(person => person.Id == id);
        }

        public void Update(Person person)
        {
                _peopleDbContext.People.Update(person);
                _peopleDbContext.SaveChanges();
         
            
        }

        public void Delete(Person person)
        {
            
                _peopleDbContext.People.Remove(person);
                _peopleDbContext.SaveChanges();
          
        }
    }
}
