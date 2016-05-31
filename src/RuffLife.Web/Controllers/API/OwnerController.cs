﻿using System.Web.Http;
using RuffLife.Core.Services.Interfaces;

namespace RuffLife.Web.Controllers.API
{
    [RoutePrefix("api/owners")]
    public class OwnerController : ApiController
    {
        public readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [Route("get-all")]
        [HttpGet]
        public IHttpActionResult GetAllUSers()
        {
            var owners = _ownerService.GetAllOwners();
            return Ok(owners);
        }
    }
}
