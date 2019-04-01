using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSite.Helper;
using WebSite.Models;
using WebSite.Utility;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        ExpressoApiHelper _api = new ExpressoApiHelper();
        public async Task<IActionResult> Index()
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync(SD.ClientApiMenus);

            dynamic json = null;
            string temp = "";
            if (res.IsSuccessStatusCode)
            {
                temp = res.Content.ReadAsStringAsync().Result;
                json = JsonConvert.DeserializeObject(temp);
            }

            //return View(JsonConvert.DeserializeObject(temp));
            ViewData["json"] = json;
            //return View(res);
            return Ok(json);

        }

        // [HttpGet("{id}")]
        public async Task<IActionResult> Index2(int id)
        {
            Menu model = new Menu()
            {
                Id=id,	
                Name="test",
                Image="testUrl"
            };
            return Ok();



        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
