using System;
using System.Collections.Generic;
using System.Linq;
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

        [Route("{walkerId}/createWalk")]
        [HttpPost]
        public IHttpActionResult CreateWalk(ViewOwnerDto newWalk, int walkerId)
        {

            var walk = new CreateWalkDto()
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.Add(new TimeSpan(1, 0, 0)),
                Walker = _walkerService.GetWalker(walkerId),
                Dogs = _dogService.GetDogsByOwner(newWalk.Id),
                IsFinished = false,
                Location = newWalk.Location
            };

            _walkService.CreateWalk(walk);
            return Ok();
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
