using RuffLife.Core.Models.ReviewForDog;
using RuffLife.Core.Services.Interfaces;
using System.Web.Http;

namespace RuffLife.Web.Controllers.API
{
    [RoutePrefix("api/review-for-dogs")]
    public class ReviewForDogController : ApiController
    {
        public readonly IReviewForDogService _reviewForDogService;

        public ReviewForDogController(IReviewForDogService reviewForDogService)
        {
            _reviewForDogService = reviewForDogService;
        }

        [Route("create")]
        [HttpPost]
        public void CreateReviewForDog(CreateReviewForDogDto newReviewForDog)
        {
            _reviewForDogService.CreateReviewForDog(newReviewForDog);
        }

        [Route("update/{id}")]
        [HttpPost]
        public void UpdateReviewForDog(UpdateReviewForDogDto updatedReviewForDog)
        {
            _reviewForDogService.UpdateReviewForDog(updatedReviewForDog);
        }

        [Route("get-reviews/{id}")]
        [HttpGet]
        public void GetReviewsForDogByDog(int dogId)
        {
            _reviewForDogService.GetReviewsForDogByDog(dogId);
        }
    }
}
