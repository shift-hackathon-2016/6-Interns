using RuffLife.Core.Models.Walk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Core.Services.Interfaces
{
    public interface IWalkService : IDisposable
    {
        void CreateWalk(CreateWalkDto newWalk);
        void UpdateWalk(UpdateWalkDto updatedWalk);
        ViewWalkDto GetWalk(int walkId);
        IList<ViewWalkDto> GetWalksByWalker(int walkerId);
        IList<ViewWalkDto> GetWalksByDog(int dogId);
    }
}
