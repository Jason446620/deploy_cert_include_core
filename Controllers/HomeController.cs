using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using deploy_cert_include_core.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace deploy_cert_include_core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            string myKeyValue = Configuration["testKey"];
            ViewBag.myKeyValue = myKeyValue;
            return View();
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
        public string test() {
            string path = @"D:\home\site\myfiles\a.txt";
            string line = string.Empty;
            FileStream fileStream = new FileStream(path, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                line = reader.ReadLine();
            }
            return line;
        }
        public IActionResult customcode() {
            return StatusCode(999, Json("Not allowed."));
        }
        public string testcode()
        {
            return "001";
        }
    }
}
