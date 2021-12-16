using MvcData.Models.Repos;
using MvcData.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.Service
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepo _languageRepo;
        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }
        public Language Create(CreateLanguageViewModel createLanguage)
        {
            if (string.IsNullOrWhiteSpace(createLanguage.Name))
            {
                throw new ArgumentException("Language cannot consist of backsapce and whitespace");
            }

            Language language = new Language()
            {
                Name = createLanguage.Name,                
            };
            _languageRepo.Create(language);
            return language;
        }

        public bool Edit(int id, CreateLanguageViewModel editLanguage)
        {
            Language currentLanguage = FindById(id);

            if (currentLanguage == null)
            {
                return false;
            }

            currentLanguage.Name = editLanguage.Name;

            return _languageRepo.Update(currentLanguage);
        }

        public Language FindById(int id)
        {
            return _languageRepo.FindById(id);
        }

        public List<Language> GetAll()
        {
            return _languageRepo.GetAll();
        }

        public bool Remove(int id)
        {
            Language language = _languageRepo.FindById(id);
            if (language == null)
            {
                return false;
            }
           
            return _languageRepo.Delete(language);
        }
    }
}
