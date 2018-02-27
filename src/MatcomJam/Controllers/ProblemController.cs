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
    [Route("api/[controller]")]
    public class ProblemController : Controller
    {
        private IUnitOfWork _unitOdfOfWork;

        public ProblemController(IUnitOfWork unitOfWork)
        {
            _unitOdfOfWork = unitOfWork;
        }

        // GET: api/values
        [HttpGet]
        [Produces(typeof(List<ProblemViewModel>))]
        public IActionResult Get()
        {
            var allProblems = _unitOdfOfWork.Problems.GetAllProblems();
            var problemViewModels = new List<ProblemViewModel>();
            foreach (var problem in allProblems)
            {
                var problemVM = Mapper.Map<ProblemViewModel>(problem);
                problemViewModels.Add(problemVM);
            }

            return Ok(problemViewModels);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value" + id;
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
