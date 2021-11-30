using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class ParticipationRepository : IParticipationRepository
    {
        public ParticipationRepository()
        {
        }

        public Task AddAsync(Participation p)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Participation>> BrowseAllAcync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Participation p)
        {
            throw new NotImplementedException();
        }

        public Task<Participation> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
