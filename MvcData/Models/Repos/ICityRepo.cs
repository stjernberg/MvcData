using MvcData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.Repos
{
    public interface ICityRepo
    {
        City Create(City city);
        City FindById(int id);
        List<City> GetAll();
        bool Update(City city);
        bool Delete(City city);
    }
}
