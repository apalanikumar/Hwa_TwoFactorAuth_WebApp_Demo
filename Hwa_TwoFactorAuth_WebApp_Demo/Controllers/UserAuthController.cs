using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using TwoFactorAuthWebApp.Models;

namespace Hwa_TwoFactorAuth_WebApp_Demo.Controllers
{
    public class UserAuthController : Controller
    {
        // GET: UserAuthController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("api/AuthToken")]
        //Hosted web API REST Service base url
        public async Task<ActionResult> UserLogin(string UserName, string Password)
        {
            string baseUrl = "https://localhost:7051/";
                        
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Auth/Login");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                   var UserInfo = JsonConvert.DeserializeObject<List<MemberViewModel>>(EmpResponse);
                }
                //returning the employee list to view
                return View();
            }
        }


    }
}
