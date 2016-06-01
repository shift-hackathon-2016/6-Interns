using AutoMapper;
using RuffLife.Core.Models.Walk;
using RuffLife.Core.Models.Walker;
using RuffLife.Core.Models.WalkOffer;
using RuffLife.Core.Repositories.Interfaces;
using RuffLife.Core.Services.Interfaces;
using RuffLife.Data.Models;
using System.Collections.Generic;

namespace RuffLife.Core.Services
{
    public class WalkOfferService : IWalkOfferService
    {
        private readonly IWalkOfferRepository _walkOfferRepository;
        private readonly IWalkRepository _walkRepository;
        private readonly IWalkerRepository _walkerRepository;

        public WalkOfferService(IWalkOfferRepository walkOfferRepository,
            IWalkRepository walkRepository,
            IWalkerRepository walkerRepository)
        {
            _walkOfferRepository = walkOfferRepository;
            _walkRepository = walkRepository;
            _walkerRepository = walkerRepository;
        }

        public void CreateWalkOffer(CreateWalkOfferDto newWalkOffer)
        {
            _walkOfferRepository.CreateWalkOffer(newWalkOffer);
        }

        public void UpdateWalkOffer(UpdateWalkOfferDto updatedWalkOffer)
        {

        }

        public IList<ViewWalkOfferDto> GetWalkOffersByWalk(int walkId)
        {

            return _walkOfferRepository.GetWalkOffersByWalk(walkId);
        }

        public void Dispose()
        {
            _walkOfferRepository.Dispose();
        }
    }
}
