using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ICompetitionRepository
    {
        Task AddAsync(Competition c);
        Task DelAsync(Competition c);
        Task<Competition> GetAsync(int id);
        Task<IEnumerable<Competition>> BrowseAllAcync();
    }
}
