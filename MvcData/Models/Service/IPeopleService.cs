using MvcData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.Service
{
    interface IPeopleService
    {
        Person Add(CreatePersonViewModel person);
        List<Person> All();
        List<Person> Search(string search, string type);
        Person FindById(int id);
        bool Edit(int id, CreatePersonViewModel person);
        bool Remove(int id);
    }
}
