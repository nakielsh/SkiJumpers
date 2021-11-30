using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface IParticipationRepository
    {
        Task AddAsync(Participation p);
        Task DelAsync(Participation p);
        Task<Participation> GetAsync(int id);
        Task<IEnumerable<Participation>> BrowseAllAcync();
    }
}
