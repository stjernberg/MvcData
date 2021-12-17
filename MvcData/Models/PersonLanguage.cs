using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcData.Models
{
    public class PersonLanguage
    {
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
