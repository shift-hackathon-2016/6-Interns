using RuffLife.Core.Services.Interfaces;
using System.Web.Http;

namespace RuffLife.Web.Controllers.API
{
    [RoutePrefix("api/dogs")]
    public class DogController : ApiController
    {
        private readonly IDogService _dogService;
        private readonly IWalkService _walkService;

        public DogController(IDogService dogService,  IWalkService walkService)
        {
            _dogService = dogService;
            _walkService = walkService;
        }

        [Route("get/{Id}")]
        [HttpGet]
        public IHttpActionResult GetDog(int Id)
        {
            var dog = _dogService.GetDog(Id);
            return Ok(dog);
        }

        [Route("{dogId}/walks")]
        [HttpGet]
        public IHttpActionResult GetWalksByDog(int dogId)
        {
            var walks = _walkService.GetWalksByDog(dogId);
            return Ok(walks);
        }
    }
}
