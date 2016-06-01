using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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

        public void CreateWalkOffer(CreateWalkOfferDto newWalkOffer)
        {
            var walkOffer = new WalkOffer()
            {
                IsActive = true,
                Walk = Mapper.Map<Walk>(newWalkOffer.Walk),
                Walker = Mapper.Map<Walker>(newWalkOffer.Walker)
            };

            _ruffLifeContext.WalkOffers.Add(walkOffer);
            _ruffLifeContext.SaveChanges();
        }

        public void LockWalkOffer(int walkOfferId)
        {
            var walkOffer = _ruffLifeContext.WalkOffers
                .Include("Walker")
                .Include("Walk")
                .Include("WalkOffers")
                .FirstOrDefault(x => x.Id == walkOfferId);

            walkOffer.IsActive = false;

            _ruffLifeContext.SaveChanges();
        }

        public IList<ViewWalkOfferDto> GetWalkOffersByWalk(int walkId)
        {
            var walkOffers = _ruffLifeContext.WalkOffers
                .Include("Walker")
                .Include("Walk")
                .Include("WalkOffers")
                .Where(x => x.Walk.Id == walkId)
                .ToList();

            return walkOffers.Select(walkOffer => Mapper.Map<ViewWalkOfferDto>(walkOffer)).ToList();
        }

        public void Dispose()
        {
            _ruffLifeContext.Dispose();
        }
    }
}
