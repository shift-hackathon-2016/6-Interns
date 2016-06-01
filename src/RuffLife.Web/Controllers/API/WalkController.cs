using RuffLife.Core.Models.Walk;
using RuffLife.Core.Services.Interfaces;
using System.Web.Http;

namespace RuffLife.Web.Controllers.API
{
    [RoutePrefix("api/walks")]
    public class WalkController : ApiController
    {
        private readonly IWalkService _walkService;
        private readonly IDogService _dogService;

        public WalkController(IWalkService walkService, IDogService dogService)
        {
            _walkService = walkService;
            _dogService = dogService;
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
        public void CreateWalk(CreateWalkDto newWalk)
        {
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
