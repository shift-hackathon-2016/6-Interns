using AutoMapper;
using RuffLife.Core.Models.Walk;
using RuffLife.Core.Models.Walker;
using RuffLife.Core.Models.WalkOffer;
using RuffLife.Core.Repositories.Interfaces;
using RuffLife.Core.Services.Interfaces;
using RuffLife.Data.Models;

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

        public void CreateOffer(CreateWalkOfferDto createdOffer)
        {
            _walkOfferRepository.CreateWalkOffer(createdOffer);
        }

        public void VoteOnOffer(ViewWalkerDto walkerToAdd, int walkOfferIdToUpdate)
        {
            var walkOffer = _walkOfferRepository.GetOfferFromRepo(walkOfferIdToUpdate);

            _walkOfferRepository.VoteOnOffer(walkerToAdd, walkOffer);
        }

        public void LockWalkOffer(ViewWalkerDto walkerSelected, WalkOffer walkOfferToLock)
        {
            _walkOfferRepository.LockOffer(walkOfferToLock);

            var walk = _walkRepository.GetWalk(walkOfferToLock.Walk.Id);
            walk.Walker = walkerSelected;

            _walkRepository.UpdateWalk(Mapper.Map<UpdateWalkDto>(walk));


        }

        public void Dispose()
        {
            _walkOfferRepository.Dispose();
        }
    }
}
