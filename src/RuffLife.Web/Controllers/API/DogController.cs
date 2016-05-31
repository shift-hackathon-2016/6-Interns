using RuffLife.Core.Models.ReviewForDog;
using RuffLife.Core.Services.Interfaces;
using System.Web.Http;

namespace RuffLife.Web.Controllers.API
{
    [RoutePrefix("api/dogs")]
    public class DogController : ApiController
    {
        private readonly IDogService _dogService;
        private readonly IReviewForDogService _reviewForDogService;

        public DogController(IDogService dogService, IReviewForDogService reviewForDogService)
        {
            _dogService = dogService;
            _reviewForDogService = reviewForDogService;
        }

        [Route("{dogId}/reviews")]
        [HttpGet]
        public IHttpActionResult GetReviewsForDogByDog(int dogId)
        {
            var reviewsForDogs = _reviewForDogService.GetReviewsForDogByDog(dogId);
            return Ok(reviewsForDogs);
        }

        [Route("{dogId}/reviews/create")]
        [HttpPost]
        public void CreateReviewForDog(CreateReviewForDogDto newReviewForDog, int dogId)
        {
            newReviewForDog.Dog = _dogService.GetDog(dogId);
            _reviewForDogService.CreateReviewForDog(newReviewForDog);
        }

        [Route("get/{Id}")]
        [HttpGet]
        public IHttpActionResult GetDog(int Id)
        {
            var dog = _dogService.GetDog(Id);
            return Ok(dog);
        }
    }
}
