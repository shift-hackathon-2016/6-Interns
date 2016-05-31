using RuffLife.Core.Models.ReviewForWalker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuffLife.Core.Repositories.Interfaces
{
    interface IReviewForWalkerRepository : IDisposable
    {
        void CreateReviewForWalker(CreateReviewForWalkerDto newReviewForWalker);
        void UpdateReviewForWalker(UpdateReviewForWalkerDto updatedReviewForWalker);
        IList<ViewReviewForWalkerDto> GetReviewsForWalkerByWalker(int walkerId);
    }
}
