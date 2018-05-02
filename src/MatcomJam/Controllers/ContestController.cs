using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CodeFirstDatabase;
using DAL;
using MatcomJamDAL.Models.MyModel;
using Microsoft.AspNetCore.Mvc;
using MatcomJam.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatcomJam.Controllers
{
    //[Route("api/[controller]")]
    public class ContestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContestController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        // GET: api/values
        [HttpGet]
        [Route("api/Contest/Index2")]
        [Produces(typeof(List<ContestViewModel>))]
        public async Task<IActionResult> Get(Filter filter, int offset, int limit)
        {
            var allContests = _unitOfWork.Contests.GetAllContests(filter, offset, limit);
            var contestViewModels = new List<ContestViewModel>();
            foreach (var contest in allContests)
            {
                var contestVM = Mapper.Map<ContestViewModel>(contest);
                contestViewModels.Add(contestVM);
            }

            return Ok(contestViewModels);
        }

        [HttpGet]
        [Route("api/Contest/Index")]
        [Produces(typeof(List<ContestViewModel>))]
        public IActionResult Get(Filter filter)
        {
            return Ok(_unitOfWork.Contests.GetContestCount(filter));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Route("api/Contest/Index/{id}")]
        public IActionResult Get(int id)
        {
            var contest = _unitOfWork.Contests.GetContest(id);
            var contestVM = Mapper.Map<ContestViewModel>(contest);
            return Ok(contestVM);
        }

        // POST api/values
        [HttpPost]
        [Route("api/Contest/Save")]
        public IActionResult Post([FromBody]Contest contest)
        {
            return Json(_unitOfWork.Contests.SaveContest(contest));
        }

        // PUT api/values/5
        [HttpPut]
        [Route("api/Contest/Update")]
        public IActionResult Put([FromBody]Contest contest)
        {
            return Json(_unitOfWork.Contests.SaveContest(contest));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Route("api/Contest/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Json(_unitOfWork.Contests.DeleteContestById(id));
        }
    }
}
