using System.ComponentModel.DataAnnotations;

namespace Tallinnarakenduskolledz.Models
{
    public class CourseAssignment
    {
        [Key]
        public int id { get; set; }
        public int InstructorID { get; set; }
        public int CourseID { get; set; }
        public Instructor Instructor { get; set; }
        public Course Course { get; set; }


    }
}
