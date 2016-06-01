using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RuffLife.Core.Services.Interfaces;
using RuffLife.Core.Models.Walker;
using RuffLife.Core.Models.ReviewForWalker;

namespace RuffLife.Web.Controllers.API
{
    [RoutePrefix("api/walkers")]
    public class WalkerController : ApiController
    {
        private readonly IWalkerService _walkerService;
        private readonly IReviewForWalkerService _reviewForWalkerService;
        private readonly IWalkService _walkService;

        public WalkerController(IWalkerService walkerService, IReviewForWalkerService reviewForWalkerService, IWalkService walkService)
        {
            _walkerService = walkerService;
            _reviewForWalkerService = reviewForWalkerService;
            _walkService = walkService;
        }

        [Route("get/{id}")]
        [HttpGet]
        public IHttpActionResult GetSingleWalker(int id)
        {
            var walker = _walkerService.GetWalker(id);
            if (walker != null)
                return Ok(walker);
            return BadRequest("Walker with that Id doesnt exist");
        }

        [Route("all")]
        [HttpGet]
        public IHttpActionResult GetAllWalkers()
        {
            var walkers = _walkerService.GetAllWalkers();
            return Ok(walkers);
        }

        [Route("create")]
        [HttpPost]
        public void CreateWalker(CreateWalkerDto walker)
        {
            _walkerService.CreateWalker(walker);
        }

        [Route("{walkerId}/reviews")]
        [HttpGet]
        public IHttpActionResult GetreviewsForWalkerByWalker (int walkerId)
        {
            var reviewsForWalkers = _reviewForWalkerService.GetReviewsForWalkerByWalker(walkerId);
            return Ok(reviewsForWalkers);
        }

        [Route("{walkerId}/reviews/create")]
        [HttpPost]
        public void CreateReviewForWalker(CreateReviewForWalkerDto newReviewForWalker, int walkerId)
        {
            newReviewForWalker.Walker = _walkerService.GetWalker(walkerId);
            _reviewForWalkerService.CreateReviewForWalker(newReviewForWalker);
        }

        [Route("{walkerId}/walks")]
        [HttpGet]
        public IHttpActionResult GetWalksByWalker(int walkerId)
        {
            var walks = _walkService.GetWalksByWalker(walkerId);
            return Ok(walks);
        }

        [Route("{walkerId}/activeOffers")]
        [HttpGet]
        public IHttpActionResult GetActiveOffers(int walkerId)
        {
            var walks = _walkService.GetActiveOffersForWalker(walkerId);
            return Ok(walks);
        }
    }
}
