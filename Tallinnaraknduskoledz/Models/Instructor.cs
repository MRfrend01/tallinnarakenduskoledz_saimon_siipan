using System.ComponentModel.DataAnnotations;

namespace Tallinnarakenduskolledz.Models
{
    public class Instructor
    {
        [Key]
        public int InstructorID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "perekonnanimi")]
        public string LastName { get; set; }
        /**/
        [Required]
        [StringLength(50)]
        [Display(Name = "eesnimi")]

        public string FirstName { get; set; }
        [Display(Name = "Õpetaja nimi")]

        public string FullName
        {
            get { return FirstName + " " + LastName; }

        }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "tööleasumiskuupäev")]
        public DateTime HireDate { get; set; }

        public ICollection<CourseAssignment>? CourseAssignments { get; set; }
        public OfficeAssignment? OfficeAssignment { get; set; }
        // lisan ise 3 omadust

        
    }
}
