using System.ComponentModel.DataAnnotations;

namespace Tallinnarakenduskolledz.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }

        public Instructor Instructor { get; set; }

        [StringLength(50)]
        [Display(Name = "Kontori asukoht")]
        public string Location { get; set; }


    }
}
