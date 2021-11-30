using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;
using Zawodnicy.Infrastructure.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zawodnicy.WebAPI.Controllers
{
    [Route("[controller]")]
    public class SkiJumperController : Controller
    {
        private readonly ISkiJumperService _skiJumperService;

        public SkiJumperController(ISkiJumperService skiJumperService)
        {
            _skiJumperService = skiJumperService;
        }

        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var skiJumperList = await _skiJumperService.BrowseAllAsync();
            return Json(skiJumperList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkiJumper(int id)
        {
            SkiJumperDTO skiJumperEntity;

            try {
                skiJumperEntity = await _skiJumperService.GetAsync(id);
                return Json(skiJumperEntity);
            } catch (DllNotFoundException e)
            {
                return Json(e.StackTrace);
            }
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetSkiJumper(string country, string name)
        {
            var skiJumperList = await _skiJumperService.BrowseAllByFilter(country, name);
            return Json(skiJumperList);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkiJumper([FromBody] CreateSkiJumper skiJumper)
        {
            var returnedSkiJumper = await _skiJumperService.Add(skiJumper);
            return CreatedAtAction(null, returnedSkiJumper);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkiJumper([FromBody] UpdateSkiJumper skiJumper, int id)
        {
            await _skiJumperService.Update(skiJumper, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkiJumper(int id)
        {
            await _skiJumperService.Delete(id);
            return NoContent();

        }
    }
}
