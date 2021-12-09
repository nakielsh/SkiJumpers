using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ISkiJumperRepository
    {
        Task AddAsync(SkiJumper s);
        Task DelAsync(int id);
        Task<SkiJumper> GetAsync(int id);
        Task<IEnumerable<SkiJumper>> BrowseAllAsync();
        Task<IEnumerable<SkiJumper>> BrowseAllByFilterAsync(string country, string name);
        Task UpdateAsync(SkiJumper s);
    }
}
