using AutoMapper;
using RuffLife.Core.Models.Walk;
using RuffLife.Data.Context;
using RuffLife.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Core.Repositories
{
    class WalkRepository
    {
        private readonly RuffLifeContext _ruffLifeContext;
        public WalkRepository(RuffLifeContext context)
        {
            _ruffLifeContext = context;
        }

        public void CreateWalk(CreateWalkDto newWalk)
        {
            var walk = new Walk()
            {
                StartTime = newWalk.StartTime,
                EndTime = newWalk.EndTime,
                Location = newWalk.Location,
                Dogs = newWalk.Dogs.Select(dog => Mapper.Map<Dog>(newWalk.Dogs)).ToList()
            };

            _ruffLifeContext.Walks.Add(walk);
            _ruffLifeContext.SaveChanges();
        }

        public void UpdateWalk(UpdateWalkDto updatedWalk)
        {
            var walk = _ruffLifeContext.Walks
                .Include("Walkers")
                .Include("Dogs")
                .FirstOrDefault(x => x.Id == updatedWalk.Id);

            walk.Price = updatedWalk.Price;
            walk.Walker = Mapper.Map<Walker>(updatedWalk.Walker);

            _ruffLifeContext.SaveChanges();
        }

        public ViewWalkDto GetWalk(int walkId)
        {
            var walk = _ruffLifeContext.Walks
                .Include("Walkers")
                .Include("Dogs")
                .FirstOrDefault(x => x.Id == walkId);

            return Mapper.Map<ViewWalkDto>(walk);
        }

        public IList<ViewWalkDto> GetWalksByWalker(int walkerId)
        {
            var walks = _ruffLifeContext.Walks
                .Include("Walkers")
                .Include("Dogs")
                .Where(x => x.Walker.Id == walkerId)
                .Select(walk => Mapper.Map<ViewWalkDto>(walk))
                .ToList();

            return walks;
        }

        public IList<ViewWalkDto> GetWalksByDog(int dogId)
        {
            var walks = _ruffLifeContext.Walks
                .Include("Walkers")
                .Include("Dogs")
                .Where(x => x.Dogs.Any(_ => _.Id == dogId))
                .Select(walk => Mapper.Map<ViewWalkDto>(walk))
                .ToList();

            return walks;
        }
    }
}
