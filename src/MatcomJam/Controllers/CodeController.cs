using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MatcomJamDAL.Models.MyModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuickApp.Controllers
{
    //[Route("api/[controller]")]
    public class CodeController : Controller
    {
        private readonly IHostingEnvironment _host;
        private readonly int MAX_BYTES = 10 * 1024 * 1024;
        private readonly string[] ACCEPTED_FILE_TYPE = new[] { ".cpp", ".cs", ".py", ".java" };

        public CodeController(IHostingEnvironment host)
        {
            _host = host;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Route("api/problems/{problemId}/code")]
        public async Task<IActionResult> Upload(int problemId, IFormFile sourceFile)
        {
            if (sourceFile == null) return BadRequest("Null File");
            if (sourceFile.Length == 0) return BadRequest("Empty File");
            if (sourceFile.Length > MAX_BYTES) return BadRequest("Max File Size Exceeded");
            if (ACCEPTED_FILE_TYPE.All(s => s != Path.GetExtension(sourceFile.FileName)))
                return BadRequest("Invalid wndfnlkdsnvndsv file type");

            var uploadsFolderPath = Path.Combine(_host.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(sourceFile.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await sourceFile.CopyToAsync(stream);
            }

            var code = new Code { FileName = fileName };
            return Ok(code);
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
