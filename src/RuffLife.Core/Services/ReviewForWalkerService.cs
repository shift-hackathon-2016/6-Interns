using RuffLife.Core.Models.ReviewForWalker;
using RuffLife.Core.Repositories.Interfaces;
using RuffLife.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Core.Services
{
    public class ReviewForWalkerService : IReviewForWalkerService
    {
        private readonly IReviewForWalkerRepository _reviewForWalkerRepository;

        public ReviewForWalkerService(IReviewForWalkerRepository reviewForWalkerRepo)
        {
            _reviewForWalkerRepository = reviewForWalkerRepo;
        }

        public void CreateReviewForWalker(CreateReviewForWalkerDto newReviewForWalker)
        {
            _reviewForWalkerRepository.CreateReviewForWalker(newReviewForWalker);
        }

        public void UpdateReviewForWalker(UpdateReviewForWalkerDto updatedReviewForWalker)
        {
            _reviewForWalkerRepository.UpdateReviewForWalker(updatedReviewForWalker);
        }

        public IList<ViewReviewForWalkerDto> GetReviewsForWalkerByWalker(int walkerId)
        {
            return _reviewForWalkerRepository.GetReviewsForWalkerByWalker(walkerId);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
