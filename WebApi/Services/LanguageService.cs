using APIKalbe.DBContext;
using APIKalbe.Models;
using System.Collections.Generic;
using System.Linq;

namespace APIKalbe.Services
{

    public class LanguageService : ILanguageService
    {
        public LanguageContext _languageDBContext;
        public LanguageService(LanguageContext languageContext)
        {
            _languageDBContext = languageContext;
        }
        public List<Master.Language> GetLanguages()
        {
            return _languageDBContext.Language.ToList();
        }
    }
}
