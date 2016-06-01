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
    [RoutePrefix("api/walkers")]
    public class WalkerController : ApiController
    {
        private readonly IWalkerService _walkerService;
        private readonly IWalkService _walkService;

        public WalkerController(IWalkerService walkerService, IWalkService walkService)
        {
            _walkerService = walkerService;
            _walkService = walkService;
        }

        [Route("get/{id}")]
        [HttpGet]
        public IHttpActionResult GetSingleWalker(int id)
        {
            var walker = _walkerService.GetWalker(id);
            if (walker != null)
                return Ok(walker);
            return BadRequest("Walker with that Id doesnt exist");
        }

        [Route("all")]
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

        [Route("{walkerId}/walks")]
        [HttpGet]
        public IHttpActionResult GetWalksByWalker(int walkerId)
        {
            var walks = _walkService.GetWalksByWalker(walkerId);
            return Ok(walks);
        }

        [Route("search/{query}")]
        [HttpGet]
        public IHttpActionResult GetWalkersByLocation(string query)
        {
            var walkers = _walkerService.GetWalkersByLocation(query);
            return Ok(walkers);
        }

        protected override void Dispose(bool disposing)
        {
            _walkerService.Dispose();
            _walkService.Dispose();
            base.Dispose(disposing);
        }
    }
}
