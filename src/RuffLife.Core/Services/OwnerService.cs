using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RuffLife.Core.Models.Owner;
using RuffLife.Core.Repositories.Interfaces;
using RuffLife.Core.Services.Interfaces;
using RuffLife.Data.Models;

namespace RuffLife.Core.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepo)
        {
            _ownerRepository = ownerRepo;
        }


        public void CreateOwner(CreateOwnerDto owner)
        {
            _ownerRepository.CreateOwner(Mapper.Map<Owner>(owner));
        }

        public IList<ViewOwnerDto> GetAllOwners()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
