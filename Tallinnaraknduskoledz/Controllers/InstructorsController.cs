using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
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
        // GET: Instructors/Details/5

        [HttpGet]
        public IActionResult create()
        {
            var instructor = new Instructor();
            instructor.CourseAssignments = new List<CourseAssignment>();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Instructor instructor, string selectedCourses)
        {
            if (selectedCourses != null)
            {
                instructor.CourseAssignments = new List<CourseAssignment>();
                foreach (var courses in selectedCourses)
                {
                    var courseToAdd = new CourseAssignment
                    {
                        InstructorID = instructor.InstructorID,
                        CourseID = courses

                    };
                    instructor.CourseAssignments.Add(courseToAdd);
                }
            }
            ModelState.Remove("selectedCourses");
            if (ModelState.IsValid)
            {
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }
            populateAssignedCourseData(instructor);
            return View(instructor);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }
            var deletableInstructor = await _context.Instructors
                .SingleAsync(i => i.InstructorID == id);
            if (deletableInstructor == null)
            {
                return NotFound();
            }
            return View(deletableInstructor);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Instructor deletableInstructor = await _context.Instructors
                .SingleAsync(i => i.InstructorID == id);
            _context.Instructors.Remove(deletableInstructor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private void populateAssignedCourseData(Instructor instructor)
        {
            var allCourses = _context.Courses;
            var instructorCourses = new HashSet<int>(instructor.CourseAssignments.Select(c => c.CourseID));
            var vm = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                vm.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }
            ViewData["Courses"] = vm;
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id, string? selectedCourses)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instructorToUpdate = await _context.Instructors

               

                .SingleAsync(i => i.InstructorID == id);
            return View(instructorToUpdate);
    }
        [HttpPost]
        public async Task<IActionResult> Edit(Instructor instructor, string selectedCourses)
        {
            if (selectedCourses != null)
            {
                instructor.CourseAssignments = new List<CourseAssignment>();
                foreach (var courses in selectedCourses)
                {
                    var courseToAdd = new CourseAssignment
                    {
                        InstructorID = instructor.InstructorID,
                        CourseID = courses

                    };
                    instructor.CourseAssignments.Add(courseToAdd);
                }
            }
            ModelState.Remove("selectedCourses");
            if (ModelState.IsValid)
            {
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }
            //populateAssignedCourseData(instructor);
            return View(instructor);
        }
        
    }

}




