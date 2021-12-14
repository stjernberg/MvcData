using MvcData.Models.Data;
using MvcData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.Repos
{
    public class DatabaseCountryRepo : ICountryRepo
    {
        private PeopleDbContext _peopleDbContext;

        public DatabaseCountryRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public Country Create(Country country)
        {
            _peopleDbContext.Countries.Add(country);
            _peopleDbContext.SaveChanges();
            return country;
        }
      
        public bool Delete(Country country)
        {
            
            _peopleDbContext.Countries.Remove(country);
            int saveChanges =_peopleDbContext.SaveChanges();
            if(saveChanges == 0)
            {
                return false;
            }

            return true;
        }

        public List<Country> GetAll()
        {
            return _peopleDbContext.Countries.ToList();
        }

        public Country FindById(int id)
        {
            return _peopleDbContext.Countries.SingleOrDefault(country => country.Id == id);
        }

        public bool Update(Country country)
        {
            _peopleDbContext.Countries.Update(country);
            int updateChanges = _peopleDbContext.SaveChanges();
            if (updateChanges == 0)
            {
                return false;
            }

            return true;
        }
    }
}
