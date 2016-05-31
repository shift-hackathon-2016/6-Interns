using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using RuffLife.Core.Models.Owner;
using RuffLife.Data.Models;

namespace RuffLife.Core.Repositories.Interfaces
{
    public interface IOwnerRepository : IDisposable
    {
        void CreateOwner(Owner newOwner);
        IList<Owner> GetAllOwners();
    }
}