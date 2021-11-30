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

        public async Task<IEnumerable<SkiJumperDTO>> BrowseAllByFilter(string country, string name)
        {
            var skiJumperList = await _skiJumperRepository.BrowseAllByFilter(country, name);

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

        public async Task<SkiJumperDTO> Add(CreateSkiJumper createSkiJumper)
        {
            var skiJumper = new SkiJumper()
            {
                Name = createSkiJumper.Name,
                ForeName = createSkiJumper.ForeName,
                Country = createSkiJumper.Country,
                Weight = createSkiJumper.Weight
            };

            var returnedSkiJumper = await _skiJumperRepository.Add(skiJumper);
            return new SkiJumperDTO()
            {
                Id = returnedSkiJumper.Id,
                Country = returnedSkiJumper.Country,
                Name = returnedSkiJumper.Name,
                BirthDate = returnedSkiJumper.BirthDate,
                ForeName = returnedSkiJumper.ForeName,
                Weight = returnedSkiJumper.Weight,
                Height = returnedSkiJumper.Height

            };

        }

        public async Task<SkiJumperDTO> Delete(int id)
        {
            var toDelete = await _skiJumperRepository.GetAsync(id);
            var deleted = await _skiJumperRepository.DelAsync(toDelete);

            return new SkiJumperDTO()
            {
                Id = deleted.Id,
                Country = deleted.Country,
                Name = deleted.Name,
                BirthDate = deleted.BirthDate,
                ForeName = deleted.ForeName,
                Weight = deleted.Weight,
                Height = deleted.Height

            };
        }

        public async Task<SkiJumperDTO> Update(UpdateSkiJumper updateSkiJumper, int id)
        {
            var skiJumper = new SkiJumper()
            {
                Id = id,
                Height = updateSkiJumper.Height,
                ForeName = updateSkiJumper.ForeName,
                Country = updateSkiJumper.Country,
                Weight = updateSkiJumper.Weight
            };

            var updated = await _skiJumperRepository.UpdateAsync(skiJumper);

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
