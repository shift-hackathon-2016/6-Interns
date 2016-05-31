using System;
using System.Collections.Generic;
using RuffLife.Core.Models.Owner;
using RuffLife.Data.Models;

namespace RuffLife.Core.Services.Interfaces
{
    public interface IOwnerService : IDisposable
    {
        void CreateOwner(CreateOwnerDto owner);
        IList<Owner> GetAllOwners();
    }
}