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
                new Student{Firstname="Mari",Lastname="Saar",EnrollmentDate=DateTime.Now },
                new Student{Firstname="kala",Lastname="muna",EnrollmentDate=DateTime.Now },
                new Student{Firstname="rohl",Lastname="Sasar",EnrollmentDate=DateTime.Now },
                new Student{Firstname="kuli",Lastname="negor",EnrollmentDate=DateTime.Now },
                new Student{Firstname="riri",Lastname="risa",EnrollmentDate=DateTime.Now },
                new Student{Firstname="rari",Lastname="kool",EnrollmentDate=DateTime.Now },
                new Student{Firstname="goo",Lastname="soor",EnrollmentDate=DateTime.Now }
            };
            context.Students.AddRange(students);
            context.SaveChanges();
            if (context.Courses.Any())
            {
                return; // DB has been seeded
            }
            var courses = new Course[]
            {
                new Course{CourseID=1050,Title="Matemaatika",Credits=3,},
                new Course{CourseID=4022,Title="Füüsika",Credits=4,},
                new Course{CourseID=4041,Title="Keemia",Credits=4,},
                new Course{CourseID=1045,Title="Bioloogia",Credits=3,},
                new Course{CourseID=3141,Title="Ajalugu",Credits=4,},
                new Course{CourseID=2021,Title="Geograafia",Credits=3,},
                new Course{CourseID=2042,Title="Inglise keel",Credits=4,},
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();
            if (context.Enrollments.Any())
            {
                return; // DB has been seeded
            }
            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
                new Enrollment{StudentID=2,CourseID=4041,Grade=Grade.B},
                new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.D},
                new Enrollment{StudentID=3,CourseID=3141,Grade=Grade.F},
                new Enrollment{StudentID=3,CourseID=2021,Grade=Grade.F},
                new Enrollment{StudentID=4,CourseID=2042,Grade=Grade.A},
                new Enrollment{StudentID=4,CourseID=1050,Grade=Grade.F},
                new Enrollment{StudentID=5,CourseID=4022,Grade=Grade.C},
                new Enrollment{StudentID=5,CourseID=2021,Grade=Grade.C},
                new Enrollment{StudentID=6,CourseID=4041,Grade=Grade.A},
                new Enrollment{StudentID=6,CourseID=4041,Grade=Grade.A},
                new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.F},
                new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.F},
            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
            if (context.Instructors.Any())
            {
                return; // DB has been seeded
            }
            var instructors = new Instructor[]
            {
                new Instructor{FirstName="Piret",LastName="Puu",HireDate=DateTime.Now, AmountOfCars="6"},
                new Instructor{FirstName="Jüri",LastName="Juurikas",HireDate=DateTime.Now, AmountOfCars="6"},
                new Instructor{FirstName="Mari",LastName="Mets",HireDate=DateTime.Now, homes="2" },
            };
            context.Instructors.AddRange(instructors);
            context.SaveChanges();
        }
    }
}
