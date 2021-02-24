using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DynamicSeries.WebUI.Controllers
{
    public class SeriesController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult SendData(string divisor, string number)
        {
            //this url should go in configuraiotn or databsae 
            string url =$"http://localhost:5000/api/DynamicSeries?divisor={divisor}&number={number}";

            var connection = new HttpClient();

            var rs = connection.GetAsync(url);

            string result = rs.Result.Content.ReadAsStringAsync().Result;

            if(result != "Some eror occured")
            {
                ViewBag.Result = result;
            }

            return View("result");
        }


    }
}
