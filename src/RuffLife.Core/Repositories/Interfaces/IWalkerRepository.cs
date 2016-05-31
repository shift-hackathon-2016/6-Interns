using System;
using System.Collections.Generic;
using RuffLife.Core.Models.Walker;

namespace RuffLife.Core.Repositories.Interfaces
{
    public interface IWalkerRepository : IDisposable
    {
        void CreateWalker(CreateWalkerDto newWalker);

        IList<ViewWalkerDto> GetAllWalkers();

        ViewWalkerDto GetWalker(int walkerId);
    }
}