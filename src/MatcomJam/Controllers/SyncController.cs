using System;
using System.Collections.Generic;
using DAL;
using MatcomJamDAL.Models.MyModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatcomJam.Controllers
{
    public class SyncController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SyncController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/values
        [HttpGet]
        [Route("api/Sync/Index")]
        public IEnumerable<SyncServer> Get()
        {
            throw new Exception();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Route("api/Sync/Index/{id}")]
        public IActionResult Get(int id)
        {
            var obj = _unitOfWork.SyncServers.GetSyncServer(id);
            return Ok(obj);
        }

        // POST api/values
        [HttpPost]
        [Route("api/Sync/Save")]
        public IActionResult Post([FromBody]SyncServer sync)
        {
            return Json(_unitOfWork.SyncServers.SaveSyncServer(sync));
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
