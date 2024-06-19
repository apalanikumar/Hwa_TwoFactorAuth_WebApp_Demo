using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TwoFactorAuthWebApp.Models;

namespace TwoFactorAuthWebApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly AppConfiguration _appConfiguration;
        public WeatherController(IOptions<AppConfiguration> myConfiguration) => _appConfiguration = myConfiguration.Value;
        public async Task<IActionResult> Index()
        {
            await GetWeatherForecast();
            return View();
        }
        [HttpGet]
        [Route("api/GetWeatherForecast")]
        //Hosted web API REST Service base url
        public async Task<ActionResult> GetWeatherForecast()
        {
            string baseUrl = "https://localhost:7051/";//_appConfiguration.WebAPIUrl.ToString();

            List<MemberViewModel> WeatherInfo = new List<MemberViewModel>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/WeatherForecast");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    WeatherInfo = JsonConvert.DeserializeObject<List<MemberViewModel>>(EmpResponse);
                }
                //returning the employee list to view
                return View(WeatherInfo);
            }
        }
    }
}

