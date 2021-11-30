using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ISkiJumpRepository
    {
        Task AddAsync(SkiJump s);
        Task DelAsync(SkiJump s);
        Task<SkiJump> GetAsync(int id);
        Task<IEnumerable<SkiJump>> BrowseAllAcync();
    }
}
