using MvcData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.Service
{
    public interface ILanguageService
    {
        Language Create(CreateLanguageViewModel createLanguage);
        List<Language> GetAll();
        Language FindById(int id);     
        bool Edit(int id, CreateLanguageViewModel languageViewModel);
        bool Remove(int id);
    }
}
