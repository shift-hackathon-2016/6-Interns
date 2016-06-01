using RuffLife.Core.Models.Dog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Core.Services.Interfaces
{
    public interface IDogService : IDisposable
    {
        void CreateDog(CreateDogDto newDog);
        void UpdateDog(UpdateDogDto updatedDog);
        ViewDogDto GetDog(int dogId);
        void DeleteDog(int dogId);
        IList<ViewDogDto> GetDogsByOwner(int ownerId);
        IList<ViewDogDto> GetDogsByWalk(int walkId);
    }
}
