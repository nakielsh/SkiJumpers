using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ISkiJumperRepository
    {
        Task<SkiJumper> Add(SkiJumper s);
        Task<SkiJumper> DelAsync(SkiJumper s);
        Task<SkiJumper> GetAsync(int id);
        Task<IEnumerable<SkiJumper>> BrowseAllAsync();
        Task<IEnumerable<SkiJumper>> BrowseAllByFilter(string country, string name);
        Task<SkiJumper> UpdateAsync(SkiJumper s);
    }
}
