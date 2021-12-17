using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.ViewModels
{
    public class LanguageConnectionViewModel
    {
        public Person Person { get; }
        public List<Language> AllLanguages { get; }
        public List<Language> SpokenLanguages { get; }
        public LanguageConnectionViewModel()
        {            
            SpokenLanguages = new List<Language>();
            AllLanguages = new List<Language>();
            Person = Person;
        }

        
    }
}
