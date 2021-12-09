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
    public class TrainerService : ITrainerService
    {

        private readonly ITrainerRepository _trainerRepository;

        public TrainerService(ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }

        public async Task AddAsync(CreateTrainer createTrainer)
        {
            var trainer = new Trainer()
            {
                FirstName = createTrainer.FirstName,
                LastName = createTrainer.LastName,
                BirthDate = createTrainer.BirthDate
            };

            await _trainerRepository.AddAsync(trainer);
        }

        public async Task<IEnumerable<TrainerDTO>> BrowseAllAsync()
        {
            var trainerList = await _trainerRepository.BrowseAllAsync();

            return trainerList.Select(x => new TrainerDTO()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                BirthDate = x.BirthDate
            });
        }

        public async Task<IEnumerable<TrainerDTO>> BrowseAllByFilterAsync(string firstname, string lastname)
        {
            var trainerList = await _trainerRepository.BrowseAllByFilterAsync(firstname, lastname);

            return trainerList.Select(x => new TrainerDTO()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                BirthDate = x.BirthDate
            });
        }

        public async Task DeleteAsync(int id)
        {
            await _trainerRepository.DelAsync(id);
        }

        public async Task<TrainerDTO> GetAsync(int id)
        {
            var trainer = await _trainerRepository.GetAsync(id);

            return new TrainerDTO()
            {
                Id = trainer.Id,
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                BirthDate = trainer.BirthDate
            };
        }

        public async Task<TrainerDTO> UpdateAsync(UpdateTrainer updateTrainer, int id)
        {
            var trainer = new Trainer()
            {
                Id = updateTrainer.Id,
                FirstName = updateTrainer.FirstName,
                LastName = updateTrainer.LastName,
                BirthDate = updateTrainer.BirthDate
            };

            await _trainerRepository.UpdateAsync(trainer);
            var updated = await _trainerRepository.GetAsync(id);

            return new TrainerDTO()
            {
                Id = trainer.Id,
                FirstName = trainer.FirstName,
                LastName = trainer.LastName,
                BirthDate = trainer.BirthDate
            };
        }
    }
}
