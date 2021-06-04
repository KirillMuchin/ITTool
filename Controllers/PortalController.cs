using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ITToolTest.Controllers
{
    [Authorize]
    public class PortalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
