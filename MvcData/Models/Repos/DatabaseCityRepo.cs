using Microsoft.EntityFrameworkCore;
using MvcData.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.Repos
{
    public class DatabaseCityRepo : ICityRepo
    {
        private PeopleDbContext _peopleDbContext;

        public DatabaseCityRepo(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }
        public City Create(City city)
        {
            _peopleDbContext.Cities.Add(city);
            _peopleDbContext.SaveChanges();
            return city;
        }

        public bool Delete(City city)
        {
         
                _peopleDbContext.Cities.Remove(city);
            int saveChanges = _peopleDbContext.SaveChanges();
            if (saveChanges == 0)
            {
                return false;
            }

            return true;
        }

        public List<City> GetAll()
        {
            return _peopleDbContext.Cities.Include(city => city.Country).ToList();
        }

        public City FindById(int id)
        {
            return _peopleDbContext.Cities.SingleOrDefault(city => city.Id == id);
        }
       

        public bool Update(City city)
        {
          
            _peopleDbContext.Cities.Update(city);
            int updateChanges = _peopleDbContext.SaveChanges();
            if (updateChanges == 0)
            {
                return false;
            }

            return true;
        }
    }
}
