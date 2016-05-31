using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using RuffLife.Core.Models.Owner;

namespace RuffLife.Core.Repositories.Interfaces
{
    public interface IOwnerRepository : IDisposable
    {
        void CreateAsync(CreateOwnerDto newOwner);
        IList<ViewOwnerDto> GetAllOwners();
    }
}