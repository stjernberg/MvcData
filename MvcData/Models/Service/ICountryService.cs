using MvcData.Models.ViewModels;
using System.Collections.Generic;

namespace MvcData.Controllers
{
    public  interface ICountryService
    {
        List<Country> GetAll();
        Country FindById(int id);
        Country Create(CreateCountryViewModel createCountry);
        bool Edit(int id, CreateCountryViewModel countryViewModel);
        bool Remove(int id);
    }
}