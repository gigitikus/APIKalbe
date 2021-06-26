using APIKalbe.Models;
using APIKalbe.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APIKalbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Language/GetLanguages")]
        public IEnumerable<Master.Language> GetLanguages()
        {
            return _languageService.GetLanguages().OrderBy(s => s.OrderNo);
        }
    }
}
