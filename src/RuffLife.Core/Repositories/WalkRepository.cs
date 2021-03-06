﻿using AutoMapper;
using RuffLife.Core.Models.Walk;
using RuffLife.Data.Context;
using RuffLife.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuffLife.Core.Repositories.Interfaces;
using RuffLife.Core.Models.Walker;

namespace RuffLife.Core.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly RuffLifeContext _ruffLifeContext;
        public WalkRepository(RuffLifeContext context)
        {
            _ruffLifeContext = context;
        }

        public void CreateWalk(CreateWalkDto newWalk)
        {
            var newDogs = newWalk.Dogs.Select(d => Mapper.Map<Dog>(d)).ToList();
            
            var newWalker = Mapper.Map<Walker>(newWalk.Walker);
            var walk = new Walk()
            {
                StartTime = newWalk.StartTime,
                EndTime = newWalk.EndTime,
                Location = newWalk.Location,
                Dogs = newDogs,
                Walker = newWalker,
                Price = 10
            };

            _ruffLifeContext.Walks.Add(walk);
            _ruffLifeContext.SaveChanges();
        }

        public void UpdateWalk(UpdateWalkDto updatedWalk)
        {
            var walk = _ruffLifeContext.Walks
                .Include("Walker")
                .Include("Dogs")
                .FirstOrDefault(x => x.Id == updatedWalk.Id);
            if (walk == null) return;

            walk.Price = updatedWalk.Price;
            walk.Walker = Mapper.Map<Walker>(updatedWalk.Walker);

            _ruffLifeContext.SaveChanges();
        }

        public ViewWalkDto GetWalk(int walkId)
        {
            var walk = _ruffLifeContext.Walks
                .Include("Walker")
                .Include("Dogs")
                .FirstOrDefault(x => x.Id == walkId);

            return Mapper.Map<ViewWalkDto>(walk);
        }

        public IList<ViewWalkDto> GetWalksByWalker(int walkerId)
        {
            var walks = _ruffLifeContext.Walks
                .Include("Walker")
                .Include("Dogs")
                .Where(x => x.Walker.Id == walkerId)
                .ToList();

            return walks.Select(walk => Mapper.Map<ViewWalkDto>(walk)).ToList();
        }

        public IList<ViewWalkDto> GetWalksByDog(int dogId)
        {
            var walks = _ruffLifeContext.Walks
                .Include("Walker")
                .Include("Dogs")
                .Where(x => x.Dogs.Any(_ => _.Id == dogId))
                .ToList();

            return walks.Select(walk => Mapper.Map<ViewWalkDto>(walk)).ToList();
        }


        public void Dispose()
        {
            _ruffLifeContext.Dispose();
        }
    }
}
