using RuffLife.Core.Models.ReviewForDog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Core.Services.Interfaces
{
    public interface IReviewForDogService : IDisposable
    {
        void CreateReviewForDog(CreateReviewForDogDto newReviewForDog);
        void UpdateReviewForDog(UpdateReviewForDogDto updatedReviewForDog);
        IList<ViewReviewForDogDto> GetReviewsForDogByDog(int dogId);
    }
}
