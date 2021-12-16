using MvcData.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.Repos
{
    public class DatabaseLanguageRepo : ILanguageRepo
    {
        private PeopleDbContext _peopleDbContext;
        public DatabaseLanguageRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        public Language Create(Language language)
        {
            _peopleDbContext.Languages.Add(language);
            if (_peopleDbContext.SaveChanges() > 0)
            {
                return language;
            }
            return null;
         }

       
        public List<Language> GetAll()
        {
            return _peopleDbContext.Languages.ToList();
        }

        public Language FindById(int id)
        {
            return _peopleDbContext.Languages.SingleOrDefault(language => language.Id == id);
        }

        public bool Update(Language language)
        {
            _peopleDbContext.Languages.Update(language);           
            if (_peopleDbContext.SaveChanges() == 0)
            {
                return false;
            }

            return true;
        }

        public bool Delete(Language language)
        {
            _peopleDbContext.Languages.Remove(language);
           if (_peopleDbContext.SaveChanges() == 0)
            {
                return false;
            }

            return true;
        }

        
    }
}
