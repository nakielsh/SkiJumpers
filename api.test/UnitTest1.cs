using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;
using Zawodnicy.Infrastructure.Services;

namespace service.test
{
    public class Tests
    {
        private SkiJumperService skiJumperService;
        private Mock<ISkiJumperRepository> skiJumperRepository;
        private IEnumerable<SkiJumper> skiJumpers;

        [SetUp]
        public void Setup()
        {
            skiJumperRepository = new Mock<ISkiJumperRepository>();

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


            skiJumpers = new List<SkiJumper>()
            {
                skiJumper1, skiJumper2, skiJumper3
            };


            skiJumperService = new SkiJumperService(skiJumperRepository.Object);
        }

        [Test]
        [Description("Checking if skiJumperService returns proper list of all SkiJumpers as SkiJumperDTO list")]
        [Author("nakielsh")]
        [Category("Correct")]
        public void ShouldReturnCorrectList()
        {
            var skiJumperDTO1 = new SkiJumperDTO()
            {
                Id = 1,
                Name = "Alan",
                ForeName = "G",
                Country = "pol",
                Weight = 170
            };

            var skiJumperDTO2 = new SkiJumperDTO()
            {
                Id = 2,
                Name = "Adam",
                ForeName = "P",
                Country = "ger",
                Weight = 172
            };

            var skiJumperDTO3 = new SkiJumperDTO()
            {
                Id = 3,
                Name = "Martin",
                ForeName = "S",
                Country = "fin",
                Weight = 172
            };

            IEnumerable<SkiJumperDTO> skiJumpersDTO = new List<SkiJumperDTO>()
            {
                skiJumperDTO1, skiJumperDTO2, skiJumperDTO3
            };

            skiJumperRepository.Setup(c => c.BrowseAllAsync()).Returns(Task.FromResult(skiJumpers));

            var result = skiJumperService.BrowseAllAsync();
            Assert.AreEqual(skiJumpersDTO.ToList().ToString(), result.Result.ToList().ToString());
        }

        [Test]
        [Description("Checking if skiJumperService properly returns SkiJumperDTO of added SkiJumper using CreateSkiJumper")]
        [Author("nakielsh")]
        [Category("Correct")]
        public void ShouldReturnSkiJumperWhenAddedCorrectly()
        {
            var skiJumper = new SkiJumper()
            {
                Id = 1,
                Name = "Mariusz",
                ForeName = "Pudzianowski",
                Country = "pol",
                Weight = 170
            };

            var createSkiJumper = new CreateSkiJumper()
            {
                Name = "Mariusz",
                ForeName = "Pudzianowski",
                Country = "pol",
                Weight = 170
            };

            var skiJumperDTO = new SkiJumperDTO()
            {
                Id = 1,
                Name = "Mariusz",
                ForeName = "Pudzianowski",
                Country = "pol",
                Weight = 170
            };

            skiJumperRepository.Setup(c => c.Add(It.IsAny<SkiJumper>())).Returns(Task.FromResult(skiJumper));
            skiJumperRepository.Setup(c => c.GetAsync(1)).Returns(Task.FromResult(skiJumper));

            var result = skiJumperService.Add(createSkiJumper);
            Assert.AreEqual(skiJumperDTO.ToString(), result.Result.ToString());
        }

        [Test]
        [Description("Checking if skiJumperService properly returns SkiJumperDTO of updated SkiJumper using UpdateSkiJumper")]
        [Author("nakielsh")]
        [Category("Correct")]
        public void ShouldReturnUpdatedSkiJumperWhenUpdatedCorrectly()
        {
            var updateSkiJumper = new UpdateSkiJumper()
            {
                Height = 123,
                ForeName = "Pudzianowski",
                Country = "pol",
                Weight = 170
            };


            var skiJumper = new SkiJumper()
            {
                Id = 1,
                Height = 123,
                ForeName = "Pudzianowski",
                Country = "pol",
                Weight = 170
            };

            var skiJumperDTO = new SkiJumperDTO()
            {
                Id = 1,
                Height = 123,
                ForeName = "Pudzianowski",
                Country = "pol",
                Weight = 170
            };

            skiJumperRepository.Setup(c => c.UpdateAsync(It.IsAny<SkiJumper>())).Returns(Task.FromResult(skiJumper));

            var result = skiJumperService.Update(updateSkiJumper, 1);
            Assert.AreEqual(skiJumperDTO.ToString(), result.Result.ToString());
        }

        [Test]
        [Description("Checking if skiJumperService properly returns SkiJumperDTO of deleted SkiJumper")]
        [Author("nakielsh")]
        [Category("Correct")]
        public void ShouldReturnDeletedSkiJumperWhenDeletedSuccesfully()
        {
            var skiJumper = new SkiJumper()
            {
                Id = 1,
                Height = 123,
                ForeName = "Pudzianowski",
                Country = "pol",
                Weight = 170
            };

            var skiJumperDTO = new SkiJumperDTO()
            {
                Id = 1,
                Height = 123,
                ForeName = "Pudzianowski",
                Country = "pol",
                Weight = 170
            };

            skiJumperRepository.Setup(c => c.DelAsync(It.IsAny<SkiJumper>())).Returns(Task.FromResult(skiJumper));

            var result = skiJumperService.Delete(1);
            Assert.AreEqual(skiJumperDTO.ToString(), result.Result.ToString());
        }

        [Test]
        [Description("Checking if skiJumperService returns proper, filtered by country and name, list of all SkiJumpers as SkiJumperDTO list")]
        [Author("nakielsh")]
        [Category("Correct")]
        public void ShouldReturnAllSkiJumpersWithCountryAndName()
        {
            var skiJumperDTO1 = new SkiJumperDTO()
            {
                Id = 1,
                Name = "Alan",
                ForeName = "G",
                Country = "pol",
                Weight = 170
            };


            IEnumerable<SkiJumperDTO> skiJumpersDTO = new List<SkiJumperDTO>()
            {
                skiJumperDTO1
            };

            skiJumpers = skiJumpers.SkipLast(2);

            skiJumperRepository.Setup(c => c.BrowseAllByFilter(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(skiJumpers));

            var result = skiJumperService.BrowseAllByFilter("pol", "Alan");
            Assert.AreEqual(skiJumpersDTO.ToList().ToString(), result.Result.ToList().ToString());
        }

        [TearDown]
        public void TearDown()
        {
            skiJumperService = null;
            skiJumperRepository = null;
            skiJumpers = null;
        }

    }
}