using AutoMapper;
using RuffLife.Core.Models.Dog;
using RuffLife.Core.Models.Owner;
using RuffLife.Core.Repositories.Interfaces;
using RuffLife.Data.Context;
using RuffLife.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Core.Repositories
{
    public class DogRepository : IDogRepository
    {
        private readonly RuffLifeContext _ruffLifeContext;
        public DogRepository(RuffLifeContext context)
        {
            _ruffLifeContext = context;
        }

        public void CreateDog(CreateDogDto newDog)
        {
            var dog = new Dog()
            {
                Name = newDog.Name,
                Breed = newDog.Breed,
                Age = newDog.Age,
                Gender = newDog.Gender,
                Description = newDog.Description,
                Notes = newDog.Notes,
                Owner = Mapper.Map<Owner>(newDog.Owner)
            };
            _ruffLifeContext.Dogs.Add(dog);
            _ruffLifeContext.SaveChanges();
        }

        public void UpdateDog(UpdateDogDto updatedDog)
        {
            var dog = _ruffLifeContext.Dogs
                .Include("Owner")
                .Include("Walks")
                .FirstOrDefault(x => x.Id == updatedDog.Id);

            dog.Description = updatedDog.Description;
            dog.Notes = updatedDog.Notes;

            _ruffLifeContext.SaveChanges();
        }

        public ViewDogDto GetDog(int dogId)
        {
            var dog = _ruffLifeContext.Dogs
                .Include("Owner")
                .Include("Walks")
                .FirstOrDefault(x => x.Id == dogId);

            return Mapper.Map<ViewDogDto>(dog);
        }

        public void DeleteDog(int dogId)
        {
            var dog = _ruffLifeContext.Dogs
                .Include("Owner")
                .Include("Walks")
                .FirstOrDefault(x => x.Id == dogId);

            _ruffLifeContext.Dogs.Remove(dog);
            _ruffLifeContext.SaveChanges();
        }

        public IList<ViewDogDto> GetDogsByOwner(int ownerId)
        {
            var dogs = _ruffLifeContext.Dogs
                .Include("Owner")
                .Include("Walks")
                .Where(x => x.Owner.Id == ownerId)
                .ToList();

            return dogs.Select(dog => Mapper.Map<ViewDogDto>(dog)).ToList();
        }

        public IList<ViewDogDto> GetDogsByWalk(int walkId)
        {
            var dogs = _ruffLifeContext.Dogs
                .Include("Owner")
                .Include("Walks")
                .Where(d => d.Walks.Any(w => w.Id == walkId))
                .ToList();

            return dogs.Select(dog => Mapper.Map<ViewDogDto>(dog)).ToList();
        }

        public void Dispose()
        {
            _ruffLifeContext.Dispose();
        }
    }
}
