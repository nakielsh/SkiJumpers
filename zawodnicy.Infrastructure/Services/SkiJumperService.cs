using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;

namespace Zawodnicy.Infrastructure.Services
{
    public class SkiJumperService : ISkiJumperService
    {

        private readonly ISkiJumperRepository _skiJumperRepository;

        

        public SkiJumperService(ISkiJumperRepository skiJumperRepository)
        {
            _skiJumperRepository = skiJumperRepository;
        }

        public async Task<IEnumerable<SkiJumperDTO>> BrowseAllAsync()
        {
            var skiJumperList = await _skiJumperRepository.BrowseAllAsync();

            //automapper
            return skiJumperList.Select(x => new SkiJumperDTO()
            {
                Id = x.Id,
                Country = x.Country,
                Name = x.Name,
                BirthDate = x.BirthDate,
                ForeName = x.ForeName,
                Weight = x.Weight,
                Height = x.Height

            });
        }

        public async Task<SkiJumperDTO> GetAsync(int id)
        {
            var skiJumper = await _skiJumperRepository.GetAsync(id);

            return new SkiJumperDTO()
            {
                Id = skiJumper.Id,
                Country = skiJumper.Country,
                Name = skiJumper.Name,
                BirthDate = skiJumper.BirthDate,
                ForeName = skiJumper.ForeName,
                Weight = skiJumper.Weight,
                Height = skiJumper.Height

            };
        }

        public async Task<IEnumerable<SkiJumperDTO>> BrowseAllByFilterAsync(string country, string name)
        {
            var skiJumperList = await _skiJumperRepository.BrowseAllByFilterAsync(country, name);

            //automapper
            return skiJumperList.Select(x => new SkiJumperDTO()
            {
                Id = x.Id,
                Country = x.Country,
                Name = x.Name,
                BirthDate = x.BirthDate,
                ForeName = x.ForeName,
                Weight = x.Weight,
                Height = x.Height

            });
        }

        public async Task AddAsync(CreateSkiJumper createSkiJumper)
        {
            var skiJumper = new SkiJumper()
            {
                Name = createSkiJumper.Name,
                ForeName = createSkiJumper.ForeName,
                Country = createSkiJumper.Country,
                BirthDate = createSkiJumper.BirthDate,
                Weight = createSkiJumper.Weight,
                Height = createSkiJumper.Height
            };

            await _skiJumperRepository.AddAsync(skiJumper);

        }

        public async Task DeleteAsync(int id)
        {
            await _skiJumperRepository.DelAsync(id);

        }

        public async Task<SkiJumperDTO> UpdateAsync(UpdateSkiJumper updateSkiJumper, int id)
        {
            var skiJumper = new SkiJumper()
            {
                Id = id,
                Name = updateSkiJumper.Name,
                Height = updateSkiJumper.Height,
                ForeName = updateSkiJumper.ForeName,
                Country = updateSkiJumper.Country,
                Weight = updateSkiJumper.Weight,
                BirthDate = updateSkiJumper.BirthDate
            };

            await _skiJumperRepository.UpdateAsync(skiJumper);
            var updated = await _skiJumperRepository.GetAsync(id);

            return new SkiJumperDTO()
            {
                Id = updated.Id,
                Country = updated.Country,
                Name = updated.Name,
                BirthDate = updated.BirthDate,
                ForeName = updated.ForeName,
                Weight = updated.Weight,
                Height = updated.Height

            };
        }
    }

}
