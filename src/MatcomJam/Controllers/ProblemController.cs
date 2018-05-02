using System.Collections.Generic;
using System.Linq;
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
    public class ProblemController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public ProblemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/values
        [HttpGet]
        [Route("api/Problem/Index2")]
        [Produces(typeof(List<ProblemViewModel>))]
        public IActionResult Get(Filter filter, int offset, int limit)
        {
            var allProblems = _unitOfWork.Problems.GetAllProblems(filter, offset, limit);
            var problemViewModels = allProblems.Select(Mapper.Map<ProblemViewModel>).ToList();
            //var problemViewModels = new List<ProblemViewModel>();
            //foreach (var problem in allProblems)
            //{
            //    var problemVM = Mapper.Map<ProblemViewModel>(problem);
            //    problemViewModels.Add(problemVM);
            //}

            return Ok(problemViewModels);
        }

        [HttpGet]
        [Route("api/Problem/Index")]
        [Produces(typeof(List<ProblemViewModel>))]
        public IActionResult Get(Filter filter)
        {
            return Ok(_unitOfWork.Problems.GetProblemCount(filter));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Route("api/Problem/Index/{id}")]
        public IActionResult Get(int id)
        {
            var problem = _unitOfWork.Problems.GetProblem(id);
            var problemVM = Mapper.Map<ProblemViewModel>(problem);
            return Ok(problemVM);
        }

        // POST api/values
        [HttpPost]
        [Route("api/Problem/Save")]
        //[Produces(typeof(Problem))]
        public IActionResult Post([FromBody]Problem problem)
        {
            //var p = Mapper.Map<Problem>(problem);
            return Json(_unitOfWork.Problems.SaveProblem(problem));
            //return Ok(p);
            //return CreatedAtRoute("DefaultApi", new { id = problem.Id }, problem);
        }

        // PUT api/values/5
        [HttpPut]
        [Route("api/Problem/Update")]
        public IActionResult Edit([FromBody]Problem problem)
        {
            //var p = Mapper.Map<Problem>(problem);
            return Json(_unitOfWork.Problems.SaveProblem(problem));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Route("api/Problem/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Json(_unitOfWork.Problems.DeleteProblemById(id));
        }
    }
}
