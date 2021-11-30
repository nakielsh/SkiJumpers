using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ITrainerRepository
    {
        Task AddAsync(Trainer t);
        Task DelAsync(Trainer t);
        Task<Trainer> GetAsync(int id);
        Task<IEnumerable<Trainer>> BrowseAllAcync();
    }
}
