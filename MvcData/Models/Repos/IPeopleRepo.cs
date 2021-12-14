using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.Repos
{
    public interface IPeopleRepo
    {
        Person Create(Person person);
        List<Person> GetAll();

        Person GetById(int id);
       
        void Delete(Person person);
        void Update(Person person);
    }
}
