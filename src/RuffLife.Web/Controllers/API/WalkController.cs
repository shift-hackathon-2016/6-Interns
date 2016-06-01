using System;
using System.Collections.Generic;
using RuffLife.Core.Models.Walk;
using RuffLife.Core.Services.Interfaces;
using System.Web.Http;
using RuffLife.Core.Models.Dog;
using RuffLife.Core.Models.Owner;
using RuffLife.Core.Models.Walker;
using RuffLife.Data.Models;

namespace RuffLife.Web.Controllers.API
{
    [RoutePrefix("api/walks")]
    public class WalkController : ApiController
    {
        private readonly IWalkService _walkService;
        private readonly IDogService _dogService;
        private readonly IOwnerService _ownerService;
        private readonly IWalkerService _walkerService;

        public WalkController(IWalkService walkService, 
            IDogService dogService,
            IOwnerService ownerService,
            IWalkerService walkerService)
        {
            _walkService = walkService;
            _dogService = dogService;
            _ownerService = ownerService;
            _walkerService = walkerService;
        }

        [Route("get/{Id}")]
        [HttpGet]
        public IHttpActionResult GetWalk(int Id)
        {
            var walk = _walkService.GetWalk(Id);
            return Ok(walk);
        }

        [Route("create")]
        [HttpPost]
        public void CreateWalk(dynamic newWalk)
        {
            var ownerId = int.Parse(newWalk["user"]["Id"]);
            var owner = _ownerService.GetOwner(ownerId);
            var walker = _walkerService.GetWalker(int.Parse(newWalk["walker"]));

            var walk = new CreateWalkDto()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.Add(new TimeSpan(1, 0, 0)),
                Location = owner.Location,
                IsFinished = false,
                Walker = walker,
                Dogs = owner.Dogs
                };
            _walkService.CreateWalk(newWalk);
        }

        [Route("update/{Id}")]
        [HttpPost]
        public void UpdateWalk(UpdateWalkDto updatedWalk)
        {
            _walkService.UpdateWalk(updatedWalk);
        }

        [Route("{walkId}/dogs")]
        [HttpGet]
        public IHttpActionResult GetDogsByWalk(int walkId)
        {
            var dogs = _dogService.GetDogsByWalk(walkId);
            return Ok(dogs);
        }
    }
}
