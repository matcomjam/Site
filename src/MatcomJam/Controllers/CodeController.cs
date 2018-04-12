using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using MatcomJamDAL.Models.MyModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickApp.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuickApp.Controllers
{
    //[Route("api/[controller]")]
    public class CodeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CodeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //private readonly IHostingEnvironment _host;
        private readonly int MAX_BYTES = 10 * 1024 * 1024;
        private readonly string[] ACCEPTED_FILE_TYPE = new[] { ".cpp", ".cs", ".py", ".java" };

        //public CodeController(IHostingEnvironment host)
        //{
        //    _host = host;
        //}

        // GET: api/values
        [HttpGet]
        [Route("api/Code/Index")]
        public IActionResult Get()
        {
            var code = _unitOfWork.Codes.GetNextPendingCode();
            var codeVM = Mapper.Map<CodeViewModel>(code);
            return Ok(codeVM);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/values
        //[HttpPost]
        //[Route("api/problems/{problemId}/code")]
        //public async Task<IActionResult> Upload(Code model)
        //{
        //    if (model.file == null) return BadRequest("Null File");
        //    if (model.file.Length == 0) return BadRequest("Empty File");
        //    if (model.file.Length > MAX_BYTES) return BadRequest("Max File Size Exceeded");

        //    var extension = Path.GetExtension(model.file.FileName);
        //    if (ACCEPTED_FILE_TYPE.All(s => s != extension))
        //        return BadRequest("Invalid file type");

        //    //var uploadsFolderPath = Path.Combine(_host.WebRootPath, "uploads");
        //    //if (!Directory.Exists(uploadsFolderPath))
        //    //    Directory.CreateDirectory(uploadsFolderPath);

        //    //var fileName = Guid.NewGuid().ToString() + Path.GetExtension(sourceFile.FileName);
        //    //var filePath = Path.Combine(uploadsFolderPath, fileName);
        //    //var fileName = $"Main{extension}";
        //    //var text = new StreamReader(sourceFile.OpenReadStream()).ReadToEnd();
        //    //var status = "PENDING";
        //    //var lang = languageId;
        //    //var user = UserId;

        //    var code = new Code
        //    {
        //        Id = model.Id,
        //        file = model.file,
        //        FileName = $"Main{extension}",
        //        Text = new StreamReader(model.file.OpenReadStream()).ReadToEnd(),
        //        Status = "PENDING",
        //        ProblemId = model.ProblemId,
        //        LanguageId = model.LanguageId,
        //        UserId = model.UserId
        //    };

        //    //using (var stream = new FileStream(filePath, FileMode.Create))
        //    //{

        //    //   // await sourceFile.CopyToAsync(stream);
        //    //}

        //    //var code = new Code { FileName = fileName };
        //    return Json(_unitOfWork.Codes.SaveCode(code));
        //}


        //string userId, int problemId, int languageId, 
        [HttpPost]
        [Route("api/Code/Save")]
        public IActionResult Upload(string userId, int problemId, int languageId, IFormFile file)
        {
            if (file == null) return BadRequest("Null File");
            if (file.Length == 0) return BadRequest("Empty File");
            if (file.Length > MAX_BYTES) return BadRequest("Max File Size Exceeded");

            var extension = Path.GetExtension(file.FileName);
            if (ACCEPTED_FILE_TYPE.All(s => s != extension))
                return BadRequest("Invalid file type");

            //var uploadsFolderPath = Path.Combine(_host.WebRootPath, "uploads");
            //if (!Directory.Exists(uploadsFolderPath))
            //    Directory.CreateDirectory(uploadsFolderPath);

            //var fileName = Guid.NewGuid().ToString() + Path.GetExtension(sourceFile.FileName);
            //var filePath = Path.Combine(uploadsFolderPath, fileName);
            //var fileName = $"Main{extension}";
            //var text = new StreamReader(sourceFile.OpenReadStream()).ReadToEnd();
            //var status = "PENDING";
            //var lang = languageId;
            //var user = UserId;

            var code = new Code
            {
                file = file,
                FileName = $"Main{extension}",
                Text = new StreamReader(file.OpenReadStream()).ReadToEnd(),
                Status = "PENDING",
                ProblemId = problemId,
                LanguageId = languageId,
                UserId = userId
            };

            //using (var stream = new FileStream(filePath, FileMode.Create))
            //{

            //   // await sourceFile.CopyToAsync(stream);
            //}

            //var code = new Code { FileName = fileName };
            return Json(_unitOfWork.Codes.SaveCode(code));
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
