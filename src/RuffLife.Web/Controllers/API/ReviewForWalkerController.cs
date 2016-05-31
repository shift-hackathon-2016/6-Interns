﻿using RuffLife.Core.Models.ReviewForWalker;
using RuffLife.Core.Services.Interfaces;
using System.Web.Http;

namespace RuffLife.Web.Controllers.API
{

    [RoutePrefix("api/review-for-walkers")]
    public class ReviewForWalkerController : ApiController
    {
        public readonly IReviewForWalkerService _reviewForWalkerService;

        public ReviewForWalkerController(IReviewForWalkerService reviewForWalkerService)
        {
            _reviewForWalkerService = reviewForWalkerService;
        }

        [Route("update/{id}")]
        [HttpPost]
        public void UpdateReviewForWalker(UpdateReviewForWalkerDto updatedReviewForWalker)
        {
            _reviewForWalkerService.UpdateReviewForWalker(updatedReviewForWalker);
        }
    }
}
