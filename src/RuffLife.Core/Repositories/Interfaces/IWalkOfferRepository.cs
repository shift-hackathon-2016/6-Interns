using System;
using RuffLife.Core.Models.WalkOffer;
using RuffLife.Data.Models;

namespace RuffLife.Core.Repositories.Interfaces
{
    public interface IWalkOfferRepository : IDisposable
    {
        WalkOffer CreateWalkOffer(CreateWalkOfferDto walkOffer);
        void VoteOnOffer(Walker walkerThatVoted, WalkOffer votedOffer);
        void LockOffer(WalkOffer walkOfferToLock);
        WalkOffer GetOfferFromRepo(int walkOfferId);
    }
}