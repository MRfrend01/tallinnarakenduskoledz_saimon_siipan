using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tallinnarakenduskolledz.Data;
using Tallinnarakenduskolledz.Models;

namespace Tallinnarakenduskolledz.Controllers
{
    public class InstructorsControllers : Controller
    {
        private readonly SchoolContext _context;
        public InstructorsControllers(SchoolContext context)
        {
            _context = context;
        }
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
