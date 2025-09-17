using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tallinnarakenduskolledz.Data;
using Tallinnarakenduskolledz.Models;

namespace Tallinnarakenduskolledz.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly SchoolContext _context;
        public InstructorsController(SchoolContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? id, int? courseid)
        {
            var vm = new InstructorIndexData();
            vm.Instructors = await _context.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.CourseAssignments)
                .ToListAsync();
            return View(vm);
        }
    }
}
