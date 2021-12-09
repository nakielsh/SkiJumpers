using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class SkiJumperRepository : ISkiJumperRepository
    {

        private AppDbContext _appDbContext;

        public SkiJumperRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        

        public async Task AddAsync(SkiJumper s)
        {
            try
            {
                s.Id = _appDbContext.SkiJumper.Count() + 1;

                _appDbContext.SkiJumper.Add(s);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<SkiJumper>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.SkiJumper);
        }

        public async Task<IEnumerable<SkiJumper>> BrowseAllByFilterAsync(string country, string name)
        {
            var s = _appDbContext.SkiJumper.Where(x => x.Country.Contains(country) || x.Name.Contains(name)).AsEnumerable();
            return await Task.FromResult(s);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.SkiJumper.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<SkiJumper> GetAsync(int id)
        {
            try
            {
                var skiJumper = _appDbContext.SkiJumper.FirstOrDefault(x => x.Id == id);
                return await Task.FromResult(skiJumper);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }

        public async Task UpdateAsync(SkiJumper s)
        {
            try
            {
                var found = _appDbContext.SkiJumper.FirstOrDefault(x => x.Id == s.Id);

                found.Height = s.Height;
                found.ForeName = s.ForeName;
                found.Country = s.Country;
                found.Weight = s.Weight;

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
