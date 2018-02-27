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
    public class ContestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContestController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        // GET: api/values
        [HttpGet]
        [Produces(typeof(List<ContestViewModel>))]
        public IActionResult Get()
        {
            var allContests = _unitOfWork.Contests.GetAllContests();
            var contestViewModels = new List<ContestViewModel>();
            foreach (var contest in allContests)
            {
                var contestVM = Mapper.Map<ContestViewModel>(contest);
                contestViewModels.Add(contestVM);
            }

            return Ok(contestViewModels);
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
