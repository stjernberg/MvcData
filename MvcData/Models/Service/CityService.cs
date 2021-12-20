using MvcData.Models.Repos;
using MvcData.Models.ViewModels;
using MvcData.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.Service
{
    public class CityService : ICityService
    {
        private readonly ICityRepo _cityRepo;
        public CityService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public City Create(CreateCityViewModel createCity)
        {
            if (string.IsNullOrWhiteSpace(createCity.CityName))
            {
                throw new ArgumentException("City cannot consist of backsapce and whitespace");
            }

            City city = new City()
            {
                CityName = createCity.CityName,
                CountryId = createCity.CountryId

            };
            return _cityRepo.Create(city);
        }
        

        public bool Edit(int id, CreateCityViewModel cityToEdit)
        {
            City currentCity = FindById(id);

            if (currentCity == null)
            {
                return false;
            }

            currentCity.CityName = cityToEdit.CityName;

            return _cityRepo.Update(currentCity);
        }

       

        public City FindById(int id)
        {
            return _cityRepo.FindById(id);
        }

        public List<City> GetAll()
        {
            return _cityRepo.GetAll();
        }

        public bool Remove(int id)
        {
            City city = _cityRepo.FindById(id);
         
            if (city != null)
            {
                return _cityRepo.Delete(city);
            }
            return false;
        }

    }
}
