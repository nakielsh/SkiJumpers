using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class SkiJumpRepository : ISkiJumpRepository
    {
        public SkiJumpRepository()
        {
        }

        public Task AddAsync(SkiJump s)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SkiJump>> BrowseAllAcync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(SkiJump s)
        {
            throw new NotImplementedException();
        }

        public Task<SkiJump> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SkiJump s)
        {
            throw new NotImplementedException();
        }
    }
}
