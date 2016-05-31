using System;
using RuffLife.Core.Models.Walker;

namespace RuffLife.Core.Services.Interfaces
{
    public interface IWalkerService : IDisposable
    {
        ViewWalkerDto GetWalker(int walkerId);
    }
}