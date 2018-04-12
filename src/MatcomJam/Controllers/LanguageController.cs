using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using Microsoft.AspNetCore.Mvc;
using QuickApp.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuickApp.Controllers
{
    //[Route("api/[controller]")]
    public class LanguageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LanguageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/values
        [HttpGet]
        [Route("api/Language/Index")]
        public IActionResult Get()
        {
            var allLanguages = _unitOfWork.Languages.GetAllLanguages();
            var languageViewModels = new List<LanguageViewModel>();
            foreach (var language in allLanguages)
            {
                var languageVM = Mapper.Map<LanguageViewModel>(language);
                languageViewModels.Add(languageVM);
            }
            return Ok(languageViewModels);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
