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

        [Route("all")]
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

        [Route("get/{id}")]
        [HttpGet]
        public IHttpActionResult GetSingleOwner(int id)
        {
            var owner = _ownerService.GetOwner(id);
            if (owner != null)
                return Ok(owner);
            return BadRequest("Owner with that Id doesnt exist");
        }

        [Route("get/{ownerId}/dogs/create")]
        [HttpPost]
        public void CreateDog(CreateDogDto newDog, int ownerId)
        {
            newDog.Owner = _ownerService.GetOwner(ownerId);
            _dogService.CreateDog(newDog);
        }

        [Route("get/{ownerId}/dogs/update/{Id}")]
        [HttpPost]
        public void UpdateDog(UpdateDogDto updatedDog)
        {
            _dogService.UpdateDog(updatedDog);
        }

        [Route("get/{ownerId}/dogs/delete/{Id}")]
        [HttpPost]
        public void DeleteDog(int dogId)
        {
            _dogService.DeleteDog(dogId);
        }

        [Route("get/{ownerId}/dogs")]
        [HttpGet]
        public IHttpActionResult GetDogsByOwner(int ownerId)
        {
            var dogs = _dogService.GetDogsByOwner(ownerId);
            return Ok(dogs);
        }
    }
}
