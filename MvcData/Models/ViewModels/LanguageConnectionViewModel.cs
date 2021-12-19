using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models.ViewModels
{
    public class LanguageConnectionViewModel
    {

        public Person Person { get; set; }
        public List<Language> AllLanguages { get; set; }
        public List<Language> SpokenLanguages { get; set; }
        public LanguageConnectionViewModel()
        {            
            SpokenLanguages = new List<Language>();
            AllLanguages = new List<Language>();
         }

        
    }
}
