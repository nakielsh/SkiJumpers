using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Zawodnicy.WebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zawodnicy.WebApp.Controllers
{
    public class TrainerController : Controller
    {
        public IConfiguration Configuration;

        public TrainerController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult GetHostUrl()
        {
            var result = Configuration["RestApiUrl:HostUrl"];
            return Content(result);
        }

        private string CN()
        {
            string cn = ControllerContext.RouteData.Values["controller"].ToString();
            return cn;
        }

        public async Task<IActionResult> Index()
        {
            //string _restpath = "https://localhost:5001";
            string _restpath = GetHostUrl().Content + CN();

            List<TrainerVM> trainerList = new List<TrainerVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    trainerList = JsonConvert.DeserializeObject<List<TrainerVM>>(apiResponse);
                }
            }
            return View(trainerList);
        }

        public async Task<IActionResult> Edit(int id)
        {
            //string _restpath = "https://localhost:5001";
            string _restpath = GetHostUrl().Content + CN();

            TrainerVM result = new TrainerVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<TrainerVM>(apiResponse);
                }
            }
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TrainerVM t)
        {
            //string _restpath = "https://localhost:5001";
            string _restpath = GetHostUrl().Content + CN();

            TrainerVM result = new TrainerVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(t);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{t.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<TrainerVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create()
        {
            //string _restpath = "https://localhost:5001";
            string _restpath = GetHostUrl().Content + CN();

            TrainerVM result = new TrainerVM();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrainerVM t)
        {
            //string _restpath = "https://localhost:5001";
            string _restpath = GetHostUrl().Content + CN();

            TrainerVM result = new TrainerVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(t);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{_restpath}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<TrainerVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            //string _restpath = "https://localhost:5001";
            string _restpath = GetHostUrl().Content + CN();

            TrainerVM result = new TrainerVM();

            try
            {
                using (var httpClient = new HttpClient())
                {

                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<TrainerVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
