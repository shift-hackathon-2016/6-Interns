using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RuffLife.Core.Models.Owner;
using RuffLife.Core.Repositories.Interfaces;
using RuffLife.Data.Context;
using RuffLife.Data.Models;

namespace RuffLife.Core.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly RuffLifeContext _ruffLifeContext;
        public OwnerRepository(RuffLifeContext context)
        {
            _ruffLifeContext = context;
        }

        public void CreateOwner(Owner newOwner)
        {
            var owner = new Owner()
            {
                Address = newOwner.Address,
                ContactNumber = newOwner.ContactNumber,
                Email = newOwner.Email,
                Location = newOwner.Location,
                Username = newOwner.Username,
                Dogs = newOwner.Dogs
            };

            _ruffLifeContext.Owners.Add(owner);
            _ruffLifeContext.SaveChanges();
        }

        public IList<ViewOwnerDto> GetAllOwners()
        {
            var owners = _ruffLifeContext.Owners
                .Include("Dogs")
                .Include("ReviewsGiven")
                .ToList();

            return owners.Select(owner => Mapper.Map<ViewOwnerDto>(owner)).ToList();
        }

        public ViewOwnerDto GetOwner(int ownerId)
        {
            var owner = _ruffLifeContext.Owners
                .Include("Dogs")
                .Include("ReviewsGiven")
                .FirstOrDefault(x => x.Id == ownerId);

            return Mapper.Map<ViewOwnerDto>(owner);
        }

        public void Dispose()
        {
            _ruffLifeContext.Dispose();
        }
    }
}
