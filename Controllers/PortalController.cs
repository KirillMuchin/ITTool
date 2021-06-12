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
            var userCourses = GetUserCoursesList();
            return View(userCourses);
        }

        public IActionResult NewCourse()
        {
            var dataCourses = _coursesController.GetData();
            return View(dataCourses);
        }

        public IActionResult LearnCourse(int courseId)
        {
            var userCourse = GetUserCoursesList().Where(x => x.Id == courseId).First();
            ViewData["CourseName"] = (userCourse.Name);
            var courseData = _coursesController.GetCourseData(userCourse.Id);
            return View(courseData);

        }

        public IEnumerable<Courses> GetUserCoursesList()
        {
            GetAllData();
            var userId = identityUser.Id;
            var localUserId = localUser.Id;
            var coursesId = _context.UserCourse.Where(x => x.UserId == localUserId).Select(x => x.CoursesId).ToList();
            foreach (var id in coursesId)
            {
                yield return _context.Courses.Where(x => x.Id == id).First();
            }
        }

        public IActionResult AddCourseToUser(int courseId)
        {
            GetAllData();
            var isCourseInProgress =
                (_context.UserCourse.Where(x => x.UserId == localUser.Id && x.CoursesId == courseId)).Any();
            if (isCourseInProgress)
            {
                return Redirect("./MyCourses");
            }
            else
            {
                var newCourse = new UserCourse() { CoursesId = courseId, UserId = localUser.Id, Progress = "0" };
                _context.UserCourse.Add(newCourse);
                _context.SaveChangesAsync();
            }
            return Redirect("./MyCourses");
        }
    }
}
