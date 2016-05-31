using AutoMapper;
using RuffLife.Core.Models.ReviewForDog;
using RuffLife.Core.Repositories.Interfaces;
using RuffLife.Core.Services.Interfaces;
using RuffLife.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Core.Services
{
    public class ReviewForDogService : IReviewForDogService
    {
        private readonly IReviewForDogRepository _reviewForDogRepository;

        public ReviewForDogService(IReviewForDogRepository reviewForDogRepo)
        {
            _reviewForDogRepository = reviewForDogRepo;
        }

        public void CreateReviewForDog(CreateReviewForDogDto newReviewForDog)
        {
            _reviewForDogRepository.CreateReviewForDog(newReviewForDog);
        }

        public void UpdateReviewForDog(UpdateReviewForDogDto updatedReviewForDog)
        {
            _reviewForDogRepository.UpdateReviewForDog(updatedReviewForDog);
        }

        public IList<ViewReviewForDogDto> GetReviewsForDogByDog(int dogId)
        {
            return _reviewForDogRepository.GetReviewsForDogByDog(dogId);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
