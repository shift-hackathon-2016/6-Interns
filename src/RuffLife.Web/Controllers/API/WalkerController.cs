using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RuffLife.Core.Services.Interfaces;
using RuffLife.Core.Models.Walker;

namespace RuffLife.Web.Controllers.API
{
    [RoutePrefix("api/walker")]
    public class WalkerController : ApiController
    {
        private readonly IWalkerService _walkerService;

        public WalkerController(IWalkerService walkerService)
        {
            _walkerService = walkerService;
        }

        [Route("get-single/{id}")]
        [HttpGet]
        public IHttpActionResult GetSingleWalker(int id)
        {
            var walker = _walkerService.GetWalker(id);
            if (walker != null)
                return Ok(walker);
            return BadRequest("Walker with that Id doesnt exist");
        }

        [Route("get-all")]
        [HttpGet]
        public IHttpActionResult GetAllWalkers()
        {
            var walkers = _walkerService.GetAllWalkers();
            return Ok(walkers);
        }

        [Route("create")]
        [HttpPost]
        public void CreateWalker(CreateWalkerDto walker)
        {
            _walkerService.CreateWalker(walker);
        }
    }
}
