using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;
using Zawodnicy.Infrastructure.Services;

namespace Zawodnicy.WebAPI.Controllers
{
    [Route("[controller]")]
    public class TrainerController : Controller
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var skiJumperList = await _trainerService.BrowseAllAsync();
            return Json(skiJumperList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainer(int id)
        {
            TrainerDTO trainerEntity;

            try
            {
                trainerEntity = await _trainerService.GetAsync(id);
                return Json(trainerEntity);
            }
            catch (Exception e)
            {
                return Json(e.StackTrace);
            }
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetTrainer(string firstname, string lastname)
        {
            var trainerList = await _trainerService.BrowseAllByFilterAsync(firstname, lastname);
            return Json(trainerList);
        }

        [HttpPost]
        public async Task<IActionResult> AddTrainer([FromBody] CreateTrainer trainer)
        {
            await _trainerService.AddAsync(trainer);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainer([FromBody] UpdateTrainer trainer, int id)
        {
            await _trainerService.UpdateAsync(trainer, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            await _trainerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
