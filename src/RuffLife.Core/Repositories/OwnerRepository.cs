using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
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

        public async void CreateAsync(CreateOwnerDto newOwner)
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
            await  _ruffLifeContext.SaveChangesAsync();
        }

        public IList<ViewOwnerDto> GetAllOwners()
        {
            var owners = _ruffLifeContext.Owners
                .Include("Dogs")
                .Select(owner => Mapper.Map<Owner, ViewOwnerDto>(owner))
                .ToList();

            return owners;
        }

        public void Dispose()
        {
            _ruffLifeContext.Dispose();
        }
    }
}
