using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tallinnarakenduskolledz.Data;

namespace Tallinnarakenduskolledz.Controllers
{
    public class DepartmentsControllers : Controller
    {
        private readonly SchoolContext _context;
        public DepartmentsControllers(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Departments.Include(d => d.Administrator);
            return View(await schoolContext.ToListAsync());
        }
    }
}
