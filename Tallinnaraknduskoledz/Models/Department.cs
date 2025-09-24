using System.ComponentModel.DataAnnotations;

namespace Tallinnarakenduskolledz.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? InstructorID { get; set; }
        public Instructor? Administrator { get; set; }
        public ICollection<Course>? Courses { get; set; }
        public byte? RowVersion { get; set; }

        // 3 ise
        public int? OldInstructorID { get; set; }
        public DateTime? OldStartDate { get; set; }
        public string? OldName { get; set; }
    }
}
