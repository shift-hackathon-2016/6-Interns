using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RuffLife.Core.Models.Walker;
using RuffLife.Core.Repositories.Interfaces;
using RuffLife.Core.Services.Interfaces;

namespace RuffLife.Core.Services
{
    public class WalkerService : IWalkerService
    {
        private readonly IWalkerRepository _walkerRepository;

        public WalkerService(IWalkerRepository walkerRepository)
        {
            _walkerRepository = walkerRepository;
        }

        public ViewWalkerDto GetWalker(int walkerId)
        {
            var walker = _walkerRepository.GetWalker(walkerId);
            return walker;
        }

        public void Dispose()
        {
            _walkerRepository.Dispose();
        }
    }
}
