using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ITToolTest.Data;
using ITToolTest.Models;
using Microsoft.AspNetCore.Authorization;

namespace ITToolTest
{   
    [Authorize(Roles = "admin")]
    public class OurCoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OurCoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OurCourses
        public async Task<IActionResult> Index()
        {

            return View(await _context.OurCourses.ToListAsync());
        }

        // GET: OurCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourCourses = await _context.OurCourses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourCourses == null)
            {
                return NotFound();
            }

            return View(ourCourses);
        }

        // GET: OurCourses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OurCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,LessonsCount,Level")] OurCourses ourCourses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ourCourses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ourCourses);
        }

        // GET: OurCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourCourses = await _context.OurCourses.FindAsync(id);
            if (ourCourses == null)
            {
                return NotFound();
            }
            return View(ourCourses);
        }

        // POST: OurCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,LessonsCount,Level")] OurCourses ourCourses)
        {
            if (id != ourCourses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ourCourses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OurCoursesExists(ourCourses.Id))
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
            return View(ourCourses);
        }

        // GET: OurCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourCourses = await _context.OurCourses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourCourses == null)
            {
                return NotFound();
            }

            return View(ourCourses);
        }

        // POST: OurCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ourCourses = await _context.OurCourses.FindAsync(id);
            _context.OurCourses.Remove(ourCourses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OurCoursesExists(int id)
        {
            return _context.OurCourses.Any(e => e.Id == id);
        }

        public List<OurCourses> GetData()
        {
            var data = _context.OurCourses.ToList();
            return data;
        }
    }
}
