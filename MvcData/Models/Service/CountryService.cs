using MvcData.Models.Repos;
using MvcData.Controllers;
using MvcData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepo _countryRepo;
        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public Country Create(CreateCountryViewModel createCountry)
        {
            if (string.IsNullOrWhiteSpace(createCountry.Name))
            {
                throw new ArgumentException("Country cannot consist of backsapce and whitespace");
            }

            Country country = new Country()
            {
                Name = createCountry.Name,
            };
            return _countryRepo.Create(country);
        }

        public bool Edit(int id, CreateCountryViewModel countryToEdit)
        {
            Country currentCountry = FindById(id);

            if (currentCountry == null)
            {
                return false;
            }

            currentCountry.Name = countryToEdit.Name;

            return _countryRepo.Update(currentCountry);
        }

        public Country FindById(int id)
        {
            return _countryRepo.FindById(id);
        }

        public List<Country> GetAll()
        {
            return _countryRepo.GetAll();
        }

        public bool Remove(int id)
        {
            Country country = _countryRepo.FindById(id);
            if (country != null)
            {
                return _countryRepo.Delete(country);
            }
            return false;
        }
    }
}
