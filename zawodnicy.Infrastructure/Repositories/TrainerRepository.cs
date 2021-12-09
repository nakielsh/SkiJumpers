using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {

        private AppDbContext _appDbContext;

        public TrainerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Trainer t)
        {
            try
            {
                _appDbContext.Trainer.Add(t);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Trainer>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Trainer);
        }

        public async Task<IEnumerable<Trainer>> BrowseAllByFilterAsync(string firstname, string lastname)
        {
            var t = _appDbContext.Trainer.Where(x => x.FirstName.Contains(firstname) || x.LastName.Contains(lastname)).AsEnumerable();
            return await Task.FromResult(t);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Trainer.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Trainer> GetAsync(int id)
        {
            try
            {
                var t = _appDbContext.Trainer.FirstOrDefault(x => x.Id == id);
                return await Task.FromResult(t);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(Trainer t)
        {
            try
            {
                var found = _appDbContext.Trainer.FirstOrDefault(x => x.Id == t.Id);

                found.FirstName = t.FirstName;
                found.LastName = t.LastName;
                found.BirthDate = t.BirthDate;

                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
