using RuffLife.Core.Models.ReviewForWalker;
using RuffLife.Core.Services.Interfaces;
using System.Web.Http;

namespace RuffLife.Web.Controllers.API
{
    [RoutePrefix("reviewForWalkers")]
    public class ReviewForWalkerController : ApiController
    {
        public readonly IReviewForWalkerService _reviewForWalkerService;

        public ReviewForWalkerController(IReviewForWalkerService reviewForWalkerService)
        {
            _reviewForWalkerService = reviewForWalkerService;
        }

        [Route("create")]
        [HttpPost]
        public void CreateReviewForWalker(CreateReviewForWalkerDto newReviewForWalker)
        {
            _reviewForWalkerService.CreateReviewForWalker(newReviewForWalker);
        }

        [Route("update/{id}")]
        [HttpPost]
        public void UpdateReviewForWalker(UpdateReviewForWalkerDto updatedReviewForWalker)
        {
            _reviewForWalkerService.UpdateReviewForWalker(updatedReviewForWalker);
        }

        [Route("get-reviews/{id}")]
        [HttpGet]
        public void GetReviewsForWalkerByWalker(int walkerId)
        {
            _reviewForWalkerService.GetReviewsForWalkerByWalker(walkerId);
        }
    }
}
