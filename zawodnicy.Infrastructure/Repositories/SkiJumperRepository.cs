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
        public static List<SkiJumper> _skiJumperMock = new List<SkiJumper>();
        public SkiJumperRepository()
        {
            var skiJumper1 = new SkiJumper()
            {
                Id = 1,
                Name = "Alan",
                ForeName = "G",
                Country = "pol",
                Weight = 170
            };

            var skiJumper2 = new SkiJumper()
            {
                Id = 2,
                Name = "Adam",
                ForeName = "P",
                Country = "ger",
                Weight = 172
            };

            var skiJumper3 = new SkiJumper()
            {
                Id = 3,
                Name = "Martin",
                ForeName = "S",
                Country = "fin",
                Weight = 172
            };

            if (_skiJumperMock.Count < 3)
            {
                _skiJumperMock.Clear();
                _skiJumperMock.Add(skiJumper1);
                _skiJumperMock.Add(skiJumper2);
                _skiJumperMock.Add(skiJumper3);
            }

        }

        public async Task<SkiJumper> Add(SkiJumper s)
        {
            s.Id = _skiJumperMock.Count + 1;
            _skiJumperMock.Add(s);
            return await GetAsync(s.Id);
        }

        public async Task<IEnumerable<SkiJumper>> BrowseAllAsync()
        {
            return await Task.FromResult(_skiJumperMock);
        }

        public async Task<IEnumerable<SkiJumper>> BrowseAllByFilter(string country, string name)
        {
            var s = _skiJumperMock.Where(x => x.Country.Contains(country) || x.Name.Contains(name)).AsEnumerable();
            return await Task.FromResult(s);
        }

        public async Task<SkiJumper> DelAsync(SkiJumper s)
        {
            _skiJumperMock.Remove(s);
            return await Task.FromResult(s);
        }

        public async Task<SkiJumper> GetAsync(int id)
        {
            var skiJumper = _skiJumperMock.Where(x => x.Id == id);
            if (skiJumper.Count() > 0)
            {
                return await Task.FromResult(skiJumper.First());
            } else
            {
                throw new DllNotFoundException();
            }
            
        }

        public async Task<SkiJumper> UpdateAsync(SkiJumper s)
        {
            var found = _skiJumperMock.FirstOrDefault(x => x.Id == s.Id);
            if (found != null)
            {
                found.Height = s.Height;
                found.ForeName = s.ForeName;
                found.Country = s.Country;
                found.Weight = s.Weight;
                return await Task.FromResult(found);
            } else
            {
                throw new DllNotFoundException();
            }

        }
    }
}
