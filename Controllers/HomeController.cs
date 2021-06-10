﻿using ITToolTest.Models;
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
        private CoursesController CoursesController;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, CoursesController coursesController)
        {
            _logger = logger;
            CoursesController = coursesController;
        }

        public IActionResult Index()
        {
            var dataCourses = CoursesController.GetData();
            return View(dataCourses);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
