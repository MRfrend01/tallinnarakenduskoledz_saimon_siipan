using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;
        public CoursesController(SchoolContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var courses = _context.Courses.Include(c => c.Department)
            .AsNoTracking();
            return View(courses.ToList());

        }
        [HttpGet]
        public IActionResult create()
        {
            ViewData["action"] = "Create";
            populateDepartmentsDropDownlist();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            ViewData["action"] = "Edit";
            populateDepartmentsDropDownlist();
            var course = _context.Courses.Find(id);
            return View("Create");

        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            populateDepartmentsDropDownlist(course.DepartmentID);
            return View(course);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed([Bind("")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }


        [HttpPost]
        public async Task<IActionResult> delete(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }
            var course = await _context.Courses
                .Include(c => c.Enrollments)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
        [HttpPost, ActionName("delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Courses == null)
            {
                return Problem("Entity set 'SchoolContext.Courses'  is null.");
            }
            var course = await _context.Courses
                .Include(c => c.Enrollments)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private void populateDepartmentsDropDownlist(object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name
                                   select d;
            ViewBag.DepartmentID = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID"
                , "Name", selectedDepartment);
        }

    }
}
