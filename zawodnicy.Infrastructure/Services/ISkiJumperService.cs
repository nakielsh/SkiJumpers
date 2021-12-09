using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;

namespace Zawodnicy.Infrastructure.Services
{
    public interface ISkiJumperService
    {
        Task<IEnumerable<SkiJumperDTO>> BrowseAllAsync();
        Task<SkiJumperDTO> GetAsync(int id);
        Task<IEnumerable<SkiJumperDTO>> BrowseAllByFilterAsync(string country, string name);
        Task AddAsync(CreateSkiJumper createSkiJumper);
        Task DeleteAsync(int id);
        Task<SkiJumperDTO> UpdateAsync(UpdateSkiJumper updateSkiJumper, int id);

    }
}
