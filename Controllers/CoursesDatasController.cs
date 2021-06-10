using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITToolTest.Data;
using ITToolTest.Models;

namespace ITToolTest
{
    public class CoursesDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CoursesDatas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CoursesData.Include(c => c.Courses1);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CoursesDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursesData = await _context.CoursesData
                .Include(c => c.Courses1)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coursesData == null)
            {
                return NotFound();
            }

            return View(coursesData);
        }

        // GET: CoursesDatas/Create
        public IActionResult Create()
        {
            ViewData["CoursesId"] = new SelectList(_context.Courses, "Id", "Id");
            return View();
        }

        // POST: CoursesDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Header,Text,CoursesId")] CoursesData coursesData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coursesData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoursesId"] = new SelectList(_context.Courses, "Id", "Id", coursesData.CoursesId);
            return View(coursesData);
        }

        // GET: CoursesDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursesData = await _context.CoursesData.FindAsync(id);
            if (coursesData == null)
            {
                return NotFound();
            }
            ViewData["CoursesId"] = new SelectList(_context.Courses, "Id", "Id", coursesData.CoursesId);
            return View(coursesData);
        }

        // POST: CoursesDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Header,Text,CoursesId")] CoursesData coursesData)
        {
            if (id != coursesData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coursesData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursesDataExists(coursesData.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoursesId"] = new SelectList(_context.Courses, "Id", "Id", coursesData.CoursesId);
            return View(coursesData);
        }

        // GET: CoursesDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursesData = await _context.CoursesData
                .Include(c => c.Courses1)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coursesData == null)
            {
                return NotFound();
            }

            return View(coursesData);
        }

        // POST: CoursesDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coursesData = await _context.CoursesData.FindAsync(id);
            _context.CoursesData.Remove(coursesData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoursesDataExists(int id)
        {
            return _context.CoursesData.Any(e => e.Id == id);
        }
    }
}
