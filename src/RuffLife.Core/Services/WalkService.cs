using RuffLife.Core.Models.Walk;
using RuffLife.Core.Repositories.Interfaces;
using RuffLife.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Core.Services
{
    class WalkService : IWalkService
    {
        private readonly IWalkRepository _walkRepository;

        public WalkService(IWalkRepository walkRepo)
        {
            _walkRepository = walkRepo;
        }

        public void CreateWalk(CreateWalkDto newWalk)
        {
            _walkRepository.CreateWalk(newWalk);
        }

        public void UpdateWalk(UpdateWalkDto updatedWalk)
        {
            _walkRepository.UpdateWalk(updatedWalk);
        }

        public ViewWalkDto GetWalk(int walkId)
        {
            return _walkRepository.GetWalk(walkId);
        }

        public IList<ViewWalkDto> GetWalksByWalker(int walkerId)
        {
            return _walkRepository.GetWalksByWalker(walkerId);
        }

        public IList<ViewWalkDto> GetWalksByDog(int dogId)
        {
            return _walkRepository.GetWalksByDog(dogId);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
