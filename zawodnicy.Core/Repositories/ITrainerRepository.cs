using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ITrainerRepository
    {
        Task AddAsync(Trainer t);
        Task DelAsync(int id);
        Task<Trainer> GetAsync(int id);
        Task<IEnumerable<Trainer>> BrowseAllAsync();
        Task<IEnumerable<Trainer>> BrowseAllByFilterAsync(string firstname, string lastname);
        Task UpdateAsync(Trainer t);
    }
}
