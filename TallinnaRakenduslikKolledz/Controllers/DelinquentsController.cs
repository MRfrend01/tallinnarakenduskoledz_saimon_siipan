using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class DelinquentsController : Controller
    {
        private readonly SchoolContext _context;
        public DelinquentsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var delinquents = await _context.Delinquents.ToListAsync();
            return View(delinquents);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Models.Delinquent delinquent)
        {
            _context.Delinquents.Add(delinquent);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Delinquents == null) { return NotFound(); }
            var delinquent = await _context.Delinquents
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.DelinquentId == id);
            if (delinquent == null) { return NotFound(); }
            return View(delinquent);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Delinquents == null) { return Problem("Entity set 'SchoolContext.Delinquents'  is null."); }
            var delinquent = await _context.Delinquents.FindAsync(id);
            if (delinquent != null)
            {
                _context.Delinquents.Remove(delinquent);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    
            [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) { return NotFound(); }

            var delinquent = await _context.Delinquents.FirstOrDefaultAsync(x => x.DelinquentId == id);

            if (delinquent == null) { return NotFound(); }

            return View(delinquent);
        }

    }
}
