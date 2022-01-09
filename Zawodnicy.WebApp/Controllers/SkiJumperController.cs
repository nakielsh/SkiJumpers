using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Zawodnicy.WebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zawodnicy.WebApp.Controllers
{
    public class SkiJumperController : Controller
    {

        public IConfiguration Configuration;

        public SkiJumperController (IConfiguration configuration)
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

        [Authorize(Roles = "wazny,zarzadca")]
        public async Task<IActionResult> Index()
        {
            //string _restpath = "https://localhost:5001";
            string _restpath = GetHostUrl().Content + CN();

            var tokenString = GenerateJSONWebToken();
            List<SkiJumperVM> skiJumpersList = new List<SkiJumperVM>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tokenString);
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    skiJumpersList = JsonConvert.DeserializeObject<List<SkiJumperVM>>(apiResponse);
                }
            }
                return View(skiJumpersList);
        }

        [Authorize(Roles = "wazny,zarzadca")]
        public async Task<IActionResult> Edit(int id)
        {
            //string _restpath = "https://localhost:5001";
            string _restpath = GetHostUrl().Content + CN();

            SkiJumperVM result = new SkiJumperVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}")) 
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<SkiJumperVM>(apiResponse);
                }
            }
            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "wazny,zarzadca")]
        public async Task<IActionResult> Edit(SkiJumperVM s)
        {
            //string _restpath = "https://localhost:5001";
            string _restpath = GetHostUrl().Content + CN();

            SkiJumperVM result = new SkiJumperVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{s.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<SkiJumperVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "wazny,zarzadca")]
        public async Task<IActionResult> Create()
        {
            //string _restpath = "https://localhost:5001";
            string _restpath = GetHostUrl().Content + CN();

            SkiJumperVM result = new SkiJumperVM();

            return View(result);
        }

        [HttpPost]
        [Authorize(Roles = "wazny,zarzadca")]
        public async Task<IActionResult> Create(SkiJumperVM s)
        {
            //string _restpath = "https://localhost:5001";
            string _restpath = GetHostUrl().Content + CN();

            SkiJumperVM result = new SkiJumperVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(s);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{_restpath}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<SkiJumperVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "wazny,zarzadca")]
        public async Task<IActionResult> Delete(int id)
        {
            //string _restpath = "https://localhost:5001";
            string _restpath = GetHostUrl().Content + CN();

            SkiJumperVM result = new SkiJumperVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    
                    using (var response = await httpClient.DeleteAsync($"{_restpath}/{id}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<SkiJumperVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperTajneHaslo1234"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
