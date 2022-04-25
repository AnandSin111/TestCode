using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SampleApp.ASPDotNETCore.Models;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace SampleApp.ASPDotNETCore.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateStudent()
        {
            return View();
        }        

        [HttpPost]
        public async Task<IActionResult> AddDetails([FromBody] StudentModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Enter required fields");
            }
            else
            {
                var fileName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("File")["FileName"];
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(student, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.AppendAllText(fileName, json);
                return this.Ok();
            }
        }
    }
}
