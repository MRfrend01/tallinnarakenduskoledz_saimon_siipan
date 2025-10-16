using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly SchoolContext _context;

        public DepartmentsController(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Departments.Include(d => d.Administrator);
            return View(await schoolContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["action"] = "Create";
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName");
            return View("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentID,Name,Budget,StartDate,RowVersion,InstructorID")] Department department)
        {
            ViewData["action"] = "Create";
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "Id", "FullName", department.InstructorID);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["action"] = "Delete";
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(d => d.Administrator)
                .FirstOrDefaultAsync(d => d.DepartmentID == id);

            if (department == null) { return NotFound(); }
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Department department)
        {
            if (await _context.Departments.AnyAsync(m => m.DepartmentID == department.DepartmentID))
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["action"] = "Details";
            if (id == null) { return NotFound(); }

            var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentID == id);
            return View(nameof(Delete), department);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {ViewData["action"] = "Edit";
            var deparment = await _context.Departments.FirstOrDefaultAsync(m => m.DepartmentID == id);
            return View("Create",deparment);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConfirmed(int? id, [Bind("DepartmentID,Name,Budget,StartDate,InstructorID,Courses,RowVersion,IsActive,EndDate,PhoneNumber")] Department department)
        {
            department.DepartmentID = (int)id;
            if (ModelState.IsValid)
            {
                _context.Departments.Update(department);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
