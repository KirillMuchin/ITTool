using ITToolTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SQLitePCL;

namespace ITToolTest.Controllers
{
    public class HomeController : Controller
    {
        private OurCoursesController ourCoursesController;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, OurCoursesController coursesController)
        {
            _logger = logger;
            ourCoursesController = coursesController;
        }

        public IActionResult Index()
        {
            var dataCourses = ourCoursesController.GetData();
            return View(dataCourses);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
