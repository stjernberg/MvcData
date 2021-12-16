using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.Repos
{
    public interface ILanguageRepo
    {
        Language Create(Language language);
        Language FindById(int id);
        List<Language> GetAll();
        bool Update(Language language);
        bool Delete(Language language);
    }
}
