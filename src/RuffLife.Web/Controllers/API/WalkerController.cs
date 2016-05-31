using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RuffLife.Core.Services.Interfaces;

namespace RuffLife.Web.Controllers.API
{
    [RoutePrefix("walker")]
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
            var user = _walkerService.GetWalker(id);
            if (user != null)
                return Ok(user);
            return BadRequest("Walker with that Id doesnt exist");
        }
    }
}
