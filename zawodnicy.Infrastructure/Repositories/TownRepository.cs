using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class TownRepository : ITownRepository
    {
        public TownRepository()
        {
        }

        public Task AddAsync(Town t)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Town>> BrowseAllAcync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Town t)
        {
            throw new NotImplementedException();
        }

        public Task<Town> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
