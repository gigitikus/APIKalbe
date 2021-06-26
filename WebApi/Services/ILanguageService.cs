using APIKalbe.Models;
using System.Collections.Generic;

namespace APIKalbe.Services
{
    public interface ILanguageService
    {
        List<Master.Language> GetLanguages();
    }
}
