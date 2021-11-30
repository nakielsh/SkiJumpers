using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {
        public TrainerRepository()
        {
        }

        public Task AddAsync(Trainer t)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Trainer>> BrowseAllAcync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Trainer t)
        {
            throw new NotImplementedException();
        }

        public Task<Trainer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
