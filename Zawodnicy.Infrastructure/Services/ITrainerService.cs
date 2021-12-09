using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;

namespace Zawodnicy.Infrastructure.Services
{
    public interface ITrainerService
    {
        Task<IEnumerable<TrainerDTO>> BrowseAllAsync();
        Task<TrainerDTO> GetAsync(int id);
        Task<IEnumerable<TrainerDTO>> BrowseAllByFilterAsync(string firstname, string lastname);
        Task AddAsync(CreateTrainer createTrainer);
        Task DeleteAsync(int id);
        Task<TrainerDTO> UpdateAsync(UpdateTrainer updateTrainer, int id);
    }
}
