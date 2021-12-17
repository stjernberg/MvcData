using MvcData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.Service
{
    public interface IPeopleService
    {
        Person Add(CreatePersonViewModel person);
        List<Person> All();
        List<Person> Search(string search, string type);
        Person FindById(int id);
         void Edit(int id, CreatePersonViewModel person);
        void Remove(int id);
        List<Person> Sort(string sorting);
        LanguageConnectionViewModel languageConnection(Person person);

    }
}
