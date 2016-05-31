using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuffLife.Core.Models.WalkOffer;
using RuffLife.Core.Repositories.Interfaces;
using RuffLife.Data.Context;
using RuffLife.Data.Models;

namespace RuffLife.Core.Repositories
{
    public class WalkOfferRepository : IWalkOfferRepository
    {
        private readonly RuffLifeContext _ruffLifeContext;

        public WalkOfferRepository(RuffLifeContext ruffLifeContext)
        {
            _ruffLifeContext = ruffLifeContext;
        }

        //Creates offer in Db with Walk field and empty Walkoffer field
        //Then returns created offer
        public WalkOffer CreateWalkOffer(CreateWalkOfferDto walkOffer)
        {
            var offer = new WalkOffer()
            {
                IsActive = true,
                Walk = walkOffer.Walk
            };

            _ruffLifeContext.WalkOffers.Add(offer);
            _ruffLifeContext.SaveChanges();
            return _ruffLifeContext.WalkOffers.FirstOrDefault(o => o.Walk == offer.Walk);
        }

        //adds user on offer
        public void VoteOnOffer(Walker walkerThatVoted, WalkOffer votedOffer)
        {
            var walkOffer = _ruffLifeContext.WalkOffers.FirstOrDefault(o => o.Id == votedOffer.Id);
            if (walkOffer == null || !walkOffer.IsActive) return;

            var walker = _ruffLifeContext.Walkers.FirstOrDefault(w => w.Id == walkerThatVoted.Id);
            if (walker == null) return;

            walkOffer.Walker.Add(walker);
            _ruffLifeContext.SaveChanges();

        }

        public void LockOffer(WalkOffer walkOfferToLock)
        {
            var walkOffer = _ruffLifeContext.WalkOffers.FirstOrDefault(o => o.Id == walkOfferToLock.Id);
            if (walkOffer == null) return;

            walkOffer.IsActive = false;

            _ruffLifeContext.SaveChanges();
        }

        public WalkOffer GetOfferFromRepo(int walkOfferId)
        {
            var walkOffer = _ruffLifeContext.WalkOffers
                .Include("Walkers")
                .FirstOrDefault(o => o.Id == walkOfferId);
            return walkOffer;
        }

        public void Dispose()
        {
            _ruffLifeContext.Dispose();
        }
    }
}
