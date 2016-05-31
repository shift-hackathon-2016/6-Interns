using System;
using System.Collections.Generic;
using RuffLife.Core.Models.Walk;

namespace RuffLife.Core.Repositories.Interfaces
{
    public interface IWalkRepository : IDisposable
    {
        void CreateWalk(CreateWalkDto newWalk);

        void UpdateWalk(UpdateWalkDto updatedWalk);

        ViewWalkDto GetWalk(int walkId);

        IList<ViewWalkDto> GetWalksByWalker(int walkerId);
        IList<ViewWalkDto> GetWalksByDog(int dogId);
    }

}