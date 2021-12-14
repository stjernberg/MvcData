using MvcData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.Service
{
    public interface ICityService
    {
      
        List<City> GetAll();
       City FindById(int id);
        City Create(CreateCityViewModel createCity);
        bool Edit(int id, CreateCityViewModel cityViewModel);
        bool Remove(int id);
    }
}
