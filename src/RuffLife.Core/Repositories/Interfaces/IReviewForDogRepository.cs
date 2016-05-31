using RuffLife.Core.Models.ReviewForDog;
using RuffLife.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Core.Repositories.Interfaces
{
    public interface IReviewForDogRepository : IDisposable
    {
        void CreateReviewForDog(CreateReviewForDogDto newReviewForDog);
        void UpdateReviewForDog(UpdateReviewForDogDto updatedReviewForDog);
        IList<ViewReviewForDogDto> GetReviewsForDogByDog(int dogId);
    }
}
