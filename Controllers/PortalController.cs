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
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ITToolTest.Controllers
{
    [Authorize]
    public class PortalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly CoursesController _coursesController;
        private IdentityUser identityUser;
        private User localUser;
        private readonly UserCoursesController _userCoursesController;
        public PortalController(ApplicationDbContext context, UserManager<IdentityUser> userManager, CoursesController coursesController, UserCoursesController userCoursesController)
        {
            _context = context;
            _userManager = userManager;
            _coursesController = coursesController;
            _userCoursesController = userCoursesController;
        }

        private void GetAllData()
        {
            identityUser = _context.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            localUser = (_context.User.Where(x => x.AspNetUsersId == identityUser.Id).ToList())[0];
        }

        public IActionResult Index()
        {
            GetAllData();
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

        public IActionResult NewCourse()
        {
            var dataCourses = _coursesController.GetData();
            return View(dataCourses);
        }

        public void AddCourseToUser(int courseId)
        {
            GetAllData();
            var newCourse = new UserCourse() {CoursesId = courseId, UserId = localUser.Id, Progress = "0"};
            _context.UserCourse.Add(newCourse);
            _context.SaveChangesAsync();
            RedirectToAction("MyCourses");
        }
    }
}
