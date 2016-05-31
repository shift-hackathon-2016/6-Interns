using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using RuffLife.Core.Models.Walker;
using RuffLife.Core.Models.WalkOffer;
using RuffLife.Core.Services.Interfaces;
using RuffLife.Data.Models;

namespace RuffLife.Web.Controllers.API
{
    [RoutePrefix("walk-offer")]
    public class WalkOfferController : ApiController
    {
        private readonly IWalkOfferService _walkOfferService;

        public WalkOfferController(IWalkOfferService walkOfferService)
        {
            _walkOfferService = walkOfferService;
        }

        [Route("create-offer")]
        [HttpPost]
        public IHttpActionResult CreateWalkOffer(CreateWalkOfferDto walkOffer)
        {
            _walkOfferService.CreateOffer(walkOffer);
            return Ok();
        }

        [Route("lock-offer")]
        [HttpPost]
        public IHttpActionResult LockWalkOffer(ViewWalkerDto walker, WalkOffer walkOffer)
        {
            _walkOfferService.LockWalkOffer(walker, walkOffer);
            return Ok();
        }

        [Route("update-offer/{walkOfferId}")]
        [HttpPost]
        public IHttpActionResult UpdateWalkOffer(int walkOfferId, ViewWalkerDto walker)
        {
            _walkOfferService.VoteOnOffer(walker, walkOfferId);
            return Ok();
        }
    }
}
