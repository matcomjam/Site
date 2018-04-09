using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CodeFirstDatabase;
using DAL;
using Microsoft.AspNetCore.Mvc;
using QuickApp.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuickApp.Controllers
{
    //[Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/values
        [HttpGet]
        [Route("api/Comment/Index")]
        public IActionResult Get(int blogId)
        {
            var allComment = _unitOfWork.Comments.GetAllComments(blogId);
            var commentViewModels = new List<CommentViewModel>();
            foreach (var comment in allComment)
            {
                var commentVM = Mapper.Map<CommentViewModel>(comment);
                commentViewModels.Add(commentVM);
            }
            return Ok(commentViewModels);
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost]
        [Route("api/Comment/Save")]
        public IActionResult Post([FromBody]Comment comment)
        {
            return Json(_unitOfWork.Comments.SaveComment(comment));
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
