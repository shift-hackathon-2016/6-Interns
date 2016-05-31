using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RuffLife.Core.Services.Interfaces;

namespace RuffLife.Web.Controllers.API
{
    public class WalkOfferController : ApiController
    {
        private readonly IWalkOfferService _walkOfferService;

        public WalkOfferController(IWalkOfferService walkOfferService)
        {
            _walkOfferService = walkOfferService;
        }
    }
}
