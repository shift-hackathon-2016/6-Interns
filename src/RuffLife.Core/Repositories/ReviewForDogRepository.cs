using AutoMapper;
using RuffLife.Core.Models.ReviewForDog;
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
    public class ReviewForDogRepository : IReviewForDogRepository
    {
        private readonly RuffLifeContext _ruffLifeContext;
        public ReviewForDogRepository(RuffLifeContext context)
        {
            _ruffLifeContext = context;
        }

        public void CreateReviewForDog(CreateReviewForDogDto newReviewForDog)
        {
            var reviewForDog = new ReviewForDog()
            {
                Grade = newReviewForDog.Grade,
                Review = newReviewForDog.Review,
                Walker = Mapper.Map<Walker>(newReviewForDog.Walker),
                Dog = Mapper.Map<Dog>(newReviewForDog.Dog)
            };
            _ruffLifeContext.ReviewsForDogs.Add(reviewForDog);
            _ruffLifeContext.SaveChanges();
        }

        public void UpdateReviewForDog(UpdateReviewForDogDto updatedReviewForDog)
        {
            var reviewForDog = _ruffLifeContext.ReviewsForDogs
                .Include("Walker")
                .Include("Dog")
                .FirstOrDefault(x => x.Id == updatedReviewForDog.Id);

            reviewForDog.Grade = updatedReviewForDog.Grade;
            reviewForDog.Review = updatedReviewForDog.Review;

            _ruffLifeContext.SaveChanges();
        }

        public IList<ViewReviewForDogDto> GetReviewsForDogByDog(int dogId)
        {
            var reviewsForDogs = _ruffLifeContext.ReviewsForDogs
                .Include("Walker")
                .Include("Dog")
                .Where(x => x.Dog.Id == dogId)
                .ToList();

            return reviewsForDogs.Select(dog => Mapper.Map<ViewReviewForDogDto>(dog)).ToList();
        }

        public void Dispose()
        {
            _ruffLifeContext.Dispose();
        }
    }
}
