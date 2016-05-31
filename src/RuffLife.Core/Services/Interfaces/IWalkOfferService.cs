using System;
using RuffLife.Core.Models.Walker;
using RuffLife.Core.Models.WalkOffer;
using RuffLife.Data.Models;

namespace RuffLife.Core.Services.Interfaces
{
    public interface IWalkOfferService : IDisposable
    {
        void CreateOffer(CreateWalkOfferDto createdOffer);

        void VoteOnOffer(ViewWalkerDto walkerToAdd, int walkOfferToUpdate);

        void LockWalkOffer(ViewWalkerDto walkerSelected, WalkOffer walkOfferToLock);
    }
}