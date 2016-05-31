using System;
using RuffLife.Core.Models.WalkOffer;
using RuffLife.Data.Models;

namespace RuffLife.Core.Services.Interfaces
{
    public interface IWalkOfferService : IDisposable
    {
        void CreateOffer(CreateWalkOfferDto createdOffer);

        void VoteOnOffer(Walker walkerToAdd, WalkOffer walkOfferToUpdate);

        void LockWalkOffer(Walker walkerSelected, WalkOffer walkOfferToLock);
    }
}