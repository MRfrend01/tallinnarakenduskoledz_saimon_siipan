using System.ComponentModel.DataAnnotations;

namespace Tallinnarakenduskolledz.Models
{
    public class Student

    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }

        // lisame kolm omandust õpilase ise mõtlen välja
        public string? Email { get; set; }           // Õpilase e-posti aadress
        public string? PhoneNumber { get; set; }     // Telefoninumber
        public DateTime DateOfBirth { get; set; }   // Sünniaeg
    }
}
