using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ITownRepository
    {
        Task AddAsync(Town t);
        Task DelAsync(Town t);
        Task<Town> GetAsync(int id);
        Task<IEnumerable<Town>> BrowseAllAcync();
    }
}
