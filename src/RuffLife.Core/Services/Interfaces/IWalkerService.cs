using System;
using RuffLife.Core.Models.Walker;
using System.Collections.Generic;

namespace RuffLife.Core.Services.Interfaces
{
    public interface IWalkerService : IDisposable
    {
        ViewWalkerDto GetWalker(int walkerId);
        void CreateWalker(CreateWalkerDto walker);
        IList<ViewWalkerDto> GetAllWalkers();
        IList<ViewWalkerDto> GetWalkersByLocation(string query);
    }
}