using Tallinnarakenduskolledz.Models;

namespace Tallinnarakenduskolledz.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();
            if (context.Students.Any())
            {
                return; // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{Firstname="Kati",Lastname="Kask",EnrollmentDate=DateTime.Now },
                new Student{Firstname="Jaan",Lastname="nmm",EnrollmentDate=DateTime.Now },
                new Student{Firstname="Mari",Lastname="Saar",EnrollmentDate=DateTime.Now }
            };
        }
    }
}
