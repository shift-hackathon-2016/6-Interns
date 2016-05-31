using System.Collections.Generic;
using System.Linq;
using RuffLife.Core.Models.Owner;
using RuffLife.Data.Context;
using RuffLife.Data.Models;

namespace RuffLife.Core.Repositories
{
    public class OwnerRepository
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

        public IList<Owner> GetAllOwners()
        {
            var owners = _ruffLifeContext.Owners
                .Include("Dogs").ToList();

            return owners.ToList();
        } 
    }
}
