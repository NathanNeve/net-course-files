using System;
using System.Linq;

namespace FinalExercise.Data
{

    public class DBInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any products.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            // Add some test data for programmes
            var programmes = new Programme[]
            {
            new Programme{Name="Computer Science"},
            new Programme{Name="Engineering"},
            new Programme{Name="Business Administration"}
            };
            foreach (Programme p in programmes)
            {
                context.Programmes.Add(p);
            }
            context.SaveChanges();

            // Add some test data for courses
            var courses = new Course[]
            {
            new Course{Name="Mathematics", ProgrammeId = 1},
            new Course{Name="Physics", ProgrammeId = 1},
            new Course{Name="Chemistry", ProgrammeId = 2},
            new Course{Name="Biology", ProgrammeId = 2},
            new Course{Name="History", ProgrammeId = 3}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            // Add some test data for students
            var students = new Student[]
            {
            new Student{FirstName="John",LastName="Doe"},
            new Student{FirstName="Jane",LastName="Smith"},
            new Student{FirstName="Michael",LastName="Johnson"},
            new Student{FirstName="Emily",LastName="Brown"},
            new Student{FirstName="David",LastName="Wilson"},
            new Student{FirstName="Emma",LastName="Jones"},
            new Student{FirstName="Daniel",LastName="Taylor"}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();



            // Add some test data for enrollments
            var enrollments = new Enrollment[]
            {
            new Enrollment{StudentId=1,CourseId=1},
            new Enrollment{StudentId=1,CourseId=2},
            new Enrollment{StudentId=2,CourseId=2},
            new Enrollment{StudentId=3,CourseId=3},
            new Enrollment{StudentId=4,CourseId=4},
            new Enrollment{StudentId=4,CourseId=5},
            new Enrollment{StudentId=5,CourseId=1},
            new Enrollment{StudentId=6,CourseId=3},
            new Enrollment{StudentId=7,CourseId=4}
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }

            context.SaveChanges();
        }
    }
}