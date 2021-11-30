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
        Task<IEnumerable<SkiJumperDTO>> BrowseAllByFilter(string country, string name);
        Task<SkiJumperDTO> Add(CreateSkiJumper createSkiJumper);
        Task<SkiJumperDTO> Delete(int id);
        Task<SkiJumperDTO> Update(UpdateSkiJumper updateSkiJumper, int id);

    }
}
