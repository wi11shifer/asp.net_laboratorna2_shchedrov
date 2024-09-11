using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace Shschedrov_Bohdan_Laboratorna_2.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            var jsonData = System.IO.File.ReadAllText("Config/mydata.json");

            var personalData = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonData);

            return View(personalData);
        }
    }
}
