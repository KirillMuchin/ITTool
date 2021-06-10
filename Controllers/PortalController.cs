using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ITToolTest.Data;
using ITToolTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ITToolTest.Controllers
{
    [Authorize]
    public class PortalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public PortalController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyCourses()
        {
            var userId = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name).Id;
            var user = (_context.User.Where(x => x.AspNetUsersId == userId).ToList())[0].Id;
            var coursesId = _context.UserCourse.Where(x => x.UserId == user).Select(x => x.CoursesId).ToList();
            var userCourses = new List<Courses>();
            foreach (var id in coursesId)
            {
                userCourses.AddRange(_context.Courses.Where(x => x.Id == id).ToList());
            }
            return View(userCourses);
        }
    }
}
