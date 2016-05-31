using AutoMapper;
using RuffLife.Core.Models.ReviewForDog;
using RuffLife.Data.Context;
using RuffLife.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Core.Repositories
{
    class ReviewForDogRepository
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
                Walker = newReviewForDog.Walker,
                Dog = newReviewForDog.Dog
            };
            _ruffLifeContext.ReviewsForDogs.Add(reviewForDog);
            _ruffLifeContext.SaveChanges();
        }

        public void UpdateReviewForDog(UpdateReviewForDogDto updatedReviewForDog)
        {
            var reviewForDog = _ruffLifeContext.ReviewsForDogs
                .Include("Walkers")
                .Include("Dogs")
                .FirstOrDefault(x => x.Id == updatedReviewForDog.Id);

            reviewForDog.Grade = updatedReviewForDog.Grade;
            reviewForDog.Review = updatedReviewForDog.Review;

            _ruffLifeContext.SaveChanges();
        }

        public IList<ViewReviewForDogDto> GetReviewsForDogByDog(int dogId)
        {
            var reviewsForDogs = _ruffLifeContext.ReviewsForDogs
                .Include("Walkers")
                .Include("Dogs")
                .Where(x => x.Dog.Id == dogId)
                .Select(dog => Mapper.Map<ViewReviewForDogDto>(dog))
                .ToList();

            return reviewsForDogs;
        }
    }
}
