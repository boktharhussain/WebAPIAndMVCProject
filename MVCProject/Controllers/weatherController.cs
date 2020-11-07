using MVCProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCProject.Controllers
{
    public class weatherController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://localhost:56818/WatherService/GetWatherInformation";
        public weatherController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: WatherInfo
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var WatherData = JsonConvert.DeserializeObject<List<WatherInfo>>(responseData);

                return View(WatherData);
            }
            return View("Internal Error");
        }
    }
}