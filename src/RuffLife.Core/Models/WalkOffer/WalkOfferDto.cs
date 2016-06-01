using RuffLife.Core.Models.Walk;
using RuffLife.Core.Models.Walker;

namespace RuffLife.Core.Models.WalkOffer
{
    public class CreateWalkOfferDto
    {
        public bool IsActive { get; set; }
        public virtual ViewWalkDto Walk { get; set; }
        public virtual ViewWalkerDto Walker { get; set; }
    }

    public class ViewWalkOfferDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public virtual ViewWalkDto Walk { get; set; }
        public virtual ViewWalkerDto Walker { get; set; }
    }
}