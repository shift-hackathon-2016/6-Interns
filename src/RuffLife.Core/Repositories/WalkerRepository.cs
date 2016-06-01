using RuffLife.Core.Models.Walker;
using RuffLife.Data.Context;
using RuffLife.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RuffLife.Core.Repositories.Interfaces;
using RuffLife.Core.Services.Interfaces;

namespace RuffLife.Core.Repositories
{
    public class WalkerRepository : IWalkerRepository
    {
        private readonly RuffLifeContext _ruffLifeContext;
        public WalkerRepository(RuffLifeContext context)
        {
            _ruffLifeContext = context;
        }

        public void CreateWalker(CreateWalkerDto newWalker)
        {
            var walker = new Walker()
            {
                ContactNumber = newWalker.ContactNumber,
                Email = newWalker.Email,
                Location = newWalker.Location,
                Username = newWalker.Username,
                CostPerHourInHRK = newWalker.CostPerHourInHRK,
                Description = newWalker.Description,
            };

            _ruffLifeContext.Walkers.Add(walker);
            _ruffLifeContext.SaveChanges();
        }

        public IList<ViewWalkerDto> GetAllWalkers()
        {
            var walkers = _ruffLifeContext.Walkers
                .Include("Walks")
                .ToList();

            return walkers
                .Select(walker => Mapper.Map<ViewWalkerDto>(walker))
                .ToList();
        }

        public ViewWalkerDto GetWalker(int walkerId)
        {
            var walker = _ruffLifeContext.Walkers
                .Include("Walks")
                .FirstOrDefault(x => x.Id == walkerId);

            return Mapper.Map<ViewWalkerDto>(walker);
        }

        public void Dispose()
        {
            _ruffLifeContext.Dispose();
        }
    }
}
