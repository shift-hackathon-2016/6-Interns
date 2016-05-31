using System.Web.Http;
using RuffLife.Core.Services.Interfaces;
using RuffLife.Core.Models.Owner;
using RuffLife.Core.Models.Dog;

namespace RuffLife.Web.Controllers.API
{
    [RoutePrefix("api/owners")]
    public class OwnerController : ApiController
    {
        public readonly IOwnerService _ownerService;
        public readonly IDogService _dogService;

        public OwnerController(IOwnerService ownerService, IDogService dogService)
        {
            _ownerService = ownerService;
            _dogService = dogService;
        }

        [Route("get-all")]
        [HttpGet]
        public IHttpActionResult GetAllUSers()
        {
            var owners = _ownerService.GetAllOwners();
            return Ok(owners);
        }

        [Route("create")]
        [HttpPost]
        public void CreateOwner(CreateOwnerDto newOwner)
        {
            _ownerService.CreateOwner(newOwner);
        }

        [Route("get-single/{id}")]
        [HttpGet]
        public IHttpActionResult GetSingleOwner(int id)
        {
            var owner = _ownerService.GetOwner(id);
            if (owner != null)
                return Ok(owner);
            return BadRequest("Owner with that Id doesnt exist");
        }

        [Route("get-single/{ownerId}/create-dog")]
        [HttpPost]
        public void CreateDog(CreateDogDto newDog, int ownerId)
        {
            newDog.Owner = _ownerService.GetOwner(ownerId);
            _dogService.CreateDog(newDog);
        }
    }
}
