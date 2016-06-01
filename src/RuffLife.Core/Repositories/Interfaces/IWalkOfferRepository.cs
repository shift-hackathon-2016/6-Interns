using System;
using RuffLife.Core.Models.Walker;
using RuffLife.Core.Models.WalkOffer;
using RuffLife.Data.Models;
using System.Collections;
using System.Collections.Generic;

namespace RuffLife.Core.Repositories.Interfaces
{
    public interface IWalkOfferRepository : IDisposable
    {
        void CreateWalkOffer(CreateWalkOfferDto newWalkOffer);
        void UpdateWalkOffer(UpdateWalkOfferDto updatedWalkOffer);
        IList<ViewWalkOfferDto> GetWalkOffersByWalk(int walkId);
    }
}