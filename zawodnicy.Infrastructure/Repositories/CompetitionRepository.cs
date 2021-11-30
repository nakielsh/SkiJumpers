using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class CompetitionRepository : ICompetitionRepository
    {
        public CompetitionRepository()
        {
        }

        public Task AddAsync(Competition c)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Competition>> BrowseAllAcync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Competition c)
        {
            throw new NotImplementedException();
        }

        public Task<Competition> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
