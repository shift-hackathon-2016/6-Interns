using RuffLife.Core.Models.Dog;
using RuffLife.Core.Repositories.Interfaces;
using RuffLife.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Core.Services
{
    public class DogService : IDogService
    {
        private readonly IDogRepository _dogRepository;

        public DogService(IDogRepository dogRepo)
        {
            _dogRepository = dogRepo;
        }

        public void CreateDog(CreateDogDto newDog)
        {
            _dogRepository.CreateDog(newDog);
        }

        public void UpdateDog(UpdateDogDto updatedDog)
        {
            _dogRepository.UpdateDog(updatedDog);
        }

        public ViewDogDto GetDog(int dogId)
        {
            return _dogRepository.GetDog(dogId);
        }

        public void DeleteDog(int dogId)
        {
            _dogRepository.DeleteDog(dogId);
        }

        public IList<ViewDogDto> GetDogsByOwner(int ownerId)
        {
            return _dogRepository.GetDogsByOwner(ownerId);
        }

        public IList<ViewDogDto> GetDogsByWalk(int walkId)
        {
            return _dogRepository.GetDogsByWalk(walkId);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
