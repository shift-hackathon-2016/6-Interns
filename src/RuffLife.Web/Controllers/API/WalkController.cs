﻿using RuffLife.Core.Models.Walk;
using RuffLife.Core.Models.WalkOffer;
using RuffLife.Core.Services.Interfaces;
using System.Web.Http;

namespace RuffLife.Web.Controllers.API
{
    [RoutePrefix("api/walks")]
    public class WalkController : ApiController
    {
        private readonly IWalkService _walkService;
        private readonly IDogService _dogService;
        private readonly IWalkOfferService _walkOfferService;

        public WalkController(IWalkService walkService, IDogService dogService, IWalkOfferService walkOfferService)
        {
            _walkService = walkService;
            _dogService = dogService;
            _walkOfferService = walkOfferService;
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

        [Route("{walkId}/walkOffers/create")]
        [HttpPost]
        public void CreateWalkOffer(CreateWalkOfferDto newWalkOffer, int walkId)
        {
            newWalkOffer.Walk = _walkService.GetWalk(walkId);
            _walkOfferService.CreateWalkOffer(newWalkOffer);
        }

        [Route("{walkId}/walkOffers/{Id}/lock")]
        [HttpPost]
        public void LockWalkOffer(int Id)
        {
            _walkOfferService.LockWalkOffer(Id);
        }

        [Route("{walkId}/walkOffers")]
        [HttpGet]
        public IHttpActionResult GetWalkOffersByWalk(int walkId)
        {
            var walkOffers = _walkOfferService.GetWalkOffersByWalk(walkId);
            return Ok(walkOffers);
        }
    }
}
