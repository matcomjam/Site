﻿using System;
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
    public class BlogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/values
        [HttpGet]
        [Route("api/BLog/Index2/")]
        [Produces(typeof(List<BlogViewModel>))]
        public IActionResult Get(int offset, int limit)
        {
            var allBlogs = _unitOfWork.Blogs.GetAllBlogs(offset, limit);
            var blogViewModels = new List<BlogViewModel>();
            foreach (var contest in allBlogs)
            {
                var blogVM = Mapper.Map<BlogViewModel>(contest);
                blogViewModels.Add(blogVM);
            }

            return Ok(blogViewModels);
        }

        // GET: api/values
        [HttpGet]
        [Route("api/BLog/Index")]
        [Produces(typeof(List<BlogViewModel>))]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.Blogs.GetBlogCount());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Route("api/BLog/Index/{id}")]
        public IActionResult Get(int id)
        {
            var blog = _unitOfWork.Blogs.GetBlog(id);
            var blogVM = Mapper.Map<BlogViewModel>(blog);
            return Ok(blogVM);
        }

        // POST api/values
        [HttpPost]
        [Route("api/BLog/Save")]
        public IActionResult Post([FromBody]Blog blog)
        {
            return Json(_unitOfWork.Blogs.SaveBlog(blog));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Route("api/BLog/Update")]
        public IActionResult Put([FromBody]Blog blog)
        {
            return Json(_unitOfWork.Blogs.SaveBlog(blog));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Route("api/BLog/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Json(_unitOfWork.Blogs.DeleteBlog(id));
        }
    }
}
