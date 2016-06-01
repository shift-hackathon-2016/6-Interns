using AutoMapper;
using RuffLife.Core.Models.ReviewForWalker;
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
    public class ReviewForWalkerRepository : IReviewForWalkerRepository
    {
        private readonly RuffLifeContext _ruffLifeContext;
        public ReviewForWalkerRepository(RuffLifeContext context)
        {
            _ruffLifeContext = context;
        }

        public void CreateReviewForWalker(CreateReviewForWalkerDto newReviewForWalker)
        {
            var reviewForWalker = new ReviewForWalker()
            {
                Grade = newReviewForWalker.Grade,
                Review = newReviewForWalker.Review,
                Walker = Mapper.Map<Walker>(newReviewForWalker.Walker),
                Owner = Mapper.Map<Owner>(newReviewForWalker.Owner)
            };
            _ruffLifeContext.ReviewsForWalkers.Add(reviewForWalker);
            _ruffLifeContext.SaveChanges();
        }

        public void UpdateReviewForWalker(UpdateReviewForWalkerDto updatedReviewForWalker)
        {
            var reviewForWalker = _ruffLifeContext.ReviewsForWalkers
                .Include("Walker")
                .Include("Owner")
                .FirstOrDefault(x => x.Id == updatedReviewForWalker.Id);

            reviewForWalker.Grade = updatedReviewForWalker.Grade;
            reviewForWalker.Review = updatedReviewForWalker.Review;

            _ruffLifeContext.SaveChanges();
        }

        public IList<ViewReviewForWalkerDto> GetReviewsForWalkerByWalker(int walkerId)
        {
            var reviewsForWalkers = _ruffLifeContext.ReviewsForWalkers
                .Include("Walker")
                .Include("Owner")
                .Where(x => x.Walker.Id == walkerId)
                .ToList();

            return reviewsForWalkers.Select(walker => Mapper.Map<ViewReviewForWalkerDto>(walker)).ToList();
        }

        public void Dispose()
        {
            _ruffLifeContext.Dispose();
        }
    }
}
