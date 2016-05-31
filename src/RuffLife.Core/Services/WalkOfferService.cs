using RuffLife.Core.Models.WalkOffer;
using RuffLife.Core.Repositories.Interfaces;
using RuffLife.Data.Models;

namespace RuffLife.Core.Services
{
    public class WalkOfferService
    {
        private readonly IWalkOfferRepository _walkOfferRepository;
        private readonly IWalkRepository _walkRepository;

        public WalkOfferService(IWalkOfferRepository walkOfferRepository,
            IWalkRepository walkRepository)
        {
            _walkOfferRepository = walkOfferRepository;
            _walkRepository = walkRepository;
        }

        public void CreateOffer(CreateWalkOfferDto createdOffer)
        {
            _walkOfferRepository.CreateWalkOffer(createdOffer);
        }

        public void VoteOnOffer(Walker walkerToAdd, WalkOffer walkOfferToUpdate)
        {
            _walkOfferRepository.VoteOnOffer(walkerToAdd,walkOfferToUpdate);
        }

        public void LockWalkOffer(Walker walkerSelected, WalkOffer walkOfferToLock)
        {
            _walkOfferRepository.LockOffer(walkOfferToLock);
        }

        public void Dispose()
        {
            _walkOfferRepository.Dispose();
        }
    }
}
