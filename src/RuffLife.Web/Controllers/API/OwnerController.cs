using System.Web.Http;
using RuffLife.Core.Services.Interfaces;
using RuffLife.Core.Models.Owner;

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

        [Route("create")]
        [HttpPost]
        public void CreateOwner(CreateOwnerDto owner)
        {
            _ownerService.CreateOwner(owner);
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
    }
}
