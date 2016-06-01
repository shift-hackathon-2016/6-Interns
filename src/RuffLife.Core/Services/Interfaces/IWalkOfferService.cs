using System;
using RuffLife.Core.Models.Walker;
using RuffLife.Core.Models.WalkOffer;
using RuffLife.Data.Models;
using System.Collections.Generic;

namespace RuffLife.Core.Services.Interfaces
{
    public interface IWalkOfferService : IDisposable
    {
        void CreateWalkOffer(CreateWalkOfferDto newWalkOffer);
        void UpdateWalkOffer(UpdateWalkOfferDto updatedWalkOffer);
        IList<ViewWalkOfferDto> GetWalkOffersByWalk(int walkId);
    }
}